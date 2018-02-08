<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SystemPanel
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
        Me.ButtonItem6 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem7 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem8 = New DevComponents.DotNetBar.ButtonItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DeviceControlPanel1 = New EVO.DeviceControlPanel()
        Me.ExpandableSplitter3 = New DevComponents.DotNetBar.ExpandableSplitter()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.ChangedDevicesViewr1 = New EVO.ChangedDevicesViewr()
        Me.OrderHandler1 = New EVO.OrderHandler()
        Me.expandableSplitter1 = New DevComponents.DotNetBar.ExpandableSplitter()
        Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx()
        Me.UserShiftViewer1 = New EVO.UserShiftViewer()
        Me.SpeciesHandler1 = New EVO.SpeciesHandler()
        Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
        Me.PanelEx2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonItem6
        '
        Me.ButtonItem6.Name = "ButtonItem6"
        Me.ButtonItem6.Text = "ButtonItem4"
        '
        'ButtonItem7
        '
        Me.ButtonItem7.Name = "ButtonItem7"
        Me.ButtonItem7.Text = "ButtonItem4"
        '
        'ButtonItem8
        '
        Me.ButtonItem8.Name = "ButtonItem8"
        Me.ButtonItem8.Text = "ButtonItem4"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.expandableSplitter1)
        Me.Panel1.Controls.Add(Me.PanelEx2)
        Me.Panel1.Controls.Add(Me.CircularProgress1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1258, 507)
        Me.Panel1.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DeviceControlPanel1)
        Me.Panel2.Controls.Add(Me.ExpandableSplitter3)
        Me.Panel2.Controls.Add(Me.PanelEx1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(943, 507)
        Me.Panel2.TabIndex = 11
        '
        'DeviceControlPanel1
        '
        Me.DeviceControlPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.DeviceControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DeviceControlPanel1.Location = New System.Drawing.Point(0, 0)
        Me.DeviceControlPanel1.MaximumSize = New System.Drawing.Size(990, 3111)
        Me.DeviceControlPanel1.Name = "DeviceControlPanel1"
        Me.DeviceControlPanel1.Size = New System.Drawing.Size(943, 499)
        Me.DeviceControlPanel1.TabIndex = 0
        '
        'ExpandableSplitter3
        '
        Me.ExpandableSplitter3.AnimationTime = 200
        Me.ExpandableSplitter3.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ExpandableSplitter3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ExpandableSplitter3.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.ExpandableSplitter3.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.ExpandableSplitter3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ExpandableSplitter3.ExpandableControl = Me.PanelEx1
        Me.ExpandableSplitter3.ExpandActionClick = False
        Me.ExpandableSplitter3.ExpandActionDoubleClick = True
        Me.ExpandableSplitter3.Expanded = False
        Me.ExpandableSplitter3.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ExpandableSplitter3.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.ExpandableSplitter3.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ExpandableSplitter3.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.ExpandableSplitter3.ForeColor = System.Drawing.Color.Black
        Me.ExpandableSplitter3.GripDarkColor = System.Drawing.Color.AntiqueWhite
        Me.ExpandableSplitter3.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.ExpandableSplitter3.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ExpandableSplitter3.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.ExpandableSplitter3.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ExpandableSplitter3.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ExpandableSplitter3.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.ExpandableSplitter3.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.ExpandableSplitter3.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ExpandableSplitter3.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.ExpandableSplitter3.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ExpandableSplitter3.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.ExpandableSplitter3.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ExpandableSplitter3.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.ExpandableSplitter3.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ExpandableSplitter3.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.ExpandableSplitter3.Location = New System.Drawing.Point(0, 499)
        Me.ExpandableSplitter3.Name = "ExpandableSplitter3"
        Me.ExpandableSplitter3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ExpandableSplitter3.Shortcut = DevComponents.DotNetBar.eShortcut.F1
        Me.ExpandableSplitter3.Size = New System.Drawing.Size(943, 8)
        Me.ExpandableSplitter3.TabIndex = 1
        Me.ExpandableSplitter3.TabStop = False
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.PanelEx1.Controls.Add(Me.ChangedDevicesViewr1)
        Me.PanelEx1.Controls.Add(Me.OrderHandler1)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelEx1.Location = New System.Drawing.Point(0, 324)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(925, 183)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.PanelEx1.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.StyleMouseDown.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.PanelEx1.StyleMouseDown.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.PanelEx1.TabIndex = 0
        Me.PanelEx1.Visible = False
        '
        'ChangedDevicesViewr1
        '
        Me.ChangedDevicesViewr1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChangedDevicesViewr1.Location = New System.Drawing.Point(549, 0)
        Me.ChangedDevicesViewr1.Name = "ChangedDevicesViewr1"
        Me.ChangedDevicesViewr1.Size = New System.Drawing.Size(376, 183)
        Me.ChangedDevicesViewr1.TabIndex = 1
        '
        'OrderHandler1
        '
        Me.OrderHandler1.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.OrderHandler1.Dock = System.Windows.Forms.DockStyle.Left
        Me.OrderHandler1.Location = New System.Drawing.Point(0, 0)
        Me.OrderHandler1.Name = "OrderHandler1"
        Me.OrderHandler1.Size = New System.Drawing.Size(549, 183)
        Me.OrderHandler1.TabIndex = 0
        '
        'expandableSplitter1
        '
        Me.expandableSplitter1.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.expandableSplitter1.Dock = System.Windows.Forms.DockStyle.Right
        Me.expandableSplitter1.ExpandableControl = Me.PanelEx2
        Me.expandableSplitter1.ExpandActionClick = False
        Me.expandableSplitter1.ExpandActionDoubleClick = True
        Me.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.expandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.expandableSplitter1.ForeColor = System.Drawing.Color.Black
        Me.expandableSplitter1.GripDarkColor = System.Drawing.Color.Azure
        Me.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.expandableSplitter1.Location = New System.Drawing.Point(943, 0)
        Me.expandableSplitter1.Name = "expandableSplitter1"
        Me.expandableSplitter1.Size = New System.Drawing.Size(10, 507)
        Me.expandableSplitter1.TabIndex = 1
        Me.expandableSplitter1.TabStop = False
        '
        'PanelEx2
        '
        Me.PanelEx2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelEx2.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.PanelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx2.Controls.Add(Me.UserShiftViewer1)
        Me.PanelEx2.Controls.Add(Me.SpeciesHandler1)
        Me.PanelEx2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelEx2.Location = New System.Drawing.Point(953, 0)
        Me.PanelEx2.MaximumSize = New System.Drawing.Size(323, 0)
        Me.PanelEx2.Name = "PanelEx2"
        Me.PanelEx2.Size = New System.Drawing.Size(305, 507)
        Me.PanelEx2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.PanelEx2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.PanelEx2.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile
        Me.PanelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx2.Style.GradientAngle = 90
        Me.PanelEx2.TabIndex = 12
        '
        'UserShiftViewer1
        '
        Me.UserShiftViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UserShiftViewer1.Location = New System.Drawing.Point(0, 322)
        Me.UserShiftViewer1.Name = "UserShiftViewer1"
        Me.UserShiftViewer1.Size = New System.Drawing.Size(305, 185)
        Me.UserShiftViewer1.TabIndex = 2
        '
        'SpeciesHandler1
        '
        Me.SpeciesHandler1.BackColor = System.Drawing.Color.Transparent
        Me.SpeciesHandler1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SpeciesHandler1.Location = New System.Drawing.Point(0, 0)
        Me.SpeciesHandler1.Name = "SpeciesHandler1"
        Me.SpeciesHandler1.Size = New System.Drawing.Size(305, 322)
        Me.SpeciesHandler1.TabIndex = 1
        '
        'CircularProgress1
        '
        Me.CircularProgress1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CircularProgress1.AnimationSpeed = 10
        Me.CircularProgress1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.CircularProgress1.BackgroundStyle.BackgroundImage = Global.EVO.My.Resources.Resources.mdiClient1_BackgroundImage
        Me.CircularProgress1.BackgroundStyle.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Tile
        Me.CircularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress1.Location = New System.Drawing.Point(590, 232)
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
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 2000
        '
        'SystemPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Controls.Add(Me.Panel1)
        Me.Name = "SystemPanel"
        Me.Size = New System.Drawing.Size(1258, 507)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DeviceControlPanel1 As EVO.DeviceControlPanel
    Friend WithEvents ButtonItem6 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem7 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem8 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents OrderHandler1 As EVO.OrderHandler
    Friend WithEvents SpeciesHandler1 As EVO.SpeciesHandler
    Friend WithEvents CircularProgress1 As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents expandableSplitter1 As DevComponents.DotNetBar.ExpandableSplitter
    Friend WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ExpandableSplitter3 As DevComponents.DotNetBar.ExpandableSplitter
    Friend WithEvents ChangedDevicesViewr1 As EVO.ChangedDevicesViewr
    Friend WithEvents UserShiftViewer1 As EVO.UserShiftViewer


End Class
