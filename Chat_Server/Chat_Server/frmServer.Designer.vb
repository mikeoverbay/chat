<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServer))
        Me.chat_text_tb = New System.Windows.Forms.TextBox()
        Me.mm = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.m_log_folder = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.m_send_greeting = New System.Windows.Forms.ToolStripMenuItem()
        Me.m_greeting = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.m_ip_port = New System.Windows.Forms.ToolStripTextBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.status_tb = New System.Windows.Forms.TextBox()
        Me.mm.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chat_text_tb
        '
        Me.chat_text_tb.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.chat_text_tb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chat_text_tb.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chat_text_tb.ForeColor = System.Drawing.Color.White
        Me.chat_text_tb.Location = New System.Drawing.Point(0, 0)
        Me.chat_text_tb.Margin = New System.Windows.Forms.Padding(0)
        Me.chat_text_tb.Multiline = True
        Me.chat_text_tb.Name = "chat_text_tb"
        Me.chat_text_tb.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.chat_text_tb.Size = New System.Drawing.Size(422, 538)
        Me.chat_text_tb.TabIndex = 5
        '
        'mm
        '
        Me.mm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.m_greeting, Me.ToolStripTextBox1, Me.m_ip_port})
        Me.mm.Location = New System.Drawing.Point(0, 0)
        Me.mm.Name = "mm"
        Me.mm.Size = New System.Drawing.Size(875, 27)
        Me.mm.TabIndex = 6
        Me.mm.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.m_log_folder, Me.ToolStripSeparator1, Me.m_send_greeting})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(61, 23)
        Me.ToolStripMenuItem1.Text = "Settings"
        '
        'm_log_folder
        '
        Me.m_log_folder.Name = "m_log_folder"
        Me.m_log_folder.Size = New System.Drawing.Size(174, 22)
        Me.m_log_folder.Text = "Show Logs Folder"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(171, 6)
        '
        'm_send_greeting
        '
        Me.m_send_greeting.CheckOnClick = True
        Me.m_send_greeting.Name = "m_send_greeting"
        Me.m_send_greeting.Size = New System.Drawing.Size(174, 22)
        Me.m_send_greeting.Text = "Send Greeting Msg"
        '
        'm_greeting
        '
        Me.m_greeting.Name = "m_greeting"
        Me.m_greeting.Size = New System.Drawing.Size(200, 23)
        Me.m_greeting.Text = Global.Chat_Server.My.MySettings.Default.m_greeting
        Me.m_greeting.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.AutoSize = False
        Me.ToolStripTextBox1.BackColor = System.Drawing.Color.White
        Me.ToolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ToolStripTextBox1.Enabled = False
        Me.ToolStripTextBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 16)
        Me.ToolStripTextBox1.Text = "WIFI : WAN : PORT"
        '
        'm_ip_port
        '
        Me.m_ip_port.BackColor = System.Drawing.Color.White
        Me.m_ip_port.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.m_ip_port.Name = "m_ip_port"
        Me.m_ip_port.Size = New System.Drawing.Size(250, 23)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 27)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.chat_text_tb)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.status_tb)
        Me.SplitContainer1.Size = New System.Drawing.Size(875, 538)
        Me.SplitContainer1.SplitterDistance = 422
        Me.SplitContainer1.TabIndex = 7
        '
        'status_tb
        '
        Me.status_tb.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.status_tb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.status_tb.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.status_tb.ForeColor = System.Drawing.Color.White
        Me.status_tb.Location = New System.Drawing.Point(0, 0)
        Me.status_tb.Margin = New System.Windows.Forms.Padding(0)
        Me.status_tb.Multiline = True
        Me.status_tb.Name = "status_tb"
        Me.status_tb.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.status_tb.Size = New System.Drawing.Size(449, 538)
        Me.status_tb.TabIndex = 6
        '
        'frmServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(875, 565)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.mm)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mm
        Me.MinimumSize = New System.Drawing.Size(489, 300)
        Me.Name = "frmServer"
        Me.Text = "Chat Server"
        Me.mm.ResumeLayout(False)
        Me.mm.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chat_text_tb As System.Windows.Forms.TextBox
    Friend WithEvents mm As System.Windows.Forms.MenuStrip
    Friend WithEvents m_greeting As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents m_ip_port As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents status_tb As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m_log_folder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents m_send_greeting As System.Windows.Forms.ToolStripMenuItem

End Class
