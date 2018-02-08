Public Class SQLExportImport
    Public Shared Sub BACKUP()
        Try
            Dim pr As Process = Process.Start(Application.StartupPath + "\BackUp\EVOBACKUP.exe", "backup ""Server=localhost;Database=EVO;Uid=root;Pwd=;Character Set=utf8;Convert Zero Datetime=True""")
            pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            pr.WaitForExit()
        Catch ex As Exception

        End Try

    End Sub
End Class
