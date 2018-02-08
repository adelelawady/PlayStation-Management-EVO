Imports System.Runtime.InteropServices

Public Class DevicesTableLayout
    '   Private location As Integer = 0
    Private Declare Function ShowScrollBar Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal wBar As Integer, ByVal bShow As Boolean) As Boolean
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Try

            ShowScrollBar(TableLayoutPanel1.Handle, 0, False)
        Catch ex As Exception
        End Try
        MyBase.WndProc(m)
    End Sub
    Public Sub New()
        On Error Resume Next
        ' This call is required by the designer.
        InitializeComponent()
        TableLayoutPanel1.AutoScrollPosition = New Point(0, 0)
        Me.TableLayoutPanel1.HorizontalScroll.Enabled = False
        Me.DoubleBuffered = True
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        '   Me.TableLayoutPanel1.HorizontalScroll.
        '  Me.Panel1.Width =Me.TableLayoutPanel1.VerticalScroll
    End Sub
    Public Sub add(ByVal Control As Object)
        Me.TableLayoutPanel1.Controls.Add(Control)
    End Sub

    Private Sub DevicesTableLayout_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles Me.ControlAdded
        Me.MetroScrollBar1.Minimum = TableLayoutPanel1.VerticalScroll.Minimum
        Me.MetroScrollBar1.Maximum = TableLayoutPanel1.VerticalScroll.Maximum
        Me.MetroScrollBar1.LargeChange = Me.TableLayoutPanel1.VerticalScroll.LargeChange
        Me.MetroScrollBar1.SmallChange = Me.TableLayoutPanel1.VerticalScroll.SmallChange

    End Sub

    Private Sub DevicesTableLayout_ControlRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles Me.ControlRemoved

    End Sub
    Private Sub TableLayOut_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    'Private Sub MainControlTable_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    '    '  Me.SuspendLayout()
    '    ShowScrollBar(TableLayoutPanel1.Handle, 0, False)
    'End Sub


    Private Sub MetroScrollBar1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles MetroScrollBar1.Scroll
        ''  SendMessage(TableLayoutPanel1.Handle, WM_VSCROLL, SB_LINEDOWN, 0)

        ''   TableLayoutPanel1.VerticalScroll.Value = Me.MetroScrollBar1.Value

        ''MsgBox(TableLayoutPanel1.AutoScrollMargin.Height)
        ''  TableLayoutPanel1.Invalidate()
        'If location + 20 < TableLayoutPanel1.VerticalScroll.Maximum Then
        '    location += 20
        '    TableLayoutPanel1.VerticalScroll.Value = location
        'Else
        '    ' If scroll position is above 280 set the position to 280 (MAX)
        '    location = TableLayoutPanel1.VerticalScroll.Maximum
        '    TableLayoutPanel1.AutoScrollPosition = New Point(0, location)
        'End If
        On Error Resume Next

      
     
       
        TableLayoutPanel1.VerticalScroll.Value = Me.MetroScrollBar1.Value
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        On Error Resume Next
    

    End Sub

    Private Sub TableLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub TableLayoutPanel1_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles TableLayoutPanel1.Scroll
        On Error Resume Next

        Me.MetroScrollBar1.Value = TableLayoutPanel1.VerticalScroll.Value
      
       
        MetroScrollBar1.Refresh()
        MetroScrollBar1.Invalidate()
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
