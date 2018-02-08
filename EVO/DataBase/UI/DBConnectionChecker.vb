Public Class DBConnectionChecker
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Control.CheckForIllegalCrossThreadCalls = False
        Me.DBChecker.RunWorkerAsync()

    End Sub
    Public Sub New(ByVal Hidden As Boolean)
        Try

    
        Me.Opacity = 0
        InitializeComponent()
        Control.CheckForIllegalCrossThreadCalls = False
            Me.DBChecker.RunWorkerAsync()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GameBoosterTheme1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GameBoosterTheme1.Click

    End Sub

    Private Sub AetherButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub AetherTag2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AetherTag2.Click

    End Sub

    Private Sub AetherButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private ProccessResult As Boolean = Nothing

    Private Sub DBChecker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles DBChecker.DoWork

        e.Result = True
        Try
            Dim DBConnection As New DataBaseConnection

            e.Result = True
        Catch ex As Exception

            e.Result = False
        End Try

    End Sub

    Private Sub DBChecker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles DBChecker.ProgressChanged

    End Sub
    Private EndResult As DialogResult = Windows.Forms.DialogResult.No
    Private Sub DBChecker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles DBChecker.RunWorkerCompleted

        If e.Result = True Then
            AetherTag1.Text = "Successfuly Connected to Server On 3306"
            AetherTag2.Text = "Connected"
            Me.PictureBox1.Image = My.Resources.tick_yes_approve_accept_green_64
            EndResult = Windows.Forms.DialogResult.Yes
        Else
            AetherTag1.Text = "Failed To Connect To Mysql Server"
            AetherTag2.BackColor = Color.FromArgb(51, 51, 51)
            AetherTag2.Border = Color.White
            AetherTag2.Background = Color.Red
            AetherTag2.Text = "Failed"
            Me.PictureBox1.Image = My.Resources.caution_64
            EndResult = Windows.Forms.DialogResult.No
        End If
        AetherTag1.Refresh()
        AetherTag2.Refresh()
        Me.PerformLayout()
        Timer1.Start()
    End Sub

    Private Sub DBConnectionChecker_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter


    End Sub

    Private Sub DBConnectionChecker_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave

    End Sub

    Private Sub DBConnectionChecker_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove

    End Sub

    
    Private Sub GameBoosterTheme1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub GameBoosterTheme1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.DialogResult = EndResult
        Me.Close()
    End Sub
End Class