Public Class Time
    Dim DB As New DataBaseConnection
    Private _Minutes As Double
    Private _Id As Integer
    Private _DeviceType As Device.DeviceType
    Private _price As Double
    Private Time_Rols As New List(Of TimeRole)
    Public TimeRolsRowString As String = ""
    Private HasTimeRolles As Boolean = False
    Public Sub New(ByVal TimeId As Integer)
        Dim Sql As String = "SELECT * FROM `time` WHERE `id` = '" + CStr(TimeId) + "'"
        Dim Row As DataRow = DB.executeSQL(Sql)(0)
        Me._Id = TimeId
        Me._Minutes = CDbl(Row(1))
        Me._DeviceType = New Device.DeviceType(CInt(Row(2)))
        Me._price = CDbl(Row(3))
        If Not CStr(Row(4)) = "0" Then
            HasTimeRolles = True
            TimeRolsRowString = Row(4)
            LoadTimeRoles()
        End If
    End Sub
    Public Sub New(ByVal Devicetype As String, Optional ByVal DV As String = "")
        On Error Resume Next
        Dim Sql As String = "SELECT * FROM `time` WHERE `Devicetype` = '" + CStr(Devicetype) + "'"
        Dim Row As DataRow = DB.executeSQL(Sql)(0)
        Me._Id = CInt(Row(0))
        Me._Minutes = CDbl(Row(1))
        Me._DeviceType = New Device.DeviceType(Devicetype)
        Me._price = CDbl(Row(3))
        If Not CStr(Row(4)) = "0" Then
            HasTimeRolles = True
            TimeRolsRowString = Row(4)
            LoadTimeRoles()
        End If
    End Sub
    Public Sub LoadTimeRoles()
        On Error Resume Next

        If HasTimeRolles = True Then
            Dim Rolles As String() = TimeRolsRowString.Split(",")
            Time_Rols.Clear()
            For Each Str As String In Rolles
                If Not Str = "" Then
                    Time_Rols.Add(New TimeRole(CInt(Str)))
                End If
            Next

        End If

    End Sub
    Public Function addTimeRole(ByVal RoleId As Integer)
        On Error Resume Next
        Dim NewRole As TimeRole = New TimeRole(CInt(RoleId))
        Me.HasTimeRolles = True
        LoadTimeRoles()
        Me.Time_Rols.Add(NewRole)
        Me.TimeRolsRowString = GetRollsString() + "," + NewRole.ID
        Me.UpdateTime()
        LoadTimeRoles()
    End Function
    Public Function GetRollsString(Optional ByVal Exloude As String = "") As String
        On Error Resume Next
        LoadTimeRoles()
        Dim resultstr As String = ""
        Dim Counter As Integer = 0

        For Each Role As TimeRole In Me.Time_Rols
            If Not Exloude = "" Then
                If Not Role.ID = CInt(Exloude) Then
                    If Counter = 0 Then
                        resultstr += CStr(Role.ID)
                    Else
                        resultstr += "," + CStr(Role.ID)
                    End If
                End If
            Else
                If Counter = 0 Then
                    resultstr += CStr(Role.ID)
                Else
                    resultstr += "," + CStr(Role.ID)
                End If
            End If

        Next
        Return resultstr
    End Function
    ReadOnly Property ID As Integer
        Get
            Return _Id
        End Get
    End Property
    ReadOnly Property TimeRols As List(Of TimeRole)
        Get
            Return Me.Time_Rols
        End Get
    End Property

    Property Miuntes As Integer
        Set(ByVal value As Integer)
            Me._Minutes = value

        End Set
        Get
            Return Me._Minutes
        End Get
    End Property
    ReadOnly Property MiuntesPrice As Double
        Get
            Return (Me.Price / Me._Minutes)
        End Get
    End Property
    Property DeviceType As Device.DeviceType
        Set(ByVal value As Device.DeviceType)
            Me._DeviceType = value

        End Set
        Get
            Return Me._DeviceType
        End Get
    End Property
    Property Price As Double
        Set(ByVal value As Double)
            Me._price = value

        End Set
        Get
            Return Me._price
        End Get
    End Property


    Public Shared Function insertTime(ByVal Miuntes_ As Integer, ByVal DeviceId_ As Integer, ByVal price_ As Double) As Integer
        On Error Resume Next
        Dim HP As New Helper()
        Return HP.GlobalInsert("time", "`id`, `Minutes`, `Devicetype`, `Price`", "NULL,'" + CStr(Miuntes_) + "','" + CStr(DeviceId_) + "','" + CStr(price_) + "'")
    End Function

    Public Function UpdateTime() As Integer
        On Error Resume Next
        Dim HP As New Helper()
        Return HP.GlobalUpdate("time", "`Minutes`='" + CStr(Me.Miuntes) + "',`Devicetype`='" + CStr(Me.DeviceType.Id) + "',`Price`='" + CStr(Me.Price) + "'" + IIf(HasTimeRolles, ",`TimeRolles`='" + CStr(Me.TimeRolsRowString) + "'", Nothing), "id", CStr(Me.ID))
    End Function


    Public Function DeleteTime() As Integer
        Dim HP As New Helper()
        Return HP.GlobalDelete("time", "id", CStr(Me.ID))
    End Function
    Public Shared Function GetTimeList() As List(Of Time)
        On Error Resume Next
        Dim DB As New DataBaseConnection
        Dim returnValue As New List(Of Time)
        Dim Sql As String = "SELECT * FROM `time` WHERE 1"
        Dim Row As DataRowCollection = DB.executeSQL(Sql)
        For Each rw As DataRow In Row
            returnValue.Add(New Time(CInt(rw(0))))
        Next
        Return returnValue
    End Function
    Public Class TimeRole
        Dim DB As New DataBaseConnection
        Private _Id As Integer
        Private _MinutesStart, _MinutesEnd As Integer
        Private _Name As String
        ReadOnly Property ID As Integer
            Get
                Return _Id
            End Get
        End Property
        Property Name As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property
        Property MinutesStart As Integer
            Set(ByVal value As Integer)
                _MinutesStart = value
            End Set
            Get
                Return Me._MinutesStart
            End Get
        End Property
        Property MinutesEnd As Integer
            Set(ByVal value As Integer)
                _MinutesEnd = value
            End Set
            Get
                Return Me._MinutesEnd
            End Get
        End Property

        Public Sub New(ByVal TimeRoleId As Integer)
            Dim Sql As String = "SELECT * FROM `timeroles` WHERE `id` = '" + CStr(TimeRoleId) + "'"
            Dim Row As DataRow = DB.executeSQL(Sql)(0)
            Me._Id = CInt(Row(0))

            Me._Name = CStr(Row(1))
            Me._MinutesStart = CInt(Row(2))
            Me._MinutesEnd = CInt(Row(3))

        End Sub
        Public Shared Function insertTimeRole(ByVal Name As String, ByVal MinuteStart As Integer, ByVal MinuteEnd As Integer)
            On Error Resume Next
            Dim HP As New Helper()
            Return HP.GlobalInsert("timeroles", "`Name`,`MinutesStart`,`MinutesEnd`", "'" + Name + "','" + MinuteStart + "','" + MinuteEnd + "'")

        End Function
        Public Function UpdateTimeRole() As Integer
            On Error Resume Next
            Dim HP As New Helper()
            Return HP.GlobalUpdate("timeroles", "`Name`='" + Name + "'," + "`MinutesStart`='" + Me.MinutesStart + "'," + "`MinutesEnd`='" + Me.MinutesEnd + "'", "id", CStr(Me.ID))

        End Function
        Public Function DeleteTimeRole() As Integer
            Dim HP As New Helper()
            Return HP.GlobalDelete("timeroles", "id", CStr(Me.ID))
        End Function
        ' ({START_Minutes} = 45 and {EndMinutes} < 60)  -> 60
        '({START_Minutes} = 0 and {EndMinutes} < 15) -> 15



    End Class
End Class
