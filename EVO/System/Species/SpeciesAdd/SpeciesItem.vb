Imports System.Drawing.Drawing2D

Public Class SpeciesItem
    Public Event SelectionChanged(ByVal sender As SpeciesItem)
    Dim NearSF As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near}
    Friend WithEvents tmrMouseLeave As New System.Windows.Forms.Timer With {.Interval = 10}
    Dim family As Font = New Font("Segoe UI", 13)
    Private MousePoint As Point
    Private MainSpecies As species
    Public Sub New(ByVal Dv As species)

        InitializeComponent()
        Control.CheckForIllegalCrossThreadCalls = False
        Me.DoubleBuffered = True
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Dim textSize As Size = TextRenderer.MeasureText(Dv.Name, family)

        If textSize.Width < 80 Then
            Me.Width = 80
        Else

            Me.Width = textSize.Width + 5
        End If


        Me.Dock = DockStyle.Fill
     
        Me.MainSpecies = Dv
    End Sub

#Region "Properties"
    ReadOnly Property Specie As species
        Get
            Return Me.MainSpecies
        End Get
    End Property

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

    Private Sub ListControlItem_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        'If Selected = False Then

        '  End If
    End Sub

    Private Sub metroRadioGroup_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown ', rdButton.MouseDown
        bState = ButtonState.ButtonDown
        RaiseEvent SelectionChanged(Me)
        Selected = True
        Refresh()

    End Sub

    Private Sub metroRadioGroup_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        bMouse = MouseCapture.Inside
        tmrMouseLeave.Start()
        Refresh()
    End Sub

    'Private Sub DeviceControl1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove

    'End Sub

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
    Private Sub Paint_DrawBackground(ByVal gfx As Graphics)
        '
        On Error Resume Next
        gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
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









        '   DrawTag(Specie.Name, gfx, New Rectangle(10, 10, 20, 20), Color.PaleVioletRed, Color.Gray, Color.White)



        ' Draw
        Dim b As LinearGradientBrush = New LinearGradientBrush(rect, Color.FromArgb(43, 60, 89), Color.FromArgb(43, 60, 89), LinearGradientMode.ForwardDiagonal)
        Dim blend As ColorBlend = New ColorBlend
        blend.Colors = ColorScheme
        blend.Positions = New Single() {0.0F, 0.1, 0.9F, 0.95F, 1.0F}
        b.InterpolationColors = blend
        gfx.FillPath(b, p)

        '// Draw border
        gfx.DrawPath(New Pen(brdr), p)
        '1; 83


        Dim pricetextsize As SizeF = gfx.MeasureString(Specie.Price, Me.Font)
        If (bMouse = MouseCapture.Inside OrElse Selected) Then
            gfx.DrawString(Specie.Name, family, Brushes.DimGray, New Point(4, 4))
        Else
            gfx.DrawString(Specie.Name, family, Brushes.White, New Point(4, 4))
        End If

        DrawTag(Specie.Price, gfx, New Rectangle(Me.Width - pricetextsize.Width - My.Resources.UntitledWhite.Width - 2, 33, pricetextsize.Width + 3 + My.Resources.UntitledWhite.Width, pricetextsize.Height + 5), Color.Gray, Color.Gray, Color.Gold)
        gfx.FillRectangle(Brushes.Gray, Me.Width - My.Resources.UntitledWhite.Width, 35, 16, 16)
        gfx.DrawImage(My.Resources.UntitledGray, Me.Width - My.Resources.UntitledWhite.Width, 35, 16, 16)










        If bMouse = MouseCapture.Outside Then
            rect = New Rectangle(rect.Left, Me.Height - 1, rect.Width, 1)
            b = New LinearGradientBrush(rect, Color.FromArgb(43, 60, 89), Color.FromArgb(43, 60, 89), LinearGradientMode.BackwardDiagonal)
            blend = New ColorBlend
            blend.Colors = New Color() {Color.FromArgb(43, 60, 89), Color.FromArgb(43, 60, 89), Color.FromArgb(43, 60, 89)}
            blend.Positions = New Single() {0.0F, 0.5F, 1.0F}
            b.InterpolationColors = blend
            '
            gfx.FillRectangle(b, rect)
        End If

    End Sub
    Public Sub DrawTag(ByVal Text As String, ByVal G As Graphics, ByVal Rec As Rectangle, ByVal BackGround As Color, ByVal border As Color, ByVal textcolor As Color)

        G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        G.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit



        Using B1 As New SolidBrush(BackGround), P1 As New Pen(border), B2 As New SolidBrush(textcolor)
            G.FillRectangle(B1, Rec)
            DrawRoundRect(G, Rec, 3, P1)
            ' New Rectangle(4, Me.Height - 25, 80, 15)

            Using F1 As New Font("Segoe UI", 8, FontStyle.Bold)
                G.DrawString(Text, F1, B2, Rec.Location)
            End Using
        End Using
    End Sub
    Private Sub PaintEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim gfx = e.Graphics
        '
        Paint_DrawBackground(gfx)


    End Sub

    Private Sub SpeciesItem_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Enter

    End Sub
End Class
