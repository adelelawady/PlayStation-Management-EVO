Imports DevComponents.Schedule.Model
Imports DevComponents.DotNetBar.Schedule
Imports DevComponents.DotNetBar

Public Class Schedule
    Dim timeFormat As String = "yyyy-MM-dd HH:mm:ss"
    Private Sub InContentAddAppContextItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InContentAddAppContextItem.Click
        On Error Resume Next

        ' X.ShowDialog(Me)

        Dim startDate As Date = calendarView1.DateSelectionStart.GetValueOrDefault()
        Dim endDate As Date = calendarView1.DateSelectionEnd.GetValueOrDefault()
      
        If calendarView1.DateSelectionStart.HasValue AndAlso calendarView1.DateSelectionEnd.HasValue Then
            Dim X As New ADDRESRVATION(startDate, endDate)
            If X.ShowDialog = DialogResult.OK Then
                'AddNewAppointment(X.DateTimeInput1.Value, X.DateTimeInput2.Value, "Device", X.ComboBoxEx1.SelectedItem.tag, X.ComboBoxEx1.SelectedText, "Adel elawady")

                Dim ScheduleSpecialKey As String = ScheduleObject.InsertSchedule("[Device]", X.ComboBoxEx1.SelectedItem.tag, startDate.ToString(timeFormat), endDate.ToString(timeFormat), X.IntegerInput1.Value, X.TextBoxX1.Text, frmMain.LoginUser.UserName.ToString, X.ComboBoxEx1.SelectedItem.Text, X.DoubleInput1.Value, X.TextBoxX2.Text)
                Dim schObject As New ScheduleObject(ScheduleSpecialKey, False)

                calendarView1.CalendarModel.Appointments.Add(schObject.GetObjectSchedule)

            End If
        End If
    End Sub
    'Public Function CheckAppAt(ByVal startdate As Date, ByVal enddate As Date, ByVal app As DevComponents.Schedule.Model.Appointment)
    '    For Each appo As DevComponents.Schedule.Model.Appointment In calendarView1.CalendarModel.Appointments
    '        '   If app
    '        If appo.StartTime =
    '    Next

    '    ' calendarView1.CalendarModel.CustomReminders.Add (New Reminder (
    'End Function
    ''' <summary>
    ''' Handles CalendarView MouseUp events
    ''' </summary>
    ''' <param name="sender">Varied sender</param>
    ''' <param name="e">MouseEventArgs</param>
    Private Sub CalendarView1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles calendarView1.MouseUp
        ' Process Right MouseUp event in order to
        ' present view specific ContextMenu

        If e.Button = MouseButtons.Right Then
            ' Main Calendar View hit
            '  MsgBox(sender.GetType.Name.ToString)
            'Clipboard.SetText(sender.GetType.Name.ToString)
            If TypeOf sender Is BaseView Then
                If calendarView1.DateSelectionStart.HasValue AndAlso calendarView1.DateSelectionEnd.HasValue Then
                    BaseViewMouseUp(sender, e)
                End If




                '    ' AppointmentView hit

            ElseIf TypeOf sender Is AppointmentView Then
                AppointmentViewMouseUp(sender, e)

                '    ' AllDayPanel hit

                'ElseIf TypeOf sender Is AllDayPanel Then
                '    AllDayPanelMouseUp(sender, e)

                '    ' TimeRulerPanel

                'ElseIf TypeOf sender Is TimeRulerPanel Then
                '    TimeRulerPanelMouseUp(sender, e)

                '    ' TimeLineHeaderPanel

                'ElseIf TypeOf sender Is TimeLineHeaderPanel Then
                '    TimeLineHeaderPanelMouseUp(sender, e)

                '    ' CustomCalendarItem

                'ElseIf TypeOf sender Is CustomCalendarItem Then
                '    CustomCalendarItemMouseUp(sender, e)

                'ElseIf TypeOf sender Is BaseItem Then
                '    Dim bi As BaseItem = TryCast(sender, BaseItem)

                '    If TypeOf bi.Parent Is CustomCalendarItem Then
                '        CustomCalendarItemMouseUp(bi.Parent, e)
                '    End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' Adds a new appointment at the user selected time
    ''' </summary>
    Private Function AddNewAppointment(ByVal startDate As DateTime, ByVal endDate As DateTime, ByVal Type As String, ByVal ObjectID As String, ByVal Objectname As String, ByVal CostomerDetailes As String) As Appointment
        ' Create new appointment and add it to the model
        ' Appointment will show up in the view automatically

        Dim appointment As New DevComponents.Schedule.Model.Appointment()

        appointment.StartTime = startDate
        appointment.EndTime = endDate
        If Type = "Device" Then

        End If
        appointment.Subject = Objectname + " Reservation"

        appointment.Description = "Name: " + CostomerDetailes
        appointment.Tooltip = "Device Reservation"

        ' Add appointment to the model

        calendarView1.CalendarModel.Appointments.Add(appointment)

        Return (appointment)
    End Function
#Region "AppointmentViewMouseUp"

    ''' <summary>
    ''' Handles AppointmentView MouseUp events
    ''' </summary>
    ''' <param name="sender">AppointmentView</param>
    ''' <param name="e">MouseEventArgs</param>
    Private Sub AppointmentViewMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim view As AppointmentView = TryCast(sender, AppointmentView)
        Dim appoi As ScheduleObject = DirectCast(view.Appointment.Tag, ScheduleObject)

        ' Select the appointment
        view.IsSelected = True
        labelItem3.Text = appoi.Type + " : <b><font color=""#22B14C"">" + appoi.ObjectName + "</font></b>"
        labelItem4.Text = "Owner : <b><font color=""#22B14C"">" + appoi.Client + "</font></b>"
        LabelItem5.Text = "Paid : <b><font color=""#22B14C"">" + appoi.Paid.ToString + "</font></b>"
        LabelItem1.Text = "AddedBy : <b><font color=""#22B14C"">" + appoi.User.ToString + "</font></b>"
        'MsgBox(appoi.ISEnded)
        ' Let the user delete the appointment
        AppDeleteContextItem.Enabled = (view.Appointment.IsRecurringInstance = False)
        AppointmentContextMenu.Tag = view
        'MsgBox("Warning : " + appoi.IsWarning.ToString)
        'MsgBox("Active : " + appoi.IsActive.ToString)
        'MsgBox("IsEnd : " + appoi.ISEnded.ToString)
        'StartIn
        ' MsgBox("IsEnd : " + appoi.StartIn.ToString)
        ShowContextMenu(AppointmentContextMenu)
    End Sub
    Private Sub Schedule_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error Resume Next

        calendarView1.Is24HourFormat = False
        'initlziDevices()
        Dim usr As USER = USER.LoadFromSQL(frmMain.LoginUser.UserName)

        Me.InContentAddAppContextItem.Enabled = CBool(usr.[CanCreateSchedule])
        '  MsgBox(usr.[CanDeleteSchedule])
        Me.AppDeleteContextItem.Enabled = CBool(usr.[CanDeleteSchedule])
        LoadAppo()
    End Sub
    Public Sub LoadAppo()
        calendarView1.BeginUpdate()
        calendarView1.CalendarModel.Appointments.Clear()
        For Each Schedules As DataRow In ScheduleObject.GetSchedules
            Dim sch As New ScheduleObject(CStr(Schedules(0)))
            calendarView1.CalendarModel.Appointments.Add(sch.GetObjectSchedule)
        Next
        calendarView1.EndUpdate()
    End Sub
#End Region
#Region "View change"

    ''' <summary>
    ''' Day view selection
    ''' </summary>
    ''' <param name="sender">PopupItem</param>
    ''' <param name="e">EventArgs</param>
    Private Sub btnDay_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDay.Click
        calendarView1.SelectedView = eCalendarView.Day
    End Sub

    ''' <summary>
    ''' Week view selection
    ''' </summary>
    ''' <param name="sender">PopupItem</param>
    ''' <param name="e">EventArgs</param>
    Private Sub btnWeek_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnWeek.Click
        calendarView1.SelectedView = eCalendarView.Week
    End Sub

    ''' <summary>
    ''' Month view selection
    ''' </summary>
    ''' <param name="sender">PopupItem</param>
    ''' <param name="e">EventArgs</param>
    Private Sub btnMonth_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMonth.Click
        calendarView1.SelectedView = eCalendarView.Month
    End Sub

    ''' <summary>
    ''' TimeLine view selection
    ''' </summary>
    ''' <param name="sender">PopupItem</param>
    ''' <param name="e">EventArgs</param>
    Private Sub btnTimeLine_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTimeLine.Click
        calendarView1.SelectedView = eCalendarView.TimeLine
    End Sub

#End Region


#Region "BaseViewMouseUp"

    ''' <summary>
    ''' Handles Day, Week, and Month View MouseUp events
    ''' </summary>
    ''' <param name="sender">BaseView</param>
    ''' <param name="e">MouseEventArgs</param>
    Private Sub BaseViewMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim view As BaseView = TryCast(sender, BaseView)
        Dim area As eViewArea = view.GetViewAreaFromPoint(e.Location)

        If area = eViewArea.InContent Then
            InContentMouseUp(view, e)

        ElseIf area = eViewArea.InDayOfWeekHeader Then
            InHeaderMouseUp(view, e)

        ElseIf area = eViewArea.InSideBarPanel Then
            InSideBarMouseUp(view, e)

        ElseIf area = eViewArea.InCondensedView Then
            InCondensedViewMouseUp(e)
        End If
    End Sub
    ''' <summary>
    ''' Handles BaseView InHeader MouseUp events.
    ''' </summary>
    ''' <param name="view">BaseView</param>
    ''' <param name="e">MouseEventArgs</param>
    Private Sub InHeaderMouseUp(ByVal view As BaseView, ByVal e As MouseEventArgs)
        If TypeOf view Is MonthView Then
            Dim mv As MonthView = TryCast(view, MonthView)

            ' The View is a month view, so let the user
            ' hide or show the SideBar panel

            If mv.IsSideBarVisible = True Then
                InHeaderHideSideBarContextItem.Visible = True
                InHeaderShowSideBarContextItem.Visible = False
            Else
                InHeaderHideSideBarContextItem.Visible = False
                InHeaderShowSideBarContextItem.Visible = True
            End If
        Else
            InHeaderHideSideBarContextItem.Visible = False
            InHeaderShowSideBarContextItem.Visible = False
        End If

        InHeaderContextMenu.Tag = view

        ShowContextMenu(InHeaderContextMenu)
    End Sub
#Region "InSideBarMouseUp"

    ''' <summary>
    ''' Handles SideBar MouseUp events
    ''' </summary>
    ''' <param name="view">BaseView</param>
    ''' <param name="e">MouseEventArgs</param>
    Private Sub InSideBarMouseUp(ByVal view As BaseView, ByVal e As MouseEventArgs)
        InSideBarContextMenu.Tag = view

        ShowContextMenu(InSideBarContextMenu)
    End Sub

#End Region

#Region "InCondensedViewMouseUp"

    ''' <summary>
    ''' Handles Mouse Up events in the CondensedView
    ''' area of the control
    ''' </summary>
    ''' <param name="e">MouseEventArgs</param>
    Private Sub InCondensedViewMouseUp(ByVal e As MouseEventArgs)
        ShowContextMenu(CondensedViewContextMenu)
    End Sub

#End Region

#Region "InContentMouseUp"

    ''' <summary>
    ''' Handles BaseView InContent MouseUp events
    ''' </summary>
    ''' <param name="view">BaseView</param>
    ''' <param name="e">MouseEventArgs</param>
    Private Sub InContentMouseUp(ByVal view As BaseView, ByVal e As MouseEventArgs)
        ' Get the DateSelection start and end
        ' from the current mouse location

        Dim startDate As DateTime, endDate As DateTime
      
        If calendarView1.GetDateSelectionFromPoint(e.Location, startDate, endDate) = True Then
            ' If this date already falls outside the currently
            ' selected range (DateSelectionStart and DateSelectionEnd)
            ' then select the new range
          
            If IsDateSelected(startDate, endDate) = False Then
                calendarView1.DateSelectionStart = startDate
                calendarView1.DateSelectionEnd = endDate

            End If
        End If

        ' Remove any previously added view specific items

        For i As Integer = InContentContextMenu.SubItems.Count - 1 To 4 Step -1
            InContentContextMenu.SubItems.RemoveAt(i)
        Next

        ' If this is a TimeLine view, then add a couple
        ' of extra items
        ShowContextMenu(InContentContextMenu)


    End Sub
#Region "ShowContextMenu"

    ''' <summary>
    ''' Shows the given ContextMenu
    ''' </summary>
    ''' <param name="cm">ContextMenu to show</param>
    Private Sub ShowContextMenu(ByVal cm As ButtonItem)
        Dim pt As Point = Control.MousePosition
        cm.Popup(pt)
    End Sub

#End Region
#Region "bi_CondensedClick"

    ''' <summary>
    ''' Handles InContentContextMenu Condensed selection
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub bi_CondensedClick(ByVal sender As Object, ByVal e As EventArgs)
        calendarView1.TimeLineCondensedViewVisibility = eCondensedViewVisibility.AllResources
    End Sub

#End Region

#Region "bi_PageNavigatorClick"

    ''' <summary>
    ''' Handles InContentContextMenu PageNavigator selection
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub bi_PageNavigatorClick(ByVal sender As Object, ByVal e As EventArgs)
        calendarView1.TimeLineShowPageNavigation = (calendarView1.TimeLineShowPageNavigation = False)
    End Sub

#End Region

#Region "IsDateSelected"

    ''' <summary>
    ''' Determines if the given date range is within the currently selected
    ''' CalendarView selection range (DateSelectionStart to DateSelectionEnd)
    ''' </summary>
    ''' <param name="startDate">Start date range</param>
    ''' <param name="endDate">End date range</param>
    ''' <returns>True if selected</returns>
    Private Function IsDateSelected(ByVal startDate As DateTime, ByVal endDate As DateTime) As Boolean
        If calendarView1.DateSelectionStart.HasValue AndAlso calendarView1.DateSelectionEnd.HasValue Then
            If calendarView1.DateSelectionStart.Value <= startDate AndAlso calendarView1.DateSelectionEnd.Value >= endDate Then
                Return (True)
            End If
        End If

        Return (False)
    End Function

#End Region



    
#End Region

#End Region




    Private Sub AppDeleteContextItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AppDeleteContextItem.Click
        If calendarView1.SelectedAppointments.Count = 1 Then
            Dim app As DevComponents.Schedule.Model.Appointment = calendarView1.SelectedAppointments(0).Appointment
            Dim Sch As ScheduleObject = DirectCast(app.Tag, ScheduleObject)
            calendarView1.CalendarModel.Appointments.Remove(app)
            Sch.DeleteSchedule()
        End If
       
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        On Error Resume Next

        'calendarView1.BeginUpdate()
        'calendarView1.CalendarModel.Appointments.Clear()
        Me.LoadAppo()
    End Sub

    Private Sub AppointmentContextMenu_PopupShowing(ByVal sender As Object, ByVal e As System.EventArgs) Handles AppointmentContextMenu.PopupShowing
        On Error Resume Next

        Me.AppDeleteContextItem.Enabled = CBool(frmMain.LoginUser.[CanDeleteSchedule])
    End Sub
End Class