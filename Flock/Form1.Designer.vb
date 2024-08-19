<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Flock = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewCtrlNToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddBoidToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddObstacleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GetStartedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DebugWindowCtrlHToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 423)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'Flock
        '
        Me.Flock.Enabled = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "Text Files|*.txt"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(734, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "File"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewCtrlNToolStripMenuItem, Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.ToolStripMenuItem1.Text = "&File"
        '
        'NewCtrlNToolStripMenuItem
        '
        Me.NewCtrlNToolStripMenuItem.Name = "NewCtrlNToolStripMenuItem"
        Me.NewCtrlNToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.NewCtrlNToolStripMenuItem.Text = "New (Ctrl-N)"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.OpenToolStripMenuItem.Text = "Open (Ctrl-O)"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.SaveToolStripMenuItem.Text = "Save (Ctrl-S)"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.ExitToolStripMenuItem.Text = "Exit (Alt-F4)"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddBoidToolStripMenuItem, Me.AddObstacleToolStripMenuItem})
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(59, 20)
        Me.ToolStripMenuItem2.Text = "Actions"
        '
        'AddBoidToolStripMenuItem
        '
        Me.AddBoidToolStripMenuItem.Name = "AddBoidToolStripMenuItem"
        Me.AddBoidToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.AddBoidToolStripMenuItem.Text = "Add Boid (B)"
        '
        'AddObstacleToolStripMenuItem
        '
        Me.AddObstacleToolStripMenuItem.Name = "AddObstacleToolStripMenuItem"
        Me.AddObstacleToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.AddObstacleToolStripMenuItem.Text = "Add Obstacle (O)"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GetStartedToolStripMenuItem, Me.DebugWindowCtrlHToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'GetStartedToolStripMenuItem
        '
        Me.GetStartedToolStripMenuItem.Name = "GetStartedToolStripMenuItem"
        Me.GetStartedToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.GetStartedToolStripMenuItem.Text = "Get Started (Ctrl-F1)"
        '
        'DebugWindowCtrlHToolStripMenuItem
        '
        Me.DebugWindowCtrlHToolStripMenuItem.Name = "DebugWindowCtrlHToolStripMenuItem"
        Me.DebugWindowCtrlHToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.DebugWindowCtrlHToolStripMenuItem.Text = "Debug Window (Ctrl-H)"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 461)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(750, 500)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(750, 500)
        Me.Name = "Form1"
        Me.Text = "Bickering Boids!!!"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Public WithEvents Flock As Timer
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddBoidToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddObstacleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GetStartedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DebugWindowCtrlHToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewCtrlNToolStripMenuItem As ToolStripMenuItem
End Class
