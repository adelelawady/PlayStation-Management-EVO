<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpeciesControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.ColorWithAlpha3 = New EVO.ColorWithAlpha()
        Me.ColorWithAlpha4 = New EVO.ColorWithAlpha()
        Me.ColorWithAlpha5 = New EVO.ColorWithAlpha()
        Me.ColorWithAlpha6 = New EVO.ColorWithAlpha()
        Me.ColorWithAlpha1 = New EVO.ColorWithAlpha()
        Me.ColorWithAlpha2 = New EVO.ColorWithAlpha()
        Me.FlatLabel1 = New EVO.FlatLabel()
        Me.SuspendLayout()
        '
        'ColorWithAlpha3
        '
        Me.ColorWithAlpha3.Alpha = 255
        Me.ColorWithAlpha3.Color = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ColorWithAlpha3.Parent = Nothing
        '
        'ColorWithAlpha4
        '
        Me.ColorWithAlpha4.Alpha = 255
        Me.ColorWithAlpha4.Color = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(121, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ColorWithAlpha4.Parent = Nothing
        '
        'ColorWithAlpha5
        '
        Me.ColorWithAlpha5.Alpha = 255
        Me.ColorWithAlpha5.Color = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ColorWithAlpha5.Parent = Nothing
        '
        'ColorWithAlpha6
        '
        Me.ColorWithAlpha6.Alpha = 255
        Me.ColorWithAlpha6.Color = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ColorWithAlpha6.Parent = Nothing
        '
        'ColorWithAlpha1
        '
        Me.ColorWithAlpha1.Alpha = 255
        Me.ColorWithAlpha1.Color = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(121, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ColorWithAlpha1.Parent = Nothing
        '
        'ColorWithAlpha2
        '
        Me.ColorWithAlpha2.Alpha = 255
        Me.ColorWithAlpha2.Color = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ColorWithAlpha2.Parent = Nothing
        '
        'FlatLabel1
        '
        Me.FlatLabel1.AutoSize = True
        Me.FlatLabel1.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.FlatLabel1.ForeColor = System.Drawing.Color.Black
        Me.FlatLabel1.Location = New System.Drawing.Point(5, 3)
        Me.FlatLabel1.Name = "FlatLabel1"
        Me.FlatLabel1.Size = New System.Drawing.Size(81, 21)
        Me.FlatLabel1.TabIndex = 2
        Me.FlatLabel1.Text = "FlatLabel1"
        Me.FlatLabel1.Visible = False
        '
        'SpeciesControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Controls.Add(Me.FlatLabel1)
        Me.Name = "SpeciesControl"
        Me.Padding = New System.Windows.Forms.Padding(1)
        Me.Size = New System.Drawing.Size(433, 28)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ColorWithAlpha1 As EVO.ColorWithAlpha
    Friend WithEvents ColorWithAlpha2 As EVO.ColorWithAlpha
    Friend WithEvents ColorWithAlpha3 As EVO.ColorWithAlpha
    Friend WithEvents ColorWithAlpha4 As EVO.ColorWithAlpha
    Friend WithEvents ColorWithAlpha5 As EVO.ColorWithAlpha
    Friend WithEvents ColorWithAlpha6 As EVO.ColorWithAlpha
    Friend WithEvents FlatLabel1 As EVO.FlatLabel

End Class
