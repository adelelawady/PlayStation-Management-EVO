Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Drawing.Text

''' <summary>
''' Element Theme
''' Created by Earn
''' From HF
''' </summary>
''' <remarks></remarks>

Enum MouseState_
    None = 0
    Over = 1
    Down = 2
End Enum

Class ElementTheme
    Inherits ContainerControl

#Region " Declarations "
    Dim _Down As Boolean = False
    Dim _Header As Integer = 30
    Dim _MousePoint As Point
#End Region

#Region " MouseStates "

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        _Down = False
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If e.Location.Y < _Header AndAlso e.Button = Windows.Forms.MouseButtons.Left Then
            _Down = True
            _MousePoint = e.Location
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If _Down = True Then
            ParentForm.Location = MousePosition - _MousePoint
        End If
    End Sub

#End Region

#Region " Properties "

    Private _CenterText As Boolean
    Public Property CenterText() As Boolean
        Get
            Return _CenterText
        End Get
        Set(ByVal value As Boolean)
            _CenterText = value
        End Set
    End Property


#End Region

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        ParentForm.FormBorderStyle = FormBorderStyle.None
        ParentForm.TransparencyKey = Color.Fuchsia
        Dock = DockStyle.Fill
        Invalidate()
    End Sub

    Sub New()
        BackColor = Color.FromArgb(41, 41, 41)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.Clear(Color.FromArgb(32, 32, 32))
        G.FillRectangle(New SolidBrush(BackColor), New Rectangle(9, _Header, Width - 18, Height - _Header - 9))
        If _CenterText = True Then
            Dim _StringF As New StringFormat
            _StringF.Alignment = StringAlignment.Center
            _StringF.LineAlignment = StringAlignment.Center
            G.DrawString(Text, New Font("Arial", 11), Brushes.White, New RectangleF(0, 0, Width, _Header), _StringF)
        Else
            G.DrawString(Text, New Font("Arial", 11), Brushes.White, New Point(8, 7))
        End If
    End Sub
End Class

Class ElementButton
    Inherits Control

#Region " Declarations "
    Private _State As MouseState
#End Region

#Region " MouseStates "
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

    Private _BaseColor As Color = Color.FromArgb(231, 75, 60)
    Public Property BaseColor() As Color
        Get
            Return _BaseColor
        End Get
        Set(ByVal value As Color)
            _BaseColor = value
        End Set
    End Property


#End Region

    Sub New()
        Size = New Size(90, 30)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.Clear(_BaseColor)

        Select Case _State
            Case MouseState.Over
                G.FillRectangle(New SolidBrush(Color.FromArgb(20, Color.White)), New Rectangle(0, 0, Width, Height))

            Case MouseState.Down
                G.FillRectangle(New SolidBrush(Color.FromArgb(30, Color.Black)), New Rectangle(0, 0, Width, Height))
        End Select

        Dim _StringF As New StringFormat
        _StringF.Alignment = StringAlignment.Center
        _StringF.LineAlignment = StringAlignment.Center
        G.DrawString(Text, New Font("Arial", 9), Brushes.White, New RectangleF(0, 0, Width, Height), _StringF)

    End Sub

End Class

Class ElementGroupBox
    Inherits ContainerControl

#Region " Properties "
    Private _SideColor As Color = Color.FromArgb(231, 75, 60)
    Public Property SideColor() As Color
        Get
            Return _SideColor
        End Get
        Set(ByVal value As Color)
            _SideColor = value
        End Set
    End Property

#End Region

    Sub New()
        Size = New Size(200, 100)
        BackColor = Color.FromArgb(32, 32, 32)
    End Sub
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.Clear(Color.FromArgb(32, 32, 32))

        G.FillRectangle(New SolidBrush(_SideColor), New Rectangle(0, 0, 7, Height))
        G.DrawString(Text, New Font("Arial", 9), Brushes.White, New Point(10, 4))
    End Sub
End Class

Class ElementRadioButton
    Inherits Control

#Region " Variables "

    Private _State As MouseState
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

    Private _CheckedColor As Color = Color.FromArgb(231, 75, 60)
    Public Property CheckedColor() As Color
        Get
            Return _CheckedColor
        End Get
        Set(ByVal value As Color)
            _CheckedColor = value
        End Set
    End Property


#End Region

#Region " Events "
    Event CheckedChanged(ByVal sender As Object)
    Protected Overrides Sub OnClick(e As EventArgs)
        If Not _Checked Then Checked = True
        MyBase.OnClick(e)
    End Sub
    Private Sub InvalidateControls()
        If Not IsHandleCreated OrElse Not _Checked Then Return
        For Each C As Control In Parent.Controls
            If C IsNot Me AndAlso TypeOf C Is ElementRadioButton Then
                DirectCast(C, ElementRadioButton).Checked = False
                Invalidate()
            End If
        Next
    End Sub
    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        InvalidateControls()
    End Sub


    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Height = 16
    End Sub
#End Region

#Region " Mouse States "

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        _State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        _State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        _State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        _State = MouseState.None : Invalidate()
    End Sub

#End Region

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.SmoothingMode = 2
        G.TextRenderingHint = 5
        G.Clear(Parent.BackColor)
        G.FillEllipse(Brushes.White, New Rectangle(0, 0, 15, 15))
        If Checked Then
            G.FillEllipse(New SolidBrush(_CheckedColor), New Rectangle(2, 2, 11, 11))
        End If
        G.DrawString(Text, New Font("Arial", 9), Brushes.White, New Point(20, 0))
    End Sub
End Class

Class ElementCheckBox
    Inherits Control

#Region " Variables "

    Private _State As MouseState
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

    Private _CheckedColor As Color = Color.FromArgb(231, 75, 60)
    Public Property CheckedColor() As Color
        Get
            Return _CheckedColor
        End Get
        Set(ByVal value As Color)
            _CheckedColor = value
        End Set
    End Property
#End Region

#Region " Events "
    Event CheckedChanged(ByVal sender As Object)
    Protected Overrides Sub OnClick(e As EventArgs)
        If Not _Checked Then Checked = True
        MyBase.OnClick(e)
    End Sub


    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Height = 16
    End Sub
#End Region

#Region " Mouse States "

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        _State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        _State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        _State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        _State = MouseState.None : Invalidate()
    End Sub

#End Region

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.TextRenderingHint = 5
        G.Clear(Parent.BackColor)
        G.FillRectangle(Brushes.White, New Rectangle(0, 0, 15, 15))
        If Checked = True Then
            G.FillRectangle(New SolidBrush(_CheckedColor), New Rectangle(2, 2, 11, 11))
        End If
        G.DrawString(Text, New Font("Arial", 9), Brushes.White, New Point(20, 0))
    End Sub
End Class

Class ElementProgressBar
    Inherits Control

#Region " Variables "
    Private _Value As Integer = 0
    Private _Maximum As Integer = 100
#End Region

#Region " Properties "
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

    Private _ProgressColor As Color = Color.FromArgb(231, 75, 60)
    Public Property ProgressColor() As Color
        Get
            Return _ProgressColor
        End Get
        Set(ByVal value As Color)
            _ProgressColor = value
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

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics

        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
        G.SmoothingMode = SmoothingMode.HighQuality
        G.PixelOffsetMode = PixelOffsetMode.HighQuality

        G.Clear(Parent.BackColor)
        Dim ProgVal As Integer = CInt(_Value / _Maximum * Width)
        G.FillRectangle(New SolidBrush(Color.White), New Rectangle(0, 0, Width, Height))
        G.FillRectangle(New SolidBrush(_ProgressColor), New Rectangle(0, 0, ProgVal, Height))
        G.InterpolationMode = CType(7, InterpolationMode)
    End Sub
End Class

<DefaultEvent("TextChanged")>
Class ElementTextBox
    Inherits Control

#Region " Variables"
    Private WithEvents _TextBox As Windows.Forms.TextBox
#End Region

#Region " Properties"

    Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Left
    <Category("Options")> _
    Property TextAlign() As HorizontalAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            _TextAlign = value
            If _TextBox IsNot Nothing Then
                _TextBox.TextAlign = value
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
            If _TextBox IsNot Nothing Then
                _TextBox.MaxLength = value
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
            If _TextBox IsNot Nothing Then
                _TextBox.ReadOnly = value
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
            If _TextBox IsNot Nothing Then
                _TextBox.UseSystemPasswordChar = value
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
            If _TextBox IsNot Nothing Then
                _TextBox.Multiline = value

                If value Then
                    _TextBox.Height = Height - 11
                Else
                    Height = _TextBox.Height + 11
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
            If _TextBox IsNot Nothing Then
                _TextBox.Text = value
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
            If _TextBox IsNot Nothing Then
                _TextBox.Font = value
                _TextBox.Location = New Point(3, 5)
                _TextBox.Width = Width - 6

                If Not _Multiline Then
                    Height = _TextBox.Height + 11
                End If
            End If
        End Set
    End Property

    Private _BorderColor As Color = Color.FromArgb(231, 75, 60)
    Public Property BorderColor() As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal value As Color)
            _BorderColor = value
        End Set
    End Property


#End Region

#Region " Events "
    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If Not Controls.Contains(_TextBox) Then
            Controls.Add(_TextBox)
        End If
    End Sub
    Private Sub OnBaseTextChanged(ByVal s As Object, ByVal e As EventArgs)
        Text = _TextBox.Text
    End Sub
    Private Sub OnBaseKeyDown(ByVal s As Object, ByVal e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.A Then
            _TextBox.SelectAll()
            e.SuppressKeyPress = True
        End If
        If e.Control AndAlso e.KeyCode = Keys.C Then
            _TextBox.Copy()
            e.SuppressKeyPress = True
        End If
    End Sub
    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        _TextBox.Location = New Point(5, 5)
        _TextBox.Width = Width - 10

        If _Multiline Then
            _TextBox.Height = Height - 11
        Else
            Height = _TextBox.Height + 11
        End If
        MyBase.OnResize(e)
    End Sub

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True

        BackColor = Color.Transparent

        _TextBox = New Windows.Forms.TextBox
        _TextBox.Font = New Font("Segoe UI", 10)
        _TextBox.Text = Text
        _TextBox.BackColor = Color.FromArgb(32, 32, 32)
        _TextBox.ForeColor = Color.White
        _TextBox.MaxLength = _MaxLength
        _TextBox.Multiline = _Multiline
        _TextBox.ReadOnly = _ReadOnly
        _TextBox.UseSystemPasswordChar = _UseSystemPasswordChar
        _TextBox.BorderStyle = BorderStyle.None
        _TextBox.Location = New Point(5, 5)
        _TextBox.Width = Width - 10

        _TextBox.Cursor = Cursors.IBeam

        If _Multiline Then
            _TextBox.Height = Height - 11
        Else
            Height = _TextBox.Height + 11
        End If

        AddHandler _TextBox.TextChanged, AddressOf OnBaseTextChanged
        AddHandler _TextBox.KeyDown, AddressOf OnBaseKeyDown
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.Clear(Color.FromArgb(32, 32, 32))
        G.DrawRectangle(New Pen(_BorderColor), New Rectangle(0, 0, Width - 1, Height - 1))
    End Sub
End Class

Class ElementClose
    Inherits Control

#Region " Declarations "
    Private _State As MouseState
#End Region

#Region " MouseStates "
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

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        Environment.Exit(0)
    End Sub
#End Region

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(12, 12)
    End Sub

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        Size = New Size(12, 12)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics

        G.Clear(Color.FromArgb(32, 32, 32))

        Dim _StringF As New StringFormat
        _StringF.Alignment = StringAlignment.Center
        _StringF.LineAlignment = StringAlignment.Center

        G.DrawString("r", New Font("Marlett", 11), Brushes.White, New RectangleF(0, 0, Width, Height), _StringF)

        Select Case _State
            Case MouseState.Over
                G.DrawString("r", New Font("Marlett", 11), New SolidBrush(Color.FromArgb(25, Color.White)), New RectangleF(0, 0, Width, Height), _StringF)

            Case MouseState.Down
                G.DrawString("r", New Font("Marlett", 11), New SolidBrush(Color.FromArgb(40, Color.Black)), New RectangleF(0, 0, Width, Height), _StringF)

        End Select

    End Sub

End Class

Class ElementMini
    Inherits Control

#Region " Declarations "
    Private _State As MouseState
#End Region

#Region " MouseStates "
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

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        FindForm.WindowState = FormWindowState.Minimized
    End Sub
#End Region

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(12, 12)
    End Sub

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        Size = New Size(12, 12)
    End Sub
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics

        G.Clear(Color.FromArgb(32, 32, 32))

        Dim _StringF As New StringFormat
        _StringF.Alignment = StringAlignment.Center
        _StringF.LineAlignment = StringAlignment.Center

        G.DrawString("0", New Font("Marlett", 11), Brushes.White, New RectangleF(0, 0, Width, Height), _StringF)

        Select Case _State
            Case MouseState.Over
                G.DrawString("0", New Font("Marlett", 11), New SolidBrush(Color.FromArgb(25, Color.White)), New RectangleF(0, 0, Width, Height), _StringF)

            Case MouseState.Down
                G.DrawString("0", New Font("Marlett", 11), New SolidBrush(Color.FromArgb(40, Color.Black)), New RectangleF(0, 0, Width, Height), _StringF)

        End Select

    End Sub

End Class