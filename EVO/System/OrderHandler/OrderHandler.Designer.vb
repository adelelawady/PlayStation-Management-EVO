<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrderHandler
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SpeciesList1 = New EVO.SpeciesList()
        Me.TypeTabPanel1 = New EVO.TypeTabPanel()
        Me.SuspendLayout()
        '
        'SpeciesList1
        '
        Me.SpeciesList1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SpeciesList1.Location = New System.Drawing.Point(0, 45)
        Me.SpeciesList1.Name = "SpeciesList1"
        Me.SpeciesList1.Size = New System.Drawing.Size(624, 191)
        Me.SpeciesList1.TabIndex = 1
        '
        'TypeTabPanel1
        '
        Me.TypeTabPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TypeTabPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TypeTabPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TypeTabPanel1.Name = "TypeTabPanel1"
        Me.TypeTabPanel1.Size = New System.Drawing.Size(624, 45)
        Me.TypeTabPanel1.TabIndex = 0
        '
        'OrderHandler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SpeciesList1)
        Me.Controls.Add(Me.TypeTabPanel1)
        Me.Name = "OrderHandler"
        Me.Size = New System.Drawing.Size(624, 236)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TypeTabPanel1 As EVO.TypeTabPanel
    Friend WithEvents SpeciesList1 As EVO.SpeciesList

End Class
