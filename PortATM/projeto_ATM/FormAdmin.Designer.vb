<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAdmin
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
        Me.dgv_usuarios = New System.Windows.Forms.DataGridView()
        Me.dgv_transacoes = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_ir_registros = New System.Windows.Forms.Button()
        Me.btn_atualizar_tabelas = New System.Windows.Forms.Button()
        CType(Me.dgv_usuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_transacoes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_usuarios
        '
        Me.dgv_usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_usuarios.Location = New System.Drawing.Point(30, 46)
        Me.dgv_usuarios.Name = "dgv_usuarios"
        Me.dgv_usuarios.Size = New System.Drawing.Size(343, 471)
        Me.dgv_usuarios.TabIndex = 0
        '
        'dgv_transacoes
        '
        Me.dgv_transacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_transacoes.Location = New System.Drawing.Point(428, 46)
        Me.dgv_transacoes.Name = "dgv_transacoes"
        Me.dgv_transacoes.Size = New System.Drawing.Size(343, 470)
        Me.dgv_transacoes.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(59, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(291, 31)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Usuarios Cadastrados "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(516, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(164, 31)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Transaçoes "
        '
        'btn_ir_registros
        '
        Me.btn_ir_registros.Location = New System.Drawing.Point(304, 546)
        Me.btn_ir_registros.Name = "btn_ir_registros"
        Me.btn_ir_registros.Size = New System.Drawing.Size(187, 55)
        Me.btn_ir_registros.TabIndex = 4
        Me.btn_ir_registros.Text = "REGISTROS"
        Me.btn_ir_registros.UseVisualStyleBackColor = True
        '
        'btn_atualizar_tabelas
        '
        Me.btn_atualizar_tabelas.Location = New System.Drawing.Point(65, 546)
        Me.btn_atualizar_tabelas.Name = "btn_atualizar_tabelas"
        Me.btn_atualizar_tabelas.Size = New System.Drawing.Size(187, 55)
        Me.btn_atualizar_tabelas.TabIndex = 5
        Me.btn_atualizar_tabelas.Text = "ATUALIZAR"
        Me.btn_atualizar_tabelas.UseVisualStyleBackColor = True
        '
        'FormAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 618)
        Me.Controls.Add(Me.btn_atualizar_tabelas)
        Me.Controls.Add(Me.btn_ir_registros)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgv_transacoes)
        Me.Controls.Add(Me.dgv_usuarios)
        Me.Name = "FormAdmin"
        Me.Text = "FormAdmin"
        CType(Me.dgv_usuarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_transacoes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgv_usuarios As DataGridView
    Friend WithEvents dgv_transacoes As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btn_ir_registros As Button
    Friend WithEvents btn_atualizar_tabelas As Button
End Class
