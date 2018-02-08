Public Class SystemHandler
    Private M_SystemPanel As SystemPanel
    Private IsChangingDevice As Boolean = False
    Private DeviceToBeChanged As DeviceControl1 = Nothing
    Public Sub New(ByVal SYSPNL As SystemPanel)
        On Error Resume Next
        M_SystemPanel = SYSPNL
        AddHandler M_SystemPanel.SpAddedToDevice, AddressOf Specis_Added
        AddHandler M_SystemPanel.DeviceSelectionChanged, AddressOf DeviceSelectionChanged
        AddHandler M_SystemPanel.SpDeletedFromDevice, AddressOf Species_deleted
        AddHandler M_SystemPanel.ItemClick, AddressOf ItemClicked
        ' AddHandler M_SystemPanel.DeviceControlPanel1.Device_Handler.SESSTION_CHANGED, AddressOf DeviceSesstionChanged
        M_SystemPanel.UserShiftViewer1.LoadUserShift()
    End Sub
    Public Sub Specis_Added(ByVal Item As species)
        ' MsgBox(Item.Name)
        On Error Resume Next

        Dim dv As Device = Me.M_SystemPanel.SelectedDV.Device
        dv.addSpecies(Item.Id)

        M_SystemPanel.SpeciesHandler1.UpdateSPecies(dv)
        OnAction()
        frmMain.ADDSTATUS("  الطلبات " + Item.Name + " الي الجهاز " + dv.Name)
    End Sub
    Public Sub ChangeDevice()
        On Error Resume Next
        frmMain.ADDSTATUS("اختر جهاز")
        If Me.M_SystemPanel.SelectedDV.Device.Statue = Device.DeviceStatus.IsActive Then
            DeviceToBeChanged = Me.M_SystemPanel.SelectedDV
            IsChangingDevice = True
            For Each DVC As DeviceControl1 In Me.M_SystemPanel.DeviceControlPanel1.Device_Handler.DeviceList
                If Not DVC.Device.Id = Me.M_SystemPanel.SelectedDV.Device.Id Then
                    If DVC.Device.Statue = Device.DeviceStatus.Empty Then
                        DVC.CanChangeDevice = True
                        DVC.Refresh()
                    Else
                        DVC.Enabled = False
                    End If
                End If
            Next
        End If
    End Sub

    Public Sub ItemClicked(ByVal DvC As DeviceControl1)
        On Error Resume Next
        If IsChangingDevice Then
            For Each DVCC As DeviceControl1 In Me.M_SystemPanel.DeviceControlPanel1.Device_Handler.DeviceList
                DVCC.CanChangeDevice = False
                DVCC.Enabled = True
                DVCC.Refresh()
              Next
            IsChangingDevice = False
            DeviceToBeChanged.Device.ChangeDevice(DvC)
            Me.M_SystemPanel.DeviceControlPanel1.Device_Handler.LoadDevices()
            'ChangeDevice
            ' DvC.Refresh()
            DeviceSelectionChanged()
        End If
    End Sub
    Public Sub Species_deleted(ByVal sp As species)
        On Error Resume Next

        Dim dv As Device = Me.M_SystemPanel.SelectedDV.Device
        'dv.RemoveSpecies(sp.Id)
        Me.M_SystemPanel.SpeciesHandler1.UpdateSPecies(dv)
        OnAction()
        frmMain.ADDSTATUS("طلبات  " + sp.Name + " حذف من جهاز " + dv.Name)
    End Sub
    'Public Sub DeviceSesstionChanged()
    '    On Error Resume Next
    '    MsgBox("jjj:")


    'End Sub
    Public Sub DeviceSelectionChanged()
        '  On Error Resume Next
        On Error Resume Next

            Dim dv As Device = Me.M_SystemPanel.SelectedDV.Device

            M_SystemPanel.SpeciesHandler1.UpdateSPecies(dv)
            UpdateMainFormStart_timeRippon()


            M_SystemPanel.ChangedDevicesViewr1.UpdateChangedDevices(dv)



            '  Me.M_SystemPanel.TimeControl1.InitializeDevice(Me.M_SystemPanel.SelectedDV)
    End Sub
    Public Sub UpdateMainFormStart_timeRippon()
        On Error Resume Next

        'frmMain.StartTimeRibbon.Tag = Me.M_SystemPanel.SelectedDV.Device
        'frmMain.ButtonItem39.Text = CStr(Me.M_SystemPanel.SelectedDV.Device.StartDate.Hour)

    End Sub
    Public Sub OnAction()
        On Error Resume Next
        M_SystemPanel.DeviceControlPanel1.Device_Handler.mLastSelected.Refresh()
    End Sub

End Class
