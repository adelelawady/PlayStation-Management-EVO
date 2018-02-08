Public Class NewDeviceTypePOPUP
    Dim db As New DataBaseConnection

    Public Sub LoadTypes()
        On Error Resume Next

        'ComboBoxEx1.Items.Clear()

        'For Each Tim As Time In Time.GetTimeList

        '    Dim combo As New DevComponents.Editors.ComboItem(Tim.ID.ToString + " | TimeByMinutes:" + CStr(Tim.Miuntes) + " | Price:" + Tim.Price.ToString, Color.DarkGray)
        '    combo.Tag = Tim

        '    ComboBoxEx1.Items.Add(combo)
        '    If ComboBoxEx1.Items.Count = 0 Then
        '        ComboBoxEx1.SelectedItem = combo
        '    End If
        'Next


    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        Try

            If Not TextBoxX1.Text = "" Then
                If Not IntegerInput1.Value = 0 Then
                    If Not DoubleInput1.Value = 0 Then
                        If Device.DeviceType.InsertDeviceType(TextBoxX1.Text) = 1 Then
                            Dim GetDVTYPEITDSQL As String = "SELECT * FROM `devicetype` WHERE `Name` ='" + TextBoxX1.Text + "'"
                            Dim NEWID As String = CStr(db.executeSQL(GetDVTYPEITDSQL)(0)(0))
                            If Time.insertTime(IntegerInput1.Value, NEWID, DoubleInput1.Value) = 1 Then
                                MsgBox("Success")
                                Me.DialogResult = Windows.Forms.DialogResult.OK
                                Me.Close()
                            Else
                                MsgBox("Faild To Add Time")
                                Me.DialogResult = Windows.Forms.DialogResult.Abort
                            End If
                        Else
                            MsgBox("Faild To Insert Device Type Changed it's name And try again", MsgBoxStyle.Critical, "Error")
                            Me.DialogResult = Windows.Forms.DialogResult.Abort
                        End If

                        ' Time.insertTime (
                    Else
                        MsgBox("Enter Minutes Price Value")
                        Me.DialogResult = Windows.Forms.DialogResult.Abort
                    End If


                Else
                    MsgBox("Enter Minutes Value")
                    Me.DialogResult = Windows.Forms.DialogResult.Abort
                End If

            Else

                MsgBox("EnterName")
                Me.DialogResult = Windows.Forms.DialogResult.Abort

            End If

        Catch ex As Exception
            LOG.[LOG](ex) ' MsgBox(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        Me.Close()

    End Sub
End Class