Imports System.IO
Imports MySql.Data.MySqlClient
Imports projeto_ATM.ConexaoBanco

Module MóduloGeral
    Public tentativas As Integer = 0

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
        conn.Close()
    End Function

    Function Sacar(id, valor)
        Dim Conexao As New ConexaoBanco()
        Dim conn = Conexao.ConectarBanco()
        Dim QuerySql = "update contas set saldo = saldo - @valor where id_conta = @id"
        Dim comando = New MySqlCommand(QuerySql, conn)
        comando.Parameters.AddWithValue("@id", id)
        comando.Parameters.AddWithValue("@valor", valor)
        Try
            comando.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Registro(id, id, valor, "Saque")
        conn.Close()
    End Function

    Function Depositar(id, valor)
        Dim Conexao As New ConexaoBanco()
        Dim conn = Conexao.ConectarBanco()
        Dim QuerySql = "update contas set saldo = saldo + @valor where id_conta = @id"
        Dim comando = New MySqlCommand(QuerySql, conn)
        comando.Parameters.AddWithValue("@id", id)
        comando.Parameters.AddWithValue("@valor", valor)
        comando.ExecuteNonQuery()
        Registro(id, id, valor, "depósito")
        conn.Close()
    End Function

    Function Transferir(id_origem, id_destino, valor, pix)
        Sacar(id_origem, valor)
        Depositar(id_destino, valor)
        If pix = False Then
            Registro(id_destino, id_origem, valor, "transferência")
        Else
            Registro(id_destino, id_origem, valor, "pix")
        End If
    End Function

    Function VerificarSenha(cartao, pin)
        If tentativas >= 3 Then
            MsgBox("Cartão bloqueado por excesso de tentativas!")
            Return "bloqueado"
        End If
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
            tentativas += 1
            Return False
        End If
        conn.Close()
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
        conn.Close()
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
        conn.Close()
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
        conn.Close()
    End Function

    Function IdentificarContaPix(cpf)
        Dim Conexao As New ConexaoBanco()
        Dim conn = Conexao.ConectarBanco()
        Dim QuerySql = "select * from contas where cpf = @cpf and pix = True"
        Dim comando = New MySqlCommand(QuerySql, conn)
        comando.Parameters.AddWithValue("@cpf", cpf)
        Dim leitor = comando.ExecuteReader()
        If leitor.Read Then
            Return leitor("id_conta").ToString()
        Else
            Return False
        End If
        conn.Close()
    End Function

    Function Registro(id_conta_to, id_conta_from, valor, operacao)
        Dim Conexao As New ConexaoBanco()
        Dim conn = Conexao.ConectarBanco()
        Dim QuerySql = "insert into registros(id_conta_to, id_conta_from, operacao, valor) values(@id_conta_to, @id_conta_from, @operacao, @valor)"
        Dim comando = New MySqlCommand(QuerySql, conn)
        comando.Parameters.AddWithValue("@id_conta_to", id_conta_to)
        comando.Parameters.AddWithValue("@valor", valor)
        comando.Parameters.AddWithValue("@id_conta_from", id_conta_from)
        comando.Parameters.AddWithValue("@operacao", operacao)
        comando.ExecuteNonQuery()
        Historico(id_conta_from, id_conta_to, valor, operacao)
        conn.Close()
    End Function

    Function Historico(id_conta_from, id_conta_to, valor, operacao)
        Dim applicationPath = Path.GetDirectoryName(Application.ExecutablePath)
        applicationPath = applicationPath + "\transacoes.txt"
        Dim info = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "|Conta Origem:" + id_conta_from.ToString() + "|Valor R$" + valor.ToString() + "|Operação:" + operacao + "|Conta Destino:" + id_conta_from.ToString() + Environment.NewLine
        My.Computer.FileSystem.WriteAllText(applicationPath, info, True)
    End Function

End Module
