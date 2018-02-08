Public Class UserPanel
    Dim CUSer As USER = Nothing
    Public Sub New(ByVal U As USER)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadUserSettings(U)
        If U.Admin Then
            ItemContainer6.Enabled = True
            CheckBoxItem23.Checked = True
            UpdateAdmin()
            U.SetAdmin()
        Else
            ItemContainer1.Enabled = False
            ItemContainer5.Enabled = False
            ButtonX2.Enabled = False
            ItemContainer6.Enabled = False
        End If
        CUSer = U
        LoadUsers()
        Me.TextBoxX1.Text = U.UserName
        Me.TextBoxX2.Text = U.Password
    End Sub
    Public Sub LoadUserSettings(ByVal U As USER)
        On Error Resume Next
        CheckBoxItem23.Checked = CBool(U.Admin)
        CheckBoxItem5.Checked = CBool(U.PlayStationTab)
        CheckBoxItem6.Checked = CBool(U.SpeciesControllerPanel)
        CheckBoxItem1.Checked = CBool(U.DeviceControlPanel)
        CheckBoxItem2.Checked = CBool(U.DeviceTypePanel)
        CheckBoxItem3.Checked = CBool(U.DeviceLogHistory)
        CheckBoxItem4.Checked = CBool(U.schdule)

        CheckBoxItem7.Checked = CBool(U.CanEditTotalBill)
        CheckBoxItem8.Checked = CBool(U.CanAddAdditionalCash)
        CheckBoxItem9.Checked = CBool(U.CanStartCloseSession)
        CheckBoxItem10.Checked = CBool(U.CanCreateDevice)
        CheckBoxItem11.Checked = CBool(U.CanDeleteDevice)
        CheckBoxItem15.Checked = CBool(U.CanAddTime)
        CheckBoxItem14.Checked = CBool(U.CanStartDeviceLog)
        CheckBoxItem12.Checked = CBool(U.CanUpdateDevice)
        CheckBoxItem13.Checked = CBool(U.CanDeleteDeviceLog)
        CheckBoxItem16.Checked = CBool(U.CanChangedDevice)

        CheckBoxItem17.Checked = CBool(U.CanAddSpecies)
        CheckBoxItem18.Checked = CBool(U.CanSetOffers)
        CheckBoxItem19.Checked = CBool(U.CanRemoveSpecies)
        CheckBoxItem20.Checked = CBool(U.CanUpdateStartTime)


        CheckBoxItem21.Checked = CBool(U.CanCreateSchedule)
        CheckBoxItem22.Checked = CBool(U.CanDeleteSchedule)
        ' CheckBoxItem23.Checked = Not CBool(U.Admin)
        UpdateAdmin()
        '  UpdateAdmin()
    End Sub
    Public Sub LoadUsers()
        On Error Resume Next
        ItemContainer7.SubItems.Clear()
        Dim db As New DataBaseConnection
        Dim sql As String = "SELECT * FROM `user`"
        Dim dr As DataRowCollection = db.executeSQL(sql)
        For Each dd As DataRow In dr
            If Not dd(1) = "abdo11" Then

                Dim lbl As New DevComponents.DotNetBar.ButtonItem(dd(1), dd(1))
                lbl.Tag = dd(1)
                '  lbl.BeginGroup = True
                lbl.OptionGroup = "Users"
                If CUSer.UserName = dd(1) Then
                    lbl.Checked = True
                Else
                    lbl.Checked = False
                End If
                AddHandler lbl.Click, AddressOf LoadUserSettingsX
                ItemContainer7.SubItems.Add(lbl)
            End If
        Next
        ItemContainer7.Refresh()
        ItemContainer6.Refresh()
        ItemContainer6.UpdateBindings()

    End Sub
    Public Sub LoadUserSettingsX(ByVal sender As Object, ByVal e As EventArgs)
        On Error Resume Next

        Dim User As USER = User.LoadFromSQL(DirectCast(sender, DevComponents.DotNetBar.ButtonItem).Tag)
        Me.CUSer = User
        Me.TextBoxX1.Text = CUSer.UserName
        Me.TextBoxX2.Text = CUSer.Password
        LoadUserSettings(User)
    End Sub
    Private Sub UserPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Public Sub SaveUserSettings(ByVal U As USER)
        On Error Resume Next

        U.PlayStationTab = CheckBoxItem5.Checked
        U.SpeciesControllerPanel = CheckBoxItem6.Checked
        U.DeviceControlPanel = CheckBoxItem1.Checked
        U.DeviceTypePanel = CheckBoxItem2.Checked
        U.DeviceLogHistory = CheckBoxItem3.Checked
        U.schdule = CheckBoxItem4.Checked

        U.CanEditTotalBill = CheckBoxItem7.Checked
        U.CanAddAdditionalCash = CheckBoxItem8.Checked
        U.CanStartCloseSession = CheckBoxItem9.Checked
        U.CanCreateDevice = CheckBoxItem10.Checked
        U.CanDeleteDevice = CheckBoxItem11.Checked
        U.CanAddTime = CheckBoxItem15.Checked
        U.CanStartDeviceLog = CheckBoxItem14.Checked
        U.CanUpdateDevice = CheckBoxItem12.Checked
        U.CanDeleteDeviceLog = CheckBoxItem13.Checked
        U.CanChangedDevice = CheckBoxItem16.Checked

        U.CanAddSpecies = CheckBoxItem17.Checked
        U.CanSetOffers = CheckBoxItem18.Checked
        U.CanRemoveSpecies = CheckBoxItem19.Checked
        U.CanUpdateStartTime = CheckBoxItem20.Checked


        U.CanCreateSchedule = CheckBoxItem21.Checked
        U.CanDeleteSchedule = CheckBoxItem22.Checked
        U.Admin = CheckBoxItem23.Checked


    End Sub
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        If (Not TextBoxX1.Text = "" And Not TextBoxX2.Text = "") Then
            If Not Me.CUSer Is Nothing Then
                CUSer.UserName = TextBoxX1.Text
                CUSer.Password = TextBoxX2.Text
                SaveUserSettings(CUSer)
                CUSer.SaveToSQL()
                If Me.CUSer.UserName = frmMain.LoginUser.UserName Then
                    frmMain.SetLogin(CUSer)
                End If
            Else
                MsgBox("SelectUserToUpdate")

            End If
        Else
            MsgBox("Invaild User Name Or Password")
        End If
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        If (Not TextBoxX1.Text = "" And Not TextBoxX2.Text = "") Then
            If USER.LoadFromSQL(TextBoxX1.Text) Is Nothing Then
                Dim Us As New USER
                Us.UserName = TextBoxX1.Text
                Us.Password = TextBoxX2.Text
                SaveUserSettings(Us)
                Us.SaveToSQL()
                Me.CUSer = Us
                LoadUsers()
            Else
                MsgBox("UserName Exsits Before")

            End If
           

        End If

    End Sub

    Private Sub CheckBoxItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxItem23.Click

        UpdateAdmin()
    End Sub
    Public Sub UpdateAdmin()
        On Error Resume Next

        If CheckBoxItem23.Checked Then
            CheckBoxItem5.Checked = True
            CheckBoxItem6.Checked = True
            CheckBoxItem1.Checked = True
            CheckBoxItem2.Checked = True
            CheckBoxItem3.Checked = True
            CheckBoxItem4.Checked = True
            CheckBoxItem7.Checked = True
            CheckBoxItem8.Checked = True
            CheckBoxItem9.Checked = True
            CheckBoxItem10.Checked = True
            CheckBoxItem11.Checked = True
            CheckBoxItem15.Checked = True
            CheckBoxItem14.Checked = True
            CheckBoxItem12.Checked = True
            CheckBoxItem13.Checked = True
            CheckBoxItem16.Checked = True
            CheckBoxItem17.Checked = True
            CheckBoxItem18.Checked = True
            CheckBoxItem19.Checked = True
            CheckBoxItem20.Checked = True
            CheckBoxItem21.Checked = True
            CheckBoxItem22.Checked = True

            CheckBoxItem23.Enabled = True
            ItemContainer1.Enabled = False
        Else
            ItemContainer1.Enabled = True


            ' LoadUserSettings(CUSer)
        End If
    End Sub
    Private Sub CheckBoxItem23_CheckedChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles CheckBoxItem23.CheckedChanged
        ' UpdateAdmin()
    End Sub

    Private Sub DeleteUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteUser.Click
        If CUSer.UserName = frmMain.LoginUser.UserName Then
            MsgBox(" You Can delete Current Active User LogOut First")
        Else
            Dim db As New DataBaseConnection
            Dim Rows As Integer = db.executeDMLSQL("DELETE FROM `user` WHERE `USER`='" + CUSer.UserName + "'")
            If Rows = 1 Then
                LoadUsers()
            End If
        End If
    End Sub
End Class