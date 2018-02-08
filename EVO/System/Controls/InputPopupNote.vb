Public Class InputPopupNote

    Public retResult As String = ""
    Public retResult2 As String = ""
    Public Sub New(ByVal Text As String)

        ' This call is required by the designer.
        InitializeComponent()
        Me.Label1.Text = Text
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        retResult = Me.TextBoxX1.Text
        retResult2 = Me.TextBoxX2.Text
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class