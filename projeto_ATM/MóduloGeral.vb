Imports projeto_ATM.ConexaoBanco
Imports MySql.Data.MySqlClient
Module MóduloGeral


    Public Sub Main()
        Dim Conexao As New ConexaoBanco()
        Dim conn = Conexao.ConectarBanco()
        Dim QuerySql = "select cartao from contas where id_conta = 1"

        Dim comando = New MySqlCommand(QuerySql, conn)
        Dim contas As String = comando.ExecuteNonQuery()
        MsgBox(contas)
    End Sub


End Module
