Public Class ChangedDevicesViewr
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub UpdateChangedDevices(ByVal Dv As Device)
        On Error Resume Next
        Me.DataGridViewX1.Rows.Clear()
        If Dv.Statue = Device.DeviceStatus.IsActive Then
            If Dv.IsChangedDevice Then
                Dv.LoadOldChangedDevices()
                For Each DvX In Dv.OldChangedDevices
                    If DvX.ChangedDeviceValued Then
                        '    MsgBox(DvX.Name)
                        Dim ChiledNode As Object() = New Object() {DvX.ORGDeviceID, DvX.Name, DvX.Bill.ToString, DvX.PlayStationBill.ToString, String.Format("{0}H|{1}M", DvX.DurationTime.Hours, DvX.DurationTime.Minutes), DvX.LogTotalbill.ToString}
                        Me.DataGridViewX1.Rows.Add(ChiledNode)
                    End If
                Next
                Me.FlatLabel8.Text = Dv.Name
                Me.FlatLabel12.Text = Dv.OldChangedDevices.Count.ToString
            Else
                Me.FlatLabel8.Text = Dv.Name
                Me.FlatLabel12.Text = "0"
                Me.Refresh()
                Me.Invalidate()
            End If
        Else
            Me.FlatLabel8.Text = Dv.Name
            Me.FlatLabel12.Text = "0"
            Me.Refresh()
            Me.Invalidate()
        End If

    End Sub
End Class
