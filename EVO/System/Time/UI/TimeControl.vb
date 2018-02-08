Public Class TimeControl
    Private Dev As DeviceControl1
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub InitializeDevice(ByVal D As DeviceControl1)
        Me.Dev = D
    End Sub
    Private Sub CButton1_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CButton1.ClickButtonArea
        Me.Dev.Device.AddTime(60)
        Refre()
    End Sub

    Private Sub CButton3_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CButton3.ClickButtonArea
        Me.Dev.Device.RemoveTime(60)
        Refre()
    End Sub

    Private Sub CButton4_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CButton4.ClickButtonArea
        Me.Dev.Device.RemoveTime(30)
        Refre()
    End Sub
    Public Sub Refre()
        Dev.Refresh()
    End Sub
   

    Private Sub CButton5_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CButton5.ClickButtonArea
        Me.Dev.Device.AddTime(30)
        Refre()
    End Sub

    Private Sub CButton2_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CButton2.ClickButtonArea
        If IsNumeric(Me.TextBox1.Text) Then
            Me.Dev.Device.AddTime(Me.TextBox1.Text)
            Refre()
        End If

    End Sub

    Private Sub CButton6_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CButton6.ClickButtonArea
        If IsNumeric(Me.TextBox1.Text) Then
            Me.Dev.Device.AddTime((CInt(Me.TextBox2.Text) * 60))
            Refre()
        End If
    End Sub

    Private Sub CButton7_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CButton7.ClickButtonArea
        Me.Dev.Device.SetTimeOpend()
        Refre()
    End Sub
End Class
