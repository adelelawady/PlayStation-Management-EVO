Imports DevComponents.DotNetBar

Public Class DevicesControlerPanel

    Private db As New DataBaseConnection
    Private Sub ButtonItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Dim Loaddevicesthrd As Threading.Thread
    Dim AddDeviceThrd As Threading.Thread
    Private _Main As frmMain = Nothing
    Dim User As USER = Nothing
    Public Sub New(ByVal main As frmMain)
        Try


            ' This call is required by the designer.
            InitializeComponent()
           
            _Main = main

            User = main.LoginUser
            Me.CButton2.Enabled = CBool(User.CanCreateDevice)
            Me.CButton3.Enabled = CBool(User.CanUpdateDevice)
            Me.CButton4.Enabled = CBool(User.CanDeleteDevice)
            Me.CButton5.Enabled = CBool(User.CanDeleteDeviceLog)
            Me.CButton6.Enabled = CBool(User.CanStartDeviceLog)

            Control.CheckForIllegalCrossThreadCalls = False
            Me.CircularProgress1.IsRunning = True
            Me.PanelEx1.BringToFront()
            Me.ItemContainer1.SubItems.Clear()


            ' Add any initialization after the InitializeComponent() call.
            Loaddevicesthrd = New Threading.Thread(AddressOf LoadDevices)
            Loaddevicesthrd.IsBackground = True
            Loaddevicesthrd.Start()




            '  LoadAdvancedOptionsList()

            '  LoadDeviceTypes()
            ' Try


        Catch ex As Exception
            LOG.[LOG](ex) ' MsgBox(ex.StackTrace)
        End Try
        'Catch ex As Exception
        '   LOG.[LOG](ex) ' MsgBox(ex.StackTrace)
        'End Try

    End Sub
    Public Sub LoadDeviceTypes()
        On Error Resume Next
        ComboBoxEx1.Items.Clear()
        For Each dev As Device.DeviceType In Device.DeviceType.GetDeviceTypes
            '  MsgBox(dev.Name)
            Dim combo As New DevComponents.Editors.ComboItem(dev.Name, Color.DarkGray)
            combo.Tag = dev
            If Not (dev.Id = 0 And CheckBoxItem1.Checked) Then
                ComboBoxEx1.Items.Add(combo)
            End If
        Next
        If ComboBoxEx1.Items.Count > 0 Then
            ComboBoxEx1.SelectedIndex = 0
        End If
    End Sub
    Public Sub LoadAdvancedOptionsList()
        On Error Resume Next

        ItemContainer5.SubItems.Clear()
        Dim counter As Integer = 0
        Dim DVoption As New Device.Options(Nothing)

        If Not Me.CheckBoxItem1.Checked Then
            DVoption.SetTabel()
        Else
            DVoption.SetDefaultDeviceValue()
        End If
        '  Application.DoEvents()

        For Each DeviceOption As String In System.Enum.GetNames(GetType(Device.Options.SettingList))
            'Dim DisabledSettings As Boolean = False


            'For Each TableDisabledSettings As String In System.Enum.GetNames(GetType(Device.Options.TableDisabledSettings))
            '    If TableDisabledSettings.ToString = DeviceOption.ToString Then
            '        DisabledSettings = True
            '        Exit For
            '    End If
            'Next

            If counter > 2 Then
                Dim StringName As String = ""
                '   MsgBox(Device.Options.GetOptionRecommended(DeviceOption).ToString)
                If Device.Options.GetOptionRecommended(DeviceOption.ToString) = Device.Options.SettingType.HighRecommended Then
                    StringName = "<b>" + DeviceOption + "</b><font color=""" + Device.Options.HighRecommendedColor + """> [HighRecommended]</font>"
                ElseIf Device.Options.GetOptionRecommended(DeviceOption.ToString) = Device.Options.SettingType.Recommended Then
                    StringName = "<b>" + DeviceOption + "</b><font color=""" + Device.Options.RecommendedColor + """> [Recommended]</font>"
                ElseIf Device.Options.GetOptionRecommended(DeviceOption.ToString) = Device.Options.SettingType.Optional Then
                    StringName = "<b>" + DeviceOption + "</b><font color=""" + Device.Options.OptionalColor + """> [Optional]</font>"
                End If

                Dim combo As New DevComponents.DotNetBar.CheckBoxItem("CheckBoxOption" + CStr(counter), StringName)
                combo.TextColor = Color.White
                combo.Tag = DeviceOption
                combo.Checked = DVoption.GetSetting(DeviceOption)
                'AddHandler combo.CheckedChanged, AddressOf CheckedChanged
                CurrentBoxitem = combo
                ' ItemContainer5.SubItems.Add(combo)
                Dim thrd As Threading.Thread = New Threading.Thread(AddressOf AddCheckbox)
                thrd.IsBackground = True
                thrd.Start()
                Application.DoEvents()
                'combo.Tag = tim_role
                ItemContainer5.UpdateBindings()
                ItemContainer5.Refresh()
            End If

            counter += 1
            Application.DoEvents()
            ItemContainer5.UpdateBindings()
            ItemContainer5.Refresh()

        Next
    End Sub
    'Public Sub CheckedChanged()
    '    Dim OptionName As String = CheckBox.Tag.ToString
    '    Dev.DeviceOptions.SetSetting(OptionName, CheckBox.Checked)
    'End Sub
    Private CurrentBoxitem As DevComponents.DotNetBar.CheckBoxItem = Nothing
    'Delegate Sub AddDeviceCallback(ByVal [Device] As DevComponents.DotNetBar.BaseItem)

    Private Sub AddCheckbox()
        Me.AddCheckBoxItem(CurrentBoxitem)
    End Sub
    Private Sub AddCheckBoxItem(ByVal [Device] As DevComponents.DotNetBar.BaseItem)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread  of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ItemContainer5.InvokeRequired Then
            Dim d As New AddDeviceCallback(AddressOf AddCheckBoxItem)

            ItemContainer5.Invoke(d, New Object() {[Device]})

            'Me.PanelEx2.Invoke(d, New Object() {[Device]})
            'Me.PanelEx1.Invoke(d, New Object() {[Device]})
        Else
            ''  Me.textBox1.Text = [Text]
            '[Device].Refresh()
            'MsgBox("success")

            ItemContainer5.SubItems.Add([Device])

            ' EffectualProgressBarBlue1.Value += 1

        End If
    End Sub


    Private Sub AddDevice()
        Me.AddTo(currentDv)
    End Sub
    Private currentDv As DevComponents.DotNetBar.BaseItem = Nothing
    Delegate Sub AddDeviceCallback(ByVal [Device] As DevComponents.DotNetBar.BaseItem)
    Private Sub AddTo(ByVal [Device] As DevComponents.DotNetBar.BaseItem)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread  of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ItemContainer1.InvokeRequired Then
            Dim d As New AddDeviceCallback(AddressOf AddTo)

            ItemContainer1.Invoke(d, New Object() {[Device]})

            'Me.PanelEx2.Invoke(d, New Object() {[Device]})
            'Me.PanelEx1.Invoke(d, New Object() {[Device]})
        Else
            ''  Me.textBox1.Text = [Text]
            '[Device].Refresh()
            'MsgBox("success")

            ItemContainer1.SubItems.Add([Device])
            ItemContainer1.Refresh()
            ItemContainer1.UpdateBindings()
            ' EffectualProgressBarBlue1.Value += 1

        End If
    End Sub
    Public Sub LoadDevices()
        '  On Error Resume Next
        Me.PanelEx1.BringToFront()
        Me.ItemContainer1.SubItems.Clear()

        Dim Sql As String = "SELECT * FROM `devices`"
        Dim Rows As DataRowCollection = db.executeSQL(Sql)
        '  EffectualProgressBarBlue1.Maximum = Rows.Count
        For Each DR As DataRow In Rows
            'MsgBox(DR(0))
            Dim Dev As Device = New Device(DR(0), Me.User)
            Dim Baseitm As DevComponents.DotNetBar.BaseItem = IntializeButton(Dev)
            If Not Baseitm Is Nothing Then

                '   MsgBox(Baseitm.Text)
                Me.currentDv = Baseitm
                '  ItemContainer1.SubItems.Add(Baseitm)
                AddDeviceThrd = New Threading.Thread(AddressOf AddDevice)
                AddDeviceThrd.IsBackground = True
                AddDeviceThrd.Start()

                'MsgBox(Baseitm.Text)
                'AddDevice()
            End If

        Next
        ItemContainer1.Refresh()
        ItemContainer1.UpdateBindings()
        ItemPanel1.Refresh()
        ItemPanel1.RefreshItems()
        Me.PanelEx1.SendToBack()
        Loaddevicesthrd.Abort()
        Loaddevicesthrd.CurrentThread.Interrupt()

    End Sub
    Public Function IntializeButton(ByVal Dev As Device) As DevComponents.DotNetBar.ButtonItem
        Try


            Dim But As New DevComponents.DotNetBar.ButtonItem

            Dim Info As String = String.Format(My.Resources.DevicesPanelDeviceInfo.ToString, Dev.Name, Dev.Type.Name, "Acive")

            But.Text = Info

            But.FixedSize = New Size(120, 120)
            But.Image = My.Resources.desktop_monitor_screen_64
            But.ImageFixedSize = New Size(32, 32)
            But.Tag = Dev
            But.OptionGroup = "DeviceList"
            But.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            'If Dev.Id = sledev.Id Then
            '    But.Checked = True
            'End If
            AddHandler But.Click, AddressOf SelectedDeviceChanged
            Return But
        Catch ex As Exception
            LOG.[LOG](ex) ' MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function



    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        Me.PageSlider1.SelectedPageIndex = 0
    End Sub

    Private Sub CButton2_ClickButtonArea_1(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CButton2.ClickButtonArea
        Me.PageSlider1.SelectedPageIndex = 1
        ButtonX3.Enabled = True
    End Sub

    Private Sub ComboBoxEx1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxEx1.SelectedIndexChanged
        On Error Resume Next

        ItemContainer4.SubItems.Clear()
        Dim tim As New Time(DirectCast(ComboBoxEx1.SelectedItem.Tag, Device.DeviceType).Id.ToString, "")

        For Each tim_role As Time.TimeRole In tim.TimeRols
            ' MsgBox(tim_role.ID)
            '  MsgBox(dev.Name)
            Dim combo As New DevComponents.DotNetBar.CheckBoxItem(tim_role.ID, tim_role.Name.ToString + " [ MinutesStart:" + CStr(tim_role.MinutesStart) + "  > MinutesEnd:" + tim_role.MinutesEnd.ToString + "]")
            combo.TextColor = Color.White
            combo.Enabled = False
            combo.Checked = True
            combo.Tag = tim_role

            ItemContainer4.SubItems.Add(combo)
        Next
        ItemContainer4.Refresh()

        ' For Each Tim As Time In Time.GetTimeList

        '    If Tim.ID = Me.Device.TimeType.ID Then

        'DeviceTime_selecteditem = combo
        'ComboBoxEx2.SelectedItem = combo
        '    End If
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        Me.PageSlider1.Invalidate()
        Me.PageSlider1.Refresh()

        Me.PageSlider1.Update()

    End Sub
    Dim LoadAdvancedOptionsListthrd As Threading.Thread = Nothing
    Public Sub SetTABLE()
        For Each item As DevComponents.Editors.ComboItem In ComboBoxEx1.Items
            If item.Text = "[TABLE]" Then
                ComboBoxEx1.SelectedItem = item
                Exit For
            End If
        Next
    End Sub
    Private Sub CheckBoxItem1_CheckedChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles CheckBoxItem1.CheckedChanged
        On Error Resume Next
        LoadDeviceTypes()

        ComboBoxEx1.Enabled = CheckBoxItem1.Checked
        SetTABLE()
        If Not LoadAdvancedOptionsListthrd.IsAlive Then
            LoadAdvancedOptionsListthrd = New Threading.Thread(AddressOf LoadAdvancedOptionsList)
            LoadAdvancedOptionsListthrd.IsBackground = True
            LoadAdvancedOptionsListthrd.Start()
        Else
            LoadAdvancedOptionsListthrd.Abort()
            LoadAdvancedOptionsListthrd.CurrentThread.Interrupt()

        End If

        'LoadAdvancedOptionsListLoaded = True
    End Sub
    Public Function InsertDevice() As Boolean
        On Error Resume Next

        Return Device.InsertDevice(TextBoxX1.Text, DirectCast(ComboBoxEx1.SelectedItem.Tag, Device.DeviceType).Id.ToString)
    End Function
    Public Function InserDevOptions(ByVal Devid As String) As Boolean
        On Error Resume Next
        ButtonX3.Enabled = False
        Dim db As New DataBaseConnection
        Dim NewDevId As Integer = db.executeSQL("SELECT * FROM `devices` WHERE `Name` = '" + CStr(TextBoxX1.Text) + "'")(0)(0)
        '  MsgBox(Me.User.UserName)
        Dim Dev As New Device(NewDevId, Me.User)

        Dev.DeviceOptions.SetSetting(Device.Options.SettingList.IsPlayStationDevice.ToString, CheckBoxItem1.Checked)
        Dev.DeviceOptions.SetSetting(Device.Options.SettingList.IsRoomDevice.ToString, CheckBoxItem2.Checked)
        Dev.DeviceOptions.SetSetting(Device.Options.SettingList.CanActive.ToString, CheckBoxItem3.Checked)
        'For Each CheckBox As DevComponents.DotNetBar.CheckBoxItem In ItemContainer5.SubItems
        '    Dim OptionName As String = CheckBox.Tag.ToString
        '    Dev.DeviceOptions.SetSetting(OptionName, CheckBox.Checked)

        'Next
        Me.PageSlider1.SelectedPage = PageSliderPage1
        Dev.DeviceOptions.SaveUpdateOptions()

        If Not Loaddevicesthrd.IsAlive Then
            Loaddevicesthrd = New Threading.Thread(AddressOf LoadDevices)
            Loaddevicesthrd.IsBackground = True
            Loaddevicesthrd.Start()
        End If


        _Main.PlayStationControlPanelTab.SystemPanel1.DeviceControlPanel1.Device_Handler.LoadDevices()

        If Not Dev.DeviceOptions.IsPlayStationDevice Then
            Dev.DeviceOptions.SetTabel()
        End If

        'Dim allsetting As String = ""
        'For Each DeviceOption As String In System.Enum.GetNames(GetType(Device.Options.SettingList))
        '    allsetting += DeviceOption + " : " + Dev.DeviceOptions.GetSetting(DeviceOption).ToString + vbNewLine
        'Next
        'MsgBox(allsetting)
    End Function
    Public Sub Reset(Optional ByVal ShowImage As Boolean = False)
        On Error Resume Next

        PictureBox1.Visible = ShowImage
        ButtonX3.Enabled = True
        ButtonX1.Enabled = True
        Me.CircularProgress2.Visible = False
        Me.LabelX1.Visible = True

    End Sub
    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click

        On Error Resume Next
        Dim DivType As Device.DeviceType = DirectCast(ComboBoxEx1.SelectedItem.Tag, Device.DeviceType)
        ButtonX3.Enabled = False
        ButtonX1.Enabled = False
        Me.CircularProgress2.IsRunning = True
        Me.CircularProgress2.Visible = True
        Me.LabelX1.Visible = True
        If Not TextBoxX1.Text = "" Then
            If ComboBoxEx1.Items.Count > 0 Then


                If Not DivType.Name = "" Then
                    If InsertDevice() Then
                        Me.LabelX1.Text = "Inserting Device Options.."
                        Me.PictureBox1.Image = My.Resources.tick_yes_approve_accept_green_64
                        Reset(True)
                        InserDevOptions(TextBoxX1.Text)
                    Else
                        Me.LabelX1.Text = "Failed To Insert Device Check Name And Type"
                        Me.PictureBox1.Image = My.Resources.caution_64
                        Reset(True)

                    End If
                Else
                    Me.LabelX1.Text = "Invalid Device Type"
                    Me.PictureBox1.Image = My.Resources.caution_64
                    Reset(True)
                End If
            Else
                Me.LabelX1.Text = "You Need To add Devices"
                Me.PictureBox1.Image = My.Resources.caution_64
                Reset(True)
            End If
        Else
            Me.LabelX1.Text = "Invalid Device name"
            Me.PictureBox1.Image = My.Resources.caution_64
            Reset(True)
        End If
        ' MsgBox(InsertDevice())
        'If InsertDevice() Then
        '    Me.LabelX1.Text = "Inserting Device Options.."
        'Else
        '    Me.LabelX1.Text = "Failed To Insert Device Check Name And Type"

        'End If
    End Sub

    Private Sub CheckBoxItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxItem2.Click

    End Sub
    ReadOnly Property SelectedButton As DevComponents.DotNetBar.ButtonItem
        Get
            Try
                For Each baseItem As DevComponents.DotNetBar.ButtonItem In ItemContainer1.SubItems
                    If baseItem.Checked Then
                        Return baseItem
                    End If
                Next
            Catch ex As Exception
                Return Nothing
            End Try
            ' Return Nothing
        End Get
    End Property

    ReadOnly Property SelectedDevice As Device
        Get
            If Not SelectedButton Is Nothing Then
                Return DirectCast(SelectedButton.Tag, Device)
            Else
                Return Nothing
            End If
        End Get
    End Property
    Private Sub CButton4_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CButton4.ClickButtonArea
        ''''//Confirm
        On Error Resume Next
        If Not SelectedDevice.Statue = Device.DeviceStatus.IsActive Then

            If MessageBox.Show("Are You Sure You Want To Delete Selected Device", "Deleting Device", MessageBoxButtons.OKCancel) = MsgBoxResult.Ok Then
                SelectedDevice.Delete()
                Me.ItemContainer1.SubItems.Remove(SelectedButton)
                Me.ItemContainer1.Refresh()
                ItemPanel1.Refresh()
                _Main.PlayStationControlPanelTab.SystemPanel1.DeviceControlPanel1.Device_Handler.LoadDevices()
            End If
        Else
            'Dim info As TaskDialogInfo = CreateTaskDialogInfo()
            'Dim result As eTaskDialogResult = TaskDialog.Show(info)

            MessageBox.Show("Selected Device IS Currently Active DisActive Device First !")

        End If

    End Sub

    Private Function CreateTaskDialogInfo() As TaskDialogInfo
        ' Dim com As New Command
        'AddHandler com.Executed (

        ' Dim info As New TaskDialogInfo("", CType(System.Enum.Parse(GetType(eTaskDialogIcon), eTaskDialogIcon.Bulb), eTaskDialogIcon), "", "", eTaskDialogButton.Ok, eTaskDialogBackgroundColor.Blue, Nothing, )
        ' Return info
    End Function
    Private Sub CButton3_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CButton3.ClickButtonArea
        PageSlider2.SelectedPageIndex = 1
    End Sub

    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        PageSlider2.SelectedPageIndex = 0
    End Sub
    Dim LoadAdvancedOptionsListLoaded = False
    Private Sub PageSlider1_SelectedPageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageSlider1.SelectedPageChanged
        'If Not LoadAdvancedOptionsListLoaded Then
        '    Dim thrd2 As Threading.Thread = New Threading.Thread(AddressOf LoadAdvancedOptionsList)
        '    thrd2.IsBackground = True
        '    thrd2.Start()
        '    LoadAdvancedOptionsListLoaded = True
        'End If




    End Sub
    Public Sub IntilizeHistory()
        On Error Resume Next


        Dim sql As String = "SELECT * FROM `deviceslog` WHERE `DeviceId` = '" + CStr(SelectedDevice.Id) + "' AND `InActive` LIKE 'false' AND Deleted='0' ORDER BY `EndDate` DESC LIMIT 15"

        Dim DataRowC As DataRowCollection = db.executeSQL(sql)

        'ItemContainer6.SubItems.Clear()
        'ItemContainer6.Refresh()

        DataGridViewX1.Rows.Clear()

        ' DataGridViewX1.Rows.AddRange 


        For Each Row As DataRow In DataRowC
            Dim Sdate As Date = Date.Parse(Row(2))

            Dim Enddate As Date = Date.Parse(Row(3))
            Dim spanDuration As TimeSpan = Enddate.Subtract(Sdate)
            Dim SinceDuration As TimeSpan = Date.Now.Subtract(Enddate)
            Dim TotalString = String.Format("{0} hour  {1} Minute", spanDuration.Hours, spanDuration.Minutes)
            Dim TotalStringSince = String.Format("{0} hour  {1} Minute", SinceDuration.Hours, SinceDuration.Minutes)

            Dim Drow As String() = New String() {Row(0), Row(2), TotalString, Row(6), Row(5), Row(17), Row(18), Row(10), SelectedDevice.Type.Name, TotalStringSince}
            ' DataGridViewX1.Rows.Add(row)






            DataGridViewX1.Rows.Add(Drow)


            '    Dim lblitem As DevComponents.DotNetBar.LabelItem = CType(LabelItem11.Clone, DevComponents.DotNetBar.LabelItem)
            '    lblitem.Visible = True
            '    ItemContainer6.SubItems.Add(lblitem)
            '    ItemContainer6.Refresh()

        Next
        DataGridViewX1.Update()

        'ItemContainer6.Refresh()
        'ItemContainer6.UpdateBindings()
        'Catch ex As Exception
        '    MsgBox("IntilizeHistory " + ex.Message)
        'End Try
    End Sub
    Public Sub SelectedDeviceChanged()
        Try


            IntilizeHistory()
        Catch ex As Exception
            LOG.[LOG](ex) '
        End Try
        'Dim thrd2 As Threading.Thread = New Threading.Thread(AddressOf IntilizeHistory)
        'thrd2.IsBackground = True
        'thrd2.Start()

    End Sub
    Private Sub ItemContainer1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemContainer1.Click

    End Sub
    Private Sub ItemContainer1_SubItemsChanged(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs) Handles ItemContainer1.SubItemsChanged
        On Error Resume Next

        '  If SelectedDevice.Statue = Device.DeviceStatus.IsActive Then
        'Dim sql As String = "SELECT * FROM `deviceslog` WHERE `DeviceId` = '" + CStr(SelectedDevice.Id) + "' AND `InActive` LIKE 'false' ORDER BY `EndDate` ASC"

        'Dim Row As DataRowCollection = db.executeSQL(sql)
        'IntilizeHistory(Row)

        'Me.Log_Id = CInt(Row(0))

        'Me.StartDate = Date.Parse(Row(2))



        'Me.Bill = CDbl(Row(5))

        'If CStr(Row(11)) = "(0)" Then
        '    Me.IsDeviceChanged = False
        'Else
        '    OldChangedDevicesIdData = CStr(Row(11))
        '    Me.IsDeviceChanged = True
        '    ' LoadOldChangedDevices()
        '    'MsgBox(OldChangedDevicesBill)
        'End If
        'Me.Is_PlayStationDevice = CBool(Row(8))

        'If Me.IsPlayStationDevice Then

        '    Me.Time_Limit = CInt(Row(7))
        '    Me.Time_Type = New Time(Me.Type.Id)

        'End If

        'If Not DeviceOptions.CanActive Then
        '    Me.CloseSesstion()
        'End If

        ''   If Not (Row(14).ToString = "none" OrElse CDbl(Row(14)) = 0.0) Then
        'If (Row(14).ToString.Contains(",")) Then
        '    Me.SetOffer(CDbl(Row(14).ToString.Split(",")(1)))
        'End If


        ''End If

        'If (Row(16).ToString.Contains(",")) Then
        '    Me.AdditinalBill = CInt(Row(16).ToString.Split(",")(0))
        '    Me.AdditinalBillInfo = CStr(Row(16).ToString.Split(",")(1))
        '    '  Me.AddAdditionalBill (CInt(Row(17).ToString.Split(",")(0)), CStr(Row(17).ToString.Split(",")(1))
        'End If
        'Me.ControllersCount = CInt(Row(15))
        '   End If
    End Sub

    Private Sub CButton5_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CButton5.ClickButtonArea
        On Error Resume Next
        Dim User As USER = User.GetActiveUser
        '  Dim sql As String = "DELETE FROM `deviceslog` WHERE `id` = '9.9' "
        Dim hp As New Helper

        For Each rw As DataGridViewRow In DataGridViewX1.SelectedRows
            ' Dim rwlog As New Device.DeviceLOG(rw.Cells(0).Value)
            '       sql += " OR `id` = '" + rw.Cells(0).Value + "'"
            hp.GlobalUpdate("deviceslog", "`Deleted`='1',`DeletedBy`='" + User.UserName + "'", "id", CStr(rw.Cells(0).Value))
        Next
        '  db.executeSQL(sql)
        IntilizeHistory()
    End Sub

    Private Sub CButton6_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CButton6.ClickButtonArea
        Try


            SelectedDevice.CheckActive()
            Dim Selectedid As String = CStr(DataGridViewX1.SelectedRows(0).Cells(0).Value)
            If Not DataGridViewX1.SelectedRows.Count > 1 Then
                If SelectedDevice.Statue = Device.DeviceStatus.Empty Then
                    Dim HP As New Helper()
                    Dim ReActive As Integer = Device.ReActiveLog(Selectedid)

                    If ReActive Then

                        _Main.PlayStationControlPanelTab.SystemPanel1.DeviceControlPanel1.Device_Handler.LoadDevices()
                        _Main.TabsHandler.FindAndSelectTab(frmMain.tabStrip1, SystemTabHandler.TabsType.PlayStationControlPanel)
                    End If
                Else
                    MsgBox("Device Is Already 'Active' With Another Log")
                End If
            Else
                MsgBox("Select Only One Log")

            End If
        Catch ex As Exception
            MsgBox("Faild To ReActive Log")
            LOG.[LOG](ex) '
            ' LOG.[LOG](ex) ' MsgBox(ex.StackTrace)
        End Try
    End Sub

    Private Sub CButton7_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CButton7.ClickButtonArea

    End Sub

    Private Sub DevicesControlerPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PageSlider2_SelectedPageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageSlider2.SelectedPageChanged
        On Error Resume Next

        If PageSlider2.SelectedPageIndex = 1 Then
            If Not SelectedDevice Is Nothing Then

                Me.TextBoxX2.Text = SelectedDevice.Name

                ComboBoxEx3.Items.Clear()


                For Each dev As Device.DeviceType In Device.DeviceType.GetDeviceTypes
                    '  MsgBox(dev.Name)
                    Dim combo As New DevComponents.Editors.ComboItem(dev.Name, Color.DarkGray)
                    combo.Tag = dev

                    ComboBoxEx3.Items.Add(combo)
                    If dev.Id = SelectedDevice.Type.Id Then

                        ' DeviceType_selecteditem = combo
                        ComboBoxEx3.SelectedItem = combo
                    End If
                Next



                'Me.TextBoxX1.Text = Me.Device.Name


            End If
        End If
    End Sub


    Private Sub ComboBoxEx3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxEx3.SelectedIndexChanged
        On Error Resume Next

        ComboBoxEx2.Items.Clear()
        Dim tim As New Time(DirectCast(ComboBoxEx1.SelectedItem.Tag, Device.DeviceType).Id.ToString, "")

        ' For Each Tim As Time In Time.GetTimeList
        '  MsgBox(dev.Name)
        Dim combo As New DevComponents.Editors.ComboItem(tim.ID.ToString + " | TimeByMinutes:" + CStr(tim.Miuntes) + " | Price:" + tim.Price.ToString, Color.DarkGray)
        combo.Tag = tim

        ComboBoxEx2.Items.Add(combo)
        '    If Tim.ID = Me.Device.TimeType.ID Then

        ' DeviceTime_selecteditem = combo
        ComboBoxEx2.SelectedItem = combo
    End Sub

    Private Sub ButtonX7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX7.Click
        Try


            If Not TextBoxX2.Text = "" Then
                If Not SelectedDevice Is Nothing Then
                    If Not SelectedButton Is Nothing Then

                        Try
                            SelectedDevice.Name = TextBoxX2.Text
                            Dim NewDv As Device.DeviceType = DirectCast(DirectCast(ComboBoxEx3.SelectedItem, DevComponents.Editors.ComboItem).Tag, Device.DeviceType)
                            SelectedDevice.Type = NewDv

                        Catch ex As Exception
                            LOG.[LOG](ex) ' MsgBox(ex.Message)
                            Exit Sub
                        End Try
                        PageSlider2.SelectedPage = PageSliderPage3

                        If SelectedDevice.UpdateDevice() Then
                            Try


                                If Not Loaddevicesthrd.IsAlive Then
                                    Loaddevicesthrd = New Threading.Thread(AddressOf LoadDevices)
                                    Loaddevicesthrd.IsBackground = True
                                    Loaddevicesthrd.Start()
                                End If


                                _Main.PlayStationControlPanelTab.SystemPanel1.DeviceControlPanel1.Device_Handler.LoadDevices()
                            Catch ex As Exception
                                LOG.[LOG](ex) '
                            End Try
                        End If


                    End If
                End If
            End If
        Catch ex As Exception
            LOG.[LOG](ex) ' MsgBox(ex.StackTrace)
        End Try
    End Sub

    Private Sub CheckBoxItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxItem1.Click

    End Sub
End Class