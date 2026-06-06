Imports MySql.Data.MySqlClient
Public Class Formsenhadeposito
    Private Sub Button1SD_Click(sender As Object, e As EventArgs) Handles Button1SD.Click
        txt_senha_deposito.Text &= "1"

    End Sub

    Private Sub Button2SD_Click(sender As Object, e As EventArgs) Handles Button2SD.Click
        txt_senha_deposito.Text &= "2"

    End Sub
    Private Sub Button3SD_Click(sender As Object, e As EventArgs) Handles Button3SD.Click
        txt_senha_deposito.Text &= "3"

    End Sub
    Private Sub Button4SD_Click(sender As Object, e As EventArgs) Handles Button4SD.Click
        txt_senha_deposito.Text &= "4"

    End Sub
    Private Sub Button5SD_Click(sender As Object, e As EventArgs) Handles Button5SD.Click
        txt_senha_deposito.Text &= "5"

    End Sub
    Private Sub Button6SD_Click(sender As Object, e As EventArgs) Handles Button6SD.Click
        txt_senha_deposito.Text &= "6"

    End Sub
    Private Sub Button7SD_Click(sender As Object, e As EventArgs) Handles Button7SD.Click
        txt_senha_deposito.Text &= "7"

    End Sub
    Private Sub Button8SD_Click(sender As Object, e As EventArgs) Handles Button8SD.Click
        txt_senha_deposito.Text &= "8"

    End Sub
    Private Sub Button9SD_Click(sender As Object, e As EventArgs) Handles Button9SD.Click
        txt_senha_deposito.Text &= "9"

    End Sub
    Private Sub Button0SD_Click(sender As Object, e As EventArgs) Handles Button0SD.Click
        txt_senha_deposito.Text &= "0"

    End Sub

    Private Sub btn_CancelSD_Click(sender As Object, e As EventArgs) Handles btn_CancelSD.Click
        If txt_senha_deposito.Text.Length > 0 Then
            txt_senha_deposito.Text = txt_senha_deposito.Text.Substring(0, txt_senha_deposito.Text.Length - 1)
        End If
    End Sub

    Private Sub btn_ClearSD_Click(sender As Object, e As EventArgs) Handles btn_ClearSD.Click
        txt_senha_deposito.Clear()
    End Sub

    ' 1. BOTÃO CONFIRMAR DEPÓSITO
    Private Sub btn_confirmar_Click(sender As Object, e As EventArgs) Handles btn_confirmar.Click
        ' PASSO A: Valida a senha digitada
        If txt_senha_deposito.Text <> Cartao_acesso.SenhaCorreta Then
            MessageBox.Show("Senha incorreta! A transação não pode ser concluída.", "Erro de Segurança", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txt_senha_deposito.Clear()
            txt_senha_deposito.Focus()
            Exit Sub
        End If

        ' PASSO B: Conecta e salva no banco de dados
        Dim conexaoBanco As New ConexaoBanco()
        Dim conn As MySqlConnection = conexaoBanco.ConectarBanco()

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            ' ====================================================================
            ' TRATAMENTO DE DADOS (Evita o erro "Fatal Error")
            ' 1. Converte o ID para Número (caso o banco exija INT)
            Dim idConta As Integer = Convert.ToInt32(Cartao_acesso.IDContaLogada)

            ' 2. Formata a data para o padrão internacional exato do MySQL (Ano-Mes-Dia Hora:Minuto:Segundo)
            Dim dataFormatada As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

            ' 3. Garante que o valor venha limpo
            Dim valorFormatado As Decimal = FormDeposito.ValorGuardado
            ' ====================================================================

            ' 1. Atualiza o saldo do usuário na tabela 'contas'
            Dim sqlUpdate As String = "UPDATE `contas` SET `saldo` = `saldo` + @valor WHERE `id_conta` = @id;"
            Using cmdUpdate As New MySqlCommand(sqlUpdate, conn)
                cmdUpdate.Parameters.AddWithValue("@valor", valorFormatado)
                cmdUpdate.Parameters.AddWithValue("@id", idConta)
                cmdUpdate.ExecuteNonQuery()
            End Using

            ' 2. Grava o histórico na tabela 'registro'
            Dim sqlRegistro As String = "INSERT INTO `registros` (`data`, `id_conta_to`, `id_conta_from`, `operacao`, `valor`) " &
                                        "VALUES (@data, @id_to, @id_from, @operacao, @valor);"

            Using cmdRegistro As New MySqlCommand(sqlRegistro, conn)
                ' Agora passamos as variáveis tratadas
                cmdRegistro.Parameters.AddWithValue("@data", dataFormatada)
                cmdRegistro.Parameters.AddWithValue("@id_to", idConta)
                cmdRegistro.Parameters.AddWithValue("@id_from", idConta)
                cmdRegistro.Parameters.AddWithValue("@operacao", "Depósito")
                cmdRegistro.Parameters.AddWithValue("@valor", valorFormatado)

                cmdRegistro.ExecuteNonQuery() ' É geralmente aqui que o Fatal Error ocorria
            End Using

            ' Mensagem de Sucesso
            MessageBox.Show("Depósito de " & valorFormatado.ToString("C") & " concluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Volta ao menu principal e fecha as telas de depósito
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Erro ao realizar o depósito: " & ex.Message & vbCrLf & vbCrLf & "Detalhe Técnico: Pode haver um nome de coluna escrito diferente no MySQL.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' 2. BOTÃO CANCELAR (Desiste da operação)
    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        VoltarParaMenuPrincipal()
    End Sub

    ' Função para limpar a memória e voltar ao menu de forma segura
    Private Sub VoltarParaMenuPrincipal()
        ' 1. Procura o menu principal que está escondido e mostra ele
        For Each f As Form In Application.OpenForms
            If TypeOf f Is menu_principal Then
                f.Show() ' <--- A CORREÇÃO FOI FEITA AQUI!
                Exit For
            End If
        Next

        ' 2. Fecha o formulário de valor que estava escondido
        For Each f As Form In Application.OpenForms
            If TypeOf f Is FormDeposito Then
                DirectCast(f, FormDeposito).Close()
                Exit For
            End If
        Next

        ' 3. Fecha a própria tela de senha
        Me.Close()
    End Sub

    Private Sub FormSenhaDeposito_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        menu_principal.Show()
    End Sub

End Class