Public Class TypeTab
    Inherits DevComponents.DotNetBar.ButtonItem

    Private _SpeciesType As SpeciesType

    Public Sub New(ByVal typeId As Integer, ByVal isSelected As Boolean)
        _SpeciesType = New SpeciesType(typeId)

        Me.Text = _SpeciesType.Name
        Me.Tooltip = True
       
       
        intiCbutton(isSelected)
    End Sub
    Public Sub intiCbutton(ByVal IsSelected As Boolean)
        Me.Checked = IsSelected
        'If Not IsSelected Then


        '    Me.ColorFillBlend.iColor = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black}
        '    Me.ColorFillSolid = System.Drawing.Color.Black
        'Else
        '    Me.ColorFillBlend.iColor = New System.Drawing.Color() {System.Drawing.Color.RoyalBlue, System.Drawing.Color.RoyalBlue, System.Drawing.Color.RoyalBlue}

        '    Me.ColorFillSolid = System.Drawing.Color.RoyalBlue
        'End If



        'Me.ColorFillSolid = System.Drawing.SystemColors.ActiveCaptionText
        'Me.Dock = System.Windows.Forms.DockStyle.Left
        'Me.Corners.All = 1
        'Me.Corners.LowerLeft = 1
        'Me.Corners.LowerRight = 1
        'Me.Corners.UpperLeft = 1
        'Me.Corners.UpperRight = 1
        'Me.Refresh()
    End Sub
    ReadOnly Property Type As SpeciesType
        Get
            Return Me._SpeciesType
        End Get

    End Property

End Class
