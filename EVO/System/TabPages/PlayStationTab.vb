

Public Class PlayStationTab
    Private DB As DataBaseConnection
    Public Sub New(ByVal m As frmMain)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.SystemPanel1.OrderHandler1.Enabled = CBool(m.LoginUser.CanAddSpecies)
        Me.SystemPanel1.SpeciesHandler1.ButtonItem2.Enabled = CBool(m.LoginUser.CanRemoveSpecies)
        'MsgBox("hjikhuk")
        'Dim s As New Device(2, DB)
        'MsgBox(s.CheckTableActive)
        Me.SystemPanel1.DeviceControlPanel1.Device_Handler.LoadDevices()

    End Sub
    Public Function CheckDB() As Boolean
        Dim DBCHECK As New DBConnectionChecker
        DBCHECK.ShowDialog()
        If DBCHECK.DialogResult = Windows.Forms.DialogResult.Yes Then
            DB = New DataBaseConnection
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub ShowLoadingImage()
        Me.Panel1.Show()
        Me.Panel1.BringToFront()
    End Sub
    Public Sub HideLoadingImage()
        Me.Panel1.Hide()
        Me.Panel1.SendToBack()
    End Sub
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CircularProgress1.IsRunning = True
        'Me.SystemPanel1.DeviceControlPanel1.Device_Handler.LoadDevices()
    End Sub

    
End Class