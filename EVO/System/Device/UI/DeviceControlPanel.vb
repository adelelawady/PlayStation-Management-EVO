Imports System.Threading

Public Class DeviceControlPanel
    Public Device_Handler As DevicesHandler
    Private CanShowLoading As Boolean = True
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        '  MsgBox(frmMain.LoginUser.UserName)
       
        Try
            Dim User As USER = User.GetActiveUser
            Device_Handler = New DevicesHandler(Me, User)
        Catch ex As Exception

        End Try
        Me.CircularProgress1.IsRunning = True
        ' Add any initialization after the InitializeComponent() call.
        Me.DoubleBuffered = True
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        AddHandler Device_Handler.DevicesLoaded, AddressOf devicesLoaded
    End Sub
    Public Sub devicesLoaded()
        Me.Panel1.Visible = False
        Me.Panel1.SendToBack()
    End Sub
    Private Sub flpListBox_Resize(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.MainControlTable1.TableLayoutPanel1.Controls.Count Then
            If MainControlTable1.TableLayoutPanel1.Controls.Count > 7 Then
                MainControlTable1.TableLayoutPanel1.Controls(0).Width = MainControlTable1.TableLayoutPanel1.Width - System.Windows.Forms.SystemInformation.VerticalScrollBarWidth
            Else
                MainControlTable1.TableLayoutPanel1.Controls(0).Width = MainControlTable1.TableLayoutPanel1.Width
            End If

        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        On Error Resume Next
        
        'If CanShowLoading Then
        '    ' CircularProgress1.Location = New Point(MainControlTable1.Size.Width / 2, MainControlTable1.Size.Height / 2)
        '    If Me.CircularProgress1.Value = CircularProgress1.Maximum Then
        '        CircularProgress1.Value = 0
        '    Else
        '        CircularProgress1.Value += 1
        '    End If
        'Else
        '    CircularProgress1.Hide()
        'End If
       
        For Each DV As DeviceControl1 In Me.Device_Handler.DeviceList
            DV.UpdateActive()
        Next
        Me.FlatStatusBar1.Refresh()
        Me.FlatStatusBar1.Text = GetStatueText()

    End Sub
    Public Function GetStatueText() As String
        On Error Resume Next

        Dim ActiveCount As Integer = 0
        Dim disActiveCount As Integer = 0
        Dim DevicesAboutToFinish As Integer = 0
        Dim DevicesFinished As Integer = 0
        Dim TimeTillLastDevieFinish As Integer = 0
        Dim TotalActiveBill As Double = 0
        '   Dim PS3Count As Integer = 0
        '    Dim PS4count As Integer = 0


        For Each DV As DeviceControl1 In Me.Device_Handler.DeviceList
            Dim DC_Device As Device = DV.Device

            If DC_Device.Statue = Device.DeviceStatus.IsActive Then
                ' DC_Device.InitializeData()
                ActiveCount += 1
                TotalActiveBill += (DC_Device.TotalBill)

            Else
                disActiveCount += 1
            End If

            If DC_Device.IsOverTime Then
                DevicesAboutToFinish += 1
            End If
            If DC_Device.IsOver Then
                DevicesFinished += 1
            End If

        Next
        Return String.Format(" " + "مشغول" + ": {0} | " + "فاضي" + " : {1} | " + "اقترب علي الانتهاء" + " : {2} | " + "انتهي" + " : {3}  ||  " + " صافي مجموع الفواتير" + " : {4}", CStr(ActiveCount), CStr(disActiveCount), CStr(CInt(DevicesAboutToFinish)), CStr(CInt(DevicesFinished)), CStr(CInt(TotalActiveBill)))
      
    End Function

    Private Sub DeviceControlPanel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Device_Handler.Initialize()
      
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next

        Me.Device_Handler.LoadDevices()
    End Sub

    Private Sub MainControlTable1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MainControlTable1_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainControlTable1.Load

    End Sub
End Class
