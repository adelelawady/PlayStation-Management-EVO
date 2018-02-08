Public Class ScheduleObject
    Dim db As New DataBaseConnection

    Private _id As Integer
    Private _Type, _ObjectID, _DateS, _DateE, _WarnBefore, _Client, _User, _Objectname, _Paid, _Phone As String
    ReadOnly Property ID As Integer
        Get
            Return _id
        End Get
    End Property
    ReadOnly Property Type As String
        Get
            Return _Type
        End Get
    End Property
    ReadOnly Property ObjectID As String
        Get
            Return _ObjectID
        End Get
    End Property
    ReadOnly Property StartDate As Date
        Get
            Return Date.Parse(_DateS)
        End Get
    End Property
    ReadOnly Property EndDate As Date
        Get
            Return Date.Parse(_DateE)
        End Get
    End Property

    ReadOnly Property WarnBefore As String
        Get
            Return _WarnBefore
        End Get
    End Property
    '_Client
    ReadOnly Property Client As String
        Get
            Return _Client
        End Get
    End Property
    ReadOnly Property User As String
        Get
            Return _User
        End Get
    End Property
    ReadOnly Property ObjectName As String
        Get
            Return _Objectname
        End Get
    End Property
    ReadOnly Property Paid As Double
        Get
            Return CDbl(_Paid)
        End Get
    End Property
    ReadOnly Property ISEnded As Boolean
        Get
            If Not IsActive Then


                If IsWarning Then
                    Return False
                Else
                    If StartIn.TotalMinutes > 0 Then
                        Return False
                    Else
                        Return True
                    End If

                End If
            Else
                Return False
            End If
        End Get
    End Property
    ReadOnly Property StartIn As TimeSpan
        Get
            Dim Sdate As Date = Date.Now
            Dim Nowdate As Date = Me.StartDate
            Dim span As TimeSpan = Nowdate.Subtract(Sdate)
            Return span
        End Get
    End Property
    ReadOnly Property IsActive As Boolean
        Get
            Dim Sql As String = "SELECT * FROM `schedule` WHERE `id`='" + CStr(ID) + "' and `StartDate` <= '" + Date.Now.ToString(time_Format) + "' AND `EndDate` >= '" + Date.Now.ToString(time_Format) + "'"
            '  Clipboard.SetText(Sql)

            Dim drrows As DataRowCollection = db.executeSQL(Sql)
            If drrows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        End Get
    End Property
    Public Function CheckScheduleOnDeviceLog() As Boolean
        On Error Resume Next

        Dim dbX As New DataBaseConnection
        Dim sql = "SELECT * FROM `deviceslog` WHERE `SheduleID`='" + Me.ID.ToString + "' LIMIT 1"
        If dbX.executeSQL(sql).Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    ReadOnly Property IsWarning As Boolean
        Get
            If Not IsActive Then


                Dim Sql As String = "SELECT * FROM `schedule` WHERE `id`='" + CStr(ID) + "' and `StartDate` >= '" + Date.Now.ToString(time_Format) + "' AND `EndDate` <= '" + Date.Now.AddMinutes(CInt(Me.WarnBefore)).ToString(time_Format) + "'"
                Clipboard.SetText(Sql)

                Dim drrows As DataRowCollection = db.executeSQL(Sql)
                If drrows.Count > 0 Then
                    If StartIn.TotalMinutes > WarnBefore Then
                        Return False
                    Else
                        Return True
                    End If

                Else
                    Return False
                End If
            Else

                Return False

            End If
        End Get
    End Property
   
    Public Sub New(ByVal ScheduleID As String, Optional ByVal ById As Boolean = True)
        Try

      
        Dim Sql As String
        If ById Then
            Sql = "SELECT * FROM `Schedule` WHERE `id`='" + ScheduleID + "'"
        Else
            Sql = "SELECT * FROM `Schedule` WHERE `SpectialGetById` ='" + ScheduleID + "'"
        End If

        Dim drrows As DataRow = db.executeSQL(Sql)(0)
        If ById Then
            Me._id = ScheduleID
        Else
            Me._id = drrows(0)
        End If
        Me._Type = drrows(1)
        Me._ObjectID = drrows(2)
        Me._DateS = drrows(3)
        Me._DateE = drrows(4)
        Me._WarnBefore = drrows(5)
        Me._Client = drrows(6)
        Me._User = drrows(7)
        Me._Objectname = drrows(8)
        Me._Paid = drrows(9)
            Me._Phone = drrows(11)
        Catch ex As Exception
            LOG.[LOG](ex)

        End Try
    End Sub
    Public Shared Function CheckScheduleOnDeviceLog(ByVal schid As String) As Boolean
        On Error Resume Next

        Dim dbX As New DataBaseConnection
        Dim sql = "SELECT * FROM `deviceslog` WHERE `SheduleID`='" + schid + "' LIMIT 1"
        If dbX.executeSQL(sql).Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function GetTodayDeviceSchedules(ByVal Object_ID As String) As List(Of ScheduleObject)
        Dim timeFormatxx As String = "yyyy-MM-dd HH:mm:ss"
        Dim Sql As String = "SELECT * FROM `schedule` WHERE `ObjectID`='" + CStr(Object_ID) + "' AND `StartDate` BETWEEN '" + Date.Now.Date.ToString(timeFormatxx) + "' AND '" + Date.Now.Date.AddHours(23).AddMinutes(59).AddDays(1).ToString(timeFormatxx) + "' AND `EndDate` BETWEEN '" + Date.Now.Date.ToString(timeFormatxx) + "' AND '" + Date.Now.Date.AddHours(23).AddMinutes(59).AddDays(1).ToString(timeFormatxx) + "' ORDER BY `schedule`.`StartDate` ASC"
        ' Clipboard.SetText(Sql)
        ' Clipboard.SetText(Sql)
        Dim db As New DataBaseConnection
        Dim drrows As DataRowCollection = db.executeSQL(Sql)
        Dim ScheduleList As New List(Of ScheduleObject)
        For Each Dr As DataRow In drrows
            If Not CheckScheduleOnDeviceLog(Dr(0)) Then


                Dim sch As New ScheduleObject(Dr(0))
                '   MsgBox(Object_ID + "  " + sch.ObjectName)
                ScheduleList.Add(sch)
            End If
        Next
        Return ScheduleList
    End Function
    Public Function GetDuration() As TimeSpan
        Dim Sdate As Date = Me.StartDate
        Dim Nowdate As Date = Me.EndDate
        Dim span As TimeSpan = Nowdate.Subtract(Sdate)
    End Function
    Public Shared Function CheckSchuduleDateExsits(ByVal ObjectId As String, ByVal startdate As Date, ByVal enddate As Date) As ScheduleObject
        ' Try
        On Error Resume Next

        On Error Resume Next
        Dim dbX As New DataBaseConnection
        Dim timeFormatxx As String = "yyyy-MM-dd HH:mm:ss"

        Dim Sql As String = "SELECT * FROM `schedule` WHERE `ObjectID`='" + CStr(ObjectId) + "' and `StartDate` <= '" + startdate.ToString(timeFormatxx) + "' AND `EndDate` >= '" + startdate.ToString(timeFormatxx) + "'"

        ' Clipboard.SetText(Sql)
        Dim drrows As DataRowCollection = dbX.executeSQL(Sql)
        If drrows.Count > 0 Then
            Return New ScheduleObject(CStr(drrows(0)(0)))
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    LOG.[LOG](ex) ' MsgBox(ex.Message)
        '    Return Nothing
        'End Try
    End Function

    Public Shared Function GetSchedules() As DataRowCollection
        Dim dbX As New DataBaseConnection
        Dim Sql As String = "SELECT * FROM `Schedule`"
        Dim drrows As DataRowCollection = dbX.executeSQL(Sql)
        Return drrows
    End Function

    Public Function GetObjectSchedule() As DevComponents.Schedule.Model.Appointment

        Dim appointment As New DevComponents.Schedule.Model.Appointment()
        appointment.Tag = Me
        appointment.StartTime = Me.StartDate
        appointment.EndTime = Me.EndDate
        appointment.Locked = True
        If Me.CheckScheduleOnDeviceLog Or Me.ISEnded Then
            appointment.CategoryColor = DevComponents.Schedule.Model.Appointment.CategoryRed
        End If

        appointment.Subject = Type + ": " + Me.ObjectName
        appointment.Description += "[DeviceId]:" + Me.ObjectID + vbNewLine
        appointment.Description += "[Paid] : " + Me.Paid.ToString + vbNewLine
        appointment.Description += "[Client] : " + Me.Client + vbNewLine
        appointment.Description += "[MadeBy] : " + Me.User + vbNewLine
        appointment.Tooltip = Type + " : " + Me.ObjectName + " [" + Me.Client + "]"
        Return appointment
    End Function
    Public Shared timeFormat As String = "yyyy-MM-dd HH:mm:ss"
    Private time_Format As String = "yyyy-MM-dd HH:mm:ss"
    Public Shared Function InsertSchedule(ByVal _Type As String, ByVal _ObjectID As String, ByVal _DateS As String, ByVal _DateE As String, ByVal _WarnBefore As String, ByVal _Client As String, ByVal _User As String, ByVal _ObjectName As String, ByVal _Paid As Double, ByVal _Phone As String) As String
        Dim helper As New Helper


        Dim ResultToken As String = _Type + _ObjectID + _DateS.ToString + _DateE.ToString + _WarnBefore + _Paid.ToString + _User

        If helper.GlobalInsert("Schedule", "`Type`, `ObjectID`, `StartDate`, `EndDate`, `WarnBefore`, `Client`, `User`,`Objectname`,`Paid`,`SpectialGetById`,`phone`", "'" + _Type + "','" + _ObjectID + "','" + _DateS.ToString() + "','" + _DateE.ToString() + "','" + _WarnBefore + "','" + _Client + "','" + _User + "','" + _ObjectName + "','" + CStr(_Paid) + "','" + CStr(ResultToken) + "','" + CStr(_Phone) + "'") = 1 Then
            '  MsgBox(ResultToken)
            Return ResultToken
        End If

    End Function
    Public Function DeleteSchedule() As Integer
        Dim helper As New Helper
        Return helper.GlobalDelete("Schedule", "id", ID)
    End Function
End Class
