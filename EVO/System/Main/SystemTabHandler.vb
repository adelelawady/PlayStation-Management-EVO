Public Class SystemTabHandler
    Enum TabsType
        PlayStationControlPanel = 0
        DevicesControlerPanel = 1
        SpeciesControllerPanel = 2
        DeviesLogHistory = 3
        ScheduleHandler = 4
        DevicesTypeController = 5
        LOGIN = 6
    End Enum
    Public Function FindAndSelectTab(ByVal TabStrip As DevComponents.DotNetBar.TabStrip, ByVal TBType As TabsType) As Boolean
        For Each TAB As DevComponents.DotNetBar.TabItem In TabStrip.Tabs
            If TAB.AttachedControl.Name = TBType.ToString Then
                TabStrip.SelectedTab = TAB
                Return True
                Exit For
                Exit Function
            End If

        Next
        Return False
    End Function
    Public Function GetTab(ByVal TabStrip As DevComponents.DotNetBar.TabStrip, ByVal TabType As TabsType) As DevComponents.DotNetBar.TabItem
        Dim SelectedTab As DevComponents.DotNetBar.TabItem = Nothing
        For Each TAB As DevComponents.DotNetBar.TabItem In TabStrip.Tabs
            MsgBox(TAB.Name)
            If TAB.AttachedControl.Name = TabType.ToString Then
                SelectedTab = TAB
            Else
                SelectedTab = Nothing
            End If
        Next
        Return SelectedTab
    End Function
End Class
