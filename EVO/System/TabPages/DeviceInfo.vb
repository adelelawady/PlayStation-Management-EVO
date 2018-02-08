Public Class DeviceInfo
    Private M_Device As Device
    ReadOnly Property Device As Device
        Get
            Return M_Device
        End Get
    End Property
    Private _Main As frmMain

    Dim DeviceType_selecteditem As DevComponents.Editors.ComboItem
    Dim DeviceTime_selecteditem As DevComponents.Editors.ComboItem
    Public Sub New(ByVal M As frmMain, ByVal Dev As Device)

        ' This call is required by the designer.
        InitializeComponent()
        _Main = M
        ' Add any initialization after the InitializeComponent() call.
        M_Device = Dev
        LoadDeviceInfoPanel()
    End Sub
    
    Private Sub BubbleButton1_Click(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.ClickEventArgs) Handles BubbleButton1.Click
        On Error Resume Next

        Me.PageSlider1.SelectedPageIndex = 0
    End Sub

    Private Sub BubbleButton3_Click(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.ClickEventArgs) Handles BubbleButton3.Click
        Me.PageSlider1.SelectedPageIndex = 1
    End Sub

    Private Sub DeviceInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CircularProgress1.IsRunning = True
        'Me.Panel1.BringToFront()
    End Sub
    Public Sub LoadDeviceInfoPanel()
        Me.TextBoxX1.Text = Me.Device.Name

        ComboBoxEx1.Items.Clear()

      
        For Each dev As Device.DeviceType In Device.DeviceType.GetDeviceTypes
            '  MsgBox(dev.Name)
            Dim combo As New DevComponents.Editors.ComboItem(dev.Name, Color.DarkGray)
            combo.Tag = dev

            ComboBoxEx1.Items.Add(combo)
            If dev.Id = Me.Device.Type.Id Then

                DeviceType_selecteditem = combo
                ComboBoxEx1.SelectedItem = combo
            End If
        Next
      
       

        'Me.TextBoxX1.Text = Me.Device.Name

    End Sub

    Private Sub ComboBoxEx2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxEx2.SelectedIndexChanged
        On Error Resume Next
        Dim TimeType As Time = DirectCast(ComboBoxEx2.SelectedItem.tag, Time)

        Me.LabelX4.Text = String.Format("Minutes : {0}" + vbNewLine + "MinutesPrice : {1}" + vbNewLine + "[OneMinutePrice] : {2}", TimeType.Miuntes.ToString, TimeType.Price.ToString, TimeType.MiuntesPrice.ToString)



    End Sub

    Private Sub ComboBoxEx1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxEx1.SelectedIndexChanged
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
            '    End If
            'Next
        Else
            ComboBoxEx2.Items.Add("TABLE")
            ComboBoxEx2.SelectedIndex = 0
        End If

    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        Try


            If Not TextBoxX1.Text = "" Then
                If Not Device Is Nothing Then
                    If Not Device Is Nothing Then

                        Try
                            Device.Name = TextBoxX1.Text
                            Dim NewDv As Device.DeviceType = DirectCast(DirectCast(ComboBoxEx1.SelectedItem, DevComponents.Editors.ComboItem).Tag, Device.DeviceType)
                            Device.Type = NewDv
                            If Device.Type.Id = 0 Then
                                Device.DeviceOptions.IsPlayStationDevice = False
                                Device.DeviceOptions.SaveUpdateOptions()
                            End If
                        Catch ex As Exception
                            LOG.[LOG](ex) ' MsgBox(ex.Message)
                            Exit Sub
                        End Try
                        
                        If Device.UpdateDevice() Then
                            Try
                                _Main.PlayStationControlPanelTab.SystemPanel1.DeviceControlPanel1.Device_Handler.LoadDevices()
                            Catch ex As Exception

                            End Try
                        End If


                    End If
                End If
            End If
        Catch ex As Exception
            LOG.[LOG](ex) ' MsgBox(ex.StackTrace)
        End Try
    End Sub
End Class