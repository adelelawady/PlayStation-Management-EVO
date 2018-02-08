Public Class UserShiftViewer
    Dim ls As Date = Nothing
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DateTimeInput4.Value = Date.Now.Date.AddHours(2)
        Me.DateTimeInput5.Value = Date.Now.AddHours(14)
        ls=Date.Now 
        
    End Sub

    Dim timeFormat As String = "yyyy-MM-dd"
    Dim LastLoginSTR As String = "LASTLOGIN<br/><font color=""#ED1C24""><b><font color=""#22B14C"">{0}</font></b></font>"
    Public Sub LoadUserShift()
        On Error Resume Next

        Dim TotalPaid, TotalBill As Double


        Dim User As USER = User.GetActiveUser

        Dim Db As New DataBaseConnection
        Me.DataGridViewX1.Rows.Clear()
        Dim Sql As String = "SELECT * FROM `deviceslog` WHERE `deviceslog`.`User`='" + User.UserName + "' AND " + "`deviceslog`.`StartDate` >= '" + Me.DateTimeInput4.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND `deviceslog`.`EndDate` < '" + Me.DateTimeInput5.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' " + " AND Deleted='0' AND `InActive` LIKE 'false' ORDER BY `EndDate` DESC"
        '  MsgBox(Sql)
        Dim dr As DataRowCollection = Db.executeSQL(Sql)
        For Each drow As DataRow In dr
            Dim dlog As New Device.DeviceLOG(drow(0))
            '     MsgBox(dlog.Name)
            '      Dim Sdate As Date = Date.Parse(dlog.StartDate)

            Dim Enddate As Date = Date.Parse(dlog.EndDate)

            Dim SinceDuration As TimeSpan = Date.Now.Subtract(Enddate)

            Dim TotalStringSince = String.Format("{0}H|{1}M", SinceDuration.Hours, SinceDuration.Minutes)

            Dim ChiledNode As Object() = New Object() {drow(0), dlog.Name, dlog.LogTotalbill, drow(18), TotalStringSince}
            ' Me.DataGridViewX1.Rows.Add(ChiledNode)
            Me.DataGridViewX1.Rows.Add(ChiledNode)

            TotalPaid += CInt(drow(18))
            TotalBill += CInt(dlog.LogTotalbill)
        Next
        Me.FlatLabel8.Text = User.UserName
        Me.FlatLabel12.Text = TotalBill.ToString
        Me.FlatLabel13.Text = TotalPaid.ToString
        Me.DataGridViewX1.Refresh()
        Me.DataGridViewX1.Invalidate()

    End Sub

    Private Sub UserShiftViewer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim List As DataGridViewRow() = LoadUserShift()
        'Me.DataGridViewX1.Rows.AddRange(List)

    End Sub

    Private Sub DateTimeInput4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimeInput4.ValueChanged
        LoadUserShift()

    End Sub

    Private Sub DateTimeInput5_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimeInput5.ValueChanged
        LoadUserShift()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim span As TimeSpan = Date.Now.Subtract(ls)
        Me.LabelItem1.Text = String.Format(LastLoginSTR, span.Hours.ToString + " H | " + span.Minutes.ToString + " M")
    End Sub
End Class
