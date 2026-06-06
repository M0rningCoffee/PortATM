Imports MySql.Data.MySqlClient

Public Class FormSenhaSaque
    Private Sub Button1D_Click(sender As Object, e As EventArgs) Handles Button1D.Click
        txt_senha_saque.Text &= "1"

    End Sub

    Private Sub Button2D_Click(sender As Object, e As EventArgs) Handles Button2D.Click
        txt_senha_saque.Text &= "2"

    End Sub
    Private Sub Button3D_Click(sender As Object, e As EventArgs) Handles Button3D.Click
        txt_senha_saque.Text &= "3"

    End Sub
    Private Sub Button4D_Click(sender As Object, e As EventArgs) Handles Button4D.Click
        txt_senha_saque.Text &= "4"

    End Sub
    Private Sub Button5D_Click(sender As Object, e As EventArgs) Handles Button5D.Click
        txt_senha_saque.Text &= "5"

    End Sub
    Private Sub Button6D_Click(sender As Object, e As EventArgs) Handles Button6D.Click
        txt_senha_saque.Text &= "6"

    End Sub
    Private Sub Button7D_Click(sender As Object, e As EventArgs) Handles Button7D.Click
        txt_senha_saque.Text &= "7"

    End Sub
    Private Sub Button8D_Click(sender As Object, e As EventArgs) Handles Button8D.Click
        txt_senha_saque.Text &= "8"

    End Sub

    Private Sub Button9D_Click(sender As Object, e As EventArgs) Handles Button9D.Click
        txt_senha_saque.Text &= "9"

    End Sub
    Private Sub Button0D_Click(sender As Object, e As EventArgs) Handles Button0D.Click
        txt_senha_saque.Text &= "0"

    End Sub

    Private Sub btn_CancelD_Click(sender As Object, e As EventArgs) Handles btn_CancelD.Click
        If txt_senha_saque.Text.Length > 0 Then
            txt_senha_saque.Text = txt_senha_saque.Text.Substring(0, txt_senha_saque.Text.Length - 1)
        End If
    End Sub

    Private Sub btn_ClearD_Click(sender As Object, e As EventArgs) Handles btn_ClearD.Click
        txt_senha_saque.Clear()
    End Sub



    ' 1. BOTÃO CONFIRMAR SAQUE
    Private Sub btn_confirmar_Click(sender As Object, e As EventArgs) Handles btn_confirmar.Click
            ' PASSO A: Valida a senha digitada
            If txt_senha_saque.Text <> Cartao_acesso.SenhaCorreta Then
                MessageBox.Show("Senha incorreta! A transação não pode ser concluída.", "Erro de Segurança", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_senha_saque.Clear()
                txt_senha_saque.Focus()
                Exit Sub
            End If

            ' PASSO B: Conecta ao banco para verificar saldo e gravar
            Dim conexaoBanco As New ConexaoBanco()
            Dim conn As MySqlConnection = conexaoBanco.ConectarBanco()

            Try
                If conn.State = ConnectionState.Closed Then conn.Open()

            ' ====================================================================
            ' TRATAMENTO DE DADOS ANTIFALHA
            Dim idConta As Integer = Convert.ToInt32(Cartao_acesso.IDContaLogada)
            Dim dataFormatada As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                Dim valorFormatado As Decimal = FormSaque.ValorGuardado
                ' ====================================================================

                ' PASSO C: VERIFICAR SE TEM SALDO SUFICIENTE
                Dim sqlSaldo As String = "SELECT `saldo` FROM `contas` WHERE `id_conta` = @id;"
                Dim saldoAtual As Decimal = 0

                Using cmdSaldo As New MySqlCommand(sqlSaldo, conn)
                    cmdSaldo.Parameters.AddWithValue("@id", idConta)
                    Dim resultado As Object = cmdSaldo.ExecuteScalar()
                    If resultado IsNot Nothing AndAlso Not IsDBNull(resultado) Then
                        saldoAtual = Convert.ToDecimal(resultado)
                    End If
                End Using

                ' Se tentar sacar mais do que tem, bloqueia na hora!
                If valorFormatado > saldoAtual Then
                    MessageBox.Show("Saldo insuficiente para realizar este saque!", "Operação Negada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txt_senha_saque.Clear()
                    Exit Sub
                End If

                ' PASSO D: Desconta o dinheiro da conta (USANDO O SINAL DE MENOS)
                Dim sqlUpdate As String = "UPDATE `contas` SET `saldo` = `saldo` - @valor WHERE `id_conta` = @id;"
                Using cmdUpdate As New MySqlCommand(sqlUpdate, conn)
                    cmdUpdate.Parameters.AddWithValue("@valor", valorFormatado)
                    cmdUpdate.Parameters.AddWithValue("@id", idConta)
                    cmdUpdate.ExecuteNonQuery()
                End Using

            ' PASSO E: Grava o histórico na tabela 'registro'
            Dim sqlRegistro As String = "INSERT INTO `registros` (`data`, `id_conta_to`, `id_conta_from`, `operacao`, `valor`) " &
                                            "VALUES (@data, @id_to, @id_from, @operacao, @valor);"

            Using cmdRegistro As New MySqlCommand(sqlRegistro, conn)
                    cmdRegistro.Parameters.AddWithValue("@data", dataFormatada)
                    cmdRegistro.Parameters.AddWithValue("@id_to", idConta)
                    cmdRegistro.Parameters.AddWithValue("@id_from", idConta)
                    cmdRegistro.Parameters.AddWithValue("@operacao", "Saque")
                    cmdRegistro.Parameters.AddWithValue("@valor", valorFormatado)

                    cmdRegistro.ExecuteNonQuery()
                End Using

                ' Mensagem de Sucesso
                MessageBox.Show("Saque de " & valorFormatado.ToString("C") & " autorizado! Por favor, retire o seu dinheiro.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Manda fechar esta tela (isso aciona o FormClosed que volta para o menu)
                Me.Close()

            Catch ex As Exception
                MessageBox.Show("Erro ao realizar o saque: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If conn.State = ConnectionState.Open Then conn.Close()
            End Try
        End Sub

        ' 2. BOTÃO CANCELAR (Desiste da operação)
        Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
            Me.Close()
        End Sub

        ' 3. Função segura para limpar a memória e voltar ao menu (Mesma lógica do depósito)
        Private Sub FormSenhaSaque_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
            ' Mostra o menu principal
            For Each f As Form In Application.OpenForms
                If TypeOf f Is menu_principal Then
                    f.Show()
                    Exit For
                End If
            Next

            ' Fecha a tela de digitação de valor (FormSaque) que estava apenas escondida
            Dim telaAntiga As Form = Nothing
            For Each f As Form In Application.OpenForms
                If TypeOf f Is FormSaque Then
                    telaAntiga = f
                    Exit For
                End If
            Next

            If telaAntiga IsNot Nothing Then
                telaAntiga.Close()
            End If
        End Sub

    End Class
