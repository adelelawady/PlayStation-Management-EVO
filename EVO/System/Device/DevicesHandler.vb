Imports System.Threading

Public Class DevicesHandler
    Dim DB As New DataBaseConnection
    Public DeviceList As New List(Of DeviceControl1)
    Public Event DeviceSelectionChanged(ByVal sender As DeviceControl1)
    Public Event ItemClick(ByVal Item As DeviceControl1)
    Public Event ItemDoubleClick(ByVal Item As DeviceControl1)
    Public Event DevicesLoaded()
    Private trd As Thread
    Delegate Sub AddDeviceCallback(ByVal [Device] As DeviceControl1)
    Private DVCP As DeviceControlPanel
    Private usr As USER = Nothing

    Public Sub New(ByVal DvHandelr As DeviceControlPanel, ByVal USER As USER)
        ' usr = frmMain.LoginUser
        On Error Resume Next

        DVCP = DvHandelr
        usr = USER
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub
  
    Public Sub LoadDevices()
        On Error Resume Next
        frmMain.[ADDSTATUS]("[DEVICE] Loading Devices (%)")

        DVCP.Panel1.BringToFront()
        DVCP.Panel1.Visible = True
        LoadDevicesList()

    End Sub
    Private Sub LoadSqlData()
        ' On Error Resume Next
        Try
            Dim Sql As String = "SELECT * FROM `devices`"
            Dim Rows As DataRowCollection = DB.executeSQL(Sql)
        '  EffectualProgressBarBlue1.Maximum = Rows.Count
        '

        For Each DR As DataRow In Rows

            Add(DR(0))



        Next
        ''
            RaiseEvent DevicesLoaded()
        Catch ex As Exception
            LOG.[LOG](ex) ' MsgBox("LoadSqlData DVHandler: " + ex.Message)
        End Try

        'Me.PictureBox1.Visible = False
        'Me.PictureBox1.SendToBack()
        'EffectualProgressBarBlue1.SendToBack()
        'EffectualProgressBarBlue1.Visible = False
        'Me.Me.DVCP.MainControlTable1.TableLayoutPanel1 .BringToFront()

        'Catch ex As Exception
        '    LOG.[LOG](ex) ' MsgBox(ex.Message)
        '    'Me.PictureBox1.Image = My.Resources.caution_64
        '    'EffectualProgressBarBlue1.Visible = False
        'End Try
    End Sub
    Public Function LoadDevicesList() As Boolean
        On Error Resume Next

        If Not trd.IsAlive Then
            DeviceList.Clear()
            Me.DVCP.MainControlTable1.TableLayoutPanel1.Controls.Clear()

            'LoadSqlData()
            trd = New Thread(AddressOf LoadSqlData)
            trd.IsBackground = True
            trd.Start()

        End If


        Return True
    End Function
    Private currentDv As DeviceControl1

    Public Sub Add(ByVal tbid As Integer)
        Try


            Dim DV As Device = New Device(tbid, Me.usr)
            Dim c As New DeviceControl1(DV, Me.usr)

            If DeviceList.Count = 0 Then
                SelectionChanged(c)
            End If
            DeviceList.Add(c)
            With c
                ' Assign an auto generated name

                .Name = "item" & Me.DVCP.MainControlTable1.TableLayoutPanel1.Controls.Count + 1
                .Margin = New Padding(0)
            End With
            ' To check when the selection is changed
            AddHandler c.SelectionChanged, AddressOf SelectionChanged
            AddHandler c.Click, AddressOf ItemClicked
            AddHandler c.DoubleClick, AddressOf ItemDoubleClicked
            AddHandler c.SheduleOnse, AddressOf SheduleOnse
            AddHandler c.Device.OnOverTime, AddressOf DeviceOnTimeOver
            AddHandler c.DeviceSesstionUpdate, AddressOf SessionChanged
            'Dim Co As New Controler()
            'Co.intiData(c.Table)
            'c.StartDate = Co.StartDate
            currentDv = c
            Dim AddThrd As Thread = New Thread( _
        New ThreadStart(AddressOf Me.AddDevice))
            AddThrd.IsBackground = True

            AddThrd.Start()

            ' SetupAnchors()
        Catch ex As Exception
            '  MsgBox(ex.
            LOG.[LOG](ex)
        End Try

    End Sub
    Public Event SESSTION_CHANGED()
    Public Sub SessionChanged()
        RaiseEvent SESSTION_CHANGED()

        '        mLastSelected.Device

        frmMain.[ADDSTATUS]("[DEVICE] " + mLastSelected.Device.Name + " SESSTION CHANGING....")
        'End If

        ' mLastSelected.Device.InitializeData()
        'Dim sele As DeviceControl1 = mLastSelected
        'For i As Integer = 0 To DeviceList.Count

        '    If DeviceList(i).Device.Name = mLastSelected.Device.Name Then
        '        DeviceList(i) = New DeviceControl1(sele.Device, usr)
        '        SelectionChanged(DeviceList(i))
        '        Exit For
        '    End If
        'Next

    End Sub
    Public Sub SheduleOnse()
        On Error Resume Next

        For Each Dv As DeviceControl1 In DeviceList
            Dv.Responed = True
        Next
    End Sub
    Private Sub AddDevice()
        Me.AddTo(currentDv)
    End Sub
    Private Sub AddTo(ByVal [Device] As DeviceControl1)
        On Error Resume Next

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.DVCP.MainControlTable1.TableLayoutPanel1.InvokeRequired Then
            Dim d As New AddDeviceCallback(AddressOf AddTo)
            Me.DVCP.MainControlTable1.TableLayoutPanel1.Invoke(d, New Object() {[Device]})

        Else
        

            Me.DVCP.MainControlTable1.TableLayoutPanel1.Controls.Add([Device])
            [Device].Device.InitializeData()
            [Device].Device.[CheckActive]()
            frmMain.[ADDSTATUS]("Initializing [DEVICE] " + [Device].Device.Name)
        End If
    End Sub

  
    Public mLastSelected As DeviceControl1 = Nothing
    Private Sub SelectionChanged(ByVal sender As DeviceControl1)
        Try

       
        RaiseEvent DeviceSelectionChanged(sender)
        If mLastSelected IsNot Nothing Then
            mLastSelected.Selected = False
        End If
            mLastSelected = sender
            mLastSelected.Selected = True
            mLastSelected.Refresh()
        Catch ex As Exception
            LOG.[LOG](ex) '
        End Try
    End Sub
    Public Sub DeviceOnTimeOver(ByVal Dv As Device)
        On Error Resume Next
        '   If Dv.DeviceOptions.WarnMeLast10Minutes Then

        If Dv.DeviceOptions.WarnMeWithSound Then
            My.Computer.Audio.Play(My.Resources.Strange_Noise_SoundBible_com_229408508,
    AudioPlayMode.Background)
        End If

        If Dv.DeviceOptions.WarnMeWithNotifications Then
            NotificationManager.ShowNotifi(
       CType(frmMain.tabStrip1.SelectedTab.AttachedControl, PlayStationTab).SystemPanel1, "Device :'" + Dv.Name + "' Will End In " + Dv.RestTime.ToString, 2000)
        End If
        frmMain.ADDSTATUS("[Device] Device : '" + Dv.Name + "' Will End In " + Dv.RestTime.ToString)
        ' End If
    End Sub

    Private Sub ItemClicked(ByVal sender As Object, ByVal e As System.EventArgs)
      
        
        RaiseEvent ItemClick(mLastSelected)
        ' MsgBox(mLastSelected.Device.LogId)
     
        Try
            My.Computer.Audio.Stop()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub ItemDoubleClicked(ByVal sender As Object, ByVal e As System.EventArgs)
        RaiseEvent ItemDoubleClick(mLastSelected)


       
    

    End Sub

End Class
