Imports Microsoft.Win32
Imports MySql.Data.MySqlClient
Public Class FormAdmin
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub FormAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Carrega as duas listas assim que a tela abre
        CarregarUsuarios()
        CarregarTransacoes()
    End Sub

    ' 1. FUNÇÃO PARA CARREGAR TODOS OS USUÁRIOS CADASTRADOS
    Private Sub CarregarUsuarios()
        Dim conexaoBanco As New ConexaoBanco()
        Dim conn As MySqlConnection = conexaoBanco.ConectarBanco()

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            ' Busca os dados principais da sua tabela 'contas'
            Dim sql As String = "SELECT `id_conta` As 'ID', `cpf` As 'CPF', `nome completo` As 'Nome', `cartao` As 'Cartão', `agencia` As 'Agência' FROM `contas`;"

            Dim dtUsuarios As New DataTable()
            Using da As New MySqlDataAdapter(sql, conn)
                da.Fill(dtUsuarios)
            End Using

            ' Joga os dados no DataGridView de usuários
            dgv_usuarios.DataSource = dtUsuarios
            dgv_usuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Catch ex As Exception
            MessageBox.Show("Erro ao carregar usuários: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub CarregarTransacoes()
        Dim conexaoBanco As New ConexaoBanco()
        Dim conn As MySqlConnection = conexaoBanco.ConectarBanco()

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            ' ATENÇÃO: Ajuste os nomes das colunas e da tabela ('transacoes') de acordo com o seu banco de dados
            Dim sql As String = "SELECT `id_registros` As 'ID', `data` As 'Data', `id_conta_to` As 'De', `id_conta_from` As 'para', `operacao` As 'Operacao' FROM `registros` ORDER BY `data` DESC;"

            Dim dtTransacoes As New DataTable()
            Using da As New MySqlDataAdapter(sql, conn)
                da.Fill(dtTransacoes)
            End Using

            ' Joga os dados no DataGridView de transações
            dgv_transacoes.DataSource = dtTransacoes
            dgv_transacoes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Catch ex As Exception
            ' Se a tabela de transações ainda não existir, o sistema avisará aqui sem travar o resto
            MessageBox.Show("Erro ao carregar transações (Verifique se a tabela existe): " & ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub btn_ir_registros_Click(sender As Object, e As EventArgs) Handles btn_ir_registros.Click
        ' Cria e mostra o formulário chamado registros
        ' (Certifique-se de já ter criado um formulário com o nome exatamente 'registros')
        Dim telaRegistros As New frm_registro()
        telaRegistros.Show()

        ' Opcional: se quiser fechar ou esconder o painel admin ao abrir os registros, use Me.Hide()
    End Sub

    Private Sub btn_atualizar_tabelas_Click(sender As Object, e As EventArgs) Handles btn_atualizar_tabelas.Click
        Try
            ' Altera o cursor do mouse para o modo de "Carregamento" (ampulheta/círculo)
            Cursor = Cursors.WaitCursor

            ' Chama as funções que buscam os dados atualizados no MySQL
            CarregarUsuarios()
            CarregarTransacoes()

            ' Restaura o cursor padrão do mouse
            Cursor = Cursors.Default

            ' Opcional: Um aviso discreto no canto da tela ou uma mensagem rápida
            MessageBox.Show("As tabelas de usuários e transações foram atualizadas com sucesso!", "Painel Atualizado", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            ' Garante que o mouse volte ao normal mesmo se der erro
            Cursor = Cursors.Default
            MessageBox.Show("Erro ao atualizar as listas: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgv_transacoes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_transacoes.CellContentClick

    End Sub
End Class