<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormExtrato
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
        Me.lbl_saldo_atual = New System.Windows.Forms.Label()
        Me.dgv_extrato = New System.Windows.Forms.DataGridView()
        Me.btn_voltar = New System.Windows.Forms.Button()
        CType(Me.dgv_extrato, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(51, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(0, 46)
        Me.Label1.TabIndex = 0
        '
        'lbl_saldo_atual
        '
        Me.lbl_saldo_atual.AutoSize = True
        Me.lbl_saldo_atual.Font = New System.Drawing.Font("Microsoft Sans Serif", 50.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_saldo_atual.Location = New System.Drawing.Point(95, 40)
        Me.lbl_saldo_atual.Name = "lbl_saldo_atual"
        Me.lbl_saldo_atual.Size = New System.Drawing.Size(259, 76)
        Me.lbl_saldo_atual.TabIndex = 1
        Me.lbl_saldo_atual.Text = "SALDO"
        '
        'dgv_extrato
        '
        Me.dgv_extrato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_extrato.Location = New System.Drawing.Point(424, 131)
        Me.dgv_extrato.Name = "dgv_extrato"
        Me.dgv_extrato.Size = New System.Drawing.Size(364, 335)
        Me.dgv_extrato.TabIndex = 2
        '
        'btn_voltar
        '
        Me.btn_voltar.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_voltar.Location = New System.Drawing.Point(89, 247)
        Me.btn_voltar.Name = "btn_voltar"
        Me.btn_voltar.Size = New System.Drawing.Size(265, 113)
        Me.btn_voltar.TabIndex = 3
        Me.btn_voltar.Text = "Voltar"
        Me.btn_voltar.UseVisualStyleBackColor = True
        '
        'FormExtrato
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 487)
        Me.Controls.Add(Me.btn_voltar)
        Me.Controls.Add(Me.dgv_extrato)
        Me.Controls.Add(Me.lbl_saldo_atual)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormExtrato"
        Me.Text = "FormExtrato"
        CType(Me.dgv_extrato, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lbl_saldo_atual As Label
    Friend WithEvents dgv_extrato As DataGridView
    Friend WithEvents btn_voltar As Button
End Class
