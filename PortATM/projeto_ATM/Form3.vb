Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class frm_registro
    Dim str As String = "server=localhost; uid=root; pwd=; database=atm"
    Dim conn As New MySqlConnection(str)

    Private Sub LimparFormulario()
        ' Limpa as caixas de texto
        txt_usuario.Clear()
        txt_cpf.Clear()
        txt_nome.Clear()
        txt_cartao.Clear()
        txt_senha.Clear()
        txt_agencia.Clear()

        ' Reseta o DateTimePicker para a data de hoje
        DateTimePicker1.Value = DateTime.Now

        ' Desmarca ou reseta os RadioButtons (opcional)
        RadioButton1.Checked = False
        ' Se tiver um RadioButton2 para "Female", pode desmarcar também:
        ' RadioButton2.Checked = False

        ' Coloca o cursor de digitação de volta no primeiro campo
        txt_usuario.Focus()
    End Sub

    Private Sub btn_salvar_Click(sender As Object, e As EventArgs) Handles btn_salvar.Click
        Dim gend As String
        If RadioButton1.Checked = True Then
            gend = "Male"
        Else
            gend = "Female"
        End If

        ' 1. Abertura da conexão
        conn.Open()

        Try
            ' =========================================================================
            ' PASSO 1: VERIFICAÇÃO DE DUPLICIDADE
            ' =========================================================================
            Dim sqlCheck As String = "SELECT `id_conta`, `cpf`, `cartao`, `agencia` FROM `contas` " &
                                     "WHERE `id_conta` = @id_conta OR `cpf` = @cpf OR `cartao` = @cartao OR `agencia` = @agencia;"

            Dim cmdCheck As New MySqlCommand(sqlCheck, conn)
            cmdCheck.Parameters.AddWithValue("@id_conta", txt_usuario.Text)
            cmdCheck.Parameters.AddWithValue("@cpf", txt_cpf.Text) ' Certifique-se de usar o campo correto de CPF aqui
            cmdCheck.Parameters.AddWithValue("@cartao", txt_cartao.Text)
            cmdCheck.Parameters.AddWithValue("@agencia", txt_agencia.Text) ' Ajuste para a sua TextBox de agência

            Dim reader As MySqlDataReader = cmdCheck.ExecuteReader()

            ' Se o reader encontrar alguma linha, significa que algo já existe
            If reader.Read() Then
                Dim mensagemErro As String = "Não foi possível cadastrar:" & vbCrLf

                ' Verifica qual campo específico gerou a duplicidade
                If reader("id_conta").ToString() = txt_usuario.Text Then
                    mensagemErro &= "- Este ID de Conta já está em uso." & vbCrLf
                End If
                If reader("cpf").ToString() = txt_cpf.Text Then
                    mensagemErro &= "- Este CPF já está cadastrado." & vbCrLf
                End If
                If reader("cartao").ToString() = txt_cartao.Text Then
                    mensagemErro &= "- Este número de Cartão já está em uso." & vbCrLf
                End If
                ' Nota: Agências costumam se repetir entre contas diferentes. 
                ' Se você quer que a combinação AGÊNCIA única bloqueie, o teste abaixo faz isso:
                If reader("agencia").ToString() = txt_agencia.Text Then
                    mensagemErro &= "- Esta Agência já está registrada." & vbCrLf
                End If

                MsgBox(mensagemErro, MsgBoxStyle.Exclamation, "Dados Duplicados")

                reader.Close() ' Fecha o reader
                conn.Close()   ' Fecha a conexão
                Exit Sub       ' Para a execução aqui e NÃO faz o insert
            End If

            reader.Close() ' Fecha o reader para podermos usar a conexão no INSERT

            ' =========================================================================
            ' PASSO 2: INSERÇÃO DOS DADOS (Só acontece se não caiu no Exit Sub acima)
            ' =========================================================================
            Dim cmb As MySqlCommand = conn.CreateCommand()
            cmb.CommandText = "INSERT INTO `contas` (`id_conta`, `cpf`, `nome completo`, `Genero`, `aniversario`, `saldo`, `cartao`, `pin`, `agencia`, `cc`, `pix`) VALUES (@id_conta, @cpf, @nome_completo, @genero, @aniversario, @saldo, @cartao, @pin, @agencia, @cc, @pix);"

            cmb.Parameters.AddWithValue("@id_conta", txt_usuario.Text)
            cmb.Parameters.AddWithValue("@cpf", txt_cpf.Text)
            cmb.Parameters.AddWithValue("@nome_completo", txt_nome.Text)
            cmb.Parameters.AddWithValue("@genero", gend)
            cmb.Parameters.AddWithValue("@aniversario", DateTimePicker1.Value)
            cmb.Parameters.AddWithValue("@saldo", "")
            cmb.Parameters.AddWithValue("@cartao", txt_cartao.Text)
            cmb.Parameters.AddWithValue("@pin", txt_senha.Text)
            cmb.Parameters.AddWithValue("@agencia", txt_agencia.Text)
            cmb.Parameters.AddWithValue("@cc", "")
            cmb.Parameters.AddWithValue("@pix", "")

            cmb.ExecuteNonQuery()
            MsgBox("Novo registro gravado com sucesso!", MsgBoxStyle.Information, "Sucesso")

            LimparFormulario()
        Catch ex As Exception
            MsgBox("Erro na operação: " & ex.Message, MsgBoxStyle.Critical, "Erro")
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

    End Sub

    Private Sub frm_registro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub BuscarEPreencher(ByVal nomeCampoBanco As String, ByVal valorBuscado As String)
        ' Se o campo estiver vazio, não faz nada
        If String.IsNullOrWhiteSpace(valorBuscado) Then Exit Sub

        ' Query dinâmica que busca pelo campo que disparou o evento
        Dim sql As String = $"SELECT * FROM `contas` WHERE `{nomeCampoBanco}` = @valor LIMIT 1;"

        ' Abre a conexão se ela estiver fechada
        If conn.State = ConnectionState.Closed Then conn.Open()

        Try
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@valor", valorBuscado)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    ' Se encontrou o registro no banco de dados
                    If reader.Read() Then
                        ' Preenche as TextBoxes com os dados do banco
                        txt_usuario.Text = reader("id_conta").ToString()
                        txt_cpf.Text = reader("cpf").ToString()
                        txt_nome.Text = reader("nome completo").ToString()
                        txt_cartao.Text = reader("cartao").ToString()
                        txt_senha.Text = reader("pin").ToString() ' Preenche a senha/pin
                        txt_agencia.Text = reader("agencia").ToString()

                        ' Preenche o DateTimePicker (converte de string/date para o componente)
                        ' Verifica se o campo não está nulo no banco antes de tentar converter
                        If Not IsDBNull(reader("aniversario")) AndAlso reader("aniversario").ToString() <> "" Then
                            Dim dataBanco As Object = reader("aniversario")

                            ' Se o banco já devolver como um tipo Date nativo
                            If TypeOf dataBanco Is Date Then
                                DateTimePicker1.Value = DirectCast(dataBanco, Date)
                            Else
                                ' Se o banco devolver como texto, tenta converter de forma segura
                                Dim dataConvertida As Date
                                If Date.TryParse(dataBanco.ToString(), dataConvertida) Then
                                    DateTimePicker1.Value = dataConvertida
                                Else
                                    ' Caso o formato falhe totalmente, define a data de hoje para não travar o programa
                                    DateTimePicker1.Value = DateTime.Now
                                End If
                            End If
                        Else
                            ' Se estiver vazio ou nulo no banco, define a data de hoje por padrão
                            DateTimePicker1.Value = DateTime.Now
                        End If

                        ' Preenche o Gênero
                        Dim genero As String = reader("Genero").ToString()
                        If genero.Equals("Male", StringComparison.OrdinalIgnoreCase) Then
                            RadioButton1.Checked = True
                        Else
                            RadioButton2.Checked = True ' Se você tiver o RadioButton para Female
                        End If

                        ' Opcional: Avisa sutilmente na barra de status ou muda a cor (opcional)
                    End If
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Erro ao buscar dados: " & ex.Message, MsgBoxStyle.Critical, "Erro")
        Finally
            ' Sempre fecha a conexão
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub
    ' Quando o usuário sai do campo de Usuário
    Private Sub txt_usuario_Leave(sender As Object, e As EventArgs) Handles txt_usuario.Leave
        BuscarEPreencher("id_conta", txt_usuario.Text)
    End Sub

    ' Quando o usuário sai do campo de CPF
    Private Sub txt_cpf_Leave(sender As Object, e As EventArgs) Handles txt_cpf.Leave
        BuscarEPreencher("cpf", txt_cpf.Text)
    End Sub

    ' Quando o usuário sai do campo de Cartão
    Private Sub txt_cartao_Leave(sender As Object, e As EventArgs) Handles txt_cartao.Leave
        BuscarEPreencher("cartao", txt_cartao.Text)
    End Sub

    ' Quando o usuário sai do campo de Agência
    ' NOTA: Como várias pessoas usam a mesma agência, isso trará a PRIMEIRA conta que encontrar com ela.
    Private Sub txt_agencia_Leave(sender As Object, e As EventArgs) Handles txt_agencia.Leave
        BuscarEPreencher("agencia", txt_agencia.Text)
    End Sub

    Private Sub btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click
        ' 1. Validação básica: verifica se há um ID de conta digitado ou carregado na tela
        If String.IsNullOrWhiteSpace(txt_usuario.Text) Then
            MessageBox.Show("Por favor, selecione ou digite o ID da conta que deseja excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_usuario.Focus()
            Exit Sub
        End If

        ' 2. Pergunta de segurança para o usuário
        Dim resposta As MsgBoxResult
        resposta = MsgBox("Tem certeza de que deseja excluir permanentemente a conta do usuário '" & txt_usuario.Text & "'?",
                          MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2,
                          "Confirmar Exclusão")

        ' Se o usuário clicar em 'Não', cancela a exclusão
        If resposta = MsgBoxResult.No Then Exit Sub

        ' 3. Processo de exclusão no banco de dados
        If conn.State = ConnectionState.Closed Then conn.Open()

        Try
            Dim sql As String = "DELETE FROM `contas` WHERE `id_conta` = @id_conta;"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@id_conta", txt_usuario.Text)

                ' Executa o comando e retorna a quantidade de linhas afetadas
                Dim linhasAfetadas As Integer = cmd.ExecuteNonQuery()

                ' Se retornou mais que 0, significa que a conta existia e foi apagada
                If linhasAfetadas > 0 Then
                    MsgBox("Conta excluída com sucesso!", MsgBoxStyle.Information, "Sucesso")

                    ' Reaproveita a função que criamos antes para limpar a tela
                    LimparFormulario()
                Else
                    ' Se nenhuma linha foi afetada, o ID digitado não existia no banco
                    MsgBox("Nenhuma conta foi encontrada com o ID informado.", MsgBoxStyle.Exclamation, "Não Encontrado")
                End If
            End Using

        Catch ex As Exception
            MsgBox("Erro ao tentar excluir a conta: " & ex.Message, MsgBoxStyle.Critical, "Erro de Banco de Dados")
        Finally
            ' Garante o fechamento da conexão
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        ' 1. Validação básica: garante que existe um ID de conta na tela para saber quem atualizar
        If String.IsNullOrWhiteSpace(txt_usuario.Text) Then
            MessageBox.Show("Por favor, selecione ou busque uma conta antes de tentar atualizar os dados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_usuario.Focus()
            Exit Sub
        End If

        ' Definição do gênero com base nos RadioButtons
        Dim gend As String
        If RadioButton1.Checked = True Then
            gend = "Male"
        Else
            gend = "Female"
        End If

        ' 2. Pergunta de confirmação ao usuário
        Dim resposta As DialogResult
        resposta = MessageBox.Show("Deseja realmente salvar as alterações para a conta '" & txt_usuario.Text & "'?",
                                   "Confirmar Atualização",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question)

        If resposta = DialogResult.No Then Exit Sub

        ' 3. Processo de atualização no MySQL
        If conn.State = ConnectionState.Closed Then conn.Open()

        Try
            ' Query SQL para atualizar os campos desejados com base no id_conta
            Dim sql As String = "UPDATE `contas` SET " &
                                 "`cpf` = @cpf, " &
                                 "`nome completo` = @nome_completo, " &
                                 "`Genero` = @genero, " &
                                 "`aniversario` = @aniversario, " &
                                 "`cartao` = @cartao, " &
                                 "`pin` = @pin, " &
                                 "`agencia` = @agencia " &
                                 "WHERE `id_conta` = @id_conta;"

            Using cmd As New MySqlCommand(sql, conn)
                ' Parâmetros que vão substituir os @valores na Query
                cmd.Parameters.AddWithValue("@id_conta", txt_usuario.Text) ' O ID usado no WHERE para localizar o registro
                cmd.Parameters.AddWithValue("@cpf", txt_cpf.Text)
                cmd.Parameters.AddWithValue("@nome_completo", txt_nome.Text)
                cmd.Parameters.AddWithValue("@genero", gend)
                cmd.Parameters.AddWithValue("@aniversario", DateTimePicker1.Value)
                cmd.Parameters.AddWithValue("@cartao", txt_cartao.Text)
                cmd.Parameters.AddWithValue("@pin", txt_senha.Text) ' Atualiza a senha/pin com o que estiver na txt_senha
                cmd.Parameters.AddWithValue("@agencia", txt_agencia.Text)

                ' Executa o comando de atualização
                Dim linhasAfetadas As Integer = cmd.ExecuteNonQuery()

                If linhasAfetadas > 0 Then
                    MessageBox.Show("Dados atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Limpa o formulário após atualizar com sucesso para o próximo uso
                    LimparFormulario()
                Else
                    MessageBox.Show("Nenhuma alteração foi feita ou a conta não foi encontrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Erro ao atualizar os dados: " & ex.Message, "Erro de Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Garante que a conexão sempre feche
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

End Class
