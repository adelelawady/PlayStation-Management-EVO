Imports System.Drawing.Drawing2D

'----------------------------
'AviraTabControl
'Creator: Temploit
'Version: 1.1
'Created: 3rd of May / ~1.5hr
'----------------------------

Public Class AviraTabControl
    Inherits TabControl

    Private BC As Color = Color.FromArgb(73, 73, 73) 'Background Color
    Private SLGT As Color = Color.FromArgb(255, 255, 255) 'Selected Tab Gradient Color Top
    Private SLGB As Color = Color.FromArgb(200, 200, 200) 'Selected Tab Gradient Color Bottom
    Private SLLT As Pen = New Pen(Color.FromArgb(165, 165, 165)) 'Selected Tab Line Color Top
    Private SLLB As Pen = New Pen(Color.FromArgb(98, 98, 98)) 'Selected Tab Line Color Bottom
    Private TC As SolidBrush = New SolidBrush(Color.FromArgb(180, 180, 180)) 'Header Text Color
    Private UTC As Brush = Brushes.White 'Unselected Tab Font Color
    Private STC As Brush = Brushes.Black 'Selected Tab Font Color

    Private BCB As SolidBrush = New SolidBrush(BC)
    Private BCP As Pen = New Pen(BC)
    Private TR, InTR, InR, LR, ImR As Rectangle
    Private SF As StringFormat = New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center}
    Private SFHeader As StringFormat = New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Far}
    Private ICounter As Integer = 0
    Private SLGBr As LinearGradientBrush
    Private TSB As SolidBrush
    Private TROffset As Integer = 1

    Sub New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.Opaque Or ControlStyles.ResizeRedraw Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.Opaque, True)
        SetStyle(ControlStyles.Selectable, False)
        SizeMode = TabSizeMode.Fixed
        Alignment = TabAlignment.Left
        ItemSize = New Size(21, 180)
        DrawMode = TabDrawMode.OwnerDrawFixed
        Font = New Font("Verdana", 8)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim g As Graphics = e.Graphics

        If Not SelectedIndex = Nothing AndAlso Not SelectedIndex = -1 AndAlso Not SelectedIndex > TabPages.Count - 1 AndAlso Not TabPages(SelectedIndex).BackColor = Color.Transparent Then
            g.Clear(TabPages(SelectedIndex).BackColor)
        Else
            g.Clear(Color.White)
        End If
        ICounter = 0
        LR = New Rectangle(0, 0, ItemSize.Height + 3, Height)
        g.FillRectangle(BCB, LR)
        g.DrawRectangle(BCP, LR)

        g.SmoothingMode = SmoothingMode.AntiAlias
        For i = 0 To TabCount - 1
            TR = GetTabRect(i)
            TR = New Rectangle(TR.X, TR.Y, TR.Width - 1, TR.Height)
            If TabPages(i).Tag IsNot Nothing AndAlso TabPages(i).Tag IsNot String.Empty Then
                InR = New Rectangle(TR.X + 10, TR.Y, TR.Width - 10, TR.Height)
                g.DrawString(TabPages(i).Text.ToUpper, Font, TC, InR, SFHeader)
                ICounter += 1
            Else
                If i = SelectedIndex Then
                    SLGBr = New LinearGradientBrush(TR, SLGT, SLGB, 90)
                    InR = New Rectangle(TR.X + 36, TR.Y, TR.Width - 36, TR.Height)
                    InTR = New Rectangle(TR.X, TR.Y + TROffset, TR.Width, TR.Height - (2 * TROffset))

                    g.FillRectangle(SLGBr, InTR)
                    g.DrawLine(SLLT, TR.X, TR.Y + TROffset, TR.X + TR.Width - 1, TR.Y + TROffset)
                    g.DrawLine(SLLB, TR.X, TR.Y + TR.Height - TROffset, TR.X + TR.Width - 1, TR.Y + TR.Height - TROffset)
                    g.DrawString(TabPages(i).Text, Font, STC, InR, SF)

                    If SelectedImageList IsNot Nothing AndAlso SelectedImageList.Images.Count > i - ICounter AndAlso SelectedImageList.Images(i - ICounter) IsNot Nothing Then
                        ImR = New Rectangle(TR.X + 13, TR.Y + ((TR.Height / 2) - 8), 16, 16)
                        g.DrawImage(SelectedImageList.Images(i - ICounter), ImR)
                    End If

                Else
                    InR = New Rectangle(TR.X + 36, TR.Y, TR.Width - 36, TR.Height)
                    g.DrawString(TabPages(i).Text, Font, UTC, InR, SF)

                    If UnselectedImageList IsNot Nothing AndAlso UnselectedImageList.Images.Count > i - ICounter AndAlso UnselectedImageList.Images(i - ICounter) IsNot Nothing Then
                        ImR = New Rectangle(TR.X + 13, TR.Y + ((TR.Height / 2) - 8), 16, 16)
                        g.DrawImage(UnselectedImageList.Images(i - ICounter), ImR)
                    End If

                End If
            End If
        Next


        g.Dispose()

    End Sub

    Private UnselectedImageList As ImageList
    Public Property ImageList_Unselected As ImageList
        Get
            Return UnselectedImageList
        End Get
        Set(value As ImageList)
            UnselectedImageList = value
            If UnselectedImageList IsNot Nothing AndAlso Not UnselectedImageList.ImageSize = New Size(16, 16) Then
                UnselectedImageList.ImageSize = New Size(16, 16)
            End If
            Invalidate()
        End Set
    End Property

    Private SelectedImageList As ImageList
    Public Property ImageList_Selected As ImageList
        Get
            Return SelectedImageList
        End Get
        Set(value As ImageList)
            SelectedImageList = value
            If SelectedImageList IsNot Nothing AndAlso Not SelectedImageList.ImageSize = New Size(16, 16) Then
                SelectedImageList.ImageSize = New Size(16, 16)
            End If
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnSelecting(e As TabControlCancelEventArgs)
        MyBase.OnSelecting(e)
        If e.TabPage IsNot Nothing AndAlso e.TabPage.Tag IsNot Nothing AndAlso e.TabPage.Tag IsNot String.Empty AndAlso Not DesignMode Then
            e.Cancel = True
        End If
    End Sub

End Class