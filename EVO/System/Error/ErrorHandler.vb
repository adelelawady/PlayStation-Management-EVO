Public Class ErrorHandler
    Public Shared Function ErroMsgToString(ByVal errormsg As String) As String()
        Dim Result As String() = {""}
        Try
            Result = errormsg.Split(":")


        Catch ex As Exception
            Return Nothing

            'Return New Exception With {.Source = "Error handling Msg"}
        End Try
        Return Result
    End Function




End Class
