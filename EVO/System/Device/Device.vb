Imports System.Threading
Imports System.Runtime.InteropServices
Imports Microsoft.Win32.SafeHandles


Public Class Device
    '  Implements IDisposable

    Dim disposed As Boolean = False
    ' Instantiate a SafeHandle instance.

    Private DBHelper As Helper
    Enum DeviceStatus
        IsActive
        Empty
    End Enum
    '' Public implementation of Dispose pattern callable by consumers.
    'Public Sub Dispose() _
    '           Implements IDisposable.Dispose
    '    Dispose(True)
    '    GC.SuppressFinalize(Me)
    'End Sub

    '' Protected implementation of Dispose pattern.
    'Protected Overridable Sub Dispose(ByVal disposing As Boolean)
    '    If disposed Then Return

    '    If disposing Then

    '        ' Free any other managed objects here.
    '        '
    '    End If

    '    ' Free any unmanaged objects here.
    '    '
    '    disposed = True
    'End Sub


    Private DeviceID As Integer
    Private DeviceName As String
    Private Device_Type As DeviceType
    Private DeviceRowOptionsString As String
    Public NextSchedule As ScheduleObject = Nothing
    Private _Options As Options
    Public _Statue As DeviceStatus
    Public DB As New DataBaseConnection
    Public Schedules As New List(Of ScheduleObject)
    Private usr As USER = Nothing
    Public Sub New(ByVal DeviceId As Integer, ByVal ur As USER)
        Try


            usr = ur
            ' MsgBox(usr.UserName)
            DBHelper = New Helper()

            Dim sql As String = "SELECT * FROM `devices` WHERE `id` = '" + CStr(DeviceId) + "'"

            Dim Row As DataRow = DB.executeSQL(sql)(0)
            Me.DeviceID = DeviceId
            Me.DeviceName = Row(1).ToString
            Me.Device_Type = New Device.DeviceType(CInt(Row(2)))
            If Not CInt(Row(2)) = 0 Then
                Me.Is_PlayStationDevice = False
            End If


            Me.DeviceRowOptionsString = Row(3).ToString

            _Options = New Options(Me)
            ' Application.DoEvents()
            If _Options.IsPlayStationDevice Then
                If Not CInt(Row(2)) = 0 Then
                    Me.Is_PlayStationDevice = True
                Else
                    Me.Is_PlayStationDevice = False
                    _Options.IsPlayStationDevice = False
                    _Options.SaveUpdateOptions()
                End If

            Else
                Me.Is_PlayStationDevice = False
            End If
            ' InitializeData()
            SetOffer(0)
            [CheckActive]()

            UpdateSchedules()
        Catch ex As Exception
            LOG.LOG(ex)
        End Try
    End Sub
    Dim ScheduleThreads As Threading.Thread
    Public Sub UpdateSchedules()
        On Error Resume Next
        UpdateScheduleThreads()
        'If Not ScheduleThreads.IsAlive Then

        '    ScheduleThreads = New Threading.Thread(AddressOf UpdateScheduleThreads)
        'End If

    End Sub

    Public Sub UpdateScheduleThreads()
        On Error Resume Next

        Me.Schedules = ScheduleObject.GetTodayDeviceSchedules(Me.Id)
        '  MsgBox(Me.Schedules.Count)
    End Sub
    Public Sub ShutDownSchedules()

    End Sub
    Public Function CheckScheduleOnDeviceLog(ByVal schid As String) As Boolean
        On Error Resume Next

        Dim dbX As New DataBaseConnection
        Dim sql = "SELECT * FROM `deviceslog` WHERE `SheduleID`='" + schid + "' LIMIT 1"
        If dbX.executeSQL(sql).Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function CheckSchedules() As ScheduleObject
        Me.UpdateSchedules()
        Dim Canbool As ScheduleObject = Nothing
        For Each sch As ScheduleObject In Me.Schedules
            If sch.IsWarning Or sch.IsActive Then
                ' MsgBox(sch.ObjectName)
                If Not CheckScheduleOnDeviceLog(sch.ID) Then
                    Canbool = sch
                    Exit For
                End If
              
            Else
                Canbool = Nothing
            End If
        Next
        Return Canbool
    End Function

    ReadOnly Property DeviceOptions As Options
        Get
            Return _Options
        End Get
    End Property
    Property RowOptionsString As String
        Set(ByVal value As String)
            DeviceRowOptionsString = value
        End Set
        Get
            Return DeviceRowOptionsString
        End Get
    End Property
    ReadOnly Property Id As Integer
        Get
            Return (Me.DeviceID)
        End Get
    End Property
    ReadOnly Property Statue As DeviceStatus
        Get
            ' CheckActive()
            Return _Statue

        End Get
    End Property
    Property Name As String
        Set(ByVal value As String)
            Me.DeviceName = value
        End Set
        Get
            Return Me.DeviceName
        End Get
    End Property
    Property Type As DeviceType
        Set(ByVal value As DeviceType)
            Me.Device_Type = value
        End Set
        Get
            Return Me.Device_Type
        End Get
    End Property
    Public Function [CheckActive]() As Boolean
        On Error Resume Next
        'If Me.GetWithLogID Then
        '    Me._Statue = DeviceStatus.IsActive
        '    Return True

        'Else
        Dim Sql As String = "SELECT * FROM `deviceslog` WHERE `DeviceId` ='" + CStr(Me.Id) + "' AND `InActive` LIKE 'true'"
        Dim res As Integer = DB.executeSQL(Sql).Count
        If (res >= 1) Then
            Me._Statue = DeviceStatus.IsActive
            Return True
        Else
            Me._Statue = DeviceStatus.Empty
            Return False

        End If
        ' End If
    End Function
    Public Shared Function InsertDevice(ByVal TabelName As String, ByVal TabelType As String) As Integer

        Dim DBHelperIns As New Helper()
        Return DBHelperIns.GlobalInsert("devices", "`id`, `Name`, `Type`", "NULL, '" + TabelName + "', '" + CStr(TabelType) + "'")
    End Function
    Public Function Delete()
        Return DBHelper.GlobalDelete("devices", "id", CStr(Me.Id))
    End Function
    Public Function UpdateDevice() As Integer
        Return Me.DBHelper.GlobalUpdate("devices", "`Name`='" + Me.Name + "',`Type`='" + CStr(Me.Type.Id) + "'", "id", CStr(Me.Id))
    End Function
#Region "DeviceControler"
    '///////////////////////////////PlayStaion/////////////////////////
    Private Is_PlayStationDevice As Boolean = True
    Private Time_Limit As Integer = 0  'miuntes   // 0=open
    Private Passed_Time As TimeSpan
    Private Play_StationBill As Double
    Private Time_Type As Time
    Public Event OnOverTime(ByVal Device As Device)
    Private Total_Bill As Double = 0
    Private Additinal_Bill As Double = 0
    Private Additinal_Bill_Info As String = ""
    Private SpectialOffer As New offer

    Private Paid_Bill As Integer = 0
    Private Controllers_Count As Integer = 0

    '  Private IsDeviceChanged As Boolean = False
    Private IsDeviceChanged As Boolean = False
    Private ChangedDevicesBill As Double = 0
    Private ChangedFromDevice As New List(Of DeviceLOG)

    Private OldChangedDevicesIdData As String = ""
    Private Log_Id As Integer
    Private Start_Date As Date
    Private End_Date As Date
    Private _Bill As Double
    Private _SpeciesOrderCheck As String
   
    Private Time_Data As DeviceLogData()
    '   Private _Species As New List(Of species)
    Public ControlDevice As DeviceControl1 = Nothing
    Private CorrentLoadedSpeciesCount As Integer = 0
    Public isSheduled As Boolean = False
    Public isNEXTSheduleding As Boolean = False
    Public Event SesstionStarted()
    Public Event SpeciesLoaded()
    Public Event SesstionClosed()
    Public Event DeviceChanged()
    Dim InitializeThread As Thread = Nothing
    Public Sub InitializeData()
        On Error Resume Next
        If Not InitializeThread.IsAlive Then
            InitializeThread = New Thread( _
    New ThreadStart(AddressOf Me.InitializeDataByThread))
            InitializeThread.IsBackground = True
            InitializeThread.Start()
        End If
    End Sub
    'Public Sub InitializeData(ByVal HistoryLogId As Integer)
    '    Me.LogId = HistoryLogId
    '    GetWithLogID = True
    '    InitializeDataByThread()
    '    '   InitializeThread = New Thread( _
    '    'New ThreadStart(AddressOf Me.InitializeDataByThread))
    '    '  InitializeThread.IsBackground = True
    '    '  InitializeThread.Start()
    'End Sub
    Private GetWithLogID As Boolean = False
    Public Sub InitializeDataByThread()
        '  On Error Resume Next
        Try
            '  MsgBox("hh")
            If Statue = DeviceStatus.IsActive Then


                _Options.ReadAndApplySettings()
                '  MsgBox(Me.Id)
                Dim sql As String = "SELECT * FROM `deviceslog` WHERE `DeviceId` = '" + CStr(Me.Id) + "' AND `InActive` LIKE 'true'"
                Dim Row As DataRow

                Row = DB.executeSQL(sql)(0)

                ' MsgBox(Row(0))

                Me.Log_Id = CInt(Row(0))

                Me.StartDate = Date.Parse(Row(2))



                Me.Bill = CDbl(Row(5))

                If CStr(Row(11)).Contains("(") Then
                    Me.IsDeviceChanged = False
                Else
                    OldChangedDevicesIdData = CStr(Row(11))
                    Me.IsDeviceChanged = True
                    LoadOldChangedDevices()
                    '  MsgBox(OldChangedDevicesBill)
                End If
                Me.Is_PlayStationDevice = CBool(Row(8))

                If Me.IsPlayStationDevice Then

                    Me.Time_Limit = CInt(Row(7))
                    Me.Time_Type = New Time(Me.Type.Id, "")

                End If

                If Not DeviceOptions.CanActive Then
                    Me.CloseSesstion()
                End If

                '   If Not (Row(14).ToString = "none" OrElse CDbl(Row(14)) = 0.0) Then
                If (Row(14).ToString.Contains(",")) Then
                    Me.SetOffer(CDbl(Row(14).ToString.Split(",")(1)))
                End If


                'End If

                If (Row(16).ToString.Contains(",")) Then
                    Me.AdditinalBill = CInt(Row(16).ToString.Split(",")(0))
                    Me.AdditinalBillInfo = CStr(Row(16).ToString.Split(",")(1))
                    '  Me.AddAdditionalBill (CInt(Row(17).ToString.Split(",")(0)), CStr(Row(17).ToString.Split(",")(1))
                End If
                Me.ControllersCount = CInt(Row(15))
                Me.Paid_Bill = CInt(Row(18))
                ''Dim Rowss As DataRow = DB.executeSQL(sqlss)(0)
                ''Me.DeviceRowOptionsString = Rowss(3).ToString
                ''_Options = New Options(Me)

                'MsgBox(_Options.AddOverTimeCash)
                If isSheduled Then
                    Dim h As New Helper
                    If Not NextSchedule Is Nothing Then
                        h.GlobalUpdate("deviceslog", "`SheduleID`='" + NextSchedule.ID.ToString + "'", "id", CStr(LogId))
                    End If
                Else
                    If CStr(Row(19)) = "none" OrElse CStr(Row(19)) = "" Then
                        '  UpdateSchedules()
                    Else
                        If Not CStr(Row(19)) = "" Then
                            isSheduled = True
                            Me.NextSchedule = New ScheduleObject(CStr(Row(19)))
                            Me.Paid_Bill = Me.NextSchedule.Paid
                        End If
                    End If
                End If


                loadCalculateMethods()
                '  MsgBox(Me.BIllCalculateType(0).ToString)
                '  InitializeThread.CurrentThread.Abort()
                '  InitializeThread = Nothing
                IntializeTotalBill(True)

                ControlDevice.UpdateRefresh()

            End If

        Catch ex As Exception

            LOG.[LOG](ex) 'LOG.[LOG](ex) 'LOG.[LOG](ex) ' MsgBox(ex.StackTrace)

        End Try
    End Sub
    Public Sub loadCalculateMethods()
        On Error Resume Next

        Me.BillsCalculateType.Clear()

        If DeviceOptions.AddOrderCash Then
            Me.BillsCalculateType.Add(Device.Bill_Claculate_Type.OrderBill)
        End If

        If DeviceOptions.AddOverTimeCash Then
            Me.BillsCalculateType.Add(Device.Bill_Claculate_Type.OverTimeBill)

        End If

        If DeviceOptions.AddPlayCash Then
            Me.BillsCalculateType.Add(Device.Bill_Claculate_Type.PlayStationBill)

        End If


        If DeviceOptions.AddChangedDevicesCash Then
            Me.BillsCalculateType.Add(Device.Bill_Claculate_Type.ChangedDevicesBill)

        End If

        Me.BillsCalculateType.Add(Device.Bill_Claculate_Type.Additinal)

    End Sub
    Public Sub LoadOldChangedDevices()
        Try

            Me.ChangedFromDevice.Clear()
            Dim CHangedIDs As String = Me.OldChangedDevicesIdData
            For Each I_d As String In CHangedIDs.Split(",")
                If Not I_d = "" Then
                    Dim devic As New DeviceLOG(CInt(I_d))
                    '  MsgBox(devic.GetMasterDeviceLogID
                    '  MsgBox(CStr(Me.ChangedFromDevice.Count))
                    'MsgBox(devic.LogTotalbill)
                    Me.ChangedFromDevice.Add(devic)
                End If
            Next

        Catch ex As Exception
            LOG.[LOG](ex) '
        End Try
    End Sub
    Private Function UpdateOldSpecies(ByVal dvid As Integer) As Integer
        On Error Resume Next
        ''  Dim Sql As String = "UPDATE `tablelog`, `tablelogdata` SET `Active`='false' WHERE  tablelog.TableId ='" + CStr(Tabel.Id) + "' AND tablelogdata.LogId=tablelog.id AND tablelogdata.Active LIKE 'true'"
        Dim NewLogid As Integer = CInt(DB.executeSQL("SELECT id FROM `deviceslog` WHERE `DeviceId` = '" + CStr(dvid) + "' AND `InActive` LIKE 'true'")(0)(0))
        ' MsgBox(NewLogid)
        Dim HP As New Helper()
        Return HP.GlobalUpdate("deviceslogdata", "`LogId`='" + CStr(NewLogid) + "'", "LogId", CStr(Me.LogId))
    End Function

    ReadOnly Property OldChangedDevicesPlayBill As Double
        Get
            On Error Resume Next
            Dim TotalChangedDevicesBill As Double = 0
            For Each dv As DeviceLOG In Me.ChangedFromDevice
                If dv.ChangedDeviceValued Then
                    TotalChangedDevicesBill += dv.LogTotalbill
                End If
            Next
            Me.ChangedDevicesBill = TotalChangedDevicesBill
            Return TotalChangedDevicesBill
        End Get
    End Property
    Public Sub ChangeDevice(ByVal DCl As DeviceControl1)
        Try



            Dim schstr As String = "none"


            If Me.Statue = DeviceStatus.IsActive And Me.IsPlayStationDevice Then


                If DCl.Device.Statue = DeviceStatus.Empty Then
                    If DCl.Device.IsPlayStationDevice Then

                        If DCl.Device.Type.Id = Me.Type.Id Then
                            Dim timeFormat As String = "yyyy-MM-dd HH:mm:ss"

                            DCl.Device.InsertActiveLog(Me.OldChangedDevicesIdData & "," & CStr(Me.LogId), Me.Bill, Me.StartDate.ToString(timeFormat), "`PlayBill`,`TimeLimit`,", "'" + CStr(Me.PlayStationBill) + "','" + CStr(CInt(Me.TimeLimit.TotalMinutes)) + "',")


                            UpdateOldSpecies(DCl.Device.Id)

                            DCl.Device.StartSesstion(False)



                            Me.CloseSesstion(False, True, "`DeviceLogChanges`='(1)',`Bill`='0',`PlayBill`='0',`TimeLimit`='0',")
                            If Scheduled Then

                                DCl.Device.NextSchedule.DeleteSchedule()

                            End If
                        Else
                            DCl.Device.InsertActiveLog(Me.OldChangedDevicesIdData & "," & Me.LogId, 0)
                            'UpdateOldSpecies(DCl.Device.Id)
                            DCl.Device.StartSesstion(False)

                            Me.CloseSesstion(False, True, "`DeviceLogChanges`='(2)',")
                            If Scheduled Then

                                DCl.Device.NextSchedule.DeleteSchedule()

                            End If
                        End If


                        'Me.Bill = 0
                        ' Me.UpdateBill()
                        '   Me.ResetChangedDevices()

                    End If

                End If
            End If
            frmMain.ADDSTATUS("[CHANGE_DEVICE] DEVICE : " + Me.Name + " CHANGING TO " + DCl.Name)
        Catch ex As Exception
            LOG.[LOG](ex) ' MsgBox("ChangeDevice " + ex.StackTrace)
        End Try
    End Sub
    ReadOnly Property IsChangedDevice As Boolean
        Get
            Return Me.IsDeviceChanged
        End Get
    End Property
    Public Shared Function ReActiveLog(ByVal LogId As Integer) As Integer
        Dim HP As New Helper()
        Dim res As Integer = HP.GlobalUpdate("deviceslog", "`InActive`='true'", "id", CStr(LogId))
        HP.GlobalUpdate("deviceslogdata", "`Active`='true'", "LogId", CStr(LogId))
        frmMain.ADDSTATUS("[Device] REACTIVE LOG ID : " + LogId)
        Return res

    End Function

    'Public Function ResetChangedDevices() As Integer
    '    On Error Resume Next
    '    Dim HP As New Helper()
    '    Return HP.GlobalUpdate("deviceslog", "`DeviceLogChanges`='(0)'", "id", CStr(Me.Log_Id))

    'End Function

    ReadOnly Property OldChangedDevices As List(Of DeviceLOG)
        Get
            Return ChangedFromDevice
        End Get
    End Property
    Public Function AddToStartTime(ByVal hours As Integer, ByVal Minutes As Integer)
        On Error Resume Next
        If Me.IsPlayStationDevice Then


            Dim RecoverDate As Date = Me.StartDate
            Me.StartDate = Me.StartDate.AddHours(hours)

            Me.StartDate = Me.StartDate.AddMinutes(Minutes)

            If Me.PassedTime.Hours < 0 Then
                Me.StartDate = RecoverDate
            End If
            If Me.PassedTime.Minutes < 0 Then
                Me.StartDate = RecoverDate
            End If
            SetTotalBillIntialized()
        End If
    End Function
    Public Function UpdateStartDate() As Integer
        Dim dbHlp As New Helper
        Dim timeFormat As String = "yyyy-MM-dd HH:mm:ss"
        '  Dim d As Date = Date.Now
        Return dbHlp.GlobalUpdate("deviceslog", "`StartDate`='" + StartDate.ToString(timeFormat) + "'", "id", CStr(Me.Log_Id))
    End Function
    Public Sub ResetVariables(Optional ByVal RestartSchedule As Boolean = False)
        On Error Resume Next

        Me.DeviceSpectialOffer = New offer
        Me.AdditinalBill = 0
        Me.Play_StationBill = 0
        ' Is_PlayStationDevice = True
        If Not RestartSchedule Then
            isSheduled = False
            Me.Schedules.Clear()
            Me.NextSchedule = Nothing
            Me.isNEXTSheduleding = False
        End If
        Time_Limit = 0  'miun es   // 0=open
        Total_Bill = 0
        Additinal_Bill_Info = ""
        Controllers_Count = 0
        IsDeviceChanged = False
        ChangedDevicesBill = 0
        Me.ChangedFromDevice.Clear()
        OldChangedDevicesIdData = ""
        Log_Id = 0
        Paid_Bill = 0
        Start_Date = New Date
        End_Date = New Date
        Me._Bill = 0
        _SpeciesOrderCheck = ""
    End Sub
    Public Sub StartSesstionWithSechudle(Optional ByVal BypassSchedulesCheck As Boolean = False)
        Try

            isSheduled = True
            Me.Paid_Bill = NextSchedule.Paid

            StartSesstion(, BypassSchedulesCheck)

        Catch ex As Exception
            LOG.[LOG](ex) '  MsgBox("StartSesstionWithSechudle " + ex.Message)
        End Try
    End Sub
    Public Sub StartSesstion(Optional ByVal InsetLog As Boolean = True, Optional ByVal BypassSchedulesCheck As Boolean = False)
        Try
            [CheckActive]()
            '  _Options.ReadAndApplySettings()
            If BypassSchedulesCheck Then
                GoTo BypassSchedulesCheck
            End If
            Dim FirstSchedule As ScheduleObject = CheckSchedules()

            If FirstSchedule Is Nothing Then
BypassSchedulesCheck:
                If InsetLog Then
                    If InsertActiveLog() Then
                        Me._Statue = DeviceStatus.IsActive
                    End If
                End If

                RaiseEvent SesstionStarted()
                Me.InitializeData()
            Else
                ' Me.NextSchedule = CheckSchedules()
                If FirstSchedule.IsWarning Then
                    ControlDevice.StartSesstionPop()
                ElseIf FirstSchedule.IsActive Then

                    MsgBox("Device Is Initializing  schedule Event Please wait", MsgBoxStyle.Information, "ActiveSchedule")
                    'ControlDevice.UpdateActive()
                End If

            End If
            [CheckActive]()
        Catch ex As Exception
            [CheckActive]()
            ' Me.InitializeData()
            LOG.[LOG](ex) '  MsgBox("StartSesstion: " & ex.Message)
        End Try
    End Sub
    Public Sub CloseSesstion(Optional ByVal DisActiveSpecies As Boolean = True, Optional ByVal DisActiveLog As Boolean = True, Optional ByVal Additionalparms As String = "", Optional ByVal RestartSchedule As Boolean = False)
        Try

            Dim res As Integer = 0
            If Statue = DeviceStatus.IsActive Then


                If DisActiveLog Then

                    res = insertDisActivelog(Additionalparms, RestartSchedule)
                End If
                If DisActiveSpecies Then
                    DisActiveDeviceLogData()
                End If
                ''reset variables
                If res > 0 Then
                    RaiseEvent SesstionClosed()
                    [CheckActive]()
                End If
                ResetVariables(RestartSchedule)
                If RestartSchedule Then
                    StartSesstionWithSechudle(True)
                End If
            End If

        Catch ex As Exception
            LOG.[LOG](ex) ' MsgBox("CloseSesstion: " & ex.StackTrace)
        End Try
    End Sub
    Private Function InsertActiveLog(Optional ByVal ChangedFrom As String = "(0)", Optional ByVal NewBill As Double = 0, Optional ByVal NewStartDate As String = "", Optional ByVal AdditionalparmsFilds As String = "", Optional ByVal AdditionalparmsValues As String = "") As Integer
        '  Try
        'MsgBox("ins")
        ' On Error Resume Next

        If NewStartDate = "" Then


            NewStartDate = GetDate()

        End If

        Dim r As Integer = 0
        '  MsgBox(Me.Statue.ToString +"")
        If Not Me.Statue = Device.DeviceStatus.IsActive Then
            'If Not DeviceOptions.CanActive Then

            '    Me.CloseSesstion()
            '    Return r
            '    Exit Function
            'End If

            Dim HP As New Helper()

            Me.StartDate = GetDate()
            r = HP.GlobalInsert("deviceslog", AdditionalparmsFilds & "`PlayStation`,`DeviceId`, `StartDate`, `InActive`, `Bill`, `SpeciesOrderCheck`, `User` ,`DeviceLogChanges`,`PaidBill`", AdditionalparmsValues & "'" + Me.DeviceOptions.IsPlayStationDevice.ToString + "','" + CStr(Id) + "', '" + NewStartDate + "', 'true', '" + CStr(NewBill) + "', '0', '" + Me.usr.UserName.ToString + "','" + ChangedFrom + "','" + CStr(Me.Paid_Bill) + "'")
            'InitializeData()

        End If

        Return r

        'Catch ex As Exception
        '    LOG.[LOG](ex) ' MsgBox("InsertActiveLog: " & ex.Message)
        'End Try
    End Function
    Private Function insertDisActivelog(Optional ByVal AddtionalParms As String = "", Optional ByVal RestartSchedule As Boolean = False) As Integer
        Try

            '   On Error Resume Next

            If Me.Statue = Device.DeviceStatus.IsActive Then
                IntializeTotalBill(True)


                Dim playbill As Double = CDbl(IIf(IsPlayStationDevice, CStr(Me.PlayStationBill), 0))

                '   Dim MiuntesPrice As Double

                'If IsPlayStationDevice Then
                '    Try


                '        MiuntesPrice = CDbl(IIf(IsPlayStationDevice, CStr(Me.TimeType.MiuntesPrice), 0))
                '    Catch ex As Exception
                '        LOG.[LOG](ex)
                '    End Try
                'Else

                '    MiuntesPrice = 0
                '    AddtionalParms = ""
                'End If

                ' MsgBox(IsPlayStationDevice)
                Dim TotalNEWBILL As Double
                If AddtionalParms = "" Then
                    TotalNEWBILL = Me.TotalBill
                Else
                    TotalNEWBILL = Me.TotalBill - OldChangedDevicesPlayBill
                End If
                Dim SpeciesOrder As String = GetSpeciesOrderCheck()
                Dim Scheduleid As String = "none"
                If Not isSheduled Then
                    ' Me.NextSchedule = Nothing
                Else
                    If Not NextSchedule Is Nothing Then
                        Scheduleid = NextSchedule.ID
                    End If

                End If

                Dim HP As New Helper
                If AddtionalParms.Contains("`PlayBill`") Then
                    ' MsgBox("ins1")
                    Return HP.GlobalUpdate("deviceslog", AddtionalParms & "`EndDate`='" + CStr(GetDate()) + "',`InActive`='false',`SpeciesOrderCheck`='" + SpeciesOrder + "' ,`DeviceType` ='" + Me.Device_Type.Name + "',`TotalBill`='" + CStr(TotalNEWBILL) + "',`PaidBill`='" + CStr(PaidBill) + "',`SheduleID` = '" + Scheduleid + "'", "id", CStr(Me.Log_Id))

                Else
                    ' MsgBox("ins")
                    ' MsgBox(Me.Device_Type.Name)

                    Return HP.GlobalUpdate("deviceslog", AddtionalParms & "`EndDate`='" + CStr(GetDate()) + "',`InActive`='false',`PlayBill`='" + CStr(playbill) + "',`SpeciesOrderCheck`='" + SpeciesOrder + "' ,`DeviceType` ='" + Me.Device_Type.Name + "',`TotalBill`='" + CStr(TotalNEWBILL) + "',`PaidBill`='" + CStr(PaidBill) + "',`SheduleID` = '" + Scheduleid + "'", "id", CStr(Me.Log_Id))
                End If

            End If
        Catch ex As Exception
            ' insertDisActivelog(AddtionalParms, RestartSchedule)
            'Throw ex
            LOG.[LOG](ex) '  MsgBox("InsertDisActiveLog: " & ex.StackTrace)
            ' Return 0
        End Try
    End Function
    Private Function DisActiveDeviceLogData() As Integer
        ''  Dim Sql As String = "UPDATE `tablelog`, `tablelogdata` SET `Active`='false' WHERE  tablelog.TableId ='" + CStr(Tabel.Id) + "' AND tablelogdata.LogId=tablelog.id AND tablelogdata.Active LIKE 'true'"
        Dim HP As New Helper()
        Return HP.GlobalUpdate("deviceslogdata", "`Active`='false'", "LogId", CStr(Me.Log_Id))
    End Function
    'Private Function DisActiveTimeLog() As Integer
    '    ''  Dim Sql As String = "UPDATE `tablelog`, `tablelogdata` SET `Active`='false' WHERE  tablelog.TableId ='" + CStr(Tabel.Id) + "' AND tablelogdata.LogId=tablelog.id AND tablelogdata.Active LIKE 'true'"
    '    Dim HP As New Helper()
    '    Return HP.GlobalUpdate("timelog", "`Active`='false'", "LogId", CStr(Me.Log_Id))
    'End Function
    Public Function SpeciesList() As List(Of species)
        Try


            Dim SpL As New List(Of species)

            If Me.Statue = Device.DeviceStatus.IsActive Then
                'Dim Sql As String = "SELECT SpeciesId,deviceslogdata.id FROM `deviceslog`, `deviceslogdata` WHERE  deviceslog.DeviceId ='" + CStr(Me.DeviceID) + "' AND deviceslogdata.LogId=deviceslog.id AND deviceslogdata.Active LIKE 'true'"
                Dim Sql As String = "SELECT deviceslogdata.SpeciesId,deviceslogdata.id,deviceslogdata.Date FROM `deviceslogdata` WHERE deviceslogdata.LogId='" + CStr(Me.Log_Id) + "'"

                My.Computer.Clipboard.SetText(Sql)
                Dim Rows As DataRowCollection = DB.executeSQL(Sql)
                For Each DR As DataRow In Rows
                    Dim Sp As New species(DR(0))
                    '   Dim LG As New DeviceLogData(DR(1))
                    Sp.AddDate = Date.Parse(CStr(DR(2)))
                    SpL.Add(Sp)
                Next

                RaiseEvent SpeciesLoaded()
            End If
            Return SpL
        Catch ex As Exception
            LOG.[LOG](ex) '  MsgBox("SpeciesList: " + ex.StackTrace)
        End Try
    End Function

    Property SpeciesCount As Integer
        Get

            Return Me.CorrentLoadedSpeciesCount
        End Get
        Set(ByVal value As Integer)
            Me.CorrentLoadedSpeciesCount = value
        End Set
    End Property

    Public Sub addSpecies(ByVal spid As Integer)
        '  On Error Resume Next
        Try


            If Me.Statue = Device.DeviceStatus.IsActive Then

                Dim sp As New species(spid)

                DeviceLogData.InsertTableLogDataItem(Me.Log_Id, spid, sp.Price)
                ' Me._Species.Add(sp)
                Me.Bill += sp.Price

                UpdateBill()
                '  InitializeData()
                '   RaiseEvent SpeciesLoaded()
                SetTotalBillIntialized()
            End If
        Catch ex As Exception
            LOG.[LOG](ex) '  MsgBox("Add Species: " & ex.Message)
        End Try
    End Sub
    Public Sub RemoveSpecies(ByVal spid As Integer)
        On Error Resume Next


        If Me.Statue = Device.DeviceStatus.IsActive Then
            Dim SqlGet As String = "SELECT * FROM `deviceslogdata` WHERE `LogId` = '" + CStr(Me.Log_Id) + "' AND `SpeciesId` = '" + CStr(spid) + "' LIMIT 1"
            Dim ROW As DataRow = DB.executeSQL(SqlGet)(0)
            Dim tabelLogdta As New DeviceLogData(ROW(0))

            Me.Bill -= tabelLogdta.OrgPrice
            tabelLogdta.Delete()
            '  Me._Species.Remove(New species(spid))
            UpdateBill()
            '   InitializeData()
            ' LoadSpeciesList()
            '  RaiseEvent SpeciesLoaded()
            SetTotalBillIntialized()

        End If

    End Sub
    Public Function UpdateBill()
        On Error Resume Next

        '  Dim DB As New DataBaseConnection
        '  On Error Resume Next
        Dim Res As Integer = 0
        If Me.Statue = Device.DeviceStatus.IsActive Then
            '      MsgBox(Me.Bill)
            Dim Sql As String = "UPDATE `deviceslog` SET `Bill`='" + CStr(Me.Bill) + "' WHERE `id` ='" + CStr(Me.Log_Id) + "'"

            If IsPlayStationDevice Then

                PlayStationBillUpdate()
            End If

            Res = DB.executeDMLSQL(Sql)
            If Res = 1 Then
                ' InitializeData()
            End If
                Return Res
            End If
        
    End Function
    Public Function PlayStationBillUpdate()
        On Error Resume Next
        '  Dim DB As New DataBaseConnection
        If Me.Statue = Device.DeviceStatus.IsActive Then


            Dim Sql As String = "UPDATE `deviceslog` SET `PlayBill`='" + CStr(Me.PlayStationBill) + "' WHERE `id` ='" + CStr(Me.Log_Id) + "'"

            ' MsgBox(Sql)

            Return DB.executeDMLSQL(Sql)

        End If
    End Function
    Public Function GetSpeciesOrderCheck() As String
        On Error Resume Next
        Dim res As String = ""
        If Me.DeviceOptions.CanActive Then
            Dim SPLS As List(Of species) = SpeciesList()
            If Not SPLS.Count = 0 Then
                For Each sp As species In SPLS
                    res += vbNewLine + sp.GetString
                Next
            Else
                res = "0"
            End If

        Else
            res = "0"
        End If

        Return res
    End Function
    Public Shared Function GetDate() As String
        Dim timeFormat As String = "yyyy-MM-dd HH:mm:ss"
        Dim d As Date = Date.Now
        Return d.ToString(timeFormat)
    End Function
    Public Function GetActiveDuration(Optional ByVal Small As Boolean = False) As String
        On Error Resume Next
        If Me.Statue = DeviceStatus.IsActive Then


            Dim Sdate As Date = Me.StartDate
            Dim Nowdate As Date = Date.Now
            Dim span As TimeSpan = Nowdate.Subtract(Sdate)
            '  MsgBox((Sdate, Nowdate).ToString)
            Dim TotalString As String = ""
            If Small Then
                TotalString = String.Format("س {0} د {1} ", span.Hours, span.Minutes)
            Else
                TotalString = String.Format("ساعه {0} دقيقه {1} ", span.Hours, span.Minutes)
            End If



            Return TotalString
        End If
    End Function

    Public Function AddTime(ByVal TimeByMiuntes As Integer)
        On Error Resume Next
        If Me.IsPlayStationDevice Then


            Dim NeWTime As Integer = (Me.TimeLimit.TotalMinutes + TimeByMiuntes)

            Dim Hp As New Helper()
            Dim r As Integer = Hp.GlobalUpdate("deviceslog", "`TimeLimit`='" + CStr(NeWTime) + "'", "id", CStr(Me.Log_Id))
            Me.Time_Limit = NeWTime
            PlayStationBillUpdate()
            SetTotalBillIntialized()
            '  ControlDevice.Refresh()
            Return r
        End If

    End Function
    Public Function RemoveTime(ByVal TimeByMiuntes As Integer)
        On Error Resume Next
        If Me.IsPlayStationDevice Then


            'InitializeData()
            If (Me.ISTimeLimit And Not Me.IsOver) Then
                Dim hours As Integer = TimeByMiuntes \ 60
                Dim minutes As Integer = TimeByMiuntes - (hours * 60)
                Dim NeWTime As Integer = (Me.TimeLimit.TotalMinutes - TimeByMiuntes)

                Dim Hp As New Helper()
                Dim r As Integer = Hp.GlobalUpdate("deviceslog", "`TimeLimit`='" + CStr(NeWTime) + "'", "id", CStr(Me.Log_Id))
                Me.Time_Limit = NeWTime
                If IsOver Then
                    AddTime(TimeByMiuntes)
                End If

                PlayStationBillUpdate()
                ' Me.Time_Limit()
                'InitializeData()
                SetTotalBillIntialized()
                Return r

            End If
        End If
    End Function
    Public Function SetTimeOpend()
        If Me.IsPlayStationDevice Then


            Dim Hp As New Helper()
            Dim r As Integer = Hp.GlobalUpdate("deviceslog", "`TimeLimit`='0'", "id", CStr(Me.Log_Id))
            Me.Time_Limit = 0
            SetTotalBillIntialized()
            Return r
        Else
            Return 0

        End If
    End Function
    ReadOnly Property LogId As Integer
        Get
            Return Me.Log_Id
        End Get
    End Property
    Property StartDate As Date
        Set(ByVal value As Date)
            Me.Start_Date = value
        End Set
        Get
            Return Me.Start_Date
        End Get
    End Property
    Property EndDate As Date
        Set(ByVal value As Date)
            Me.End_Date = value
        End Set
        Get
            Return End_Date
        End Get
    End Property
    Property PaidBill As Double
        Set(ByVal value As Double)
            Me.Paid_Bill = value
        End Set
        Get
            If IsPlayStationDevice Then
                Return Me.Paid_Bill
            Else
                Return Me.Paid_Bill
            End If


        End Get
    End Property
    ReadOnly Property Scheduled As Boolean
        Get
            Return isSheduled

        End Get
    End Property
    ReadOnly Property NextScheduling As Boolean
        Get
            Return isNEXTSheduleding

        End Get
    End Property
    'isNEXTSheduleding
    Property Bill As Double
        Set(ByVal value As Double)
            Me._Bill = value
        End Set
        Get
            If IsPlayStationDevice Then
                Return Me._Bill
            Else
                Return Me._Bill
            End If


        End Get
    End Property
    Property SpeciesOrderCheck As String
        Set(ByVal value As String)
            Me._SpeciesOrderCheck = value
        End Set
        Get
            Return Me._SpeciesOrderCheck
        End Get
    End Property

    ReadOnly Property TimeType As Time
        Get
            If IsPlayStationDevice Then
                Return Me.Time_Type
            Else
                Return Nothing
            End If

        End Get
    End Property
    ReadOnly Property PassedTime As TimeSpan
        Get
            'MsgBox(Me.StartDate)

            Dim Sdate As Date = Me.StartDate
            Dim Nowdate As Date = Date.Now
            Dim span As TimeSpan = Nowdate.Subtract(Sdate)
            'MsgBox("Passed Time :" + span.Minutes)
            Return span
        End Get
    End Property
    ReadOnly Property IsOver As Boolean
        Get
            If (Me.ISTimeLimit And Me.IsPlayStationDevice) Then
                If Not CInt(PassedTimeMiuntes) > CInt(TimeLimit.TotalMinutes) Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return False
            End If

        End Get
    End Property
    Public Sub RaiseOverTimeEvent()
        If Me.Statue = DeviceStatus.IsActive Then
            If Me.IsPlayStationDevice Then
                If IsOverTime Then
                    ' MsgBox("jjj")

                    RaiseEvent OnOverTime(Me)
                End If
            End If

        End If
    End Sub
    ReadOnly Property IsOverTime As Boolean
        Get
            ' InitializeData()
            If Me.IsPlayStationDevice Then


                If (Me.ISTimeLimit And Me.IsPlayStationDevice And Not IsOver) Then
                    Dim RestMiuntes As Integer = 0
                    If RestTime.Minutes < 0 Then
                        RestMiuntes = RestTime.Minutes * -1
                    Else
                        RestMiuntes = RestTime.Minutes
                    End If
                    '  MsgBox(RestMiuntes)

                    If (RestTime.Hours = 0 And RestTime.Minutes < CInt(IIf(Me.DeviceOptions.WarnMeLast10Minutes And Not Me.DeviceOptions.WarnMeCustom = 0, Me.DeviceOptions.WarnMeCustom, 10) And RestTime.Minutes > 0)) Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End Get
    End Property
    ReadOnly Property OverTime As TimeSpan
        Get
            If Me.IsPlayStationDevice Then


                If Me.ISTimeLimit Then
                    If IsOver Then
                        '   MsgBox(TimeLimit.Hours - PassedTime.Hours)
                        Dim span As TimeSpan = New TimeSpan(PassedTime.Hours - TimeLimit.Hours, PassedTime.Minutes - TimeLimit.Minutes, 0)
                        Return span
                    Else
                        Return New TimeSpan(0, 0, 0)
                    End If

                Else
                    Return New TimeSpan(0, 0, 0)
                End If
            End If
        End Get
    End Property

    ReadOnly Property RestTime As TimeSpan
        Get
            If Me.IsPlayStationDevice Then

                If Me.ISTimeLimit Then
                    If Not IsOver Then         '   2              1
                        Dim Hours As Integer = TimeLimit.Hours - PassedTime.Hours
                        '  40                                       30
                        Dim Miuntes As Integer = TimeLimit.Minutes - PassedTime.Minutes
                        '   If Hours < 0 Then Hours = (Hours * -1)
                        '   If Miuntes < 0 Then Miuntes = (Miuntes * -1)

                        Dim span As TimeSpan = New TimeSpan(Hours, Miuntes, 0)
                        Return span
                    Else
                        Return New TimeSpan(0, 0, 0)
                    End If

                Else
                    Return Nothing
                End If

            End If
        End Get
    End Property
    ReadOnly Property PassedTimeMiuntes As Integer
        Get
            Return (PassedTime.Hours * 60 + PassedTime.Minutes)
        End Get
    End Property
    ReadOnly Property ISTimeLimit As Boolean
        Get
            If Me.TimeLimit.TotalMinutes = 0 Then
                Return False
            Else
                Return True

            End If
        End Get
    End Property



    ReadOnly Property TimeLimit As TimeSpan
        Get
            If IsPlayStationDevice Then
                If Time_Limit < 0 Then
                    Time_Limit = Time_Limit * -1
                End If
                Dim hours As Integer = Time_Limit \ 60
                Dim minutes As Integer = Time_Limit - (hours * 60)
                Return New TimeSpan(hours, minutes, 0)
            Else
                Return New TimeSpan(0, 0, 0)
            End If
        End Get
    End Property
    ReadOnly Property IsPlayStationDevice As Boolean
        Get
            Return Me.Is_PlayStationDevice
        End Get
    End Property
    ReadOnly Property PlayStationOverTimeBill As Double
        Get
            Try
                If Me.IsPlayStationDevice Then


                    If IsOver Then
                        Return ((OverTime.Minutes + OverTime.Hours * 60) * TimeType.MiuntesPrice)
                    Else
                        Return 0
                    End If
                Else
                    Return 0
                End If
            Catch ex As Exception
                Return 0
            End Try
        End Get
    End Property
    ReadOnly Property PlayStationBill As Double
        Get
            Try


                If Me.IsPlayStationDevice Then


                    If Not ISTimeLimit Then
                        '  MsgBox("PassedTimeMiuntes : " + PassedTimeMiuntes.ToString + "    " + "MiuntesPrice : " + TimeType.MiuntesPrice.ToString)
                        Return (PassedTimeMiuntes * TimeType.MiuntesPrice)
                    Else
                        Return (TimeLimit.TotalMinutes * TimeType.MiuntesPrice)
                    End If

                Else
                    Return 0
                End If
            Catch ex As Exception
                Return 0
            End Try
        End Get
    End Property
    Private BIllCalculateType As New List(Of Integer)
    Public Property BillsCalculateType As List(Of Integer)
        Set(ByVal value As List(Of Integer))
            Me.BIllCalculateType = value
        End Set
        Get
            Return BIllCalculateType
        End Get
    End Property
    Private IsTotalBillIntialized As Boolean = True
    Public Sub SetTotalBillIntialized()
        IsTotalBillIntialized = False
    End Sub
    Public Sub RemoveTotalBillIntialized()
        IsTotalBillIntialized = True
    End Sub

    Public Function SetPaidBill(ByVal Value As Double) As Integer
        Dim helpr As New Helper
        Dim Res As Integer = 0
        Res = helpr.GlobalUpdate("deviceslog", "`PaidBill`='" + Me.PaidBill + "'", "id", CStr(Me.LogId))
        If Res = 1 Then
            Me.Paid_Bill = Value
        End If
        Return Res
    End Function

    ReadOnly Property TotalBill As Double
        Get
            If IsPlayStationDevice Then
                IntializeTotalBill(False)

            Else
                Me.Total_Bill = Bill

            End If

            Return Total_Bill
        End Get
    End Property


    Public Function IntializeTotalBill(ByVal IntializeOnes As Boolean) As Double

        '  MsgBox(IsTotalBillIntialized)

        If IntializeOnes Then
            SetTotalBillIntialized()
        End If

        Try
            If Not IsTotalBillIntialized Then
                RemoveTotalBillIntialized()
                If Not Me.IsPlayStationDevice Then
                    Me.Total_Bill = CInt(Bill)
                Else
                    Me.Total_Bill = 0

                    If Me.BillsCalculateType.Contains(0) Then
                        Me.Total_Bill += (Me.Bill + Me.PlayStationOverTimeBill + Me.PlayStationBill + AdditinalBill)
                    Else

                        If Me.BillsCalculateType.Contains(2) Then
                            Me.Total_Bill += Me.Bill
                        End If


                        If Me.BillsCalculateType.Contains(1) Then

                            Me.Total_Bill += Me.PlayStationBill
                        End If

                        If Me.BillsCalculateType.Contains(3) Then
                            Me.Total_Bill += Me.PlayStationOverTimeBill
                        End If
                        If Me.BillsCalculateType.Contains(4) Then
                            Me.Total_Bill += Me.OldChangedDevicesPlayBill
                        End If



                        If Me.BillsCalculateType.Contains(5) Then
                            Me.Total_Bill += Me.AdditinalBill
                        End If
                        If HasSpectialOffer Then
                            UpdateOfferDecreseValue()
                            Me.Total_Bill -= Me.DeviceSpectialOffer.OfferDecreseValue
                        End If


                    End If
                    ' MsgBox(TotalBill)

                End If

            End If
            'If IntializeOnes Then
            '    Try


            '        ControlDevice.UpdateRefresh()
            '    Catch ex As Exception

            '    End Try
            'End If
            Return CInt(Me.Total_Bill)

        Catch ex As Exception
            LOG.[LOG](ex) 'MsgBox("IntializeTotalBill " + ex.Message)
            Return 0
        End Try

        ' Me.TotalBill = TotalBillResult
        '  MsgBox(TotalBill)

    End Function
    Public Function CheckBillcalculateType(ByVal billCalcType As Integer) As Boolean

        For Each BCT As Integer In Me.BillsCalculateType
            If billCalcType = BCT Then
                ' MsgBox(BCT.ToString)
                Return True
            Else
                Return False
            End If
        Next

    End Function
    Public Sub AddController()
        Me.Controllers_Count += 1
        Dim Helpr As New Helper
        Helpr.GlobalUpdate("deviceslog", "`ControllersCount`='" + CStr(ControllersCount) + "'", "id", CStr(Me.LogId))
    End Sub
    Public Sub RemoveController()
        Me.Controllers_Count -= 1
        Dim Helpr As New Helper
        Helpr.GlobalUpdate("deviceslog", "`ControllersCount`='" + CStr(ControllersCount) + "'", "id", CStr(Me.LogId))
    End Sub
    Public Sub AddAdditionalBill(ByVal _AdditionalBill As Double, ByVal _AditionalBillInformation As String)

        On Error Resume Next

        Me.AdditinalBill = _AdditionalBill
        Me.AdditinalBillInfo = _AditionalBillInformation
        Dim Helpr As New Helper
        Helpr.GlobalUpdate("deviceslog", "`AdditionalBill`='" + CStr(_AdditionalBill) + "," + _AditionalBillInformation + "'", "id", CStr(Me.LogId))
        IntializeTotalBill(True)
        ControlDevice.UpdateRefresh()
    End Sub
    ReadOnly Property HasSpectialOffer As Boolean
        Get
            On Error Resume Next

            If DeviceSpectialOffer.value = 0 Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property
    Property DeviceSpectialOffer As offer
        Set(ByVal value As offer)
            Me.SpectialOffer = value
        End Set
        Get
            Return Me.SpectialOffer
        End Get
    End Property
    Property AdditinalBill As Double
        Set(ByVal value As Double)
            Me.Additinal_Bill = value
        End Set
        Get
            Return Me.Additinal_Bill
        End Get
    End Property
    Property AdditinalBillInfo As String
        Set(ByVal value As String)
            Me.Additinal_Bill_Info = value
        End Set
        Get
            Return Me.Additinal_Bill_Info
        End Get
    End Property
    Property ControllersCount As Integer
        Set(ByVal value As Integer)
            Me.Controllers_Count = value
        End Set
        Get
            Return Me.Controllers_Count
        End Get
    End Property

    Public Enum Bill_Claculate_Type
        all = 0
        PlayStationBill = 1
        OrderBill = 2
        OverTimeBill = 3
        ChangedDevicesBill = 4
        Additinal = 5
    End Enum
    Dim OfferUpdateThrd As Thread
    Public Sub SetOffer(ByVal OFFERBy As Double)
        On Error Resume Next
        '    MsgBox("jjj")
        Me.DeviceSpectialOffer = New offer
        '  Me.DeviceSpectialOffer = New offer

        ' If Decimal.TryParse(TotalBill, Me.DeviceSpectialOffer.value) Then
        Me.DeviceSpectialOffer.OfferDecreseValue = Val(Total_Bill) * (Val(OFFERBy) / 100)
        '  MsgBox(Me.DeviceSpectialOffer.OfferDecreseValue)
        ' End If

        'Dim int As Double = Val(OFFERBy) / 100 * Val(TotalBill)
        'Me.DeviceSpectialOffer.OfferDecreseValue = int
        Me.DeviceSpectialOffer.value = OFFERBy
        ' Me.DeviceSpectialOffer = offer

        '  SetTotalBillIntialized()
        IntializeTotalBill(True)
        ControlDevice.UpdateRefresh()
        If Not OfferUpdateThrd.IsAlive Then
            OfferUpdateThrd = New Thread( _
 New ThreadStart(AddressOf Me.UpdateOFFERData))
            OfferUpdateThrd.IsBackground = True
            OfferUpdateThrd.Start()
        End If

    End Sub
    Public Sub UpdateOFFERData()
        On Error Resume Next
        '   SetTotalBillIntialized()
        If HasSpectialOffer Then
            Dim Helpr As New Helper
            Helpr.GlobalUpdate("deviceslog", "`offers`='" + CStr(Me.DeviceSpectialOffer.OfferDecreseValue) + "," + CStr(Me.DeviceSpectialOffer.value) + "'", "id", CStr(Me.LogId))
        End If

    End Sub

    Public Sub UpdateOfferDecreseValue()
        On Error Resume Next
        If HasSpectialOffer Then


            '  Me.DeviceSpectialOffer = New offer
            ';   Me.TotalBill = DeviceTotalBill
            ' If Decimal.TryParse(TotalBill, Me.DeviceSpectialOffer.value) Then
            Me.DeviceSpectialOffer.OfferDecreseValue = Val(Total_Bill) * (Val(Me.DeviceSpectialOffer.value) / 100)
            '  Me.TotalBill = DeviceTotalBill
            ' End If
            '    SetTotalBillIntialized()
            '  Dim int As Double = Val(Me.DeviceSpectialOffer.value) / 100 * Val(TotalBill)
            '  Me.DeviceSpectialOffer.OfferDecreseValue = int
            If Not OfferUpdateThrd.IsAlive Then
                OfferUpdateThrd = New Thread( _
     New ThreadStart(AddressOf Me.UpdateOFFERData))
                OfferUpdateThrd.IsBackground = True
                OfferUpdateThrd.Start()
            End If
        End If
    End Sub
    Public Class offer
        Public Sub New()

        End Sub
        Private Offer_DecreseValue As Double = 0
        Private OfferValue As Double = 0
        Property OfferDecreseValue As Double
            Set(ByVal value As Double)
                Offer_DecreseValue = value
            End Set
            Get
                Return Offer_DecreseValue
            End Get
        End Property
        Property value As Double
            Set(ByVal value As Double)
                OfferValue = value
            End Set
            Get
                Return OfferValue
            End Get
        End Property
    End Class

#End Region


    Public Class DeviceLogData
        Dim DB As New DataBaseConnection
        Private LogDataId As Integer
        Private Log_Id As Integer
        Private Species_Id As Integer
        Private Org_Price As Double
        Private ISActive As Boolean
        Private DateSet As Date
        Public Sub New(ByVal LogData As Integer)
            On Error Resume Next
            Dim SQl = "SELECT * FROM `deviceslogdata` WHERE `id` ='" + CStr(LogData) + "'"
            Dim Row As DataRow = DB.executeSQL(SQl)(0)

            Me.LogDataId = CInt(Row(0))
            Me.Log_Id = CInt(Row(1))
            Me.Species_Id = CInt(Row(2))
            Me.Org_Price = CDbl(Row(3))
            Me.DateSet = Date.Parse(Row(6))

        End Sub
        Public Shared Function GetDate() As String
            Dim timeFormat As String = "yyyy-MM-dd HH:mm:ss"
            Dim d As Date = Date.Now
            Return d.ToString(timeFormat)
        End Function

        ReadOnly Property Id As Integer
            Get
                Return Me.LogDataId
            End Get
        End Property
        ReadOnly Property LogId As Integer
            Get
                Return Me.Log_Id
            End Get
        End Property
        ReadOnly Property SpeciesId As Integer
            Get
                Return Me.Species_Id
            End Get
        End Property

        ReadOnly Property OrgPrice As Double
            Get
                Return Me.Org_Price
            End Get
        End Property
        ReadOnly Property Active As Boolean
            Get
                Return Me.ISActive

            End Get
        End Property
        ReadOnly Property DateTime As Date
            Get
                Return Me.DateSet

            End Get
        End Property
        Public Shared Function InsertTableLogDataItem(ByVal Log_Id As Integer, ByVal Species_Id As Integer, ByVal OrgPrice As Double) As Integer
            Dim DB As New DataBaseConnection
            Dim SQl As String = "INSERT INTO `deviceslogdata` (`id`, `LogId`, `SpeciesId`, `OrgPrice`,`Active`,`Date`) VALUES (NULL, '" + CStr(Log_Id) + "', '" + CStr(Species_Id) + "', '" + CStr(OrgPrice) + "','true','" + GetDate() + "');"
            Return DB.executeDMLSQL(SQl)
        End Function
        Public Function SetRemoved()
            Dim SQl = "UPDATE `deviceslogdata` SET `Removed`='true' WHERE `id` ='" + CStr(Me.Id) + "'"
            Return DB.executeDMLSQL(SQl)
        End Function
        Public Function Delete()
            Dim SQl = "DELETE FROM `deviceslogdata` WHERE `id` ='" + CStr(Me.Id) + "'"
            Return DB.executeDMLSQL(SQl)
        End Function


    End Class

    Public Class TimeLog

        Dim DB As New DataBaseConnection
        Private LogDataId As Integer
        Private Log_Id As Integer

        Private Time_ID As Integer

        Private Org_Price As Double
        Private ISActive As Boolean
        Private DateSet As Date

        Public Sub New(ByVal LogData As Integer)
            On Error Resume Next
            Dim SQl = "SELECT * FROM `deviceslogdata` WHERE `id` ='" + CStr(LogData) + "'"
            Dim Row As DataRow = DB.executeSQL(SQl)(0)

            Me.LogDataId = CInt(Row(0))
            Me.Log_Id = CInt(Row(1))
            Me.Time_ID = CInt(Row(2))
            Me.Org_Price = CDbl(Row(3))
            Me.DateSet = Date.Parse(Row(6))

        End Sub
        Public Shared Function GetDate() As String
            Dim timeFormat As String = "yyyy-MM-dd HH:mm:ss"
            Dim d As Date = Date.Now
            Return d.ToString(timeFormat)
        End Function

        ReadOnly Property Id As Integer
            Get
                Return Me.LogDataId
            End Get
        End Property
        ReadOnly Property LogId As Integer
            Get
                Return Me.Log_Id
            End Get
        End Property
        ReadOnly Property TimeID As Integer
            Get
                Return Me.Time_ID
            End Get
        End Property

        ReadOnly Property OrgPrice As Double
            Get
                Return Me.Org_Price
            End Get
        End Property
        ReadOnly Property Active As Boolean
            Get
                Return Me.ISActive

            End Get
        End Property
        ReadOnly Property DateTime As Date
            Get
                Return Me.DateSet

            End Get
        End Property
        Public Shared Function InsertTableLogDataItem(ByVal Log_Id_ As Integer, ByVal TimeID_ As Integer, ByVal OrgPrice_ As Double) As Integer
            Dim DB As New DataBaseConnection
            Dim SQl As String = "INSERT INTO `timelog` (`id`, `LogId`, `TimeID`, `Date`, `OrgPrice`, `Active`) VALUES (NULL, '" + CStr(Log_Id_) + "', '" + CStr(TimeID_) + "', '" + GetDate() + "','" + CStr(OrgPrice_) + "','true');"
            Return DB.executeDMLSQL(SQl)
        End Function
        Public Function SetRemoved()
            Dim SQl = "UPDATE `deviceslogdata` SET `Removed`='true' WHERE `id` ='" + CStr(Me.Id) + "'"
            Return DB.executeDMLSQL(SQl)
        End Function
        Public Function Delete()
            Dim SQl = "DELETE FROM `timelog` WHERE `id` ='" + CStr(Me.Id) + "'"
            Return DB.executeDMLSQL(SQl)
        End Function


    End Class
    Public Class DeviceLOG
        Dim db As New DataBaseConnection
        Private Device_ID As Integer
        Private DeviceName As String
        Private Device_Type As DeviceType
        '///////////////////////////////PlayStaion/////////////////////////
        Private Is_PlayStationDevice As Boolean = True
        Private Time_Limit As Integer = 0  'miuntes   // 0=open
        Private Passed_Time As TimeSpan
        Private _LogTotalbill As Double
        Private Play_StationBill As Double
        Private IsDeviceChanged As Boolean = False
        Private Log_Id As Integer
        Private Start_Date As Date
        Private End_Date As Date
        Private _Bill As Double
        Private _SpeciesOrderCheck As String
        Private TimeMinutePrice As Double = 0
        '  Private CurrDevice As Device
        Private DviceType As String
        Private _ISChangedDeviceNONE As Boolean = False
        Private _ISChangedDeviceValued As Boolean = False

        Public Sub New(ByVal LogId As Integer)
            '  Try
            On Error Resume Next

            Dim Sql = "SELECT * FROM `deviceslog` WHERE `id` = '" + CStr(LogId) + "' AND `InActive` LIKE 'false'"

            Dim Row As DataRow = db.executeSQL(Sql)(0)

            Me.Log_Id = CInt(Row(0))

            Me.IntiDeviceData(Row(1))
            ' Me.CurrDevice = New Device(Row(1))

            Me.Start_Date = Date.Parse(Row(2))

            Me._Bill = CDbl(Row(5))

            Me.End_Date = Date.Parse(Row(3))

            Me.Is_PlayStationDevice = CBool(Row(8))



            If CStr(Row(11)) = "(1)" Then
                _ISChangedDeviceNONE = True
                _ISChangedDeviceValued = False
                IsDeviceChanged = True
            End If

            If CStr(Row(11)) = "(2)" Then
                _ISChangedDeviceNONE = False
                _ISChangedDeviceValued = True
                IsDeviceChanged = True
            End If
            If CStr(Row(11)) = "(0)" Then
                _ISChangedDeviceNONE = False
                _ISChangedDeviceValued = False
                IsDeviceChanged = False
            End If


            If CStr(Row(11)).Contains(",") Then
                IsDeviceChanged = True
            End If

            '       MsgBox(CDbl(Row(17)))

            Me._LogTotalbill = CDbl(Row(17))

            If Me.IsPlayStationDevice Then
                Me.Time_Limit = CInt(Row(7))
                Me.DviceType = CStr(Row(13))
                Me.TimeMinutePrice = CDbl(Row(13))
            End If
            'Catch ex As Exception
            '   LOG.[LOG](ex) 'LOG.[LOG](ex) 'LOG.[LOG](ex) ' MsgBox(ex.StackTrace)
            'End Try
        End Sub
        Public Sub IntiDeviceData(ByVal DeviceID As Integer)
            On Error Resume Next

            Dim sql As String = "SELECT * FROM `devices` WHERE `id` = '" + CStr(DeviceID.ToString) + "'"

            Dim Row As DataRow = db.executeSQL(sql)(0)
            Me.Device_ID = DeviceID
            Me.DeviceName = Row(1).ToString
            Me.Device_Type = New Device.DeviceType(CInt(Row(2)))
        End Sub
        Public Function GetMasterDeviceID() As Integer
            Dim Row As DataRow = db.executeSQL("SELECT * FROM `deviceslog` WHERE `DeviceLogChanges` LIKE '%" + CStr(Me.LogId) + "%'")(0)
            Return Row(1)
        End Function
        Public Function GetMasterDeviceLogID() As Integer
            Dim Row As DataRow = db.executeSQL("SELECT * FROM `deviceslog` WHERE `DeviceLogChanges` LIKE '%" + CStr(Me.LogId) + "%'")(0)
            Return Row(0)
        End Function
        ReadOnly Property ORGDeviceID As Integer
            Get
                Return Device_ID
            End Get
        End Property

        ReadOnly Property Name As String
            Get
                Return Me.DeviceName
            End Get
        End Property
        Property Type As DeviceType
            Set(ByVal value As DeviceType)
                Me.Device_Type = value
            End Set
            Get
                Return Me.Device_Type
            End Get
        End Property
        ReadOnly Property TypeName As String

            Get
                Return Me.DviceType
            End Get
        End Property

        ReadOnly Property TimeLimit As TimeSpan
            Get
                If Time_Limit < 0 Then
                    Time_Limit = Time_Limit * -1
                End If
                Dim hours As Integer = Time_Limit \ 60
                Dim minutes As Integer = Time_Limit - (hours * 60)
                Return New TimeSpan(hours, minutes, 0)
            End Get
        End Property
        ReadOnly Property IsPlayStationDevice As Boolean
            Get
                Return Me.Is_PlayStationDevice
            End Get
        End Property

        ReadOnly Property LogId As Integer
            Get
                Return Me.Log_Id
            End Get
        End Property
        Property StartDate As Date
            Set(ByVal value As Date)
                Me.Start_Date = value
            End Set
            Get
                Return Me.Start_Date
            End Get
        End Property
        Property EndDate As Date
            Set(ByVal value As Date)
                Me.End_Date = value
            End Set
            Get
                Return End_Date
            End Get
        End Property
        'LogTotalbill
        'ISChangedDeviceNONE
        Property ChangedDeviceNONE As Boolean
            Set(ByVal value As Boolean)
                Me._ISChangedDeviceNONE = value
            End Set
            Get

                Return Me._ISChangedDeviceNONE

            End Get
        End Property
        Property ChangedDeviceValued As Boolean
            Set(ByVal value As Boolean)
                Me._ISChangedDeviceValued = value
            End Set
            Get

                Return Me._ISChangedDeviceValued

            End Get
        End Property
        Property LogTotalbill As Double
            Set(ByVal value As Double)
                Me._LogTotalbill = value
            End Set
            Get

                Return Me._LogTotalbill

            End Get
        End Property
        Property Bill As Double
            Set(ByVal value As Double)
                Me._Bill = value
            End Set
            Get
                If IsPlayStationDevice Then
                    Return Me._Bill
                Else
                    Return Me._Bill
                End If


            End Get
        End Property
        Property SpeciesOrderCheck As String
            Set(ByVal value As String)
                Me._SpeciesOrderCheck = value
            End Set
            Get
                Return Me._SpeciesOrderCheck
            End Get
        End Property
        'Property LogData As DeviceLogData()
        '    Set(ByVal value As DeviceLogData())
        '        Me.Log_Data = value
        '    End Set
        '    Get
        '        Return Me.Log_Data
        '    End Get
        'End Property
        'ReadOnly Property TimeType As Time
        '    Get
        '        Return Me.Time_Type
        '    End Get
        'End Property
        ReadOnly Property DurationTime As TimeSpan
            Get
                Dim Sdate As Date = Me.StartDate
                Dim Nowdate As Date = Me.EndDate
                Dim span As TimeSpan = Nowdate.Subtract(Sdate)
                'MsgBox("Passed Time :" + span.Minutes)
                Return span
            End Get
        End Property
        ReadOnly Property DurationTimeMiuntes As Integer
            Get
                Return (DurationTime.Hours * 60 + DurationTime.Minutes)
            End Get
        End Property
        ReadOnly Property ISTimeLimit As Boolean
            Get
                If Me.TimeLimit.TotalMinutes = 0 Then
                    Return False
                Else
                    Return True

                End If
            End Get
        End Property
        ReadOnly Property PlayStationBill As Double
            Get

                If Not ISTimeLimit Then
                    Return (DurationTimeMiuntes * Me.TimeMinutePrice)
                Else
                    Return (TimeLimit.TotalMinutes * Me.TimeMinutePrice)
                End If

            End Get
        End Property


    End Class



    Public Class Options
        Public Enum TableDisabledSettings
            IsPlayStationDevice = 0
            ShowOvertime = 3
            ShowPassedTime = 4
            ShowCustom = 6
            StartOpend = 7
            StartImediatly = 8
            StartFiveMinutes = 9
            StartCustom = 10
            CloseImediatly = 11
            AutoCLoseTimeLimit = 13
            WarnMeLast10Minutes = 14
            WarnMeCustom = 15
            AddPlayCash = 17
            AddChangedDevicesCash = 18
            AddOverTimeCash = 19
            CanPause = 20
            AutoApplyTimeRolls = 22
            CanChangeDevice = 24
            ChangeMoveTimeOnSameType = 25
            ChangeMoveOrder = 26
            WarnMeWithSound = 27
            WarnMeWithNotifications = 28
        End Enum
        Public Enum SettingList
            IsPlayStationDevice = 0
            CanActive = 1
            IsRoomDevice = 2
            ShowOvertime = 3
            ShowPassedTime = 4
            ShowTotalcashAll = 5
            ShowCustom = 6
            StartOpend = 7
            StartImediatly = 8
            StartFiveMinutes = 9
            StartCustom = 10
            CloseImediatly = 11
            ShowCloseDialog = 12
            AutoCLoseTimeLimit = 13
            WarnMeLast10Minutes = 14
            WarnMeCustom = 15
            AddOrderCash = 16
            AddPlayCash = 17
            AddChangedDevicesCash = 18
            AddOverTimeCash = 19
            CanPause = 20
            AutoUpdate = 21
            AutoApplyTimeRolls = 22
            ShowToolTip = 23
            CanChangeDevice = 24
            ChangeMoveTimeOnSameType = 25
            ChangeMoveOrder = 26
            WarnMeWithSound = 27
            WarnMeWithNotifications = 28
        End Enum
        Enum SettingType As Short
            HighRecommended = 0
            Recommended = 1
            [Optional] = 2
        End Enum
        Public Shared HighRecommendedColor As String = "#22B14C"
        Public Shared RecommendedColor As String = "#4BACC6"
        Public Shared OptionalColor As String = "#FFC20E"
        Private CurrecntDevice As Device

        Public MainOptionString As String = ""

        Public IsPlayStationDevice, CanActive, IsRoomDevice As Boolean
        Public ShowOvertime, ShowPassedTime, ShowTotalcashAll, ShowCustom As Boolean
        Public StartOpend, StartImediatly, StartFiveMinutes, StartCustom As Boolean
        Public CloseImediatly, ShowCloseDialog, AutoCLoseTimeLimit, WarnMeLast10Minutes As Boolean
        Public WarnMeCustom As Integer = 0
        Public WarnMeWithSound As Boolean
        Public WarnMeWithNotifications As Boolean
        Public AddOrderCash, AddPlayCash, AddChangedDevicesCash, AddOverTimeCash As Boolean
        Public CanPause, AutoUpdate, AutoApplyTimeRolls, ShowToolTip As Boolean
        Public CanChangeDevice, ChangeMoveTimeOnSameType, ChangeMoveOrder As Boolean

        Public ShowCustomOptions As String = ""
        Public StartCustomOptions As Integer = False
        Public WarnMeCustomOptions As String = ""

        Public Sub New(ByVal DeviceOptions As Device)
            On Error Resume Next
            CurrecntDevice = DeviceOptions
            If DeviceOptions.RowOptionsString = "" Then
                SetDefaultDeviceValue()

                Me.SaveUpdateOptions()
            ElseIf DeviceOptions Is Nothing Then
                SetDefaultDeviceValue()
            Else

                Me.MainOptionString = DeviceOptions.RowOptionsString
                Me.ReadAndApplySettings()
            End If



        End Sub

        Public Sub SetDefaultDeviceValue()
            On Error Resume Next

            Me.IsPlayStationDevice = True
            Me.CanActive = True
            Me.IsRoomDevice = False
            Me.ShowOvertime = True
            Me.ShowPassedTime = True
            Me.ShowTotalcashAll = True
            Me.ShowCustom = False
            Me.StartOpend = True
            Me.StartImediatly = True
            Me.StartFiveMinutes = False
            Me.StartCustom = False
            Me.CloseImediatly = True
            Me.ShowCloseDialog = False
            Me.AutoCLoseTimeLimit = False
            Me.WarnMeLast10Minutes = False
            Me.WarnMeCustom = 0
            Me.AddOrderCash = True
            Me.AddPlayCash = True
            Me.AddOverTimeCash = False
            Me.AddChangedDevicesCash = True
            Me.CanPause = True
            Me.AutoUpdate = True
            Me.AutoApplyTimeRolls = True
            Me.ShowToolTip = True
            Me.CanChangeDevice = True
            Me.ChangeMoveTimeOnSameType = True
            Me.ChangeMoveOrder = True
            Me.WarnMeWithSound = False
            Me.WarnMeWithNotifications = True

            Me.MainOptionString = TOStringOptions()

        End Sub
        Public Sub SetTabel(Optional ByVal Enabled As Boolean = False)
            IsPlayStationDevice = Enabled
            ShowOvertime = Enabled
            ShowPassedTime = Enabled
            ShowCustom = Enabled
            StartOpend = Enabled
            StartImediatly = Enabled
            StartFiveMinutes = Enabled
            StartCustom = Enabled
            CloseImediatly = Enabled
            AutoCLoseTimeLimit = Enabled
            WarnMeLast10Minutes = Enabled
            WarnMeCustom = Enabled
            AddPlayCash = Enabled
            AddChangedDevicesCash = Enabled
            AddOverTimeCash = Enabled
            CanPause = Enabled
            AutoApplyTimeRolls = Enabled
            CanChangeDevice = Enabled
            ChangeMoveTimeOnSameType = Enabled
            ChangeMoveOrder = Enabled
            WarnMeWithSound = Enabled
            WarnMeWithNotifications = Enabled
        End Sub
        Public Function ReadAndApplySettings() As Boolean
            '  On Error Resume Next
            Try

                Dim DataSplited As String() = MainOptionString.Split(",")

                Me.IsPlayStationDevice = CBool(DataSplited(0))
                Me.CanActive = CBool(DataSplited(1))
                Me.IsRoomDevice = CBool(DataSplited(2))
                Me.ShowOvertime = CBool(DataSplited(3))
                Me.ShowPassedTime = CBool(DataSplited(4))
                Me.ShowTotalcashAll = CBool(DataSplited(5))
                Me.ShowCustom = CBool(DataSplited(6))
                Me.StartOpend = CBool(DataSplited(7))
                Me.StartImediatly = CBool(DataSplited(8))
                Me.StartFiveMinutes = CBool(DataSplited(9))
                Me.StartCustom = CBool(DataSplited(10))
                Me.CloseImediatly = CBool(DataSplited(11))
                Me.ShowCloseDialog = CBool(DataSplited(12))
                Me.AutoCLoseTimeLimit = CBool(DataSplited(13))
                Me.WarnMeLast10Minutes = CBool(DataSplited(14))
                Me.WarnMeCustom = CInt(DataSplited(15))
                Me.AddOrderCash = CBool(DataSplited(16))
                Me.AddPlayCash = CBool(DataSplited(17))
                Me.AddOverTimeCash = CBool(DataSplited(18))
                Me.AddChangedDevicesCash = CBool(DataSplited(19))
                Me.CanPause = CBool(DataSplited(20))
                Me.AutoUpdate = CBool(DataSplited(21))
                Me.AutoApplyTimeRolls = CBool(DataSplited(22))
                Me.ShowToolTip = CBool(DataSplited(23))
                Me.CanChangeDevice = CBool(DataSplited(24))
                Me.ChangeMoveTimeOnSameType = CBool(DataSplited(25))
                Me.ChangeMoveOrder = CBool(DataSplited(26))
                Me.WarnMeWithSound = CBool(DataSplited(27))
                '  MsgBox(DataSplited(28))
                Me.WarnMeWithNotifications = CBool(DataSplited(28))
                Return True
            Catch ex As Exception
                LOG.[LOG](ex) '   MsgBox("Error Reading Setting Default Setting" + ex.StackTrace)
                SetDefaultDeviceValue()
                '  Me.MainOptionString = TOStringOptions()
                Me.SaveUpdateOptions()
                Return False
            End Try


        End Function
        Public Function TOStringOptions() As String
            Try



                Dim ResultStringData As String = ""
                Dim MainDataStructure As String = _
                    "{0},{1},{2},{3},{4},{5},{6},{7},{8}" & _
                     ",{9},{10},{11},{12},{13},{14},{15}" & _
                     ",{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28}"
                ResultStringData = String.Format(MainDataStructure, GetSetting(SettingList.IsPlayStationDevice.ToString) _
                                                 , GetSetting(SettingList.CanActive.ToString) _
                                                 , GetSetting(SettingList.IsRoomDevice.ToString) _
                                                  , GetSetting(SettingList.ShowOvertime.ToString) _
                                            , GetSetting(SettingList.ShowPassedTime.ToString) _
                                            , GetSetting(SettingList.ShowTotalcashAll.ToString) _
                                             , GetSetting(SettingList.StartOpend.ToString) _
                                            , GetSetting(SettingList.StartImediatly.ToString) _
                                             , GetSetting(SettingList.StartFiveMinutes.ToString) _
                                             , GetSetting(SettingList.StartCustom.ToString) _
                                            , GetSetting(SettingList.ShowCustom.ToString) _
                                             , GetSetting(SettingList.CloseImediatly.ToString) _
                                             , GetSetting(SettingList.ShowCloseDialog.ToString) _
                                            , GetSetting(SettingList.AutoCLoseTimeLimit.ToString) _
                                            , GetSetting(SettingList.WarnMeLast10Minutes.ToString) _
                                            , GetSetting(SettingList.WarnMeCustom.ToString) _
                                            , GetSetting(SettingList.AddOrderCash.ToString) _
                                            , GetSetting(SettingList.AddPlayCash.ToString) _
                                            , GetSetting(SettingList.AddChangedDevicesCash.ToString) _
                                            , GetSetting(SettingList.AddOverTimeCash.ToString) _
                                            , GetSetting(SettingList.CanPause.ToString) _
                                            , GetSetting(SettingList.AutoUpdate.ToString) _
                                            , GetSetting(SettingList.AutoApplyTimeRolls.ToString) _
                                            , GetSetting(SettingList.ShowToolTip.ToString) _
                                            , GetSetting(SettingList.CanChangeDevice.ToString) _
                                            , GetSetting(SettingList.ChangeMoveTimeOnSameType.ToString) _
                                            , GetSetting(SettingList.ChangeMoveOrder.ToString) _
                                            , GetSetting(SettingList.WarnMeWithSound.ToString) _
                                            , GetSetting(SettingList.WarnMeWithNotifications.ToString))
                ' MsgBox(GetSetting(SettingList.WarnMeWithNotifications.ToString))
                'Application.DoEvents()
                Return ResultStringData
            Catch ex As Exception
                LOG.[LOG](ex) 'LOG.[LOG](ex) 'LOG.[LOG](ex) ' MsgBox(ex.StackTrace)
                Return ""
            End Try

        End Function
        Public Function GetSetting(ByVal Setting As String) As Object
            '   On Error Resume Next
            Try


                ' ReadAndApplySettings()
                If Setting = SettingList.IsPlayStationDevice.ToString Then
                    Return IsPlayStationDevice
                ElseIf Setting = SettingList.CanActive.ToString Then
                    Return CanActive
                ElseIf Setting = SettingList.IsRoomDevice.ToString Then
                    Return IsRoomDevice
                ElseIf Setting = SettingList.ShowOvertime.ToString Then
                    Return ShowOvertime
                ElseIf Setting = SettingList.ShowPassedTime.ToString Then
                    Return ShowPassedTime

                ElseIf Setting = SettingList.ShowTotalcashAll.ToString Then
                    Return ShowTotalcashAll

                ElseIf Setting = SettingList.ShowCustom.ToString Then
                    Return ShowCustom

                ElseIf Setting = SettingList.StartOpend.ToString Then
                    Return StartOpend

                ElseIf Setting = SettingList.StartImediatly.ToString Then
                    Return StartImediatly
                ElseIf Setting = SettingList.StartFiveMinutes.ToString Then
                    Return StartFiveMinutes
                ElseIf Setting = SettingList.StartCustom.ToString Then
                    Return StartCustom
                ElseIf Setting = SettingList.CloseImediatly.ToString Then
                    Return CloseImediatly
                ElseIf Setting = SettingList.ShowCloseDialog.ToString Then
                    Return ShowCloseDialog
                ElseIf Setting = SettingList.AutoCLoseTimeLimit.ToString Then
                    Return AutoCLoseTimeLimit

                ElseIf Setting = SettingList.WarnMeLast10Minutes.ToString Then
                    Return WarnMeLast10Minutes
                ElseIf Setting = SettingList.WarnMeCustom.ToString Then
                    Return WarnMeCustom.ToString
                ElseIf Setting = SettingList.AddOrderCash.ToString Then
                    Return AddOrderCash
                ElseIf Setting = SettingList.AddPlayCash.ToString Then
                    Return AddPlayCash
                ElseIf Setting = SettingList.AddChangedDevicesCash.ToString Then
                    Return AddChangedDevicesCash
                ElseIf Setting = SettingList.AddOverTimeCash.ToString Then
                    Return AddOverTimeCash
                ElseIf Setting = SettingList.CanPause.ToString Then
                    Return CanPause
                ElseIf Setting = SettingList.AutoUpdate.ToString Then
                    Return AutoUpdate
                ElseIf Setting = SettingList.AutoApplyTimeRolls.ToString Then
                    Return AutoApplyTimeRolls
                ElseIf Setting = SettingList.ShowToolTip.ToString Then
                    Return ShowToolTip
                ElseIf Setting = SettingList.CanChangeDevice.ToString Then
                    Return CanChangeDevice
                ElseIf Setting = SettingList.ChangeMoveTimeOnSameType.ToString Then
                    Return ChangeMoveTimeOnSameType
                ElseIf Setting = SettingList.ChangeMoveOrder.ToString Then
                    Return ChangeMoveOrder
                ElseIf Setting = SettingList.WarnMeWithSound.ToString Then
                    Return WarnMeWithSound
                ElseIf Setting = SettingList.WarnMeWithNotifications.ToString Then
                    Return WarnMeWithNotifications
                    'ChangeMoveOrder
                End If
            Catch ex As Exception
                LOG.[LOG](ex) 'LOG.[LOG](ex) ' MsgBox(ex.StackTrace)
            End Try
        End Function
        Public Sub SetSetting(ByVal Setting As String, ByVal Value As Object)
            If Setting = SettingList.IsPlayStationDevice.ToString Then
                IsPlayStationDevice = Value
            ElseIf Setting = SettingList.CanActive.ToString Then
                CanActive = Value
            ElseIf Setting = SettingList.IsRoomDevice.ToString Then
                IsRoomDevice = Value
            ElseIf Setting = SettingList.ShowOvertime.ToString Then
                ShowOvertime = Value
            ElseIf Setting = SettingList.ShowPassedTime.ToString Then
                ShowPassedTime = Value

            ElseIf Setting = SettingList.ShowTotalcashAll.ToString Then
                ShowTotalcashAll = Value

            ElseIf Setting = SettingList.ShowCustom.ToString Then
                ShowCustom = Value

            ElseIf Setting = SettingList.StartOpend.ToString Then
                StartOpend = Value

            ElseIf Setting = SettingList.StartImediatly.ToString Then
                StartImediatly = Value
            ElseIf Setting = SettingList.StartFiveMinutes.ToString Then
                StartFiveMinutes = Value
            ElseIf Setting = SettingList.StartCustom.ToString Then
                StartCustom = Value
            ElseIf Setting = SettingList.CloseImediatly.ToString Then
                CloseImediatly = Value
            ElseIf Setting = SettingList.ShowCloseDialog.ToString Then
                ShowCloseDialog = Value
            ElseIf Setting = SettingList.AutoCLoseTimeLimit.ToString Then
                AutoCLoseTimeLimit = Value

            ElseIf Setting = SettingList.WarnMeLast10Minutes.ToString Then
                WarnMeLast10Minutes = Value
            ElseIf Setting = SettingList.WarnMeCustom.ToString Then
                WarnMeCustom = CInt(Value)
            ElseIf Setting = SettingList.AddOrderCash.ToString Then
                AddOrderCash = Value
            ElseIf Setting = SettingList.AddPlayCash.ToString Then
                AddPlayCash = Value
            ElseIf Setting = SettingList.AddChangedDevicesCash.ToString Then
                AddChangedDevicesCash = Value
            ElseIf Setting = SettingList.AddOverTimeCash.ToString Then
                AddOverTimeCash = Value
            ElseIf Setting = SettingList.AutoUpdate.ToString Then
                AutoUpdate = Value
            ElseIf Setting = SettingList.AutoApplyTimeRolls.ToString Then
                AutoApplyTimeRolls = Value
            ElseIf Setting = SettingList.ShowToolTip.ToString Then
                ShowToolTip = Value
            ElseIf Setting = SettingList.CanChangeDevice.ToString Then
                CanChangeDevice = Value
            ElseIf Setting = SettingList.ChangeMoveTimeOnSameType.ToString Then
                ChangeMoveTimeOnSameType = Value
            ElseIf Setting = SettingList.ChangeMoveOrder.ToString Then
                ChangeMoveOrder = Value
            ElseIf Setting = SettingList.WarnMeWithSound.ToString Then
                WarnMeWithSound = Value
            ElseIf Setting = SettingList.WarnMeWithNotifications.ToString Then
                WarnMeWithNotifications = Value
            End If

        End Sub

        Public Shared Function GetOptionRecommended(ByVal Setting As String) As SettingType
            If Setting.ToString = SettingList.IsPlayStationDevice.ToString Then
                Return SettingType.HighRecommended
            ElseIf Setting.ToString = SettingList.CanActive.ToString Then
                Return SettingType.HighRecommended
            ElseIf Setting.ToString = SettingList.IsRoomDevice.ToString Then
                Return SettingType.Optional
            ElseIf Setting.ToString = SettingList.ShowOvertime.ToString Then
                Return SettingType.Recommended
            ElseIf Setting.ToString = SettingList.ShowPassedTime.ToString Then
                Return SettingType.Recommended

            ElseIf Setting.ToString = SettingList.ShowTotalcashAll.ToString Then
                Return SettingType.Recommended

            ElseIf Setting.ToString = SettingList.ShowCustom.ToString Then
                Return SettingType.Optional

            ElseIf Setting.ToString = SettingList.StartOpend.ToString Then
                Return SettingType.HighRecommended

            ElseIf Setting.ToString = SettingList.StartImediatly.ToString Then
                Return SettingType.Recommended
            ElseIf Setting.ToString = SettingList.StartFiveMinutes.ToString Then
                Return SettingType.Optional
            ElseIf Setting.ToString = SettingList.StartCustom.ToString Then
                Return SettingType.Optional
            ElseIf Setting.ToString = SettingList.CloseImediatly.ToString Then
                Return SettingType.Optional
            ElseIf Setting.ToString = SettingList.ShowCloseDialog.ToString Then
                Return SettingType.HighRecommended
            ElseIf Setting.ToString = SettingList.AutoCLoseTimeLimit.ToString Then
                Return SettingType.Optional

            ElseIf Setting.ToString = SettingList.WarnMeLast10Minutes.ToString Then
                Return SettingType.HighRecommended
            ElseIf Setting.ToString = SettingList.WarnMeCustom.ToString Then
                Return SettingType.Optional
            ElseIf Setting.ToString = SettingList.AddOrderCash.ToString Then
                Return SettingType.Recommended
            ElseIf Setting.ToString = SettingList.AddPlayCash.ToString Then
                Return SettingType.Recommended
            ElseIf Setting.ToString = SettingList.AddChangedDevicesCash.ToString Then
                Return SettingType.Recommended
            ElseIf Setting.ToString = SettingList.AddOverTimeCash.ToString Then
                Return SettingType.Optional
            ElseIf Setting.ToString = SettingList.AutoUpdate.ToString Then
                Return SettingType.HighRecommended
            ElseIf Setting.ToString = SettingList.AutoApplyTimeRolls.ToString Then
                Return SettingType.Recommended
            ElseIf Setting.ToString = SettingList.ShowToolTip.ToString Then
                Return SettingType.Recommended
            ElseIf Setting.ToString = SettingList.CanChangeDevice.ToString Then
                Return SettingType.Optional
            ElseIf Setting.ToString = SettingList.ChangeMoveTimeOnSameType.ToString Then
                Return SettingType.HighRecommended
            ElseIf Setting.ToString = SettingList.ChangeMoveOrder.ToString Then
                Return SettingType.Recommended
            ElseIf Setting.ToString = SettingList.WarnMeWithSound.ToString Then
                Return SettingType.Optional
            ElseIf Setting.ToString = SettingList.WarnMeWithNotifications.ToString Then
                Return SettingType.Recommended

                'ChangeMoveOrder
            End If
        End Function
        Public Sub SaveUpdateOptions()
            On Error Resume Next
            Dim Hp As New Helper
            Hp.GlobalUpdate("devices", "`Options`='" + Me.TOStringOptions + "'", "id", CStr(Me.CurrecntDevice.Id))
        End Sub

    End Class



    Public Class DeviceType
        Dim DB As New DataBaseConnection
        Private DeviceTypeID As Integer
        Private DeviceTypeName As String
        Public Sub New(ByVal DeviceTypeId As Integer)
            Try


                Dim sql As String = "SELECT * FROM `devicetype` WHERE `id` = '" + CStr(DeviceTypeId) + "'"
                Dim Row As DataRow = DB.executeSQL(sql)(0)

                Me.DeviceTypeID = DeviceTypeId
                Me.Name = Row(1)
            Catch ex As Exception
                Exit Sub
            End Try
        End Sub
        ReadOnly Property Id As Integer
            Get
                Return Me.DeviceTypeID
            End Get
        End Property

        Property Name As String
            Set(ByVal value As String)
                Me.DeviceTypeName = value
            End Set
            Get
                Return Me.DeviceTypeName
            End Get
        End Property
        Public Shared Function InsertDeviceType(ByVal name As String) As Integer
            Dim DB As New DataBaseConnection
            Dim Sql = "INSERT INTO `devicetype` (`id`, `Name`) VALUES (NULL, '" + name + "');"
            Return DB.executeDMLSQL(Sql)
        End Function
        Public Function Update() As Integer
            Dim sql As String = "UPDATE `devicetype` SET `Name`='" + Me.Name + "' WHERE `id`='" + CStr(Me.Id) + "'"
            Return DB.executeDMLSQL(sql)

        End Function
        Public Function Delete()
            Dim SQl = "DELETE FROM `devicetype` WHERE `Id` ='" + Str(Me.Id) + "'"
            Return DB.executeDMLSQL(SQl)
        End Function
        Public Shared Function GetDeviceTypes() As List(Of Device.DeviceType)
            On Error Resume Next
            Dim returnValue As New List(Of Device.DeviceType)
            Dim DB As New DataBaseConnection
            Dim sql As String = "SELECT * FROM `devicetype` WHERE 1"
            Dim Row As DataRowCollection = DB.executeSQL(sql)
            For Each rw As DataRow In Row
                returnValue.Add(New Device.DeviceType(CInt(rw(0))))
            Next
            Return returnValue
        End Function
    End Class

End Class
