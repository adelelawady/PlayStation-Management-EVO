Public Class SystemPanel
    Public SelectedDV As DeviceControl1
    Public Event DeviceSelectionChanged(ByVal sender As Object)
    Public m_SystemHandler As New SystemHandler(Me)
    Public Event SpAddedToDevice(ByVal Item As species)
    Public Event SpDeletedFromDevice(ByVal Item As species)
    Public Event ItemClick(ByVal Item As DeviceControl1)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        AddHandler OrderHandler1.SpeciesList1.SpAddedToDevice, AddressOf Specis_Added
        AddHandler SpeciesHandler1.SpRemovedFromTable, AddressOf Specis_Deleted
        AddHandler Me.DeviceControlPanel1.Device_Handler.DeviceSelectionChanged, AddressOf SelectionChanged
        AddHandler Me.DeviceControlPanel1.Device_Handler.ItemClick, AddressOf DeviceClicked
        AddHandler Me.DeviceControlPanel1.Device_Handler.SESSTION_CHANGED, AddressOf DeviceSesstionChanged
        ' Add any initialization after the InitializeComponent() call.
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.CircularProgress1.IsRunning = True
        DeviceSesstionChanged()

        IsLoading(True)
    End Sub
    Public Sub DeviceClicked()
        RaiseEvent ItemClick(SelectedDV)
    End Sub
    Private Sub SelectionChanged(ByVal sender As Object)
        SelectedDV = sender
        RaiseEvent DeviceSelectionChanged(sender)
    End Sub
    Public Sub Specis_Added(ByVal Item As species)
        RaiseEvent SpAddedToDevice(Item)

    End Sub
    Public Sub Specis_Deleted(ByVal Item As species)
        RaiseEvent SpDeletedFromDevice(Item)

    End Sub
    Public Sub DeviceSesstionChanged()
        On Error Resume Next
        ' MsgBox("hi")
        UserShiftViewer1.LoadUserShift()
    End Sub
    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    SelectedDV.UpdateActive()
    'End Sub

    Private Sub ExpandablePanel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub OrderHandler1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrderHandler1.Load

    End Sub

    Private Sub SplitContainer2_Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub
    Public Sub IsLoading(ByVal Visible As Boolean)
        If Visible Then
            'Me.SplitContainer1.Visible = False
            Me.Panel1.BringToFront()
        Else
            'Me.SplitContainer1.Visible = True
            Me.Panel1.SendToBack()
        End If
    End Sub

    Private Sub SystemPanel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '  IsLoading(True)
    End Sub


    Private Sub SystemPanel_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

    End Sub

    Private Sub SplitContainer1_Panel2_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SystemPanel_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        IsLoading(False)
        'Me.DeviceControlPanel1.Device_Handler.LoadDevices()
        Timer1.Stop()

    End Sub

End Class
