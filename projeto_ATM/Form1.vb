
Imports MySql.Data.MySqlClient
Imports projeto_ATM.MóduloGeral
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ConexaoBanco = New ConexaoBanco()
        Dim Conn = ConexaoBanco.ConectarBanco()
        MsgBox("Conectado com Sucesso!")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox(Saldo(1))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

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
            MsgBox("Conectando ao MySQL...")
            conexao.Open()
            Return conexao
        Catch ex As Exception
            MsgBox(ex.ToString())
            Return Nothing
        End Try
    End Function
End Class
