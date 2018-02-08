Imports DevComponents.Editors

Public Class ADDRESRVATION
    Public sdate As Date
    Public Edate As Date
    Public Sub New(ByVal sd As Date, ByVal ed As Date)


        ' This call is required by the designer.
        InitializeComponent()
        sdate = sd
        Edate = ed
        ' Add any initialization after the InitializeComponent() call.
        initlziDevices()
    End Sub
    Public Sub initlziDevices()

        ComboBoxEx1.Items.Clear()

        Dim sql As String = "SELECT `id`,`Name` FROM `devices`"
        Dim Rows As DataRowCollection = (New DataBaseConnection).executeSQL(sql)
        ' MsgBox(Rows.Count)
        For Each DR As DataRow In Rows
            ' MsgBox(sdate.ToString)
            ' If Not (CStr(DR(2)) = "0") Then
            Dim Schedule_Object As ScheduleObject = ScheduleObject.CheckSchuduleDateExsits(DR(0), sdate, Edate)
            If Schedule_Object Is Nothing Then
                ' If Not DR(2) = 0 Then
                Dim CBI As New ComboItem(CStr(DR(1)))
                CBI.Tag = CStr(DR(0))
                ComboBoxEx1.Items.Add(CBI)
                'End If

            End If
            'End If
        Next
        ComboBoxEx1.Refresh()

    End Sub
    Private Sub ADDRESRVATION_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' initlziDevices()
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub DateTimeInput1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'DateTimeInput2.Value = DateTimeInput1.Value
    End Sub

    Private Sub ComboBoxEx1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxEx1.SelectedIndexChanged

    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        Me.Close()
    End Sub
End Class