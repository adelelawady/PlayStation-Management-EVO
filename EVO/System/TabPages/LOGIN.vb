Public Class LOGIN

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click

    End Sub

    Private Sub LOGIN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Dim db As New DataBaseConnection
        Dim sql As String = "SELECT * FROM `user`"
        Dim dr As DataRowCollection = db.executeSQL(sql)
        If dr.Count = 0 Then
            Dim User As New USER
            User.UserName = "admin"
            User.Password = "admin"
            User.Admin = True
            User.SetAdmin()
            User.SaveToSQL()

            Dim UserX As New USER
            UserX.UserName = "abdo11"
            UserX.Password = "abdo"
            UserX.Admin = True
            User.SetAdmin()
            UserX.SaveToSQL()
        End If
    End Sub
End Class