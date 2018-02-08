<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpeciesHandler
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridViewX1 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Column4 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.Column1 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.Column2 = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.Column3 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.AlphaGradientPanel3 = New EVO.AlphaGradientPanel()
        Me.ColorWithAlpha5 = New EVO.ColorWithAlpha()
        Me.ColorWithAlpha6 = New EVO.ColorWithAlpha()
        Me.ColorWithAlpha7 = New EVO.ColorWithAlpha()
        Me.ColorWithAlpha8 = New EVO.ColorWithAlpha()
        Me.ColorWithAlpha9 = New EVO.ColorWithAlpha()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.FlatLabel12 = New EVO.FlatLabel()
        Me.FlatLabel11 = New EVO.FlatLabel()
        Me.FlatLabel10 = New EVO.FlatLabel()
        Me.FlatLabel8 = New EVO.FlatLabel()
        Me.FlatLabel9 = New EVO.FlatLabel()
        Me.AlphaGradientPanel2 = New EVO.AlphaGradientPanel()
        Me.ColorWithAlpha1 = New EVO.ColorWithAlpha()
        Me.ColorWithAlpha2 = New EVO.ColorWithAlpha()
        Me.ColorWithAlpha3 = New EVO.ColorWithAlpha()
        Me.ColorWithAlpha4 = New EVO.ColorWithAlpha()
        Me.FlatLabel7 = New EVO.FlatLabel()
        Me.FlatLabel6 = New EVO.FlatLabel()
        Me.FlatLabel5 = New EVO.FlatLabel()
        Me.FlatLabel4 = New EVO.FlatLabel()
        Me.FlatLabel3 = New EVO.FlatLabel()
        Me.FlatLabel2 = New EVO.FlatLabel()
        Me.FlatLabel1 = New EVO.FlatLabel()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AlphaGradientPanel3.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AlphaGradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 5000
        '
        'CircularProgress1
        '
        Me.CircularProgress1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CircularProgress1.AnimationSpeed = 10
        Me.CircularProgress1.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        '
        '
        '
        Me.CircularProgress1.BackgroundStyle.BackgroundImage = Global.EVO.My.Resources.Resources.mdiClient1_BackgroundImage
        Me.CircularProgress1.BackgroundStyle.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Tile
        Me.CircularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress1.Location = New System.Drawing.Point(126, 117)
        Me.CircularProgress1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CircularProgress1.Name = "CircularProgress1"
        Me.CircularProgress1.PieBorderDark = System.Drawing.Color.Transparent
        Me.CircularProgress1.PieBorderLight = System.Drawing.Color.Transparent
        Me.CircularProgress1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.CircularProgress1.ProgressColor = System.Drawing.Color.White
        Me.CircularProgress1.Size = New System.Drawing.Size(87, 58)
        Me.CircularProgress1.SpokeBorderDark = System.Drawing.Color.Transparent
        Me.CircularProgress1.SpokeBorderLight = System.Drawing.Color.Transparent
        Me.CircularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress1.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CircularProgress1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(343, 291)
        Me.Panel1.TabIndex = 3
        '
        'DataGridViewX1
        '
        Me.DataGridViewX1.AllowUserToAddRows = False
        Me.DataGridViewX1.AllowUserToResizeRows = False
        Me.DataGridViewX1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridViewX1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.DataGridViewX1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("justagain DIN", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewX1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewX1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.Column1, Me.Column2, Me.Column3})
        Me.ContextMenuBar1.SetContextMenuEx(Me.DataGridViewX1, Me.ButtonItem1)
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("justagain DIN", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewX1.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewX1.EnableHeadersVisualStyles = False
        Me.DataGridViewX1.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DataGridViewX1.Location = New System.Drawing.Point(0, 33)
        Me.DataGridViewX1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DataGridViewX1.Name = "DataGridViewX1"
        Me.DataGridViewX1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("justagain DIN", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewX1.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewX1.RowHeadersVisible = False
        Me.DataGridViewX1.SelectAllSignVisible = False
        Me.DataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewX1.ShowRowErrors = False
        Me.DataGridViewX1.Size = New System.Drawing.Size(343, 245)
        Me.DataGridViewX1.TabIndex = 4
        '
        'Column4
        '
        Me.Column4.HeaderText = "ID"
        Me.Column4.Name = "Column4"
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column4.Visible = False
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI Semilight", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.LightSeaGreen
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column1.HeaderText = "الاسم"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        '
        '
        '
        Me.Column2.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.Column2.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.Column2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Column2.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI Semilight", 11.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column2.HeaderText = "السعر"
        Me.Column2.Increment = 1.0R
        Me.Column2.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Teal
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column3.HeaderText = "الكتالوج"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'ButtonItem2
        '
        Me.ButtonItem2.Image = Global.EVO.My.Resources.Resources.x_cross_delete_stop_16
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Text = "حذف"
        '
        'AlphaGradientPanel3
        '
        Me.AlphaGradientPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.AlphaGradientPanel3.Border = True
        Me.AlphaGradientPanel3.BorderColor = System.Drawing.Color.Gold
        Me.AlphaGradientPanel3.Colors.Add(Me.ColorWithAlpha5)
        Me.AlphaGradientPanel3.Colors.Add(Me.ColorWithAlpha6)
        Me.AlphaGradientPanel3.Colors.Add(Me.ColorWithAlpha7)
        Me.AlphaGradientPanel3.Colors.Add(Me.ColorWithAlpha8)
        Me.AlphaGradientPanel3.Colors.Add(Me.ColorWithAlpha9)
        Me.AlphaGradientPanel3.ContentPadding = New System.Windows.Forms.Padding(0)
        Me.AlphaGradientPanel3.Controls.Add(Me.ContextMenuBar1)
        Me.AlphaGradientPanel3.Controls.Add(Me.FlatLabel12)
        Me.AlphaGradientPanel3.Controls.Add(Me.FlatLabel11)
        Me.AlphaGradientPanel3.Controls.Add(Me.FlatLabel10)
        Me.AlphaGradientPanel3.Controls.Add(Me.FlatLabel8)
        Me.AlphaGradientPanel3.Controls.Add(Me.FlatLabel9)
        Me.AlphaGradientPanel3.CornerRadius = 10
        Me.AlphaGradientPanel3.Corners = EVO.Corner.None
        Me.AlphaGradientPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.AlphaGradientPanel3.Gradient = True
        Me.AlphaGradientPanel3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.AlphaGradientPanel3.GradientOffset = 1.0!
        Me.AlphaGradientPanel3.GradientSize = New System.Drawing.Size(0, 0)
        Me.AlphaGradientPanel3.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile
        Me.AlphaGradientPanel3.Grayscale = False
        Me.AlphaGradientPanel3.Image = Nothing
        Me.AlphaGradientPanel3.ImageAlpha = 75
        Me.AlphaGradientPanel3.ImagePadding = New System.Windows.Forms.Padding(5)
        Me.AlphaGradientPanel3.ImagePosition = EVO.ImagePosition.BottomRight
        Me.AlphaGradientPanel3.ImageSize = New System.Drawing.Size(48, 48)
        Me.AlphaGradientPanel3.Location = New System.Drawing.Point(0, 0)
        Me.AlphaGradientPanel3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AlphaGradientPanel3.Name = "AlphaGradientPanel3"
        Me.AlphaGradientPanel3.Rounded = True
        Me.AlphaGradientPanel3.Size = New System.Drawing.Size(343, 33)
        Me.AlphaGradientPanel3.TabIndex = 0
        '
        'ColorWithAlpha5
        '
        Me.ColorWithAlpha5.Alpha = 255
        Me.ColorWithAlpha5.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ColorWithAlpha5.Parent = Me.AlphaGradientPanel3
        '
        'ColorWithAlpha6
        '
        Me.ColorWithAlpha6.Alpha = 170
        Me.ColorWithAlpha6.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ColorWithAlpha6.Parent = Me.AlphaGradientPanel3
        '
        'ColorWithAlpha7
        '
        Me.ColorWithAlpha7.Alpha = 130
        Me.ColorWithAlpha7.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ColorWithAlpha7.Parent = Me.AlphaGradientPanel3
        '
        'ColorWithAlpha8
        '
        Me.ColorWithAlpha8.Alpha = 100
        Me.ColorWithAlpha8.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ColorWithAlpha8.Parent = Me.AlphaGradientPanel3
        '
        'ColorWithAlpha9
        '
        Me.ColorWithAlpha9.Alpha = 40
        Me.ColorWithAlpha9.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ColorWithAlpha9.Parent = Me.AlphaGradientPanel3
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.DockSide = DevComponents.DotNetBar.eDockSide.Top
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(233, 4)
        Me.ContextMenuBar1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(87, 27)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 5
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.AutoExpandOnClick = True
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem2})
        Me.ButtonItem1.Text = "Options"
        '
        'FlatLabel12
        '
        Me.FlatLabel12.AutoSize = True
        Me.FlatLabel12.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel12.Dock = System.Windows.Forms.DockStyle.Left
        Me.FlatLabel12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.FlatLabel12.ForeColor = System.Drawing.Color.White
        Me.FlatLabel12.Location = New System.Drawing.Point(178, 0)
        Me.FlatLabel12.Name = "FlatLabel12"
        Me.FlatLabel12.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.FlatLabel12.Size = New System.Drawing.Size(15, 22)
        Me.FlatLabel12.TabIndex = 6
        Me.FlatLabel12.Text = "0"
        '
        'FlatLabel11
        '
        Me.FlatLabel11.AutoSize = True
        Me.FlatLabel11.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel11.Dock = System.Windows.Forms.DockStyle.Right
        Me.FlatLabel11.Font = New System.Drawing.Font("Segoe UI", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlatLabel11.ForeColor = System.Drawing.Color.White
        Me.FlatLabel11.Location = New System.Drawing.Point(343, 0)
        Me.FlatLabel11.Name = "FlatLabel11"
        Me.FlatLabel11.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.FlatLabel11.Size = New System.Drawing.Size(0, 28)
        Me.FlatLabel11.TabIndex = 5
        '
        'FlatLabel10
        '
        Me.FlatLabel10.AutoSize = True
        Me.FlatLabel10.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel10.Dock = System.Windows.Forms.DockStyle.Left
        Me.FlatLabel10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.FlatLabel10.ForeColor = System.Drawing.Color.White
        Me.FlatLabel10.Location = New System.Drawing.Point(90, 0)
        Me.FlatLabel10.Name = "FlatLabel10"
        Me.FlatLabel10.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.FlatLabel10.Size = New System.Drawing.Size(88, 22)
        Me.FlatLabel10.TabIndex = 7
        Me.FlatLabel10.Text = "| عدد الطلبات : "
        '
        'FlatLabel8
        '
        Me.FlatLabel8.AutoSize = True
        Me.FlatLabel8.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel8.Dock = System.Windows.Forms.DockStyle.Left
        Me.FlatLabel8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.FlatLabel8.ForeColor = System.Drawing.Color.White
        Me.FlatLabel8.Location = New System.Drawing.Point(75, 0)
        Me.FlatLabel8.Name = "FlatLabel8"
        Me.FlatLabel8.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.FlatLabel8.Size = New System.Drawing.Size(15, 22)
        Me.FlatLabel8.TabIndex = 3
        Me.FlatLabel8.Text = "0"
        '
        'FlatLabel9
        '
        Me.FlatLabel9.AutoSize = True
        Me.FlatLabel9.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel9.Dock = System.Windows.Forms.DockStyle.Left
        Me.FlatLabel9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.FlatLabel9.ForeColor = System.Drawing.Color.White
        Me.FlatLabel9.Location = New System.Drawing.Point(0, 0)
        Me.FlatLabel9.Name = "FlatLabel9"
        Me.FlatLabel9.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.FlatLabel9.Size = New System.Drawing.Size(75, 22)
        Me.FlatLabel9.TabIndex = 2
        Me.FlatLabel9.Text = "اسم الجهاز : "
        '
        'AlphaGradientPanel2
        '
        Me.AlphaGradientPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.AlphaGradientPanel2.Border = True
        Me.AlphaGradientPanel2.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Me.AlphaGradientPanel2.Colors.Add(Me.ColorWithAlpha1)
        Me.AlphaGradientPanel2.Colors.Add(Me.ColorWithAlpha2)
        Me.AlphaGradientPanel2.Colors.Add(Me.ColorWithAlpha3)
        Me.AlphaGradientPanel2.Colors.Add(Me.ColorWithAlpha4)
        Me.AlphaGradientPanel2.ContentPadding = New System.Windows.Forms.Padding(0)
        Me.AlphaGradientPanel2.Controls.Add(Me.FlatLabel7)
        Me.AlphaGradientPanel2.Controls.Add(Me.FlatLabel6)
        Me.AlphaGradientPanel2.Controls.Add(Me.FlatLabel5)
        Me.AlphaGradientPanel2.Controls.Add(Me.FlatLabel4)
        Me.AlphaGradientPanel2.Controls.Add(Me.FlatLabel3)
        Me.AlphaGradientPanel2.Controls.Add(Me.FlatLabel2)
        Me.AlphaGradientPanel2.Controls.Add(Me.FlatLabel1)
        Me.AlphaGradientPanel2.CornerRadius = 10
        Me.AlphaGradientPanel2.Corners = EVO.Corner.None
        Me.AlphaGradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.AlphaGradientPanel2.Gradient = True
        Me.AlphaGradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.AlphaGradientPanel2.GradientOffset = 1.0!
        Me.AlphaGradientPanel2.GradientSize = New System.Drawing.Size(0, 0)
        Me.AlphaGradientPanel2.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile
        Me.AlphaGradientPanel2.Grayscale = False
        Me.AlphaGradientPanel2.Image = Nothing
        Me.AlphaGradientPanel2.ImageAlpha = 75
        Me.AlphaGradientPanel2.ImagePadding = New System.Windows.Forms.Padding(5)
        Me.AlphaGradientPanel2.ImagePosition = EVO.ImagePosition.BottomRight
        Me.AlphaGradientPanel2.ImageSize = New System.Drawing.Size(48, 48)
        Me.AlphaGradientPanel2.Location = New System.Drawing.Point(0, 278)
        Me.AlphaGradientPanel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AlphaGradientPanel2.Name = "AlphaGradientPanel2"
        Me.AlphaGradientPanel2.Rounded = True
        Me.AlphaGradientPanel2.Size = New System.Drawing.Size(343, 13)
        Me.AlphaGradientPanel2.TabIndex = 1
        '
        'ColorWithAlpha1
        '
        Me.ColorWithAlpha1.Alpha = 255
        Me.ColorWithAlpha1.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ColorWithAlpha1.Parent = Me.AlphaGradientPanel2
        '
        'ColorWithAlpha2
        '
        Me.ColorWithAlpha2.Alpha = 255
        Me.ColorWithAlpha2.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ColorWithAlpha2.Parent = Me.AlphaGradientPanel2
        '
        'ColorWithAlpha3
        '
        Me.ColorWithAlpha3.Alpha = 255
        Me.ColorWithAlpha3.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ColorWithAlpha3.Parent = Me.AlphaGradientPanel2
        '
        'ColorWithAlpha4
        '
        Me.ColorWithAlpha4.Alpha = 255
        Me.ColorWithAlpha4.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ColorWithAlpha4.Parent = Me.AlphaGradientPanel2
        '
        'FlatLabel7
        '
        Me.FlatLabel7.AutoSize = True
        Me.FlatLabel7.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.FlatLabel7.Font = New System.Drawing.Font("Segoe UI", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlatLabel7.ForeColor = System.Drawing.Color.Black
        Me.FlatLabel7.Location = New System.Drawing.Point(0, 0)
        Me.FlatLabel7.Name = "FlatLabel7"
        Me.FlatLabel7.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.FlatLabel7.Size = New System.Drawing.Size(0, 28)
        Me.FlatLabel7.TabIndex = 6
        '
        'FlatLabel6
        '
        Me.FlatLabel6.AutoSize = True
        Me.FlatLabel6.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.FlatLabel6.Font = New System.Drawing.Font("Segoe UI", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlatLabel6.ForeColor = System.Drawing.Color.Black
        Me.FlatLabel6.Location = New System.Drawing.Point(0, 0)
        Me.FlatLabel6.Name = "FlatLabel6"
        Me.FlatLabel6.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.FlatLabel6.Size = New System.Drawing.Size(0, 28)
        Me.FlatLabel6.TabIndex = 5
        '
        'FlatLabel5
        '
        Me.FlatLabel5.AutoSize = True
        Me.FlatLabel5.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.FlatLabel5.Font = New System.Drawing.Font("Segoe UI", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlatLabel5.ForeColor = System.Drawing.Color.Black
        Me.FlatLabel5.Location = New System.Drawing.Point(84, 0)
        Me.FlatLabel5.Name = "FlatLabel5"
        Me.FlatLabel5.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.FlatLabel5.Size = New System.Drawing.Size(20, 28)
        Me.FlatLabel5.TabIndex = 4
        Me.FlatLabel5.Text = "0"
        Me.FlatLabel5.Visible = False
        '
        'FlatLabel4
        '
        Me.FlatLabel4.AutoSize = True
        Me.FlatLabel4.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.FlatLabel4.Font = New System.Drawing.Font("Segoe UI", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlatLabel4.ForeColor = System.Drawing.Color.Black
        Me.FlatLabel4.Location = New System.Drawing.Point(104, 0)
        Me.FlatLabel4.Name = "FlatLabel4"
        Me.FlatLabel4.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.FlatLabel4.Size = New System.Drawing.Size(110, 28)
        Me.FlatLabel4.TabIndex = 3
        Me.FlatLabel4.Text = " : عدد الطلبات "
        Me.FlatLabel4.Visible = False
        '
        'FlatLabel3
        '
        Me.FlatLabel3.AutoSize = True
        Me.FlatLabel3.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.FlatLabel3.Font = New System.Drawing.Font("Segoe UI Light", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlatLabel3.ForeColor = System.Drawing.Color.Black
        Me.FlatLabel3.Location = New System.Drawing.Point(214, 0)
        Me.FlatLabel3.Name = "FlatLabel3"
        Me.FlatLabel3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 13)
        Me.FlatLabel3.Size = New System.Drawing.Size(23, 50)
        Me.FlatLabel3.TabIndex = 2
        Me.FlatLabel3.Text = "|"
        Me.FlatLabel3.Visible = False
        '
        'FlatLabel2
        '
        Me.FlatLabel2.AutoSize = True
        Me.FlatLabel2.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.FlatLabel2.Font = New System.Drawing.Font("Segoe UI", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlatLabel2.ForeColor = System.Drawing.Color.Black
        Me.FlatLabel2.Location = New System.Drawing.Point(237, 0)
        Me.FlatLabel2.Name = "FlatLabel2"
        Me.FlatLabel2.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.FlatLabel2.Size = New System.Drawing.Size(35, 28)
        Me.FlatLabel2.TabIndex = 1
        Me.FlatLabel2.Text = "0.0"
        Me.FlatLabel2.Visible = False
        '
        'FlatLabel1
        '
        Me.FlatLabel1.AutoSize = True
        Me.FlatLabel1.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.FlatLabel1.Font = New System.Drawing.Font("Segoe UI", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlatLabel1.ForeColor = System.Drawing.Color.Black
        Me.FlatLabel1.Location = New System.Drawing.Point(272, 0)
        Me.FlatLabel1.Name = "FlatLabel1"
        Me.FlatLabel1.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.FlatLabel1.Size = New System.Drawing.Size(71, 28)
        Me.FlatLabel1.TabIndex = 0
        Me.FlatLabel1.Text = " : فاتوره "
        Me.FlatLabel1.Visible = False
        '
        'SpeciesHandler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Controls.Add(Me.DataGridViewX1)
        Me.Controls.Add(Me.AlphaGradientPanel3)
        Me.Controls.Add(Me.AlphaGradientPanel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("justagain DIN", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "SpeciesHandler"
        Me.Size = New System.Drawing.Size(343, 291)
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AlphaGradientPanel3.ResumeLayout(False)
        Me.AlphaGradientPanel3.PerformLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AlphaGradientPanel2.ResumeLayout(False)
        Me.AlphaGradientPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ColorWithAlpha1 As EVO.ColorWithAlpha
    Friend WithEvents ColorWithAlpha2 As EVO.ColorWithAlpha
    Friend WithEvents ColorWithAlpha3 As EVO.ColorWithAlpha
    Friend WithEvents ColorWithAlpha4 As EVO.ColorWithAlpha
    Friend WithEvents AlphaGradientPanel3 As EVO.AlphaGradientPanel
    Friend WithEvents ColorWithAlpha5 As EVO.ColorWithAlpha
    Friend WithEvents ColorWithAlpha6 As EVO.ColorWithAlpha
    Friend WithEvents ColorWithAlpha7 As EVO.ColorWithAlpha
    Friend WithEvents ColorWithAlpha8 As EVO.ColorWithAlpha
    Friend WithEvents ColorWithAlpha9 As EVO.ColorWithAlpha
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents FlatLabel11 As EVO.FlatLabel
    Friend WithEvents FlatLabel8 As EVO.FlatLabel
    Friend WithEvents FlatLabel9 As EVO.FlatLabel
    Friend WithEvents FlatLabel12 As EVO.FlatLabel
    Friend WithEvents FlatLabel10 As EVO.FlatLabel
    Friend WithEvents CircularProgress1 As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents AlphaGradientPanel2 As EVO.AlphaGradientPanel
    Friend WithEvents FlatLabel7 As EVO.FlatLabel
    Friend WithEvents FlatLabel6 As EVO.FlatLabel
    Friend WithEvents FlatLabel5 As EVO.FlatLabel
    Friend WithEvents FlatLabel4 As EVO.FlatLabel
    Friend WithEvents FlatLabel3 As EVO.FlatLabel
    Friend WithEvents FlatLabel2 As EVO.FlatLabel
    Friend WithEvents FlatLabel1 As EVO.FlatLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridViewX1 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Column4 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents Column1 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents Column2 As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents Column3 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn

End Class
