Imports MySql.Data.MySqlClient
Public Class FormExtrato
    Private Sub FormExtrato_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Carrega o saldo e a lista de transações assim que a tela abre
        CarregarSaldo()
        CarregarExtrato()
    End Sub

    ' 1. FUNÇÃO PARA BUSCAR E MOSTRAR O SALDO
    Private Sub CarregarSaldo()
        Dim conexaoBanco As New ConexaoBanco()
        Dim conn As MySqlConnection = conexaoBanco.ConectarBanco()

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim sql As String = "SELECT `saldo` FROM `contas` WHERE `id_conta` = @id;"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@id", Cartao_acesso.IDContaLogada)

                Dim resultado As Object = cmd.ExecuteScalar()

                If resultado IsNot Nothing AndAlso Not IsDBNull(resultado) Then
                    Dim saldoAtual As Decimal = Convert.ToDecimal(resultado)
                    lbl_saldo_atual.Text = "Saldo Disponível: " & saldoAtual.ToString("C")
                Else
                    lbl_saldo_atual.Text = "Saldo Disponível: R$ 0,00"
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Erro ao carregar o saldo: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' 2. FUNÇÃO PARA BUSCAR AS TRANSAÇÕES DO USUÁRIO E MONTAR O EXTRATO
    Private Sub CarregarExtrato()
        Dim conexaoBanco As New ConexaoBanco()
        Dim conn As MySqlConnection = conexaoBanco.ConectarBanco()

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            ' Busca apenas as transações deste usuário específico, da mais recente para a mais antiga
            Dim sql As String = "SELECT `id_registros` As 'ID', `data` As 'Data', `id_conta_to` As 'De', `id_conta_from` As 'para', `operacao` As 'Operacao'" &
                                "FROM `registros` " &
                                "WHERE `id_conta_to` = @id OR `id_conta_from` = @id " &
                                "ORDER BY `data` DESC;"

            Dim dtExtrato As New DataTable()
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@id", Cartao_acesso.IDContaLogada)

                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dtExtrato)
                End Using
            End Using

            ' Joga os dados no DataGridView
            dgv_extrato.DataSource = dtExtrato

            ' ESCONDE A COLUNA DO ID VISUALMENTE
            ' (Troque "ID" pelo nome exato que você deu para a coluna no seu SELECT)
            If dgv_extrato.Columns.Contains("ID") Then
                dgv_extrato.Columns("ID").Visible = False
            End If

            ' Formata visualmente as colunas
            dgv_extrato.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Formata a coluna "Valor" para aparecer como moeda (R$) no DataGridView
            If dgv_extrato.Columns.Contains("Valor") Then
                dgv_extrato.Columns("Valor").DefaultCellStyle.Format = "c"
            End If

        Catch ex As Exception
            MessageBox.Show("Erro ao carregar o extrato: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' 3. BOTÃO DE VOLTAR AO MENU
    Private Sub btn_voltar_Click(sender As Object, e As EventArgs) Handles btn_voltar.Click
        For Each f As Form In Application.OpenForms
            If TypeOf f Is menu_principal Then
                f.Show()
                Exit For
            End If
        Next
        Me.Close()
    End Sub

    ' Se fechar no "X", também volta ao menu
    Private Sub FormExtrato_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        For Each f As Form In Application.OpenForms
            If TypeOf f Is menu_principal Then
                f.Show()
                Exit For
            End If
        Next
    End Sub

    Private Sub dgv_extrato_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_extrato.CellContentClick

    End Sub

End Class