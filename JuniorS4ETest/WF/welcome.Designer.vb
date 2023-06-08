<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class welcome
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(182, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(242, 142)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bem-vindo!"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(256, 235)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(97, 34)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Proximo"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'welcome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ClientSize = New System.Drawing.Size(618, 375)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "welcome"
        Me.Text = "welcome"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Button1 As Windows.Forms.Button
End Class
