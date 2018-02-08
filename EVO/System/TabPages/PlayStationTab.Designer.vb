<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlayStationTab
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PlayStationTab))
        Me.SystemPanel1 = New EVO.SystemPanel()
        Me.ResizeBeginTmr = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SystemPanel1
        '
        Me.SystemPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.SystemPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SystemPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SystemPanel1.Name = "SystemPanel1"
        Me.SystemPanel1.Size = New System.Drawing.Size(953, 353)
        Me.SystemPanel1.TabIndex = 0
        '
        'ResizeBeginTmr
        '
        Me.ResizeBeginTmr.Interval = 3000
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.EVO.My.Resources.Resources.mdiClient1_BackgroundImage
        Me.Panel1.Controls.Add(Me.CircularProgress1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(953, 353)
        Me.Panel1.TabIndex = 6
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
        Me.CircularProgress1.Location = New System.Drawing.Point(437, 155)
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
        'PlayStationTab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(953, 353)
        Me.ControlBox = False
        Me.Controls.Add(Me.SystemPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PlayStationTab"
        Me.Text = "Form2"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SystemPanel1 As EVO.SystemPanel
    Friend WithEvents ResizeBeginTmr As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CircularProgress1 As DevComponents.DotNetBar.Controls.CircularProgress
End Class
