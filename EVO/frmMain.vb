Option Strict On
Imports System.Collections
Imports System.ComponentModel
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Rendering
Imports MySql.Data.MySqlClient

''' <summary>
''' Summary description for Form1.
''' </summary>
Public Class frmMain
    Inherits DevComponents.DotNetBar.Office2007RibbonForm
    Private mdiClient1 As MdiClient
    Public WithEvents tabStrip1 As DevComponents.DotNetBar.TabStrip
    Private components As System.ComponentModel.IContainer
    Private bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents labelStatus As DevComponents.DotNetBar.LabelItem
    Private comboItem1 As DevComponents.Editors.ComboItem
    Private comboItem2 As DevComponents.Editors.ComboItem
    Private comboItem3 As DevComponents.Editors.ComboItem
    Private comboItem4 As DevComponents.Editors.ComboItem
    Private comboItem5 As DevComponents.Editors.ComboItem
    Private comboItem6 As DevComponents.Editors.ComboItem
    Private comboItem7 As DevComponents.Editors.ComboItem
    Private comboItem8 As DevComponents.Editors.ComboItem
    Private comboItem9 As DevComponents.Editors.ComboItem
    Private ribbonTabItemGroup1 As DevComponents.DotNetBar.RibbonTabItemGroup
    Private buttonItem47 As DevComponents.DotNetBar.ButtonItem
    Private buttonItem48 As DevComponents.DotNetBar.ButtonItem
    Private buttonItem49 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ribbonControl1 As DevComponents.DotNetBar.RibbonControl
    Friend WithEvents RibbonPanel2 As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents Office2007StartButton1 As DevComponents.DotNetBar.Office2007StartButton
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ItemContainer2 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ItemContainer3 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer4 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ButtonItem18 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonTabItem5 As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents labelItem8 As DevComponents.DotNetBar.LabelItem
    Private WithEvents qatCustomizeItem1 As DevComponents.DotNetBar.QatCustomizeItem
    Private WithEvents buttonUndo As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonSave As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonNew As DevComponents.DotNetBar.ButtonItem
    Private WithEvents RibbonTabItem2 As DevComponents.DotNetBar.RibbonTabItem
    Private WithEvents switchButtonItem1 As DevComponents.DotNetBar.SwitchButtonItem
    Private WithEvents buttonChangeStyle As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonStyleOffice2010Blue As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonStyleOffice2010Silver As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonStyleOffice2010Black As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonStyleVS2010 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonItem62 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonStyleOffice2007Blue As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonStyleOffice2007Black As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonStyleOffice2007Silver As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonItem60 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonStyleCustom As DevComponents.DotNetBar.ColorPickerDropDown
    Private WithEvents ribbonTabItem3 As DevComponents.DotNetBar.RibbonTabItem
    Private WithEvents ribbonTabItem1 As DevComponents.DotNetBar.RibbonTabItem
    Private WithEvents buttonFile As DevComponents.DotNetBar.Office2007StartButton
    Private WithEvents menuFileContainer As DevComponents.DotNetBar.ItemContainer
    Private WithEvents menuFileTwoColumnContainer As DevComponents.DotNetBar.ItemContainer
    Private WithEvents menuFileItems As DevComponents.DotNetBar.ItemContainer
    Private WithEvents buttonItem20 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonItem21 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonFileSaveAs As DevComponents.DotNetBar.ButtonItem
    Private WithEvents itemContainer12 As DevComponents.DotNetBar.ItemContainer
    Private WithEvents labelItem1 As DevComponents.DotNetBar.LabelItem
    Private WithEvents buttonItem56 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonItem57 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonItem58 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonItem59 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonItem23 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonItem24 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonItem25 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents menuFileMRU As DevComponents.DotNetBar.ItemContainer
    Private WithEvents buttonItem26 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonItem27 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonItem28 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonItem29 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents menuFileBottomContainer As DevComponents.DotNetBar.ItemContainer
    Private WithEvents buttonOptions As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonExit As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonPanel3 As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents RibbonPanel4 As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents RibbonTabItem6 As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents RibbonTabItemGroup2 As DevComponents.DotNetBar.RibbonTabItemGroup
    Public WithEvents Tools As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents RibbonTabItemGroup3 As DevComponents.DotNetBar.RibbonTabItemGroup
    Friend WithEvents RibbonPanel5 As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents RibbonPanel1 As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents RibbonTabItem8 As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents RibbonTabItem4 As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents RibbonBar1 As DevComponents.DotNetBar.RibbonBar
    Private WithEvents itemContainer5 As DevComponents.DotNetBar.ItemContainer
    Private WithEvents buttonAddHour As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonRemoveHour As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ItemContainer8 As DevComponents.DotNetBar.ItemContainer
    Private WithEvents ButtonAddHalfHour As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonRemovehalfhour As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ItemContainer6 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents AddminutsTbox As DevComponents.DotNetBar.TextBoxItem
    Private WithEvents AddMinutes As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ItemContainer7 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents AddHoursTbox As DevComponents.DotNetBar.TextBoxItem
    Private WithEvents addHours As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar2 As DevComponents.DotNetBar.RibbonBar
    Private WithEvents buttonItem54 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonItem53 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonPaste As DevComponents.DotNetBar.ButtonItem
    Private WithEvents buttonMargins As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem19 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents RibbonBar3 As DevComponents.DotNetBar.RibbonBar
    Private WithEvents ButtonItem22 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem30 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar4 As DevComponents.DotNetBar.RibbonBar
    Private WithEvents ButtonItem31 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem32 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents RibbonBar5 As DevComponents.DotNetBar.RibbonBar
    Public WithEvents StartTimeRibbon As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ItemContainer10 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ItemContainer14 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ButtonItem36 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem37 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer11 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ItemContainer15 As DevComponents.DotNetBar.ItemContainer
    Public WithEvents ButtonItem39 As DevComponents.DotNetBar.ButtonItem
    Public WithEvents ButtonItem40 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Private WithEvents ButtonItem34 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem35 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem41 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents CircularProgressItem1 As DevComponents.DotNetBar.CircularProgressItem
    Friend WithEvents RibbonBar7 As DevComponents.DotNetBar.RibbonBar
    Private WithEvents ButtonItem46 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem50 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem51 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ColorPickerDropDown1 As DevComponents.DotNetBar.ColorPickerDropDown
    Friend WithEvents RibbonBar6 As DevComponents.DotNetBar.RibbonBar
    Private WithEvents ButtonItem43 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem42 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem44 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem45 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar8 As DevComponents.DotNetBar.RibbonBar
    Private WithEvents ButtonItem55 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem61 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem33 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer9 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents STATUSTIMER As System.Windows.Forms.Timer

    Public Sub New()
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()
        On Error Resume Next
        Dim C As DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(26, Byte), Integer)))
        StyleManager.ChangeStyle(DevComponents.DotNetBar.eStyle.VisualStudio2010Blue, Metro.ColorTables.MetroColorGeneratorParameters.BlackClouds.BaseColor)
        ' Me.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2010Blue

    End Sub

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"
    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.tabStrip1 = New DevComponents.DotNetBar.TabStrip()
        Me.bar1 = New DevComponents.DotNetBar.Bar()
        Me.labelStatus = New DevComponents.DotNetBar.LabelItem()
        Me.CircularProgressItem1 = New DevComponents.DotNetBar.CircularProgressItem()
        Me.ribbonTabItemGroup1 = New DevComponents.DotNetBar.RibbonTabItemGroup()
        Me.comboItem1 = New DevComponents.Editors.ComboItem()
        Me.comboItem2 = New DevComponents.Editors.ComboItem()
        Me.comboItem3 = New DevComponents.Editors.ComboItem()
        Me.comboItem4 = New DevComponents.Editors.ComboItem()
        Me.comboItem5 = New DevComponents.Editors.ComboItem()
        Me.comboItem6 = New DevComponents.Editors.ComboItem()
        Me.comboItem7 = New DevComponents.Editors.ComboItem()
        Me.comboItem8 = New DevComponents.Editors.ComboItem()
        Me.comboItem9 = New DevComponents.Editors.ComboItem()
        Me.ribbonControl1 = New DevComponents.DotNetBar.RibbonControl()
        Me.RibbonPanel4 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar4 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem31 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem32 = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar3 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem22 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem30 = New DevComponents.DotNetBar.ButtonItem()
        Me.StartTimeRibbon = New DevComponents.DotNetBar.RibbonBar()
        Me.ItemContainer10 = New DevComponents.DotNetBar.ItemContainer()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.ItemContainer15 = New DevComponents.DotNetBar.ItemContainer()
        Me.ButtonItem39 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem40 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.ItemContainer14 = New DevComponents.DotNetBar.ItemContainer()
        Me.ButtonItem36 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem37 = New DevComponents.DotNetBar.ButtonItem()
        Me.ItemContainer11 = New DevComponents.DotNetBar.ItemContainer()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.RibbonBar1 = New DevComponents.DotNetBar.RibbonBar()
        Me.itemContainer5 = New DevComponents.DotNetBar.ItemContainer()
        Me.buttonAddHour = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonRemoveHour = New DevComponents.DotNetBar.ButtonItem()
        Me.ItemContainer8 = New DevComponents.DotNetBar.ItemContainer()
        Me.ButtonAddHalfHour = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonRemovehalfhour = New DevComponents.DotNetBar.ButtonItem()
        Me.ItemContainer6 = New DevComponents.DotNetBar.ItemContainer()
        Me.AddminutsTbox = New DevComponents.DotNetBar.TextBoxItem()
        Me.AddMinutes = New DevComponents.DotNetBar.ButtonItem()
        Me.ItemContainer7 = New DevComponents.DotNetBar.ItemContainer()
        Me.AddHoursTbox = New DevComponents.DotNetBar.TextBoxItem()
        Me.addHours = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem19 = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel3 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar6 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem43 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem45 = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel2 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar8 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem55 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem61 = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar7 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem46 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem50 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem51 = New DevComponents.DotNetBar.ButtonItem()
        Me.ColorPickerDropDown1 = New DevComponents.DotNetBar.ColorPickerDropDown()
        Me.RibbonBar5 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem34 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem44 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem35 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem41 = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar2 = New DevComponents.DotNetBar.RibbonBar()
        Me.buttonMargins = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel5 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonPanel1 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonTabItem8 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItem5 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItem6 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItemGroup2 = New DevComponents.DotNetBar.RibbonTabItemGroup()
        Me.Tools = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItemGroup3 = New DevComponents.DotNetBar.RibbonTabItemGroup()
        Me.Office2007StartButton1 = New DevComponents.DotNetBar.Office2007StartButton()
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
        Me.ItemContainer2 = New DevComponents.DotNetBar.ItemContainer()
        Me.ItemContainer3 = New DevComponents.DotNetBar.ItemContainer()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.ItemContainer9 = New DevComponents.DotNetBar.ItemContainer()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.ItemContainer4 = New DevComponents.DotNetBar.ItemContainer()
        Me.ButtonItem18 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem33 = New DevComponents.DotNetBar.ButtonItem()
        Me.qatCustomizeItem1 = New DevComponents.DotNetBar.QatCustomizeItem()
        Me.RibbonTabItem2 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.switchButtonItem1 = New DevComponents.DotNetBar.SwitchButtonItem()
        Me.buttonChangeStyle = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonStyleOffice2010Blue = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonStyleOffice2010Silver = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonStyleOffice2010Black = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonStyleVS2010 = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonItem62 = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonStyleOffice2007Blue = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonStyleOffice2007Black = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonStyleOffice2007Silver = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonItem60 = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonStyleCustom = New DevComponents.DotNetBar.ColorPickerDropDown()
        Me.ribbonTabItem3 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.ribbonTabItem1 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItem4 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.mdiClient1 = New System.Windows.Forms.MdiClient()
        Me.buttonItem47 = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonItem48 = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonItem49 = New DevComponents.DotNetBar.ButtonItem()
        Me.labelItem8 = New DevComponents.DotNetBar.LabelItem()
        Me.buttonUndo = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonSave = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonNew = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonFile = New DevComponents.DotNetBar.Office2007StartButton()
        Me.menuFileContainer = New DevComponents.DotNetBar.ItemContainer()
        Me.menuFileTwoColumnContainer = New DevComponents.DotNetBar.ItemContainer()
        Me.menuFileItems = New DevComponents.DotNetBar.ItemContainer()
        Me.buttonItem20 = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonItem21 = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonFileSaveAs = New DevComponents.DotNetBar.ButtonItem()
        Me.itemContainer12 = New DevComponents.DotNetBar.ItemContainer()
        Me.labelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.buttonItem56 = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonItem57 = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonItem58 = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonItem59 = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonItem23 = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonItem24 = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonItem25 = New DevComponents.DotNetBar.ButtonItem()
        Me.menuFileMRU = New DevComponents.DotNetBar.ItemContainer()
        Me.buttonItem26 = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonItem27 = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonItem28 = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonItem29 = New DevComponents.DotNetBar.ButtonItem()
        Me.menuFileBottomContainer = New DevComponents.DotNetBar.ItemContainer()
        Me.buttonOptions = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonExit = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonItem54 = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonItem53 = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonPaste = New DevComponents.DotNetBar.ButtonItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ButtonItem42 = New DevComponents.DotNetBar.ButtonItem()
        Me.STATUSTIMER = New System.Windows.Forms.Timer(Me.components)
        CType(Me.bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ribbonControl1.SuspendLayout()
        Me.RibbonPanel4.SuspendLayout()
        Me.RibbonPanel3.SuspendLayout()
        Me.RibbonPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabStrip1
        '
        Me.tabStrip1.AntiAlias = True
        Me.tabStrip1.AutoHideSystemBox = True
        Me.tabStrip1.AutoSelectAttachedControl = True
        Me.tabStrip1.CanReorderTabs = True
        Me.tabStrip1.CloseButtonOnTabsVisible = True
        Me.tabStrip1.CloseButtonVisible = True
        Me.tabStrip1.Dock = System.Windows.Forms.DockStyle.Top
        Me.tabStrip1.ForeColor = System.Drawing.Color.Black
        Me.tabStrip1.Location = New System.Drawing.Point(5, 164)
        Me.tabStrip1.MdiForm = Me
        Me.tabStrip1.MdiTabbedDocuments = True
        Me.tabStrip1.Name = "tabStrip1"
        Me.tabStrip1.SelectedTab = Nothing
        Me.tabStrip1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabStrip1.Size = New System.Drawing.Size(1140, 26)
        Me.tabStrip1.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document
        Me.tabStrip1.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Top
        Me.tabStrip1.TabCloseButtonHot = Global.EVO.My.Resources.Resources.x_cross_delete_stop_16
        Me.tabStrip1.TabCloseButtonNormal = Global.EVO.My.Resources.Resources.x_cross_delete_stop_16
        Me.tabStrip1.TabIndex = 6
        Me.tabStrip1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.tabStrip1.Text = "tabStrip1"
        Me.tabStrip1.ThemeAware = True
        '
        'bar1
        '
        Me.bar1.AccessibleDescription = "DotNetBar Bar (bar1)"
        Me.bar1.AccessibleName = "DotNetBar Bar"
        Me.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar
        Me.bar1.AntiAlias = True
        Me.bar1.BackColor = System.Drawing.Color.White
        Me.bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.bar1.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.ResizeHandle
        Me.bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.labelStatus, Me.CircularProgressItem1})
        Me.bar1.ItemSpacing = 2
        Me.bar1.Location = New System.Drawing.Point(5, 471)
        Me.bar1.Name = "bar1"
        Me.bar1.Size = New System.Drawing.Size(1140, 27)
        Me.bar1.Stretch = True
        Me.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.bar1.TabIndex = 7
        Me.bar1.TabStop = False
        Me.bar1.Text = "barStatus"
        '
        'labelStatus
        '
        Me.labelStatus.BackColor = System.Drawing.Color.White
        Me.labelStatus.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelStatus.ForeColor = System.Drawing.Color.OrangeRed
        Me.labelStatus.Name = "labelStatus"
        Me.labelStatus.PaddingLeft = 2
        Me.labelStatus.PaddingRight = 2
        Me.labelStatus.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.labelStatus.Stretch = True
        Me.labelStatus.Text = "READY"
        '
        'CircularProgressItem1
        '
        Me.CircularProgressItem1.Name = "CircularProgressItem1"
        Me.CircularProgressItem1.PieBorderDark = System.Drawing.Color.AliceBlue
        Me.CircularProgressItem1.PieBorderLight = System.Drawing.Color.AliceBlue
        Me.CircularProgressItem1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.CircularProgressItem1.ProgressColor = System.Drawing.Color.RoyalBlue
        Me.CircularProgressItem1.Visible = False
        '
        'ribbonTabItemGroup1
        '
        Me.ribbonTabItemGroup1.Color = DevComponents.DotNetBar.eRibbonTabGroupColor.Orange
        Me.ribbonTabItemGroup1.GroupTitle = "«·«”«”ÌÂ"
        Me.ribbonTabItemGroup1.Name = "ribbonTabItemGroup1"
        '
        '
        '
        Me.ribbonTabItemGroup1.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.ribbonTabItemGroup1.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ribbonTabItemGroup1.Style.BackColorGradientAngle = 90
        Me.ribbonTabItemGroup1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ribbonTabItemGroup1.Style.BorderBottomWidth = 1
        Me.ribbonTabItemGroup1.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(154, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ribbonTabItemGroup1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ribbonTabItemGroup1.Style.BorderLeftWidth = 1
        Me.ribbonTabItemGroup1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ribbonTabItemGroup1.Style.BorderRightWidth = 1
        Me.ribbonTabItemGroup1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ribbonTabItemGroup1.Style.BorderTopWidth = 1
        Me.ribbonTabItemGroup1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ribbonTabItemGroup1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ribbonTabItemGroup1.Style.TextColor = System.Drawing.Color.Black
        Me.ribbonTabItemGroup1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        'comboItem1
        '
        Me.comboItem1.Text = "6"
        '
        'comboItem2
        '
        Me.comboItem2.Text = "7"
        '
        'comboItem3
        '
        Me.comboItem3.Text = "8"
        '
        'comboItem4
        '
        Me.comboItem4.Text = "9"
        '
        'comboItem5
        '
        Me.comboItem5.Text = "10"
        '
        'comboItem6
        '
        Me.comboItem6.Text = "11"
        '
        'comboItem7
        '
        Me.comboItem7.Text = "12"
        '
        'comboItem8
        '
        Me.comboItem8.Text = "13"
        '
        'comboItem9
        '
        Me.comboItem9.Text = "14"
        '
        'ribbonControl1
        '
        Me.ribbonControl1.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.ribbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ribbonControl1.CaptionVisible = True
        Me.ribbonControl1.Controls.Add(Me.RibbonPanel2)
        Me.ribbonControl1.Controls.Add(Me.RibbonPanel3)
        Me.ribbonControl1.Controls.Add(Me.RibbonPanel4)
        Me.ribbonControl1.Controls.Add(Me.RibbonPanel5)
        Me.ribbonControl1.Controls.Add(Me.RibbonPanel1)
        Me.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ribbonControl1.Expanded = False
        Me.ribbonControl1.Font = New System.Drawing.Font("justagain DIN", 8.749999!)
        Me.ribbonControl1.ForeColor = System.Drawing.Color.Black
        Me.ribbonControl1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.RibbonTabItem8, Me.RibbonTabItem5, Me.RibbonTabItem6, Me.Tools})
        Me.ribbonControl1.KeyTipsFont = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ribbonControl1.Location = New System.Drawing.Point(5, 1)
        Me.ribbonControl1.MdiSystemItemVisible = False
        Me.ribbonControl1.Name = "ribbonControl1"
        Me.ribbonControl1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.ribbonControl1.QuickToolbarItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Office2007StartButton1, Me.ButtonItem1})
        Me.ribbonControl1.Size = New System.Drawing.Size(1140, 163)
        Me.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ribbonControl1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
        Me.ribbonControl1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
        Me.ribbonControl1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
        Me.ribbonControl1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
        Me.ribbonControl1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
        Me.ribbonControl1.SystemText.QatDialogAddButton = "&Add >>"
        Me.ribbonControl1.SystemText.QatDialogCancelButton = "Cancel"
        Me.ribbonControl1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
        Me.ribbonControl1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
        Me.ribbonControl1.SystemText.QatDialogOkButton = "OK"
        Me.ribbonControl1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
        Me.ribbonControl1.SystemText.QatDialogRemoveButton = "&Remove"
        Me.ribbonControl1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
        Me.ribbonControl1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
        Me.ribbonControl1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
        Me.ribbonControl1.TabGroupHeight = 14
        Me.ribbonControl1.TabGroups.AddRange(New DevComponents.DotNetBar.RibbonTabItemGroup() {Me.ribbonTabItemGroup1, Me.RibbonTabItemGroup2, Me.RibbonTabItemGroup3})
        Me.ribbonControl1.TabGroupsVisible = True
        Me.ribbonControl1.TabIndex = 8
        Me.ribbonControl1.Text = "oo"
        '
        'RibbonPanel4
        '
        Me.RibbonPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel4.Controls.Add(Me.RibbonBar4)
        Me.RibbonPanel4.Controls.Add(Me.RibbonBar3)
        Me.RibbonPanel4.Controls.Add(Me.StartTimeRibbon)
        Me.RibbonPanel4.Controls.Add(Me.RibbonBar1)
        Me.RibbonPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel4.Location = New System.Drawing.Point(0, 60)
        Me.RibbonPanel4.Name = "RibbonPanel4"
        Me.RibbonPanel4.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel4.Size = New System.Drawing.Size(1140, 101)
        '
        '
        '
        Me.RibbonPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel4.TabIndex = 4
        Me.RibbonPanel4.Visible = False
        '
        'RibbonBar4
        '
        Me.RibbonBar4.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar4.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar4.ContainerControlProcessDialogKey = True
        Me.RibbonBar4.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar4.Enabled = False
        Me.RibbonBar4.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem31, Me.ButtonItem32})
        Me.RibbonBar4.Location = New System.Drawing.Point(915, 0)
        Me.RibbonBar4.Name = "RibbonBar4"
        Me.RibbonBar4.Size = New System.Drawing.Size(269, 98)
        Me.RibbonBar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar4.TabIndex = 2
        Me.RibbonBar4.Text = " Õﬂ„ «·ÃÂ«“"
        '
        '
        '
        Me.RibbonBar4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar4.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ButtonItem31
        '
        Me.ButtonItem31.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonItem31.FixedSize = New System.Drawing.Size(340, 0)
        Me.ButtonItem31.Image = CType(resources.GetObject("ButtonItem31.Image"), System.Drawing.Image)
        Me.ButtonItem31.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.ButtonItem31.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem31.Name = "ButtonItem31"
        Me.ButtonItem31.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2)
        Me.ButtonItem31.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl5)
        Me.ButtonItem31.Text = "«⁄œ«œ« _«·ÃÂ«“"
        '
        'ButtonItem32
        '
        Me.ButtonItem32.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonItem32.FixedSize = New System.Drawing.Size(340, 0)
        Me.ButtonItem32.Image = CType(resources.GetObject("ButtonItem32.Image"), System.Drawing.Image)
        Me.ButtonItem32.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.ButtonItem32.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem32.ImageSmall = Global.EVO.My.Resources.Resources.desktop_monitor_screen_64
        Me.ButtonItem32.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.ButtonItem32.Name = "ButtonItem32"
        Me.ButtonItem32.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2)
        Me.ButtonItem32.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl1)
        Me.ButtonItem32.Text = "”Ã·_«·ÃÂ«“"
        '
        'RibbonBar3
        '
        Me.RibbonBar3.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar3.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar3.ContainerControlProcessDialogKey = True
        Me.RibbonBar3.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar3.Enabled = False
        Me.RibbonBar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem22, Me.ButtonItem30})
        Me.RibbonBar3.ItemSpacing = 3
        Me.RibbonBar3.Location = New System.Drawing.Point(704, 0)
        Me.RibbonBar3.Name = "RibbonBar3"
        Me.RibbonBar3.Size = New System.Drawing.Size(211, 98)
        Me.RibbonBar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar3.TabIndex = 1
        Me.RibbonBar3.Text = " Õﬂ„ «·«ÃÂ“Â"
        '
        '
        '
        Me.RibbonBar3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar3.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ButtonItem22
        '
        Me.ButtonItem22.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonItem22.Image = CType(resources.GetObject("ButtonItem22.Image"), System.Drawing.Image)
        Me.ButtonItem22.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.ButtonItem22.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem22.Name = "ButtonItem22"
        Me.ButtonItem22.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2)
        Me.ButtonItem22.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlF4)
        Me.ButtonItem22.Text = " €ÌÌ—_«·ÃÂ«“"
        '
        'ButtonItem30
        '
        Me.ButtonItem30.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonItem30.Image = CType(resources.GetObject("ButtonItem30.Image"), System.Drawing.Image)
        Me.ButtonItem30.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem30.Name = "ButtonItem30"
        Me.ButtonItem30.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2)
        Me.ButtonItem30.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5)
        Me.ButtonItem30.Text = " ÕœÌÀ_«·«ÃÂ“Â"
        '
        'StartTimeRibbon
        '
        Me.StartTimeRibbon.AutoOverflowEnabled = True
        '
        '
        '
        Me.StartTimeRibbon.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.StartTimeRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.StartTimeRibbon.ContainerControlProcessDialogKey = True
        Me.StartTimeRibbon.Dock = System.Windows.Forms.DockStyle.Left
        Me.StartTimeRibbon.Enabled = False
        Me.StartTimeRibbon.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer10, Me.ItemContainer11})
        Me.StartTimeRibbon.Location = New System.Drawing.Point(535, 0)
        Me.StartTimeRibbon.MinimumSize = New System.Drawing.Size(169, 0)
        Me.StartTimeRibbon.Name = "StartTimeRibbon"
        Me.StartTimeRibbon.Size = New System.Drawing.Size(169, 98)
        Me.StartTimeRibbon.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.StartTimeRibbon.TabIndex = 3
        Me.StartTimeRibbon.Text = "«⁄œ«œ«  «·Êﬁ "
        '
        '
        '
        Me.StartTimeRibbon.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.StartTimeRibbon.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ItemContainer10
        '
        '
        '
        '
        Me.ItemContainer10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer10.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer10.Name = "ItemContainer10"
        Me.ItemContainer10.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.ItemContainer15, Me.ItemContainer14})
        '
        'LabelItem2
        '
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.SingleLineColor = System.Drawing.Color.White
        Me.LabelItem2.Text = "Êﬁ  «·»œ¡"
        '
        'ItemContainer15
        '
        '
        '
        '
        Me.ItemContainer15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer15.Name = "ItemContainer15"
        Me.ItemContainer15.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem39, Me.ButtonItem40, Me.LabelItem3})
        '
        'ButtonItem39
        '
        Me.ButtonItem39.AutoCollapseOnClick = False
        Me.ButtonItem39.Checked = True
        Me.ButtonItem39.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
        Me.ButtonItem39.Name = "ButtonItem39"
        Me.ButtonItem39.Text = "00"
        '
        'ButtonItem40
        '
        Me.ButtonItem40.AutoCollapseOnClick = False
        Me.ButtonItem40.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
        Me.ButtonItem40.Name = "ButtonItem40"
        Me.ButtonItem40.Text = "00"
        '
        'LabelItem3
        '
        Me.LabelItem3.AutoCollapseOnClick = False
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.Text = "AM"
        '
        'ItemContainer14
        '
        '
        '
        '
        Me.ItemContainer14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer14.Name = "ItemContainer14"
        Me.ItemContainer14.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem36, Me.ButtonItem37})
        '
        'ButtonItem36
        '
        Me.ButtonItem36.AutoCollapseOnClick = False
        Me.ButtonItem36.Image = Global.EVO.My.Resources.Resources.arrow_down_16
        Me.ButtonItem36.Name = "ButtonItem36"
        Me.ButtonItem36.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.ShiftF2)
        '
        'ButtonItem37
        '
        Me.ButtonItem37.AutoCollapseOnClick = False
        Me.ButtonItem37.ClickAutoRepeat = True
        Me.ButtonItem37.HotForeColor = System.Drawing.Color.White
        Me.ButtonItem37.Image = Global.EVO.My.Resources.Resources.arrow_up_16
        Me.ButtonItem37.Name = "ButtonItem37"
        Me.ButtonItem37.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.ShiftF1)
        '
        'ItemContainer11
        '
        '
        '
        '
        Me.ItemContainer11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer11.ItemSpacing = 3
        Me.ItemContainer11.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer11.Name = "ItemContainer11"
        Me.ItemContainer11.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem4, Me.LabelItem5})
        '
        'LabelItem4
        '
        Me.LabelItem4.Name = "LabelItem4"
        Me.LabelItem4.SingleLineColor = System.Drawing.Color.White
        Me.LabelItem4.Text = "«·„œÂ"
        '
        'LabelItem5
        '
        Me.LabelItem5.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelItem5.Name = "LabelItem5"
        Me.LabelItem5.SingleLineColor = System.Drawing.Color.White
        Me.LabelItem5.Text = "0H:0M"
        '
        'RibbonBar1
        '
        Me.RibbonBar1.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar1.ContainerControlProcessDialogKey = True
        Me.RibbonBar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar1.Enabled = False
        Me.RibbonBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.itemContainer5, Me.ItemContainer8, Me.ItemContainer6, Me.ItemContainer7, Me.ButtonItem19})
        Me.RibbonBar1.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar1.Name = "RibbonBar1"
        Me.RibbonBar1.Size = New System.Drawing.Size(532, 98)
        Me.RibbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar1.TabIndex = 0
        Me.RibbonBar1.Text = " ⁄œÌ· «·Êﬁ "
        '
        '
        '
        Me.RibbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'itemContainer5
        '
        '
        '
        '
        Me.itemContainer5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.itemContainer5.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.itemContainer5.Name = "itemContainer5"
        Me.itemContainer5.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.buttonAddHour, Me.buttonRemoveHour})
        '
        'buttonAddHour
        '
        Me.buttonAddHour.AutoCollapseOnClick = False
        Me.buttonAddHour.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.buttonAddHour.Image = Global.EVO.My.Resources.Resources._678092_sign_add_16
        Me.buttonAddHour.Name = "buttonAddHour"
        Me.buttonAddHour.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlF1)
        Me.buttonAddHour.Text = "«÷«›Â 60 œﬁÌﬁÂ"
        '
        'buttonRemoveHour
        '
        Me.buttonRemoveHour.AutoCollapseOnClick = False
        Me.buttonRemoveHour.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.buttonRemoveHour.Image = Global.EVO.My.Resources.Resources.x_cross_delete_stop_16
        Me.buttonRemoveHour.Name = "buttonRemoveHour"
        Me.buttonRemoveHour.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlF2)
        Me.buttonRemoveHour.Text = "Remove Hour"
        Me.buttonRemoveHour.Visible = False
        '
        'ItemContainer8
        '
        '
        '
        '
        Me.ItemContainer8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer8.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer8.Name = "ItemContainer8"
        Me.ItemContainer8.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonAddHalfHour, Me.ButtonRemovehalfhour})
        '
        'ButtonAddHalfHour
        '
        Me.ButtonAddHalfHour.AutoCollapseOnClick = False
        Me.ButtonAddHalfHour.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonAddHalfHour.Image = Global.EVO.My.Resources.Resources._678092_sign_add_16
        Me.ButtonAddHalfHour.Name = "ButtonAddHalfHour"
        Me.ButtonAddHalfHour.Text = "«÷«›Â 30 œﬁÌﬁÂ"
        '
        'ButtonRemovehalfhour
        '
        Me.ButtonRemovehalfhour.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonRemovehalfhour.Image = Global.EVO.My.Resources.Resources.x_cross_delete_stop_16
        Me.ButtonRemovehalfhour.Name = "ButtonRemovehalfhour"
        Me.ButtonRemovehalfhour.Text = "Remove 1/2 Hour"
        Me.ButtonRemovehalfhour.Visible = False
        '
        'ItemContainer6
        '
        '
        '
        '
        Me.ItemContainer6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer6.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer6.Name = "ItemContainer6"
        Me.ItemContainer6.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.AddminutsTbox, Me.AddMinutes})
        '
        'AddminutsTbox
        '
        Me.AddminutsTbox.Name = "AddminutsTbox"
        Me.AddminutsTbox.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'AddMinutes
        '
        Me.AddMinutes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.AddMinutes.Image = Global.EVO.My.Resources.Resources._678092_sign_add_16
        Me.AddMinutes.Name = "AddMinutes"
        Me.AddMinutes.Text = "«÷› »«·œﬁÌﬁÂ"
        '
        'ItemContainer7
        '
        '
        '
        '
        Me.ItemContainer7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer7.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer7.Name = "ItemContainer7"
        Me.ItemContainer7.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.AddHoursTbox, Me.addHours})
        '
        'AddHoursTbox
        '
        Me.AddHoursTbox.Name = "AddHoursTbox"
        Me.AddHoursTbox.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'addHours
        '
        Me.addHours.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.addHours.Image = Global.EVO.My.Resources.Resources._678092_sign_add_16
        Me.addHours.Name = "addHours"
        Me.addHours.Text = "«÷› »«·”«⁄Â"
        '
        'ButtonItem19
        '
        Me.ButtonItem19.AutoCollapseOnClick = False
        Me.ButtonItem19.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonItem19.Image = CType(resources.GetObject("ButtonItem19.Image"), System.Drawing.Image)
        Me.ButtonItem19.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem19.Name = "ButtonItem19"
        Me.ButtonItem19.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2)
        Me.ButtonItem19.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlF3)
        Me.ButtonItem19.Text = "Êﬁ _„› ÊÕ"
        '
        'RibbonPanel3
        '
        Me.RibbonPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel3.Controls.Add(Me.RibbonBar6)
        Me.RibbonPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel3.Location = New System.Drawing.Point(0, 60)
        Me.RibbonPanel3.Name = "RibbonPanel3"
        Me.RibbonPanel3.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel3.Size = New System.Drawing.Size(1140, 101)
        '
        '
        '
        Me.RibbonPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel3.TabIndex = 3
        Me.RibbonPanel3.Visible = False
        '
        'RibbonBar6
        '
        Me.RibbonBar6.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar6.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar6.ContainerControlProcessDialogKey = True
        Me.RibbonBar6.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar6.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem43, Me.ButtonItem45})
        Me.RibbonBar6.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar6.Name = "RibbonBar6"
        Me.RibbonBar6.Size = New System.Drawing.Size(303, 98)
        Me.RibbonBar6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar6.TabIndex = 0
        Me.RibbonBar6.Text = "«·”Ã· Ê «·ÕÃ“"
        '
        '
        '
        Me.RibbonBar6.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar6.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ButtonItem43
        '
        Me.ButtonItem43.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonItem43.Enabled = False
        Me.ButtonItem43.FixedSize = New System.Drawing.Size(140, 0)
        Me.ButtonItem43.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem43.Image = CType(resources.GetObject("ButtonItem43.Image"), System.Drawing.Image)
        Me.ButtonItem43.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem43.Name = "ButtonItem43"
        Me.ButtonItem43.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2)
        Me.ButtonItem43.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl6)
        Me.ButtonItem43.Stretch = True
        Me.ButtonItem43.Text = "«·”Ã·« "
        '
        'ButtonItem45
        '
        Me.ButtonItem45.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonItem45.Enabled = False
        Me.ButtonItem45.FixedSize = New System.Drawing.Size(140, 0)
        Me.ButtonItem45.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem45.Image = CType(resources.GetObject("ButtonItem45.Image"), System.Drawing.Image)
        Me.ButtonItem45.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem45.Name = "ButtonItem45"
        Me.ButtonItem45.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2)
        Me.ButtonItem45.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl7)
        Me.ButtonItem45.Stretch = True
        Me.ButtonItem45.Text = "«·ÕÃ“"
        '
        'RibbonPanel2
        '
        Me.RibbonPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel2.Controls.Add(Me.RibbonBar8)
        Me.RibbonPanel2.Controls.Add(Me.RibbonBar7)
        Me.RibbonPanel2.Controls.Add(Me.RibbonBar5)
        Me.RibbonPanel2.Controls.Add(Me.RibbonBar2)
        Me.RibbonPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel2.Location = New System.Drawing.Point(0, 60)
        Me.RibbonPanel2.Name = "RibbonPanel2"
        Me.RibbonPanel2.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel2.Size = New System.Drawing.Size(1140, 101)
        '
        '
        '
        Me.RibbonPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel2.TabIndex = 2
        '
        'RibbonBar8
        '
        Me.RibbonBar8.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar8.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar8.ContainerControlProcessDialogKey = True
        Me.RibbonBar8.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar8.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem55, Me.ButtonItem61})
        Me.RibbonBar8.Location = New System.Drawing.Point(917, 0)
        Me.RibbonBar8.Name = "RibbonBar8"
        Me.RibbonBar8.Size = New System.Drawing.Size(175, 98)
        Me.RibbonBar8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar8.TabIndex = 3
        Me.RibbonBar8.Text = "«·Õ”«»"
        '
        '
        '
        Me.RibbonBar8.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar8.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ButtonItem55
        '
        Me.ButtonItem55.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonItem55.FixedSize = New System.Drawing.Size(140, 0)
        Me.ButtonItem55.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem55.Image = CType(resources.GetObject("ButtonItem55.Image"), System.Drawing.Image)
        Me.ButtonItem55.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem55.Name = "ButtonItem55"
        Me.ButtonItem55.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2)
        Me.ButtonItem55.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA)
        Me.ButtonItem55.Text = " ”ÃÌ·_«·œŒÊ·"
        '
        'ButtonItem61
        '
        Me.ButtonItem61.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonItem61.Enabled = False
        Me.ButtonItem61.FixedSize = New System.Drawing.Size(140, 0)
        Me.ButtonItem61.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem61.Image = CType(resources.GetObject("ButtonItem61.Image"), System.Drawing.Image)
        Me.ButtonItem61.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem61.Name = "ButtonItem61"
        Me.ButtonItem61.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2)
        Me.ButtonItem61.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlQ)
        Me.ButtonItem61.Text = " ”ÃÌ·_Œ—ÊÃ"
        '
        'RibbonBar7
        '
        Me.RibbonBar7.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar7.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar7.ContainerControlProcessDialogKey = True
        Me.RibbonBar7.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar7.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem46, Me.ButtonItem51})
        Me.RibbonBar7.Location = New System.Drawing.Point(689, 0)
        Me.RibbonBar7.Name = "RibbonBar7"
        Me.RibbonBar7.Size = New System.Drawing.Size(228, 98)
        Me.RibbonBar7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar7.TabIndex = 2
        Me.RibbonBar7.Text = "«·„ŸÂ—"
        '
        '
        '
        Me.RibbonBar7.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar7.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ButtonItem46
        '
        Me.ButtonItem46.AutoCollapseOnClick = False
        Me.ButtonItem46.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonItem46.FixedSize = New System.Drawing.Size(140, 0)
        Me.ButtonItem46.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem46.Image = CType(resources.GetObject("ButtonItem46.Image"), System.Drawing.Image)
        Me.ButtonItem46.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem46.Name = "ButtonItem46"
        Me.ButtonItem46.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2)
        Me.ButtonItem46.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl5)
        Me.ButtonItem46.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem50})
        Me.ButtonItem46.Text = " €ÌÌ—_«·ÀÌ„"
        '
        'ButtonItem50
        '
        Me.ButtonItem50.Name = "ButtonItem50"
        Me.ButtonItem50.Text = "«·«› —«÷Ì"
        '
        'ButtonItem51
        '
        Me.ButtonItem51.AutoCollapseOnClick = False
        Me.ButtonItem51.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonItem51.FixedSize = New System.Drawing.Size(140, 0)
        Me.ButtonItem51.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem51.Image = CType(resources.GetObject("ButtonItem51.Image"), System.Drawing.Image)
        Me.ButtonItem51.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem51.Name = "ButtonItem51"
        Me.ButtonItem51.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2)
        Me.ButtonItem51.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ColorPickerDropDown1})
        Me.ButtonItem51.Text = " €ÌÌ—_«··Ê‰"
        '
        'ColorPickerDropDown1
        '
        Me.ColorPickerDropDown1.DisplayMoreColors = False
        Me.ColorPickerDropDown1.DisplayStandardColors = False
        Me.ColorPickerDropDown1.Name = "ColorPickerDropDown1"
        Me.ColorPickerDropDown1.PersonalizedMenus = DevComponents.DotNetBar.ePersonalizedMenus.Both
        Me.ColorPickerDropDown1.Stretch = True
        Me.ColorPickerDropDown1.Text = "«··Ê‰"
        '
        'RibbonBar5
        '
        Me.RibbonBar5.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar5.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar5.ContainerControlProcessDialogKey = True
        Me.RibbonBar5.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar5.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem34, Me.ButtonItem44, Me.ButtonItem35, Me.ButtonItem41})
        Me.RibbonBar5.Location = New System.Drawing.Point(181, 0)
        Me.RibbonBar5.Name = "RibbonBar5"
        Me.RibbonBar5.Size = New System.Drawing.Size(508, 98)
        Me.RibbonBar5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar5.TabIndex = 1
        Me.RibbonBar5.Text = "«·’›Õ«  «·—«∆Ì”ÌÂ"
        '
        '
        '
        Me.RibbonBar5.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar5.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ButtonItem34
        '
        Me.ButtonItem34.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonItem34.Enabled = False
        Me.ButtonItem34.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem34.Image = CType(resources.GetObject("ButtonItem34.Image"), System.Drawing.Image)
        Me.ButtonItem34.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem34.Name = "ButtonItem34"
        Me.ButtonItem34.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2)
        Me.ButtonItem34.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl2)
        Me.ButtonItem34.Text = "√⁄œ«œ« _«·«ÃÂ“Â"
        '
        'ButtonItem44
        '
        Me.ButtonItem44.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonItem44.Enabled = False
        Me.ButtonItem44.FixedSize = New System.Drawing.Size(140, 0)
        Me.ButtonItem44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem44.Image = CType(resources.GetObject("ButtonItem44.Image"), System.Drawing.Image)
        Me.ButtonItem44.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.ButtonItem44.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem44.Name = "ButtonItem44"
        Me.ButtonItem44.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2)
        Me.ButtonItem44.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl3)
        Me.ButtonItem44.Text = "«‰Ê«⁄_«·«ÃÂ“Â"
        '
        'ButtonItem35
        '
        Me.ButtonItem35.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonItem35.Enabled = False
        Me.ButtonItem35.FixedSize = New System.Drawing.Size(140, 0)
        Me.ButtonItem35.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem35.Image = CType(resources.GetObject("ButtonItem35.Image"), System.Drawing.Image)
        Me.ButtonItem35.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem35.Name = "ButtonItem35"
        Me.ButtonItem35.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2)
        Me.ButtonItem35.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl4)
        Me.ButtonItem35.Text = "«‰Ê«⁄_«·ÿ·»« "
        '
        'ButtonItem41
        '
        Me.ButtonItem41.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonItem41.Enabled = False
        Me.ButtonItem41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem41.Image = CType(resources.GetObject("ButtonItem41.Image"), System.Drawing.Image)
        Me.ButtonItem41.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem41.Name = "ButtonItem41"
        Me.ButtonItem41.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2)
        Me.ButtonItem41.SubItemsExpandWidth = 100
        Me.ButtonItem41.Text = "«⁄œ«œ« _«·»—‰«„Ã"
        '
        'RibbonBar2
        '
        Me.RibbonBar2.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar2.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar2.ContainerControlProcessDialogKey = True
        Me.RibbonBar2.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.buttonMargins})
        Me.RibbonBar2.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar2.Name = "RibbonBar2"
        Me.RibbonBar2.Size = New System.Drawing.Size(178, 98)
        Me.RibbonBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar2.TabIndex = 0
        Me.RibbonBar2.Text = "«·«”«”Ì"
        '
        '
        '
        Me.RibbonBar2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar2.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'buttonMargins
        '
        Me.buttonMargins.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.buttonMargins.Enabled = False
        Me.buttonMargins.FixedSize = New System.Drawing.Size(140, 0)
        Me.buttonMargins.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.buttonMargins.Image = CType(resources.GetObject("buttonMargins.Image"), System.Drawing.Image)
        Me.buttonMargins.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.buttonMargins.Name = "buttonMargins"
        Me.buttonMargins.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2)
        Me.buttonMargins.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl1)
        Me.buttonMargins.Text = "<font color=""#7F7F7F""><font color=""#388194""><font color=""#262626"">«·ﬁ«∆Â_«·—∆Ì”ÌÂ" & _
            "</font></font></font>"
        '
        'RibbonPanel5
        '
        Me.RibbonPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel5.Location = New System.Drawing.Point(0, 54)
        Me.RibbonPanel5.Name = "RibbonPanel5"
        Me.RibbonPanel5.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel5.Size = New System.Drawing.Size(1140, 80)
        '
        '
        '
        Me.RibbonPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel5.TabIndex = 5
        Me.RibbonPanel5.Visible = False
        '
        'RibbonPanel1
        '
        Me.RibbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonPanel1.Name = "RibbonPanel1"
        Me.RibbonPanel1.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel1.Size = New System.Drawing.Size(1140, 161)
        '
        '
        '
        Me.RibbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel1.TabIndex = 1
        '
        'RibbonTabItem8
        '
        Me.RibbonTabItem8.Name = "RibbonTabItem8"
        Me.RibbonTabItem8.Panel = Me.RibbonPanel5
        Me.RibbonTabItem8.SplitButton = True
        Me.RibbonTabItem8.Tag = "                          "
        Me.RibbonTabItem8.Text = "                    ."
        '
        'RibbonTabItem5
        '
        Me.RibbonTabItem5.Checked = True
        Me.RibbonTabItem5.ColorTable = DevComponents.DotNetBar.eRibbonTabColor.Orange
        Me.RibbonTabItem5.FontBold = True
        Me.RibbonTabItem5.Group = Me.ribbonTabItemGroup1
        Me.RibbonTabItem5.Name = "RibbonTabItem5"
        Me.RibbonTabItem5.Panel = Me.RibbonPanel2
        Me.RibbonTabItem5.Text = "«·ﬁ«∆„Â «·«”«”ÌÂ"
        '
        'RibbonTabItem6
        '
        Me.RibbonTabItem6.ColorTable = DevComponents.DotNetBar.eRibbonTabColor.Orange
        Me.RibbonTabItem6.FontBold = True
        Me.RibbonTabItem6.Group = Me.RibbonTabItemGroup2
        Me.RibbonTabItem6.Name = "RibbonTabItem6"
        Me.RibbonTabItem6.Panel = Me.RibbonPanel3
        Me.RibbonTabItem6.Text = "«·”Ã·"
        '
        'RibbonTabItemGroup2
        '
        Me.RibbonTabItemGroup2.Color = DevComponents.DotNetBar.eRibbonTabGroupColor.Orange
        Me.RibbonTabItemGroup2.GroupTitle = "«·”Ã·"
        Me.RibbonTabItemGroup2.Name = "RibbonTabItemGroup2"
        '
        '
        '
        Me.RibbonTabItemGroup2.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.RibbonTabItemGroup2.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(144, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.RibbonTabItemGroup2.Style.BackColorGradientAngle = 90
        Me.RibbonTabItemGroup2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.RibbonTabItemGroup2.Style.BorderBottomWidth = 1
        Me.RibbonTabItemGroup2.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(154, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.RibbonTabItemGroup2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.RibbonTabItemGroup2.Style.BorderLeftWidth = 1
        Me.RibbonTabItemGroup2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.RibbonTabItemGroup2.Style.BorderRightWidth = 1
        Me.RibbonTabItemGroup2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.RibbonTabItemGroup2.Style.BorderTopWidth = 1
        Me.RibbonTabItemGroup2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonTabItemGroup2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.RibbonTabItemGroup2.Style.TextColor = System.Drawing.Color.White
        Me.RibbonTabItemGroup2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.RibbonTabItemGroup2.Style.TextShadowColor = System.Drawing.Color.Black
        Me.RibbonTabItemGroup2.Style.TextShadowOffset = New System.Drawing.Point(1, 1)
        '
        'Tools
        '
        Me.Tools.ColorTable = DevComponents.DotNetBar.eRibbonTabColor.Orange
        Me.Tools.CustomColorName = "Red"
        Me.Tools.FontBold = True
        Me.Tools.Group = Me.RibbonTabItemGroup3
        Me.Tools.Name = "Tools"
        Me.Tools.Panel = Me.RibbonPanel4
        Me.Tools.Text = "«œÊ«  «·«ÃÂ“Â"
        '
        'RibbonTabItemGroup3
        '
        Me.RibbonTabItemGroup3.Color = DevComponents.DotNetBar.eRibbonTabGroupColor.Orange
        Me.RibbonTabItemGroup3.GroupTitle = "«⁄œ«œ«  «·«ÃÂ“Â"
        Me.RibbonTabItemGroup3.Name = "RibbonTabItemGroup3"
        '
        '
        '
        Me.RibbonTabItemGroup3.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.RibbonTabItemGroup3.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(144, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.RibbonTabItemGroup3.Style.BackColorGradientAngle = 90
        Me.RibbonTabItemGroup3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.RibbonTabItemGroup3.Style.BorderBottomWidth = 1
        Me.RibbonTabItemGroup3.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(154, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.RibbonTabItemGroup3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.RibbonTabItemGroup3.Style.BorderLeftWidth = 1
        Me.RibbonTabItemGroup3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.RibbonTabItemGroup3.Style.BorderRightWidth = 1
        Me.RibbonTabItemGroup3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.RibbonTabItemGroup3.Style.BorderTopWidth = 1
        Me.RibbonTabItemGroup3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonTabItemGroup3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.RibbonTabItemGroup3.Style.TextColor = System.Drawing.Color.White
        Me.RibbonTabItemGroup3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.RibbonTabItemGroup3.Style.TextShadowColor = System.Drawing.Color.Black
        Me.RibbonTabItemGroup3.Style.TextShadowOffset = New System.Drawing.Point(1, 1)
        '
        'Office2007StartButton1
        '
        Me.Office2007StartButton1.AutoExpandOnClick = True
        Me.Office2007StartButton1.CanCustomize = False
        Me.Office2007StartButton1.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image
        Me.Office2007StartButton1.Image = CType(resources.GetObject("Office2007StartButton1.Image"), System.Drawing.Image)
        Me.Office2007StartButton1.ImagePaddingHorizontal = 2
        Me.Office2007StartButton1.ImagePaddingVertical = 2
        Me.Office2007StartButton1.Name = "Office2007StartButton1"
        Me.Office2007StartButton1.ShowSubItems = False
        Me.Office2007StartButton1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1})
        Me.Office2007StartButton1.Text = "EVO"
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.Class = "RibbonFileMenuContainer"
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer1.Name = "ItemContainer1"
        Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer2, Me.ItemContainer4})
        '
        'ItemContainer2
        '
        '
        '
        '
        Me.ItemContainer2.BackgroundStyle.Class = "RibbonFileMenuTwoColumnContainer"
        Me.ItemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer2.ItemSpacing = 0
        Me.ItemContainer2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer2.Name = "ItemContainer2"
        Me.ItemContainer2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer3, Me.ItemContainer9})
        '
        'ItemContainer3
        '
        '
        '
        '
        Me.ItemContainer3.BackgroundStyle.Class = "RibbonFileMenuColumnOneContainer"
        Me.ItemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer3.MinimumSize = New System.Drawing.Size(120, 0)
        Me.ItemContainer3.Name = "ItemContainer3"
        Me.ItemContainer3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem2})
        '
        'ButtonItem2
        '
        Me.ButtonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem2.FontBold = True
        Me.ButtonItem2.HotFontBold = True
        Me.ButtonItem2.HotFontUnderline = True
        Me.ButtonItem2.Image = CType(resources.GetObject("ButtonItem2.Image"), System.Drawing.Image)
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.SubItemsExpandWidth = 24
        Me.ButtonItem2.Text = "<font color=""#5C83B4""><b>CHECK FOR UPDATE</b></font>"
        '
        'ItemContainer9
        '
        '
        '
        '
        Me.ItemContainer9.BackgroundStyle.Class = "RibbonFileMenuColumnOneContainer"
        Me.ItemContainer9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer9.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer9.MinimumSize = New System.Drawing.Size(120, 0)
        Me.ItemContainer9.Name = "ItemContainer9"
        Me.ItemContainer9.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem3})
        '
        'ButtonItem3
        '
        Me.ButtonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem3.Enabled = False
        Me.ButtonItem3.FontBold = True
        Me.ButtonItem3.HotFontBold = True
        Me.ButtonItem3.HotFontUnderline = True
        Me.ButtonItem3.Image = CType(resources.GetObject("ButtonItem3.Image"), System.Drawing.Image)
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.SubItemsExpandWidth = 24
        Me.ButtonItem3.Text = "<font color=""#5C83B4""><b>BACKUP DATA</b></font>"
        '
        'ItemContainer4
        '
        '
        '
        '
        Me.ItemContainer4.BackgroundStyle.Class = "RibbonFileMenuBottomContainer"
        Me.ItemContainer4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer4.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Right
        Me.ItemContainer4.Name = "ItemContainer4"
        Me.ItemContainer4.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem18})
        '
        'ButtonItem18
        '
        Me.ButtonItem18.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem18.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonItem18.Image = CType(resources.GetObject("ButtonItem18.Image"), System.Drawing.Image)
        Me.ButtonItem18.Name = "ButtonItem18"
        Me.ButtonItem18.SubItemsExpandWidth = 24
        Me.ButtonItem18.Text = "E&xit"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem33})
        Me.ButtonItem1.Text = "œŒÊ·"
        '
        'ButtonItem33
        '
        Me.ButtonItem33.FontBold = True
        Me.ButtonItem33.Image = CType(resources.GetObject("ButtonItem33.Image"), System.Drawing.Image)
        Me.ButtonItem33.Name = "ButtonItem33"
        Me.ButtonItem33.Text = "«⁄œ«œ«  «·Õ”«»"
        '
        'qatCustomizeItem1
        '
        Me.qatCustomizeItem1.Name = "qatCustomizeItem1"
        '
        'RibbonTabItem2
        '
        Me.RibbonTabItem2.Checked = True
        Me.RibbonTabItem2.Group = Me.ribbonTabItemGroup1
        Me.RibbonTabItem2.Name = "RibbonTabItem2"
        Me.RibbonTabItem2.Text = "Page &Layout"
        '
        'switchButtonItem1
        '
        Me.switchButtonItem1.ButtonHeight = 20
        Me.switchButtonItem1.ButtonWidth = 62
        Me.switchButtonItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.switchButtonItem1.Margin.Bottom = 2
        Me.switchButtonItem1.Margin.Left = 4
        Me.switchButtonItem1.Name = "switchButtonItem1"
        Me.switchButtonItem1.OffText = "MAX"
        Me.switchButtonItem1.OnText = "MIN"
        Me.switchButtonItem1.Tooltip = "Minimizes/Maximizes the Ribbon"
        '
        'buttonChangeStyle
        '
        Me.buttonChangeStyle.AutoExpandOnClick = True
        Me.buttonChangeStyle.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.buttonChangeStyle.Name = "buttonChangeStyle"
        Me.buttonChangeStyle.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.buttonStyleOffice2010Blue, Me.buttonStyleOffice2010Silver, Me.buttonStyleOffice2010Black, Me.buttonStyleVS2010, Me.buttonItem62, Me.buttonStyleOffice2007Blue, Me.buttonStyleOffice2007Black, Me.buttonStyleOffice2007Silver, Me.buttonItem60, Me.buttonStyleCustom})
        Me.buttonChangeStyle.Text = "Style"
        '
        'buttonStyleOffice2010Blue
        '
        Me.buttonStyleOffice2010Blue.CommandParameter = "Office2010Blue"
        Me.buttonStyleOffice2010Blue.Name = "buttonStyleOffice2010Blue"
        Me.buttonStyleOffice2010Blue.OptionGroup = "style"
        Me.buttonStyleOffice2010Blue.Text = "Office 2010 Blue"
        '
        'buttonStyleOffice2010Silver
        '
        Me.buttonStyleOffice2010Silver.CommandParameter = "Office2010Silver"
        Me.buttonStyleOffice2010Silver.Name = "buttonStyleOffice2010Silver"
        Me.buttonStyleOffice2010Silver.OptionGroup = "style"
        Me.buttonStyleOffice2010Silver.Text = "Office 2010 <font color=""Silver""><b>Silver</b></font>"
        '
        'buttonStyleOffice2010Black
        '
        Me.buttonStyleOffice2010Black.CommandParameter = "Office2010Black"
        Me.buttonStyleOffice2010Black.Name = "buttonStyleOffice2010Black"
        Me.buttonStyleOffice2010Black.OptionGroup = "style"
        Me.buttonStyleOffice2010Black.Text = "Office 2010 Black"
        '
        'buttonStyleVS2010
        '
        Me.buttonStyleVS2010.Checked = True
        Me.buttonStyleVS2010.CommandParameter = "VisualStudio2010Blue"
        Me.buttonStyleVS2010.Name = "buttonStyleVS2010"
        Me.buttonStyleVS2010.OptionGroup = "style"
        Me.buttonStyleVS2010.Text = "Visual Studio 2010"
        '
        'buttonItem62
        '
        Me.buttonItem62.CommandParameter = "Windows7Blue"
        Me.buttonItem62.Name = "buttonItem62"
        Me.buttonItem62.OptionGroup = "style"
        Me.buttonItem62.Text = "Windows 7"
        '
        'buttonStyleOffice2007Blue
        '
        Me.buttonStyleOffice2007Blue.CommandParameter = "Office2007Blue"
        Me.buttonStyleOffice2007Blue.Name = "buttonStyleOffice2007Blue"
        Me.buttonStyleOffice2007Blue.OptionGroup = "style"
        Me.buttonStyleOffice2007Blue.Text = "Office 2007 <font color=""Blue""><b>Blue</b></font>"
        '
        'buttonStyleOffice2007Black
        '
        Me.buttonStyleOffice2007Black.CommandParameter = "Office2007Black"
        Me.buttonStyleOffice2007Black.Name = "buttonStyleOffice2007Black"
        Me.buttonStyleOffice2007Black.OptionGroup = "style"
        Me.buttonStyleOffice2007Black.Text = "Office 2007 <font color=""black""><b>Black</b></font>"
        '
        'buttonStyleOffice2007Silver
        '
        Me.buttonStyleOffice2007Silver.CommandParameter = "Office2007Silver"
        Me.buttonStyleOffice2007Silver.Name = "buttonStyleOffice2007Silver"
        Me.buttonStyleOffice2007Silver.OptionGroup = "style"
        Me.buttonStyleOffice2007Silver.Text = "Office 2007 <font color=""Silver""><b>Silver</b></font>"
        '
        'buttonItem60
        '
        Me.buttonItem60.CommandParameter = "Office2007VistaGlass"
        Me.buttonItem60.Name = "buttonItem60"
        Me.buttonItem60.OptionGroup = "style"
        Me.buttonItem60.Text = "Vista Glass"
        '
        'buttonStyleCustom
        '
        Me.buttonStyleCustom.BeginGroup = True
        Me.buttonStyleCustom.Name = "buttonStyleCustom"
        Me.buttonStyleCustom.Text = "Custom scheme"
        Me.buttonStyleCustom.Tooltip = "Custom color scheme is created based on currently selected color table. Try selec" & _
            "ting Silver or Blue color table and then creating custom color scheme."
        '
        'ribbonTabItem3
        '
        Me.ribbonTabItem3.Group = Me.ribbonTabItemGroup1
        Me.ribbonTabItem3.Name = "ribbonTabItem3"
        Me.ribbonTabItem3.Text = "Page &Layout"
        '
        'ribbonTabItem1
        '
        Me.ribbonTabItem1.Name = "ribbonTabItem1"
        Me.ribbonTabItem1.Text = "&Write"
        '
        'RibbonTabItem4
        '
        Me.RibbonTabItem4.Name = "RibbonTabItem4"
        Me.RibbonTabItem4.Panel = Me.RibbonPanel1
        Me.RibbonTabItem4.Text = "RibbonTabItem4"
        '
        'mdiClient1
        '
        Me.mdiClient1.BackgroundImage = CType(resources.GetObject("mdiClient1.BackgroundImage"), System.Drawing.Image)
        Me.mdiClient1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mdiClient1.Location = New System.Drawing.Point(5, 190)
        Me.mdiClient1.Name = "mdiClient1"
        Me.mdiClient1.Size = New System.Drawing.Size(1140, 281)
        Me.mdiClient1.TabIndex = 5
        '
        'buttonItem47
        '
        Me.buttonItem47.BeginGroup = True
        Me.buttonItem47.Image = CType(resources.GetObject("buttonItem47.Image"), System.Drawing.Image)
        Me.buttonItem47.Name = "buttonItem47"
        Me.buttonItem47.Text = "Search for Templates Online..."
        '
        'buttonItem48
        '
        Me.buttonItem48.Image = CType(resources.GetObject("buttonItem48.Image"), System.Drawing.Image)
        Me.buttonItem48.Name = "buttonItem48"
        Me.buttonItem48.Text = "Browse for Templates..."
        '
        'buttonItem49
        '
        Me.buttonItem49.Image = CType(resources.GetObject("buttonItem49.Image"), System.Drawing.Image)
        Me.buttonItem49.Name = "buttonItem49"
        Me.buttonItem49.Text = "Save Current Template..."
        '
        'labelItem8
        '
        Me.labelItem8.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.labelItem8.BorderType = DevComponents.DotNetBar.eBorderType.Etched
        Me.labelItem8.Name = "labelItem8"
        Me.labelItem8.PaddingBottom = 2
        Me.labelItem8.PaddingTop = 2
        Me.labelItem8.Stretch = True
        Me.labelItem8.Text = "Recent Documents"
        '
        'buttonUndo
        '
        Me.buttonUndo.Enabled = False
        Me.buttonUndo.Image = CType(resources.GetObject("buttonUndo.Image"), System.Drawing.Image)
        Me.buttonUndo.Name = "buttonUndo"
        Me.buttonUndo.Text = "Undo"
        '
        'buttonSave
        '
        Me.buttonSave.Enabled = False
        Me.buttonSave.Image = CType(resources.GetObject("buttonSave.Image"), System.Drawing.Image)
        Me.buttonSave.Name = "buttonSave"
        Me.buttonSave.Text = "buttonItem2"
        '
        'buttonNew
        '
        Me.buttonNew.Image = CType(resources.GetObject("buttonNew.Image"), System.Drawing.Image)
        Me.buttonNew.Name = "buttonNew"
        Me.buttonNew.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlN)
        Me.buttonNew.Text = "New Document"
        '
        'buttonFile
        '
        Me.buttonFile.AutoExpandOnClick = True
        Me.buttonFile.CanCustomize = False
        Me.buttonFile.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image
        Me.buttonFile.Image = CType(resources.GetObject("buttonFile.Image"), System.Drawing.Image)
        Me.buttonFile.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.buttonFile.ImagePaddingHorizontal = 0
        Me.buttonFile.ImagePaddingVertical = 0
        Me.buttonFile.Name = "buttonFile"
        Me.buttonFile.ShowSubItems = False
        Me.buttonFile.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.menuFileContainer})
        Me.buttonFile.Text = "&File"
        '
        'menuFileContainer
        '
        '
        '
        '
        Me.menuFileContainer.BackgroundStyle.Class = "RibbonFileMenuContainer"
        Me.menuFileContainer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.menuFileContainer.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.menuFileContainer.Name = "menuFileContainer"
        Me.menuFileContainer.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.menuFileTwoColumnContainer, Me.menuFileBottomContainer})
        '
        'menuFileTwoColumnContainer
        '
        '
        '
        '
        Me.menuFileTwoColumnContainer.BackgroundStyle.Class = "RibbonFileMenuTwoColumnContainer"
        Me.menuFileTwoColumnContainer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.menuFileTwoColumnContainer.BackgroundStyle.PaddingBottom = 2
        Me.menuFileTwoColumnContainer.BackgroundStyle.PaddingLeft = 2
        Me.menuFileTwoColumnContainer.BackgroundStyle.PaddingRight = 2
        Me.menuFileTwoColumnContainer.BackgroundStyle.PaddingTop = 2
        Me.menuFileTwoColumnContainer.ItemSpacing = 0
        Me.menuFileTwoColumnContainer.Name = "menuFileTwoColumnContainer"
        Me.menuFileTwoColumnContainer.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.menuFileItems, Me.menuFileMRU})
        '
        'menuFileItems
        '
        '
        '
        '
        Me.menuFileItems.BackgroundStyle.Class = "RibbonFileMenuColumnOneContainer"
        Me.menuFileItems.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.menuFileItems.ItemSpacing = 5
        Me.menuFileItems.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.menuFileItems.MinimumSize = New System.Drawing.Size(120, 0)
        Me.menuFileItems.Name = "menuFileItems"
        Me.menuFileItems.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.buttonItem20, Me.buttonItem21, Me.buttonFileSaveAs, Me.buttonItem23, Me.buttonItem24, Me.buttonItem25})
        '
        'buttonItem20
        '
        Me.buttonItem20.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.buttonItem20.Image = CType(resources.GetObject("buttonItem20.Image"), System.Drawing.Image)
        Me.buttonItem20.ImageSmall = CType(resources.GetObject("buttonItem20.ImageSmall"), System.Drawing.Image)
        Me.buttonItem20.Name = "buttonItem20"
        Me.buttonItem20.SubItemsExpandWidth = 24
        Me.buttonItem20.Text = "&New"
        '
        'buttonItem21
        '
        Me.buttonItem21.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.buttonItem21.Image = CType(resources.GetObject("buttonItem21.Image"), System.Drawing.Image)
        Me.buttonItem21.Name = "buttonItem21"
        Me.buttonItem21.SubItemsExpandWidth = 24
        Me.buttonItem21.Text = "&Open..."
        '
        'buttonFileSaveAs
        '
        Me.buttonFileSaveAs.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.buttonFileSaveAs.Image = CType(resources.GetObject("buttonFileSaveAs.Image"), System.Drawing.Image)
        Me.buttonFileSaveAs.ImageSmall = CType(resources.GetObject("buttonFileSaveAs.ImageSmall"), System.Drawing.Image)
        Me.buttonFileSaveAs.Name = "buttonFileSaveAs"
        Me.buttonFileSaveAs.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.itemContainer12})
        Me.buttonFileSaveAs.SubItemsExpandWidth = 24
        Me.buttonFileSaveAs.Text = "&Save As..."
        '
        'itemContainer12
        '
        '
        '
        '
        Me.itemContainer12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.itemContainer12.ItemSpacing = 4
        Me.itemContainer12.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.itemContainer12.MinimumSize = New System.Drawing.Size(210, 256)
        Me.itemContainer12.Name = "itemContainer12"
        Me.itemContainer12.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.labelItem1, Me.buttonItem56, Me.buttonItem57, Me.buttonItem58, Me.buttonItem59})
        '
        'labelItem1
        '
        Me.labelItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.labelItem1.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.labelItem1.BorderType = DevComponents.DotNetBar.eBorderType.Etched
        Me.labelItem1.Name = "labelItem1"
        Me.labelItem1.PaddingBottom = 5
        Me.labelItem1.PaddingLeft = 5
        Me.labelItem1.PaddingRight = 5
        Me.labelItem1.PaddingTop = 5
        Me.labelItem1.Text = "<b>Save a copy of the document</b>"
        '
        'buttonItem56
        '
        Me.buttonItem56.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.buttonItem56.Image = CType(resources.GetObject("buttonItem56.Image"), System.Drawing.Image)
        Me.buttonItem56.Name = "buttonItem56"
        Me.buttonItem56.Text = "<b>&Rich Text Document</b>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<div padding=""0,0,4,0"" width=""170"">Save the document " & _
            "in the default file format.</div>"
        '
        'buttonItem57
        '
        Me.buttonItem57.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.buttonItem57.Image = CType(resources.GetObject("buttonItem57.Image"), System.Drawing.Image)
        Me.buttonItem57.Name = "buttonItem57"
        Me.buttonItem57.Text = "<b>Document &Template</b>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<div padding=""0,0,4,0"" width=""170"">Save as a template " & _
            "that can be used to format future documents.</div>"
        '
        'buttonItem58
        '
        Me.buttonItem58.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.buttonItem58.Image = CType(resources.GetObject("buttonItem58.Image"), System.Drawing.Image)
        Me.buttonItem58.Name = "buttonItem58"
        Me.buttonItem58.Text = "<b>&Find add-ins for other formats</b>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<div padding=""0,0,4,0"" width=""180"">Learn " & _
            "about add-ins to save to other formats such as PDF or XPS.</div>"
        '
        'buttonItem59
        '
        Me.buttonItem59.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.buttonItem59.Image = CType(resources.GetObject("buttonItem59.Image"), System.Drawing.Image)
        Me.buttonItem59.Name = "buttonItem59"
        Me.buttonItem59.Text = "<b>&Other Formats</b>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<div padding=""0,0,4,0"" width=""170"">Open the Save As dialog" & _
            " box to select from all possible file types.</div>"
        '
        'buttonItem23
        '
        Me.buttonItem23.BeginGroup = True
        Me.buttonItem23.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.buttonItem23.Image = CType(resources.GetObject("buttonItem23.Image"), System.Drawing.Image)
        Me.buttonItem23.Name = "buttonItem23"
        Me.buttonItem23.SubItemsExpandWidth = 24
        Me.buttonItem23.Text = "S&hare..."
        '
        'buttonItem24
        '
        Me.buttonItem24.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.buttonItem24.Image = CType(resources.GetObject("buttonItem24.Image"), System.Drawing.Image)
        Me.buttonItem24.Name = "buttonItem24"
        Me.buttonItem24.SubItemsExpandWidth = 24
        Me.buttonItem24.Text = "&Print..."
        '
        'buttonItem25
        '
        Me.buttonItem25.BeginGroup = True
        Me.buttonItem25.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.buttonItem25.Image = CType(resources.GetObject("buttonItem25.Image"), System.Drawing.Image)
        Me.buttonItem25.Name = "buttonItem25"
        Me.buttonItem25.SubItemsExpandWidth = 24
        Me.buttonItem25.Text = "&Close"
        '
        'menuFileMRU
        '
        '
        '
        '
        Me.menuFileMRU.BackgroundStyle.Class = "RibbonFileMenuColumnTwoContainer"
        Me.menuFileMRU.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.menuFileMRU.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.menuFileMRU.MinimumSize = New System.Drawing.Size(225, 0)
        Me.menuFileMRU.Name = "menuFileMRU"
        Me.menuFileMRU.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.labelItem8, Me.buttonItem26, Me.buttonItem27, Me.buttonItem28, Me.buttonItem29})
        '
        'buttonItem26
        '
        Me.buttonItem26.Name = "buttonItem26"
        Me.buttonItem26.Text = "&1. Short News 5-7.rtf"
        '
        'buttonItem27
        '
        Me.buttonItem27.Name = "buttonItem27"
        Me.buttonItem27.Text = "&2. Prospect Email.rtf"
        '
        'buttonItem28
        '
        Me.buttonItem28.Name = "buttonItem28"
        Me.buttonItem28.Text = "&3. Customer Email.rtf"
        '
        'buttonItem29
        '
        Me.buttonItem29.Name = "buttonItem29"
        Me.buttonItem29.Text = "&4. example.rtf"
        '
        'menuFileBottomContainer
        '
        '
        '
        '
        Me.menuFileBottomContainer.BackgroundStyle.Class = "RibbonFileMenuBottomContainer"
        Me.menuFileBottomContainer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.menuFileBottomContainer.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Right
        Me.menuFileBottomContainer.Name = "menuFileBottomContainer"
        Me.menuFileBottomContainer.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.buttonOptions, Me.buttonExit})
        '
        'buttonOptions
        '
        Me.buttonOptions.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.buttonOptions.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.buttonOptions.Image = CType(resources.GetObject("buttonOptions.Image"), System.Drawing.Image)
        Me.buttonOptions.Name = "buttonOptions"
        Me.buttonOptions.SubItemsExpandWidth = 24
        Me.buttonOptions.Text = "RibbonPad Opt&ions"
        '
        'buttonExit
        '
        Me.buttonExit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.buttonExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.buttonExit.Image = CType(resources.GetObject("buttonExit.Image"), System.Drawing.Image)
        Me.buttonExit.Name = "buttonExit"
        Me.buttonExit.SubItemsExpandWidth = 24
        Me.buttonExit.Text = "E&xit RibbonPad"
        '
        'buttonItem54
        '
        Me.buttonItem54.Image = CType(resources.GetObject("buttonItem54.Image"), System.Drawing.Image)
        Me.buttonItem54.Name = "buttonItem54"
        Me.buttonItem54.Text = "Paste &Special..."
        '
        'buttonItem53
        '
        Me.buttonItem53.Enabled = False
        Me.buttonItem53.Image = CType(resources.GetObject("buttonItem53.Image"), System.Drawing.Image)
        Me.buttonItem53.Name = "buttonItem53"
        Me.buttonItem53.Text = "&Paste"
        '
        'buttonPaste
        '
        Me.buttonPaste.Image = CType(resources.GetObject("buttonPaste.Image"), System.Drawing.Image)
        Me.buttonPaste.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.buttonPaste.Name = "buttonPaste"
        Me.buttonPaste.SplitButton = True
        Me.buttonPaste.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.buttonItem53, Me.buttonItem54})
        Me.buttonPaste.Text = "&Paste"
        '
        'Timer1
        '
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        '
        'ButtonItem42
        '
        Me.ButtonItem42.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonItem42.FixedSize = New System.Drawing.Size(140, 0)
        Me.ButtonItem42.FontBold = True
        Me.ButtonItem42.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem42.Image = CType(resources.GetObject("ButtonItem42.Image"), System.Drawing.Image)
        Me.ButtonItem42.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem42.Name = "ButtonItem42"
        Me.ButtonItem42.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2)
        Me.ButtonItem42.Text = "ORDER_OPTIONS"
        '
        'STATUSTIMER
        '
        Me.STATUSTIMER.Enabled = True
        Me.STATUSTIMER.Interval = 1500
        '
        'frmMain
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1150, 500)
        Me.Controls.Add(Me.tabStrip1)
        Me.Controls.Add(Me.ribbonControl1)
        Me.Controls.Add(Me.bar1)
        Me.Controls.Add(Me.mdiClient1)
        Me.Font = New System.Drawing.Font("justagain DIN", 9.249999!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TapPages"
        CType(Me.bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ribbonControl1.ResumeLayout(False)
        Me.ribbonControl1.PerformLayout()
        Me.RibbonPanel4.ResumeLayout(False)
        Me.RibbonPanel3.ResumeLayout(False)
        Me.RibbonPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region

#Region "AppCreation"
    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    <STAThread()> _
    Shared Sub Main()
        Application.Run(New frmMain())
    End Sub
#End Region
    Private Tabs_Handler As New SystemTabHandler()
    Private PlayStationControlPanel_Tab As PlayStationTab = Nothing
    ' Public [LoginUser] As USER = 
    Public IsUserInitilaized As Boolean = False
    ReadOnly Property [LoginUser] As USER
        Get
            Return USER.GetActiveUser
        End Get
    End Property


    ReadOnly Property TabsHandler As SystemTabHandler
        Get
            Return Me.Tabs_Handler
        End Get
    End Property
    ReadOnly Property PlayStationControlPanelTab As PlayStationTab
        Get
            Return PlayStationControlPanel_Tab
        End Get
    End Property

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next

        USER.DisActiveUsers()

    End Sub

    'Public Function GetTab(ByVal TabType As SystemTabHandler.TabsType) As DevComponents.DotNetBar.TabItem
    '    Return Tabs_Handler.GetTab(tabStrip1, TabType)
    'End Function

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error Resume Next

        SQLExportImport.BACKUP()
        CircularProgressItem1.IsRunning = True
        'Dim conn As MySqlConnection = New MySqlConnection
        [ADDSTATUS]("[SYSTEM] LOADING....")

        'Dim file As String = "C:\backup.sql"
        'Dim sComm As New MySqlCommand
        'sComm.CommandText = con
        'sComm.Connection = conn
        'Dim mb As New MySqlBackup(sComm)
        'MsgBox(mb.ExportToString())

        ' SQLExportImport.BACKUP()

        USER.DisActiveUsers()
        ' MsgBox(USER.GetActiveUser().UserName)
        ''MsgBox(DirectCast(Us.Admin, String())(1))
        'MsgBox(Us.DeviceControlPanel.ToString)
        ''Us.[DeviceControlPanel] = True
        ''Us.[Admin] = New String() {"adel", "ali", "mohamed"}
        'Us.SaveToSQL()
        '  Us.Admin = New String() {"adel", "ali", "mohamed"}
        ' Us.Save()
        '    MsgBox(Us.UserName)
        '   Us.UserName = "addmmiin"
        '  Us.SaveToSQL()
        ' MsgBox(Us.UserName)
        'Us.X = "Elkonsol"
        '  Process.Start(Application.StartupPath + "\" + "Back.exe", "backup")

        ' MsgBox(UX.X)
        ButtonItem55.RaiseClick()
        ButtonItem61.Enabled = False
        'Dim x As New Device(66)
        'MsgBox(x.DeviceOptions.ChangeMoveOrder)
        'x.DeviceOptions.ChangeMoveOrder = False
        'x.DeviceOptions.SaveUpdateOptions()
        'Dim x As New Device.Offer(10, 50.433)
        'MsgBox(x.GetOfferValue)
        'MsgBox 

        'My.Computer.Audio.Play(My.Resources.Strange_Noise_SoundBible_com_229408508,
        'AudioPlayMode.Background)



        '' System.Media.SystemSounds.Hand)
        'Dim Sql = "SELECT * FROM `deviceslog` WHERE `id` = '" + CStr(661) + "'"
        'Dim Row As DataRow = (New DataBaseConnection).executeSQL(Sql)(0)

        'Dim s As New Device.DeviceLOG(661)
        'MsgBox(s.DurationTime.ToString)
        ' MsgBox(s.dev.ToString)
        '   MsgBox(Row(5))

        'Dim dv As New Device(68)
        'dv.InitializeData(661)
        'MsgBox(dv.Id)

        RibbonTabItem8.Enabled = False
        '  Me.SetStyle(ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.SupportsTransparentBackColor, False)
        '   RibbonTabItem8.dis
        ' Me.SystemPanel1.DeviceControlPanel1.Device_Handler.LoadDevices()




    End Sub
    Public Sub GetLogin(ByVal sender As Object, ByVal e As EventArgs)
        On Error Resume Next

        If Not IsUserInitilaized Then
            ' If Me.LoginUser Is Nothing Then
            Dim LoginTab As LOGIN = DirectCast(DirectCast(sender, ButtonX).Parent.Parent, LOGIN)
            '  MsgBox(LoginTab.TextBoxX2.Text)
            Dim Uer As USER = USER.LoadFromSQL(LoginTab.TextBoxX1.Text)

            If Not Uer Is Nothing Then

                If Uer.Password = LoginTab.TextBoxX2.Text Then
                    'If Uer.Password = "" Then
                    '    MsgBox("You Need To add Password ")
                    'End If
                    ' MsgBox("Success")
                    LoginTab.Close()
                    tabStrip1.Refresh()
                    tabStrip1.Invalidate()
                    SetLogin(Uer)
                    UpdateTools()
                    frmMain.ADDSTATUS("[LOGIN] SUCCESS USER : " + Uer.UserName)
                Else
                    frmMain.ADDSTATUS("[LOGIN] FAILED USER : " + Uer.UserName + " WORNG PASSWORD")
                End If
            Else
                frmMain.ADDSTATUS("[LOGIN] FAILED USER : " + Uer.UserName + " USER WAS NOT FOUNDED")
            End If

        End If
        '  End If

    End Sub
    Public Sub SetLogin(ByVal User As USER)
        ' Me.LoginUser = User
        On Error Resume Next

        User.DisActiveUsers(User.UserName)

        Me.IsUserInitilaized = True
        Me.ButtonItem1.Text = User.UserName
        Me.ButtonItem1.Enabled = True

        LoadUserSettings()
        ' User.UpdateLastLogin()
    End Sub
    Public Sub LoadUserSettings()
        On Error Resume Next
        ButtonItem61.Enabled = True
        ButtonItem55.Enabled = False
        Me.ButtonItem1.Enabled = True
        ButtonItem34.Enabled = CBool(Me.LoginUser.DeviceControlPanel)
        ButtonItem44.Enabled = CBool(Me.LoginUser.DeviceTypePanel)
        ButtonItem35.Enabled = CBool(Me.LoginUser.SpeciesControllerPanel)
        'application Settings    ButtonItem41.Enabled = CBool(Me.LoginUser.SpeciesControllerPanel)
        buttonMargins.Enabled = CBool(Me.LoginUser.PlayStationTab)
        ButtonItem43.Enabled = CBool(Me.LoginUser.DeviceLogHistory)
        ButtonItem45.Enabled = CBool(Me.LoginUser.schdule)
        RibbonBar1.Enabled = CBool(Me.LoginUser.CanAddTime)
        StartTimeRibbon.Enabled = CBool(Me.LoginUser.CanUpdateStartTime)
        ButtonItem22.Enabled = CBool(Me.LoginUser.CanChangedDevice)
        ButtonItem31.Enabled = CBool(Me.LoginUser.CanUpdateDevice)
        ButtonItem32.Enabled = False
        ' DirectCast(tabStrip1.Tabs(0).AttachedControl, Form).Close()
        ' MsgBox(LoginUser.Theme)
        If Not Me.LoginUser.Theme Is Nothing Then
            StyleManager.ChangeStyle(CType(Me.LoginUser.Theme, eStyle), ColorPickerDropDown1.SelectedColor)
            frmMain.ADDSTATUS("[SYSTEM] UPDATING USER THEME")
        End If
        If Not Me.LoginUser.ThemeColor Is Nothing Then
            StyleManager.ChangeStyle(CType(StyleManager.Style, eStyle), CType(Me.LoginUser.ThemeColor, Color))
        End If
    End Sub
    ReadOnly Property SelectedDevice As DeviceControl1
        Get
            Try
                Return DirectCast(tabStrip1.SelectedTab.AttachedControl, PlayStationTab).SystemPanel1.SelectedDV
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Private Sub tabStrip1_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles tabStrip1.ControlAdded
        On Error Resume Next
        UpdateTools()
    End Sub

    Private Sub tabStrip1_TabItemClose(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripActionEventArgs) Handles tabStrip1.TabItemClose
        'If tabStrip1.SelectedTab.AttachedControl.Name = "PlayStationControlPanel" Then
        '    e.Cancel = True
        'End If
        On Error Resume Next

        tabStrip1.Refresh()
        tabStrip1.Invalidate()

    End Sub
    'Private Sub frmMain_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
    '    Me.SuspendLayout()
    'End Sub

    'Private Sub frmMain_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
    '    Me.ResumeLayout()
    'End Sub

    Private Sub tabStrip1_TabItemOpen(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabStrip1.TabItemOpen
        On Error Resume Next

        tabStrip1.Refresh()
        tabStrip1.Invalidate()
        '  MsgBox(tabStrip1.SelectedTab.AttachedControl.Name)
    End Sub

    Private Sub ButtonItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem1.Click

        'On Error Resume Next

        'CType(Me.mdiClient1.MdiChildren(0), PlayStationTab).SystemPanel1.DeviceControlPanel1.Device_Handler.LoadDevices()

        'Dim doc As New CircularProgressControl.Form1
        'doc.Name = "CircleTest"
        'doc.Text = "CircleTest  "
        'doc.MdiParent = Me
        'doc.WindowState = FormWindowState.Maximized
        'doc.Show()
        'doc.Update()

    End Sub

    Private Sub ButtonItem22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub buttonReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonAddHour.Click
        On Error Resume Next
        If tabStrip1.SelectedTab.AttachedControl.Name = "PlayStationControlPanel" Then
            Dim Dev As DeviceControl1 = DirectCast(tabStrip1.SelectedTab.AttachedControl, PlayStationTab).SystemPanel1.SelectedDV
            Dev.Device.AddTime(60)
            Dev.Refresh()
        End If
    End Sub

    Private Sub tabStrip1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles tabStrip1.SelectedTabChanged
        On Error Resume Next

        UpdateTools()

        If tabStrip1.SelectedTab.AttachedControl.Name = "DevicesControlerPanel" Then
            DirectCast(tabStrip1.SelectedTab.AttachedControl, DevicesControlerPanel).IntilizeHistory()
        End If

    End Sub

    Private Sub buttonRemoveHour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonRemoveHour.Click
        On Error Resume Next
        If tabStrip1.SelectedTab.AttachedControl.Name = "PlayStationControlPanel" Then
            Dim Dev As DeviceControl1 = DirectCast(tabStrip1.SelectedTab.AttachedControl, PlayStationTab).SystemPanel1.SelectedDV
            Dev.Device.RemoveTime(60)
            Dev.Refresh()
        End If
    End Sub

    Private Sub ButtonAddHalfHour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAddHalfHour.Click
        On Error Resume Next
        If tabStrip1.SelectedTab.AttachedControl.Name = "PlayStationControlPanel" Then
            Dim Dev As DeviceControl1 = DirectCast(tabStrip1.SelectedTab.AttachedControl, PlayStationTab).SystemPanel1.SelectedDV
            Dev.Device.AddTime(30)
            Dev.Refresh()
        End If
    End Sub

    Private Sub ButtonRemovehalfhour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRemovehalfhour.Click
        On Error Resume Next
        If tabStrip1.SelectedTab.AttachedControl.Name = "PlayStationControlPanel" Then
            Dim Dev As DeviceControl1 = DirectCast(tabStrip1.SelectedTab.AttachedControl, PlayStationTab).SystemPanel1.SelectedDV
            Dev.Device.RemoveTime(30)
            Dev.Refresh()
        End If
    End Sub

    Private Sub AddMinutes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddMinutes.Click
        On Error Resume Next
        If tabStrip1.SelectedTab.AttachedControl.Name = "PlayStationControlPanel" Then
            Dim Dev As DeviceControl1 = DirectCast(tabStrip1.SelectedTab.AttachedControl, PlayStationTab).SystemPanel1.SelectedDV
            If IsNumeric(Me.AddminutsTbox.Text) Then
                Dev.Device.AddTime(CInt(Me.AddminutsTbox.Text))
                Dev.Refresh()
            End If

        End If
    End Sub

    Private Sub addHours_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addHours.Click
        On Error Resume Next
        If tabStrip1.SelectedTab.AttachedControl.Name = "PlayStationControlPanel" Then
            Dim Dev As DeviceControl1 = DirectCast(tabStrip1.SelectedTab.AttachedControl, PlayStationTab).SystemPanel1.SelectedDV
            If IsNumeric(Me.AddHoursTbox.Text) Then
                Dev.Device.AddTime((CInt(Me.AddHoursTbox.Text) * 60))
                Dev.Refresh()
            End If

        End If
    End Sub

    Private Sub ButtonItem19_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem19.Click
        On Error Resume Next

        If tabStrip1.SelectedTab.AttachedControl.Name = "PlayStationControlPanel" Then
            Dim Dev As DeviceControl1 = DirectCast(tabStrip1.SelectedTab.AttachedControl, PlayStationTab).SystemPanel1.SelectedDV
            Dev.Device.SetTimeOpend()
            Dev.Refresh()
        End If
    End Sub

    Private Sub buttonMargins_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonMargins.Click
        On Error Resume Next
        If Not Tabs_Handler.FindAndSelectTab(Me.tabStrip1, SystemTabHandler.TabsType.PlayStationControlPanel) Then

            Dim doc As New PlayStationTab(Me)
            doc.Name = "PlayStationControlPanel"
            doc.Text = "PlayStaionDevices&Tables"
            doc.MdiParent = Me
            doc.WindowState = FormWindowState.Maximized
            'doc.Enabled = False
            doc.Show()
            doc.Update()
            Me.PlayStationControlPanel_Tab = doc

        End If
    End Sub

    Private Sub ButtonItem22_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem22.Click
        On Error Resume Next

        'Dim Dev As DeviceControl1 = DirectCast(tabStrip1.SelectedTab.AttachedControl, PlayStationTab).SystemPanel1.SelectedDV
        DirectCast(tabStrip1.SelectedTab.AttachedControl, PlayStationTab).SystemPanel1.m_SystemHandler.ChangeDevice()
    End Sub

    Private is_Resizing As Boolean = True
    Private Sub PlayStationTab_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        On Error Resume Next
        DirectCast(tabStrip1.SelectedTab.AttachedControl, PlayStationTab).ShowLoadingImage()
        is_Resizing = True
        Me.Timer1.Start()

    End Sub

    Private Sub ResizeBeginTmr_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        On Error Resume Next
        If Me.is_Resizing Then
            DirectCast(tabStrip1.SelectedTab.AttachedControl, PlayStationTab).ShowLoadingImage()
            is_Resizing = False
        Else
            Timer1.Stop()
            '  MsgBox("hhh1")

            DirectCast(tabStrip1.SelectedTab.AttachedControl, PlayStationTab).HideLoadingImage()
        End If
    End Sub

    Private Sub PlayStationTab_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        On Error Resume Next
        '  MsgBox("hhh")
        is_Resizing = False
        Me.Timer1.Start()
    End Sub

    Private Sub frmMain_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        On Error Resume Next
        DirectCast(tabStrip1.SelectedTab.AttachedControl, PlayStationTab).ShowLoadingImage()
        is_Resizing = True
        Me.Timer1.Start()
    End Sub

    Private Sub ButtonItem30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem30.Click
        On Error Resume Next

        DirectCast(tabStrip1.SelectedTab.AttachedControl, PlayStationTab).SystemPanel1.DeviceControlPanel1.Device_Handler.LoadDevices()
    End Sub

    Private Sub Tools_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tools.CheckedChanged

    End Sub

    Private Sub Tools_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tools.Click


    End Sub
    Public Sub UpdateTools()

        On Error GoTo 1
        If (tabStrip1.SelectedTab.AttachedControl.Name = "PlayStationControlPanel") Then
            ' If SelectedDevice.Device.DeviceOptions.CanActive Then
            Me.RibbonBar1.Enabled = CBool(Me.LoginUser.CanAddTime)
            Me.RibbonBar3.Enabled = True
            Me.RibbonBar4.Enabled = True
            Me.StartTimeRibbon.Enabled = CBool(Me.LoginUser.CanUpdateStartTime)
            'Else
            '    GoTo 1
            'End If
        Else
1:

            Me.RibbonBar1.Enabled = False
            Me.RibbonBar3.Enabled = False
            Me.RibbonBar4.Enabled = False
            Me.StartTimeRibbon.Enabled = False
        End If
        Me.RibbonBar1.Refresh()
        Me.RibbonBar3.Refresh()
        Me.RibbonBar4.Refresh()
        Me.StartTimeRibbon.Refresh()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Try

            If (Not SelectedDevice Is Nothing) Then
                If SelectedDevice.Device.Statue = Device.DeviceStatus.IsActive Then


                    '  If (tabStrip1.SelectedTab.AttachedControl.Name = "PlayStationControlPanel") Then
                    Dim Hour As String = CStr(SelectedDevice.Device.StartDate.Hour)
                    If CInt(Hour) > 12 Then
                        Me.LabelItem3.Text = "PM"
                        Hour = CStr(CInt(Hour) - 12)
                    Else
                        Me.LabelItem3.Text = "AM"
                    End If
                    Me.ButtonItem39.Text = Hour
                    Me.ButtonItem40.Text = CStr(SelectedDevice.Device.StartDate.Minute)
                    ButtonItem39.Refresh()
                    ButtonItem40.Refresh()
                    LabelItem3.Refresh()
                    Me.LabelItem5.Text = String.Format("{0}H:{1}M", CStr(SelectedDevice.Device.PassedTime.Hours), CStr(SelectedDevice.Device.PassedTime.Minutes))
                    ''Me.LabelItem3.Text = CStr(SelectedDevice.Device.StartDate)
                Else
                    ' On Error GoTo 1
                    Me.LabelItem5.Text = "0H:0M"
                    Me.StartTimeRibbon.Refresh()
                End If
            End If

            '        End If
        Catch ex As Exception
            LOG.[LOG](ex) '
        End Try
        'ButtonItem39
    End Sub

    Private Sub ButtonItem40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem40.Click
        On Error Resume Next

        ButtonItem39.Checked = ButtonItem40.Checked
        ButtonItem40.Checked = Not ButtonItem40.Checked
        StartTimeRibbon.Refresh()
    End Sub

    Private Sub ButtonItem39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem39.Click
        On Error Resume Next

        ButtonItem40.Checked = ButtonItem39.Checked
        ButtonItem39.Checked = Not ButtonItem39.Checked
        StartTimeRibbon.Refresh()
    End Sub

    Private Sub ButtonItem36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem36.Click
        On Error Resume Next

        If ButtonItem39.Checked Then
            Me.SelectedDevice.Device.AddToStartTime(1, 0)
            Me.SelectedDevice.Refresh()
        End If
        If ButtonItem40.Checked Then
            Me.SelectedDevice.Device.AddToStartTime(0, 1)
            Me.SelectedDevice.Refresh()
        End If
        Me.SelectedDevice.Device.UpdateStartDate()
        StartTimeRibbon.Refresh()
    End Sub

    Private Sub ButtonItem37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem37.Click
        On Error Resume Next

        If ButtonItem39.Checked Then
            Me.SelectedDevice.Device.AddToStartTime(-1, 0)
            Me.SelectedDevice.Refresh()
        End If
        If ButtonItem40.Checked Then
            Me.SelectedDevice.Device.AddToStartTime(0, -1)
            Me.SelectedDevice.Refresh()
        End If
        Me.SelectedDevice.Device.UpdateStartDate()
        StartTimeRibbon.Refresh()
    End Sub

    Private Sub ButtonItem38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.SelectedDevice.Device.UpdateStartDate()
        StartTimeRibbon.Refresh()
    End Sub

    Private Sub ButtonItem31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem31.Click
        On Error Resume Next
        If Not SelectedDevice Is Nothing Then
            Dim doc As New DeviceInfo(Me, SelectedDevice.Device)
            doc.Name = "DeviceInfo"
            doc.Text = "Device [" + Me.SelectedDevice.Device.Name + "]"
            doc.MdiParent = Me
            doc.WindowState = FormWindowState.Maximized
            doc.Show()
            doc.Update()
        End If

    End Sub

    Private Sub ButtonItem34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem34.Click
        On Error Resume Next

        OpenDevicesControlerPanel()
    End Sub
    Public Sub OpenDevicesControlerPanel()

        If Not Tabs_Handler.FindAndSelectTab(Me.tabStrip1, SystemTabHandler.TabsType.DevicesControlerPanel) Then
            Dim doc As DevicesControlerPanel

            doc = New DevicesControlerPanel(Me)


            doc.Name = SystemTabHandler.TabsType.DevicesControlerPanel.ToString
            doc.Text = "DevicesControlPanel"
            doc.MdiParent = Me
            doc.WindowState = FormWindowState.Maximized
            'doc.Enabled = False
            doc.Show()
            doc.Update()
            doc.Invalidate()
        End If
    End Sub

    'Private Sub ButtonItem42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    StyleManager.ChangeStyle(CType(eDotNetBarStyle.Office2000, eStyle), StyleManager.ColorTint)
    '    Me.Update()
    '    Me.Refresh()



    'End Sub



    Private Sub ButtonItem43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        Dim RandomSelect As Integer = (New Random).Next(0, 30)
        Dim Counter As Integer = 0
        For Each ColorGeneratored As Metro.ColorTables.MetroColorGeneratorParameters In Metro.ColorTables.MetroColorGeneratorParameters.GetAllPredefinedThemes
            If Counter = RandomSelect Then
                StyleManager.ChangeStyle(CType(StyleManager.Style, eStyle), ColorGeneratored.BaseColor)
                Exit For
            Else
                Counter += 1
            End If


        Next
    End Sub

    Private Sub ButtonItem45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        StyleManager.ChangeStyle(CType(eStyle.VisualStudio2010Blue, eStyle), StyleManager.ColorTint)

    End Sub


    Private Sub ButtonItem35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem35.Click
        On Error Resume Next
        If Not Tabs_Handler.FindAndSelectTab(Me.tabStrip1, SystemTabHandler.TabsType.SpeciesControllerPanel) Then
            ' If Not SelectedDevice Is Nothing Then
            Dim doc As New SpeciesControllerPanel
            doc.Name = "SpeciesControllerPanel"
            doc.Text = "SpeciesControllerPanel"
            doc.MdiParent = Me
            doc.WindowState = FormWindowState.Maximized
            doc.Show()
            doc.Update()
            '  End If
            ' My.Computer.Audio.Stop()
        End If
        '  Me.Refresh()

    End Sub

    Private Sub ButtonItem41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem41.Click
        On Error Resume Next

        Dim doc As New DevicesTypeController
        doc.Name = "DevicesTypeController"
        doc.Text = "DevicesTypeController"
        doc.MdiParent = Me
        doc.WindowState = FormWindowState.Maximized
        doc.Show()
        doc.Update()
    End Sub

    Private Sub ButtonItem46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem46.Click
        On Error Resume Next
        '  Try


        Dim RandomSelect As Integer = CInt(StyleManager.Style)
        If RandomSelect = 9 Then
            RandomSelect = 0
        Else
            RandomSelect += 1
        End If

        StyleManager.ChangeStyle(CType(RandomSelect, eStyle), StyleManager.ColorTint)
        If USER.GetActiveUser Is Nothing Then
        Else
            Dim U As USER = USER.GetActiveUser
            '            MsgBox(CType(RandomSelect, eStyle))
            U.Theme = RandomSelect
            U.SaveToSQL()
            ' MsgBox(U.Theme)


            ' MsgBox(CType(Me.LoginUser.Theme, eStyle).ToString)

        End If
        'Catch ex As Exception

        'End Try
    End Sub
    Private m_BaseColorScheme As eWindows7ColorScheme = eWindows7ColorScheme.Blue
    Private Sub colorPickerCustomScheme_ColorPreview(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.ColorPreviewEventArgs) Handles ColorPickerDropDown1.ColorPreview
        On Error Resume Next

        '    RibbonPredefinedColorSchemes.ChangeWindows7ColorTable(Me, m_BaseColorScheme, e.Color)
        StyleManager.ChangeStyle(CType(StyleManager.Style, eStyle), e.Color)

    End Sub
    Private m_ColorSelected As Boolean = False
    Private Sub colorPickerCustomScheme_ExpandChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles ColorPickerDropDown1.ExpandChange
        On Error Resume Next

        If Me.ColorPickerDropDown1.Expanded Then
            ' Remember the starting color scheme to apply if no color is selected during live-preview
            m_ColorSelected = False
            '  m_BaseColorScheme = Windows7ColorTable.ColorTable.InitialColorScheme
        Else
            If Not m_ColorSelected Then
                StyleManager.ChangeStyle(CType(StyleManager.Style, eStyle), ColorPickerDropDown1.SelectedColor)
                If USER.GetActiveUser Is Nothing Then
                Else
                    Dim U As USER = USER.GetActiveUser
                    U.ThemeColor = ColorPickerDropDown1.SelectedColor
                    U.SaveToSQL()
                End If
            End If
        End If
    End Sub
    Private Sub colorPickerCustomScheme_SelectedColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ColorPickerDropDown1.SelectedColorChanged
        On Error Resume Next

        StyleManager.ChangeStyle(CType(StyleManager.Style, eStyle), ColorPickerDropDown1.SelectedColor)
        If USER.GetActiveUser Is Nothing Then
        Else
            Dim U As USER = USER.GetActiveUser
            U.ThemeColor = ColorPickerDropDown1.SelectedColor
            U.SaveToSQL()
        End If
    End Sub

    Private Sub ButtonItem51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem51.Click
        On Error Resume Next
        Dim RandomSelect As Integer = (New Random).Next(0, 30)
        Dim Counter As Integer = 0
        For Each ColorGeneratored As Metro.ColorTables.MetroColorGeneratorParameters In Metro.ColorTables.MetroColorGeneratorParameters.GetAllPredefinedThemes
            If Counter = RandomSelect Then
                StyleManager.ChangeStyle(CType(StyleManager.Style, eStyle), ColorGeneratored.BaseColor)
                If USER.GetActiveUser Is Nothing Then
                Else
                    Dim U As USER = USER.GetActiveUser
                    U.ThemeColor = ColorGeneratored.BaseColor
                    U.SaveToSQL()
                End If
                Exit For
            Else
                Counter += 1
            End If


        Next
    End Sub

    Private Sub ButtonItem50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem50.Click
        On Error Resume Next
        StyleManager.ChangeStyle(CType(eStyle.VisualStudio2010Blue, eStyle), StyleManager.ColorTint)
        Dim U As USER = USER.GetActiveUser
        U.Theme = 8
        U.SaveToSQL()
    End Sub

    Private Sub ButtonItem43_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem43.Click

        On Error Resume Next

        If Not Tabs_Handler.FindAndSelectTab(Me.tabStrip1, SystemTabHandler.TabsType.DeviesLogHistory) Then


            Dim doc As New DeviesLogHistory
            doc.Name = "DeviesLogHistory"
            doc.Text = "DeviesLogHistory"
            doc.MdiParent = Me
            doc.WindowState = FormWindowState.Maximized
            doc.Show()
            doc.Update()
        End If
    End Sub

    Private Sub ButtonItem33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'DeviceToUpdate = SelectedDevice.Device
        'OpenDevicesControlerPanel()
    End Sub

    Private Sub ButtonItem45_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem45.Click
        On Error Resume Next

        If Not Tabs_Handler.FindAndSelectTab(Me.tabStrip1, SystemTabHandler.TabsType.ScheduleHandler) Then
            Dim doc As New Schedule
            doc.Name = "ScheduleHandler"
            doc.Text = "ScheduleHandler"
            doc.MdiParent = Me
            doc.WindowState = FormWindowState.Maximized
            doc.Show()
            doc.Update()
        End If
    End Sub

    Private Sub ButtonItem44_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem44.Click
        On Error Resume Next

        If Not Tabs_Handler.FindAndSelectTab(Me.tabStrip1, SystemTabHandler.TabsType.DevicesTypeController) Then


            Dim doc As New DevicesTypeController
            doc.Name = "DevicesTypeController"
            doc.Text = "DevicesTypeController"
            doc.MdiParent = Me
            doc.WindowState = FormWindowState.Maximized
            doc.Show()
            doc.Update()
        End If
    End Sub

    Private Sub ButtonItem52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next

        MsgBox(Me.PlayStationControlPanelTab.SystemPanel1.SelectedDV.Device.CheckSchedules)

        ' CheckSchedules()
    End Sub

    Private Sub ribbonControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ribbonControl1.Click

    End Sub

    Private Sub ButtonItem55_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem55.Click
        On Error Resume Next

        If Not Tabs_Handler.FindAndSelectTab(Me.tabStrip1, SystemTabHandler.TabsType.LOGIN) Then

            Dim doc As New LOGIN()
            AddHandler doc.ButtonX1.Click, AddressOf GetLogin
            doc.Name = "LOGIN"
            doc.Text = "LOGIN"
            doc.MdiParent = Me
            doc.WindowState = FormWindowState.Maximized
            'doc.Enabled = False
            doc.Show()
            doc.Update()
            ' Me.PlayStationControlPanel_Tab = doc
            ButtonItem61.Enabled = True
        End If
    End Sub

    Private Sub ButtonItem61_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem61.Click
        On Error Resume Next
        'ButtonItem55.RaiseClick()
        ButtonItem61.Enabled = False
        ButtonItem55.Enabled = False
        ButtonItem34.Enabled = False
        ButtonItem44.Enabled = False
        ButtonItem35.Enabled = False
        'application Settings    ButtonItem41.Enabled = CBool(Me.LoginUser.SpeciesControllerPanel)
        buttonMargins.Enabled = False
        ButtonItem43.Enabled = False
        ButtonItem45.Enabled = False
        RibbonBar1.Enabled = False
        StartTimeRibbon.Enabled = False
        ButtonItem22.Enabled = False
        ButtonItem31.Enabled = False
        ButtonItem32.Enabled = False

        Me.ButtonItem1.Enabled = False
        Me.ButtonItem1.Text = "LOGIN"

        For i As Integer = 0 To tabStrip1.Tabs.Count
            If tabStrip1.Tabs(i).AttachedControl.Name = "LOGIN" Then
                '  TAB.PerformClick()
            Else

                DirectCast(tabStrip1.Tabs(i).AttachedControl, Form).Close()
                tabStrip1.Refresh()
                Me.Refresh()
                Me.Update()
            End If

        Next


        DirectCast(tabStrip1.Tabs(0).AttachedControl, Form).Close()
        tabStrip1.Refresh()
        tabStrip1.Invalidate()
        Me.Refresh()
        Me.Update()

        If Not Tabs_Handler.FindAndSelectTab(Me.tabStrip1, SystemTabHandler.TabsType.LOGIN) Then

            Dim doc As New LOGIN()
            AddHandler doc.ButtonX1.Click, AddressOf GetLogin
            doc.Name = "LOGIN"
            doc.Text = "LOGIN"
            doc.MdiParent = Me
            doc.WindowState = FormWindowState.Maximized
            'doc.Enabled = False
            doc.Show()
            doc.Update()
            ' Me.PlayStationControlPanel_Tab = doc
            ButtonItem61.Enabled = True
        End If


        Me.IsUserInitilaized = False
        USER.DisActiveUsers()
        ButtonItem55.Enabled = True
    End Sub


    Private Sub ButtonItem33_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem33.Click

        If Not Tabs_Handler.FindAndSelectTab(Me.tabStrip1, SystemTabHandler.TabsType.LOGIN) Then

            Dim doc As New UserPanel(Me.LoginUser)
            '  AddHandler doc.ButtonX1.Click, AddressOf GetLogin
            doc.Name = "UserPanel"
            doc.Text = "UserPanel"
            doc.MdiParent = Me
            doc.WindowState = FormWindowState.Maximized
            'doc.Enabled = False
            doc.Show()
            doc.Update()
            ' Me.PlayStationControlPanel_Tab = doc
            '   ButtonItem61.Enabled = True
        End If
    End Sub

    Private Sub ButtonItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem2.Click
      
    End Sub
    Private Shared STSLIST As New List(Of String)
    Public Shared ReadOnly Property StatusList As List(Of String)
        Get
            Return STSLIST
        End Get
    End Property
    Public Shared Sub [ADDSTATUS](ByVal Status As String)
        STSLIST.Add(Status)
    End Sub



    Private Sub ButtonItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem18.Click
        Application.Exit()

    End Sub

    Private Sub STATUSTIMER_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STATUSTIMER.Tick
        On Error Resume Next
        If StatusList.Count > 0 Then
            CircularProgressItem1.Visible = True
            labelStatus.Text = STSLIST(0)
            STSLIST.RemoveAt(0)
        Else
            CircularProgressItem1.Visible = False
            labelStatus.Text = "READY"
        End If
    End Sub

    Private Sub ButtonItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem3.Click
        On Error Resume Next
        SQLExportImport.BACKUP()
    End Sub
End Class

