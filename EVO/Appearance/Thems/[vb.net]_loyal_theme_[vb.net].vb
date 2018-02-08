Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Text
Imports System.Drawing.Text

''' <summary>
''' Loyal Theme
''' Created by Earn
''' From HackForums.net
''' </summary>
''' <remarks></remarks>

Enum MouseState__2
    None = 0
    Over = 1
    Down = 2
End Enum

Class LoyalTheme
    Inherits ContainerControl

#Region " Back End "

#Region " Enums "

    Enum ControlsAlign
        Left = 0
        Right = 2
    End Enum

    Enum TextAlign
        Left = 0
        Center = 1
        Right = 2
    End Enum

#End Region

#Region " Declarations "
    Private _Down As Boolean = False
    Private _Header As Integer = 47
    Private _MousePoint As Point
    Private _ControlsFormat As New StringFormat With {.LineAlignment = StringAlignment.Center}
#End Region

#Region " Properties "

    Private _HeaderColor As Color = Color.Aqua
    <Category("Header Settings")> _
    Public Property HeaderColor() As Color
        Get
            Return _HeaderColor
        End Get
        Set(ByVal value As Color)
            _HeaderColor = value
            Invalidate()
        End Set
    End Property

    'Alignments
    Private _ControlsAlignment As ControlsAlign = ControlsAlign.Right
    <Category("Header Settings")> _
    Public Property ControlsAlignment() As ControlsAlign
        Get
            Return _ControlsAlignment
        End Get
        Set(ByVal value As ControlsAlign)
            _ControlsAlignment = value
            Invalidate()
        End Set
    End Property

    Private _TextAlignment As TextAlign = TextAlign.Center
    <Category("Header Settings")> _
    Public Property TextAlignment() As TextAlign
        Get
            Return _TextAlignment
        End Get
        Set(ByVal value As TextAlign)
            _TextAlignment = value
            Invalidate()
        End Set
    End Property

    'Header Size
    Private _HeaderSize As Integer = 30
    <Category("Header Settings")> _
    Public Property HeaderSize() As Integer
        Get
            Return _HeaderSize
        End Get
        Set(ByVal value As Integer)
            _HeaderSize = value
            Invalidate()
        End Set
    End Property


    'Show Controls
    Private _ShowClose As Boolean
    <Category("Header Settings")> _
    Public Property ShowClose() As Boolean
        Get
            Return _ShowClose
        End Get
        Set(ByVal value As Boolean)
            _ShowClose = value
            Invalidate()
        End Set
    End Property

    Private _ShowMinimize As Boolean
    <Category("Header Settings")> _
    Public Property ShowMinimize() As Boolean
        Get
            Return _ShowMinimize
        End Get
        Set(ByVal value As Boolean)
            _ShowMinimize = value
            Invalidate()
        End Set
    End Property

    Private _ShowMaximize As Boolean
    <Category("Header Settings")> _
    Public Property ShowMaximize() As Boolean
        Get
            Return _ShowMaximize
        End Get
        Set(ByVal value As Boolean)
            _ShowMaximize = value
            Invalidate()
        End Set
    End Property

#End Region

#Region " Mouse States "

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)

        Select Case ControlsAlignment
            Case ControlsAlign.Right
                '_ShowClose
                If _ShowClose = True Then
                    If New Rectangle(Width - 23, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location) Then
                        Application.Exit()
                    End If
                End If

                '_ShowMinimize
                If _ShowMinimize = True Then
                    If _ShowMaximize = True Then
                        If _ShowClose = True Then

                            If New Rectangle(Width - 58, (((_HeaderSize + 2) - 18) / 2), 17, 18).Contains(e.Location) Then
                                FindForm.WindowState = FormWindowState.Minimized
                                Exit Sub
                            End If

                        Else
                            If New Rectangle(Width - 41, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location) Then
                                FindForm.WindowState = FormWindowState.Minimized
                                Exit Sub
                            End If
                        End If
                    Else
                        If _ShowClose = True Then
                            If New Rectangle(Width - 41, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location) Then
                                FindForm.WindowState = FormWindowState.Minimized
                                Exit Sub
                            End If
                        Else
                            If New Rectangle(Width - 23, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location) Then
                                FindForm.WindowState = FormWindowState.Minimized
                                Exit Sub
                            End If
                        End If
                    End If
                End If

                '_ShowMaximize
                If _ShowMaximize = True Then
                    If _ShowClose = True Then

                        If New Rectangle(Width - 41, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location) Then
                            If FindForm.WindowState = FormWindowState.Maximized Then
                                FindForm.WindowState = FormWindowState.Normal
                                Refresh()
                            ElseIf FindForm.WindowState = FormWindowState.Normal Then
                                FindForm.WindowState = FormWindowState.Maximized
                                Refresh()
                            End If
                            Exit Sub
                        End If

                    Else
                        If New Rectangle(Width - 23, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location) Then
                            If FindForm.WindowState = FormWindowState.Maximized Then
                                FindForm.WindowState = FormWindowState.Normal
                                Refresh()
                            ElseIf FindForm.WindowState = FormWindowState.Normal Then
                                FindForm.WindowState = FormWindowState.Maximized
                                Refresh()
                            End If
                            Exit Sub
                        End If
                    End If
                End If

            Case ControlsAlign.Left
                '_ShowClose
                If _ShowClose = True Then
                    If New Rectangle(4, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location) Then
                        Application.Exit()
                    End If
                End If

                '_ShowMinimize
                If _ShowMinimize = True Then
                    If _ShowMaximize = True Then
                        If _ShowClose = True Then

                            If New Rectangle(40, (((_HeaderSize + 2) - 18) / 2), 17, 18).Contains(e.Location) Then
                                FindForm.WindowState = FormWindowState.Minimized
                                Exit Sub
                            End If

                        Else
                            If New Rectangle(22, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location) Then
                                FindForm.WindowState = FormWindowState.Minimized
                                Exit Sub
                            End If
                        End If
                    Else
                        If _ShowClose = True Then
                            If New Rectangle(22, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location) Then
                                FindForm.WindowState = FormWindowState.Minimized
                                Exit Sub
                            End If
                        Else
                            If New Rectangle(4, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location) Then
                                FindForm.WindowState = FormWindowState.Minimized
                                Exit Sub
                            End If
                        End If
                    End If
                End If

                '_ShowMaximize
                If _ShowMaximize = True Then
                    If _ShowClose = True Then

                        If New Rectangle(22, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location) Then
                            If FindForm.WindowState = FormWindowState.Maximized Then
                                FindForm.WindowState = FormWindowState.Normal
                                Refresh()
                            ElseIf FindForm.WindowState = FormWindowState.Normal Then
                                FindForm.WindowState = FormWindowState.Maximized
                                Refresh()
                            End If
                            Exit Sub
                        End If

                    Else
                        If New Rectangle(4, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location) Then
                            If FindForm.WindowState = FormWindowState.Maximized Then
                                FindForm.WindowState = FormWindowState.Normal
                                Refresh()
                            ElseIf FindForm.WindowState = FormWindowState.Normal Then
                                FindForm.WindowState = FormWindowState.Maximized
                                Refresh()
                            End If
                            Exit Sub
                        End If
                    End If
                End If
        End Select

        If e.Y < _Header AndAlso e.Button = Windows.Forms.MouseButtons.Left Then
            _Down = True
            _MousePoint = New Point(e.Location)
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        _Down = False
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If _Down = True Then
            ParentForm.Location = MousePosition - _MousePoint
        End If
    End Sub

#End Region

#Region " Misc "
    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        Dock = DockStyle.Fill
        ParentForm.TransparencyKey = Color.Fuchsia
        ParentForm.FormBorderStyle = FormBorderStyle.None
        BackColor = Color.FromArgb(31, 31, 31)
        Invalidate()
    End Sub

#End Region

#End Region

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        With G
            Dim _StringF As New StringFormat With {.LineAlignment = StringAlignment.Center}
            .Clear(Color.FromArgb(31, 31, 31))
            .FillRectangle(New SolidBrush(_HeaderColor), New Rectangle(0, 0, Width, 5))
            .FillRectangle(New SolidBrush(Color.FromArgb(34, 34, 34)), New Rectangle(0, 5, Width, _HeaderSize))
            .DrawLine(New Pen(Color.FromArgb(38, 38, 38)), New Point(0, _HeaderSize + 5), New Point(Width, _HeaderSize + 5))
            .DrawLine(New Pen(Color.FromArgb(24, 24, 24)), New Point(0, _HeaderSize + 6), New Point(Width, _HeaderSize + 6))
            .DrawLine(Pens.Fuchsia, New Point(0, 0), New Point(0, 2))
            .DrawLine(Pens.Fuchsia, New Point(0, 0), New Point(2, 0))
            .DrawLine(Pens.Fuchsia, New Point(Width - 1, 0), New Point(Width - 1, 2))
            .DrawLine(Pens.Fuchsia, New Point(Width - 1, 0), New Point(Width - 3, 0))
            If _ControlsAlignment = ControlsAlign.Right Then
                If _ShowClose = True Then
                    .DrawString("r", New Font("Marlett", 11), Brushes.White, New RectangleF(Width - 23, 5, 23, _HeaderSize + 3), _ControlsFormat)
                End If
                If _ShowMinimize = True Then
                    If _ShowMaximize = True Then
                        If _ShowClose = True Then
                            G.DrawString("0", New Font("Marlett", 11), Brushes.White, New RectangleF(Width - 57, 5, 23, _HeaderSize + 3), _ControlsFormat)
                        Else
                            G.DrawString("0", New Font("Marlett", 11), Brushes.White, New RectangleF(Width - 41, 5, 23, _HeaderSize + 3), _ControlsFormat)
                        End If
                    Else
                        If _ShowClose = True Then
                            G.DrawString("0", New Font("Marlett", 11), Brushes.White, New RectangleF(Width - 41, 5, 23, _HeaderSize + 3), _ControlsFormat)
                        Else
                            G.DrawString("0", New Font("Marlett", 11), Brushes.White, New RectangleF(Width - 23, 5, 23, _HeaderSize + 3), _ControlsFormat)
                        End If
                    End If
                End If
                If _ShowMaximize = True Then
                    If _ShowClose = True Then
                        If FindForm.WindowState = FormWindowState.Maximized Then
                            .DrawString("1", New Font("Marlett", 11), Brushes.White, New RectangleF(Width - 41, 5, 23, _HeaderSize + 3), _ControlsFormat)
                        ElseIf FindForm.WindowState = FormWindowState.Normal Then
                            .DrawString("2", New Font("Marlett", 11), Brushes.White, New RectangleF(Width - 41, 5, 23, _HeaderSize + 3), _ControlsFormat)
                        End If
                    Else
                        If FindForm.WindowState = FormWindowState.Maximized Then
                            .DrawString("1", New Font("Marlett", 11), Brushes.White, New RectangleF(Width - 23, 5, 23, _HeaderSize + 3), _ControlsFormat)
                        ElseIf FindForm.WindowState = FormWindowState.Normal Then
                            .DrawString("2", New Font("Marlett", 11), Brushes.White, New RectangleF(Width - 23, 5, 23, _HeaderSize + 3), _ControlsFormat)
                        End If
                    End If
                End If
            End If
            If _ControlsAlignment = ControlsAlign.Left Then
                If _ShowClose = True Then
                    .DrawString("r", New Font("Marlett", 11), Brushes.White, New RectangleF(5, 5, 23, _HeaderSize + 3), _ControlsFormat)
                End If
                If _ShowMinimize = True Then
                    If _ShowMaximize = True Then
                        If _ShowClose = True Then
                            G.DrawString("0", New Font("Marlett", 11), Brushes.White, New RectangleF(41, 5, 23, _HeaderSize + 3), _ControlsFormat)
                        Else
                            G.DrawString("0", New Font("Marlett", 11), Brushes.White, New RectangleF(23, 5, 23, _HeaderSize + 3), _ControlsFormat)
                        End If
                    Else
                        If _ShowClose = True Then
                            G.DrawString("0", New Font("Marlett", 11), Brushes.White, New RectangleF(23, 5, 23, _HeaderSize + 3), _ControlsFormat)
                        Else
                            G.DrawString("0", New Font("Marlett", 11), Brushes.White, New RectangleF(5, 5, 23, _HeaderSize + 3), _ControlsFormat)
                        End If
                    End If
                End If
                If _ShowMaximize = True Then
                    If _ShowClose = True Then
                        If FindForm.WindowState = FormWindowState.Maximized Then
                            .DrawString("1", New Font("Marlett", 11), Brushes.White, New RectangleF(23, 5, 23, _HeaderSize + 3), _ControlsFormat)
                        ElseIf FindForm.WindowState = FormWindowState.Normal Then
                            .DrawString("2", New Font("Marlett", 11), Brushes.White, New RectangleF(23, 5, 23, _HeaderSize + 3), _ControlsFormat)
                        End If
                    Else
                        If FindForm.WindowState = FormWindowState.Maximized Then
                            .DrawString("1", New Font("Marlett", 11), Brushes.White, New RectangleF(5, 5, 23, _HeaderSize + 3), _ControlsFormat)
                        ElseIf FindForm.WindowState = FormWindowState.Normal Then
                            .DrawString("2", New Font("Marlett", 11), Brushes.White, New RectangleF(5, 5, 23, _HeaderSize + 3), _ControlsFormat)
                        End If
                    End If
                End If
            End If
            Select Case _TextAlignment
                Case TextAlign.Center
                    _StringF.Alignment = StringAlignment.Center
                    .DrawString(Text, New Font("Arial", 9), Brushes.White, New RectangleF(0, 5, Width, _HeaderSize), _StringF)

                Case TextAlign.Left
                    .DrawString(Text, New Font("Arial", 9), Brushes.White, New RectangleF(10, 5, Width, _HeaderSize), _StringF)

                Case TextAlign.Right
                    Dim _TextLength As Integer = TextRenderer.MeasureText(Text, New Font("Arial", 9)).Width + 10
                    .DrawString(Text, New Font("Arial", 9), Brushes.White, New RectangleF(Width - _TextLength, 5, Width, _HeaderSize), _StringF)
            End Select
        End With
    End Sub
End Class

Class LoyalButton
    Inherits Control

#Region " Back End "

#Region " Enums "
    Enum Alignment
        Left = 0
        Center = 1
        Right = 2
    End Enum
#End Region

#Region " Declarations "
    Private _State As MouseState = MouseState.None
#End Region

#Region " Mouse States "

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        _State = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        _State = MouseState.None
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        _State = MouseState.Down
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        _State = MouseState.Over
        Invalidate()
    End Sub

#End Region

#Region " Properties "

    Private _TextAlignment As Alignment = Alignment.Center
    <Category("Button Settings")> _
    Public Property TextAlignment() As Alignment
        Get
            Return _TextAlignment
        End Get
        Set(ByVal value As Alignment)
            _TextAlignment = value
            Invalidate()
        End Set
    End Property

    Private _OutlineColor As Color = Color.FromArgb(102, 51, 153)
    <Category("Button Settings")> _
    Public Property OutlineColor() As Color
        Get
            Return _OutlineColor
        End Get
        Set(ByVal value As Color)
            _OutlineColor = value
            Invalidate()
        End Set
    End Property

#End Region

    Sub New()
        Size = New Size(75, 25)
    End Sub
#End Region

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        With G
            .Clear(Color.FromArgb(40, 40, 40))
            Select Case _State
                Case MouseState.None
                    .DrawRectangle(New Pen(Color.FromArgb(24, 24, 24)), New Rectangle(0, 0, Width - 1, Height - 1))
                Case MouseState.Over
                    .DrawRectangle(New Pen(_OutlineColor), New Rectangle(0, 0, Width - 1, Height - 1))

                Case MouseState.Down
                    .FillRectangle(New SolidBrush(Color.FromArgb(30, 30, 30)), New Rectangle(0, 0, Width - 1, Height - 1))
                    .DrawRectangle(New Pen(_OutlineColor), New Rectangle(0, 0, Width - 1, Height - 1))
            End Select
            .DrawRectangle(New Pen(Color.FromArgb(48, 48, 48)), New Rectangle(1, 1, Width - 3, Height - 3))
            .FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New Rectangle(0, 0, 1, 1))
            .FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New Rectangle(0, Height - 1, 1, 1))
            .FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New Rectangle(Width - 1, 0, 1, 1))
            .FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New Rectangle(Width - 1, Height - 1, 1, 1))
            Dim _StringF As New StringFormat With {.LineAlignment = StringAlignment.Center}
            Select Case _TextAlignment
                Case Alignment.Center
                    _StringF.Alignment = StringAlignment.Center
                    .DrawString(Text, New Font("Arial", 9), Brushes.White, New RectangleF(0, 0, Width - 1, Height - 1), _StringF)
                Case Alignment.Left
                    .DrawString(Text, New Font("Arial", 9), Brushes.White, New RectangleF(7, 0, Width - 11, Height - 1), _StringF)
                Case Alignment.Right
                    Dim _StringLength As Integer = TextRenderer.MeasureText(Text, New Font("Arial", 9)).Width + 8
                    .DrawString(Text, New Font("Arial", 9), Brushes.White, New Rectangle(Width - _StringLength, 0, Width - _StringLength, Height - 1), _StringF)
            End Select
        End With
    End Sub
End Class

Class LoyalGroupBox
    Inherits ContainerControl

#Region " Back End "

#Region " Enums "

    Enum TextAlign
        Left = 0
        Center = 1
        Right = 2
    End Enum

#End Region

#Region " Properties "

    Private _HeaderSize As Integer = 35
    <Category("Header Properties")> _
    Public Property HeaderSize() As Integer
        Get
            Return _HeaderSize
        End Get
        Set(ByVal value As Integer)
            _HeaderSize = value
            Invalidate()
        End Set
    End Property

    Private _HeaderColor As Color = Color.FromArgb(102, 51, 153)
    <Category("Header Properties")> _
    Public Property HeaderColor() As Color
        Get
            Return _HeaderColor
        End Get
        Set(ByVal value As Color)
            _HeaderColor = value
            Invalidate()
        End Set
    End Property

    Private _TextAlignment As TextAlign = TextAlign.Left
    Public Property TextAlignment() As TextAlign
        Get
            Return _TextAlignment
        End Get
        Set(ByVal value As TextAlign)
            _TextAlignment = value
        End Set
    End Property

#End Region

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Sub New()
        Size = New Size(200, 100)
    End Sub

#End Region

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        With G
            .Clear(Color.FromArgb(40, 40, 40))
            .FillRectangle(New SolidBrush(_HeaderColor), New Rectangle(5, 5, Width - 10, _HeaderSize - 5))
            .DrawLine(New Pen(Color.FromArgb(30, Color.White)), New Point(6, 5), New Point(Width - 6, 5))
            .FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New Rectangle(0, 0, 1, 1))
            .FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New Rectangle(Width - 1, 0, 1, 1))
            .DrawLine(New Pen(Color.FromArgb(70, Color.Black)), New Point(5, _HeaderSize), New Point(Width - 6, _HeaderSize))
            .DrawRectangle(New Pen(Color.FromArgb(18, 18, 18)), New Rectangle(0, 0, Width - 1, Height - 1))
            .FillRectangle(New SolidBrush(Color.FromArgb(40, 40, 40)), New Rectangle(5, 5, 1, 1))
            .FillRectangle(New SolidBrush(Color.FromArgb(40, 40, 40)), New Rectangle(Width - 6, 5, 1, 1))
            .FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New Rectangle(0, 0, 1, 1))
            .FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New Rectangle(0, Height - 1, 1, 1))
            .FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New Rectangle(Width - 1, 0, 1, 1))
            .FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New Rectangle(Width - 1, Height - 1, 1, 1))
            Dim _StringF As New StringFormat With {.LineAlignment = StringAlignment.Center}
            Select Case _TextAlignment
                Case TextAlign.Center
                    _StringF.Alignment = StringAlignment.Center
                    .DrawString(Text, New Font("Arial", 9), Brushes.White, New RectangleF(5, 5, Width - 10, _HeaderSize - 5), _StringF)
                Case TextAlign.Left
                    .DrawString(Text, New Font("Arial", 9), Brushes.White, New RectangleF(12, 5, Width - 10, _HeaderSize - 5), _StringF)
                Case TextAlign.Right
                    Dim _StringLength As Integer = TextRenderer.MeasureText(Text, New Font("Arial", 9)).Width + 8
                    .DrawString(Text, New Font("Arial", 9), Brushes.White, New Rectangle(Width - _StringLength, 5, Width - _StringLength, _HeaderSize - 5), _StringF)
            End Select
        End With
    End Sub
End Class

<DefaultEvent("CheckedChanged")>
Class LoyalRadioButton
    Inherits Control

#Region " Back End "

#Region " Declarations "
    Private _State As MouseState = MouseState.None
    Private _Checked As Boolean
#End Region

#Region " Properties "
    Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(value As Boolean)
            _Checked = value
            InvalidateControls()
            RaiseEvent CheckedChanged(Me)
            Invalidate()
        End Set
    End Property
    Event CheckedChanged(ByVal sender As Object)
    Protected Overrides Sub OnClick(e As EventArgs)
        If Not _Checked Then Checked = True
        MyBase.OnClick(e)
    End Sub
    Private Sub InvalidateControls()
        If Not IsHandleCreated OrElse Not _Checked Then Return
        For Each C As Control In Parent.Controls
            If C IsNot Me AndAlso TypeOf C Is LoyalRadioButton Then
                DirectCast(C, LoyalRadioButton).Checked = False
                Invalidate()
            End If
        Next
    End Sub

    Private _CheckedColor As Color = Color.FromArgb(102, 51, 153)
    <Category("Colors Settings")> _
    Public Property CheckedColor() As Color
        Get
            Return _CheckedColor
        End Get
        Set(ByVal value As Color)
            _CheckedColor = value
            Invalidate()
        End Set
    End Property
    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        InvalidateControls()
    End Sub


    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Height = 16
    End Sub

#Region " Mouse States "

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        _State = MouseState.Down
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        _State = MouseState.Over
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        _State = MouseState.Over
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        _State = MouseState.None
        Invalidate()
    End Sub

#End Region

#End Region

#End Region

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.SmoothingMode = SmoothingMode.AntiAlias
        G.Clear(Parent.BackColor)
        If Parent.BackColor = Color.FromArgb(40, 40, 40) Then
            G.FillEllipse(New SolidBrush(Color.FromArgb(35, 35, 35)), New Rectangle(0, 0, 13, 13))
        Else
            G.FillEllipse(New SolidBrush(Color.FromArgb(40, 40, 40)), New Rectangle(0, 0, 13, 13))
        End If
        G.DrawEllipse(New Pen(Color.FromArgb(18, 18, 18)), New Rectangle(0, 0, 13, 13))

        If Checked Then
            G.FillEllipse(New SolidBrush(_CheckedColor), New Rectangle(3, 3, 7, 7))
        End If
        G.DrawString(Text, New Font("Arial", 9), Brushes.White, New Point(18, 0))
    End Sub
End Class

<DefaultEvent("CheckedChanged")>
Class LoyalCheckBox
    Inherits Control

#Region " Back End "

#Region " Declarations "
    Private _State As MouseState = MouseState.None
    Private _Checked As Boolean
#End Region

#Region " Properties "
    Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(value As Boolean)
            _Checked = value
            RaiseEvent CheckedChanged(Me)
            Invalidate()
        End Set
    End Property
    Event CheckedChanged(ByVal sender As Object)
    Protected Overrides Sub OnClick(e As EventArgs)
        If Not _Checked Then
            Checked = True
        Else
            Checked = False
        End If
        MyBase.OnClick(e)
    End Sub

    Private _CheckedColor As Color = Color.FromArgb(102, 51, 153)
    <Category("Colors Settings")> _
    Public Property CheckedColor() As Color
        Get
            Return _CheckedColor
        End Get
        Set(ByVal value As Color)
            _CheckedColor = value
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Height = 16
    End Sub

#Region " Mouse States "

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        _State = MouseState.Down
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        _State = MouseState.Over
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        _State = MouseState.Over
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        _State = MouseState.None
        Invalidate()
    End Sub

#End Region

#End Region

#End Region

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.Clear(Parent.BackColor)
        If Parent.BackColor = Color.FromArgb(40, 40, 40) Then
            G.FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New Rectangle(0, 0, 13, 13))
        Else
            G.FillRectangle(New SolidBrush(Color.FromArgb(40, 40, 40)), New Rectangle(0, 0, 13, 13))
        End If
        G.DrawRectangle(New Pen(Color.FromArgb(18, 18, 18)), New Rectangle(0, 0, 13, 13))

        If Checked Then
            G.FillRectangle(New SolidBrush(_CheckedColor), New Rectangle(3, 3, 8, 8))
        End If
        G.DrawString(Text, New Font("Arial", 9), Brushes.White, New Point(18, 0))
    End Sub
End Class

Class LoyalProgressBar
    Inherits Control

#Region " Back End "

#Region " Variables "
    Private _Value As Integer = 0
    Private _Maximum As Integer = 100
#End Region

#Region " Control "
    <Category("Control")>
    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(V As Integer)
            Select Case V
                Case Is < _Value
                    _Value = V
            End Select
            _Maximum = V
            Invalidate()
        End Set
    End Property

    <Category("Control")>
    Public Property Value() As Integer
        Get
            Select Case _Value
                Case 0
                    Return 0
                    Invalidate()
                Case Else
                    Return _Value
                    Invalidate()
            End Select
        End Get
        Set(V As Integer)
            Select Case V
                Case Is > _Maximum
                    V = _Maximum
                    Invalidate()
            End Select
            _Value = V
            Invalidate()
        End Set
    End Property
#End Region

#Region " Events "
    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Height = 25
    End Sub

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Height = 25
    End Sub

    Public Sub Increment(ByVal Amount As Integer)
        Value += Amount
    End Sub
#End Region

#Region " Properties "
    Private _ProgressColor As Color = Color.FromArgb(102, 51, 153)
    <Category("Header Properties")> _
    Public Property ProgressColor() As Color
        Get
            Return _ProgressColor
        End Get
        Set(ByVal value As Color)
            _ProgressColor = value
            Invalidate()
        End Set
    End Property
#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
    End Sub
#End Region

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
        G.SmoothingMode = SmoothingMode.HighQuality
        G.PixelOffsetMode = PixelOffsetMode.HighQuality
        If Parent.BackColor = Color.FromArgb(40, 40, 40) Then
            G.Clear(Color.FromArgb(35, 35, 35))
        Else
            G.Clear(Color.FromArgb(40, 40, 40))
        End If
        Dim _Progress As Integer = CInt(_Value / _Maximum * Width)
        G.DrawRectangle(New Pen(Color.FromArgb(18, 18, 18)), 0, 0, Width, Height)
        G.FillRectangle(New SolidBrush(_ProgressColor), New Rectangle(0, 0, _Progress - 1, Height))
        G.DrawLine(New Pen(Color.FromArgb(30, Color.White)), New Point(0, 0), New Point(_Progress - 1, 0))
        G.FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New Rectangle(0, 0, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New Rectangle(Width - 1, 0, 1, 1))
        G.DrawLine(New Pen(Color.FromArgb(70, Color.Black)), New Point(0, Height), New Point(_Progress - 1, Height))
        G.InterpolationMode = CType(7, InterpolationMode)
    End Sub
End Class

<DefaultEvent("TextChanged")>
Class LoyalTextBox
    Inherits Control

#Region " Back End "

#Region " Variables "
    Private _State As MouseState = MouseState.None
    Private WithEvents TB As Windows.Forms.TextBox
#End Region

#Region " Properties "

#Region " TextBox Properties "

    Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Left
    <Category("Options")> _
    Property TextAlign() As HorizontalAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            _TextAlign = value
            If TB IsNot Nothing Then
                TB.TextAlign = value
            End If
        End Set
    End Property
    Private _MaxLength As Integer = 32767
    <Category("Options")> _
    Property MaxLength() As Integer
        Get
            Return _MaxLength
        End Get
        Set(ByVal value As Integer)
            _MaxLength = value
            If TB IsNot Nothing Then
                TB.MaxLength = value
            End If
        End Set
    End Property
    Private _ReadOnly As Boolean
    <Category("Options")> _
    Property [ReadOnly]() As Boolean
        Get
            Return _ReadOnly
        End Get
        Set(ByVal value As Boolean)
            _ReadOnly = value
            If TB IsNot Nothing Then
                TB.ReadOnly = value
            End If
        End Set
    End Property
    Private _UseSystemPasswordChar As Boolean
    <Category("Options")> _
    Property UseSystemPasswordChar() As Boolean
        Get
            Return _UseSystemPasswordChar
        End Get
        Set(ByVal value As Boolean)
            _UseSystemPasswordChar = value
            If TB IsNot Nothing Then
                TB.UseSystemPasswordChar = value
            End If
        End Set
    End Property
    Private _Multiline As Boolean
    <Category("Options")> _
    Property Multiline() As Boolean
        Get
            Return _Multiline
        End Get
        Set(ByVal value As Boolean)
            _Multiline = value
            If TB IsNot Nothing Then
                TB.Multiline = value

                If value Then
                    TB.Height = Height - 11
                Else
                    Height = TB.Height + 11
                End If

            End If
        End Set
    End Property
    <Category("Options")> _
    Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            If TB IsNot Nothing Then
                TB.Text = value
            End If
        End Set
    End Property
    <Category("Options")> _
    Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            If TB IsNot Nothing Then
                TB.Font = value
                TB.Location = New Point(3, 5)
                TB.Width = Width - 6

                If Not _Multiline Then
                    Height = TB.Height + 11
                End If
            End If
        End Set
    End Property

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If Not Controls.Contains(TB) Then
            Controls.Add(TB)
        End If
    End Sub
    Private Sub OnBaseTextChanged(ByVal s As Object, ByVal e As EventArgs)
        Text = TB.Text
    End Sub
    Private Sub OnBaseKeyDown(ByVal s As Object, ByVal e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.A Then
            TB.SelectAll()
            e.SuppressKeyPress = True
        End If
        If e.Control AndAlso e.KeyCode = Keys.C Then
            TB.Copy()
            e.SuppressKeyPress = True
        End If
    End Sub
    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        TB.Location = New Point(5, 5)
        TB.Width = Width - 10

        If _Multiline Then
            TB.Height = Height - 11
        Else
            Height = TB.Height + 11
        End If

        MyBase.OnResize(e)
    End Sub

#End Region

#Region " Mouse States "

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        _State = MouseState.Down
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        _State = MouseState.Over
        TB.Focus()
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        _State = MouseState.Over
        TB.Focus()
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        _State = MouseState.None
        Invalidate()
    End Sub

#End Region

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        TB = New Windows.Forms.TextBox
        TB.Font = New Font("Arial", 9)
        TB.Text = Text
        TB.BackColor = Color.FromArgb(40, 40, 40)
        TB.ForeColor = Color.White
        TB.MaxLength = _MaxLength
        TB.Multiline = _Multiline
        TB.ReadOnly = _ReadOnly
        TB.UseSystemPasswordChar = _UseSystemPasswordChar
        TB.BorderStyle = BorderStyle.None
        TB.Location = New Point(5, 5)
        TB.Width = Width - 10

        TB.Cursor = Cursors.IBeam

        If _Multiline Then
            TB.Height = Height - 11
        Else
            Height = TB.Height + 11
        End If

        AddHandler TB.TextChanged, AddressOf OnBaseTextChanged
        AddHandler TB.KeyDown, AddressOf OnBaseKeyDown
    End Sub
#End Region

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.Clear(Color.FromArgb(40, 40, 40))
        G.DrawRectangle(New Pen(Color.FromArgb(24, 24, 24)), New Rectangle(0, 0, Width - 1, Height - 1))
        G.DrawRectangle(New Pen(Color.FromArgb(48, 48, 48)), New Rectangle(1, 1, Width - 3, Height - 3))
        G.FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New Rectangle(0, 0, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New Rectangle(0, Height - 1, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New Rectangle(Width - 1, 0, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New Rectangle(Width - 1, Height - 1, 1, 1))
    End Sub
End Class