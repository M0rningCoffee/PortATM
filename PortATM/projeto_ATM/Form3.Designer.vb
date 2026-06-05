<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_registro
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.txt_nome = New System.Windows.Forms.TextBox()
        Me.txt_senha = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_salvar = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txt_cpf = New System.Windows.Forms.TextBox()
        Me.label = New System.Windows.Forms.Label()
        Me.txt_cartao = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_usuario = New System.Windows.Forms.TextBox()
        Me.txt_agencia = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btn_excluir = New System.Windows.Forms.Button()
        Me.btn_update = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(203, 340)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(132, 20)
        Me.DateTimePicker1.TabIndex = 29
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(240, 307)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(67, 17)
        Me.RadioButton2.TabIndex = 28
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Feminino"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(145, 307)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(73, 17)
        Me.RadioButton1.TabIndex = 27
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Masculino"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'txt_nome
        '
        Me.txt_nome.Location = New System.Drawing.Point(171, 237)
        Me.txt_nome.Name = "txt_nome"
        Me.txt_nome.Size = New System.Drawing.Size(236, 20)
        Me.txt_nome.TabIndex = 26
        '
        'txt_senha
        '
        Me.txt_senha.Location = New System.Drawing.Point(145, 195)
        Me.txt_senha.Name = "txt_senha"
        Me.txt_senha.Size = New System.Drawing.Size(262, 20)
        Me.txt_senha.TabIndex = 24
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(82, 340)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 13)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Data de nascimento"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(82, 307)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Genero"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(83, 237)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Nome Completo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(83, 195)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Senha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(82, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Usuario "
        '
        'btn_salvar
        '
        Me.btn_salvar.Location = New System.Drawing.Point(62, 415)
        Me.btn_salvar.Name = "btn_salvar"
        Me.btn_salvar.Size = New System.Drawing.Size(146, 68)
        Me.btn_salvar.TabIndex = 30
        Me.btn_salvar.Text = "SALVAR"
        Me.btn_salvar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(375, 415)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(146, 67)
        Me.Button2.TabIndex = 31
        Me.Button2.Text = "SAIR"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txt_cpf
        '
        Me.txt_cpf.Location = New System.Drawing.Point(145, 153)
        Me.txt_cpf.Name = "txt_cpf"
        Me.txt_cpf.Size = New System.Drawing.Size(262, 20)
        Me.txt_cpf.TabIndex = 34
        '
        'label
        '
        Me.label.AutoSize = True
        Me.label.Location = New System.Drawing.Point(83, 153)
        Me.label.Name = "label"
        Me.label.Size = New System.Drawing.Size(27, 13)
        Me.label.TabIndex = 33
        Me.label.Text = "CPF"
        '
        'txt_cartao
        '
        Me.txt_cartao.Location = New System.Drawing.Point(145, 117)
        Me.txt_cartao.Name = "txt_cartao"
        Me.txt_cartao.Size = New System.Drawing.Size(262, 20)
        Me.txt_cartao.TabIndex = 36
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(83, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Cartâo"
        '
        'txt_usuario
        '
        Me.txt_usuario.Location = New System.Drawing.Point(145, 80)
        Me.txt_usuario.Name = "txt_usuario"
        Me.txt_usuario.Size = New System.Drawing.Size(262, 20)
        Me.txt_usuario.TabIndex = 37
        '
        'txt_agencia
        '
        Me.txt_agencia.Location = New System.Drawing.Point(171, 281)
        Me.txt_agencia.Name = "txt_agencia"
        Me.txt_agencia.Size = New System.Drawing.Size(236, 20)
        Me.txt_agencia.TabIndex = 39
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(84, 282)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 13)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "agencia "
        '
        'btn_excluir
        '
        Me.btn_excluir.Location = New System.Drawing.Point(223, 415)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(146, 67)
        Me.btn_excluir.TabIndex = 40
        Me.btn_excluir.Text = "excluir"
        Me.btn_excluir.UseVisualStyleBackColor = True
        '
        'btn_update
        '
        Me.btn_update.Location = New System.Drawing.Point(375, 340)
        Me.btn_update.Name = "btn_update"
        Me.btn_update.Size = New System.Drawing.Size(146, 67)
        Me.btn_update.TabIndex = 41
        Me.btn_update.Text = "UPDATE"
        Me.btn_update.UseVisualStyleBackColor = True
        '
        'frm_registro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 631)
        Me.Controls.Add(Me.btn_update)
        Me.Controls.Add(Me.btn_excluir)
        Me.Controls.Add(Me.txt_agencia)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_usuario)
        Me.Controls.Add(Me.txt_cartao)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_cpf)
        Me.Controls.Add(Me.label)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btn_salvar)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.txt_nome)
        Me.Controls.Add(Me.txt_senha)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frm_registro"
        Me.Text = "Registro"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents txt_nome As TextBox
    Friend WithEvents txt_senha As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_salvar As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents txt_cpf As TextBox
    Friend WithEvents label As Label
    Friend WithEvents txt_cartao As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_usuario As TextBox
    Friend WithEvents txt_agencia As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btn_excluir As Button
    Friend WithEvents btn_update As Button
End Class
