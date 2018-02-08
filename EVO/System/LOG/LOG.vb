


Public Class LOG
    Public Shared Function [LOG](ByVal ex As Exception)
        On Error Resume Next
        Dim DB As New DataBaseConnection
        Dim errorstr As String = GETEXCEPTIONSTRING(ex)
        Dim sql As String = "INSERT INTO `LOG` (`ID`, `DATA`, `Date`) VALUES (NULL, '" + errorstr + "', '" + Date.Now.Date.ToString + "');"
        'MsgBox(ex.StackTrace)
        frmMain.[ADDSTATUS]("[ERROR] " + ex.Source)
        DB.executeSQL(sql)
    End Function
    Public Shared Function GETEXCEPTIONSTRING(ByVal ex As Exception) As String
        On Error Resume Next

        Dim EXESTRING As String = ""
        EXESTRING += ex.Source + "   " + Date.Now.ToString
        EXESTRING += ex.StackTrace + vbNewLine
        EXESTRING += ex.Message + vbNewLine
        EXESTRING += ex.InnerException.ToString + vbNewLine
        Return EXESTRING
    End Function

End Class
