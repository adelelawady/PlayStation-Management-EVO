Imports MySql.Data.MySqlClient
Imports DevComponents.DotNetBar
Imports DevComponents.Editors

Public Class DeviesLogHistory
    Dim DB As New DataBaseConnection

    Dim timeFormat As String = "yyyy-MM-dd"
    Dim DeviceLogSql As String = "SELECT * FROM `deviceslog`, `devices`,`devicetype` ,`deviceslogdata`,`species` WHERE `devices`.`id` = `deviceslog`.`DeviceId` AND `devices`.`Type` = `devicetype`.`id` AND `deviceslogdata`.`LogId` = `deviceslog`.`id` AND  `deviceslogdata`.`SpeciesId` = `species`.`id`"
    Dim DeviceSql As String = "SELECT * FROM `deviceslog` WHERE 1"


#Region "Nodes"
    Public MainLog As DevComponents.AdvTree.Node = Nothing
    Public MainNodeLoadingPrsentage As Integer = 0
    Public Maximum As Integer = 0
#End Region


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Control.CheckForIllegalCrossThreadCalls = False
        Me.CircularProgress1.IsRunning = True


    End Sub
    Public Function GetColumn(ByVal col As String) As String
        Select Case col
            Case Is = "`deviceslog`.id"
                Return "LOGID"
            Case Is = "`deviceslog`.DeviceId"
                Return "DeviceID"
            Case Is = "`deviceslog`.InActive"
                Return "Active"
            Case Is = "`deviceslog`.Bill"
                Return "OrderBill"
            Case Is = "`deviceslog`.PlayBill"
                Return "PlayStationBill"
            Case Is = "deviceslog`.TimeLimit"
                Return "Time"
            Case Is = "`deviceslog`.SpeciesOrderCheck"
                Return "Order"
            Case Is = "deviceslog`.User"
                Return "MadeBy"
            Case Is = "deviceslog`.DeviceType"
                Return "Type"
            Case Is = "deviceslog`.offers"
                Return "Discount"
            Case Is = "deviceslog`.ControllersCount"
                Return "Controllers"
            Case Is = "deviceslog`.TotalBill"
                Return "Total"
                '	TotalBill
                '	AdditionalBill
                '	User
                '	SpeciesOrderCheck
            Case Else
                Try
                    Return (col.Split(".")(1).Replace("`", ""))
                Catch ex As Exception
                    Return ""
                End Try

        End Select

    End Function
    Public Function ColumnRawName(ByVal col As String) As String


    End Function
    Public Function GetMainTables(Optional ByVal devices As Boolean = True, _
                                Optional ByVal devicetype As Boolean = True, Optional ByVal deviceslogdata As Boolean = True, _
                                Optional ByVal species As Boolean = True) As String
        Dim Ret As String = "deviceslog"
        If devices Then
            Ret += ",devices"
        End If
        If devicetype Then
            Ret += ",devicetype"
        End If
        If deviceslogdata Then
            Ret += ",deviceslogdata"
        End If
        If species Then
            Ret += ",species"
        End If

        Return Ret
    End Function
    Public Function GetMainWhereTables(Optional ByVal devices As Boolean = True, _
                              Optional ByVal devicetype As Boolean = True, Optional ByVal deviceslogdata As Boolean = True, _
                              Optional ByVal species As Boolean = True) As String
        Dim Ret As String = " "
        If devices Then
            Ret += "`devices`.`id` = `deviceslog`.`DeviceId` "
        End If
        If Ret = "" Then Ret += "AND "
        If devicetype Then
            Ret += "`devices`.`Type` = `devicetype`.`id` "
        End If
        If Ret = "" Then Ret += "AND "
        If deviceslogdata Then
            Ret += "`deviceslogdata`.`LogId` = `deviceslog`.`id` "
        End If
        If Ret = "" Then Ret += "AND "
        If species Then
            Ret += "deviceslogdata`.`SpeciesId` = `species`.`id` "
        End If

        Return Ret
    End Function
    Public Function GetSql() As String
        Return "SELECT {0} FROM {1} WHERE {2} "
    End Function
    Public Function GetDataRows(ByVal Sql As String) As DataRowCollection
        Return DB.executeSQL(Sql)
    End Function
    Dim _RightAlignFileSizeStyle As DevComponents.DotNetBar.ElementStyle
    Public Function RemoveUnVisibleColumans(ByVal NodesColumns As String, ByVal UnVisibaleColumans As String)
        Dim newColuData As String = ""

        For Each Col As String In NodesColumns.Split(",")
            Dim Canadd As Boolean = False
            For Each UnCol As String In UnVisibaleColumans.Split(",")
                If Not (Col = "" And UnCol = "") Then
                    If Col = UnCol Then
                        Canadd = False
                        Exit For
                    Else
                        Canadd = True
                    End If
                End If

            Next
            If Canadd Then
                If newColuData = "" Then
                    newColuData += Col
                Else
                    newColuData += "," + Col
                End If

            End If

        Next
        Return newColuData
    End Function
    Public Function LoadLog(Optional ByVal NodesColumns As String = "*", Optional ByVal UnVisibaleColumans As String = "`deviceslog`.DeviceLogChanges", Optional ByVal NODETEXT As String = "", Optional ByVal SUBNODETEXT As String = "", Optional ByVal devices As Boolean = False, _
                              Optional ByVal devicetype As Boolean = False, Optional ByVal deviceslogdata As Boolean = False, _
                              Optional ByVal species As Boolean = False, _
                              Optional ByVal DeviceID As String = "all", _
                               Optional ByVal LogID As String = "all", _
                               Optional ByVal type As String = "all", _
                            Optional ByVal startDate As String = "all" _
                            , Optional ByVal Active As Boolean = False _
                            , Optional ByVal hasOffer As Object = "all", Optional ByVal additional As Object = "all" _
                            , Optional ByVal User As String = "all", Optional ByVal HasLimit As Object = "all" _
                            , Optional ByVal hasOrder As Object = "all", Optional ByVal isChanged As Object = "all" _
                           , Optional ByVal ChangedFromDeviceNONE As Boolean = False, Optional ByVal ChangedFromdeviceValued As Boolean = False, Optional ByVal MainNode As Object = True, Optional ByVal AddSubNodes As Boolean = True, Optional ByVal AddDuration As Boolean = False) As Object

        Try
            Dim NewColumans As String = ""
            Try
                NewColumans = RemoveUnVisibleColumans(NodesColumns, UnVisibaleColumans)
            Catch ex As Exception
                NewColumans = NodesColumns
            End Try

            Dim TempMainLog As New DevComponents.AdvTree.Node
            ' TempMainLog.DragDropEnabled = False
            TempMainLog.Text = NODETEXT
            TempMainLog.Style = _RightAlignFileSizeStyle
            '' TempMainLog.NodesColumns
            TempMainLog.Editable = False

            ' If MainNode Then
            For Each Col As String In NodesColumns.Split(",")
                Dim ISVisible As Boolean = True
                For Each UnCol As String In UnVisibaleColumans.Split(",")
                    If Col = UnCol Then
                        ISVisible = False
                        Exit For
                    End If
                Next
                If ISVisible Then
                    Dim ColName As String = GetColumn(Col)
                    Dim Coll As New DevComponents.AdvTree.ColumnHeader(ColName)
                    Coll.Width.Absolute = 100
                    Coll.Text = ColName
                    Coll.Tag = Col
                    If ColName = "Total" Then
                        Coll.CellsBackColor = Color.LightCyan
                    End If
                    If ColName = "StartDate" Then
                        Coll.Width.Absolute = 200
                    End If
                    TempMainLog.NodesColumns.Add(Coll)
                    If ColName = "StartDate" Then
                        If AddDuration Then
                            Dim CollX As New DevComponents.AdvTree.ColumnHeader("Duration")
                            CollX.Width.Absolute = 100
                            CollX.Text = "Duration"
                            CollX.Tag = Col
                            TempMainLog.NodesColumns.Add(CollX)
                        End If
                    End If
                End If

            Next
            'End If
222:
            Dim SQladded As Boolean = False
            Dim TempMainLogSql As String = GetSql()
            Dim Tables As String = GetMainTables(devices, devicetype, deviceslogdata, species)
            Dim WhereTables As String = GetMainWhereTables(devices, IIf(Not type = "all", False, devicetype), deviceslogdata, species)
            TempMainLogSql = String.Format(TempMainLogSql, NodesColumns, Tables, WhereTables)
            If devices Or devicetype Or deviceslogdata Or species Then
                TempMainLogSql += "AND "
            End If
            If Not startDate = "all" Then
                Dim timeFormatxx = "yyyy-MM-dd HH:mm:ss"
               
                TempMainLogSql += "`deviceslog`.`StartDate` >= '" + Me.DateTimeInput1.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND `deviceslog`.`EndDate` < '" + Me.DateTimeInput2.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' "

                'SELECT * FROM `deviceslog` WHERE `StartDate` >= '2016-10-31 13:07:21' AND `EndDate` <= '2016-11-01 13:07:21'
                '  MsgBox(TempMainLogSql)
                ' TempMainLogSql += "`deviceslog`.`StartDate` BETWEEN '" + Me.DateTimeInput1.Value.Date.ToString(timeFormatxx) + "' AND '" + Me.DateTimeInput2.Value.Date.AddHours(23).AddMinutes(59).ToString(timeFormatxx) + "' "
                '  TempMainLogSql += "`deviceslog`.`StartDate` BETWEEN '" + Me.DateTimeInput1.Value.ToString(timeFormat) + "' AND '" + Me.DateTimeInput2.Value.ToString(timeFormat) + "' "
                SQladded = True
            End If

            If Not SQladded Then
                TempMainLogSql += "`deviceslog`.`InActive` = '" + Active.ToString + "' "
            Else
                TempMainLogSql += "AND `deviceslog`.`InActive` = '" + Active.ToString + "' "
            End If

            If Not DeviceID = "all" Then
                TempMainLogSql += "AND `deviceslog`.DeviceId = '" + DeviceID + "' AND `devices`.id = '" + DeviceID + "' "

            End If


            If Not LogID = "all" Then
                TempMainLogSql += "AND `deviceslog`.id = '" + LogID + "' "
            End If
            If Not CStr(hasOffer) = "all" Then
                If Not CBool(hasOffer) Then
                    TempMainLogSql += "AND `deviceslog`.offers = 'none' "
                Else
                    TempMainLogSql += "AND `deviceslog`.offers NOT LIKE 'none' "
                End If
            End If
            If Not CStr(additional) = "all" Then
                If CBool(additional) Then
                    TempMainLogSql += "AND (`deviceslog`.AdditionalBill NOT LIKE '%0,0%' AND `deviceslog`.AdditionalBill NOT LIKE '%0,none%')"
                Else
                    TempMainLogSql += "AND (`deviceslog`.AdditionalBill LIKE '%0,0%' OR `deviceslog`.AdditionalBill LIKE '%0,none%')"

                End If
            End If


            If Not User = "all" Then
                TempMainLogSql += "AND `deviceslog`.User = '" + User + "' "
            End If

            If Not CStr(HasLimit) = "all" Then
                If Not CBool(HasLimit) Then
                    TempMainLogSql += "AND `deviceslog`.TimeLimit = '0' "
                Else

                    TempMainLogSql += "AND `deviceslog`.TimeLimit NOT LIKE '0' "
                End If
            End If
            If Not CStr(hasOrder) = "all" Then
                If CBool(hasOrder) Then
                    TempMainLogSql += "AND `deviceslog`.Bill NOT LIKE '0' "
                Else

                    TempMainLogSql += "AND `deviceslog`.Bill = '0' "
                End If
            End If
            ''''RemoveDeleled
            TempMainLogSql += "AND `deviceslog`.Deleted = '0' ORDER BY `deviceslog`.`StartDate` ASC"


            ' If Not CStr(isChanged) = "none" Then


            'If Not CStr(isChanged) = "all" Then
            '    If (Not CBool(isChanged) And Not CBool(ChangedFromDeviceNONE) And Not CBool(ChangedFromdeviceValued)) Then
            '        TempMainLogSql += "AND `deviceslog`.DeviceLogChanges LIKE '%(0)%'"
            '    Else

            '        If CBool(isChanged) Then
            '            TempMainLogSql += "AND `deviceslog`.DeviceLogChanges LIKE '%,%' "
            '            ChangedFromDeviceNONE = False
            '            ChangedFromdeviceValued = False
            '        End If

            '        If CBool(ChangedFromDeviceNONE) Then
            '            TempMainLogSql += "AND `deviceslog`.DeviceLogChanges LIKE '%(1)%' "
            '            'ChangedFromdeviceValued = False

            '        End If

            '        If CBool(ChangedFromdeviceValued) Then

            '            If ChangedFromDeviceNONE Then
            '                TempMainLogSql += "OR `deviceslog`.DeviceLogChanges LIKE '%(2)%' "
            '            Else
            '                TempMainLogSql += "AND `deviceslog`.DeviceLogChanges LIKE '%(2)%' "
            '            End If
            '        End If

            '    End If
            'Else
            '    ' MsgBox("hi")
            '    '  TempMainLogSql += "AND `deviceslog`.DeviceLogChanges LIKE '%(0)%' OR `deviceslog`.DeviceLogChanges LIKE '%,%'"
            'End If
            ' End If

            If AddSubNodes Then
                Dim ReturnedRows As DataRowCollection = GetDataRows(TempMainLogSql)
                ' UpdateProgressThread(MainLog.Nodes.Count, ReturnedRows.Count)
                For Each Row As DataRow In ReturnedRows
                    ' AdvTree1.BeginUpdate()
                    '  MsgBox(Row(5))

                    Dim counter As Integer = 0
                    '  MsgBox(UnVisibaleColumans)

                    ' MsgBox(newColuData)
                    Dim FirstColomanData As String = Row(NewColumans.Split(",")(0).Split(".")(1).Replace("`", ""))

                    'MsgBox(FirstColomanData)
                    ' MsgBox(FirstColomanData)
                    Dim SubNode As New DevComponents.AdvTree.Node(FirstColomanData)
                    SubNode.DragDropEnabled = False
                    'SubNode.Cells.Clear()
                    SubNode.Image = My.Resources.time_clock_history_recent_16
                    SubNode.Style = _RightAlignFileSizeStyle
                    SubNode.Tag = Row

                    Dim One As Boolean = True
                    For Each Col As String In NodesColumns.Split(",")
                        Dim ISVisible As Boolean = True
                        For Each UnCol As String In UnVisibaleColumans.Split(",")
                            If Col = UnCol Then
                                ISVisible = False
                                Exit For
                            End If
                        Next
                        If ISVisible Then


                            Dim ColomanData As String = CStr(Row(Col.Split(".")(1).Replace("`", "")))

                            If Not counter = 0 Then
                                Dim ColName As String = GetColumn(Col)



                                Dim Cell As New DevComponents.AdvTree.Cell(ColomanData.Replace(vbNewLine, "-"), _RightAlignFileSizeStyle)
                                Cell.ShowToolTips = True
                                If ColName = "StartDate" Then
                                    ' Cell.HostedControl = New DevComponents.Editors.DateTimeAdv.DateTimeInput With {.Value = Date.Parse(ColomanData), .IsInputReadOnly = True, .CustomFormat = "yyyy-MM-dd HH:mm:ss", .Format = DevComponents.Editors.eDateTimePickerFormat.Custom}

                                    Dim F As String = "<font color=""#0F243E""><font color=""#ED1C24""><font color=""#0072BC"">{1}</font></font></font> / <font color=""#255663""><font color=""#A5A5A5"">{0}</font></font> |<font color=""#3E3C3A""> {2}</font> : <font color=""#A5A5A5"">{3}</font><b>{4}</b>"
                                    Dim DATEValue As Date = Date.Parse(ColomanData)
                                    Dim AMPM As String = "ã"
                                    If DATEValue.Hour > 12 Then
                                        ' DATEValue.AddHours(-12)
                                        AMPM = " ã "
                                    Else
                                        AMPM = " Õ "
                                    End If
                                    Cell.HostedItem = New DevComponents.DotNetBar.LabelItem(ColomanData, String.Format(F, DATEValue.Month, DATEValue.Day, IIf(DATEValue.Hour > 12, CStr(DATEValue.Hour - 12), DATEValue.Hour), DATEValue.Minute, AMPM))



                                End If

                                Cell.Tooltip = ColomanData

                                Cell.Tag = Col

                                'If ColName = "TotalBill" Then
                                '    Cell.StyleSelected = New DevComponents.DotNetBar.ElementStyle(Color.LightCyan)
                                'End If

                                SubNode.Cells.Add(Cell)
                                Try


                                    If ColName = "StartDate" Then
                                        If AddDuration Then
                                            Dim Durationa As String = GetDuration(Row("StartDate"), Row("EndDate"))
                                            Dim CellX As New DevComponents.AdvTree.Cell(Durationa, _RightAlignFileSizeStyle)
                                            CellX.ShowToolTips = True

                                            CellX.Tooltip = Durationa

                                            CellX.Tag = "Duration"
                                            SubNode.Cells.Add(CellX)
                                        End If
                                    End If
                                Catch ex As Exception

                                End Try

                            Else
                                counter += 1
                            End If

                        End If
                    Next

                    If Not CStr(isChanged) = "all" Then


                        If (CBool(isChanged) Or CBool(ChangedFromDeviceNONE) Or CBool(ChangedFromdeviceValued)) Then
                            ' TempMainLogSql += "AND `deviceslog`.DeviceLogChanges LIKE '%(0)%'"
                            If CBool(isChanged) Then
                                If Row("DeviceLogChanges").ToString.Contains(",") Then
                                    TempMainLog.Nodes.Add(SubNode)
                                End If
                            End If

                            If CBool(ChangedFromDeviceNONE) Then
                                If Row("DeviceLogChanges").ToString = "(1)" Then
                                    TempMainLog.Nodes.Add(SubNode)
                                End If
                            End If

                            If CBool(ChangedFromdeviceValued) Then
                                If Row("DeviceLogChanges").ToString = "(2)" Then
                                    TempMainLog.Nodes.Add(SubNode)
                                End If
                            End If


                        Else
                            If Row("DeviceLogChanges").ToString = "(0)" Then
                                TempMainLog.Nodes.Add(SubNode)
                            End If
                        End If
                    Else
                        If Row("DeviceLogChanges").ToString.Contains(",") Or Row("DeviceLogChanges").ToString = "(0)" Then
                            TempMainLog.Nodes.Add(SubNode)
                        End If

                    End If



                Next
            End If
            ' Clipboard.SetText(TempMainLogSql)
            ' TempMainLog.NodesColumnsHeaderVisible = True
            'Me.AdvTree1.Nodes.Add(TempMainLog)
            'Me.AdvTree1.Refresh()
            'Me.AdvTree1.Update()
            'Me.AdvTree1.RefreshItems()


            Return TempMainLog


            '  Return TempMainLogSql
        Catch ex As Exception
            LOG.[LOG](ex) ' MsgBox(ex.StackTrace)
        End Try


    End Function
    Public connString As String = "Server=localhost;Database=EVO;Uid=root;Pwd=;Character Set=utf8;"


    ' Public connString As String = "Server=" + My.Settings.ServerName + ";Database=" + My.Settings.DBName + ";Uid=" + My.Settings.Uid + ";Pwd=" + My.Settings.Pwd + ";Character Set=utf8;"
    Public conn As MySqlConnection
    Private Sub DeviesLogHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next

        AddStyles()
        initlziDevices()
        IntilizeDateDate()
        LoadUsers()
        ReUpdateNodes()
        'If Not frmMain.LoginUser.UserName = "abdo11" Then
        '    LabelItem11.Visible = False
        'End If
    End Sub
    Dim SubNodeStyle As New ElementStyle()
    Public Sub IntilizeDateDate()
        On Error Resume Next

        DateTimeInput1.Value = Date.Now
        DateTimeInput2.Value = Date.Now.AddDays(1)
        'DateTimeInput1.AllowEmptyState = False
        'DateTimeInput2.AllowEmptyState = False
    End Sub
    Public Sub LoadUsers()
        On Error Resume Next
        ComboBoxItem2.Items.Clear()

        Dim CBIAll As New ComboItem("all")
        ComboBoxItem2.SelectedIndex = 0
        ComboBoxItem2.Items.Add(CBIAll)

        Dim db As New DataBaseConnection
        Dim sql As String = "SELECT * FROM `user`"
        Dim dr As DataRowCollection = db.executeSQL(sql)
        For Each dd As DataRow In dr
            If Not dd(1) = "abdo11" Then

                Dim CBI As New ComboItem(CStr(dd(1)))
                CBI.Tag = CStr(dd(1))
                ComboBoxItem2.Items.Add(CBI)

            

            End If
        Next
        ComboBoxItem2.Refresh()

    End Sub




    Public Sub initlziDevices()
        On Error Resume Next
        ComboBoxItem1.Items.Clear()
        Dim CBIAll As New ComboItem("all")
        ComboBoxItem1.SelectedIndex = 0
        ComboBoxItem1.Items.Add(CBIAll)
        Dim sql As String = "SELECT `id`,`Name` FROM `devices`"
        Dim Rows As DataRowCollection = (New DataBaseConnection).executeSQL(sql)
        ' MsgBox(Rows.Count)
        For Each DR As DataRow In Rows
            ' MsgBox(rw(1))
            Dim CBI As New ComboItem(CStr(DR(1)))
            CBI.Tag = CStr(DR(0))
            ComboBoxItem1.Items.Add(CBI)
        Next
        ComboBoxItem1.Refresh()

    End Sub
    Public Sub AddStyles()
        On Error Resume Next
        SubNodeStyle = New ElementStyle()
        SubNodeStyle.TextColor = Color.Navy
        SubNodeStyle.Font = New Font("Segoe UI Semilight", 11.0F)
        SubNodeStyle.Name = "ChangedDevice"
        AdvTree1.Styles.Add(SubNodeStyle)
    End Sub
    Public Function AddChangedDevicesNode(ByVal MainNode As DevComponents.AdvTree.Node)
        '   For Each n As DevComponents.AdvTree.Node In MainNode.Nodes
        Try


            Dim row As DataRow = DirectCast(MainNode.Tag, DataRow)
            Dim ChangedDeviceHandlerNodeInfo As New DevComponents.AdvTree.Node("ChangedDevices")

            ChangedDeviceHandlerNodeInfo.Image = My.Resources._0042_092_refresh_update_reload_sync_syncronization_16


            ChangedDeviceHandlerNodeInfo.Style = SubNodeStyle

            ChangedDeviceHandlerNodeInfo.Style.BackColor = Color.WhiteSmoke
            ChangedDeviceHandlerNodeInfo.Style.BackColor = Color.White
            ChangedDeviceHandlerNodeInfo.DragDropEnabled = False
            If row("DeviceLogChanges").ToString.Contains(",") Then

                For Each strLogID As String In row("DeviceLogChanges").ToString.Split(",")
                    If Not strLogID = "" Then
                        Dim subsubnode As DevComponents.AdvTree.Node = LoadLog("`deviceslog`.DeviceId,`devices`.Name,`deviceslog`.DeviceType,`deviceslog`.StartDate,`deviceslog`.EndDate,`deviceslog`.Bill,`deviceslog`.SpeciesOrderCheck, `deviceslog`.PlayBill,`deviceslog`.DeviceLogChanges,`deviceslog`.TotalBill,`deviceslog`.PaidBill", "`deviceslog`.DeviceLogChanges,`deviceslog`.EndDate,`deviceslog`.DeviceId", , "ChangedDevices", True, , , , , strLogID, , , , , , , , , False, , True, False, , True)
                        If subsubnode.Nodes.Count > 0 Then



                            subsubnode.DragDropEnabled = False
                            subsubnode.Nodes(0).Style = SubNodeStyle
                            '  subsubnode.NodesColumns.Clear()
                            If subsubnode.Nodes.Count > 0 Then

                                Dim rowX As DataRow = DirectCast(subsubnode.Nodes(0).Tag, DataRow)
                                If rowX("DeviceLogChanges") = "(2)" Then
                                    ChangedDeviceHandlerNodeInfo.Nodes.Add(subsubnode.Nodes(0))
                                End If


                                ChangedDeviceHandlerNodeInfo.NodesColumns.Clear()
                                For Each Col As DevComponents.AdvTree.ColumnHeader In subsubnode.NodesColumns
                                    ChangedDeviceHandlerNodeInfo.NodesColumns.Add(Col)
                                Next
                            End If



                        End If
                    End If
                Next
                ChangedDeviceHandlerNodeInfo.Cells.Add(New DevComponents.AdvTree.Cell("Devices: " + CStr(ChangedDeviceHandlerNodeInfo.Nodes.Count)))
                Dim totalcount As Double = CalculateFiled(ChangedDeviceHandlerNodeInfo, "TotalBill")
                Dim PaidBills As Double = CalculateFiled(ChangedDeviceHandlerNodeInfo, "PaidBill")
                ChangedDeviceHandlerNodeInfo.Cells.Add(New DevComponents.AdvTree.Cell("TotalBill: " + CStr(totalcount)))
                ChangedDeviceHandlerNodeInfo.Cells.Add(New DevComponents.AdvTree.Cell("PaidBill: " + CStr(PaidBills)))
                MainNode.Nodes.Add(ChangedDeviceHandlerNodeInfo)

            End If
        Catch ex As Exception
            LOG.[LOG](ex) ' MsgBox(ex.StackTrace)
        End Try
        ' Next
    End Function
    ''none
    Public Function AddScheduleNode(ByVal MainNode As DevComponents.AdvTree.Node)
        Try
            Dim row As DataRow = DirectCast(MainNode.Tag, DataRow)


            If (Not row("SheduleID").ToString = ("none")) Then
                Dim SheduleRow As New ScheduleObject(row("SheduleID"))
                ' MsgBox(row("SheduleID"))
                Dim ScheduleNode As New DevComponents.AdvTree.Node("Shedules")
                ScheduleNode.Image = My.Resources.Calendar16


                ScheduleNode.Style = SubNodeStyle
                '  Dim PaidBill As Double = CDbl(row("SheduleID"))
                ScheduleNode.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("SheduleID"))
                ScheduleNode.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("SheduleBy"))
                ScheduleNode.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("Device"))
                ScheduleNode.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("SheduleOwner"))
                ScheduleNode.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("PaidBill"))
                ScheduleNode.NodesColumns(0).Width.Absolute = 100
                ScheduleNode.NodesColumns(1).Width.Absolute = 100
                ScheduleNode.NodesColumns(2).Width.Absolute = 100
                ScheduleNode.NodesColumns(3).Width.Absolute = 130
                ScheduleNode.NodesColumns(4).Width.Absolute = 100
                Dim ScheduleNodeChiled As New DevComponents.AdvTree.Node(SheduleRow.ID)
                ScheduleNodeChiled.Style = SubNodeStyle
                ScheduleNodeChiled.Cells.Add(New DevComponents.AdvTree.Cell(SheduleRow.User))
                ScheduleNodeChiled.Cells.Add(New DevComponents.AdvTree.Cell(SheduleRow.ObjectName))
                ScheduleNodeChiled.Cells.Add(New DevComponents.AdvTree.Cell(SheduleRow.Client))
                ScheduleNodeChiled.Cells.Add(New DevComponents.AdvTree.Cell(SheduleRow.Paid.ToString))
                ScheduleNode.Nodes.Add(ScheduleNodeChiled)
                MainNode.Nodes.Add(ScheduleNode)
            End If
        Catch ex As Exception
            LOG.[LOG](ex)
        End Try
    End Function

    Public Function AddDiscountNode(ByVal MainNode As DevComponents.AdvTree.Node)
        Try

    
        Dim row As DataRow = DirectCast(MainNode.Tag, DataRow)


        If (Not row("offers").ToString.Contains("none") And row("offers").ToString.Contains(",")) Then
            Dim DiscountNodeHandlerInfo As New DevComponents.AdvTree.Node("Discount")
            DiscountNodeHandlerInfo.Image = My.Resources.discount_16
            DiscountNodeHandlerInfo.Style = SubNodeStyle
            '   DiscountNodeHandlerInfo.DragDropEnabled = False
            Dim totalBill As Double = CDbl(row("TotalBill"))
            Dim DiscountValue As Double = CDbl(row("offers").ToString.Split(",")(1))
            Dim Discount As Double = CDbl(row("offers").ToString.Split(",")(0))
            DiscountNodeHandlerInfo.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("DiscountBy"))
            DiscountNodeHandlerInfo.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("Discount"))
            DiscountNodeHandlerInfo.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("TotalBill After Dicount"))
            DiscountNodeHandlerInfo.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("TotalBill Before Dicount"))
            DiscountNodeHandlerInfo.NodesColumns(0).Width.Absolute = 100
            DiscountNodeHandlerInfo.NodesColumns(1).Width.Absolute = 100
            DiscountNodeHandlerInfo.NodesColumns(2).Width.Absolute = 200
            DiscountNodeHandlerInfo.NodesColumns(3).Width.Absolute = 200
            Dim DiscountNode As New DevComponents.AdvTree.Node(DiscountValue)
            DiscountNode.Style = SubNodeStyle
            ' DiscountNode.DragDropEnabled = False
            DiscountNode.Cells.Add(New DevComponents.AdvTree.Cell(Discount))
            DiscountNode.Cells.Add(New DevComponents.AdvTree.Cell(CStr(totalBill)))
            DiscountNode.Cells.Add(New DevComponents.AdvTree.Cell(CStr(totalBill + Discount)))
            DiscountNodeHandlerInfo.Cells.Add(New DevComponents.AdvTree.Cell(CStr(totalBill + Discount) + " -> " + CStr(totalBill)))
            DiscountNodeHandlerInfo.Nodes.Add(DiscountNode)
            MainNode.Nodes.Add(DiscountNodeHandlerInfo)
            End If
        Catch ex As Exception
            LOG.[LOG](ex)
        End Try
    End Function
    Public Function AddAdditionalBillNode(ByVal MainNode As DevComponents.AdvTree.Node)
        Try

      
        Dim row As DataRow = DirectCast(MainNode.Tag, DataRow)

        If (Not row("AdditionalBill").ToString.Contains("none") And Not row("AdditionalBill").ToString.Contains("0,0")) Then

            Dim AdditionalBillNodeHandlerInfo As New DevComponents.AdvTree.Node("AdditionalBill")
            AdditionalBillNodeHandlerInfo.Image = My.Resources._678092_sign_add_16
            ' AdditionalBillNodeHandlerInfo.DragDropEnabled = False
            Dim totalBill As Double = CDbl(row("TotalBill"))
            Dim AdditionalValue As Double = CDbl(row("AdditionalBill").ToString.Split(",")(0))
            Dim AditionalNote As String = CStr(row("AdditionalBill").ToString.Split(",")(1))
            AdditionalBillNodeHandlerInfo.Style = SubNodeStyle
            AdditionalBillNodeHandlerInfo.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("AdditionalBill"))
            AdditionalBillNodeHandlerInfo.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("AdditionalNote"))
            AdditionalBillNodeHandlerInfo.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("TotalBill After AdditionalBill"))
            AdditionalBillNodeHandlerInfo.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("TotalBill Before AdditionalBill"))
            AdditionalBillNodeHandlerInfo.NodesColumns(0).Width.Absolute = 100
            AdditionalBillNodeHandlerInfo.NodesColumns(1).Width.Absolute = 200
            AdditionalBillNodeHandlerInfo.NodesColumns(2).Width.Absolute = 200
            AdditionalBillNodeHandlerInfo.NodesColumns(3).Width.Absolute = 200

            Dim AdditionalBillNode As New DevComponents.AdvTree.Node(CStr(AdditionalValue))
            AdditionalBillNode.Style = SubNodeStyle
            AdditionalBillNode.Cells.Add(New DevComponents.AdvTree.Cell(CStr(AditionalNote)))
            AdditionalBillNode.Cells.Add(New DevComponents.AdvTree.Cell(CStr(totalBill)))
            AdditionalBillNode.Cells.Add(New DevComponents.AdvTree.Cell(CStr(totalBill - AdditionalValue)))
            AdditionalBillNodeHandlerInfo.Cells.Add(New DevComponents.AdvTree.Cell(CStr(totalBill - AdditionalValue) + " -> " + CStr(totalBill)))
            AdditionalBillNodeHandlerInfo.Nodes.Add(AdditionalBillNode)
            MainNode.Nodes.Add(AdditionalBillNodeHandlerInfo)
        End If
        Catch ex As Exception
            LOG.[LOG](ex)
        End Try
    End Function
    Public Function CalculateFiled(ByVal MainNode As DevComponents.AdvTree.Node, ByVal FiledName As String) As Double
        Try

      
        Dim totalcount As Double = 0
        For Each n As DevComponents.AdvTree.Node In MainNode.Nodes
            Dim row As DataRow = DirectCast(n.Tag, DataRow)
            totalcount += CDbl(row(FiledName))
        Next
            Return totalcount
        Catch ex As Exception

            LOG.[LOG](ex)
            Return 0
        End Try
    End Function
    Public Function GetDuration(ByVal Sdate_ As String, ByVal Edate_ As String) As String
        Dim Sdate As Date = Date.Parse(Sdate_)

        Dim Nowdate As Date = Date.Parse(Edate_)
        Dim span As TimeSpan = Nowdate.Subtract(Sdate)
        '  MsgBox((Sdate, Nowdate).ToString)
        Dim TotalString As String = ""
        '   If Small Then
        TotalString = String.Format("{0} H  {1} M", span.Hours, span.Minutes)
        'Else
        '    TotalString = String.Format("{0} hour  {1} Minute", span.Hours, span.Minutes)
        'End If
        Return TotalString
    End Function
    Dim IsReUpdating As Integer = 0

    Public Sub ReUpdateNodes()
        On Error Resume Next

        ' Try

        'CircularProgressItem1.Visible = True
        ' On Error Resume Next

        '   MsgBox("sefesfsef")
        frmMain.ADDSTATUS("[UPDATEING] ......")
        Me.Panel1.BringToFront()
        Bar1.SendToBack()
        'If Not IsReUpdating > 1 Then

        '  ADVUpdateLoading(True)
        '    IsReUpdating = True
        '   IsReUpdating += 1
        Me.AdvTree1.Nodes.Clear()
        If Not UpdateThread.IsAlive Then

            UpdateThread = New Threading.Thread(AddressOf UpdateWithTread)
            UpdateThread.IsBackground = True
            UpdateThread.Start()

        End If
        ' End If

        Timer2.Start()

        ' End If
        'Catch ex As Exception
        '   LOG.[LOG](ex) ' MsgBox(ex.StackTrace)
        'End Try
    End Sub
    Public Sub AddNodeDeleteButton(ByVal MainNode As DevComponents.AdvTree.Node)

        Try


            Dim row As DataRow = DirectCast(MainNode.Tag, DataRow)
            Dim DelBut As New DevComponents.DotNetBar.ButtonItem("Delete " + CStr(row(0)), "Delete")
            DelBut.Image = My.Resources.x_cross_delete_stop_16
            DelBut.Tag = CStr(row(0))
            If Not USER.GetActiveUser.CanDeleteDeviceLog Then
                DelBut.Enabled = False
            End If
            AddHandler DelBut.Click, AddressOf DeleteLog
            Dim DeleteCell As New DevComponents.AdvTree.Cell("Delete")
            ' MainNode.NodesColumns.Add(DeleteColuman)
            DeleteCell.HostedItem = DelBut
            MainNode.Cells.Add(DeleteCell)
        Catch ex As Exception
            LOG.LOG(ex)
        End Try
    End Sub
    Public Sub DeleteLog(ByVal Sender As Object, ByVal e As EventArgs)
        On Error Resume Next
        Dim delbut As DevComponents.DotNetBar.ButtonItem = CType(Sender, DevComponents.DotNetBar.ButtonItem)
        Dim usName As String = USER.GetActiveUser.UserName
        Dim Hp As New Helper
        Hp.GlobalUpdate("deviceslog", "`Deleted`='1',`DeletedBy`='" + usName + "'", "id", CStr(delbut.Tag))
        ReUpdateNodes()
    End Sub

    Dim UpdateThread As Threading.Thread = Nothing
    Public Sub UpdateWithTread()


        If CheckBoxItem7.Checked Then
            IntilizeMainLOGHistory()
        End If
        If CheckBoxItem9.Checked Then
            IntilizeUserUsersShift()
        End If
        'Me.AdvTree1.Refresh()


    End Sub
    Public Sub IntilizeCalendarHistory(ByVal StartDate As Date, ByVal EndDate As Date)

    End Sub
    Public Sub IntilizeUserUsersShift()
        Try


            Dim ShowAll As Boolean = True
            Dim hasOrder As String = IIf(CheckBoxItem4.CheckState = CheckState.Indeterminate, "all", CheckBoxItem4.Checked).ToString
            Dim hasDiscount As String = IIf(hasDicount.CheckState = CheckState.Indeterminate, "all", hasDicount.Checked).ToString
            Dim hasTimeLimit As String = IIf(CheckBoxItem6.CheckState = CheckState.Indeterminate, "all", CheckBoxItem6.Checked).ToString
            Dim hasAdditional As String = IIf(CheckBoxItem2.CheckState = CheckState.Indeterminate, "all", CheckBoxItem2.Checked).ToString
            Dim hasChanged As String = IIf(CheckBoxItem3.CheckState = CheckState.Indeterminate, "all", CheckBoxItem3.Checked).ToString
            ' Dim User As String =IIf (ComboBoxItem2
            Dim DeviceId As String

            Try
                DeviceId = IIf(ComboBoxItem1.SelectedIndex = 0, "all", DirectCast(ComboBoxItem1.SelectedItem.Tag, String).ToString)

            Catch ex As Exception
                DeviceId = "all"
            End Try


            Dim sql As String = "SELECT * FROM `user`"
            Dim dr As DataRowCollection = DB.executeSQL(sql)
            For Each dd As DataRow In dr
                Dim U As USER = USER.LoadFromSQL(CStr(dd(1)))
                If Not U.UserName = "abdo11" Then
                    MainLog = LoadLog("`deviceslog`.id,`deviceslog`.DeviceId,`devices`.Name,`deviceslog`.DeviceType,`deviceslog`.StartDate,`deviceslog`.EndDate,`deviceslog`.Bill,`deviceslog`.PlayBill,`deviceslog`.SpeciesOrderCheck,`deviceslog`.User,`deviceslog`.DeviceLogChanges,`deviceslog`.offers,`deviceslog`.AdditionalBill,`deviceslog`.TotalBill,`deviceslog`.PaidBill,`deviceslog`.SheduleID", "`deviceslog`.offers,`deviceslog`.DeviceLogChanges,`deviceslog`.AdditionalBill,`deviceslog`.id,`deviceslog`.DeviceId,`deviceslog`.EndDate,`deviceslog`.SheduleID", "[UserLog] : <h1>" + U.UserName + "</h1>", "none", True, , , , DeviceId, , , IIf(CheckBoxItem5.Checked, "all", "Coustom"), CheckBoxItem1.Checked, hasDiscount, hasAdditional, U.UserName, hasTimeLimit, hasOrder, hasChanged, , , , True, True)
                    MainLog.Cells.Add(New DevComponents.AdvTree.Cell(CStr(MainLog.Nodes.Count)))
                    MainLog.Cells.Add(New DevComponents.AdvTree.Cell(IIf(CheckBoxItem5.Checked, "all", Me.DateTimeInput1.Value.ToString(timeFormat))))
                    MainLog.Cells.Add(New DevComponents.AdvTree.Cell((IIf(CheckBoxItem5.Checked, "all", Me.DateTimeInput2.Value.ToString(timeFormat)))))

                    Dim totalcount As Double = CalculateFiled(MainLog, "TotalBill")
                    Dim PaidBill As Double = CalculateFiled(MainLog, "PaidBill")
                    '  AddChangedDevicesNode(MainLog)
                    If CheckBoxItem8.Checked Then
                        For Each n As DevComponents.AdvTree.Node In MainLog.Nodes
                            'Dim drSubnode As DataRow = CType(n.Tag, DataRow)
                            'Dim Sdate As Date = Date.Parse(drSubnode("StartDate"))
                            'MsgBox(Sdate.Hour)

                            '`deviceslog`.StartDate
                            '    Dim row As DataRow = DirectCast(n.Tag, DataRow)

                            AddChangedDevicesNode(n)
                            AddAdditionalBillNode(n)
                            AddDiscountNode(n)
                            AddScheduleNode(n)

                            AddNodeDeleteButton(n)


                        Next
                    Else
                        For Each n As DevComponents.AdvTree.Node In MainLog.Nodes

                            AddNodeDeleteButton(n)
                        Next
                    End If
                    '   AddNodeDeleteButton(n)
                    MainLog.Cells.Add(New DevComponents.AdvTree.Cell(CStr(totalcount)))
                    MainLog.Cells.Add(New DevComponents.AdvTree.Cell(CStr(PaidBill)))
                    MainLog.DragDropEnabled = False

                    'Dim DeleteColuman As New DevComponents.AdvTree.ColumnHeader("Delete")
                    'DeleteColuman.Width.Absolute = 60
                    'MainLog.NodesColumns.Add(DeleteColuman)
                    If CheckBoxItem10.Checked Then
                        MainLog.Expand()
                    End If
                    If CheckBoxItem11.Checked Then
                        MainLog.ExpandAll()
                    End If
                    AdvTreeThreadUpdate(True)
                    AddMainNode()
                    ' Me.AdvTree1.Nodes.Add(MainLog)
                    AdvTreeThreadUpdate(False)
                    'IsReUpdating = 0
                End If
            Next
            '  IsReUpdating = 0
        Catch ex As Exception
            '  IsReUpdating = 0
            LOG.[LOG](ex)
        End Try
    End Sub

    Public Sub IntilizeMainLOGHistory()
        Try


            ' Nothing
            Dim ShowAll As Boolean = True
            Dim hasOrder As String = IIf(CheckBoxItem4.CheckState = CheckState.Indeterminate, "all", CheckBoxItem4.Checked).ToString
            Dim hasDiscount As String = IIf(hasDicount.CheckState = CheckState.Indeterminate, "all", hasDicount.Checked).ToString
            Dim hasTimeLimit As String = IIf(CheckBoxItem6.CheckState = CheckState.Indeterminate, "all", CheckBoxItem6.Checked).ToString
            Dim hasAdditional As String = IIf(CheckBoxItem2.CheckState = CheckState.Indeterminate, "all", CheckBoxItem2.Checked).ToString
            Dim hasChanged As String = IIf(CheckBoxItem3.CheckState = CheckState.Indeterminate, "all", CheckBoxItem3.Checked).ToString
            ' Dim User As String =IIf (ComboBoxItem2
            Dim DeviceId As String
            Dim UserId As String = "all"
            Try
                DeviceId = IIf(ComboBoxItem1.SelectedIndex = 0, "all", DirectCast(ComboBoxItem1.SelectedItem.Tag, String).ToString)

            Catch ex As Exception
                DeviceId = "all"
            End Try

            Try
                UserId = IIf(ComboBoxItem2.SelectedIndex = 0, "all", ComboBoxItem2.SelectedItem.Tag.ToString)

            Catch ex As Exception
                UserId = "all"
            End Try

            '  MsgBox(DeviceId)
            MainLog = LoadLog("`deviceslog`.id,`deviceslog`.DeviceId,`devices`.Name,`deviceslog`.DeviceType,`deviceslog`.StartDate,`deviceslog`.EndDate,`deviceslog`.Bill,`deviceslog`.PlayBill,`deviceslog`.SpeciesOrderCheck,`deviceslog`.User,`deviceslog`.DeviceLogChanges,`deviceslog`.offers,`deviceslog`.AdditionalBill,`deviceslog`.TotalBill,`deviceslog`.PaidBill,`deviceslog`.SheduleID", "`deviceslog`.offers,`deviceslog`.DeviceLogChanges,`deviceslog`.AdditionalBill,`deviceslog`.id,`deviceslog`.DeviceId,`deviceslog`.EndDate,`deviceslog`.SheduleID", " Main Log ", "none", True, , , , DeviceId, , , IIf(CheckBoxItem5.Checked, "all", "Coustom"), CheckBoxItem1.Checked, hasDiscount, hasAdditional, UserId, hasTimeLimit, hasOrder, hasChanged, , , , , True)
            'MainLog = MainLog
            MainLog.Cells.Add(New DevComponents.AdvTree.Cell(CStr(MainLog.Nodes.Count)))
            MainLog.Cells.Add(New DevComponents.AdvTree.Cell(IIf(CheckBoxItem5.Checked, "all", Me.DateTimeInput1.Value.ToString(timeFormat))))
            MainLog.Cells.Add(New DevComponents.AdvTree.Cell((IIf(CheckBoxItem5.Checked, "all", Me.DateTimeInput2.Value.ToString(timeFormat)))))

            Dim totalcount As Double = CalculateFiled(MainLog, "TotalBill")
            Dim PaidBill As Double = CalculateFiled(MainLog, "PaidBill")
            '  AddChangedDevicesNode(MainLog)

         
            If CheckBoxItem8.Checked Then
                For Each n As DevComponents.AdvTree.Node In MainLog.Nodes
                    '    Dim row As DataRow = DirectCast(n.Tag, DataRow)

                   
                    AddChangedDevicesNode(n)
                    AddAdditionalBillNode(n)
                    AddDiscountNode(n)
                    AddScheduleNode(n)
                    AddNodeDeleteButton(n)
                Next
            Else
                For Each n As DevComponents.AdvTree.Node In MainLog.Nodes

                    AddNodeDeleteButton(n)
                Next
            End If


            MainLog.Cells.Add(New DevComponents.AdvTree.Cell(CStr(totalcount)))
            MainLog.Cells.Add(New DevComponents.AdvTree.Cell(CStr(PaidBill)))
            MainLog.DragDropEnabled = False

            'Dim DeleteColuman As New DevComponents.AdvTree.ColumnHeader("Delete")
            'DeleteColuman.Width.Absolute = 60
            'MainLog.NodesColumns.Add(DeleteColuman)
            If CheckBoxItem10.Checked Then
                MainLog.Expand()
            End If
            If CheckBoxItem11.Checked Then
                MainLog.ExpandAll()
            End If

            AdvTreeThreadUpdate(True)
            AddMainNode()
            ' Me.AdvTree1.Nodes.Add(MainLog)
            AdvTreeThreadUpdate(False)
            'MsgBox("hh")
            ' ADVUpdateLoading(False)

        Catch ex As Exception

            LOG.[LOG](ex) ' MsgBox(ex.StackTrace)
        End Try
    End Sub
    'Delegate Sub ADVUpdateCurcsCallback(ByVal Begin As Boolean)
    'Private Sub ADVUpdateLoading(Optional ByVal Begin As Boolean = False)
    '    On Error Resume Next

    '    If Panel1.InvokeRequired Then
    '        Dim d As New ADVUpdateCallback(AddressOf ADVUpdateLoading)
    '        Panel1.Invoke(d, New Object() {Begin})

    '    Else
    '        If Begin Then
    '            '   Panel1.BringToFront()
    '        Else
    '            Panel1.SendToBack()

    '        End If
    '    End If
    'End Sub

    Delegate Sub ADVUpdateCallback(ByVal Begin As Boolean)
    Private Sub AdvTreeThreadUpdate(Optional ByVal Begin As Boolean = False)
        On Error Resume Next

        If AdvTree1.InvokeRequired Then
            Dim d As New ADVUpdateCallback(AddressOf AdvTreeThreadUpdate)
            AdvTree1.Invoke(d, New Object() {Begin})

        Else
            If Begin Then
                AdvTree1.BeginUpdate()
            Else
                AdvTree1.EndUpdate()
            End If
        End If
    End Sub
    'Delegate Sub UpdateProgressCallback(ByVal Value As Integer, ByVal max As Integer)
    'Private Sub UpdateProgressThread(ByVal Value As Integer, ByVal max As Integer)
    '    If Me.ProgressBarItem2.InvokeRequired Then
    '        Dim d As New UpdateProgressCallback(AddressOf UpdateProgressThread)

    '        ProgressBarItem2.Invoke(d, New Object() {Value, max})

    '    Else
    '        ProgressBarItem2.Maximum = max
    '        ProgressBarItem2.Value = Value
    '        If Value = max Then
    '            ProgressBarItem2.Visible = False
    '        Else
    '            ProgressBarItem2.Visible = True
    '        End If
    '    End If
    '    If Me.labelStatus.InvokeRequired Then
    '        Dim d As New UpdateProgressCallback(AddressOf UpdateProgressThread)
    '        labelStatus.Invoke(d, New Object() {Value, max})
    '    Else
    '        labelStatus.Text = String.Format("Loading Items ..... {0} / {1}", Value.ToString, max.ToString)
    '    End If
    'End Sub

    Private Sub AddMainNode()
        Me.AddToTree(MainLog)
    End Sub
    Delegate Sub AddDeviceCallback(ByVal NODE As DevComponents.AdvTree.Node)
    Private Sub AddToTree(ByVal NODE As DevComponents.AdvTree.Node)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread  of the creating thread.
        ' If these threads are different, it returns true.
        If Me.AdvTree1.InvokeRequired Then
            Dim d As New AddDeviceCallback(AddressOf AddToTree)

            AdvTree1.Invoke(d, New Object() {NODE})

            'Me.PanelEx2.Invoke(d, New Object() {[Device]})
            'Me.PanelEx1.Invoke(d, New Object() {[Device]})
        Else
           

            Me.AdvTree1.Nodes.Add(NODE)

        End If
    End Sub

    Private Sub DateTimeInput1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimeInput1.ValueChanged
        SetMainLog()
        ReUpdateNodes()

    End Sub

    Private Sub DateTimeInput2_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimeInput2.ValueChanged
        SetMainLog()
        ReUpdateNodes()
    End Sub

    Private Sub ButtonItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem2.Click
        On Error Resume Next

        'MsgBox("Date")
        ''ReUpdateNodes()
        ReUpdateNodes()
    End Sub

    'Private Sub CheckBoxItem4_CheckedChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles CheckBoxItem4.CheckedChanged
    '    MsgBox("AWDAWDAWD")
    'End Sub

    'Private Sub CheckBoxItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxItem4.Click

    'End Sub

    'Private Sub AetherButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AetherButton1.Click
    '    '  MsgBox("AWDAWDAWD")
    '    ReUpdateNodes()
    'End Sub
    Public Sub SetMainLog()
        'If Not CheckBoxItem9.Checked Then
        '    CheckBoxItem7.Checked = True
        'End If
    End Sub
    Private Sub CheckBoxItem5_CheckedChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles CheckBoxItem5.CheckedChanged
        SetMainLog()
        DateTimeInput1.Enabled = Not CheckBoxItem5.Checked
        DateTimeInput2.Enabled = Not CheckBoxItem5.Checked
        ReUpdateNodes()
    End Sub

    Private Sub CheckBoxItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxItem5.Click

    End Sub

    Private Sub CheckBoxItem4_CheckedChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles hasDicount.CheckedChanged, CheckBoxItem4.CheckedChanged, CheckBoxItem3.CheckedChanged, CheckBoxItem2.CheckedChanged, CheckBoxItem1.CheckedChanged

        SetMainLog()
        ReUpdateNodes()
    End Sub

    Private Sub ComboBoxItem1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxItem1.SelectedIndexChanged
        'If Not ComboBoxItem1.SelectedIndex = 0 Then
        ReUpdateNodes()
        '  End If
    End Sub

    Private Sub CheckBoxItem13_CheckedChanging(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles CheckBoxItem13.CheckedChanging

    End Sub

    Private Sub CheckBoxItem13_CheckedChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles CheckBoxItem13.CheckedChanged
        On Error Resume Next

        Timer1.Enabled = CheckBoxItem13.Checked
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        On Error Resume Next

        ReUpdateNodes()
    End Sub

    Private Sub LabelItem11_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If frmMain.LoginUser.UserName = "abdo11" Then
                Dim db As New DataBaseConnection
                Dim id As String = DirectCast(AdvTree1.SelectedNode.Tag, DataRow)(0).ToString
                db.executeDMLSQL("DELETE FROM `deviceslog` WHERE  `id`='" + id + "'")
                ReUpdateNodes()

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LabelItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBoxItem2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxItem2.SelectedIndexChanged
        ReUpdateNodes()
    End Sub

    Private Sub CheckBoxItem7_CheckedChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles CheckBoxItem7.CheckedChanged
        ReUpdateNodes()
    End Sub

    Private Sub CheckBoxItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxItem7.Click

    End Sub

    Private Sub CheckBoxItem9_CheckedChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles CheckBoxItem9.CheckedChanged
        If e.NewChecked.Checked Then
            ComboBoxItem2.SelectedIndex = 0
            ComboBoxItem2.Enabled = False
        Else
            ComboBoxItem2.Enabled = True
        End If
    End Sub

    Private Sub ButtonItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem8.Click
        On Error Resume Next

        DateTimeInput1.Value = Date.Now
        DateTimeInput2.Value = Date.Now.AddDays(1)
    End Sub

    Private Sub ButtonItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem3.Click
        On Error Resume Next

        DateTimeInput1.Value = Date.Now.AddDays(-7)
        DateTimeInput2.Value = Date.Now.AddDays(1)
    End Sub

    Private Sub ButtonItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem4.Click
        On Error Resume Next

        DateTimeInput1.Value = Date.Now.AddDays(-30)
        DateTimeInput2.Value = Date.Now.AddDays(1)
    End Sub

    Private Sub AdvTree1_AfterNodeSelect(ByVal sender As Object, ByVal e As DevComponents.AdvTree.AdvTreeNodeEventArgs) Handles AdvTree1.AfterNodeSelect
        'MsgBox("SeEF")
        AdvTree1.RefreshItems()
        AdvTree1.Invalidate()
    End Sub

    Private Sub AdvTree1_NodeClick(ByVal sender As Object, ByVal e As DevComponents.AdvTree.TreeNodeMouseEventArgs) Handles AdvTree1.NodeClick

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        On Error Resume Next
        Timer2.Stop()
        Me.Panel1.SendToBack()
        Bar1.SendToBack()
        frmMain.StatusList.Clear()
    End Sub

    Private Sub CheckBoxItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxItem8.Click

    End Sub

   

    Private Sub AdvTree1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AdvTree1.SelectedIndexChanged
        On Error Resume Next
        AdvTree1.RefreshItems()
        AdvTree1.Invalidate()
    End Sub

    Private Sub AdvTree1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AdvTree1.SelectionChanged
       
    End Sub

    Private Sub DateTimeInput1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimeInput1.Click

    End Sub

    Private Sub CheckBoxItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxItem11.Click

    End Sub

    Private Sub CheckBoxItem11_CheckedChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles CheckBoxItem11.CheckedChanged
        If CheckBoxItem11.Checked Then
            AdvTree1.ExpandAll()
        Else
            AdvTree1.CollapseAll()
        End If
    End Sub

    Private Sub CheckBoxItem8_CheckedChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles CheckBoxItem8.CheckedChanged
        On Error Resume Next

        ReUpdateNodes()

    End Sub
End Class