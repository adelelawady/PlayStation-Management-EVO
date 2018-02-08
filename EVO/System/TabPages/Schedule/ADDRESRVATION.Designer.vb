<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ADDRESRVATION
    Inherits DevComponents.DotNetBar.Office2007Form

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
        Me.ComboBoxItem1 = New DevComponents.DotNetBar.ComboBoxItem()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboBoxEx1 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.IntegerInput1 = New DevComponents.Editors.IntegerInput()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxX2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.DoubleInput1 = New DevComponents.Editors.DoubleInput()
        Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        CType(Me.IntegerInput1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DoubleInput1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBoxItem1
        '
        Me.ComboBoxItem1.DropDownHeight = 106
        Me.ComboBoxItem1.ItemHeight = 17
        Me.ComboBoxItem1.Items.AddRange(New Object() {Me.ComboItem1})
        Me.ComboBoxItem1.Name = "ComboBoxItem1"
        Me.ComboBoxItem1.Text = "ComboBoxItem1"
        Me.ComboBoxItem1.WatermarkText = "all"
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "all"
        '
        'ComboBoxEx1
        '
        Me.ComboBoxEx1.DisplayMember = "Text"
        Me.ComboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx1.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxEx1.FormattingEnabled = True
        Me.ComboBoxEx1.ItemHeight = 23
        Me.ComboBoxEx1.Location = New System.Drawing.Point(39, 35)
        Me.ComboBoxEx1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Size = New System.Drawing.Size(258, 29)
        Me.ComboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx1.TabIndex = 0
        Me.ComboBoxEx1.WatermarkText = "Device"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(251, 336)
        Me.ButtonX1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(124, 32)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 3
        Me.ButtonX1.Text = "Submit"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Location = New System.Drawing.Point(13, 336)
        Me.ButtonX2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(104, 32)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 4
        Me.ButtonX2.Text = "Cancel"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(13, 74)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(177, 25)
        Me.LabelX1.TabIndex = 5
        Me.LabelX1.Text = "WarnBefore"
        '
        'IntegerInput1
        '
        '
        '
        '
        Me.IntegerInput1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInput1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.IntegerInput1.Location = New System.Drawing.Point(39, 100)
        Me.IntegerInput1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.IntegerInput1.Name = "IntegerInput1"
        Me.IntegerInput1.ShowUpDown = True
        Me.IntegerInput1.Size = New System.Drawing.Size(258, 29)
        Me.IntegerInput1.TabIndex = 6
        Me.IntegerInput1.Value = 60
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(302, 92)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(93, 37)
        Me.LabelX2.TabIndex = 7
        Me.LabelX2.Text = "Minutes"
        '
        'TextBoxX1
        '
        '
        '
        '
        Me.TextBoxX1.Border.Class = "TextBoxBorder"
        Me.TextBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxX1.Location = New System.Drawing.Point(39, 160)
        Me.TextBoxX1.Name = "TextBoxX1"
        Me.TextBoxX1.Size = New System.Drawing.Size(258, 29)
        Me.TextBoxX1.TabIndex = 8
        Me.TextBoxX1.WatermarkText = "Client"
        '
        'TextBoxX2
        '
        '
        '
        '
        Me.TextBoxX2.Border.Class = "TextBoxBorder"
        Me.TextBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxX2.Location = New System.Drawing.Point(39, 206)
        Me.TextBoxX2.Name = "TextBoxX2"
        Me.TextBoxX2.Size = New System.Drawing.Size(258, 29)
        Me.TextBoxX2.TabIndex = 9
        Me.TextBoxX2.WatermarkText = "Phone"
        '
        'DoubleInput1
        '
        '
        '
        '
        Me.DoubleInput1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DoubleInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DoubleInput1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.DoubleInput1.Increment = 1.0R
        Me.DoubleInput1.Location = New System.Drawing.Point(39, 259)
        Me.DoubleInput1.Name = "DoubleInput1"
        Me.DoubleInput1.ShowUpDown = True
        Me.DoubleInput1.Size = New System.Drawing.Size(258, 29)
        Me.DoubleInput1.TabIndex = 10
        Me.DoubleInput1.WatermarkText = "Paid"
        '
        'CircularProgress1
        '
        '
        '
        '
        Me.CircularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress1.Location = New System.Drawing.Point(306, 3)
        Me.CircularProgress1.Name = "CircularProgress1"
        Me.CircularProgress1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.CircularProgress1.ProgressColor = System.Drawing.SystemColors.ActiveCaption
        Me.CircularProgress1.Size = New System.Drawing.Size(75, 23)
        Me.CircularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress1.TabIndex = 11
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(25, 3)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(239, 28)
        Me.LabelX3.TabIndex = 12
        Me.LabelX3.Text = "Checking Schedule Avilablity"
        '
        'ADDRESRVATION
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 372)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.CircularProgress1)
        Me.Controls.Add(Me.DoubleInput1)
        Me.Controls.Add(Me.TextBoxX2)
        Me.Controls.Add(Me.TextBoxX1)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.IntegerInput1)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.ButtonX2)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.ComboBoxEx1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "ADDRESRVATION"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADDRESRVATION"
        Me.TopMost = True
        CType(Me.IntegerInput1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DoubleInput1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents ComboBoxItem1 As DevComponents.DotNetBar.ComboBoxItem
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboBoxEx1 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents IntegerInput1 As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TextBoxX2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents DoubleInput1 As DevComponents.Editors.DoubleInput
    Friend WithEvents CircularProgress1 As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
End Class
