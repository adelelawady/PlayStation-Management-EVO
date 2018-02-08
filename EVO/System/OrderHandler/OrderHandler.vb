Public Class OrderHandler
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddHandler TypeTabPanel1.typeHandler.SelectionChanged, AddressOf TypeChanged
        Try
            Me.SpeciesList1.UpdateListByType(TypeTabPanel1.typeHandler.Selected.Type.Id)
            Me.TypeTabPanel1.typeHandler.TypeTabList(0).Shortcuts.Add(DevComponents.DotNetBar.eShortcut.AltF1)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub TypeChanged()
        On Error Resume Next
        Me.SpeciesList1.UpdateListByType(TypeTabPanel1.typeHandler.Selected.Type.Id)
    End Sub
    Private Sub TypeTabPanel1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TypeTabPanel1.Load

    End Sub

    Private Sub SpeciesList1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeciesList1.Load

    End Sub
End Class
