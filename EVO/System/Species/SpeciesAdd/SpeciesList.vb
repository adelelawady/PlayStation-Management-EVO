Imports System.Threading

Public Class SpeciesList
    Dim DB As New DataBaseConnection
    Public SpeciesList As New List(Of SpeciesItem)
    Public Event SPSelectionChanged(ByVal sender As SpeciesItem)
    Public Event ItemClick(ByVal Item As SpeciesItem)
    Public Event ItemDoubleClick(ByVal Item As SpeciesItem)
    Public Event SpAddedToDevice(ByVal Item As species)
    Public Event DevicesLoaded()
    Private trd As Thread
    Delegate Sub AddDeviceCallback(ByVal [Device] As SpeciesItem)
    Public Sub New()


        ' This call is required by the designer.
        InitializeComponent()
        Control.CheckForIllegalCrossThreadCalls = False
     

    End Sub
    Public Sub UpdateListByType(ByVal typeID As Integer)
        
     
        Me.TableLayoutPanel1.Controls.Clear()
        Me.TableLayoutPanel1.Refresh()
        Me.TableLayoutPanel1.Update()
        Dim Sql = "SELECT * FROM `species` WHERE `Type` ='" + CStr(typeID) + "'"
        Dim Row As DataRowCollection = DB.executeSQL(Sql)

        For Each RD As DataRow In Row
            Dim Sp As New species(RD(0))

            Add(Sp)

        Next
       
    End Sub
    Private currentDv As SpeciesItem = Nothing


    Public Sub Add(ByVal tbid As species)
        Try

     

            '  Dim DV As species = New species(tbid)
            Dim c As New SpeciesItem(tbid)
            c.Tag = tbid
            currentDv = c
            If SpeciesList.Count = 0 Then
                SelectionChanged(c)
            End If
            SpeciesList.Add(c)
            With c
                ' Assign an auto generated name

                .Name = "item" & Me.TableLayoutPanel1.Controls.Count + 1
                '  .Margin = New Padding(0)
            End With
            ' To check when the selection is changed
            AddHandler c.SelectionChanged, AddressOf SelectionChanged
            AddHandler c.Click, AddressOf ItemClicked
            AddHandler c.DoubleClick, AddressOf ItemDoubleClicked
            '  Application.DoEvents()
            'Dim Co As New Controler()
            'Co.intiData(c.Table)
            'c.StartDate = Co.StartDate
            Dim AddThrd As Thread = New Thread( _
        New ThreadStart(AddressOf Me.AddDevice))

            AddThrd.Start()

            ' SetupAnchors()
        Catch ex As Exception
            LOG.[LOG](ex) ' MsgBox(ex.StackTrace)
        End Try

    End Sub
    Private Sub AddDevice()
        Me.AddTo(currentDv)
    End Sub
    Private Sub AddTo(ByVal [Device] As SpeciesItem)
        On Error Resume Next
        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If TableLayoutPanel1.InvokeRequired Then
            Dim d As New AddDeviceCallback(AddressOf AddTo)
            TableLayoutPanel1.Invoke(d, New Object() {[Device]})

        Else
            ''  Me.textBox1.Text = [Text]
            '[Device].Refresh()

            TableLayoutPanel1.Controls.Add([Device])
            ' EffectualProgressBarBlue1.Value += 1
        End If
    End Sub

    'Private Sub SetupAnchors()
    '    If TableLayoutPanel1.Controls.Count > 0 Then

    '        For i = 0 To TableLayoutPanel1.Controls.Count - 1
    '            Dim c As Control = TableLayoutPanel1.Controls(i)

    '            If i = 0 Then

    '                c.Anchor = AnchorStyles.Left + AnchorStyles.Top

    '                If TableLayoutPanel1.Controls.Count > 7 Then

    '                    c.Width = TableLayoutPanel1.Width - System.Windows.Forms.SystemInformation.VerticalScrollBarWidth

    '                Else
    '                    c.Width = TableLayoutPanel1.Width
    '                End If

    '            Else

    '                c.Anchor = AnchorStyles.Left + AnchorStyles.Right

    '            End If

    '        Next

    '    End If
    'End Sub

    Public mLastSelected As SpeciesItem = Nothing
    Private Sub SelectionChanged(ByVal sender As SpeciesItem)
        On Error Resume Next
        '  MsgBox(DirectCast(sender, DeviceControl1).Device.Id)
        RaiseEvent SPSelectionChanged(sender)
        If mLastSelected IsNot Nothing Then
            mLastSelected.Selected = False
        End If
        mLastSelected = sender
        mLastSelected.Selected = True
    End Sub
    Private Sub ItemClicked(ByVal sender As Object, ByVal e As System.EventArgs)
        RaiseEvent ItemClick(mLastSelected)



        '     MsgBox(mLastSelected.Device.Id)

        'Dim DV As DeviceControl1 = DirectCast(Me.flpListBox.Controls(flpListBox.Controls.IndexOfKey(sender.name)), DeviceControl1)
  


    End Sub
    Private Sub ItemDoubleClicked(ByVal sender As Object, ByVal e As System.EventArgs)
        RaiseEvent ItemDoubleClick(mLastSelected)
        Dim Sp As species = DirectCast(mLastSelected.Tag, species)
        RaiseEvent SpAddedToDevice(Sp)
    End Sub

   
    Private Sub TableLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub
End Class
