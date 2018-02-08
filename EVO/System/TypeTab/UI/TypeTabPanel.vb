Public Class TypeTabPanel
    Public typeHandler As New TypeTabsHandler()
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        typeHandler.intiGroupBoxList(Me.Bar1)
    End Sub
    Private Sub progress_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles progress.Tick
        ' CircularProgress1.Location = New Point(MainControlTable1.Size.Width / 2, MainControlTable1.Size.Height / 2)
        'If Me.StepIndicator1.CurrentStep = StepIndicator1.StepCount Then
        '    StepIndicator1.CurrentStep = 0
        'Else
        '    StepIndicator1.CurrentStep += 1
        'End If

    End Sub

    Private Sub TypeTabPanel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub Bar1_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bar1.ItemClick

    End Sub
End Class
