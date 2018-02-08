Option Explicit On
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic '<<< do this
Imports System.Threading
Imports System.Reflection
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports DevComponents.DotNetBar

Public Class DeviceControl1
    Public Event DeviceSesstionUpdate()

    Public Event SelectionChanged(ByVal sender As DeviceControl1)
    Dim NearSF As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near}
    Friend WithEvents tmrMouseLeave As New System.Windows.Forms.Timer With {.Interval = 10}
    Dim family As FontFamily = New FontFamily("Segoe UI")
    Private MousePoint As Point
    Private MainDv As Device
    Private DviceChange As Boolean = False
    Private Usr As USER = Nothing
    Public Sub New(ByVal Dv As Device, ByVal usrX As USER)
        On Error Resume Next

        InitializeComponent()
        Dv.ControlDevice = Me
        Control.CheckForIllegalCrossThreadCalls = False
        Me.DoubleBuffered = True
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        MainDv = Dv
        Me.Dock = DockStyle.Fill
        AddHandler Dv.SesstionClosed, AddressOf StatusChanged
        AddHandler Dv.SesstionStarted, AddressOf StatusChanged
        AddHandler Dv.SpeciesLoaded, AddressOf UpdateRefresh
        ' Me.UpdateActive()
        Usr = USER.LoadFromSQL(usrX.UserName)
        ItemContainer8.Enabled = CBool(usr.CanEditTotalBill)
        ButtonItem4.Enabled = CBool(usr.CanAddAdditionalCash)
        '  ButtonItem11.Enabled = TextBoxItem1.Enabled = CBool(Usr.CanSetOffers)
        Dv.CheckActive()

    End Sub
    Public Shared ReadOnly Property Timer As Double
        Get
            Return (CDbl((DateTime.Now.Ticks Mod &HC92A69C000)) / 10000000)
        End Get
    End Property
    ReadOnly Property Device As Device
        Get
            Return Me.MainDv
        End Get

    End Property
    Property CanChangeDevice As Boolean
        Get
            Return Me.DviceChange
        End Get
        Set(ByVal value As Boolean)
            Me.DviceChange = value

        End Set
    End Property
    Sub UpdateRefresh()
        Me.Refresh()
    End Sub
    Public Sub StatusChanged()
        On Error Resume Next

        ' Me.MainDv.InitializeData()
        '   MainDv.InitializeData()

        Me.Refresh()

        RaiseEvent DeviceSesstionUpdate()
        '  Me.Refresh()
    End Sub
#Region "Properties"

    Private mSelected As Boolean
    Public Property Selected() As Boolean
        Get
            Return mSelected
        End Get
        Set(ByVal value As Boolean)
            mSelected = value
            Refresh()
        End Set
    End Property

#End Region
#Region "Mouse coding"
    Private Enum MouseCapture
        Outside
        Inside
    End Enum
    Private Enum ButtonState
        ButtonUp
        ButtonDown
        Disabled
    End Enum
    Dim bState As ButtonState
    Dim bMouse As MouseCapture

    Private Sub DeviceControl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click

    End Sub


    Private Sub ListControlItem_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        On Error Resume Next

        'If Selected = False Then
        '  MsgBox(Me.Size.ToString)
        TypesCOnt.SubItems.Clear()
        '  End If
    End Sub

    Private Sub DeviceControl1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDoubleClick
        On Error Resume Next


        If Usr.CanStartCloseSession Then


            If Device.DeviceOptions.CanActive Then
                If Me.Device.Statue = Device.DeviceStatus.IsActive Then

                    Dim closepop As New DeviceSesstionClosePOPUP(Device)
                    If closepop.ShowDialog() = DialogResult.OK Then
                        Me.Device.CloseSesstion()
                    End If

                    ' tableChanged(tb)
                Else
                    Me.Device.StartSesstion()
                    ' tableChanged(tb)
                End If
            End If
        Else
            MsgBox("YOU DONT HAVE RIGHTS TO DO THAT")

        End If
    End Sub

    Private Sub metroRadioGroup_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown ', rdButton.MouseDown
        On Error Resume Next
        If Not Me.Selected = True Then
            'bState = ButtonState.ButtonDown
            RaiseEvent SelectionChanged(Me)
            Selected = True
            Refresh()
        End If
        'Dim UpMinute As Rectangle = New Rectangle(New Point(Me.Width - 48, 14), My.Resources.arrow_up_16.Size)
        'If UpMinute.Contains(e.Location) Then
        '    Me.Device.StartDate = Me.Device.StartDate.AddMinutes(+1)
        '    Me.Device.UpdateDevice()
        '    Me.Device.InitializeData()
        '    Me.Refresh()
        'End If

    End Sub

    Private Sub metroRadioGroup_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        bMouse = MouseCapture.Inside
        tmrMouseLeave.Start()
        Refresh()
    End Sub


    Private Sub metroRadioGroup_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp ', rdButton.MouseUp
        bState = ButtonState.ButtonUp
        Refresh()
    End Sub

    Private Sub tmrMouseLeave_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMouseLeave.Tick
        On Error Resume Next

        Dim scrPT = Control.MousePosition
        Dim ctlPT As Point = Me.PointToClient(scrPT)
        '
        If ctlPT.X < 0 Or ctlPT.Y < 0 Or ctlPT.X > Me.Width Or ctlPT.Y > Me.Height Then
            ' Stop timer
            tmrMouseLeave.Stop()
            bMouse = MouseCapture.Outside
            Refresh()
        Else
            bMouse = MouseCapture.Inside
        End If
    End Sub
#End Region

#Region "Painting"

    Private Sub Paint_DrawBackground(ByVal gfx As Graphics)
        '
        '  On Error Resume Next

        '   MainDv.InitializeData()



        Dim rect As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)

        '/// Build a rounded rectangle

        Using p As New GraphicsPath

            ' Try


            Const Roundness = 10
            p.StartFigure()


            p.AddArc(New Rectangle(rect.Left, rect.Top, Roundness, Roundness), 180, 90)
            p.AddLine(rect.Left + Roundness, 0, rect.Right - Roundness, 0)
            p.AddArc(New Rectangle(rect.Right - Roundness, 0, Roundness, Roundness), -90, 90)
            p.AddLine(rect.Right, Roundness, rect.Right, rect.Bottom - Roundness)
            p.AddArc(New Rectangle(rect.Right - Roundness, rect.Bottom - Roundness, Roundness, Roundness), 0, 90)
            p.AddLine(rect.Right - Roundness, rect.Bottom, rect.Left + Roundness, rect.Bottom)
            p.AddArc(New Rectangle(rect.Left, rect.Height - Roundness, Roundness, Roundness), 90, 90)



            p.CloseFigure()


            '/// Draw the background ///
            Dim ColorScheme As Color() = Nothing
            Dim brdr As SolidBrush = Nothing

            If bState = ButtonState.Disabled Then
                ' normal
                brdr = ColorSchemes.DisabledBorder
                ColorScheme = ColorSchemes.DisabledAllColor
            Else
                If mSelected Then
                    ' Selected
                    brdr = ColorSchemes.SelectedBorder

                    If bState = ButtonState.ButtonUp And bMouse = MouseCapture.Outside Then
                        ' normal
                        ColorScheme = ColorSchemes.SelectedNormal

                    ElseIf bState = ButtonState.ButtonUp And bMouse = MouseCapture.Inside Then
                        '  hover 
                        ColorScheme = ColorSchemes.SelectedHover

                    ElseIf bState = ButtonState.ButtonDown And bMouse = MouseCapture.Outside Then
                        ' no one cares!
                        Exit Sub
                    ElseIf bState = ButtonState.ButtonDown And bMouse = MouseCapture.Inside Then
                        ' pressed
                        ColorScheme = ColorSchemes.SelectedPressed
                    End If

                Else
                    ' Not selected
                    brdr = ColorSchemes.UnSelectedBorder

                    If bState = ButtonState.ButtonUp And bMouse = MouseCapture.Outside Then
                        ' normal
                        brdr = ColorSchemes.DisabledBorder
                        ColorScheme = ColorSchemes.UnSelectedNormal

                    ElseIf bState = ButtonState.ButtonUp And bMouse = MouseCapture.Inside Then
                        '  hover 
                        ColorScheme = ColorSchemes.UnSelectedHover

                    ElseIf bState = ButtonState.ButtonDown And bMouse = MouseCapture.Outside Then
                        ' no one cares!
                        Exit Sub
                    ElseIf bState = ButtonState.ButtonDown And bMouse = MouseCapture.Inside Then
                        ' pressed
                        ColorScheme = ColorSchemes.UnSelectedPressed
                    End If

                End If
            End If

            ' Draw
            Using b As LinearGradientBrush = New LinearGradientBrush(rect, Color.FromArgb(43, 60, 89), Color.FromArgb(43, 60, 89), LinearGradientMode.Vertical)

                Dim blend As ColorBlend = New ColorBlend
                blend.Colors = ColorScheme
                blend.Positions = New Single() {0.0F, 0.1, 0.9F, 0.95F, 1.0F}
                b.InterpolationColors = blend
                gfx.FillPath(b, p)

                '// Draw border
                gfx.DrawPath(New Pen(brdr), p)
                '1; 83

                'If Me.IsActive Then
                '    gfx.DrawRectangle(Pens.Green, 2, 3, Me.Width - 2, 5)
                '    gfx.FillRectangle(Brushes.LimeGreen, 2, 3, Me.Width - 2, 5)
                'Else
                '    gfx.DrawRectangle(Pens.Green, 2, 3, Me.Width - 2, 5)
                '    gfx.FillRectangle(Brushes.Red, 2, 3, Me.Width - 2, 5)
                'End If






                'If Not bMouse = MouseCapture.Inside Then
                '    If MainDv.IsOverTime Then
                '        DrawOverTimePanel(gfx)
                '    End If
                'End If

                Dim TimeRect As New Rectangle(4, Me.Height - 45, 80, 16)
                Dim RoomTagRect As New Rectangle(4, 50, 40, 16)
                Dim Scheduled As New Rectangle(65, 50, 40, 16)
                Dim ScheduledStr As New Rectangle(90, 50, 40, 16)

                Dim B2 As New SolidBrush(Color.White)

                If (bMouse = MouseCapture.Inside OrElse Selected) Then
                    B2 = New SolidBrush(Color.DimGray)
                Else

                    B2 = New SolidBrush(Color.White)

                End If

                If Device.IsPlayStationDevice Then
                    If MainDv.Type.Id = 1 Then
                        DrawTag(MainDv.Type.Name, gfx, New Rectangle(4, Me.Height - 25, 70, 15), Color.DarkGray, Color.Black, Color.White)
                    Else

                        DrawTag(MainDv.Type.Name, gfx, New Rectangle(4, Me.Height - 25, 70, 15), Color.DarkGray, Color.Black, Color.Gold)
                    End If
                Else
                    DrawTag("طربيظه", gfx, New Rectangle(4, Me.Height - 25, 70, 15), Color.DarkGray, Color.Black, Color.SandyBrown)

                End If

                If Me.Device.IsPlayStationDevice Then
                    gfx.DrawImage(My.Resources.desktop_monitor_screen_64, 10, 10, 35, 35)
                Else
                    gfx.DrawImage(My.Resources.Armchair, 10, 10, 35, 35)
                End If


                gfx.DrawString(MainDv.Name, New Font("justagain_din", 18), B2, New Point(54, 14))

                If Device.Scheduled Or Device.NextScheduling Then
                    gfx.DrawImage(My.Resources.Calendar, Scheduled.Location.X, Scheduled.Location.Y, 16, 16)
                    If Device.Statue = EVO.Device.DeviceStatus.Empty Then
                        '  Try
                        DrawTag(String.Format("يبداء خلال : {0} د", CInt(Device.NextSchedule.StartIn.TotalMinutes).ToString), gfx, ScheduledStr, Color.WhiteSmoke, Color.Black, Color.Red)
                        'Catch ex As Exception
                        'End Try
                    End If
                    '  DrawTag("ROOM", gfx, RoomTagRect, Color.DarkGray, Color.Gray, Color.Gold)
                End If


                If Device.DeviceOptions.CanActive Then
                    If Not CanChangeDevice Then
                        If MainDv.Statue = Device.DeviceStatus.IsActive Then
                            '  If MainDv.Species.Count > 0 Then


                            'End If
                            If Device.IsPlayStationDevice Then


                                If Not Device.IsOver Then
                                    If Not Device.ISTimeLimit Then
                                        DrawTag("الوقت| مفتوح", gfx, TimeRect, Color.Green, Color.Black, Color.White)
                                    Else
                                        If Not bMouse = MouseCapture.Inside Then
                                            DrawTag("الوقت | " + CStr(Device.TimeLimit.ToString("hh\:mm")), gfx, TimeRect, Color.Red, Color.Black, Color.White)
                                        Else
                                            DrawTag("المتبقي | " + String.Format(" {0} س {1} د ", Device.RestTime.Hours, Device.RestTime.Minutes).Replace("-", ""), gfx, TimeRect, Color.White, Color.Yellow, Color.Black)
                                        End If

                                    End If
                                Else
                                    If Device.DeviceOptions.ShowOvertime Then


                                        If bMouse = MouseCapture.Inside Then
                                            DrawTag("وقت اضافي |" + MainDv.OverTime.ToString("hh\:mm"), gfx, TimeRect, Color.Red, Color.Black, Color.White)
                                        Else
                                            DrawTag("المتبقي : انتهي", gfx, TimeRect, Color.Red, Color.Black, Color.White)
                                        End If
                                    End If

                                End If




                                If Me.Device.IsChangedDevice Then
                                    gfx.DrawImage(My.Resources._0042_092_refresh_update_reload_sync_syncronization_16, New Point(Me.Width - 28, 12))
                                    Using F1 As New Font("justagain_din", 9, FontStyle.Regular)
                                        gfx.DrawString("تم تغيير الجهاز", F1, Brushes.SteelBlue, New Point(Me.Width - 95, 12))
                                    End Using

                                End If

                                If Device.ControllersCount > 0 Then
                                    gfx.DrawImage(My.Resources._Game_Controller_16, New Point(Me.Width - 28, 50))
                                    Using F1 As New Font("justagain_din", 10, FontStyle.Bold)
                                        gfx.DrawString(CStr(Device.ControllersCount).ToString, F1, Brushes.Teal, New Point(Me.Width - 44, 50))
                                    End Using

                                End If
                            End If
                            If Device.DeviceOptions.IsRoomDevice Then
                                DrawTag("|غرفه|", gfx, RoomTagRect, Color.DarkGray, Color.Gray, Color.Gold)
                            End If



                            'If bMouse = MouseCapture.Inside Then
                            '    gfx.DrawImage(My.Resources.arrow_up_16, New Point(Me.Width - 28, 14))
                            '    gfx.DrawImage(My.Resources.arrow_up_16, New Point(Me.Width - 48, 14))
                            '    Using F1 As New Font("Segoe UI", 10, FontStyle.Bold)
                            '        gfx.DrawString("H", F1, B2, New Point(Me.Width - 28, 14 + My.Resources.arrow_up_16.Height))
                            '        gfx.DrawString("M", F1, B2, New Point(Me.Width - 48, 14 + My.Resources.arrow_up_16.Height))
                            '    End Using
                            '    gfx.DrawImage(My.Resources.arrow_down_16, New Point(Me.Width - 28, 14 + My.Resources.arrow_up_16.Height + 15))
                            '    gfx.DrawImage(My.Resources.arrow_down_16, New Point(Me.Width - 48, 14 + My.Resources.arrow_up_16.Height + 15))

                            'End If


                            If Me.Device.HasSpectialOffer Then
                                gfx.DrawImage(My.Resources.discount_16, New Point(Me.Width - 28, 32))
                                Using F1 As New Font("Segoe UI", 8, FontStyle.Regular)
                                    gfx.DrawString(String.Format("{0}% | -{1}", Device.DeviceSpectialOffer.value.ToString, CInt(Device.DeviceSpectialOffer.OfferDecreseValue).ToString), F1, Brushes.SteelBlue, New Point(Me.Width - 84, 32))
                                End Using

                            End If

                            If Device.DeviceOptions.ShowPassedTime Then

                                gfx.DrawImage(My.Resources.time_clock_history_recent_16, New Point(Me.Width - 28, Me.Height - 24))
                                '  gfx.DrawString(MainDv.GetActiveDuration, New Font("Segoe UI", 10), Brushes.DimGray, New Point(Me.Width - 135, Me.Height - 25))

                                Using F1 As New Font("justagain_din", 12, FontStyle.Regular)
                                    If Me.Width >= 230 Then
                                        gfx.DrawString(MainDv.GetActiveDuration, F1, B2, New Point(Me.Width - gfx.MeasureString(MainDv.GetActiveDuration, F1).Width - My.Resources.time_clock_history_recent_16.Width - 10, Me.Height - 25))
                                    Else
                                        gfx.DrawString(MainDv.GetActiveDuration(True), F1, B2, New Point(Me.Width - gfx.MeasureString(MainDv.GetActiveDuration(True), F1).Width - My.Resources.time_clock_history_recent_16.Width - 10, Me.Height - 25))
                                    End If

                                End Using

                            End If


                            gfx.DrawImage(My.Resources.UntitledWhite, New Point(Me.Width - 30, Me.Height - 50))
                            ' gfx.DrawString(CStr(MainDv.Bill), Me.Font, Brushes.Gray, New Point(Me.Width - 65, Me.Height - 50))


                            Using F1 As New Font("justagain_din", 12, FontStyle.Regular)

                                Dim total As Double = (Device.TotalBill)

                                If Not MainDv.PlayStationOverTimeBill = 0 Then
                                    If CStr(MainDv.PlayStationOverTimeBill).Length > 5 Then
                                        gfx.DrawString("+" & CStr(CInt(MainDv.PlayStationOverTimeBill)), F1, Brushes.LimeGreen, New Point(TimeRect.Width - 2, Me.Height - 45))
                                    Else
                                        gfx.DrawString("+" & CStr((MainDv.PlayStationOverTimeBill)), F1, Brushes.LimeGreen, New Point(TimeRect.Width - 2, Me.Height - 45))
                                    End If
                                End If

                                '  If CStr(total).Length > 5 Then
                                gfx.DrawString(CStr(CInt(total)), F1, B2, New Point(Me.Width - gfx.MeasureString(CInt(total).ToString, F1).Width - My.Resources.UntitledWhite.Width - 35, Me.Height - 50))
                                'Else
                                '    gfx.DrawString(CStr((total)), F1, B2, New Point(Me.Width - gfx.MeasureString(total.ToString, F1).Width - My.Resources.UntitledWhite.Width - 35, Me.Height - 50))
                                'End If

                            End Using
                            'If Device.SpeciesCount > 0 Then
                            '    DrawTag("Orders:" & CStr(Device.SpeciesCount), gfx, New Rectangle(4, Me.Height - 65, 80, 15), Color.Green, Color.Black, Color.White)

                            'End If




                        End If
                    Else
                        gfx.DrawImage(My.Resources.tick_yes_approve_accept_green_64, CInt((Me.Width) / 3), CInt((Me.Height) / 4))
                    End If
                Else
                    gfx.DrawImage(My.Resources.power_64, CInt((Me.Width) / 2), CInt((Me.Height) / 4))
                End If

                '// Draw bottom border if Normal state (not hovered)
                If bMouse = MouseCapture.Outside Then
                    rect = New Rectangle(rect.Left, Me.Height - 1, rect.Width, 1)
                    ' b = New LinearGradientBrush(rect, Color.Transparent, Color.Transparent, LinearGradientMode.ForwardDiagonal)
                    blend = New ColorBlend
                    blend.Colors = New Color() {Color.FromArgb(43, 60, 89), Color.FromArgb(43, 60, 89), Color.FromArgb(43, 60, 89)}
                    blend.Positions = New Single() {0.0F, 0.5F, 1.0F}
                    b.InterpolationColors = blend

                    gfx.FillRectangle(b, rect)
                End If
                '  gfx.Dispose()
            End Using
            'Catch ex As Exception
            '    LOG.[LOG](ex) '  MsgBox("Paint " + ex.StackTrace)
            'End Try
        End Using

    End Sub

    Private Sub PaintEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        ' gfxStart = e.Graphics
        '
        ' On Error Resume Next
        ' Using e.Graphics
        Paint_DrawBackground(e.Graphics)
        ' End Using



    End Sub

    Dim bba As Color

    Public Sub DrawTag(ByVal Text As String, ByVal G As Graphics, ByVal Rec As Rectangle, ByVal BackGround As Color, ByVal border As Color, ByVal textcolor As Color)

        G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        G.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit



        Using B1 As New SolidBrush(BackGround), P1 As New Pen(border), B2 As New SolidBrush(textcolor)
            Dim x As Font = New Font("justagain_din", 10, FontStyle.Regular)
            Rec.Width = G.MeasureString(Text, x).Width

            G.FillRectangle(B1, Rec)
            DrawRoundRect(G, Rec, 3, P1)
            ' New Rectangle(4, Me.Height - 25, 80, 15)

            Using F1 As New Font("justagain_din", 10, FontStyle.Regular)
                G.DrawString(Text, F1, B2, Rec.Location)
            End Using
        End Using
    End Sub



#End Region


    Private LastActiveStatus As Device.DeviceStatus = Device.DeviceStatus.Empty
    Dim OLDData As Double = 0
    Dim OverTimeLast As Integer = Date.Now.Minute

    Dim ScheduleNextNotActive As Boolean = False
    Dim ScheduleNextActive As Integer = False
    Dim Nextsch As ScheduleObject = Nothing
    Public Sub RaisScheduleEvent(ByVal sch As ScheduleObject)

        Try


            If Device.Statue = EVO.Device.DeviceStatus.IsActive Then
                ''ScheduleObject=active - Device = active
                If (sch.IsActive = True And sch.IsWarning = False And sch.ISEnded = False) Then
                    ''DeviceHaveSchedule

                    Device.isNEXTSheduleding = False
                    If Not Device.NextSchedule Is Nothing Then

                        If sch.ID = Device.NextSchedule.ID Then
                            ' Device Have Same Schedule
                            'do nothing 
                            Exit Sub
                        Else
                            ' Device Have Defferent Schedule
                            ' close device + start new schedule + replace shedule
                            Me.Device.NextSchedule = sch
                            AddHandler Me.commandButton1.Executed, AddressOf ReActiveWithSchedule
                            Me.commandButton1.Text = "<font size=""+4"">Start Shedule Reservation</font><br/>Current Sesstion Will be Closed."
                            AddHandler Me.commandButton2.Executed, AddressOf DeleteNewSchedule
                            Me.commandButton2.Text = "<font size=""+4"">Delete Shedule Reservation</font><br/>."
                            GetReponse("Device Shedule Reservation", "[Device] : " + sch.ObjectName + " Has Started", "Startdate : " + sch.StartDate.ToString + vbNewLine + "Owner : " + sch.Client.ToString + vbNewLine + "Paid : " + sch.Paid.ToString + vbNewLine + "Would You Like To Start Scheudle and Close Current Sesstion Or Delete Scheudle")

                        End If
                    Else
                        'close device + start new schedule
                        'delete new schedule
                        Device.NextSchedule = sch
                        AddHandler Me.commandButton1.Executed, AddressOf ReActiveWithSchedule
                        Me.commandButton1.Text = "<font size=""+4"">Start Shedule Reservation</font><br/>Current Sesstion Will be Closed."
                        AddHandler Me.commandButton2.Executed, AddressOf DeleteNewSchedule
                        Me.commandButton2.Text = "<font size=""+4"">Delete Shedule Reservation</font><br/>."

                        GetReponse("Device Shedule Reservation", "[Device] : " + sch.ObjectName + " Has Started", "Startdate : " + sch.StartDate.ToString + vbNewLine + "Owner : " + sch.Client.ToString + vbNewLine + "Paid : " + sch.Paid.ToString + vbNewLine + "Would You Like To Start Scheudle and Close Current Sesstion Or Delete Scheudle")

                    End If


                ElseIf (sch.IsActive = False And sch.IsWarning = True And sch.ISEnded = False) Then
                    ' MsgBox("IsWarning")
                    If Not Device.Scheduled Then
                        Device.NextSchedule = sch
                    End If
                    Device.isNEXTSheduleding = True
                    frmMain.ADDSTATUS("[Schedule] DEVICE : " + Device.Name + " Has Schedule For: '" + sch.Client + "' On " + sch.StartDate.ToString)

                End If
            Else

                If (sch.IsActive = False And sch.IsWarning = True And sch.ISEnded = False) Then
                    ' MsgBox("IsWarning")
                    Device.NextSchedule = sch
                    Device.isNEXTSheduleding = True
                    frmMain.ADDSTATUS("[Schedule] DEVICE : " + Device.Name + " Has Schedule For: '" + sch.Client + "' On " + sch.StartDate.ToString)

                ElseIf (sch.IsActive = True And sch.IsWarning = False And sch.ISEnded = False) Then

                    Device.isNEXTSheduleding = False

                    ' Device Have Defferent Schedule
                    ' close device + start new schedule + replace shedule
                    Me.Device.NextSchedule = sch
                    AddHandler Me.commandButton1.Executed, AddressOf ActiveWithSchedule
                    Me.commandButton1.Text = "<font size=""+4"">Start Shedule Reservation</font><br/> Sesstion Will be StartedWith Shedule."
                    AddHandler Me.commandButton2.Executed, AddressOf DeleteNewSchedule
                    Me.commandButton2.Text = "<font size=""+4"">Delete Shedule Reservation</font><br/>."
                    GetReponse("Device Shedule Reservation", "[Device] : " + sch.ObjectName + " Has Started", "Startdate : " + sch.StartDate.ToString + vbNewLine + "Owner : " + sch.Client.ToString + vbNewLine + "Paid : " + sch.Paid.ToString + vbNewLine + "Would You Like To Start Scheudle Or Delete Scheudle")
                End If
            End If
            'If sch.StartDate >= Device.StartDate Then


            'End If

            ' MsgBox(sch.ToString)

        Catch ex As Exception
            LOG.[LOG](ex) ' MsgBox("RaisScheduleEvent " + ex.StackTrace)
        End Try
    End Sub
    Public Sub ReActiveWithSchedule()
        On Error Resume Next

        If Me.Device.Statue = EVO.Device.DeviceStatus.IsActive Then
            Me.Device.CloseSesstion(, , , True)
            'Me.Device.CheckActive()
            ''Application.DoEvents()
            'Me.Device.NextSchedule = Nextsch
            'Me.Device.StartSesstionWithSechudle()
            'MsgBox(Me.Device.PaidBill.ToString)

        End If
        TaskDialog.Close(eTaskDialogResult.Custom1)
    End Sub
    Public Sub StartSesstionPop()
        On Error Resume Next

        Dim sch As ScheduleObject = Device.CheckSchedules
        Nextsch = sch
        Me.Device.NextSchedule = sch
        AddHandler Me.commandButton1.Executed, AddressOf ActiveWithSchedule
        Me.commandButton1.Text = "<font size=""+4"">Start Shedule Reservation</font><br/>Current Sesstion Will be started ."
        AddHandler Me.commandButton2.Executed, AddressOf DeleteNewSchedule
        Me.commandButton2.Text = "<font size=""+4"">Delete Shedule Reservation</font><br/>."
        GetReponse("Device Shedule Reservation", "[Device] : " + sch.ObjectName + " Has Schudle On " + sch.StartDate.ToString, "Startdate : " + sch.StartDate.ToString + vbNewLine + "Owner : " + sch.Client.ToString + vbNewLine + "Paid : " + sch.Paid.ToString + vbNewLine + "Would You Like To Start Or Delete Scheudle")

    End Sub

    Public Sub ActiveWithSchedule()
        On Error Resume Next

        If Me.Device.Statue = EVO.Device.DeviceStatus.Empty Then
            'Me.Device.CloseSesstion()
            frmMain.ADDSTATUS("الحجز للجهاز : " + Device.Name + " بدأ")


            Me.Device.StartSesstionWithSechudle(True)

        End If
        TaskDialog.Close(eTaskDialogResult.Custom1)
    End Sub
    Public Sub DeleteNewSchedule()

        On Error Resume Next

        Me.Device.NextSchedule.DeleteSchedule()
        Me.Device.NextSchedule = Nothing
        Me.Device.isSheduled = False
        Me.Device.isNEXTSheduleding = False

        TaskDialog.Close(eTaskDialogResult.Custom1)
    End Sub
    Public Responed As Boolean = False
    Dim infoX As TaskDialogInfo = Nothing
    Public Function GetReponse(ByVal title, ByVal header, ByVal text) As Boolean
        On Error Resume Next
        '  TaskDialog.Close(eTaskDialogResult.Custom1)
        '  If Not Responed Then
        infoX = CreateTaskDialogInfo(title, header, text)

        Dim result As eTaskDialogResult = TaskDialog.Show(infoX)
        'Log("{0} Task-dialog closed with result: {1}", Date.Now, result)

        '  End If

    End Function
    Private Function CreateTaskDialogInfo(ByVal title, ByVal header, ByVal text) As TaskDialogInfo

        Dim info As New TaskDialogInfo(title, eTaskDialogIcon.Information, header, text, GetTaskDialogButtons(), eTaskDialogBackgroundColor.Blue, Nothing, GetCommandButtons(), GetCheckBoxCommand(), "", Nothing)
        Return info
    End Function
    Private Function GetCheckBoxCommand() As Command

        ' Return commandCheckBox

        Return Nothing
    End Function
    Private Function GetCommandButtons() As Command()

        Return New Command() {commandButton1, commandButton2}

        Return Nothing
    End Function
    Private Function GetTaskDialogButtons() As eTaskDialogButton
        Dim button As eTaskDialogButton = eTaskDialogButton.Cancel

        'hen
        '    button = button Or eTaskDialogButton.Yes
        'End If

        'If button <> eTaskDialogButton.Ok Then
        '    button = button And Not (button And eTaskDialogButton.Ok)
        'End If

        Return button
    End Function
    Public Event SheduleOnse()

    Public Sub UpdateActive()
        ' On Error Resume Next


        '  UpdateRefresh()
        '   On Error Resume Next
        Try


            'MainDv.InitializeData
            '    If MainDv.DeviceOptions.AutoUpdate Then


            If Not CStr(OLDData) = CStr(Date.Now.Minute) Then

                'MsgBox("hi minuetes")
                If MainDv.IsPlayStationDevice Then
                    '  MsgBox("awdawdwad")

                    OLDData = Date.Now.Minute

                    MainDv.CheckActive()
                    Device.IntializeTotalBill(True)

                    Device.UpdateSchedules()


                    MainDv.RaiseOverTimeEvent()

                    Dim ObjShch As ScheduleObject = Device.CheckSchedules()
                    If Not ObjShch Is Nothing Then

                        RaisScheduleEvent(ObjShch)

                    End If

                End If
                Me.Refresh()
                Device.UpdateBill()
            End If
            '  Me.SuperTooltip1.DefaultTooltipSettings.BodyText = 

            If Me.MainDv.Statue = Device.DeviceStatus.IsActive Then


                Me.Panel1.BackColor = Color.LimeGreen
                'If MainDv.IsPlayStationDevice Then

                '    '''''''''''''ShowToolTip
                '    If MainDv.DeviceOptions.ShowToolTip Then
                '        Dim MainInfo As String = ""
                '        If Device.ISTimeLimit Then
                '            If Device.IsOver Then
                '                Dim OverTimeStr As String = String.Format("{0}H : {1}M", CStr(Device.OverTime.Hours), CStr(Device.OverTime.Minutes))
                '                Dim MainInfoTimeOver As String = String.Format(My.Resources.OverTimeHTML, OverTimeStr, CStr(Device.PlayStationOverTimeBill), CStr(Device.Bill + Device.PlayStationOverTimeBill + Device.PlayStationOverTimeBill))
                '                Dim TimeLimitStr As String = String.Format("{0}H : {1}M", CStr(Device.TimeLimit.Hours), CStr(Device.TimeLimit.Minutes))
                '                '  Dim RestTimeStr As String = String.Format("{0}H : {1}M", CStr(Device.RestTime.Hours), CStr(Device.RestTime.Minutes))

                '                MainInfo = String.Format(My.Resources.HTMLDeviceInfo, Me.Device.Type.Name, Me.Device.StartDate.ToString, Me.Device.GetActiveDuration, CStr(Device.PlayStationBill), CStr(Device.Bill), CStr(Device.Bill + Device.PlayStationBill), CStr(Device.TimeType.MiuntesPrice), CStr(MainInfoTimeOver), TimeLimitStr, "'OverTimeLimits'")
                '            Else
                '                Dim TimeLimitStr As String = String.Format("{0}H : {1}M", CStr(Device.TimeLimit.Hours), CStr(Device.TimeLimit.Minutes))
                '                Dim RestTimeStr As String = String.Format("{0}H : {1}M", CStr(Device.RestTime.Hours), CStr(Device.RestTime.Minutes))

                '                MainInfo = String.Format(My.Resources.HTMLDeviceInfo, Me.Device.Type.Name, Me.Device.StartDate.ToString, Me.Device.GetActiveDuration, CStr(Device.PlayStationBill), CStr(Device.Bill), CStr(Device.Bill + Device.PlayStationBill), CStr((Device.TimeType.MiuntesPrice)), " ", TimeLimitStr, RestTimeStr)
                '            End If
                '        Else
                '            MainInfo = String.Format(My.Resources.HTMLDeviceInfo, Me.Device.Type.Name, Me.Device.StartDate.ToString, Me.Device.GetActiveDuration, CStr(Device.PlayStationBill), CStr(Device.Bill), CStr(Device.Bill + Device.PlayStationBill), CStr(Device.TimeType.MiuntesPrice), "", "Open", "Unkowen")
                '        End If


                '        SuperTooltip1.SetSuperTooltip(Me, _
                '             New DevComponents.DotNetBar.SuperTooltipInfo("<b><font color=""#000000"">Device</font></b> : <font color=""#8C8C8C"">" + Me.Device.Name + "</font>", "", _
                '             MainInfo, _
                '             My.Resources.desktop_monitor_screen_64, Nothing, DevComponents.DotNetBar.eTooltipColor.System, True, False, New Size(430, 320)))
                '    End If



                'End If

                '''''''''''''ContextMenu


                UpdateOffer()

            Else

                Me.Panel1.BackColor = Color.Red
                ' SuperTooltip1.Enabled = False
            End If
            '   End If


        Catch ex As Exception
            LOG.[LOG](ex) '   MsgBox("UpdateActive : " & ex.StackTrace)
        End Try

    End Sub
    Public Sub UpdateContextMenu()
        'On Error Resume Next
        Try
            ' TypesCOnt.SubItems.Clear()
            If Device.Statue = EVO.Device.DeviceStatus.IsActive Then
                Device.IntializeTotalBill(True)
                '  Device.RemoveTotalBillIntialized()
                'If Device.HasSpectialOffer Then
                '    Device.UpdateOfferDecreseValue()

                'End If


                If Device.IsOver Then
                    CheckBoxItem2.Enabled = True
                    LabelItem5.Text = CInt(Me.Device.PlayStationOverTimeBill).ToString
                    If Device.DeviceOptions.AddOverTimeCash Then

                        ItemContainer12.Enabled = True

                    Else

                        ItemContainer12.Enabled = False

                    End If
                Else
                    CheckBoxItem2.Enabled = False
                    ItemContainer12.Enabled = False
                    LabelItem5.Text = "0"
                End If

                If Device.DeviceOptions.AddOrderCash Then

                    ItemContainer13.Enabled = True
                    LabelItem3.Text = CInt(Me.Device.Bill).ToString
                Else

                    ItemContainer13.Enabled = False
                    LabelItem3.Text = CInt(Me.Device.Bill).ToString
                End If

                If Device.IsPlayStationDevice Then
                    CheckBoxItem1.Enabled = True
                    If Device.DeviceOptions.AddPlayCash Then

                        ItemContainer5.Enabled = True
                        DeviceContextBill.Text = CInt(Me.Device.PlayStationBill).ToString
                    Else
                        DeviceContextBill.Text = CInt(Me.Device.PlayStationBill).ToString
                        ItemContainer5.Enabled = False

                    End If

                    UpdateContextController()

                Else
                    ItemContainer5.Enabled = False
                    CheckBoxItem1.Enabled = False
                    DeviceContextBill.Text = "0"
                End If

                If Device.IsChangedDevice Then
                    CheckBoxItem4.Enabled = True
                    ItemContainer15.Enabled = False
                    If Device.DeviceOptions.AddChangedDevicesCash Then

                        ItemContainer15.Enabled = True
                        LabelItem12.Text = CInt(Device.OldChangedDevicesPlayBill).ToString
                    Else

                        ItemContainer15.Enabled = False
                        LabelItem12.Text = CInt(Device.OldChangedDevicesPlayBill).ToString
                    End If
                Else
                    CheckBoxItem4.Enabled = False
                    ItemContainer15.Enabled = False
                End If

                'Dim restbillX As Integer = 0
                'If Not Device.PaidBill = 0 Then

                '    restbillX = CInt(CDbl(Device.TotalBill - Device.PaidBill))
                'End If
                If Device.HasSpectialOffer Then
                    ' Device.UpdateOfferDecreseValue()
                    LabelItem7.Text = String.Format("NEW - <font color=""#22B14C""><b> {0}</b></font><br/>ORG [<font color=""#BA1419""><b>{1}</b></font>]<br/>", CInt(Device.TotalBill).ToString, CInt(Device.TotalBill + Device.DeviceSpectialOffer.OfferDecreseValue).ToString)

                    LabelItem16.Text = String.Format("By {0} %| -{1}", CInt(Device.DeviceSpectialOffer.value).ToString, CInt(Device.DeviceSpectialOffer.OfferDecreseValue).ToString)

                    'If (CBool(Usr.CanSetOffers)) Then
                    '    TextBoxItem1.Enabled = True
                    '    TextBoxItem1.Text = Device.DeviceSpectialOffer.value
                    'Else
                    '    TextBoxItem1.Enabled = False
                    'End If

                Else

                    LabelItem7.Text = String.Format("NEW - <font color=""#22B14C""><b> {0}</b></font><br/>Reset  [<font color=""#22B14C""><b>{1}</b></font>]", CInt(Device.TotalBill).ToString, "")
                    LabelItem16.Text = "0"
                End If
                '  DeviceContextBill.Text = CInt(Me.Device.PlayStationBill).ToString
                'Dim restbillX As Integer = 0
                'If Not Device.PaidBill = 0 Then

                '    restbillX = CInt(Device.TotalBill - Device.PaidBill)
                'End If



                If Device.AdditinalBill > 0 Then
                    ItemContainer16.Enabled = True
                    LabelItem14.Text = CInt(Device.AdditinalBill).ToString
                    '
                    ButtonItem5.Enabled = True
                    'SuperTooltip1.SetSuperTooltip(LabelItem14, _
                    '            New DevComponents.DotNetBar.SuperTooltipInfo("<b><font color=""#000000"">Device</font></b> : <font color=""#8C8C8C"">" + Me.Device.Name + "</font>", "", _
                    '            Device.AdditinalBillInfo.ToString, _
                    '            Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.System))

                Else
                    ButtonItem5.Enabled = False
                    LabelItem14.Text = CInt(Device.AdditinalBill).ToString
                    ItemContainer16.Enabled = False
                End If


                If Me.Device.ISTimeLimit Then
                    ItemContainer18.Enabled = True
                    CheckBoxItem5.Checked = Device.DeviceOptions.WarnMeLast10Minutes
                    TextBoxItem2.Enabled = Device.DeviceOptions.WarnMeLast10Minutes
                    CheckBoxItem6.Checked = Device.DeviceOptions.WarnMeWithSound
                    CheckBoxItem7.Checked = Device.DeviceOptions.WarnMeWithNotifications
                    If Device.DeviceOptions.WarnMeLast10Minutes Then
                        TextBoxItem2.Text = Device.DeviceOptions.WarnMeCustom

                    End If
                Else
                    TextBoxItem2.Enabled = False
                    ItemContainer18.Enabled = False
                End If

                LabelItem22.Text = Device.PaidBill


   

                For Each dev As Device.DeviceType In Device.DeviceType.GetDeviceTypes
                    '  MsgBox(dev.Name)
                    If Not dev.Id = 0 Then

                        Dim tim As New Time(dev.Id, "")
                        Dim combo As New ButtonItem(dev.Name, dev.Name + " - " + tim.Price.ToString)
                        combo.Tag = dev
                        combo.Checked = False
                        combo.OptionGroup = "Types"
                        If dev.Id = Device.Type.Id Then
                            combo.Checked = True
                        End If
                        AddHandler combo.Click, AddressOf TypeChanged
                        TypesCOnt.SubItems.Add(combo)

                    End If
                Next

                TypesCOnt.UpdateBindings()

                TypesCOnt.Refresh()


                ItemContainer1.UpdateBindings()
                ItemContainer1.Refresh()
                Me.Refresh()


            Else
                ItemContainer11.Enabled = False
                CheckBoxItem4.Enabled = False
                ItemContainer15.Enabled = False
                ItemContainer5.Enabled = False
                CheckBoxItem1.Enabled = False
                DeviceContextBill.Text = "0"
                ItemContainer13.Enabled = False
                CheckBoxItem2.Enabled = False
                ItemContainer12.Enabled = False
                ItemContainer9.Enabled = False
                LabelItem5.Text = "0"
                LabelItem7.Text = "0"
                LabelItem12.Text = "0"
                CheckBoxItem3.Enabled = False
                ItemContainer16.Enabled = False
                ItemContainer17.Enabled = False
                ItemContainer7.Enabled = False
                ItemContainer18.Enabled = False
            End If

        Catch ex As Exception
            LOG.[LOG](ex)
        End Try
    End Sub
    Public Sub TypeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '   On Error Resume Next

        Dim but As ButtonItem = DirectCast(sender, ButtonItem)
        Me.Device.Type = DirectCast(but.Tag, Device.DeviceType)
        but.Checked = True

        Me.Device.UpdateDevice()

        Device.InitializeData()
        Me.Refresh()
        ' _Main.PlayStationControlPanelTab.SystemPanel1.DeviceControlPanel1.Device_Handler.LoadDevices()
    End Sub
    Public Sub UpdateContextController()
        On Error Resume Next

        ' Dim ControllersString As String = "<b><b><font color=""#0F243E"">{0} </font></b>_____________________________________</b>"
        Me.LabelItem10.Text = String.Format("{0}", "عدد الادرعه (" + CStr(Device.ControllersCount) + ")")
        Me.LabelItem10.Refresh()
        '  Me.ButtonItem9.UpdateBindings()

    End Sub
    Private Sub ButtonItem1_PopupFinalized(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItem1.PopupFinalized
        On Error Resume Next
        ' 
        Me.Device.DeviceOptions.SaveUpdateOptions()

    End Sub
    Private Sub ButtonItem1_PopupShowing(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItem1.PopupShowing
        CheckBoxItem2.Checked = Device.DeviceOptions.AddOverTimeCash
        CheckBoxItem3.Checked = Device.DeviceOptions.AddOrderCash
        CheckBoxItem1.Checked = Device.DeviceOptions.AddPlayCash
        CheckBoxItem4.Checked = Me.Device.DeviceOptions.AddChangedDevicesCash
        UpdateContextMenu()
    End Sub

    Private Sub CheckBoxItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxItem1.Click
        Try

            Me.Device.DeviceOptions.AddPlayCash = CheckBoxItem1.Checked

            Me.Device.DeviceOptions.SaveUpdateOptions()


            Me.Device.loadCalculateMethods()

            DeviceContextBill.Text = CInt(Me.Device.PlayStationBill).ToString

            UpdateContextMenu()


        Catch ex As Exception
            LOG.[LOG](ex) ' MsgBox(ex.StackTrace)
        End Try
    End Sub

    Private Sub CheckBoxItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxItem2.Click
        On Error Resume Next

        Me.Device.DeviceOptions.AddOverTimeCash = CheckBoxItem2.Checked
        Me.Device.DeviceOptions.SaveUpdateOptions()


        Me.Device.loadCalculateMethods()

        LabelItem7.Text = CInt(Me.Device.TotalBill).ToString
        UpdateContextMenu()

    End Sub

    Private Sub CheckBoxItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxItem3.Click
        On Error Resume Next

        Me.Device.DeviceOptions.AddOrderCash = CheckBoxItem3.Checked
        Me.Device.DeviceOptions.SaveUpdateOptions()


        Me.Device.loadCalculateMethods()
        LabelItem3.Text = CInt(Me.Device.Bill).ToString
        'LabelItem7.Text = CInt(Me.Device.DeviceTotalBill).ToString
        UpdateContextMenu()
    End Sub

    Private Sub CheckBoxItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxItem4.Click
        On Error Resume Next

        Me.Device.DeviceOptions.AddChangedDevicesCash = CheckBoxItem4.Checked
        Me.Device.DeviceOptions.SaveUpdateOptions()
        '   MsgBox(Me.Device.DeviceOptions.AddChangedDevicesCash)

        Me.Device.loadCalculateMethods()
        LabelItem12.Text = CInt(Device.OldChangedDevicesPlayBill).ToString
        'LabelItem7.Text = CInt(Me.Device.DeviceTotalBill).ToString
        UpdateContextMenu()
    End Sub



    Private Sub TextBoxItem1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxItem1.KeyPress
        On Error Resume Next
        '   If CBool(Usr.CanSetOffers) Then


        If (e.KeyChar = CChar(ChrW(Keys.Enter))) Then
            Device.SetOffer(CInt(TextBoxItem1.Text))
            Me.Refresh()
            ButtonItem11.Enabled = True
            Device.UpdateOfferDecreseValue()
            UpdateContextMenu()

            UpdateOffer()
        End If

        '   End If
    End Sub
    Public Sub UpdateOffer()
        On Error Resume Next

        If Device.HasSpectialOffer Then


            LabelItem16.Text = String.Format("By {0} %| -{1}", CInt(Device.DeviceSpectialOffer.value).ToString, CInt(Device.DeviceSpectialOffer.OfferDecreseValue).ToString)
            LabelItem7.Text = String.Format("NEW - <font color=""#22B14C""><b> {0}</b></font><br/>ORG [<font color=""#BA1419""><b>{1}</b></font>]<br/>", CInt(Device.TotalBill).ToString, CInt(Device.TotalBill + Device.DeviceSpectialOffer.OfferDecreseValue).ToString)
        End If
    End Sub
    Private Sub ButtonItem11_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem11.Click
        On Error Resume Next
        If CBool(Usr.CanSetOffers) Then


            Device.SetOffer(CInt(0))
            Me.Refresh()
            ButtonItem11.Enabled = False

            UpdateContextMenu()
        End If
    End Sub


    Private Sub TextBoxItem1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxItem1.TextChanged
        On Error Resume Next
        If Not TextBoxItem1.Text = "" Then
            Device.SetOffer(CInt(TextBoxItem1.Text))
            Me.Refresh()
            ButtonItem11.Enabled = True
            Device.UpdateOfferDecreseValue()
            UpdateContextMenu()

            UpdateOffer()
        Else

            Device.SetOffer(0)
            Me.Refresh()
            ButtonItem11.Enabled = False
            Device.UpdateOfferDecreseValue()
            UpdateContextMenu()

            UpdateOffer()

        End If

    End Sub

    Private Sub ButtonItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem6.Click
        On Error Resume Next
        '   MsgBox(Device.ControllersCount)
        Device.AddController()
        UpdateContextController()
        Me.Refresh()
    End Sub

    Private Sub ButtonItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem7.Click
        On Error Resume Next

        Device.RemoveController()
        UpdateContextController()
        Me.Refresh()
    End Sub

    Private Sub ButtonItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next

        Dim bf As New BinaryFormatter()
        Dim ms As New MemoryStream()
        Dim Array As Byte()
        bf.Serialize(ms, Me.Device)
        Array = ms.ToArray()
        MsgBox(Array.Length)
    End Sub

    Private Sub ButtonItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem4.Click
        On Error Resume Next
        ButtonItem1.ClosePopup()
        Dim pop As New InputPopupNote("")



        If pop.ShowDialog() = DialogResult.OK Then
            Device.AddAdditionalBill(CDbl(pop.retResult), CStr(pop.retResult2))
            UpdateContextMenu()
            Me.Refresh()
            pop.Dispose()
        End If



    End Sub

    Private Sub ButtonItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem5.Click
        On Error Resume Next
        Device.AddAdditionalBill(0, "none")
        UpdateContextMenu()
        Me.Refresh()
    End Sub

    Private Sub TextBoxItem2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxItem2.TextChanged
        On Error Resume Next
        ' MsgBox(Device.DeviceOptions.WarnMeLast10Minutes)
        If Device.DeviceOptions.WarnMeLast10Minutes Then

            Device.DeviceOptions.WarnMeCustom = CInt(TextBoxItem2.Text)
            Device.DeviceOptions.SaveUpdateOptions()

        End If


    End Sub

    Private Sub CheckBoxItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxItem5.Click
        ' MsgBox(Device.DeviceOptions.WarnMeLast10Minutes)
        On Error Resume Next

        Device.DeviceOptions.WarnMeLast10Minutes = CheckBoxItem5.Checked
        TextBoxItem2.Enabled = CheckBoxItem5.Checked
        ' ItemContainer19.Enabled = CheckBoxItem5.Checked
        Device.DeviceOptions.SaveUpdateOptions()
    End Sub

    Private Sub CheckBoxItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxItem6.Click
        On Error Resume Next
        Device.DeviceOptions.WarnMeWithSound = CheckBoxItem6.Checked
        Device.DeviceOptions.SaveUpdateOptions()
    End Sub

    Private Sub CheckBoxItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxItem7.Click
        Device.DeviceOptions.WarnMeWithNotifications = CheckBoxItem7.Checked
        Device.DeviceOptions.SaveUpdateOptions()
    End Sub

    Private Sub commandButton1_Executed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles commandButton1.Executed

    End Sub

    Private Sub DeviceControl1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ContextMenuBar1_PopupOpen(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.PopupOpenEventArgs) Handles ContextMenuBar1.PopupOpen
        On Error Resume Next


    End Sub

    Private Sub ContextMenuBar1_PopupShowing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenuBar1.PopupShowing
        'On Error Resume Next
        ' ''  MsgBox(CBool(Usr.CanSetOffers))
        'ButtonItem11.Enabled = CBool(Usr.CanSetOffers)
        'TextBoxItem1.Enabled = CBool(Usr.CanSetOffers)
    End Sub
End Class
