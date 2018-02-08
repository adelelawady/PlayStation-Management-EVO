Public Class HistoryHandler
    Dim DB As DataBaseConnection
    Public Sub New()


    End Sub
    Public Function [LOGDATA]() As DataRowCollection
        Dim Sql As String = "SELECT * FROM `deviceslog` WHERE 1"
        Return DB.executeSQL(Sql)
    End Function
End Class
