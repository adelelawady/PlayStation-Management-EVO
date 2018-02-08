Public Class DevicesTypeController

    Private Sub DevicesTypeController_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadTypes()
    End Sub
    Dim DeviceType_selecteditem As DevComponents.Editors.ComboItem
    Dim DeviceTime_selecteditem As DevComponents.Editors.ComboItem
    Public Sub LoadTypes()
        On Error Resume Next

        ComboBoxEx1.Items.Clear()
        For Each dev As Device.DeviceType In Device.DeviceType.GetDeviceTypes
            '  MsgBox(dev.Name)
            Dim combo As New DevComponents.Editors.ComboItem(dev.Name, Color.DarkGray)
            combo.Tag = dev

            ComboBoxEx1.Items.Add(combo)

        Next
        If ComboBoxEx1.Items.Count > 0 Then
            ComboBoxEx1.SelectedIndex = 0
        End If
        'LoadTimeRoles()
    End Sub
    Public Sub LoadTimeRoles()
        '   On Error Resume Next

        GalleryContainer1.SubItems.Clear()
        Dim tim As New Time(DirectCast(ComboBoxEx1.SelectedItem.Tag, Device.DeviceType).Id.ToString, "")

        For Each tim_role As Time.TimeRole In tim.TimeRols
            ' MsgBox(tim_role.ID)
            '  MsgBox(dev.Name)
            Dim combo As New DevComponents.DotNetBar.CheckBoxItem(tim_role.ID, tim_role.Name.ToString + " [ MinutesStart:" + CStr(tim_role.MinutesStart) + "  > MinutesEnd:" + tim_role.MinutesEnd.ToString + "]")
            combo.TextColor = Color.Black
            combo.Enabled = True
            combo.Checked = False
            combo.Tag = tim_role

            GalleryContainer1.SubItems.Add(combo)
        Next
        GalleryContainer1.Refresh()
    End Sub

    Private Sub ComboBoxEx1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxEx1.SelectedIndexChanged
        On Error Resume Next

        ComboBoxEx2.Items.Clear()
        If Not DirectCast(ComboBoxEx1.SelectedItem.Tag, Device.DeviceType).Id = 0 Then


            Dim tim As New Time(DirectCast(ComboBoxEx1.SelectedItem.Tag, Device.DeviceType).Id.ToString, "")

            ' For Each Tim As Time In Time.GetTimeList
            '  MsgBox(dev.Name)
            Dim combo As New DevComponents.Editors.ComboItem(tim.ID.ToString + " | TimeByMinutes:" + CStr(tim.Miuntes) + " | Price:" + tim.Price.ToString, Color.DarkGray)
            combo.Tag = tim

            ComboBoxEx2.Items.Add(combo)
            '    If Tim.ID = Me.Device.TimeType.ID Then

            DeviceTime_selecteditem = combo
            ComboBoxEx2.SelectedItem = combo
            Me.LabelX4.Text = String.Format("Minutes : {0}" + vbNewLine + "MinutesPrice : {1}" + vbNewLine + "[OneMinutePrice] : {2}", tim.Miuntes.ToString, tim.Price.ToString, tim.MiuntesPrice.ToString)
        Else
            ComboBoxEx2.Items.Add("TABLE")
            ComboBoxEx2.SelectedIndex = 0
            Me.LabelX4.Text = String.Format("Minutes : {0}" + vbNewLine + "MinutesPrice : {1}" + vbNewLine + "[OneMinutePrice] : {2}", "NONE", "NONE",  "NONE")
        End If
    End Sub


    Private Sub ComboBoxEx2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxEx2.SelectedIndexChanged
        LoadTimeRoles()
    End Sub

    Private Sub CButton2_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CButton2.ClickButtonArea
        Dim pop As New NewDeviceTypePOPUP
        pop.ShowDialog()
        If pop.DialogResult = Windows.Forms.DialogResult.OK Then
            LoadTypes()
        End If
    End Sub

    Private Sub CButton4_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CButton4.ClickButtonArea
        On Error Resume Next
        DirectCast(ComboBoxEx2.SelectedItem.Tag, Time).DeleteTime()
        DirectCast(ComboBoxEx1.SelectedItem.Tag, Device.DeviceType).Delete()

        LoadTypes()
    End Sub
End Class