Imports MySql.Data.MySqlClient
Imports projeto_ATM.MóduloGeral
Public Class Cartao_acesso

    ' DECLARE A CONEXÃO AQUI NO TOPO PARA TODOS OS BOTÕES PODEREM USAR
    Dim ConexaoBanco As New ConexaoBanco()
    Dim Conn As MySqlConnection

    ' Crie variáveis públicas para o outro formulário conseguir ler depois
    Public Shared IDContaLogada As String = ""
    Public Shared SenhaCorreta As String = ""
    Public Shared NumeroCartaoLogado As String = ""
    Public Shared NomeUsuarioLogado As String = ""
    Public Shared HorarioDesbloqueio As DateTime = DateTime.MinValue
    Public Shared QuantidadeDeBloqueios As Integer = 0
    Public Shared EstaBloqueioAtivo As Boolean = False

    Private Sub Cartaoacesso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Inicializa a conexão que declaramos lá em cima
        Conn = ConexaoBanco.ConectarBanco()
    End Sub

    ' ... Seus botões de 0 a 9, Cancel e Clear continuam exatamente iguais aqui ...

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
        If String.IsNullOrWhiteSpace(txt_display.Text) Then
            MessageBox.Show("Por favor, digite o número do seu cartão.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If EstaBloqueioAtivo Then
            ' Se o horário atual for menor que o horário permitido para desbloquear...
            If DateTime.Now < HorarioDesbloqueio Then
                Dim tempoRestante As TimeSpan = HorarioDesbloqueio - DateTime.Now

                ' Mostra os minutos e segundos restantes de forma amigável
                Dim tempoFormatado As String = String.Format("{0:D2}:{1:D2}", tempoRestante.Minutes, tempoRestante.Seconds)
                MessageBox.Show($"O sistema está temporariamente bloqueado. Aguarde {tempoFormatado} para tentar novamente.",
                            "Acesso Suspenso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else
                ' Se o tempo já passou, libera o sistema
                EstaBloqueioAtivo = False
            End If
        End If

        ' 2. Validação básica: verifica se o visor está vazio
        If String.IsNullOrWhiteSpace(txt_display.Text) Then
            MessageBox.Show("Por favor, digite o número do seu cartão.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' =========================================================================
        ' ACESSO ADMINISTRADOR: Se digitar o cartão mestre 111111
        ' =========================================================================
        If txt_display.Text = "111111" Then
            MessageBox.Show("Identificado Cartão Administrativo. Insira as credenciais.", "Modo Técnico", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txt_display.Clear()

            ' ALTERADO: Agora abre a tela de login intermediária
            Dim telaLoginAdmin As New FormLoginAdmin()
            telaLoginAdmin.Show()

            Me.Hide()
            Exit Sub
        End If
        ' =========================================================================

        ' 2. Validação básica do display
        If String.IsNullOrWhiteSpace(txt_display.Text) Then
            MessageBox.Show("Por favor, digite o número do seu cartão.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Conn.State = ConnectionState.Closed Then Conn.Open()

        Try
            ' IMPORTANTE: Verifique se `nome completo` é exatamente o nome da coluna no seu banco
            Dim sql As String = "SELECT `id_conta`, `pin`, `cartao`, `nome completo` FROM `contas` WHERE `cartao` = @cartao LIMIT 1;"

            Using cmd As New MySqlCommand(sql, Conn)
                cmd.Parameters.AddWithValue("@cartao", txt_display.Text)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        IDContaLogada = reader("id_conta").ToString()
                        SenhaCorreta = reader("pin").ToString()
                        NumeroCartaoLogado = reader("cartao").ToString()

                        ' Captura o nome completo
                        NomeUsuarioLogado = reader("nome completo").ToString()

                        ' --- TESTE TEMPORÁRIO: REMOVA DEPOIS QUE FUNCIONAR ---
                        ' Isso vai te mostrar o que o banco guardou antes de mudar de tela
                        MsgBox("ID encontrado: " & IDContaLogada & vbCrLf & "Nome encontrado: " & NomeUsuarioLogado)
                        ' -----------------------------------------------------

                        reader.Close()
                        If Conn.State = ConnectionState.Open Then Conn.Close()

                        ' Abre o formulário da Senha
                        Dim telaSenha As New menu_senha()
                        telaSenha.Show()
                        Me.Hide()
                    Else
                        MessageBox.Show("Cartão não encontrado ou inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txt_display.Clear()
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Erro ao validar cartão: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub
End Class