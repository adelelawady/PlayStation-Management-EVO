Imports System.Drawing.Drawing2D

Public Class InfoPanel
    Friend WithEvents tmrMouseLeave As New System.Windows.Forms.Timer With {.Interval = 10}
    Dim family As FontFamily = New FontFamily("Segoe UI")
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub
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
    'Private mSelected As Boolean
    'Public Property Selected() As Boolean
    '    Get
    '        Return mSelected
    '    End Get
    '    Set(ByVal value As Boolean)
    '        mSelected = value
    '        Refresh()
    '    End Set
    'End Property
    Private Sub ListControlItem_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        'If Selected = False Then

        '  End If
    End Sub

    Private Sub metroRadioGroup_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown ', rdButton.MouseDown


        bState = ButtonState.ButtonDown
        ' Selected = True
        Refresh()
    End Sub

    Private Sub metroRadioGroup_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        bMouse = MouseCapture.Inside
        tmrMouseLeave.Start()
        Refresh()
    End Sub

    Private Sub DeviceControl1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove

    End Sub

    Private Sub metroRadioGroup_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp ', rdButton.MouseUp
        bState = ButtonState.ButtonUp
        Refresh()
    End Sub

    Private Sub tmrMouseLeave_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMouseLeave.Tick
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
        Try


            Dim rect As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)

            '/// Build a rounded rectangle

            Dim p As New GraphicsPath
            Const Roundness = 1
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


            ' Draw
            Dim b As LinearGradientBrush = New LinearGradientBrush(rect, Color.White, Color.Black, LinearGradientMode.Vertical)
            Dim blend As ColorBlend = New ColorBlend
            blend.Colors = ColorScheme
            blend.Positions = New Single() {0.0F, 0.1, 0.9F, 0.95F, 1.0F}
            b.InterpolationColors = blend
            gfx.FillPath(b, p)

            '// Draw border
            gfx.DrawPath(New Pen(brdr), p)



            '// Draw bottom border if Normal state (not hovered)
            If bMouse = MouseCapture.Outside Then
                rect = New Rectangle(rect.Left, Me.Height - 1, rect.Width, 1)
                b = New LinearGradientBrush(rect, Color.Blue, Color.Yellow, LinearGradientMode.Horizontal)
                blend = New ColorBlend
                blend.Colors = New Color() {Color.White, Color.LightGray, Color.White}
                blend.Positions = New Single() {0.0F, 0.5F, 1.0F}
                b.InterpolationColors = blend
                '
                gfx.FillRectangle(b, rect)
            End If
        Catch ex As Exception
            Me.Refresh()
        End Try
    End Sub
    Dim gfxStart As Graphics

    Private Sub PaintEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        gfxStart = e.Graphics
        '
        Paint_DrawBackground(e.Graphics)


    End Sub
#End Region
End Class
