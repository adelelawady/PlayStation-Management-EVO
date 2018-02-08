Imports System.Threading

Public Class SpeciesHandler
    Dim DB As New DataBaseConnection
    Private Device As Device

    Public Event TableSelectionChanged(ByVal sender As Object)
    Public Event ItemClick(ByVal sender As Object, ByVal Index As Integer)
    Public Event ItemDoubleClick(ByVal sender As Object, ByVal Index As Integer)
    Public Event SpRemovedFromTable(ByVal sp As species)


    ' Public SpeciesList As New List(Of SpeciesControl)
  
    Private LastScrollValue As Integer = 0
    '  Private trd As Thread = Nothing
    ' Private _Species As New List(Of species)
    Delegate Sub AddDeviceCallback(ByVal [Device] As SpeciesControl)
    Private currentDv As SpeciesControl
    Public Sub New()

        InitializeComponent()
        Me.CircularProgress1.IsRunning = True
        Me.Dock = DockStyle.Fill
        ''   Me._TableControler = New Controler()


    End Sub
    Public Sub UpdateSPecies(ByVal TB As Device)
        '   On Error Resume Next
        Try

            Panel1.BringToFront()
            Device = TB
            DataGridViewX1.Rows.Clear()

            LoadSqlData()
            'AdvTree1.EndUpdate()
            '' If Device.Statue = EVO.Device.DeviceStatus.IsActive Then
            'If trd Is Nothing Then
            '    Panel1.BringToFront()
            '    Device = TB
            '    AdvTree1.Nodes.Clear()
            '    ' AdvTree1.BeginUpdate()
            '    trd = New Thread(AddressOf LoadSqlData)
            '    '  trd.IsBackground = True
            '    trd.Start()
            'Else

            '    If Not trd.IsAlive Then

            '        ' trd.Interrupt()
            '        Panel1.BringToFront()
            '        Device = TB
            '        AdvTree1.Nodes.Clear()
            '        '  AdvTree1.BeginUpdate()
            '        trd = New Thread(AddressOf LoadSqlData)
            '        '  trd.IsBackground = True
            '        trd.Start()
            '        ' LoadSqlData()
            '        'End If
            '    End If

            'End If

        Catch ex As Exception
            LOG.[LOG](ex) ' MsgBox(ex.StackTrace)
        End Try
    End Sub
    '   Dim MainLog As DevComponents.AdvTree.Node = Nothing
    Private Sub LoadSqlData()
        On Error Resume Next
        '  Try
        ' Try


        If Device.Statue = EVO.Device.DeviceStatus.IsActive Then
            ' Me.LastScrollValue = Me.flpListBox.VerticalScroll.Value
            '   Me.AlphaGradientPanel1.SuspendLayout()
            '   Me.SpeciesList.Clear()
            DataGridViewX1.Rows.Clear()
            '  flpListBox.Controls.Clear()
            Dim Sql As String = "SELECT `deviceslogdata`.`SpeciesId`,`deviceslogdata`.`id`,`deviceslogdata`.`Date` FROM `deviceslogdata` WHERE `deviceslogdata`.`LogId`='" + CStr(Device.LogId) + "'"
            'MsgBox(Device.Id)
            ' MsgBox(Sql)
            Dim DB As New DataBaseConnection
            Dim Rows As DataRowCollection = Nothing

            Rows = DB.executeSQL(Sql)
            ' If Rows.Count > 0 Then
            'MsgBox(Rows.Count + Device.Name)
            '  MainLog = New DevComponents.AdvTree.Node("[Device] : " + Device.Name + " | [Orders] : " + Rows.Count.ToString)

            '      Dim Rows As DataRowCollection = DB.executeSQL(Sql)

            For Each DR As DataRow In Rows

                Dim Sp As New species(DR(0))
                '   Dim LG As New DeviceLogData(DR(1))

                Sp.AddDate = Date.Parse(CStr(DR(2)))
                'Dim butoon As New DevComponents.DotNetBar.Controls.DataGridViewButtonXCell
                'butoon.h()
                ' Dim Drow As String() = New String() {Row(0), Row(2), TotalString, Row(6), Row(5), Row(17), Row(10)
                Dim ChiledNode As Object() = New Object() {Sp.Id, Sp.Name, Sp.Price, Sp.Type.Name}




                'ChiledNode.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("name"))
                'ChiledNode.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("Price"))
                'ChiledNode.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("Actions"))

                'Dim deletebut As New DevComponents.DotNetBar.ButtonItem("")
                'deletebut.Image = My.Resources.x_cross_delete_stop_16

                'Dim cellDelete As New DevComponents.AdvTree.Cell("")
                'cellDelete.HostedItem = deletebut
                '  ChiledNode.Cells.Add(cell)
                '  ChiledNode.Cells.Add(cellDelete)
                '  Me.Add(Sp)
                ' Me.AdvTree1.Nodes.Add(ChiledNode)
                Me.DataGridViewX1.Rows.Add(ChiledNode)
            Next

            '  Me.Device.SpeciesCount = Me.flpListBox.Controls.Count


            Me.FlatLabel12.Text = Rows.Count.ToString
            Me.FlatLabel8.Text = Device.Name
            '  Me.Refresh()
            ' flpListBox.VerticalScroll.Value = flpListBox.VerticalScroll.Maximum
            '    SetupAnchors()
            '  Me.AdvTree1.Nodes.Add(MainLog)
        Else
            'MainLog = New DevComponents.AdvTree.Node("[OfflineDevice] : " + Device.Name + " | [Orders] : " + 0)
            'Me.AdvTree1.Nodes.Add(MainLog)
        End If




1:      Panel1.SendToBack()
        'AdvTree1.BeginUpdate()
        'Catch ex As Exception
        '   LOG.[LOG](ex) ' MsgBox(ex.StackTrace)
        'End Try
    End Sub
    'Private Sub AddMainNode()
    '    If Not MainLog Is Nothing Then
    '        Me.AddToTree(MainLog)
    '    End If

    'End Sub
    'Delegate Sub AddDeviceCallbackX(ByVal NODE As DevComponents.AdvTree.Node)
    'Private Sub AddToTree(ByVal NODE As DevComponents.AdvTree.Node)

    '    ' InvokeRequired required compares the thread ID of the
    '    ' calling thread to the thread  of the creating thread.
    '    ' If these threads are different, it returns true.
    '    If Me.AdvTree1.InvokeRequired Then
    '        Dim d As New AddDeviceCallbackX(AddressOf AddToTree)

    '        AdvTree1.Invoke(d, New Object() {NODE})

    '        'Me.PanelEx2.Invoke(d, New Object() {[Device]})
    '        'Me.PanelEx1.Invoke(d, New Object() {[Device]})
    '    Else
    '        ''  Me.textBox1.Text = [Text]
    '        '[Device].Refresh()
    '        'MsgBox("success")

    '        Me.AdvTree1.Nodes.Add(NODE)

    '        ' EffectualProgressBarBlue1.Value += 1

    '    End If
    'End Sub
    ''Private Sub AddDevice()
    '    Me.AddTo(currentDv)
    'End Sub
    'Private Sub AddTo(ByVal [Device] As SpeciesControl)
    '    On Error Resume Next
    '    ' InvokeRequired required compares the thread ID of the
    '    ' calling thread to the thread ID of the creating thread.
    '    ' If these threads are different, it returns true.
    '    If Me.flpListBox.InvokeRequired Then
    '        Dim d As New AddDeviceCallback(AddressOf AddTo)
    '        flpListBox.Invoke(d, New Object() {[Device]})

    '    Else
    '        ''  Me.textBox1.Text = [Text]
    '        '[Device].Refresh()

    '        flpListBox.Controls.Add([Device])

    '        ' EffectualProgressBarBlue1.Value += 1
    '    End If
    'End Sub
    'Dim cXX As Integer = 0
    'Public Sub Add(ByVal sp As species)
    '    On Error Resume Next

    '        Dim c As New SpeciesControl(sp)
    '    If cXX = 0 Then
    '        SelectionChanged(c)
    '        cXX = 1
    '    End If
    '        currentDv = c
    '    'SpeciesList.Add(c)
    '        With c
    '            ' Assign an auto generated name

    '            .Name = "item" & flpListBox.Controls.Count + 1
    '            .Margin = New Padding With {.Bottom = 1, .Top = 1}
    '        End With
    '        ' To check when the selection is changed

    '        AddHandler c.Click, AddressOf ItemClicked
    '        AddHandler c.DoubleClick, AddressOf ItemDoubleClicked
    '        AddHandler c.SelectionChanged, AddressOf SelectionChanged
    '        AddHandler c.SPRemoved, AddressOf SpDeleted
    '        '  AddHandler c.LogInLabel1.Click, AddressOf ItemClicked

    '        Dim AddThrd As Thread = New Thread( _
    '  New ThreadStart(AddressOf Me.AddDevice))

    '        AddThrd.Start()
    '        '  flpListBox.Controls.Add(c)

    '        '      SetupAnchors()
    '        System.Windows.Forms.Application.DoEvents()
    '        Me.flpListBox.VerticalScroll.Value = Me.flpListBox.VerticalScroll.Maximum
    '        Me.flpListBox.PerformLayout()
    '    Me.FlatLabel8.Text = Device.Name
    '    Me.FlatLabel12.Text = Me.flpListBox.Controls.Count

    'End Sub

    Public Sub SpDeleted(ByVal sp As species)
        '  Try

        RaiseEvent SpRemovedFromTable(sp)
        'For Each spcontrol As SpeciesControl In Me.SpeciesList

        '        If spcontrol.Controlspecies.Id = sp.Id Then

        '            SpeciesList.Remove(spcontrol)
        '            Me.flpListBox.Controls.Remove(spcontrol)
        '            Me.Refresh()
        '            Exit For
        '        End If
        'Next
        Me.Device.RemoveSpecies(sp.Id)


        'System.Windows.Forms.Application.DoEvents()
        '    Me.flpListBox.VerticalScroll.Value = Me.flpListBox.VerticalScroll.Maximum
        '    Me.flpListBox.PerformLayout()
        'Catch ex As Exception
        '    LOG.[LOG](ex) ' MsgBox(ex.Message)
        'End Try

    End Sub
    'Private Sub SetupAnchors()

    '    On Error Resume Next
    '        If flpListBox.Controls.Count > 0 Then

    '            For i = 0 To flpListBox.Controls.Count - 1
    '                Dim c As Control = flpListBox.Controls(i)

    '                If i = 0 Then

    '                    c.Anchor = AnchorStyles.Left + AnchorStyles.Top


    '                    c.Width = flpListBox.Width - System.Windows.Forms.SystemInformation.VerticalScrollBarWidth

    '                Else

    '                    c.Anchor = AnchorStyles.Left + AnchorStyles.Right
    '                    c.Width = flpListBox.Width
    '                End If

    '            Next

    '        End If

    'End Sub

    'Private Sub flpListBox_Resize(ByVal sender As Object, ByVal e As System.EventArgs)
    '    On Error Resume Next
    '    SetupAnchors()

    'End Sub

    Public mLastSelected As SpeciesControl = Nothing
    Private Sub SelectionChanged(ByVal sender As Object)
        On Error Resume Next
        RaiseEvent TableSelectionChanged(sender)
        If mLastSelected IsNot Nothing Then
            mLastSelected.Selected = False
        End If
        mLastSelected = sender
        mLastSelected.Selected = True
        mLastSelected.Refresh()
    End Sub

    'Private Sub ItemClicked(ByVal sender As Object, ByVal e As System.EventArgs)
    '    RaiseEvent ItemClick(Me, flpListBox.Controls.IndexOfKey(sender.name))
    '    Try

    '    Catch ex As Exception

    '    End Try


    'End Sub
    'Private Sub ItemDoubleClicked(ByVal sender As Object, ByVal e As System.EventArgs)
    '    RaiseEvent ItemDoubleClick(Me, flpListBox.Controls.IndexOfKey(sender.name))

    '    Try

    '    Catch ex As Exception

    '    End Try


    'End Sub
   
    'Private Sub flpListBox_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
    '    Me.LastScrollValue = e.NewValue
    'End Sub

    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

    'End Sub

    'Private Sub FlatLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatLabel1.Click

    'End Sub

    'Private Sub flpListBox_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    'End Sub

    Private Sub FlatLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ButtonItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem2.Click
        On Error Resume Next


        Dim Gridrow As String = Me.DataGridViewX1.SelectedRows(0).Cells(0).Value
        Me.Device.RemoveSpecies(Gridrow)

        LoadSqlData()
        Me.Device.ControlDevice.UpdateRefresh()
        Me.DataGridViewX1.Refresh()
        Me.DataGridViewX1.Update()
    End Sub
End Class
