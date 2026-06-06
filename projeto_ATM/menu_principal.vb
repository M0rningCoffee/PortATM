
Public Class menu_principal
    Private Sub btn_extrato_Click(sender As Object, e As EventArgs) Handles btn_extrato.Click
        ' Cria e abre a tela de Extrato
        Dim telaExtrato As New FormExtrato()
        telaExtrato.Show()

        ' Oculta o menu principal
        Me.Hide()
    End Sub

    Private Sub menu_principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Verifica se existe um nome salvo na variável compartilhada
        If Not String.IsNullOrWhiteSpace(Cartao_acesso.NomeUsuarioLogado) Then

            ' Pega o nome completo que veio do banco
            Dim nomeCompleto As String = Cartao_acesso.NomeUsuarioLogado

            ' Corta o texto nos espaços e pega apenas a primeira parte (o primeiro nome)
            Dim partesDoNome As String() = nomeCompleto.Trim().Split(" "c)
            Dim primeiroNome As String = partesDoNome(0)

            ' Mostra o primeiro nome na Label
            lbl_usuario_logado.Text = "Usuário Logado: " & primeiroNome
        Else
            ' Caso dê algum erro e o nome venha vazio, mostra um texto padrão
            lbl_usuario_logado.Text = "Usuário Logado: Cliente"
        End If
    End Sub

    Private Sub btn_deposito_Click(sender As Object, e As EventArgs) Handles btn_deposito.Click
        ' Cria e abre a tela de Depósito
        Dim telaDeposito As New FormDeposito()
        telaDeposito.Show()

        ' Oculta o menu principal
        Me.Hide()
    End Sub

    Private Sub btn_saque_Click(sender As Object, e As EventArgs) Handles btn_saque.Click
        ' Cria e abre a tela de Extrato
        Dim telasaque As New FormSaque()
        telasaque.Show()

        ' Oculta o menu principal
        Me.Hide()
    End Sub
End Class