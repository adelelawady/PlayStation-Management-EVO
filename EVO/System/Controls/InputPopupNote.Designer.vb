<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InputPopupNote
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
        Me.LoyalTheme1 = New EVO.LoyalTheme()
        Me.TextBoxX2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.TextBoxX1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.LoyalTheme1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LoyalTheme1
        '
        Me.LoyalTheme1.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.LoyalTheme1.Controls.Add(Me.TextBoxX2)
        Me.LoyalTheme1.Controls.Add(Me.Label1)
        Me.LoyalTheme1.Controls.Add(Me.ButtonX2)
        Me.LoyalTheme1.Controls.Add(Me.TextBoxX1)
        Me.LoyalTheme1.Controls.Add(Me.ButtonX1)
        Me.LoyalTheme1.ControlsAlignment = EVO.LoyalTheme.ControlsAlign.Right
        Me.LoyalTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LoyalTheme1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.LoyalTheme1.HeaderColor = System.Drawing.Color.Teal
        Me.LoyalTheme1.HeaderSize = 30
        Me.LoyalTheme1.Location = New System.Drawing.Point(0, 0)
        Me.LoyalTheme1.Name = "LoyalTheme1"
        Me.LoyalTheme1.ShowClose = False
        Me.LoyalTheme1.ShowMaximize = False
        Me.LoyalTheme1.ShowMinimize = False
        Me.LoyalTheme1.Size = New System.Drawing.Size(249, 182)
        Me.LoyalTheme1.TabIndex = 5
        Me.LoyalTheme1.Text = "LoyalTheme1"
        Me.LoyalTheme1.TextAlignment = EVO.LoyalTheme.TextAlign.Center
        '
        'TextBoxX2
        '
        Me.TextBoxX2.BackColor = System.Drawing.Color.Teal
        '
        '
        '
        Me.TextBoxX2.Border.BackColor = System.Drawing.Color.Teal
        Me.TextBoxX2.Border.BackColor2 = System.Drawing.Color.Teal
        Me.TextBoxX2.Border.Class = "TextBoxBorder"
        Me.TextBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.TextBoxX2.Border.TextColor = System.Drawing.Color.White
        Me.TextBoxX2.Font = New System.Drawing.Font("justagain DIN", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxX2.ForeColor = System.Drawing.Color.White
        Me.TextBoxX2.Location = New System.Drawing.Point(12, 53)
        Me.TextBoxX2.Multiline = True
        Me.TextBoxX2.Name = "TextBoxX2"
        Me.TextBoxX2.Size = New System.Drawing.Size(210, 88)
        Me.TextBoxX2.TabIndex = 7
        Me.TextBoxX2.WatermarkColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxX2.WatermarkText = "ملحوظات "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("justagain DIN", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.Location = New System.Drawing.Point(190, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 24)
        Me.Label1.TabIndex = 5
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Font = New System.Drawing.Font("justagain DIN", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX2.Location = New System.Drawing.Point(7, 156)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(102, 23)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 4
        Me.ButtonX2.Text = "الغاء"
        '
        'TextBoxX1
        '
        Me.TextBoxX1.BackColor = System.Drawing.Color.Teal
        '
        '
        '
        Me.TextBoxX1.Border.BackColor = System.Drawing.Color.Teal
        Me.TextBoxX1.Border.BackColor2 = System.Drawing.Color.Teal
        Me.TextBoxX1.Border.Class = "TextBoxBorder"
        Me.TextBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.TextBoxX1.Border.TextColor = System.Drawing.Color.White
        Me.TextBoxX1.Font = New System.Drawing.Font("justagain DIN", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxX1.ForeColor = System.Drawing.Color.White
        Me.TextBoxX1.Location = New System.Drawing.Point(12, 12)
        Me.TextBoxX1.Name = "TextBoxX1"
        Me.TextBoxX1.Size = New System.Drawing.Size(175, 39)
        Me.TextBoxX1.TabIndex = 2
        Me.TextBoxX1.WatermarkColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxX1.WatermarkText = "القيمه"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Font = New System.Drawing.Font("justagain DIN", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX1.Location = New System.Drawing.Point(139, 156)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(102, 23)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 3
        Me.ButtonX1.Text = "تاكيد"
        '
        'InputPopupNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.ClientSize = New System.Drawing.Size(249, 182)
        Me.Controls.Add(Me.LoyalTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "InputPopupNote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "InputPopup"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.LoyalTheme1.ResumeLayout(False)
        Me.LoyalTheme1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TextBoxX1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LoyalTheme1 As EVO.LoyalTheme
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxX2 As DevComponents.DotNetBar.Controls.TextBoxX
End Class
