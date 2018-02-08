Public Class TypeTabsHandler

    Dim DB As New DataBaseConnection
    Public Event SelectionChanged()
    Private TabsList As New List(Of TypeTab)
    Private SelectedTab As TypeTab
    Private CurrKey As String = ""
    Public Sub New()

        RefreshList(Nothing)


    End Sub
    Public Sub New(ByVal Selected As TypeTab)

        RefreshList(Selected)


    End Sub
    Public Sub RefreshList()
        RefreshList(Nothing)
    End Sub
    Public Sub RefreshList(ByVal tb As TypeTab)
        On Error Resume Next

            Me.TabsList.Clear()
            Me.CurrKey = ""

            Dim Sql As String = "SELECT * FROM `types` ORDER by `id` DESC"
        Dim Row As DataRowCollection = DB.executeSQL(Sql)
            For Each DR As DataRow In Row
                Dim typetab As New TypeTab(DR(0), False)

            'Me.CurrKey = HotKeyHandler.NextKey(CurrKey)
            'typetab.HotKey = New hotkey(CurrKey, WinHotKey.KeyModifier.None, typetab)
            'Main.addhk(typetab.HotKey)

                Me.TabsList.Add(typetab)
                AddHandler typetab.Click, AddressOf TypeTab_Click
                If Not tb Is (Nothing) Then
                    If typetab.Type.Id = tb.Type.Id Then

                        Me.Selected = typetab
                        typetab.intiCbutton(True)

                    End If
                End If
            Next

            'Me.CurrKey = HotKeyHandler.NextKey(CurrKey)
            'TypeTab.HotKey = New hotkey(CurrKey, WinHotKey.KeyModifier.None, TypeTab, HotKeyHandler.GetID(WinHotKey.KeyModifier.None, CurrKey))
            If tb Is Nothing Then
                Me.SelectedTab = TypeTabList.Item(TabsList.Count - 1)

                TypeTabList.Item(TabsList.Count - 1).intiCbutton(True)
            End If

        'Catch ex As Exception
        '   LOG.[LOG](ex) ' MsgBox(ex.StackTrace)
        'End Try
    End Sub

    Public Sub intiGroupBoxList(ByVal GP As DevComponents.DotNetBar.Bar)
        '  On Error Resume Next
        '  GP.Controls.Clear()
        GP.Items.Clear()
        For Each TT As TypeTab In TypeTabList
            'If TT.Type.Name = "ss" Then
            '    TT.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.AltF1)

            'End If
            GP.Items.Add(TT)
        Next
    End Sub
    Private Sub TypeTab_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try


            SelectedTab.intiCbutton(False)
            SelectedTab = sender
            sender.intiCbutton(True)
            RaiseEvent SelectionChanged()
        Catch ex As Exception
            LOG.[LOG](ex) '
        End Try
    End Sub
    ReadOnly Property TypeTabList As List(Of TypeTab)
        Get
            Return TabsList
        End Get
    End Property
    Property Selected As TypeTab
        Set(ByVal value As TypeTab)
            Me.SelectedTab = value
            TypeTab_Click(value, Nothing)
            ' RaiseEvent SelectionChanged()
        End Set
        Get
            Return Me.SelectedTab
        End Get
    End Property
End Class
