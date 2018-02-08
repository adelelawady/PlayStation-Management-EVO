<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TypeTabPanel
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
        Me.components = New System.ComponentModel.Container()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.CircularProgressItem1 = New DevComponents.DotNetBar.CircularProgressItem()
        Me.progress = New System.Windows.Forms.Timer(Me.components)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AccessibleDescription = "Bar1 (Bar1)"
        Me.Bar1.AccessibleName = "Bar1"
        Me.Bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.Bar1.AntiAlias = True
        Me.Bar1.BackgroundImage = Global.EVO.My.Resources.Resources.mdiClient1_BackgroundImage
        Me.Bar1.BackgroundImageAlpha = CType(0, Byte)
        Me.Bar1.CanHide = True
        Me.Bar1.DisplayMoreItemsOnMenu = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.DockedBorderStyle = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.Bar1.DockTabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Top
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.CircularProgressItem1})
        Me.Bar1.Location = New System.Drawing.Point(0, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(540, 33)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 0
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'CircularProgressItem1
        '
        Me.CircularProgressItem1.Name = "CircularProgressItem1"
        Me.CircularProgressItem1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.CircularProgressItem1.Visible = False
        '
        'progress
        '
        Me.progress.Enabled = True
        Me.progress.Interval = 500
        '
        'TypeTabPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Bar1)
        Me.Name = "TypeTabPanel"
        Me.Size = New System.Drawing.Size(540, 35)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents CircularProgressItem1 As DevComponents.DotNetBar.CircularProgressItem
    Friend WithEvents progress As System.Windows.Forms.Timer

End Class
