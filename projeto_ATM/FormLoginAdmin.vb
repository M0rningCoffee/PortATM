Public Class FormLoginAdmin

    ' Contador de erros local para esta tela
    Private errosAdmin As Integer = 0

    Private Sub btn_confirmar_login_Click(sender As Object, e As EventArgs) Handles btn_confirmar_login.Click
        ' 1. Validação das credenciais fixas (admin / admin)
        If txt_usuario_admin.Text = "admin" AndAlso txt_senha_admin.Text = "admin" Then
            MessageBox.Show("Autenticação de Administrador Confirmada!", "Bem-vindo", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Abre o painel com as tabelas de usuários e transações
            Dim painelAdmin As New FormAdmin()
            painelAdmin.Show()

            ' Fecha esta tela de login
            Me.Close()
        Else
            ' 2. Se as credenciais estiverem incorretas, soma um erro
            errosAdmin += 1

            If errosAdmin >= 3 Then
                MessageBox.Show("Acesso administrativo bloqueado por excesso de erros!", "BLOQUEADO", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                ' Força o sistema a voltar para a tela inicial do cartão
                VoltarParaTelaCartao()
                Me.Close()
            Else
                Dim tentativasRestantes As Integer = 3 - errosAdmin
                MessageBox.Show($"Usuário ou Senha incorretos! Você tem mais {tentativasRestantes} tentativa(s).", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' Limpa os campos para nova tentativa
                txt_senha_admin.Clear()
                txt_usuario_admin.Focus()
            End If
        End If
    End Sub

    ' Função auxiliar para achar e mostrar o formulário do cartão
    Private Sub VoltarParaTelaCartao()
        For Each f As Form In Application.OpenForms
            If TypeOf f Is Cartao_acesso Then
                f.Show()
                Exit For
            End If
        Next
    End Sub

    ' Se o administrador clicar no "X" para fechar a tela sem logar, o sistema também volta para o início
    Private Sub FormLoginAdmin_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' Só reexibe o cartão se o painel principal (FormAdmin) não estiver aberto
        Dim painelAberto As Boolean = False
        For Each f As Form In Application.OpenForms
            If TypeOf f Is FormAdmin Then
                painelAberto = True
                Exit For
            End If
        Next

        If Not painelAberto Then
            VoltarParaTelaCartao()
        End If
    End Sub
End Class