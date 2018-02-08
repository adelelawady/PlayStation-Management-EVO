Imports System.Drawing.Drawing2D

Public Class SpeciesControl
    Friend WithEvents tmrMouseLeave As New System.Windows.Forms.Timer With {.Interval = 10}
    Public Event SelectionChanged(ByVal sender As Object)
    Private Sp As species
    Private is_Selected As Boolean = False
    Public Event SPRemoved(ByVal sp As species)
    Public Sub New(ByVal SpID As species)
        Try


            ' This call is required by the designer.
            InitializeComponent()
            Control.CheckForIllegalCrossThreadCalls = False
            Me.DoubleBuffered = True
            SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            ' Add any initialization after the InitializeComponent() call.
            Me.Sp = SpID
            ' Me.Dock = DockStyle.Top
            '  Me.LogInLabel1.Text = Sp.Name
            '   Me.LogInLabel3.Text = Sp.Type.Name
            '  Me.LogInLabel2.Text = Sp.Price
            '  ''   Me.LogInLabel4.Text = Controler.TableLogData.GetDate()
        Catch ex As Exception
            LOG.[LOG](ex) '
            Me.Dispose()
        End Try
    End Sub
    Public Sub Distroy()
        Me.Dispose()

    End Sub
    ReadOnly Property Controlspecies As species

        Get
            Return Me.Sp
        End Get
    End Property








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

    Private Sub SpeciesControl_2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    End Sub

    Private Sub SpeciesControl_2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub ListControlItem_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        If Selected = False Then
            Selected = True
            RaiseEvent SelectionChanged(Me)
        End If
        Dim currPlace As Integer = Me.Width - My.Resources.x_cross_delete_stop_16.Width

        Dim p As New Rectangle(New Point(currPlace - 5, 3), My.Resources.x_cross_delete_stop_16.Size)

        If p.Contains(e.Location) Then
            Delete()
        End If
    End Sub
    Public Sub Delete()
        On Error Resume Next
        RaiseEvent SPRemoved(Me.Sp)
        'Me.Parent.Controls.Remove(Me)
        'Me.Parent.Refresh()
    End Sub
    Private Sub metroRadioGroup_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown ', rdButton.MouseDown
        bState = ButtonState.ButtonDown
        Refresh()
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
        On Error Resume Next

        Dim rect As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)

        '/// Build a rounded rectangle

        Using p As New GraphicsPath


            Const Roundness = 1
            p.StartFigure()


            '  p.AddString("$ 56.3", Me.Font.FontFamily, FontStyle.Bold, 14, New Point(56, 40), NearSF)

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
            Using b As LinearGradientBrush = New LinearGradientBrush(rect, Color.FromArgb(43, 60, 89), Color.FromArgb(43, 60, 89), LinearGradientMode.ForwardDiagonal)


                Dim blend As ColorBlend = New ColorBlend
                blend.Colors = ColorScheme
                blend.Positions = New Single() {0.0F, 0.1, 0.9F, 0.95F, 1.0F}
                b.InterpolationColors = blend
                gfx.FillPath(b, p)

                '// Draw border
                gfx.DrawPath(New Pen(brdr), p)
                '1; 83


                Dim currPlace As Integer = Me.Width - My.Resources.x_cross_delete_stop_16.Width

                If Me.bMouse = MouseCapture.Inside OrElse Selected Then
                    gfx.DrawString(Me.Sp.Name, New Font("Segoe UI", 14), New SolidBrush(Color.Silver), New Point(6, 3))
                    gfx.DrawString(Me.Sp.Name, New Font("Segoe UI", 14), New SolidBrush(Color.DimGray), New Point(5, 2))
                    gfx.DrawString(Me.Sp.Price, New Font("Segoe UI", 10), New SolidBrush(Color.DimGray), New Point(currPlace - 80, 3))
                Else
                    gfx.DrawString(Me.Sp.Name, New Font("Segoe UI", 14), New SolidBrush(Color.Silver), New Point(6, 3))
                    gfx.DrawString(Me.Sp.Name, New Font("Segoe UI", 14), New SolidBrush(Color.White), New Point(5, 2))
                    gfx.DrawString(Me.Sp.Price, New Font("Segoe UI", 10), New SolidBrush(Color.White), New Point(currPlace - 80, 3))
                End If


                gfx.DrawImage(My.Resources.x_cross_delete_stop_16, New Point(currPlace - 5, 4))


                gfx.DrawImage(My.Resources.UntitledWhite, New Point(currPlace - 105, 3))

                If bMouse = MouseCapture.Inside Then

                    '  gfx.DrawString(Me.Sp.Type.Name, New Font("Segoe UI", 10), New SolidBrush(Color.DeepSkyBlue), New Point(currPlace - 105 - My.Resources.UntitledWhite.Width, 3))

                    '    If Not Me.Sp.AddDate = Nothing Then


                    '        gfx.DrawImage(My.Resources.time_clock_history_recent_16, New Point(currPlace - 470, 4))
                    '        gfx.DrawString(GetDuration, New Font("Segoe UI", 10), New SolidBrush(Color.DeepSkyBlue), New Point(currPlace - 450, 3))
                    '    End If
                    '    ' gfx.DrawString("admin", New Font("Segoe UI", 10), New SolidBrush(Color.Red), New Point(currPlace - 520, 3))
                End If


                '// Draw bottom border if Normal state (not hovered)
                If bMouse = MouseCapture.Outside Then
                    rect = New Rectangle(rect.Left, Me.Height - 1, rect.Width, 1)
                    ' b = New LinearGradientBrush(rect, Color.Blue, Color.Yellow, LinearGradientMode.Horizontal)

                    blend = New ColorBlend
                    blend.Colors = New Color() {Color.FromArgb(43, 60, 89), Color.FromArgb(43, 60, 89), Color.FromArgb(43, 60, 89)}
                    blend.Positions = New Single() {0.0F, 0.5F, 1.0F}
                    b.InterpolationColors = blend
                    '
                    gfx.FillRectangle(b, rect)
                End If
            End Using
        End Using
    End Sub
    Public Function GetDuration() As String
        Dim sp As TimeSpan = Date.Now.Subtract(Me.Sp.AddDate)
        Dim sa As String = String.Format("{0} Hour {1} Minute", sp.Hours, sp.Minutes)
        Dim sad As String = String.Format("{0} day {1} hour {2} Minute", sp.Days, sp.Hours, sp.Minutes)
        If sp.Days > 0 Then
            Return sad
        Else
            Return sa
        End If
        '   Return String.Format("{0} Hour {1} Minute", sp.Hours, sp.Minutes)


    End Function
    Private Sub PaintEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim gfx = e.Graphics
        '
        Paint_DrawBackground(gfx)

    End Sub

#End Region

End Class
