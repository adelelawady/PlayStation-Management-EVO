Public Class Helper
    Dim DB As New DataBaseConnection
    Public Function GlobalInsert(ByVal Table As String, ByVal Fields As String, ByVal VALUES As String) As Integer
        On Error Resume Next
        Dim Sql As String = "INSERT INTO `" + CStr(Table) + "` (" + CStr(Fields) + ") VALUES (" + CStr(VALUES) + ");"
        ' MsgBox(Sql)
        ' Clipboard.SetText(Sql)
        Return DB.executeDMLSQL(Sql)

    End Function
    Public Function GlobalDelete(ByVal Table As String, ByVal Field As String, ByVal id As String) As Integer
        On Error Resume Next
        Dim SQl = "DELETE FROM `" + CStr(Table) + "` WHERE `" + CStr(Field) + "` ='" + CStr(id) + "';"
        Return DB.executeDMLSQL(SQl)
    End Function
    Public Function GlobalUpdate(ByVal Table As String, ByVal FieldsAndValues As String, ByVal WhereField As String, ByVal WhereId As String) As Integer
        On Error Resume Next
        Dim SQl = "UPDATE `" + Table + "` SET " + FieldsAndValues + " WHERE `" + WhereField + "`='" + CStr(WhereId) + "'"
        '   MsgBox(SQl)
        '  Clipboard.SetText(SQl)
        Return DB.executeDMLSQL(SQl)
    End Function
End Class
