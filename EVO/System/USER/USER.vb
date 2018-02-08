
<Serializable()>
Public Class USER
    Public UserName, Password As String
    'Pages Access
    Public [DeviceControlPanel] As Object = True
    Public [DeviceTypePanel] As Object = False
    Public [DeviceLogHistory] As Object = False
    Public [schdule] As Object = True
    Public [PlayStationTab] As Object = True
    Public [SpeciesControllerPanel] As Object = False

    'Device Options
    Public [CanEditTotalBill] As Object = False
    Public [CanAddAdditionalCash] As Object = True
    Public [CanStartCloseSession] As Object = False
    Public [CanCreateDevice] As Object = False
    Public [CanDeleteDevice] As Object = False
    Public [CanUpdateDevice] As Object = False
    Public [CanDeleteDeviceLog] As Object = False
    Public [CanStartDeviceLog] As Object = False
    Public [CanAddTime] As Object = True
    Public [CanRemoveTime] As Object = True

    Public [CanAddSpecies] As Object = True
    Public [CanRemoveSpecies] As Object = True

    Public [CanUpdateStartTime] As Object = False
    Public [CanChangedDevice] As Object = True
    Public [CanSetOffers] As Object = True

    'Schdule
    Public [CanCreateSchedule] As Object = True
    Public [CanDeleteSchedule] As Object = True

    'User
    Public [Admin] As Object = False
    Public [Normal] As Object = True
    Public [Theme] As Object
    Public [ThemeColor] As Object






    Public Function Serialize() As String
        Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim mem As New IO.MemoryStream
        bf.Serialize(mem, Me)
        Return Convert.ToBase64String(mem.ToArray())
    End Function

    Public Shared Function Deserialize(ByVal _
   StringData As String) As USER
        Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim mem As New IO.MemoryStream(Convert.FromBase64String(StringData))
        Return DirectCast(bf.Deserialize(mem), USER)
    End Function
    Public Shared Function GetActiveUser() As USER
        On Error Resume Next
        Dim db As New DataBaseConnection
        Dim sql = "SELECT * FROM `user` WHERE `Active` = 'true'"
        Dim dr As DataRow = db.executeSQL(sql)(0)
        Dim U As USER = LoadFromSQL(CStr(dr(1)))
        Return U
    End Function
    Public Shared Function DisActiveUsers(Optional ByVal U As String = "") As Integer
        Dim db As New DataBaseConnection
        Dim sql = "UPDATE `user` SET `Active`='false' WHERE NOT `USER` ='" + U + "';UPDATE `user` SET `Active`='true' WHERE `USER` ='" + U + "'"
        Return db.executeDMLSQL(sql)

    End Function
    Public Sub SetAdmin()
        If Me.Admin Then
            [DeviceControlPanel] = True
            [DeviceTypePanel] = True
            [DeviceLogHistory] = True
            [schdule] = True
            [PlayStationTab] = True
            [SpeciesControllerPanel] = True

            'Device Options
            [CanEditTotalBill] = True
            [CanAddAdditionalCash] = True
            [CanStartCloseSession] = True
            [CanCreateDevice] = True
            [CanDeleteDevice] = True
            [CanUpdateDevice] = True
            [CanDeleteDeviceLog] = True
            [CanStartDeviceLog] = True
            [CanAddTime] = True
            [CanRemoveTime] = True

            [CanAddSpecies] = True
            [CanRemoveSpecies] = True

            [CanUpdateStartTime] = True
            [CanChangedDevice] = True
            [CanSetOffers] = True

            'Schdule
            [CanCreateSchedule] = True
            [CanDeleteSchedule] = True

            'User
            ' [Admin] = True
            [Normal] = False
            '[Theme] = True
            '[ThemeColor] = True
        End If
    End Sub
    Public Sub SetDefecult()
        On Error Resume Next

        [DeviceControlPanel] = True
        [DeviceTypePanel] = False
        [DeviceLogHistory] = False
        [schdule] = True
        [PlayStationTab] = True
        [SpeciesControllerPanel] = False

        'Device Options
        [CanEditTotalBill] = False
        [CanAddAdditionalCash] = True
        [CanStartCloseSession] = False
        [CanCreateDevice] = False
        [CanDeleteDevice] = False
        [CanUpdateDevice] = False
        [CanDeleteDeviceLog] = False
        [CanStartDeviceLog] = False
        [CanAddTime] = True
        [CanRemoveTime] = True

        [CanAddSpecies] = True
        [CanRemoveSpecies] = True

        [CanUpdateStartTime] = False
        [CanChangedDevice] = True
        [CanSetOffers] = True

        'Schdule
        [CanCreateSchedule] = True
        [CanDeleteSchedule] = True

        'User
        [Admin] = False
        ' [Normal] = True

    End Sub
    Public Sub SaveToSQL()
        If Not Me.UserName = "" Then
            Dim HP As New Helper
            Dim Serelized As String = Serialize()
            If HP.GlobalUpdate("user", "`DATA`='" + Serelized + "'", "USER", UserName) = 0 Then
                HP.GlobalInsert("user", "`USER`, `PASS`, `DATA`", "'" + Me.UserName + "','" + Me.Password + "','" + Serelized + "'")
            End If

        End If
    End Sub
    Public Function UpdateLastLogin() As Integer
        On Error Resume Next

        Dim hp As New Helper
        Return hp.GlobalUpdate("user", "`LastLogin`='" + Date.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'", "USER", UserName)

    End Function
    Public Function GetLastLogin() As Date
        On Error Resume Next
        Dim db As New DataBaseConnection
        Dim sql = "SELECT `LastLogin` FROM `user` WHERE `USER` = '" + UserName + "'"
        Dim dr As DataRow = db.executeSQL(sql)(0)
        If CStr(dr(0)) = "0" Then
            Return Date.Now
            UpdateLastLogin()
        Else
            Return Date.Parse(dr(0))
        End If

    End Function
    Public Shared Function LoadFromSQL(ByVal USERNAME As String) As USER
        Try
            Dim db As New DataBaseConnection
        Dim Rows As DataRow = db.executeSQL("SELECT `DATA` FROM `user` WHERE `USER`='" + USERNAME + "'")(0)
        '  MsgBox(Rows(0))
        ' MsgBox("SELECT `DATA` FROM `user` WHERE `USER`='" + USERNAME + "'")
        Dim Serelized As USER = Deserialize(CStr(Rows(0)))
            Return Serelized
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    



End Class


