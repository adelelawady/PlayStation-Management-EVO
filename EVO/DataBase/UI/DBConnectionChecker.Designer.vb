<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DBConnectionChecker
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DBConnectionChecker))
        Me.DBChecker = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GameBoosterTheme1 = New EVO.GameBoosterTheme()
        Me.FlatClose1 = New EVO.FlatClose()
        Me.AetherTag2 = New EVO.AetherTag()
        Me.AetherTag1 = New EVO.AetherTag()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GameBoosterTheme1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DBChecker
        '
        '
        'Timer1
        '
        Me.Timer1.Interval = 1500
        '
        'GameBoosterTheme1
        '
        Me.GameBoosterTheme1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GameBoosterTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.GameBoosterTheme1.Controls.Add(Me.FlatClose1)
        Me.GameBoosterTheme1.Controls.Add(Me.AetherTag2)
        Me.GameBoosterTheme1.Controls.Add(Me.AetherTag1)
        Me.GameBoosterTheme1.Controls.Add(Me.PictureBox1)
        Me.GameBoosterTheme1.Customization = "6Ojo//z8/P/y8vL//////1BQUP//////AAAA////////////lpaW/w=="
        Me.GameBoosterTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GameBoosterTheme1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.GameBoosterTheme1.Image = Nothing
        Me.GameBoosterTheme1.Location = New System.Drawing.Point(0, 0)
        Me.GameBoosterTheme1.Movable = True
        Me.GameBoosterTheme1.Name = "GameBoosterTheme1"
        Me.GameBoosterTheme1.NoRounding = False
        Me.GameBoosterTheme1.Sizable = False
        Me.GameBoosterTheme1.Size = New System.Drawing.Size(395, 95)
        Me.GameBoosterTheme1.SmartBounds = True
        Me.GameBoosterTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GameBoosterTheme1.TabIndex = 1
        Me.GameBoosterTheme1.Text = "DB Connection Check"
        Me.GameBoosterTheme1.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.GameBoosterTheme1.Transparent = False
        '
        'FlatClose1
        '
        Me.FlatClose1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatClose1.BackColor = System.Drawing.Color.White
        Me.FlatClose1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.FlatClose1.Font = New System.Drawing.Font("Marlett", 10.0!)
        Me.FlatClose1.Location = New System.Drawing.Point(372, 4)
        Me.FlatClose1.Name = "FlatClose1"
        Me.FlatClose1.Size = New System.Drawing.Size(18, 18)
        Me.FlatClose1.TabIndex = 5
        Me.FlatClose1.Text = "FlatClose1"
        Me.FlatClose1.TextColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        '
        'AetherTag2
        '
        Me.AetherTag2.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.AetherTag2.Background = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.AetherTag2.Border = System.Drawing.Color.ForestGreen
        Me.AetherTag2.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.AetherTag2.Location = New System.Drawing.Point(100, 66)
        Me.AetherTag2.Name = "AetherTag2"
        Me.AetherTag2.Size = New System.Drawing.Size(125, 15)
        Me.AetherTag2.TabIndex = 3
        Me.AetherTag2.Text = "Connecting...."
        Me.AetherTag2.TextColor = System.Drawing.Color.White
        '
        'AetherTag1
        '
        Me.AetherTag1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.AetherTag1.Background = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.AetherTag1.Border = System.Drawing.Color.White
        Me.AetherTag1.Location = New System.Drawing.Point(100, 38)
        Me.AetherTag1.Name = "AetherTag1"
        Me.AetherTag1.Size = New System.Drawing.Size(250, 15)
        Me.AetherTag1.TabIndex = 1
        Me.AetherTag1.Text = "Checking DataBase Connection "
        Me.AetherTag1.TextColor = System.Drawing.Color.White
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(25, 33)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(47, 47)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'DBConnectionChecker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(395, 95)
        Me.Controls.Add(Me.GameBoosterTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DBConnectionChecker"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DBConnectionChecker"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.GameBoosterTheme1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GameBoosterTheme1 As EVO.GameBoosterTheme
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents AetherTag1 As EVO.AetherTag
    Friend WithEvents AetherTag2 As EVO.AetherTag
    Friend WithEvents DBChecker As System.ComponentModel.BackgroundWorker
    Friend WithEvents FlatClose1 As EVO.FlatClose
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
