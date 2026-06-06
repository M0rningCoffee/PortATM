Public Class FormSaque
    Private Sub Button1D_Click(sender As Object, e As EventArgs) Handles Button1D.Click
        txt_valor_saque.Text &= "1"

    End Sub

    Private Sub Button2D_Click(sender As Object, e As EventArgs) Handles Button2D.Click
        txt_valor_saque.Text &= "2"

    End Sub
    Private Sub Button3D_Click(sender As Object, e As EventArgs) Handles Button3D.Click
        txt_valor_saque.Text &= "3"

    End Sub
    Private Sub Button4D_Click(sender As Object, e As EventArgs) Handles Button4D.Click
        txt_valor_saque.Text &= "4"

    End Sub
    Private Sub Button5D_Click(sender As Object, e As EventArgs) Handles Button5D.Click
        txt_valor_saque.Text &= "5"

    End Sub
    Private Sub Button6D_Click(sender As Object, e As EventArgs) Handles Button6D.Click
        txt_valor_saque.Text &= "6"

    End Sub
    Private Sub Button7D_Click(sender As Object, e As EventArgs) Handles Button7D.Click
        txt_valor_saque.Text &= "7"

    End Sub
    Private Sub Button8D_Click(sender As Object, e As EventArgs) Handles Button8D.Click
        txt_valor_saque.Text &= "8"

    End Sub

    Private Sub Button9D_Click(sender As Object, e As EventArgs) Handles Button9D.Click
        txt_valor_saque.Text &= "9"

    End Sub
    Private Sub Button0D_Click(sender As Object, e As EventArgs) Handles Button0D.Click
        txt_valor_saque.Text &= "0"

    End Sub

    Private Sub btn_CancelD_Click(sender As Object, e As EventArgs) Handles btn_CancelD.Click
        If txt_valor_saque.Text.Length > 0 Then
            txt_valor_saque.Text = txt_valor_saque.Text.Substring(0, txt_valor_saque.Text.Length - 1)
        End If
    End Sub

    Private Sub btn_ClearD_Click(sender As Object, e As EventArgs) Handles btn_ClearD.Click
        txt_valor_saque.Clear()
    End Sub

    ' Variável pública para guardar o valor do saque e enviar para a tela de senha
    Public Shared ValorGuardado As Decimal = 0

    ' 1. BOTÃO CONTINUAR (Vai para a tela de senha)
    Private Sub btn_continuar_Click(sender As Object, e As EventArgs) Handles btn_continuar.Click
        ' Verifica se o valor digitado é válido
        If Not Decimal.TryParse(txt_valor_saque.Text, ValorGuardado) OrElse ValorGuardado <= 0 Then
            MessageBox.Show("Por favor, digite um valor válido e maior que zero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_valor_saque.Focus()
            Exit Sub
        End If

        ' Se o valor estiver OK, abre a tela de senha
        Dim telaSenha As New FormSenhaSaque()
        telaSenha.Show()

        ' Esconde esta tela de valor
        Me.Hide()
    End Sub

    ' 2. BOTÃO VOLTAR
    Private Sub btn_voltar_Click(sender As Object, e As EventArgs) Handles btn_voltar.Click
        For Each f As Form In Application.OpenForms
            If TypeOf f Is menu_principal Then
                f.Show()
                Exit For
            End If
        Next
        Me.Close()
    End Sub

    ' 3. Se fechar no "X" vermelho
    Private Sub FormSaque_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        For Each f As Form In Application.OpenForms
            If TypeOf f Is menu_principal Then
                f.Show()
                Exit For
            End If
        Next
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click

    End Sub

    Private Sub txt_valor_saque_TextChanged(sender As Object, e As EventArgs) Handles txt_valor_saque.TextChanged

    End Sub
End Class