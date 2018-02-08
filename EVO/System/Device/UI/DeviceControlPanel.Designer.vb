<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeviceControlPanel
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
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.MainControlTable1 = New EVO.DevicesTableLayout()
        Me.FlatStatusBar1 = New EVO.FlatStatusBar()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.CircularProgress1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(895, 308)
        Me.Panel1.TabIndex = 5
        '
        'CircularProgress1
        '
        Me.CircularProgress1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CircularProgress1.AnimationSpeed = 200
        Me.CircularProgress1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.CircularProgress1.BackgroundStyle.BackgroundImage = Global.EVO.My.Resources.Resources.mdiClient1_BackgroundImage
        Me.CircularProgress1.BackgroundStyle.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Tile
        Me.CircularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress1.Location = New System.Drawing.Point(408, 133)
        Me.CircularProgress1.Name = "CircularProgress1"
        Me.CircularProgress1.PieBorderDark = System.Drawing.Color.Transparent
        Me.CircularProgress1.PieBorderLight = System.Drawing.Color.Transparent
        Me.CircularProgress1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.CircularProgress1.ProgressColor = System.Drawing.Color.White
        Me.CircularProgress1.Size = New System.Drawing.Size(75, 44)
        Me.CircularProgress1.SpokeBorderDark = System.Drawing.Color.Transparent
        Me.CircularProgress1.SpokeBorderLight = System.Drawing.Color.Transparent
        Me.CircularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress1.TabIndex = 0
        '
        'MainControlTable1
        '
        Me.MainControlTable1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MainControlTable1.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.MainControlTable1.Location = New System.Drawing.Point(3, 3)
        Me.MainControlTable1.Name = "MainControlTable1"
        Me.MainControlTable1.Size = New System.Drawing.Size(889, 275)
        Me.MainControlTable1.TabIndex = 3
        '
        'FlatStatusBar1
        '
        Me.FlatStatusBar1.BackColor = System.Drawing.Color.LightGray
        Me.FlatStatusBar1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.FlatStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlatStatusBar1.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlatStatusBar1.ForeColor = System.Drawing.Color.White
        Me.FlatStatusBar1.Location = New System.Drawing.Point(0, 275)
        Me.FlatStatusBar1.MaximumSize = New System.Drawing.Size(990, 3111)
        Me.FlatStatusBar1.Name = "FlatStatusBar1"
        Me.FlatStatusBar1.RectColor = System.Drawing.Color.Transparent
        Me.FlatStatusBar1.ShowTimeDate = True
        Me.FlatStatusBar1.Size = New System.Drawing.Size(895, 33)
        Me.FlatStatusBar1.TabIndex = 4
        Me.FlatStatusBar1.Text = "Loading Status ..."
        Me.FlatStatusBar1.TextColor = System.Drawing.Color.White
        '
        'DeviceControlPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Controls.Add(Me.MainControlTable1)
        Me.Controls.Add(Me.FlatStatusBar1)
        Me.Controls.Add(Me.Panel1)
        Me.MaximumSize = New System.Drawing.Size(990, 3111)
        Me.Name = "DeviceControlPanel"
        Me.Size = New System.Drawing.Size(895, 308)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents FlatStatusBar1 As EVO.FlatStatusBar
    Friend WithEvents MainControlTable1 As EVO.DevicesTableLayout
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CircularProgress1 As DevComponents.DotNetBar.Controls.CircularProgress

End Class
