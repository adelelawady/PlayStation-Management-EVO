Public Class SpeciesControllerPanel

    Private Sub SpeciesControllerPanelX_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler TypeTabPanel1.typeHandler.SelectionChanged, AddressOf SelectedTabChanged
        SelectedTabChanged()
    End Sub

    Private Sub CButton2_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CButton2.ClickButtonArea
        TextBoxX1.Text = ""
        ButtonX1.Text = "Submit"
        PageSlider1.SelectedPageIndex = 1
        ISTYPEUPDATE = False
    End Sub

    Private Sub PageSlider1_DragLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageSlider1.DragLeave

    End Sub
    Public Sub SelectedTabChanged()
        On Error Resume Next

        SpeciesList1.UpdateListByType(TypeTabPanel1.typeHandler.Selected.Type.Id)
    End Sub
    Private ISTYPEUPDATE As Boolean = False
    Private ISSpeciesUPDATE As Boolean = False
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click

        If Not TextBoxX1.Text = "" Then
            If Not ISTYPEUPDATE Then
                If SpeciesType.InsertSpecieType(TextBoxX1.Text) Then
                    TextBoxX1.Text = ""
                    PageSlider1.SelectedPageIndex = 3
                    updatetyps("Add")
                Else
                    MsgBox("Faild TO Submit Type")
                    PageSlider1.SelectedPageIndex = 0
                End If
            Else
                ISTYPEUPDATE = False
                TypeTabPanel1.typeHandler.Selected.Type.Name = TextBoxX1.Text
                If TypeTabPanel1.typeHandler.Selected.Type.Update() Then
                    PageSlider1.SelectedPageIndex = 3
                    updatetyps("Update")
                End If
            End If


        Else
            MsgBox("Enter Type Name")
        End If
        ButtonX1.Text = "Submit"

    End Sub
    Public Sub updatetyps(ByVal Action As String)
        If Action = "Delete" Then
            TypeTabPanel1.typeHandler.RefreshList()
        ElseIf Action = "Add" Then
            TypeTabPanel1.typeHandler.RefreshList()
        ElseIf Action = "Update" Then
            TypeTabPanel1.typeHandler.RefreshList(TypeTabPanel1.typeHandler.Selected)
        End If


        TypeTabPanel1.typeHandler.intiGroupBoxList(TypeTabPanel1.Bar1)
        TypeTabPanel1.Update()
        TypeTabPanel1.Refresh()
    End Sub
    Public Sub updateSp(ByVal Action As String)
        'MsgBox(Action)
        'SpeciesList1
        ' MsgBox(TypeTabPanel1.typeHandler.Selected.Id)
        SpeciesList1.UpdateListByType(TypeTabPanel1.typeHandler.Selected.Id)
        SpeciesList1.Update()
        SpeciesList1.Refresh()
    End Sub
    Private Sub PageSlider1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageSlider1.MouseEnter

    End Sub

    Private Sub PageSlider1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageSlider1.MouseLeave
        PageSlider1.SelectedPageIndex = 0

    End Sub

    Private Sub CButton4_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CButton4.ClickButtonArea

        On Error Resume Next
        TypeTabPanel1.typeHandler.Selected.Type.Delete()
        updatetyps("Delete")
    End Sub

    Private Sub TextBoxX1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxX1.KeyPress
        If e.KeyChar = CChar(ChrW(Keys.Enter)) Then
            ButtonX1.PerformClick()
        End If
    End Sub

    Private Sub TextBoxX1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxX1.KeyUp

    End Sub

    Private Sub CButton3_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CButton3.ClickButtonArea
        'TextBoxX1.Text = ""
        On Error Resume Next

        ISTYPEUPDATE = True
        ButtonX1.Text = "Update"
        TextBoxX1.Text = TypeTabPanel1.typeHandler.Selected.Type.Name
        PageSlider1.SelectedPageIndex = 1
        ' updatetyps()
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        If Not TextBoxX2.Text = "" Then
            If Not ISSpeciesUPDATE Then
                If species.InsertSpecies(TextBoxX2.Text, DoubleInput1.Value, TypeTabPanel1.typeHandler.Selected.Type) = 1 Then
                    TextBoxX2.Text = ""
                    PageSlider1.SelectedPageIndex = 3
                    ' updateSp("Add")
                    '   Dim x As New species (
                    ' SpeciesList1.Add(5)
                    Application.DoEvents()
                    SelectedTabChanged()
                Else

                    MsgBox("Faild TO Submit Species")
                    PageSlider1.SelectedPageIndex = 0
                End If
            Else
                ISSpeciesUPDATE = False
                SpeciesList1.mLastSelected.Specie.Name = TextBoxX2.Text
                SpeciesList1.mLastSelected.Specie.Price = CDbl(DoubleInput1.Value)

                If SpeciesList1.mLastSelected.Specie.UpdateSpecies = 1 Then
                    PageSlider1.SelectedPageIndex = 3
                    Application.DoEvents()
                    SelectedTabChanged()
                End If

            End If

        Else
            MsgBox("Enter Species Name")
        End If
    End Sub

    Private Sub CButton1_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CButton1.ClickButtonArea
        On Error Resume Next

        TextBoxX2.Text = ""
        ButtonX2.Text = "Submit"
        ISSpeciesUPDATE = False
        Me.DoubleInput1.Value = 0
        PageSlider1.SelectedPageIndex = 2
    End Sub

    Private Sub CButton5_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CButton5.ClickButtonArea
        TextBoxX2.Text = SpeciesList1.mLastSelected.Specie.Name
        DoubleInput1.Value = SpeciesList1.mLastSelected.Specie.Price
        ButtonX2.Text = "Update"
        ISSpeciesUPDATE = True
        PageSlider1.SelectedPageIndex = 2
    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        PageSlider1.SelectedPageIndex = 0
    End Sub

    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        PageSlider1.SelectedPageIndex = 0
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
       
    End Sub

    Private Sub CButton6_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CButton6.ClickButtonArea
        On Error Resume Next

        SpeciesList1.mLastSelected.Specie.Delete()
        SelectedTabChanged()
    End Sub

    Private Sub WarningBox1_OptionsClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WarningBox1.OptionsClick
        PageSlider1.SelectedPageIndex = 0
    End Sub

    Private Sub SpeciesList1_SPSelectionChanged(ByVal sender As SpeciesItem) Handles SpeciesList1.SPSelectionChanged
        If PageSlider1.SelectedPageIndex = 2 Then
            TextBoxX2.Text = sender.Specie.Name
            DoubleInput1.Value = sender.Specie.Price
            ButtonX2.Text = "Update"
            ISSpeciesUPDATE = True

        End If
    End Sub

    Private Sub TextBoxX2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxX2.KeyPress
        If e.KeyChar = CChar(ChrW(Keys.Enter)) Then
            ButtonX2.PerformClick()
        End If
    End Sub
End Class