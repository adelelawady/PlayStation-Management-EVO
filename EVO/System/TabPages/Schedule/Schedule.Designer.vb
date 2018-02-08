<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Schedule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Schedule))
        Me.calendarView1 = New DevComponents.DotNetBar.Schedule.CalendarView()
        Me.dateNavigator1 = New DevComponents.DotNetBar.Schedule.DateNavigator()
        Me.barView = New DevComponents.DotNetBar.Bar()
        Me.btnDay = New DevComponents.DotNetBar.ButtonItem()
        Me.btnWeek = New DevComponents.DotNetBar.ButtonItem()
        Me.btnMonth = New DevComponents.DotNetBar.ButtonItem()
        Me.btnTimeLine = New DevComponents.DotNetBar.ButtonItem()
        Me.contextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.InContentContextMenu = New DevComponents.DotNetBar.ButtonItem()
        Me.InContentAddAppContextItem = New DevComponents.DotNetBar.ButtonItem()
        Me.AppointmentContextMenu = New DevComponents.DotNetBar.ButtonItem()
        Me.AppDeleteContextItem = New DevComponents.DotNetBar.ButtonItem()
        Me.labelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.labelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.CondensedViewContextMenu = New DevComponents.DotNetBar.ButtonItem()
        Me.labelItem8 = New DevComponents.DotNetBar.LabelItem()
        Me.btnCondensedViewAll = New DevComponents.DotNetBar.ButtonItem()
        Me.btnCondensedViewSelected = New DevComponents.DotNetBar.ButtonItem()
        Me.btnCondensedViewHidden = New DevComponents.DotNetBar.ButtonItem()
        Me.InSideBarContextMenu = New DevComponents.DotNetBar.ButtonItem()
        Me.InSideBarHideContextItem = New DevComponents.DotNetBar.ButtonItem()
        Me.InHeaderContextMenu = New DevComponents.DotNetBar.ButtonItem()
        Me.InHeaderShowSideBarContextItem = New DevComponents.DotNetBar.ButtonItem()
        Me.InHeaderHideSideBarContextItem = New DevComponents.DotNetBar.ButtonItem()
        Me.labelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.InHeaderCalColorBlue = New DevComponents.DotNetBar.ButtonItem()
        Me.InHeaderCalColorGreen = New DevComponents.DotNetBar.ButtonItem()
        Me.InHeaderCalColorMaroon = New DevComponents.DotNetBar.ButtonItem()
        Me.InHeaderCalColorSteel = New DevComponents.DotNetBar.ButtonItem()
        Me.InHeaderCalColorTeal = New DevComponents.DotNetBar.ButtonItem()
        Me.InHeaderCalColorPurple = New DevComponents.DotNetBar.ButtonItem()
        Me.InHeaderCalColorOlive = New DevComponents.DotNetBar.ButtonItem()
        Me.InHeaderCalColorRed = New DevComponents.DotNetBar.ButtonItem()
        Me.InHeaderCalColorDarkPeach = New DevComponents.DotNetBar.ButtonItem()
        Me.InHeaderCalColorDarkSteel = New DevComponents.DotNetBar.ButtonItem()
        Me.InHeaderCalColorDarkGreen = New DevComponents.DotNetBar.ButtonItem()
        Me.InHeaderCalColorYellow = New DevComponents.DotNetBar.ButtonItem()
        Me.InHeaderCalColorAutomatic = New DevComponents.DotNetBar.ButtonItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.barView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.contextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'calendarView1
        '
        Me.calendarView1.AppointmentBorderWidth = 2
        Me.calendarView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.calendarView1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.calendarView1.ContainerControlProcessDialogKey = True
        Me.calendarView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.calendarView1.Font = New System.Drawing.Font("Segoe UI Semilight", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.calendarView1.HighlightCurrentDay = True
        Me.calendarView1.LabelTimeSlots = True
        Me.calendarView1.Location = New System.Drawing.Point(0, 61)
        Me.calendarView1.MinimumTimeSlotHeight = 50
        Me.calendarView1.MultiUserTabHeight = 19
        Me.calendarView1.Name = "calendarView1"
        Me.calendarView1.Size = New System.Drawing.Size(746, 376)
        Me.calendarView1.TabIndex = 12
        Me.calendarView1.Text = "calendarView1"
        Me.calendarView1.TimeIndicator.BorderColor = System.Drawing.Color.Gold
        Me.calendarView1.TimeIndicator.IndicatorArea = DevComponents.DotNetBar.Schedule.eTimeIndicatorArea.All
        Me.calendarView1.TimeIndicator.Tag = Nothing
        Me.calendarView1.TimeIndicator.Thickness = 5
        Me.calendarView1.TimeIndicator.Visibility = DevComponents.DotNetBar.Schedule.eTimeIndicatorVisibility.AllResources
        Me.calendarView1.TimeSlotDuration = 30
        '
        'dateNavigator1
        '
        Me.dateNavigator1.CalendarView = Me.calendarView1
        Me.dateNavigator1.CanvasColor = System.Drawing.SystemColors.Control
        Me.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Top
        Me.dateNavigator1.Location = New System.Drawing.Point(0, 31)
        Me.dateNavigator1.Name = "dateNavigator1"
        Me.dateNavigator1.Size = New System.Drawing.Size(746, 30)
        Me.dateNavigator1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dateNavigator1.TabIndex = 11
        Me.dateNavigator1.Text = "dateNavigator1"
        '
        'barView
        '
        Me.barView.Dock = System.Windows.Forms.DockStyle.Top
        Me.barView.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.barView.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnDay, Me.btnWeek, Me.btnMonth, Me.btnTimeLine})
        Me.barView.Location = New System.Drawing.Point(0, 0)
        Me.barView.Name = "barView"
        Me.barView.RoundCorners = False
        Me.barView.Size = New System.Drawing.Size(746, 31)
        Me.barView.Stretch = True
        Me.barView.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.barView.TabIndex = 10
        Me.barView.TabStop = False
        Me.barView.Text = "bar1"
        '
        'btnDay
        '
        Me.btnDay.Checked = True
        Me.btnDay.Name = "btnDay"
        Me.btnDay.OptionGroup = "View"
        Me.btnDay.Text = "Day"
        '
        'btnWeek
        '
        Me.btnWeek.Name = "btnWeek"
        Me.btnWeek.OptionGroup = "View"
        Me.btnWeek.Text = "Week"
        '
        'btnMonth
        '
        Me.btnMonth.Name = "btnMonth"
        Me.btnMonth.OptionGroup = "View"
        Me.btnMonth.Text = "Month"
        '
        'btnTimeLine
        '
        Me.btnTimeLine.Name = "btnTimeLine"
        Me.btnTimeLine.OptionGroup = "View"
        Me.btnTimeLine.Text = "TimeLine"
        '
        'contextMenuBar1
        '
        Me.contextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.contextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.InContentContextMenu, Me.AppointmentContextMenu, Me.CondensedViewContextMenu, Me.InSideBarContextMenu, Me.InHeaderContextMenu})
        Me.contextMenuBar1.Location = New System.Drawing.Point(123, 181)
        Me.contextMenuBar1.Name = "contextMenuBar1"
        Me.contextMenuBar1.Size = New System.Drawing.Size(501, 27)
        Me.contextMenuBar1.Stretch = True
        Me.contextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.contextMenuBar1.TabIndex = 13
        Me.contextMenuBar1.TabStop = False
        Me.contextMenuBar1.Text = "contextMenuBar1"
        '
        'InContentContextMenu
        '
        Me.InContentContextMenu.AutoExpandOnClick = True
        Me.InContentContextMenu.Name = "InContentContextMenu"
        Me.InContentContextMenu.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.InContentAddAppContextItem})
        Me.InContentContextMenu.Text = "InContent"
        '
        'InContentAddAppContextItem
        '
        Me.InContentAddAppContextItem.Name = "InContentAddAppContextItem"
        Me.InContentAddAppContextItem.Text = "Add Reservation"
        '
        'AppointmentContextMenu
        '
        Me.AppointmentContextMenu.AutoExpandOnClick = True
        Me.AppointmentContextMenu.Name = "AppointmentContextMenu"
        Me.AppointmentContextMenu.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.AppDeleteContextItem, Me.labelItem3, Me.labelItem4, Me.LabelItem1, Me.LabelItem5})
        Me.AppointmentContextMenu.Text = "Appointment"
        '
        'AppDeleteContextItem
        '
        Me.AppDeleteContextItem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.AppDeleteContextItem.Name = "AppDeleteContextItem"
        Me.AppDeleteContextItem.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2)
        Me.AppDeleteContextItem.Text = "Delete Appointment"
        '
        'labelItem3
        '
        Me.labelItem3.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.labelItem3.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.labelItem3.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.labelItem3.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelItem3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.labelItem3.Name = "labelItem3"
        Me.labelItem3.PaddingBottom = 1
        Me.labelItem3.PaddingLeft = 10
        Me.labelItem3.PaddingTop = 1
        Me.labelItem3.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.labelItem3.Text = "TYPE"
        '
        'labelItem4
        '
        Me.labelItem4.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.labelItem4.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.labelItem4.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.labelItem4.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelItem4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.labelItem4.Name = "labelItem4"
        Me.labelItem4.PaddingBottom = 1
        Me.labelItem4.PaddingLeft = 10
        Me.labelItem4.PaddingTop = 1
        Me.labelItem4.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.labelItem4.Text = "Client"
        '
        'LabelItem1
        '
        Me.LabelItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem1.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem1.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem1.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.PaddingBottom = 1
        Me.LabelItem1.PaddingLeft = 10
        Me.LabelItem1.PaddingTop = 1
        Me.LabelItem1.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem1.Text = "BY"
        '
        'LabelItem5
        '
        Me.LabelItem5.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem5.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem5.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem5.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelItem5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem5.Name = "LabelItem5"
        Me.LabelItem5.PaddingBottom = 1
        Me.LabelItem5.PaddingLeft = 10
        Me.LabelItem5.PaddingTop = 1
        Me.LabelItem5.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem5.Text = "Paid"
        '
        'CondensedViewContextMenu
        '
        Me.CondensedViewContextMenu.AutoExpandOnClick = True
        Me.CondensedViewContextMenu.Name = "CondensedViewContextMenu"
        Me.CondensedViewContextMenu.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.labelItem8, Me.btnCondensedViewAll, Me.btnCondensedViewSelected, Me.btnCondensedViewHidden})
        Me.CondensedViewContextMenu.Text = "InCondensedView"
        '
        'labelItem8
        '
        Me.labelItem8.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.labelItem8.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.labelItem8.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.labelItem8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.labelItem8.Name = "labelItem8"
        Me.labelItem8.PaddingBottom = 1
        Me.labelItem8.PaddingLeft = 10
        Me.labelItem8.PaddingTop = 1
        Me.labelItem8.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.labelItem8.Text = "Visibility"
        '
        'btnCondensedViewAll
        '
        Me.btnCondensedViewAll.Name = "btnCondensedViewAll"
        Me.btnCondensedViewAll.Text = "All"
        '
        'btnCondensedViewSelected
        '
        Me.btnCondensedViewSelected.Name = "btnCondensedViewSelected"
        Me.btnCondensedViewSelected.Text = "Selected"
        '
        'btnCondensedViewHidden
        '
        Me.btnCondensedViewHidden.Name = "btnCondensedViewHidden"
        Me.btnCondensedViewHidden.Text = "Hidden"
        '
        'InSideBarContextMenu
        '
        Me.InSideBarContextMenu.AutoExpandOnClick = True
        Me.InSideBarContextMenu.Name = "InSideBarContextMenu"
        Me.InSideBarContextMenu.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.InSideBarHideContextItem})
        Me.InSideBarContextMenu.Text = "InSideBar"
        '
        'InSideBarHideContextItem
        '
        Me.InSideBarHideContextItem.Name = "InSideBarHideContextItem"
        Me.InSideBarHideContextItem.Text = "Hide SideBar"
        '
        'InHeaderContextMenu
        '
        Me.InHeaderContextMenu.AutoExpandOnClick = True
        Me.InHeaderContextMenu.Name = "InHeaderContextMenu"
        Me.InHeaderContextMenu.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.InHeaderShowSideBarContextItem, Me.InHeaderHideSideBarContextItem, Me.labelItem2, Me.InHeaderCalColorBlue, Me.InHeaderCalColorGreen, Me.InHeaderCalColorMaroon, Me.InHeaderCalColorSteel, Me.InHeaderCalColorTeal, Me.InHeaderCalColorPurple, Me.InHeaderCalColorOlive, Me.InHeaderCalColorRed, Me.InHeaderCalColorDarkPeach, Me.InHeaderCalColorDarkSteel, Me.InHeaderCalColorDarkGreen, Me.InHeaderCalColorYellow, Me.InHeaderCalColorAutomatic})
        Me.InHeaderContextMenu.Text = "InHeader"
        '
        'InHeaderShowSideBarContextItem
        '
        Me.InHeaderShowSideBarContextItem.Name = "InHeaderShowSideBarContextItem"
        Me.InHeaderShowSideBarContextItem.Text = "Show SideBar"
        '
        'InHeaderHideSideBarContextItem
        '
        Me.InHeaderHideSideBarContextItem.Name = "InHeaderHideSideBarContextItem"
        Me.InHeaderHideSideBarContextItem.Text = "Hide SideBar"
        '
        'labelItem2
        '
        Me.labelItem2.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.labelItem2.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.labelItem2.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.labelItem2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.labelItem2.Name = "labelItem2"
        Me.labelItem2.PaddingBottom = 1
        Me.labelItem2.PaddingLeft = 10
        Me.labelItem2.PaddingTop = 1
        Me.labelItem2.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.labelItem2.Text = "Calendar Color"
        '
        'InHeaderCalColorBlue
        '
        Me.InHeaderCalColorBlue.Name = "InHeaderCalColorBlue"
        Me.InHeaderCalColorBlue.Text = "Blue"
        '
        'InHeaderCalColorGreen
        '
        Me.InHeaderCalColorGreen.Name = "InHeaderCalColorGreen"
        Me.InHeaderCalColorGreen.Text = "Green"
        '
        'InHeaderCalColorMaroon
        '
        Me.InHeaderCalColorMaroon.Name = "InHeaderCalColorMaroon"
        Me.InHeaderCalColorMaroon.Text = "Maroon"
        '
        'InHeaderCalColorSteel
        '
        Me.InHeaderCalColorSteel.Name = "InHeaderCalColorSteel"
        Me.InHeaderCalColorSteel.Text = "Steel"
        '
        'InHeaderCalColorTeal
        '
        Me.InHeaderCalColorTeal.Name = "InHeaderCalColorTeal"
        Me.InHeaderCalColorTeal.Text = "Teal"
        '
        'InHeaderCalColorPurple
        '
        Me.InHeaderCalColorPurple.Name = "InHeaderCalColorPurple"
        Me.InHeaderCalColorPurple.Text = "Purple"
        '
        'InHeaderCalColorOlive
        '
        Me.InHeaderCalColorOlive.Name = "InHeaderCalColorOlive"
        Me.InHeaderCalColorOlive.Text = "Olive"
        '
        'InHeaderCalColorRed
        '
        Me.InHeaderCalColorRed.Name = "InHeaderCalColorRed"
        Me.InHeaderCalColorRed.Text = "Red"
        '
        'InHeaderCalColorDarkPeach
        '
        Me.InHeaderCalColorDarkPeach.Name = "InHeaderCalColorDarkPeach"
        Me.InHeaderCalColorDarkPeach.Text = "DarkPeach"
        '
        'InHeaderCalColorDarkSteel
        '
        Me.InHeaderCalColorDarkSteel.Name = "InHeaderCalColorDarkSteel"
        Me.InHeaderCalColorDarkSteel.Text = "DarkSteel"
        '
        'InHeaderCalColorDarkGreen
        '
        Me.InHeaderCalColorDarkGreen.Name = "InHeaderCalColorDarkGreen"
        Me.InHeaderCalColorDarkGreen.Text = "DarkGreen"
        '
        'InHeaderCalColorYellow
        '
        Me.InHeaderCalColorYellow.Name = "InHeaderCalColorYellow"
        Me.InHeaderCalColorYellow.Text = "Yellow"
        '
        'InHeaderCalColorAutomatic
        '
        Me.InHeaderCalColorAutomatic.Name = "InHeaderCalColorAutomatic"
        Me.InHeaderCalColorAutomatic.Text = "Automatic"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 5000
        '
        'Schedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 437)
        Me.Controls.Add(Me.contextMenuBar1)
        Me.Controls.Add(Me.calendarView1)
        Me.Controls.Add(Me.dateNavigator1)
        Me.Controls.Add(Me.barView)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Schedule"
        Me.Text = "Schedule"
        CType(Me.barView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.contextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents calendarView1 As DevComponents.DotNetBar.Schedule.CalendarView
    Private WithEvents dateNavigator1 As DevComponents.DotNetBar.Schedule.DateNavigator
    Private WithEvents barView As DevComponents.DotNetBar.Bar
    Private WithEvents btnDay As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnWeek As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnMonth As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnTimeLine As DevComponents.DotNetBar.ButtonItem
    Private WithEvents contextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Private WithEvents InContentContextMenu As DevComponents.DotNetBar.ButtonItem
    Private WithEvents InContentAddAppContextItem As DevComponents.DotNetBar.ButtonItem
    Private WithEvents AppointmentContextMenu As DevComponents.DotNetBar.ButtonItem
    Private WithEvents AppDeleteContextItem As DevComponents.DotNetBar.ButtonItem
    Private WithEvents labelItem3 As DevComponents.DotNetBar.LabelItem
    Private WithEvents labelItem4 As DevComponents.DotNetBar.LabelItem
    Private WithEvents CondensedViewContextMenu As DevComponents.DotNetBar.ButtonItem
    Private WithEvents labelItem8 As DevComponents.DotNetBar.LabelItem
    Private WithEvents btnCondensedViewAll As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnCondensedViewSelected As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnCondensedViewHidden As DevComponents.DotNetBar.ButtonItem
    Private WithEvents InSideBarContextMenu As DevComponents.DotNetBar.ButtonItem
    Private WithEvents InSideBarHideContextItem As DevComponents.DotNetBar.ButtonItem
    Private WithEvents InHeaderContextMenu As DevComponents.DotNetBar.ButtonItem
    Private WithEvents InHeaderShowSideBarContextItem As DevComponents.DotNetBar.ButtonItem
    Private WithEvents InHeaderHideSideBarContextItem As DevComponents.DotNetBar.ButtonItem
    Private WithEvents labelItem2 As DevComponents.DotNetBar.LabelItem
    Private WithEvents InHeaderCalColorBlue As DevComponents.DotNetBar.ButtonItem
    Private WithEvents InHeaderCalColorGreen As DevComponents.DotNetBar.ButtonItem
    Private WithEvents InHeaderCalColorMaroon As DevComponents.DotNetBar.ButtonItem
    Private WithEvents InHeaderCalColorSteel As DevComponents.DotNetBar.ButtonItem
    Private WithEvents InHeaderCalColorTeal As DevComponents.DotNetBar.ButtonItem
    Private WithEvents InHeaderCalColorPurple As DevComponents.DotNetBar.ButtonItem
    Private WithEvents InHeaderCalColorOlive As DevComponents.DotNetBar.ButtonItem
    Private WithEvents InHeaderCalColorRed As DevComponents.DotNetBar.ButtonItem
    Private WithEvents InHeaderCalColorDarkPeach As DevComponents.DotNetBar.ButtonItem
    Private WithEvents InHeaderCalColorDarkSteel As DevComponents.DotNetBar.ButtonItem
    Private WithEvents InHeaderCalColorDarkGreen As DevComponents.DotNetBar.ButtonItem
    Private WithEvents InHeaderCalColorYellow As DevComponents.DotNetBar.ButtonItem
    Private WithEvents InHeaderCalColorAutomatic As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
