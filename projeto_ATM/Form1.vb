
Imports MySql.Data.MySqlClient
Imports projeto_ATM.MóduloGeral
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ConexaoBanco = New ConexaoBanco()
        Dim Conn = ConexaoBanco.ConectarBanco()
        'MsgBox("Conectado com Sucesso!")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txt_display.Text &= "1"

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txt_display.Text &= "2"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        txt_display.Text &= "3"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        txt_display.Text &= "4"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        txt_display.Text &= "5"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        txt_display.Text &= "6"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        txt_display.Text &= "7"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        txt_display.Text &= "8"
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        txt_display.Text &= "9"
    End Sub

    Private Sub Button0_Click(sender As Object, e As EventArgs) Handles Button0.Click
        txt_display.Text &= "0"
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        If txt_display.Text.Length > 0 Then
            txt_display.Text = txt_display.Text.Substring(0, txt_display.Text.Length - 1)
        End If
    End Sub

    Private Sub btn_Clear_Click(sender As Object, e As EventArgs) Handles btn_Clear.Click
        txt_display.Clear()
    End Sub

    Private Sub btn_Enter_Click(sender As Object, e As EventArgs) Handles btn_Enter.Click
        'If txt_display.Text <= saldo(Id) Then
        '    MsgBox("Saque efetuado com sucesso!")

        'End If
    End Sub
End Class

Public Class ConexaoBanco
    Dim conexao As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader

    Function ConectarBanco() As MySqlConnection
        conexao = New MySqlConnection
        conexao.ConnectionString = "server=localhost;user id=root;password=;database=atm"
        Try
            'MsgBox("Conectando ao MySQL...")
            conexao.Open()
            Return conexao
        Catch ex As Exception
            MsgBox(ex.ToString())
            Return Nothing
        End Try
    End Function
End Class
