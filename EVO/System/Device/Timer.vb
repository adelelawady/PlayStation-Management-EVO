Public Class Timer
    Private xTimer As New System.Windows.Forms.Timer

    Public Sub New(ByVal TickValue As Integer)
        xTimer = New System.Windows.Forms.Timer
        xTimer.Interval = TickValue
        AddHandler xTimer.Tick, Timer_Tick()
    End Sub

    Public Sub StartTimer()
        xTimer.Start()
    End Sub

    Public Sub StopTimer()
        xTimer.Stop()
    End Sub

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SampleProcedure()
    End Sub

    Private Sub SampleProcedure()
        'SomeCodesHERE
    End Sub

End Class
End Class
