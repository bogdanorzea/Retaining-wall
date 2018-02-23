<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label_Grupa = New System.Windows.Forms.Label()
        Me.Label_Ordine = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Numeric_ordine = New System.Windows.Forms.NumericUpDown()
        Me.Numeric_grupa = New System.Windows.Forms.NumericUpDown()
        CType(Me.Numeric_ordine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Numeric_grupa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label_Grupa
        '
        Me.Label_Grupa.AutoSize = True
        Me.Label_Grupa.Location = New System.Drawing.Point(22, 51)
        Me.Label_Grupa.Name = "Label_Grupa"
        Me.Label_Grupa.Size = New System.Drawing.Size(70, 13)
        Me.Label_Grupa.TabIndex = 7
        Me.Label_Grupa.Text = "Număr Grupă"
        '
        'Label_Ordine
        '
        Me.Label_Ordine.AutoSize = True
        Me.Label_Ordine.Location = New System.Drawing.Point(22, 26)
        Me.Label_Ordine.Name = "Label_Ordine"
        Me.Label_Ordine.Size = New System.Drawing.Size(72, 13)
        Me.Label_Ordine.TabIndex = 6
        Me.Label_Ordine.Text = "Număr Ordine"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(61, 79)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Calculează"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Numeric_ordine
        '
        Me.Numeric_ordine.Location = New System.Drawing.Point(115, 23)
        Me.Numeric_ordine.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Numeric_ordine.Name = "Numeric_ordine"
        Me.Numeric_ordine.Size = New System.Drawing.Size(52, 20)
        Me.Numeric_ordine.TabIndex = 11
        Me.Numeric_ordine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Numeric_ordine.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Numeric_grupa
        '
        Me.Numeric_grupa.Location = New System.Drawing.Point(115, 47)
        Me.Numeric_grupa.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Numeric_grupa.Name = "Numeric_grupa"
        Me.Numeric_grupa.Size = New System.Drawing.Size(52, 20)
        Me.Numeric_grupa.TabIndex = 12
        Me.Numeric_grupa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Numeric_grupa.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Form1
        '
        Me.AcceptButton = Me.Button2
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(189, 118)
        Me.Controls.Add(Me.Numeric_grupa)
        Me.Controls.Add(Me.Numeric_ordine)
        Me.Controls.Add(Me.Label_Grupa)
        Me.Controls.Add(Me.Label_Ordine)
        Me.Controls.Add(Me.Button2)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Date de ordine"
        CType(Me.Numeric_ordine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Numeric_grupa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label_Grupa As System.Windows.Forms.Label
    Friend WithEvents Label_Ordine As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Numeric_ordine As System.Windows.Forms.NumericUpDown
    Friend WithEvents Numeric_grupa As System.Windows.Forms.NumericUpDown
End Class
