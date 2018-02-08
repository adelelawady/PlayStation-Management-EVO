Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Mail
Imports MySql.Data
Imports MySql.Data.MySqlClient



Public Class DataBaseConnection
    'MySQL

    Public connString As String = "Server=localhost;Database=EVO;Uid=root;Pwd=;Character Set=utf8;Convert Zero Datetime=True"

    ' Public connString As String = "Server=" + My.Settings.ServerName + ";Database=" + My.Settings.DBName + ";Uid=" + My.Settings.Uid + ";Pwd=" + My.Settings.Pwd + ";Character Set=utf8;"

    Public SUCCESS As String = "SUCCESS"
    Public SERROR As String = "ERROR"

    Public Sub New()
        'Try
        '    conn = New MySqlConnection
        '    conn.ConnectionString = connString
        '    conn.Open()
        '    '  conn.Close()
        '    'executeSQL("SELECT * FROM colsettings")
        'Catch ex As Exception
        '    ' LOG.[LOG](ex) ' MsgBox(ex.Message)

        '    Throw New Exception With {.Source = ("OK:1:DB Connection Failed:لا يوجد اتصال بالسرفر")}
        'End Try
    End Sub

    Public Function executeSQL(ByVal sSql As String) As System.Data.DataRowCollection
        ' On Error Resume Next
        Dim queryresult As String = ""
        Try
            'frmMain.labelStatus.Text = sSql
            '  MsgBox(sSql)
            '    Dim dataset As New DataSet

            '    dataset = executeSQL_dset(sSql, queryresult)
            '    Dim dtable As DataTable = dataset.Tables(0)
            '    If queryresult = "SUCCESS" Then
            '        Return dtable.Rows
            '    ElseIf queryresult.Contains("ERROR") Then

            '        Return Nothing

            '    End If

            ' MsgBox(sSql)
            Return executeSQL(sSql, queryresult).Rows


        Catch ex As Exception
            ' MsgBox(sSql)
            '  MsgBox(sSql)
            '  MsgBox("executeSQL " + ex.StackTrace)
            MsgBox("executeSQL : " + queryresult)
            LOG.[LOG](ex) '
            '     MsgBox(ex.Message + vbNewLine + sSql)
            '   Exit Function
            Return executeSQL(sSql, queryresult).Rows
        End Try

    End Function




    Public Function executeSQL(ByVal sSql As String, ByRef sResult As String) As Data.DataTable
        ' On Error Resume Next
        Dim sReturn As String = ""
        'Dim sr As SqlDataReader = Nothing
        Dim dt As DataTable = New DataTable
        Dim da As New MySqlDataAdapter
        Dim conn As New MySqlConnection
        Try
            conn.ConnectionString = connString
            conn.Open()
            Dim sComm As New MySqlCommand
            sComm.CommandText = sSql
            sComm.Connection = conn
            da.SelectCommand = sComm

            'Application.DoEvents()

            da.Fill(dt)

            da.Dispose()
            conn.Close()
            conn.Dispose()

            sResult = SUCCESS
        Catch ex As Exception



            sResult = SERROR & ": " & ex.Message
            If (conn.State = Data.ConnectionState.Open) Then
                conn.Close()
                's  Exit Function
            End If
        End Try
        conn = Nothing
        Return dt
    End Function
    Public Function executeDMLSQL(ByVal sSql As String) As Integer

        Dim sReturn As String = ""
        Dim irows As Integer = 0
        Dim conn As New MySqlConnection
        Try
            conn.ConnectionString = connString
            conn.Open()
            Dim sComm As New MySqlCommand
            sComm.CommandText = sSql
            sComm.Connection = conn
            irows = sComm.ExecuteNonQuery()
            ' da.Dispose()
            conn.Close()
            conn.Dispose()
            ''sResult = SUCCESS
        Catch ex As Exception
            ' LOG.[LOG](ex) ' MsgBox(ex.Message)
            ''  sResult = SERROR & ": " & ex.Message
            If (conn.State = Data.ConnectionState.Open) Then
                conn.Close()

                'Exit Function
            End If
        End Try
        conn = Nothing
        Return irows
    End Function

    Public Function executeSQL_dset(ByVal sSql As String) As Data.DataSet
        Dim sReturn As String = ""
        'Dim sr As SqlDataReader = Nothing
        'Dim dt As DataTable = New DataTable
        Dim dt As DataSet = New DataSet
        Dim da As New MySqlDataAdapter
        Dim conn As New MySqlConnection
        Try

            '  MySqlCommand cmd = new MySqlCommand("SELECT tes FROM ins", conn);
            conn.ConnectionString = connString
            conn.Open()
            Dim sComm As New MySqlCommand(sSql, conn)
            'sComm.CommandText = sSql
            'sComm.Connection = conn
            da.SelectCommand = sComm
            da.Fill(dt)
            conn.Close()
            ' sResult = SUCCESS
        Catch ex As Exception
            ' sResult = SERROR & ": " & ex.Message
            If (conn.State = Data.ConnectionState.Open) Then
                conn.Close()
            End If
        End Try
        conn = Nothing
        Return dt
    End Function

End Class
