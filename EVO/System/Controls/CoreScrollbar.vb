'# DO NOT MODIFY OR REMOVE THIS HEADER ##################
'#                                                      #
'#  Author: Adam Smith                                  #
'#  Email Address: ibulwark@hotmail.com                 #
'#  Date Created: 7/24/2004                             #
'#  Language: VB.NET                                    #
'#  Version: 1.0                                        #
'#  Website: http://www.codevendor.com                  #
'#                                                      #
'#  Title: Core Custom Scrollbar Class                  #
'#                                                      #
'#  Code Description: This is a fully drawn gdi+        #
'#  custom scrollbar control class. All of it's         #
'#  drawing methods are overrideable allowing           #
'#  developers to paint it however they choose.         #
'#                                                      #
'#  -------------------------------------------------   #
'#  License: Free to use and modify as long as header   #
'#  stays in place. If any modifications are made to    #
'#  this assembly users must email changes to author's  #
'#  email address.                                      #
'#  -------------------------------------------------   #
'#  Terms and Conditions For Use, Copy, Distribution    #
'#  and Modification.                                   #
'#  -------------------------------------------------   #
'#  THIS CODE IS PROVIDED BY THE COPYRIGHT              #
'#  HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS    #
'#  OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED   #
'#  TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND   #
'#  FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.    #
'#  IN NO EVENT SHALL THE COPYRIGHT OWNER CONTRIBUTORS  #
'#  BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,     #
'#  SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES        #
'#  (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF      #
'#  SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA,    #
'#  OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER       #
'#  CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER      #
'#  IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING   #
'#  NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT     #
'#  OF THE USE OF THIS CODE, EVEN IF ADVISED OF THE     #
'#  POSSIBILITY OF SUCH DAMAGE.                         #
'#  -------------------------------------------------   #
'#                                                      #
'########################################################

#Region "Imports"
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
#End Region

Namespace Core

    ''' <summary>CoreScrollbar is a custom scrollbar class that is fully drawn.</summary>
    Public Class [Scrollbar] : Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            Me.SetStyle(ControlStyles.DoubleBuffer, True)

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            Me.SetStyle(ControlStyles.Opaque, True)
            'Me.SetStyle(ControlStyles.DoubleBuffer, True)
            'Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            'Me.SetStyle(ControlStyles.UserPaint, True)

            'Add any initialization after the InitializeComponent() call

        End Sub

        'UserControl overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            '
            'CoreScrollbar
            '
            Me.Name = "CoreScrollbar"
            Me.Size = New System.Drawing.Size(17, 200)

        End Sub

#End Region

#Region "Events"

        Public Event Scroll()

#End Region

#Region "Supporting Controls"

        Private WithEvents PageUp As Timer
        Private WithEvents PageDown As Timer

#End Region

#Region "Private Variables"

        Private ShaftMovingUp As Boolean = False
        Private ShaftMovingDown As Boolean = False
        Private CurrentMouseMove As Integer = 0
        Private MouseDownNow As Boolean = False
        Private ThumbMoving As Boolean = False
        Private MeterY As Integer = 0
        Private Info(0) As ControlInfo
        Private P_LargeChange As Integer = 10
        Private P_Maximum As Integer = 100
        Private P_Minimum As Integer = 0
        Private P_SmallChange As Integer = 1
        Private P_Value As Integer = 0
        Private P_Orientation As OrientationMode = OrientationMode.VERTICAL

#End Region

#Region "Properties"

        ''' <summary>The change in the position of the thumb when the user clicks in the scroll bar area or uses the pgup/pgdn.</summary>
        <CategoryAttribute("Behavior"), DescriptionAttribute("The change in the position of the thumb when the user clicks in the scroll bar area or uses the pgup/pgdn.")> _
            Public Property LargeChange() As Integer
            Get
                Return P_LargeChange
            End Get
            Set(ByVal Value As Integer)
                P_LargeChange = Value
                Draw()
            End Set
        End Property

        ''' <summary>The maximum position of the thumb.</summary>
        <CategoryAttribute("Behavior"), DescriptionAttribute("The maximum position of the thumb.")> _
        Public Property Maximum() As Integer
            Get
                Return P_Maximum
            End Get
            Set(ByVal Value As Integer)
                P_Maximum = Value
                Draw()
            End Set
        End Property

        ''' <summary>The minimum position of the thumb.</summary>
        <CategoryAttribute("Behavior"), DescriptionAttribute("The minimum position of the thumb.")> _
        Public Property Minimum() As Integer
            Get
                Return P_Minimum
            End Get
            Set(ByVal Value As Integer)
                P_Minimum = Value
                Draw()
            End Set
        End Property

        ''' <summary>The change in the position of the thumb when the user clicks one of the arrows or uses an arrow key.</summary>
        <CategoryAttribute("Behavior"), DescriptionAttribute("The change in the position of the thumb when the user clicks one of the arrows or uses an arrow key.")> _
         Public Property SmallChange() As Integer
            Get
                Return P_SmallChange
            End Get
            Set(ByVal Value As Integer)
                P_SmallChange = Value
                Draw()
            End Set
        End Property

        ''' <summary>The position of the thumb.</summary>
        <CategoryAttribute("Behavior"), DescriptionAttribute("The position of the thumb.")> _
        Public Property [Value]() As Integer
            Get
                Return P_Value
            End Get
            Set(ByVal Value As Integer)
                P_Value = Value
            End Set
        End Property

        ''' <summary>The orientation of the scrollbar vertical/horizontal.</summary>
        <CategoryAttribute("Behavior"), DescriptionAttribute("The orientation of the scrollbar vertical/horizontal.")> _
        Public Property Orientation() As OrientationMode
            Get
                Return P_Orientation
            End Get
            Set(ByVal Value As OrientationMode)
                P_Orientation = Value
                Draw()
            End Set
        End Property

#End Region

#Region "Enumerations"

        ''' <summary>An enumeration of scrollbar orientation horizontal/vertical.</summary>
        Public Enum OrientationMode

            HORIZONTAL = 0
            VERTICAL = 1

        End Enum

        ''' <summary>An enumeration of usercontrol events.</summary>
        Public Enum ControlEvents

            None = 0
            OnClick = 1
            OnKeyDown = 2
            OnKeyPress = 3
            OnKeyUp = 4
            OnMouseDown = 5
            OnMouseEnter = 6
            OnMouseHover = 7
            OnMouseLeave = 8
            OnMouseMove = 9
            OnMouseUp = 10

        End Enum

#End Region

#Region "Helper Methods"

        ''' <summary>Method for drawing the scrollbar control.</summary>
        Private Sub Draw()

            'Set value to nothing-----
            Me.Value = 0
            '-------------------------

            'Redim Control list-------
            ReDim Info(5)
            Info(0) = New ControlInfo
            Info(1) = New ControlInfo
            Info(2) = New ControlInfo
            Info(3) = New ControlInfo
            Info(4) = New ControlInfo
            Info(5) = New ControlInfo
            PageUp = New Timer
            PageDown = New Timer
            '-------------------------

            'Declare Variables--------
            Dim x, y, h, w As Integer
            PageUp.Enabled = False
            PageUp.Interval = 500
            PageDown.Enabled = False
            PageDown.Interval = 500
            '-------------------------

            'Main Control--------------------------
            x = 0 : y = 0 : h = 0 : w = 0
            Info(0).X = x : Info(0).Y = y : Info(0).H = h : Info(0).W = w : Info(0).X2 = (x + w) : Info(0).Y2 = (y + h) : Info(0).Name = "ALL"
            '--------------------------------------

            'Thumb Control-------------------------
            Dim Thumbht As Integer = Get_Thumb_Height()
            x = 0 : y = 17 : h = Thumbht : w = Me.Width
            Info(1).X = x : Info(1).Y = y : Info(1).H = h : Info(1).W = w : Info(1).X2 = (x + w) : Info(1).Y2 = (y + h) : Info(1).Name = "Thumb"
            Draw_Thumb(x, y, w, h, ControlEvents.None)
            '--------------------------------------

            'Shaft Control Above-------------------
            x = 0 : y = 17 : h = 0 : w = Me.Width
            Info(2).X = x : Info(2).Y = y : Info(2).H = h : Info(2).W = w : Info(2).X2 = (x + w) : Info(2).Y2 = (y + h) : Info(2).Name = "Shaft Above"
            Draw_Shaft_Above(x, y, w, h, ControlEvents.None)
            '--------------------------------------

            'Shaft Control Below-------------------
            If Thumbht > 0 Then Thumbht += 1
            x = 0 : y = 17 + Thumbht : h = Me.Height - 34 - Thumbht : w = Me.Width
            Info(3).X = x : Info(3).Y = y : Info(3).H = h : Info(3).W = w : Info(3).X2 = (x + w) : Info(3).Y2 = (y + h) : Info(3).Name = "Shaft Below"
            Draw_Shaft_Below(x, y, w, h, ControlEvents.None)
            '--------------------------------------

            'Draw Arrow Down---------------------
            x = 0 : y = Me.Height - 17 : h = 16 : w = Me.Width
            Info(4).X = x : Info(4).Y = y : Info(4).H = h : Info(4).W = w : Info(4).X2 = (x + w) : Info(4).Y2 = (y + h) : Info(4).Name = "Arrow Down"
            Draw_Arrow_Down(x, y, w, h, ControlEvents.None)
            '------------------------------------

            'Draw Arrow Up-----------------------
            x = 0 : y = 0 : h = 16 : w = Me.Width
            Info(5).X = x : Info(5).Y = y : Info(5).H = h : Info(5).W = w : Info(5).X2 = (x + w) : Info(5).Y2 = (y + h) : Info(5).Name = "Arrow Up"
            Draw_Arrow_Up(x, y, w, h, ControlEvents.None)
            '------------------------------------

        End Sub

        ''' <summary>Method for redrawing the scrollbar control.</summary>
        Private Sub ReDraw()

            'Thumb Control-------------------------
            Dim x, y, h, w As Integer
            x = Info(1).X : y = Info(1).Y : h = Info(1).H : w = Info(1).W
            Info(1).X = x : Info(1).Y = y : Info(1).H = h : Info(1).W = w : Info(1).X2 = (x + w) : Info(1).Y2 = (y + h) : Info(1).Name = "Thumb"
            Draw_Thumb(x, y, w, h, ControlEvents.None)
            '--------------------------------------

            'Shaft Control Above-------------------
            x = Info(2).X : y = Info(2).Y : h = Info(2).H : w = Info(2).W
            Info(2).X = x : Info(2).Y = y : Info(2).H = h : Info(2).W = w : Info(2).X2 = (x + w) : Info(2).Y2 = (y + h) : Info(2).Name = "Shaft Above"
            Draw_Shaft_Above(x, y, w, h, ControlEvents.None)
            '--------------------------------------

            'Shaft Control Below-------------------
            x = Info(3).X : y = Info(3).Y : h = Info(3).H : w = Info(3).W
            Info(3).X = x : Info(3).Y = y : Info(3).H = h : Info(3).W = w : Info(3).X2 = (x + w) : Info(3).Y2 = (y + h) : Info(3).Name = "Shaft Below"
            Draw_Shaft_Below(x, y, w, h, ControlEvents.None)
            '--------------------------------------

            'Draw Arrow Down---------------------
            x = Info(4).X : y = Info(4).Y : h = Info(4).H : w = Info(4).W
            Info(4).X = x : Info(4).Y = y : Info(4).H = h : Info(4).W = w : Info(4).X2 = (x + w) : Info(4).Y2 = (y + h) : Info(4).Name = "Arrow Down"
            Draw_Arrow_Down(x, y, w, h, ControlEvents.None)
            '------------------------------------

            'Draw Arrow Up-----------------------
            x = Info(5).X : y = Info(5).Y : h = Info(5).H : w = Info(5).W
            Info(5).X = x : Info(5).Y = y : Info(5).H = h : Info(5).W = w : Info(5).X2 = (x + w) : Info(5).Y2 = (y + h) : Info(5).Name = "Arrow Up"
            Draw_Arrow_Up(x, y, w, h, ControlEvents.None)
            '------------------------------------

        End Sub

        ''' <summary>Method for calculating the thumb height of the scrollbar control.</summary>
        Private Function Get_Thumb_Height() As Integer

            If Me.Maximum = 0 Or LargeChange = 0 Then Return 0 : Exit Function

            'Make thumb height based on number of records--------
            Dim ThumbHt As Integer = (Me.Height - 35) / (Me.Maximum / Me.LargeChange)
            '----------------------------------------------------

            'Get the thumb bar height-------------
            Select Case ThumbHt
                Case Is < 10
                    Return 10
                Case Else
                    Return ThumbHt
            End Select
            '-------------------------------------

        End Function

        ''' <summary>Method for drawing the arrow down button.</summary>
        Public Overridable Sub Draw_Arrow_Down(ByVal X As Integer, ByVal Y As Integer, ByVal W As Integer, ByVal H As Integer, ByVal EventOf As ControlEvents)

            'Get Control Graphics-----------------
            Dim g As Graphics = Me.CreateGraphics
            g.SmoothingMode = SmoothingMode.None
            '-------------------------------------

            Select Case EventOf

                Case ControlEvents.None

                    'Draw Rectangle to start--------------------------------------------
                    g.FillRectangle(New SolidBrush(Color.White), New Rectangle(X, Y, W, H))
                    g.DrawRectangle(New Pen(Color.Gray), New Rectangle(X, Y, W - 1, H))
                    '-------------------------------------------------------------------

                    'Draw Border--------------------------------------------------------
                    g.DrawLine(New Pen(Color.LightBlue), 3, 2 + Y, W - 4, 2 + Y)
                    g.DrawLine(New Pen(Color.LightBlue), 2, Y + 3, 2, H + Y - 3)
                    g.DrawLine(New Pen(Color.LightBlue), 3, Y + H - 2, W - 4, Y + H - 2)
                    g.DrawLine(New Pen(Color.LightBlue), W - 3, Y + 3, W - 3, H + Y - 3)
                    '-------------------------------------------------------------------

                    'Draw Arrow---------------------------------------------------------
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 1, (H \ 2) + 2 + Y, (W \ 2) + 1, (H \ 2) + 2 + Y)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 2, (H \ 2) + 1 + Y, (W \ 2) + 2, (H \ 2) + 1 + Y)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 3, (H \ 2) + Y, (W \ 2) - 1, (H \ 2) + Y)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) + 1, (H \ 2) + Y, (W \ 2) + 3, (H \ 2) + Y)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) + 2, (H \ 2) - 1 + Y, (W \ 2) + 4, (H \ 2) - 1 + Y)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 4, (H \ 2) - 1 + Y, (W \ 2) - 2, (H \ 2) - 1 + Y)
                    '-------------------------------------------------------------------

                    'Reset Settings-----------------------
                    Info(4).X = X : Info(4).Y = Y : Info(4).H = H : Info(4).W = W : Info(4).X2 = (X + W) : Info(4).Y2 = (Y + H) : Info(4).Name = "Arrow Down"
                    '-------------------------------------

                Case ControlEvents.OnMouseMove

                    'Draw Rectangle to start--------------------------------------------
                    g.FillRectangle(New SolidBrush(Color.White), New Rectangle(X, Y, W, H))
                    g.DrawRectangle(New Pen(Color.Gray), New Rectangle(X, Y, W - 1, H))
                    '-------------------------------------------------------------------

                    'Draw Border--------------------------------------------------------
                    g.DrawLine(New Pen(Color.Blue), 3, 2 + Y, W - 4, 2 + Y)
                    g.DrawLine(New Pen(Color.Blue), 2, Y + 3, 2, H + Y - 3)
                    g.DrawLine(New Pen(Color.Blue), 3, Y + H - 2, W - 4, Y + H - 2)
                    g.DrawLine(New Pen(Color.Blue), W - 3, Y + 3, W - 3, H + Y - 3)
                    '-------------------------------------------------------------------

                    'Draw Arrow---------------------------------------------------------
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 1, (H \ 2) + 2 + Y, (W \ 2) + 1, (H \ 2) + 2 + Y)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 2, (H \ 2) + 1 + Y, (W \ 2) + 2, (H \ 2) + 1 + Y)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 3, (H \ 2) + Y, (W \ 2) - 1, (H \ 2) + Y)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) + 1, (H \ 2) + Y, (W \ 2) + 3, (H \ 2) + Y)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) + 2, (H \ 2) - 1 + Y, (W \ 2) + 4, (H \ 2) - 1 + Y)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 4, (H \ 2) - 1 + Y, (W \ 2) - 2, (H \ 2) - 1 + Y)
                    '-------------------------------------------------------------------

                    'Reset Settings-----------------------
                    Info(4).X = X : Info(4).Y = Y : Info(4).H = H : Info(4).W = W : Info(4).X2 = (X + W) : Info(4).Y2 = (Y + H) : Info(4).Name = "Arrow Down"
                    '-------------------------------------

                Case ControlEvents.OnMouseDown

                    'Draw Rectangle to start--------------------------------------------
                    g.FillRectangle(New SolidBrush(Color.LightBlue), New Rectangle(X, Y, W, H))
                    g.DrawRectangle(New Pen(Color.Gray), New Rectangle(X, Y, W - 1, H))
                    '-------------------------------------------------------------------

                    'Draw Border--------------------------------------------------------
                    g.DrawLine(New Pen(Color.Blue), 3, 2 + Y, W - 4, 2 + Y)
                    g.DrawLine(New Pen(Color.Blue), 2, Y + 3, 2, H + Y - 3)
                    g.DrawLine(New Pen(Color.Blue), 3, Y + H - 2, W - 4, Y + H - 2)
                    g.DrawLine(New Pen(Color.Blue), W - 3, Y + 3, W - 3, H + Y - 3)
                    '-------------------------------------------------------------------

                    'Draw Arrow---------------------------------------------------------
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 1, (H \ 2) + 2 + Y, (W \ 2) + 1, (H \ 2) + 2 + Y)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 2, (H \ 2) + 1 + Y, (W \ 2) + 2, (H \ 2) + 1 + Y)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 3, (H \ 2) + Y, (W \ 2) - 1, (H \ 2) + Y)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) + 1, (H \ 2) + Y, (W \ 2) + 3, (H \ 2) + Y)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) + 2, (H \ 2) - 1 + Y, (W \ 2) + 4, (H \ 2) - 1 + Y)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 4, (H \ 2) - 1 + Y, (W \ 2) - 2, (H \ 2) - 1 + Y)
                    '-------------------------------------------------------------------

                    'Reset Settings-----------------------
                    Info(4).X = X : Info(4).Y = Y : Info(4).H = H : Info(4).W = W : Info(4).X2 = (X + W) : Info(4).Y2 = (Y + H) : Info(4).Name = "Arrow Down"
                    '-------------------------------------

            End Select

        End Sub

        ''' <summary>Method for drawing the arrow up button.</summary>
        Public Overridable Sub Draw_Arrow_Up(ByVal X As Integer, ByVal Y As Integer, ByVal W As Integer, ByVal H As Integer, ByVal EventOf As ControlEvents)

            'Get Control Graphics-----------------
            Dim g As Graphics = Me.CreateGraphics
            g.SmoothingMode = SmoothingMode.None
            '-------------------------------------

            Select Case EventOf

                Case ControlEvents.None

                    'Draw Rectangle to start--------------------------------------------
                    g.FillRectangle(New SolidBrush(Color.White), New Rectangle(X, Y, W, H))
                    g.DrawRectangle(New Pen(Color.Gray), New Rectangle(X, Y, W - 1, H))
                    '-------------------------------------------------------------------

                    'Draw Border--------------------------------------------------------
                    g.DrawLine(New Pen(Color.LightBlue), 3, 2 + Y, W - 4, 2 + Y)
                    g.DrawLine(New Pen(Color.LightBlue), 2, Y + 3, 2, H + Y - 3)
                    g.DrawLine(New Pen(Color.LightBlue), 3, Y + H - 2, W - 4, Y + H - 2)
                    g.DrawLine(New Pen(Color.LightBlue), W - 3, Y + 3, W - 3, H + Y - 3)
                    '-------------------------------------------------------------------

                    'Draw Arrow---------------------------------------------------------
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 1, (H \ 2) - 2, (W \ 2) + 1, (H \ 2) - 2)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 2, (H \ 2) - 1, (W \ 2) + 2, (H \ 2) - 1)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 3, (H \ 2), (W \ 2) - 1, (H \ 2))
                    g.DrawLine(New Pen(Color.Black), (W \ 2) + 1, (H \ 2), (W \ 2) + 3, (H \ 2))
                    g.DrawLine(New Pen(Color.Black), (W \ 2) + 2, (H \ 2) + 1, (W \ 2) + 4, (H \ 2) + 1)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 4, (H \ 2) + 1, (W \ 2) - 2, (H \ 2) + 1)
                    '-------------------------------------------------------------------

                    'Reset Settings-----------------------
                    Info(5).X = X : Info(5).Y = Y : Info(5).H = H : Info(5).W = W : Info(5).X2 = (X + W) : Info(5).Y2 = (Y + H) : Info(5).Name = "Arrow Up"
                    '-------------------------------------

                Case ControlEvents.OnMouseDown

                    'Draw Rectangle to start--------------------------------------------
                    g.FillRectangle(New SolidBrush(Color.LightBlue), New Rectangle(X, Y, W, H))
                    g.DrawRectangle(New Pen(Color.Gray), New Rectangle(X, Y, W - 1, H))
                    '-------------------------------------------------------------------

                    'Draw Border--------------------------------------------------------
                    g.DrawLine(New Pen(Color.Blue), 3, 2 + Y, W - 4, 2 + Y)
                    g.DrawLine(New Pen(Color.Blue), 2, Y + 3, 2, H + Y - 3)
                    g.DrawLine(New Pen(Color.Blue), 3, Y + H - 2, W - 4, Y + H - 2)
                    g.DrawLine(New Pen(Color.Blue), W - 3, Y + 3, W - 3, H + Y - 3)
                    '-------------------------------------------------------------------

                    'Draw Arrow---------------------------------------------------------
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 1, (H \ 2) - 2, (W \ 2) + 1, (H \ 2) - 2)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 2, (H \ 2) - 1, (W \ 2) + 2, (H \ 2) - 1)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 3, (H \ 2), (W \ 2) - 1, (H \ 2))
                    g.DrawLine(New Pen(Color.Black), (W \ 2) + 1, (H \ 2), (W \ 2) + 3, (H \ 2))
                    g.DrawLine(New Pen(Color.Black), (W \ 2) + 2, (H \ 2) + 1, (W \ 2) + 4, (H \ 2) + 1)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 4, (H \ 2) + 1, (W \ 2) - 2, (H \ 2) + 1)
                    '-------------------------------------------------------------------

                    'Reset Settings-----------------------
                    Info(5).X = X : Info(5).Y = Y : Info(5).H = H : Info(5).W = W : Info(5).X2 = (X + W) : Info(5).Y2 = (Y + H) : Info(5).Name = "Arrow Up"
                    '-------------------------------------

                Case ControlEvents.OnMouseMove

                    'Draw Rectangle to start--------------------------------------------
                    g.FillRectangle(New SolidBrush(Color.White), New Rectangle(X, Y, W, H))
                    g.DrawRectangle(New Pen(Color.Gray), New Rectangle(X, Y, W - 1, H))
                    '-------------------------------------------------------------------

                    'Draw Border--------------------------------------------------------
                    g.DrawLine(New Pen(Color.Blue), 3, 2 + Y, W - 4, 2 + Y)
                    g.DrawLine(New Pen(Color.Blue), 2, Y + 3, 2, H + Y - 3)
                    g.DrawLine(New Pen(Color.Blue), 3, Y + H - 2, W - 4, Y + H - 2)
                    g.DrawLine(New Pen(Color.Blue), W - 3, Y + 3, W - 3, H + Y - 3)
                    '-------------------------------------------------------------------

                    'Draw Arrow---------------------------------------------------------
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 1, (H \ 2) - 2, (W \ 2) + 1, (H \ 2) - 2)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 2, (H \ 2) - 1, (W \ 2) + 2, (H \ 2) - 1)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 3, (H \ 2), (W \ 2) - 1, (H \ 2))
                    g.DrawLine(New Pen(Color.Black), (W \ 2) + 1, (H \ 2), (W \ 2) + 3, (H \ 2))
                    g.DrawLine(New Pen(Color.Black), (W \ 2) + 2, (H \ 2) + 1, (W \ 2) + 4, (H \ 2) + 1)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 4, (H \ 2) + 1, (W \ 2) - 2, (H \ 2) + 1)
                    '-------------------------------------------------------------------

                    'Reset Settings-----------------------
                    Info(5).X = X : Info(5).Y = Y : Info(5).H = H : Info(5).W = W : Info(5).X2 = (X + W) : Info(5).Y2 = (Y + H) : Info(5).Name = "Arrow Up"
                    '-------------------------------------


            End Select

        End Sub

        ''' <summary>Method for drawing the the scrollbar thumb.</summary>
        Public Overridable Sub Draw_Thumb(ByVal X As Integer, ByVal Y As Integer, ByVal W As Integer, ByVal H As Integer, ByVal EventOf As ControlEvents)

            'Check to see if Height is greater than 0-----
            If H = 0 Then

                'Reset Settings-----------------------
                Info(1).X = X : Info(1).Y = Y : Info(1).H = H : Info(1).W = W : Info(1).X2 = (X + W) : Info(1).Y2 = (Y + H) : Info(1).Name = "Thumb"
                '-------------------------------------
                Exit Sub
            End If

            '---------------------------------------------

            'Get Control Graphics-----------------
            Dim g As Graphics = Me.CreateGraphics
            g.SmoothingMode = SmoothingMode.None
            '-------------------------------------

            Select Case EventOf

                Case ControlEvents.None

                    'Draw Rectangle-----------------------------------------------------
                    g.FillRectangle(New SolidBrush(Color.White), New Rectangle(X, Y, W, H))
                    g.DrawRectangle(New Pen(Color.Gray), New Rectangle(X, Y, W - 1, H))
                    '-------------------------------------------------------------------

                    'Draw Border--------------------------------------------------------
                    g.DrawLine(New Pen(Color.LightBlue), 3, 2 + Y, W - 4, 2 + Y)
                    g.DrawLine(New Pen(Color.LightBlue), 2, Y + 3, 2, H + Y - 3)
                    g.DrawLine(New Pen(Color.LightBlue), 3, Y + H - 2, W - 4, Y + H - 2)
                    g.DrawLine(New Pen(Color.LightBlue), W - 3, Y + 3, W - 3, H + Y - 3)
                    '-------------------------------------------------------------------

                    'Draw Thumb Indent-------------------
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 3, (H \ 2) + Y - 2, (W \ 2) + 2, (H \ 2) + Y - 2)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 3, (H \ 2) + Y, (W \ 2) + 2, (H \ 2) + Y)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 3, (H \ 2) + Y + 2, (W \ 2) + 2, (H \ 2) + Y + 2)
                    '------------------------------------

                    'Reset Settings-----------------------
                    Info(1).X = X : Info(1).Y = Y : Info(1).H = H : Info(1).W = W : Info(1).X2 = (X + W) : Info(1).Y2 = (Y + H) : Info(1).Name = "Thumb"
                    '-------------------------------------

                Case ControlEvents.OnMouseDown

                    'Draw Rectangle-----------------------------------------------------
                    g.FillRectangle(New SolidBrush(Color.LightBlue), New Rectangle(X, Y, W, H))
                    g.DrawRectangle(New Pen(Color.Gray), New Rectangle(X, Y, W - 1, H))
                    '-------------------------------------------------------------------

                    'Draw Border--------------------------------------------------------
                    g.DrawLine(New Pen(Color.Blue), 3, 2 + Y, W - 4, 2 + Y)
                    g.DrawLine(New Pen(Color.Blue), 2, Y + 3, 2, H + Y - 3)
                    g.DrawLine(New Pen(Color.Blue), 3, Y + H - 2, W - 4, Y + H - 2)
                    g.DrawLine(New Pen(Color.Blue), W - 3, Y + 3, W - 3, H + Y - 3)
                    '-------------------------------------------------------------------

                    'Draw Thumb Indent-------------------
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 3, (H \ 2) + Y - 2, (W \ 2) + 2, (H \ 2) + Y - 2)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 3, (H \ 2) + Y, (W \ 2) + 2, (H \ 2) + Y)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 3, (H \ 2) + Y + 2, (W \ 2) + 2, (H \ 2) + Y + 2)
                    '------------------------------------

                    'Reset Settings-----------------------
                    Info(1).X = X : Info(1).Y = Y : Info(1).H = H : Info(1).W = W : Info(1).X2 = (X + W) : Info(1).Y2 = (Y + H) : Info(1).Name = "Thumb"
                    '-------------------------------------

                Case ControlEvents.OnMouseMove

                    'Draw Rectangle-----------------------------------------------------
                    g.FillRectangle(New SolidBrush(Color.White), New Rectangle(X, Y, W, H))
                    g.DrawRectangle(New Pen(Color.Gray), New Rectangle(X, Y, W - 1, H))
                    '-------------------------------------------------------------------

                    'Draw Border--------------------------------------------------------
                    g.DrawLine(New Pen(Color.Blue), 3, 2 + Y, W - 4, 2 + Y)
                    g.DrawLine(New Pen(Color.Blue), 2, Y + 3, 2, H + Y - 3)
                    g.DrawLine(New Pen(Color.Blue), 3, Y + H - 2, W - 4, Y + H - 2)
                    g.DrawLine(New Pen(Color.Blue), W - 3, Y + 3, W - 3, H + Y - 3)
                    '-------------------------------------------------------------------

                    'Draw Thumb Indent-------------------
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 3, (H \ 2) + Y - 2, (W \ 2) + 2, (H \ 2) + Y - 2)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 3, (H \ 2) + Y, (W \ 2) + 2, (H \ 2) + Y)
                    g.DrawLine(New Pen(Color.Black), (W \ 2) - 3, (H \ 2) + Y + 2, (W \ 2) + 2, (H \ 2) + Y + 2)
                    '------------------------------------

                    'Reset Settings-----------------------
                    Info(1).X = X : Info(1).Y = Y : Info(1).H = H : Info(1).W = W : Info(1).X2 = (X + W) : Info(1).Y2 = (Y + H) : Info(1).Name = "Thumb"
                    '-------------------------------------


            End Select

        End Sub

        ''' <summary>Method for drawing the shaft above the scrollbar thumb.</summary>
        Public Overridable Sub Draw_Shaft_Above(ByVal X As Integer, ByVal Y As Integer, ByVal W As Integer, ByVal H As Integer, ByVal EventOf As ControlEvents)

            'Get Control Graphics-----------------
            Dim g As Graphics = Me.CreateGraphics
            g.SmoothingMode = SmoothingMode.None
            '-------------------------------------

            Select Case EventOf

                Case ControlEvents.None

                    'Draw Thumb---------------------------
                    g.FillRectangle(New SolidBrush(Color.LightCyan), New Rectangle(X, Y, W, H))
                    '-------------------------------------

                    'Reset Settings-----------------------
                    Info(2).X = X : Info(2).Y = Y : Info(2).H = H : Info(2).W = W : Info(2).X2 = (X + W) : Info(2).Y2 = (Y + H) : Info(2).Name = "Shaft Above"
                    '-------------------------------------

                Case ControlEvents.OnMouseMove

                    'Draw Thumb---------------------------
                    g.FillRectangle(New SolidBrush(Color.LightCyan), New Rectangle(X, Y, W, H))
                    '-------------------------------------

                    'Reset Settings-----------------------
                    Info(2).X = X : Info(2).Y = Y : Info(2).H = H : Info(2).W = W : Info(2).X2 = (X + W) : Info(2).Y2 = (Y + H) : Info(2).Name = "Shaft Above"
                    '-------------------------------------

                Case ControlEvents.OnMouseDown

                    'Draw Thumb---------------------------
                    g.FillRectangle(New SolidBrush(Color.Black), New Rectangle(X, Y, W, H))
                    '-------------------------------------

                    'Reset Settings-----------------------
                    Info(2).X = X : Info(2).Y = Y : Info(2).H = H : Info(2).W = W : Info(2).X2 = (X + W) : Info(2).Y2 = (Y + H) : Info(2).Name = "Shaft Above"
                    '-------------------------------------

            End Select

        End Sub

        ''' <summary>Method for drawing the shaft below the scrollbar thumb.</summary>
        Public Overridable Sub Draw_Shaft_Below(ByVal X As Integer, ByVal Y As Integer, ByVal W As Integer, ByVal H As Integer, ByVal EventOf As ControlEvents)

            'Get Control Graphics-----------------
            Dim g As Graphics = Me.CreateGraphics
            g.SmoothingMode = SmoothingMode.None
            '-------------------------------------

            Select Case EventOf

                Case ControlEvents.None

                    'Draw Thumb---------------------------
                    g.FillRectangle(New SolidBrush(Color.LightGoldenrodYellow), New Rectangle(X, Y, W, H))
                    '-------------------------------------

                    'Reset Settings-----------------------
                    Info(3).X = X : Info(3).Y = Y : Info(3).H = H : Info(3).W = W : Info(3).X2 = (X + W) : Info(3).Y2 = (Y + H) : Info(3).Name = "Shaft Below"
                    '-------------------------------------

                Case ControlEvents.OnMouseMove

                    'Draw Thumb---------------------------
                    g.FillRectangle(New SolidBrush(Color.LightGoldenrodYellow), New Rectangle(X, Y, W, H))
                    '-------------------------------------

                    'Reset Settings-----------------------
                    Info(3).X = X : Info(3).Y = Y : Info(3).H = H : Info(3).W = W : Info(3).X2 = (X + W) : Info(3).Y2 = (Y + H) : Info(3).Name = "Shaft Below"
                    '-------------------------------------

                Case ControlEvents.OnMouseDown

                    'Draw Thumb---------------------------
                    g.FillRectangle(New SolidBrush(Color.Black), New Rectangle(X, Y, W, H))
                    '-------------------------------------

                    'Reset Settings-----------------------
                    Info(3).X = X : Info(3).Y = Y : Info(3).H = H : Info(3).W = W : Info(3).X2 = (X + W) : Info(3).Y2 = (Y + H) : Info(3).Name = "Shaft Below"
                    '-------------------------------------

            End Select

        End Sub

        ''' <summary>Method for retrieving the mouse position relative to the control.</summary>
        Private Function CursorPOS() As Integer

            'Get Cursor Location-----------------
            Dim CursorLocation As Point = Me.PointToClient(Cursor.Position)
            '------------------------------------

            'Check to make sure control has something------------------
            If UBound(Info) = 0 Then Return 0 : Exit Function
            '----------------------------------------------------------

            Dim i As Integer = 0
            For i = 0 To UBound(Info)

                'Check to see if cursor is over area-------------------
                If CursorLocation.X >= Info(i).X And CursorLocation.X < Info(i).X2 And CursorLocation.Y >= Info(i).Y And CursorLocation.Y <= Info(i).Y2 Then
                    Return i
                    Exit Function
                End If
                '------------------------------------------------------

            Next

            'Return Nothing------
            Return 0
            '--------------------

        End Function

        ''' <summary>Method for moving the thumb downwards based on scrollbar shaft being pressed.</summary>
        Private Sub Move_ShaftDown()

            Dim NewPos As Integer

            If Me.Value < Me.Maximum Then

                If Me.Value + Me.LargeChange > Me.Maximum Then
                    Me.Value = Me.Maximum
                Else
                    Me.Value += Me.LargeChange
                End If

                If Me.Value = Me.Maximum Then

                    NewPos = Info(4).Y - Info(1).H - 1

                    Draw_Thumb(Info(1).X, NewPos, Info(1).W, Info(1).H, ControlEvents.OnMouseDown)
                    Draw_Shaft_Above(0, 17, Me.Width, Info(1).Y - 17, ControlEvents.None)
                    Draw_Shaft_Below(0, NewPos + Info(1).H + 1, Me.Width, (Me.Height - 18) - (Info(1).Y + Info(1).H), ControlEvents.OnMouseDown)
                    '--------------------------------------------------

                Else

                    NewPos = ((Me.Value) / (Me.Maximum)) * (Info(4).Y - Info(1).H - 17) + 17

                    Draw_Thumb(Info(1).X, NewPos, Info(1).W, Info(1).H, ControlEvents.OnMouseDown)
                    Draw_Shaft_Above(0, 17, Me.Width, Info(1).Y - 17, ControlEvents.None)
                    Draw_Shaft_Below(0, NewPos + Info(1).H + 1, Me.Width, (Me.Height - 18) - (Info(1).Y + Info(1).H), ControlEvents.OnMouseDown)
                    '--------------------------------------------------

                End If

                RaiseEvent Scroll()

            End If

        End Sub

        ''' <summary>Method for moving the thumb downwards based on arrow button down being clicked.</summary>
        Private Sub Move_ThumbDown()

            Dim NewPos As Integer

            If Me.Value < Me.Maximum Then

                If Me.Value + Me.SmallChange > Me.Maximum Then
                    Me.Value = Me.Maximum
                Else
                    Me.Value += Me.SmallChange
                End If

                If Me.Value = Me.Maximum Then

                    NewPos = Info(4).Y - Info(1).H - 1

                    Draw_Thumb(Info(1).X, NewPos, Info(1).W, Info(1).H, ControlEvents.None)
                    Draw_Shaft_Above(0, 17, Me.Width, Info(1).Y - 17, ControlEvents.None)
                    Draw_Shaft_Below(0, NewPos + Info(1).H + 1, Me.Width, (Me.Height - 18) - (Info(1).Y + Info(1).H), ControlEvents.None)
                    '--------------------------------------------------

                Else

                    NewPos = ((Me.Value) / (Me.Maximum)) * (Info(4).Y - Info(1).H - 17) + 17

                    Draw_Thumb(Info(1).X, NewPos, Info(1).W, Info(1).H, ControlEvents.None)
                    Draw_Shaft_Above(0, 17, Me.Width, Info(1).Y - 17, ControlEvents.None)
                    Draw_Shaft_Below(0, NewPos + Info(1).H + 1, Me.Width, (Me.Height - 18) - (Info(1).Y + Info(1).H), ControlEvents.None)
                    '--------------------------------------------------

                End If

                'Scroll-------------
                RaiseEvent Scroll()
                '-------------------

            End If

        End Sub

        ''' <summary>Method for moving the thumb upwards based on scrollbar shaft being pressed.</summary>
        Private Sub Move_ShaftUp()

            Dim NewPos As Integer

            If Me.Value > 0 Then

                If Me.Value - Me.LargeChange < 0 Then
                    Me.Value = 0
                Else
                    Me.Value -= Me.LargeChange
                End If

                If Me.Value = 0 Then

                    NewPos = 17

                    Draw_Thumb(Info(1).X, NewPos, Info(1).W, Info(1).H, ControlEvents.OnMouseDown)
                    Draw_Shaft_Above(0, 17, Me.Width, 0, ControlEvents.OnMouseDown)
                    Draw_Shaft_Below(0, NewPos + Info(1).H + 1, Me.Width, (Me.Height - 18) - (Info(1).Y + Info(1).H), ControlEvents.None)
                    '--------------------------------------------------

                Else

                    NewPos = ((Me.Value) / (Me.Maximum)) * (Info(4).Y - Info(1).H - 17) + 17

                    Draw_Thumb(Info(1).X, NewPos, Info(1).W, Info(1).H, ControlEvents.OnMouseDown)
                    Draw_Shaft_Above(0, 17, Me.Width, Info(1).Y - 17, ControlEvents.OnMouseDown)
                    Draw_Shaft_Below(0, NewPos + Info(1).H + 1, Me.Width, (Me.Height - 18) - (Info(1).Y + Info(1).H), ControlEvents.None)
                    '--------------------------------------------------

                End If

                'Scroll-------------
                RaiseEvent Scroll()
                '-------------------

            End If

        End Sub

        ''' <summary>Method for moving the thumb upwards based on arrow button up being clicked.</summary>
        Private Sub Move_ThumbUp()

            Dim NewPos As Integer

            If Me.Value > 0 Then

                If Me.Value - Me.SmallChange < 0 Then
                    Me.Value = 0
                Else
                    Me.Value -= Me.SmallChange
                End If

                If Me.Value = 0 Then

                    NewPos = 17

                    Draw_Thumb(Info(1).X, NewPos, Info(1).W, Info(1).H, ControlEvents.None)
                    Draw_Shaft_Above(0, 17, Me.Width, 0, ControlEvents.None)
                    Draw_Shaft_Below(0, NewPos + Info(1).H + 1, Me.Width, (Me.Height - 18) - (Info(1).Y + Info(1).H), ControlEvents.None)
                    '--------------------------------------------------

                Else

                    NewPos = ((Me.Value) / (Me.Maximum)) * (Info(4).Y - Info(1).H - 17) + 17

                    Draw_Thumb(Info(1).X, NewPos, Info(1).W, Info(1).H, ControlEvents.None)
                    Draw_Shaft_Above(0, 17, Me.Width, Info(1).Y - 17, ControlEvents.None)
                    Draw_Shaft_Below(0, NewPos + Info(1).H + 1, Me.Width, (Me.Height - 18) - (Info(1).Y + Info(1).H), ControlEvents.None)
                    '--------------------------------------------------

                End If

                'Scroll-------------
                RaiseEvent Scroll()
                '-------------------

            End If

        End Sub

        ''' <summary>Method for moving the thumb based on sliding it.</summary>
        Private Sub ThumbMover()

            'Get Cursor Location-----------------
            Dim e As Point = Me.PointToClient(Cursor.Position)
            '------------------------------------

            'Get Position relative to where mouse was---------
            Dim NewPOS As Integer = e.Y + Info(1).Y - MeterY
            '-------------------------------------------------

            If NewPOS <= 18 Then
                If Info(1).Y <> 17 Then
                    Draw_Thumb(0, 17, Me.Width, Info(1).H, ControlEvents.OnMouseDown)
                    Draw_Shaft_Above(0, 0, Me.Width, 0, ControlEvents.None)
                    Draw_Shaft_Below(0, Info(1).H + 18, Me.Width, Me.Height - 18 - 17 - Info(1).H, ControlEvents.None)
                    Me.Value = Me.Minimum
                    RaiseEvent Scroll()
                End If
                Exit Sub
            End If

            If NewPOS >= Me.Height - Info(1).H - 19 Then
                If Info(1).Y <> Me.Height - Info(1).H - 18 Then
                    Draw_Thumb(Info(1).X, Me.Height - Info(1).H - 18, Info(1).W, Info(1).H, ControlEvents.OnMouseDown)
                    Draw_Shaft_Above(0, 17, Me.Width, Info(1).Y - 17, ControlEvents.None)
                    Draw_Shaft_Below(0, 0, Me.Width, 0, ControlEvents.None)
                    Me.Value = Me.Maximum
                    RaiseEvent Scroll()
                End If
                Exit Sub
            End If

            'Drawing moving Thumb-----------------------------------
            Draw_Thumb(Info(1).X, NewPOS, Info(1).W, Info(1).H, ControlEvents.OnMouseDown)
            Draw_Shaft_Above(0, 17, Me.Width, Info(1).Y - 17, ControlEvents.None)
            Draw_Shaft_Below(0, NewPOS + Info(1).H + 1, Me.Width, Me.Height - 18 - NewPOS - Info(1).H, ControlEvents.None)
            MeterY = e.Y
            '-------------------------------------------------------

            'Make New Value-----------------------------------------
            Dim ScrollingArea As Integer = Me.Height - 34 - Info(1).H
            Me.Value = (Me.Maximum / ScrollingArea) * ((Info(1).Y - 17) - 1)
            '-------------------------------------------------------

            'Scroll-------------
            RaiseEvent Scroll()
            '-------------------

        End Sub

        ''' <summary>Method for usercontrol resize.</summary>
        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)

            If Me.DesignMode = True Then

                'Draw Control-------
                Draw()
                '-------------------

            End If

        End Sub

        ''' <summary>Method for usercontrol paint.</summary>
        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

            If Me.DesignMode = True Then

                'Draw Control-------
                Draw()
                '-------------------

            Else

                'Redraw the Control--------
                ReDraw()
                '--------------------------

            End If

        End Sub

        ''' <summary>Method for timing thumb upwards movement.</summary>
        Private Sub PageUp_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageUp.Tick

            If ShaftMovingUp = True Then

                'Start Moving from Shaft----
                Move_ShaftUp()
                '---------------------------

            Else

                'Start Moving from Thumb----
                Move_ThumbUp()
                '---------------------------

            End If

            'Increase Timer Speed-------
            PageUp.Interval = 50
            '---------------------------

        End Sub

        ''' <summary>Method for timing thumb downwards movement.</summary>
        Private Sub PageDown_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageDown.Tick

            If ShaftMovingDown = True Then

                'Start Moving from Shaft-------
                Move_ShaftDown()
                '------------------------------

            Else

                'Start Moving from Thumb------
                Move_ThumbDown()
                '-----------------------------

            End If

            'Increase Timer Speed-------
            PageDown.Interval = 50
            '---------------------------

        End Sub

#End Region

#Region "Control Event Methods"

        ''' <summary>Method for usercontrol mousedown event.</summary>
        Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)

            'Locate which control cursor is located above---
            Dim CheckValue As Integer = CursorPOS()
            '-----------------------------------------------

            Select Case CheckValue

                Case 1 : ThumbMoving = True : Draw_Thumb(Info(CheckValue).X, Info(CheckValue).Y, Info(CheckValue).W, Info(CheckValue).H, ControlEvents.OnMouseDown)

                Case 2
                    Draw_Shaft_Above(Info(CheckValue).X, Info(CheckValue).Y, Info(CheckValue).W, Info(CheckValue).H, ControlEvents.OnMouseDown)
                    Move_ShaftUp()
                    ShaftMovingUp = True
                    PageUp.Enabled = True

                Case 3
                    Draw_Shaft_Below(Info(CheckValue).X, Info(CheckValue).Y, Info(CheckValue).W, Info(CheckValue).H, ControlEvents.OnMouseDown)
                    Move_ShaftDown()
                    ShaftMovingDown = True
                    PageDown.Enabled = True

                Case 4
                    Draw_Arrow_Down(Info(CheckValue).X, Info(CheckValue).Y, Info(CheckValue).W, Info(CheckValue).H, ControlEvents.OnMouseDown)
                    Move_ThumbDown()
                    PageDown.Enabled = True

                Case 5
                    Draw_Arrow_Up(Info(CheckValue).X, Info(CheckValue).Y, Info(CheckValue).W, Info(CheckValue).H, ControlEvents.OnMouseDown)
                    Move_ThumbUp()
                    PageUp.Enabled = True

            End Select

            'Set Location of first click----
            MouseDownNow = True
            MeterY = e.Y
            '-------------------------------

        End Sub

        ''' <summary>Method for usercontrol mouseenter event.</summary>
        Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)

        End Sub

        ''' <summary>Method for usercontrol mousehover event.</summary>
        Protected Overrides Sub OnMouseHover(ByVal e As System.EventArgs)

        End Sub

        ''' <summary>Method for usercontrol mouseleave event.</summary>
        Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)

            Select Case CurrentMouseMove

                Case 1 : Draw_Thumb(Info(1).X, Info(1).Y, Info(1).W, Info(1).H, ControlEvents.None)

                Case 2
                    Draw_Thumb(Info(1).X, Info(1).Y, Info(1).W, Info(1).H, ControlEvents.None)
                    Draw_Shaft_Above(Info(2).X, Info(2).Y, Info(2).W, Info(2).H, ControlEvents.None)
                    ShaftMovingUp = False
                    PageUp.Enabled = False
                    PageUp.Interval = 500

                Case 3
                    Draw_Thumb(Info(1).X, Info(1).Y, Info(1).W, Info(1).H, ControlEvents.None)
                    Draw_Shaft_Below(Info(3).X, Info(3).Y, Info(3).W, Info(3).H, ControlEvents.None)
                    ShaftMovingDown = False
                    PageDown.Enabled = False
                    PageDown.Interval = 500

                Case 4
                    Draw_Thumb(Info(1).X, Info(1).Y, Info(1).W, Info(1).H, ControlEvents.None)
                    Draw_Shaft_Above(Info(2).X, Info(2).Y, Info(2).W, Info(2).H, ControlEvents.None)
                    Draw_Shaft_Below(Info(3).X, Info(3).Y, Info(3).W, Info(3).H, ControlEvents.None)
                    Draw_Arrow_Down(Info(4).X, Info(4).Y, Info(4).W, Info(4).H, ControlEvents.None)
                    PageDown.Enabled = False
                    PageDown.Interval = 500

                Case 5
                    Draw_Thumb(Info(1).X, Info(1).Y, Info(1).W, Info(1).H, ControlEvents.None)
                    Draw_Shaft_Above(Info(2).X, Info(2).Y, Info(2).W, Info(2).H, ControlEvents.None)
                    Draw_Shaft_Below(Info(3).X, Info(3).Y, Info(3).W, Info(3).H, ControlEvents.None)
                    Draw_Arrow_Up(Info(5).X, Info(5).Y, Info(5).W, Info(5).H, ControlEvents.None)
                    PageUp.Enabled = False
                    PageUp.Interval = 500

            End Select

            CurrentMouseMove = 0

        End Sub

        ''' <summary>Method for usercontrol mousemove event.</summary>
        Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)

            'Check if thumb moving----------------------------
            If ThumbMoving = True Then ThumbMover() : Exit Sub
            '-------------------------------------------------

            'If Mouse Down = True Then exit this method-------
            If MouseDownNow = True Then Exit Sub
            '-------------------------------------------------

            'Locate which control cursor is located above---
            Dim CheckValue As Integer = CursorPOS()
            '-----------------------------------------------

            'Check to see if mouse is already over location dont redraw--------
            If CheckValue = CurrentMouseMove Then
                Exit Sub
            Else

                Select Case CurrentMouseMove

                    Case 1 : Draw_Thumb(Info(1).X, Info(1).Y, Info(1).W, Info(1).H, ControlEvents.None)
                    Case 4 : Draw_Arrow_Down(Info(4).X, Info(4).Y, Info(4).W, Info(4).H, ControlEvents.None)
                    Case 5 : Draw_Arrow_Up(Info(5).X, Info(5).Y, Info(5).W, Info(5).H, ControlEvents.None)

                End Select

                'Set Current Mouse Move---------
                CurrentMouseMove = CheckValue
                '-------------------------------

                Select Case CheckValue

                    Case 1 : Draw_Thumb(Info(CheckValue).X, Info(CheckValue).Y, Info(CheckValue).W, Info(CheckValue).H, ControlEvents.OnMouseMove)
                    Case 4 : Draw_Arrow_Down(Info(CheckValue).X, Info(CheckValue).Y, Info(CheckValue).W, Info(CheckValue).H, ControlEvents.OnMouseMove)
                    Case 5 : Draw_Arrow_Up(Info(CheckValue).X, Info(CheckValue).Y, Info(CheckValue).W, Info(CheckValue).H, ControlEvents.OnMouseMove)

                End Select

            End If
            '------------------------------------------------------------------

        End Sub

        ''' <summary>Method for usercontrol mouseup event.</summary>
        Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)

            'Turn OFF Moving----------------
            MouseDownNow = False
            ThumbMoving = False
            '-------------------------------

            Select Case CurrentMouseMove

                Case 1 : Draw_Thumb(Info(1).X, Info(1).Y, Info(1).W, Info(1).H, ControlEvents.None)

                Case 2
                    Draw_Thumb(Info(1).X, Info(1).Y, Info(1).W, Info(1).H, ControlEvents.None)
                    Draw_Shaft_Above(Info(2).X, Info(2).Y, Info(2).W, Info(2).H, ControlEvents.None)
                    ShaftMovingUp = False
                    PageUp.Enabled = False
                    PageUp.Interval = 500

                Case 3
                    Draw_Thumb(Info(1).X, Info(1).Y, Info(1).W, Info(1).H, ControlEvents.None)
                    Draw_Shaft_Below(Info(3).X, Info(3).Y, Info(3).W, Info(3).H, ControlEvents.None)
                    ShaftMovingDown = False
                    PageDown.Enabled = False
                    PageDown.Interval = 500

                Case 4
                    Draw_Thumb(Info(1).X, Info(1).Y, Info(1).W, Info(1).H, ControlEvents.None)
                    Draw_Shaft_Above(Info(2).X, Info(2).Y, Info(2).W, Info(2).H, ControlEvents.None)
                    Draw_Shaft_Below(Info(3).X, Info(3).Y, Info(3).W, Info(3).H, ControlEvents.None)
                    Draw_Arrow_Down(Info(4).X, Info(4).Y, Info(4).W, Info(4).H, ControlEvents.None)
                    PageDown.Enabled = False
                    PageDown.Interval = 500

                Case 5
                    Draw_Thumb(Info(1).X, Info(1).Y, Info(1).W, Info(1).H, ControlEvents.None)
                    Draw_Shaft_Above(Info(2).X, Info(2).Y, Info(2).W, Info(2).H, ControlEvents.None)
                    Draw_Shaft_Below(Info(3).X, Info(3).Y, Info(3).W, Info(3).H, ControlEvents.None)
                    Draw_Arrow_Up(Info(5).X, Info(5).Y, Info(5).W, Info(5).H, ControlEvents.None)
                    PageUp.Enabled = False
                    PageUp.Interval = 500

            End Select

            CurrentMouseMove = 0

        End Sub

        ''' <summary>Method for usercontrol keyup event.</summary>
        Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)

            Select Case e.KeyData
                Case Keys.Up, Keys.PageUp
                    Draw_Thumb(Info(1).X, Info(1).Y, Info(1).W, Info(1).H, ControlEvents.None)
                    Draw_Shaft_Above(Info(2).X, Info(2).Y, Info(2).W, Info(2).H, ControlEvents.None)
                    Draw_Shaft_Below(Info(3).X, Info(3).Y, Info(3).W, Info(3).H, ControlEvents.None)
                    Draw_Arrow_Up(Info(5).X, Info(5).Y, Info(5).W, Info(5).H, ControlEvents.None)
                    PageUp.Enabled = False
                    PageUp.Interval = 500

                Case Keys.Down, Keys.PageDown
                    Draw_Thumb(Info(1).X, Info(1).Y, Info(1).W, Info(1).H, ControlEvents.None)
                    Draw_Shaft_Above(Info(2).X, Info(2).Y, Info(2).W, Info(2).H, ControlEvents.None)
                    Draw_Shaft_Below(Info(3).X, Info(3).Y, Info(3).W, Info(3).H, ControlEvents.None)
                    Draw_Arrow_Down(Info(4).X, Info(4).Y, Info(4).W, Info(4).H, ControlEvents.None)
                    PageDown.Enabled = False
                    PageDown.Interval = 500

            End Select
        End Sub

        ''' <summary>Method for usercontrol processdialogkey event.</summary>
        Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean

            Try

                Select Case keyData
                    Case Keys.Up, Keys.PageUp

                        If PageUp.Enabled = False Then
                            Draw_Arrow_Up(Info(5).X, Info(5).Y, Info(5).W, Info(5).H, ControlEvents.OnMouseDown)
                            Move_ThumbUp()
                            PageUp.Enabled = True
                        End If

                    Case Keys.Down, Keys.PageDown
                        If PageDown.Enabled = False Then
                            Draw_Arrow_Down(Info(4).X, Info(4).Y, Info(4).W, Info(4).H, ControlEvents.OnMouseDown)
                            Move_ThumbDown()
                            PageDown.Enabled = True
                        End If

                End Select

                Return True

            Catch ex As Exception

                Return False

            End Try


        End Function

        ''' <summary>Method for usercontrol onmousewheel event.</summary>
        Protected Overrides Sub OnMouseWheel(ByVal e As System.Windows.Forms.MouseEventArgs)

            If e.Delta > 0 Then
                Move_ThumbUp()
            Else
                Move_ThumbDown()
            End If

        End Sub

#End Region

    End Class

    ''' <summary>ControlInfo class is a storage container for fake controls made from gdi+.</summary>
    Public Class ControlInfo

#Region "Private Variables"

        Private P_X As Integer
        Private P_Y As Integer
        Private P_H As Integer
        Private P_W As Integer
        Private P_Name As String
        Private P_X2 As Integer
        Private P_Y2 As Integer

#End Region

        ''' <summary>The left location of the fake control.</summary>
        <CategoryAttribute("Layout"), DescriptionAttribute("The left location of the fake control.")> _
            Public Property X() As Integer
            Get
                Return P_X
            End Get
            Set(ByVal Value As Integer)
                P_X = Value
            End Set
        End Property

        ''' <summary>The top location of the fake control.</summary>
        <CategoryAttribute("Layout"), DescriptionAttribute("The top location of the fake control.")> _
            Public Property Y() As Integer
            Get
                Return P_Y
            End Get
            Set(ByVal Value As Integer)
                P_Y = Value
            End Set
        End Property

        ''' <summary>The height of the fake control.</summary>
        <CategoryAttribute("Layout"), DescriptionAttribute("The height of the fake control.")> _
        Public Property H() As Integer
            Get
                Return P_H
            End Get
            Set(ByVal Value As Integer)
                P_H = Value
            End Set
        End Property

        ''' <summary>The width of the fake control.</summary>
        <CategoryAttribute("Layout"), DescriptionAttribute("The width of the fake control.")> _
        Public Property W() As Integer
            Get
                Return P_W
            End Get
            Set(ByVal Value As Integer)
                P_W = Value
            End Set
        End Property

        ''' <summary>The name of the fake control.</summary>
        <CategoryAttribute("Layout"), DescriptionAttribute("The name of the fake control.")> _
        Public Property Name() As String
            Get
                Return P_Name
            End Get
            Set(ByVal Value As String)
                P_Name = Value
            End Set
        End Property

        ''' <summary>The left + width of the fake control.</summary>
        <CategoryAttribute("Layout"), DescriptionAttribute("The left + width of the fake control.")> _
        Public Property X2() As Integer
            Get
                Return P_X2
            End Get
            Set(ByVal Value As Integer)
                P_X2 = Value
            End Set
        End Property

        ''' <summary>The top + height of the fake control.</summary>
        <CategoryAttribute("Layout"), DescriptionAttribute("The top + height of the fake control.")> _
        Public Property Y2() As Integer
            Get
                Return P_Y2
            End Get
            Set(ByVal Value As Integer)
                P_Y2 = Value
            End Set
        End Property

        ''' <summary>The constructor of the controlinfo class.</summary>
        <CategoryAttribute("Layout"), DescriptionAttribute("The constructor of the controlinfo class.")> _
        Public Sub New()

            P_X = 0
            P_Y = 0
            P_H = 0
            P_W = 0
            P_Name = ""
            P_X2 = 0
            P_Y2 = 0

        End Sub

    End Class

End Namespace

