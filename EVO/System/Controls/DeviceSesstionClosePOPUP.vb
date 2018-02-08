Public Class DeviceSesstionClosePOPUP
    Private device As Device
    Private totalPaidBill As Double = 0
    Public Sub New(ByVal dv As Device)

        ' This call is required by the designer.
        InitializeComponent()
        Me.Text = "[Device] " + dv.Name + " PaidBillUpdate"
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        device = dv
        Me.device.SetTotalBillIntialized()
        ' Add any initialization after the InitializeComponent() call.
        Me.totalPaidBill = device.PaidBill
        LabelItem1.Text += device.Bill.ToString
        LabelItem2.Text += device.PlayStationBill.ToString
        LabelItem3.Text += device.TotalBill.ToString
        LabelItem4.Text += device.PaidBill.ToString
    End Sub
    Dim viv As Boolean = False

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        If Not viv Then
            Me.DoubleInput1.Visible = True
            viv = True
        Else
            If Me.DoubleInput1.Value > 0 Then
                device.PaidBill = Me.DoubleInput1.Value
                Me.DialogResult = Windows.Forms.DialogResult.OK

                'device.CloseSesstion()
                Me.Close()
            Else
                MsgBox("Enter PaidBill")
            End If
        End If

    End Sub

    Private Sub DeviceSesstionClosePOPUP_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult = Windows.Forms.DialogResult.Cancel Then
            device.PaidBill = totalPaidBill
        End If
    End Sub

    Private Sub DeviceSesstionClosePOPUP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        Me.device.SetTotalBillIntialized()

        device.PaidBill = Me.device.TotalBill
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class