' Aether Theme made by AeroRev9
' 07/10/2015.

Module Helpers227

    Public Enum MouseState As Byte
        None = 0
        Over = 1
        Down = 2
    End Enum

    Public Function FullRectangle_aeth(ByVal S As Size, ByVal Subtract As Boolean) As Rectangle
        If Subtract Then
            Return New Rectangle(0, 0, S.Width - 1, S.Height - 1)
        Else
            Return New Rectangle(0, 0, S.Width, S.Height)
        End If
    End Function

    Public Function GreyColor(ByVal G As UInteger) As Color
        Return Color.FromArgb(G, G, G)
    End Function

    Public Sub CenterStringaeth(ByVal G As Graphics, ByVal T As String, ByVal F As Font, ByVal C As Color, ByVal R As Rectangle)
        Dim TS As SizeF = G.MeasureString(T, F)

        Using B As New SolidBrush(C)
            G.DrawString(T, F, B, New Point(R.Width / 2 - (TS.Width / 2), R.Height / 2 - (TS.Height / 2)))
        End Using

    End Sub

    Public Sub FillRoundRect_aeth(ByVal G As Graphics, ByVal R As Rectangle, ByVal Curve As Integer, ByVal B As Brush)
        G.FillPie(B, R.X, R.Y, Curve, Curve, 180, 90)
        G.FillPie(B, R.X + R.Width - Curve, R.Y, Curve, Curve, 270, 90)
        G.FillPie(B, R.X, R.Y + R.Height - Curve, Curve, Curve, 90, 90)
        G.FillPie(B, R.X + R.Width - Curve, R.Y + R.Height - Curve, Curve, Curve, 0, 90)
        G.FillRectangle(B, CInt(R.X + Curve / 2), R.Y, R.Width - Curve, CInt(Curve / 2))
        G.FillRectangle(B, R.X, CInt(R.Y + Curve / 2), R.Width, R.Height - Curve)
        G.FillRectangle(B, CInt(R.X + Curve / 2), CInt(R.Y + R.Height - Curve / 2), R.Width - Curve, CInt(Curve / 2))
    End Sub

    Public Sub DrawRoundRect(ByVal G As Graphics, ByVal R As Rectangle, ByVal Curve As Integer, ByVal PP As Pen)
        G.DrawArc(PP, R.X, R.Y, Curve, Curve, 180, 90)
        G.DrawLine(PP, CInt(R.X + Curve / 2), R.Y, CInt(R.X + R.Width - Curve / 2), R.Y)
        G.DrawArc(PP, R.X + R.Width - Curve, R.Y, Curve, Curve, 270, 90)
        G.DrawLine(PP, R.X, CInt(R.Y + Curve / 2), R.X, CInt(R.Y + R.Height - Curve / 2))
        G.DrawLine(PP, CInt(R.X + R.Width), CInt(R.Y + Curve / 2), CInt(R.X + R.Width), CInt(R.Y + R.Height - Curve / 2))
        G.DrawLine(PP, CInt(R.X + Curve / 2), CInt(R.Y + R.Height), CInt(R.X + R.Width - Curve / 2), CInt(R.Y + R.Height))
        G.DrawArc(PP, R.X, R.Y + R.Height - Curve, Curve, Curve, 90, 90)
        G.DrawArc(PP, R.X + R.Width - Curve, R.Y + R.Height - Curve, Curve, Curve, 0, 90)
    End Sub

    Public Enum Direction As Byte
        Up = 0
        Down = 1
        Left = 2
        Right = 3
    End Enum

    Public Sub DrawTriangle(ByVal G As Graphics, ByVal Rect As Rectangle, ByVal D As Direction, ByVal C As Color)
        Dim halfWidth As Integer = Rect.Width / 2
        Dim halfHeight As Integer = Rect.Height / 2
        Dim p0 As Point = Point.Empty
        Dim p1 As Point = Point.Empty
        Dim p2 As Point = Point.Empty

        Select Case D
            Case Direction.Up
                p0 = New Point(Rect.Left + halfWidth, Rect.Top)
                p1 = New Point(Rect.Left, Rect.Bottom)
                p2 = New Point(Rect.Right, Rect.Bottom)

            Case Direction.Down
                p0 = New Point(Rect.Left + halfWidth, Rect.Bottom)
                p1 = New Point(Rect.Left, Rect.Top)
                p2 = New Point(Rect.Right, Rect.Top)

            Case Direction.Left
                p0 = New Point(Rect.Left, Rect.Top + halfHeight)
                p1 = New Point(Rect.Right, Rect.Top)
                p2 = New Point(Rect.Right, Rect.Bottom)

            Case Direction.Right
                p0 = New Point(Rect.Right, Rect.Top + halfHeight)
                p1 = New Point(Rect.Left, Rect.Bottom)
                p2 = New Point(Rect.Left, Rect.Top)

        End Select

        Using B As New SolidBrush(C)
            G.FillPolygon(B, New Point() {p0, p1, p2})
        End Using

    End Sub

    Public Function ColorFromHex_aeth(ByVal Hex As String) As Color
        Dim R, G, B As String
        Hex = Replace(Hex, "#", "")
        R = Val("&H" & Mid(Hex, 1, 2))
        G = Val("&H" & Mid(Hex, 3, 2))
        B = Val("&H" & Mid(Hex, 5, 2))
        Return Color.FromArgb(R, G, B)
    End Function

End Module

Public Class AetherTabControl
    Inherits TabControl

    Private G As Graphics
    Private Rect As Rectangle
    Private MS1 As SizeF
    Private MS2 As SizeF

    Public Property UpperText As Boolean = True

    Sub New()
        DoubleBuffered = True
        Alignment = TabAlignment.Left
        SizeMode = TabSizeMode.Fixed
        ItemSize = New Size(40, 190)
        Dock = DockStyle.Fill
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        SetStyle(ControlStyles.UserPaint, True)
    End Sub

    Protected Overrides Sub OnControlAdded(ByVal e As ControlEventArgs)
        MyBase.OnControlAdded(e)
        e.Control.BackColor = Color.White
        e.Control.ForeColor = ColorFromHex("#343843")

        Using F1 As New Font("Segoe UI", 9)
            e.Control.Font = F1
        End Using

    End Sub

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000
            Return cp
        End Get
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        G = e.Graphics
        G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        G.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        MyBase.OnPaint(e)

        G.Clear(ColorFromHex("#343843"))

        For I As Integer = 0 To TabPages.Count - 1

            Rect = GetTabRect(I)

            If SelectedIndex = I Then

                Using B1 As New SolidBrush(ColorFromHex("#3A3E49"))
                    G.FillRectangle(B1, New Rectangle(Rect.X - 4, Rect.Y + 1, Rect.Width + 6, Rect.Height))
                End Using

            End If

            Using B1 As New SolidBrush(ColorFromHex("#737A8A"))

                If UpperText Then

                    Using F1 As New Font("Segoe UI", 7.75, FontStyle.Bold)
                        G.DrawString(TabPages(I).Text.ToUpper, F1, B1, New Point(Rect.X + 50, Rect.Y + 13))
                    End Using

                Else

                    Using F1 As New Font("Segoe UI semibold", 9)
                        G.DrawString(TabPages(I).Text, F1, B1, New Point(Rect.X + 50, Rect.Y + 11))
                    End Using

                End If

            End Using

            If Not String.IsNullOrEmpty(TabPages(I).Tag) Then

                If UpperText Then

                    Using F1 As New Font("Segoe UI", 7.75, FontStyle.Bold)
                        MS1 = G.MeasureString(TabPages(I).Text, F1)
                    End Using

                Else

                    Using F1 As New Font("Segoe UI semibold", 9)
                        MS1 = G.MeasureString(TabPages(I).Text, F1)
                    End Using

                End If

                Using F1 As New Font("Segoe UI", 9)
                    MS2 = G.MeasureString(TabPages(I).Tag, F1)
                End Using

                Using B1 As New SolidBrush(ColorFromHex("#424452")), P1 As New Pen(ColorFromHex("#323541")), B2 As New SolidBrush(ColorFromHex("#737A8A"))
                    G.FillRectangle(B1, New Rectangle(Rect.X + MS1.Width + 72, Rect.Y + 13, MS2.Width + 5, 15))
                    DrawRoundRect(G, New Rectangle(Rect.X + MS1.Width + 72, Rect.Y + 13, MS2.Width + 5, 15), 3, P1)

                    If IsNumeric(TabPages(I).Tag) Then

                        Using F1 As New Font("Segoe UI", 8, FontStyle.Bold)
                            G.DrawString(TabPages(I).Tag, F1, B2, New Point(Rect.X + MS1.Width + 75, Rect.Y + 14))
                        End Using

                    Else

                        Using F1 As New Font("Segoe UI", 7, FontStyle.Bold)
                            G.DrawString(TabPages(I).Tag.ToString.ToUpper, F1, B2, New Point(Rect.X + MS1.Width + 75, Rect.Y + 14))
                        End Using

                    End If

                End Using

            End If

            If Not I = 0 Then

                Using P1 As New Pen(ColorFromHex("#3B3D49")), P2 As New Pen(ColorFromHex("#2F323C"))
                    G.DrawLine(P1, New Point(Rect.X - 4, Rect.Y + 1), New Point(Rect.Width + 4, Rect.Y + 1))
                    G.DrawLine(P2, New Point(Rect.X - 4, Rect.Y + 2), New Point(Rect.Width + 4, Rect.Y + 2))
                End Using

            End If

            If Not IsNothing(ImageList) Then
                If Not TabPages(I).ImageIndex < 0 Then
                    G.DrawImage(ImageList.Images(TabPages(I).ImageIndex), New Rectangle(Rect.X + 18, Rect.Y + ((Rect.Height / 2) - 8), 16, 16))
                End If
            End If

        Next

    End Sub

End Class

Public Class AetherCircular
    Inherits Control

    Private G As Graphics
    Private ProgressAngle As Single
    Private RemainderAngle As Single
    Private ExceedingLimits As Boolean
    Private ExceedingSign As String

    Private _Progress As Single
    Private _Max As Single = 100
    Private _Min As Single = 0

    Public Property Percent As Boolean = True


    Public Property Progress As Single
        Get
            Return _Progress
        End Get
        Set(ByVal value As Single)
            Select Case value
                Case Is > Max
                    value = Max
                    ExceedingSign = "+"
                    ExceedingLimits = True
                    Invalidate()

                Case Is < Min
                    value = Min
                    ExceedingSign = "-"
                    ExceedingLimits = True
                    Invalidate()
            End Select
            _Progress = value
            Invalidate()
        End Set
    End Property

    Public Property Max As Single
        Get
            Return _Max
        End Get
        Set(ByVal value As Single)
            Select Case value
                Case Is < _Progress
                    _Progress = value
            End Select
            _Max = value
            Invalidate()
        End Set
    End Property

    Public Property Min As Single
        Get
            Return _Min
        End Get
        Set(ByVal value As Single)
            Select Case value
                Case Is > _Progress
                    _Progress = value
            End Select
            _Min = value
            Invalidate()
        End Set
    End Property

    Public Property Border As Color = Color.LightGray
    Public Property HatchPrimary As Color = Color.Green
    Public Property HatchSecondary As Color = Color.Red

    Sub New()
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        G = e.Graphics
        G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        G.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        MyBase.OnPaint(e)

        ProgressAngle = 360 / Max * Progress
        RemainderAngle = 360 - ProgressAngle

        Using P1 As New Pen(New Drawing2D.HatchBrush(Drawing2D.HatchStyle.LightUpwardDiagonal, HatchPrimary, HatchSecondary), 4), P2 As New Pen(Border, 4)
            G.DrawArc(P1, New Rectangle(2, 2, Width - 5, Height - 5), -90, ProgressAngle)
            G.DrawArc(P2, New Rectangle(2, 2, Width - 5, Height - 5), ProgressAngle - 90, RemainderAngle)
        End Using

        If Percent Then

            Using F1 As New Font("Segoe UI", 9, FontStyle.Bold)

                If ExceedingLimits Then
                    CenterString(G, Progress & "%" & ExceedingSign, F1, Color.FromArgb(100, 100, 100), New Rectangle(1, 1, Width, Height + 1))
                Else
                    CenterString(G, Progress & "%", F1, Color.FromArgb(100, 100, 100), New Rectangle(1, 1, Width, Height + 1))
                End If

            End Using

        Else

            If ExceedingLimits Then
                CenterString(G, Progress & ExceedingSign, New Font("Segoe UI", 9, FontStyle.Bold), Color.FromArgb(100, 100, 100), New Rectangle(1, 1, Width, Height + 1))
            Else
                CenterString(G, Progress, New Font("Segoe UI", 9, FontStyle.Bold), Color.FromArgb(100, 100, 100), New Rectangle(1, 1, Width, Height + 1))
            End If

        End If

        ExceedingLimits = False

        CenterString(G, Text.ToUpper, New Font("Segoe UI", 6, FontStyle.Bold), Color.FromArgb(170, 170, 170), New Rectangle(2, 2, Width, Height + 27))

    End Sub

End Class

Public Class AetherCheckBox
    Inherits Control

    Public Event CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)

    Private _Checked As Boolean
    Private _EnabledCalc As Boolean
    Private G As Graphics

    Private State As MouseState

    Public Property Checked As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            Invalidate()
        End Set
    End Property

    Public Shadows Property Enabled As Boolean
        Get
            Return EnabledCalc
        End Get
        Set(ByVal value As Boolean)
            _EnabledCalc = value

            If Enabled Then
                Cursor = Cursors.Hand
            Else
                Cursor = Cursors.Default
            End If

            Invalidate()
        End Set
    End Property

    Public Property EnabledCalc As Boolean
        Get
            Return _EnabledCalc
        End Get
        Set(ByVal value As Boolean)
            Enabled = value
            Invalidate()
        End Set
    End Property

    Sub New()
        DoubleBuffered = True
        Enabled = True
        Cursor = Cursors.Hand
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        G = e.Graphics
        G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        G.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        MyBase.OnPaint(e)

        If Enabled Then

            Using P1 As New Pen(ColorFromHex("#D2D2D2")), B1 As New SolidBrush(ColorFromHex("#343843")), F1 As New Font("Segoe UI", 9)
                DrawRoundRect(G, New Rectangle(0, 0, 18, 18), 6, P1)
                G.DrawString(Text, F1, B1, New Point(25, 1))
            End Using

            If State = MouseState.Over Or State = MouseState.Down Then

                Using P1 As New Pen(ColorFromHex("#8C92A1"))
                    DrawRoundRect(G, New Rectangle(0, 0, 18, 18), 6, P1)
                End Using

            End If

        Else

            Using P1 As New Pen(ColorFromHex("#DCDCDC")), B1 As New SolidBrush(ColorFromHex("#989CA7")), F1 As New Font("Segoe UI", 9)
                DrawRoundRect(G, New Rectangle(0, 0, 18, 18), 6, P1)
                G.DrawString(Text, F1, B1, New Point(25, 1))
            End Using

        End If

        If Checked Then

            If Enabled Then

                Using B1 As New Drawing2D.HatchBrush(Drawing2D.HatchStyle.WideUpwardDiagonal, ColorFromHex("#5B606F"), ColorFromHex("#525766")), P1 As New Pen(ColorFromHex("#474C5A"))
                    G.FillRectangle(B1, New Rectangle(4, 4, 10, 10))
                    DrawRoundRect(G, New Rectangle(4, 4, 10, 10), 3, P1)
                End Using

            Else

                Using B1 As New Drawing2D.HatchBrush(Drawing2D.HatchStyle.WideUpwardDiagonal, ColorFromHex("#8C92A1"), ColorFromHex("#7A7F8E")), P1 As New Pen(ColorFromHex("#797E8C"))
                    G.FillRectangle(B1, New Rectangle(4, 4, 10, 10))
                    DrawRoundRect(G, New Rectangle(4, 4, 10, 10), 3, P1)
                End Using

            End If


        End If

    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(Width, 19)
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)

        If Enabled Then
            State = MouseState.Over
            Checked = Not Checked
            RaiseEvent CheckedChanged(Me, e)
            Invalidate()
        End If

    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If Enabled Then
            State = MouseState.Down : Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        If Enabled Then
            State = MouseState.Over : Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        If Enabled Then
            State = MouseState.None : Invalidate()
        End If
    End Sub

End Class
Public Class AetherRadioButton
    Inherits Control

    Public Event CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)

    Private G As Graphics
    Private State As MouseState

    Private _Checked As Boolean
    Private _EnabledCalc As Boolean

    Sub New()
        DoubleBuffered = True
        Enabled = True
        Cursor = Cursors.Hand
    End Sub

    Public Property Checked As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            Invalidate()
        End Set
    End Property

    Public Shadows Property Enabled As Boolean
        Get
            Return EnabledCalc
        End Get
        Set(ByVal value As Boolean)
            _EnabledCalc = value

            If Enabled Then
                Cursor = Cursors.Hand
            Else
                Cursor = Cursors.Default
            End If

            Invalidate()
        End Set
    End Property

    Public Property EnabledCalc As Boolean
        Get
            Return _EnabledCalc
        End Get
        Set(ByVal value As Boolean)
            Enabled = value
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        G = e.Graphics
        G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        G.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        MyBase.OnPaint(e)

        If Enabled Then

            Using P As New Pen(ColorFromHex("#C8C8C8"))
                G.DrawEllipse(P, New Rectangle(0, 0, 18, 18))
            End Using

            Using B As New SolidBrush(ColorFromHex("#343843"))
                G.DrawString(Text, New Font("Segoe UI", 9), B, New Point(25, 1))
            End Using

            If State = MouseState.Over Or State = MouseState.Down Then

                Using P1 As New Pen(ColorFromHex("#8C92A1"))
                    G.DrawEllipse(P1, New Rectangle(0, 0, 18, 18))
                End Using

            End If

        Else

            Using P As New Pen(ColorFromHex("#DCDCDC"))
                G.DrawEllipse(P, New Rectangle(0, 0, 18, 18))
            End Using

            Using B As New SolidBrush(ColorFromHex("#989CA7"))
                G.DrawString(Text, New Font("Segoe UI", 9), B, New Point(25, 1))
            End Using

        End If

        If Checked Then

            If Enabled Then

                Using B1 As New Drawing2D.HatchBrush(Drawing2D.HatchStyle.WideUpwardDiagonal, ColorFromHex("#5B606F"), ColorFromHex("#525766")), P1 As New Pen(ColorFromHex("#474C5A"))
                    G.FillEllipse(B1, New Rectangle(4, 4, 10, 10))
                    G.DrawEllipse(P1, New Rectangle(4, 4, 10, 10))
                End Using

            Else

                Using B1 As New Drawing2D.HatchBrush(Drawing2D.HatchStyle.WideUpwardDiagonal, ColorFromHex("#8C92A1"), ColorFromHex("#7A7F8E")), P1 As New Pen(ColorFromHex("#797E8C"))
                    G.FillEllipse(B1, New Rectangle(4, 4, 10, 10))
                    G.DrawEllipse(P1, New Rectangle(4, 4, 10, 10))
                End Using

            End If

        End If

    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(Width, 19)
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)

        If Enabled Then

            For Each C As Control In Parent.Controls
                If TypeOf C Is AetherRadioButton Then
                    DirectCast(C, AetherRadioButton).Checked = False
                End If
            Next

            Checked = Not Checked
            RaiseEvent CheckedChanged(Me, e)
            State = MouseState.Over : Invalidate()

        End If

    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If Enabled Then
            State = MouseState.Down : Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        If Enabled Then
            State = MouseState.Over : Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        If Enabled Then
            State = MouseState.None : Invalidate()
        End If
    End Sub

End Class

Public Class AetherGroupBox
    Inherits ContainerControl

    Private G As Graphics

    Public Property Footer As Boolean
    Public Property FooterText As String

    Sub New()
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        G = e.Graphics
        G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        G.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        MyBase.OnPaint(e)

        G.Clear(Color.White)

        Using P1 As New Pen(ColorFromHex("#F1F5FC")), B1 As New SolidBrush(ColorFromHex("#343843")), F1 As New Font("Segoe UI", 9)
            DrawRoundRect(G, FullRectangle(Size, True), 6, P1)
            G.DrawString(Text, F1, B1, New Point(12, 10))
            G.DrawLine(P1, New Point(0, 36), New Point(Width, 36))
        End Using

        If Footer Then

            Using P1 As New Pen(ColorFromHex("#F5F5F5")), B1 As New SolidBrush(ColorFromHex("#7A7E89")), F1 As New Font("Segoe UI", 9)
                G.DrawLine(P1, New Point(0, Height - 35), New Point(Width, Height - 35))
                G.DrawString(FooterText, F1, B1, New Point(12, Height - 27))
            End Using

        End If

    End Sub

End Class

Public Class AetherButton
    Inherits Control

    Private G As Graphics
    Private State As MouseState

    Private _EnabledCalc As Boolean

    Public Shadows Event Click(ByVal sender As Object, ByVal e As EventArgs)

    Sub New()
        DoubleBuffered = True
        Enabled = True
    End Sub

    Public Shadows Property Enabled As Boolean
        Get
            Return EnabledCalc
        End Get
        Set(ByVal value As Boolean)
            _EnabledCalc = value
            Invalidate()
        End Set
    End Property

    Public Property EnabledCalc As Boolean
        Get
            Return _EnabledCalc
        End Get
        Set(ByVal value As Boolean)
            Enabled = value
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        G = e.Graphics
        G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        G.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        MyBase.OnPaint(e)

        If Enabled Then

            Select Case State

                Case MouseState.Over

                    Using B1 As New SolidBrush(ColorFromHex("#FDFDFD"))
                        FillRoundRect_aeth(G, New Rectangle(0, 0, Width - 1, Height - 1), 3, B1)
                    End Using

                Case MouseState.Down

                    Using B1 As New SolidBrush(ColorFromHex("#F0F0F0"))
                        FillRoundRect_aeth(G, New Rectangle(0, 0, Width - 1, Height - 1), 3, B1)
                    End Using

                Case Else

                    Using B1 As New SolidBrush(ColorFromHex("#F6F6F6"))
                        FillRoundRect_aeth(G, New Rectangle(0, 0, Width - 1, Height - 1), 3, B1)
                    End Using

            End Select

            Using F1 As New Font("Segoe UI", 9), P1 As New Pen(ColorFromHex("#C3C3C3"))
                DrawRoundRect(G, New Rectangle(0, 0, Width - 1, Height - 1), 3, P1)
                CenterString(G, Text, F1, ColorFromHex("#343843"), FullRectangle(Size, False))
            End Using


        Else

            Using B1 As New SolidBrush(ColorFromHex("#F2F2F2")), P1 As New Pen(ColorFromHex("#DCDCDC")), F1 As New Font("Segoe UI", 9)
                FillRoundRect_aeth(G, New Rectangle(0, 0, Width - 1, Height - 1), 6, B1)
                DrawRoundRect(G, New Rectangle(0, 0, Width - 1, Height - 1), 6, P1)
                CenterString(G, Text, F1, ColorFromHex("#989CA7"), FullRectangle(Size, False))
            End Using

        End If

    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)

        If Enabled Then
            RaiseEvent Click(Me, e)
        End If

        State = MouseState.Over : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub

End Class

Public Class AetherTag
    Inherits Control

    Private G As Graphics

    Public Property Background As Color = ColorFromHex("#424452")
    Public Property Border As Color = ColorFromHex("#323541")
    Public Property TextColor As Color = ColorFromHex("#7C8290")

    Sub New()
        DoubleBuffered = True
        Text = "Tag"
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        G = e.Graphics
        G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        G.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        MyBase.OnPaint(e)

        Using B1 As New SolidBrush(Background), P1 As New Pen(Border), B2 As New SolidBrush(TextColor)
            G.FillRectangle(B1, FullRectangle(Size, True))
            DrawRoundRect(G, FullRectangle(Size, True), 3, P1)

            If IsNumeric(Text) Then

                Using F1 As New Font("Segoe UI", 8, FontStyle.Bold)
                    G.DrawString(Text, F1, B2, New Point(2, 0))
                End Using

            Else

                Using F1 As New Font("Segoe UI", 7, FontStyle.Bold)
                    G.DrawString(Text.ToUpper, F1, B2, New Point(2, 1))
                End Using

            End If

        End Using

    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(Width, 15)
    End Sub

End Class

Public Class AetherTextbox
    Inherits Control

    Private WithEvents TB As New TextBox
    Private G As Graphics
    Private State As MouseState
    Private IsDown As Boolean

    Private _EnabledCalc As Boolean
    Private _allowpassword As Boolean = False
    Private _maxChars As Integer = 32767
    Private _textAlignment As HorizontalAlignment
    Private _multiLine As Boolean = False
    Private _readOnly As Boolean = False

    Public Shadows Property Enabled As Boolean
        Get
            Return EnabledCalc
        End Get
        Set(ByVal value As Boolean)
            TB.Enabled = value
            _EnabledCalc = value
            Invalidate()
        End Set
    End Property

    Public Property EnabledCalc As Boolean
        Get
            Return _EnabledCalc
        End Get
        Set(ByVal value As Boolean)
            Enabled = value
            Invalidate()
        End Set
    End Property

    Public Shadows Property UseSystemPasswordChar() As Boolean
        Get
            Return _allowpassword
        End Get
        Set(ByVal value As Boolean)
            TB.UseSystemPasswordChar = UseSystemPasswordChar
            _allowpassword = value
            Invalidate()
        End Set
    End Property

    Public Shadows Property MaxLength() As Integer
        Get
            Return _maxChars
        End Get
        Set(ByVal value As Integer)
            _maxChars = value
            TB.MaxLength = MaxLength
            Invalidate()
        End Set
    End Property

    Public Shadows Property TextAlign() As HorizontalAlignment
        Get
            Return _textAlignment
        End Get
        Set(ByVal value As HorizontalAlignment)
            _textAlignment = value
            Invalidate()
        End Set
    End Property

    Public Shadows Property MultiLine() As Boolean
        Get
            Return _multiLine
        End Get
        Set(ByVal value As Boolean)
            _multiLine = value
            TB.Multiline = value
            OnResize(EventArgs.Empty)
            Invalidate()
        End Set
    End Property

    Public Shadows Property [ReadOnly]() As Boolean
        Get
            Return _readOnly
        End Get
        Set(ByVal value As Boolean)
            _readOnly = value
            If TB IsNot Nothing Then
                TB.ReadOnly = value
            End If
        End Set
    End Property

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub

    Protected Overrides Sub OnBackColorChanged(ByVal e As EventArgs)
        MyBase.OnBackColorChanged(e)
        Invalidate()
    End Sub

    Protected Overrides Sub OnForeColorChanged(ByVal e As EventArgs)
        MyBase.OnForeColorChanged(e)
        TB.ForeColor = ForeColor
        Invalidate()
    End Sub

    Protected Overrides Sub OnFontChanged(ByVal e As EventArgs)
        MyBase.OnFontChanged(e)
        TB.Font = Font
    End Sub

    Protected Overrides Sub OnGotFocus(ByVal e As EventArgs)
        MyBase.OnGotFocus(e)
        TB.Focus()
    End Sub

    Private Sub TextChangeTb() Handles TB.TextChanged
        Text = TB.Text
    End Sub

    Private Sub TextChng() Handles MyBase.TextChanged
        TB.Text = Text
    End Sub

    Public Sub NewTextBox()
        With TB
            .Text = String.Empty
            .BackColor = Color.White
            .ForeColor = ColorFromHex("#343843")
            .TextAlign = HorizontalAlignment.Left
            .BorderStyle = BorderStyle.None
            .Location = New Point(3, 3)
            .Font = New Font("Segoe UI", 9)
            .Size = New Size(Width - 3, Height - 3)
            .UseSystemPasswordChar = UseSystemPasswordChar
        End With
    End Sub

    Sub New()
        MyBase.New()
        NewTextBox()
        Controls.Add(TB)
        SetStyle(ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        TextAlign = HorizontalAlignment.Left
        ForeColor = ColorFromHex("#343843")
        Font = New Font("Segoe UI", 9)
        Size = New Size(130, 29)
        Enabled = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        G = e.Graphics
        G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        G.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        MyBase.OnPaint(e)

        G.Clear(Color.White)

        If Enabled Then

            TB.ForeColor = ColorFromHex("#343843")

            If State = MouseState.Down Then

                Using P As New Pen(ColorFromHex("#5B606F"))
                    DrawRoundRect(G, FullRectangle(Size, True), 3, P)
                End Using

            Else

                Using P As New Pen(ColorFromHex("#C8C8C8"))
                    DrawRoundRect(G, FullRectangle(Size, True), 3, P)
                End Using

            End If

        Else

            TB.ForeColor = ColorFromHex("#DCDCDC")

            Using P As New Pen(ColorFromHex("#E6E6E6"))
                DrawRoundRect(G, FullRectangle(Size, True), 3, P)
            End Using

        End If

        TB.TextAlign = TextAlign
        TB.UseSystemPasswordChar = UseSystemPasswordChar

    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        If Not MultiLine Then
            Dim tbheight As Integer = TB.Height
            TB.Location = New Point(10, CType(((Height / 2) - (tbheight / 2) - 0), Integer))
            TB.Size = New Size(Width - 20, tbheight)
        Else
            TB.Location = New Point(10, 10)
            TB.Size = New Size(Width - 20, Height - 20)
        End If
    End Sub

    Protected Overrides Sub OnEnter(ByVal e As EventArgs)
        MyBase.OnEnter(e)
        State = MouseState.Down : Invalidate()
    End Sub

    Protected Overrides Sub OnLeave(ByVal e As EventArgs)
        MyBase.OnLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

End Class