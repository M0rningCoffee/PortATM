Imports projeto_ATM.ConexaoBanco
Imports MySql.Data.MySqlClient
Module MóduloGeral

    Function Saldo(id)
        Dim Conexao As New ConexaoBanco()
        Dim conn = Conexao.ConectarBanco()
        Dim QuerySql = "select * from contas where id_conta = @id"

        Dim comando = New MySqlCommand(QuerySql, conn)
        comando.Parameters.AddWithValue("@id", id)
        Dim leitor = comando.ExecuteReader()
        Do While leitor.Read
            Return leitor("saldo").ToString()
        Loop
    End Function

    Function Sacar(id, valor)
        Dim Conexao As New ConexaoBanco()
        Dim conn = Conexao.ConectarBanco()
        Dim QuerySql = "update contas set saldo = saldo - @valor where id_conta = @id"
        Dim comando = New MySqlCommand(QuerySql, conn)
        comando.Parameters.AddWithValue("@id", id)
        comando.Parameters.AddWithValue("@valor", valor)
        comando.ExecuteNonQuery()
    End Function

    Function Depositar(id, valor)
        Dim Conexao As New ConexaoBanco()
        Dim conn = Conexao.ConectarBanco()
        Dim QuerySql = "update contas set saldo = saldo + @valor where id_conta = @id"
        Dim comando = New MySqlCommand(QuerySql, conn)
        comando.Parameters.AddWithValue("@id", id)
        comando.Parameters.AddWithValue("@valor", valor)
        comando.ExecuteNonQuery()
    End Function

    Function Transferir(id_origem, id_destino, valor)
        Sacar(id_origem, valor)
        Depositar(id_destino, valor)
    End Function

    Function VerificarSenha(cartao, pin)
        Dim Conexao As New ConexaoBanco()
        Dim conn = Conexao.ConectarBanco()
        Dim QuerySql = "select * from contas where cartao = @cartao and pin = @pin"
        Dim comando = New MySqlCommand(QuerySql, conn)
        comando.Parameters.AddWithValue("@cartao", cartao)
        comando.Parameters.AddWithValue("@pin", pin)
        Dim leitor = comando.ExecuteReader()
        If leitor.Read Then
            Return True
        Else
            Return False
        End If
    End Function

    Function VerificarCartao(cartao)
        Dim Conexao As New ConexaoBanco()
        Dim conn = Conexao.ConectarBanco()
        Dim QuerySql = "select * from contas where cartao = @cartao"
        Dim comando = New MySqlCommand(QuerySql, conn)
        comando.Parameters.AddWithValue("@cartao", cartao)
        Dim leitor = comando.ExecuteReader()
        If leitor.Read Then
            Return True
        Else
            Return False
        End If
    End Function

    Function Conta(cartao)
        Dim Conexao As New ConexaoBanco()
        Dim conn = Conexao.ConectarBanco()
        Dim QuerySql = "select * from contas where cartao = @cartao"
        Dim comando = New MySqlCommand(QuerySql, conn)
        comando.Parameters.AddWithValue("@cartao", cartao)
        Dim leitor = comando.ExecuteReader()
        Do While leitor.Read
            Return leitor("id_conta").ToString()
        Loop
    End Function

    Function IdentificarContaTransferencia(agencia, cc)
        Dim Conexao As New ConexaoBanco()
        Dim conn = Conexao.ConectarBanco()
        Dim QuerySql = "select * from contas where agencia = @agencia and cc = @cc"
        Dim comando = New MySqlCommand(QuerySql, conn)
        comando.Parameters.AddWithValue("@agencia", agencia)
        comando.Parameters.AddWithValue("@cc", cc)
        Dim leitor = comando.ExecuteReader()
        If leitor.Read Then
            Return leitor("id_conta").ToString()
        Else
            Return False
        End If

    End Function

    Function IdentificarContaPix(cpf)
        Dim Conexao As New ConexaoBanco()
        Dim conn = Conexao.ConectarBanco()
        Dim QuerySql = "select * from contas where cpf = @cpf"
        Dim comando = New MySqlCommand(QuerySql, conn)
        comando.Parameters.AddWithValue("@cpf", cpf)
        Dim leitor = comando.ExecuteReader()
        If leitor.Read Then
            Return leitor("id_conta").ToString()
        Else
            Return False
        End If

    End Function


End Module
