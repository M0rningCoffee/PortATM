<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLoginAdmin
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_usuario_admin = New System.Windows.Forms.TextBox()
        Me.txt_senha_admin = New System.Windows.Forms.TextBox()
        Me.btn_confirmar_login = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(309, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "USUARIO"
        Me.Label1.UseMnemonic = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(322, 205)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 31)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SENHA"
        Me.Label2.UseMnemonic = False
        '
        'txt_usuario_admin
        '
        Me.txt_usuario_admin.Location = New System.Drawing.Point(222, 118)
        Me.txt_usuario_admin.Name = "txt_usuario_admin"
        Me.txt_usuario_admin.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_usuario_admin.Size = New System.Drawing.Size(317, 20)
        Me.txt_usuario_admin.TabIndex = 2
        '
        'txt_senha_admin
        '
        Me.txt_senha_admin.Location = New System.Drawing.Point(222, 276)
        Me.txt_senha_admin.Name = "txt_senha_admin"
        Me.txt_senha_admin.Size = New System.Drawing.Size(317, 20)
        Me.txt_senha_admin.TabIndex = 3
        '
        'btn_confirmar_login
        '
        Me.btn_confirmar_login.Location = New System.Drawing.Point(275, 347)
        Me.btn_confirmar_login.Name = "btn_confirmar_login"
        Me.btn_confirmar_login.Size = New System.Drawing.Size(201, 57)
        Me.btn_confirmar_login.TabIndex = 4
        Me.btn_confirmar_login.Text = "ENTRAR"
        Me.btn_confirmar_login.UseVisualStyleBackColor = True
        Me.btn_confirmar_login.UseWaitCursor = True
        '
        'FormLoginAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btn_confirmar_login)
        Me.Controls.Add(Me.txt_senha_admin)
        Me.Controls.Add(Me.txt_usuario_admin)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormLoginAdmin"
        Me.Text = "FormLoginAdmin"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_usuario_admin As TextBox
    Friend WithEvents txt_senha_admin As TextBox
    Friend WithEvents btn_confirmar_login As Button
End Class
