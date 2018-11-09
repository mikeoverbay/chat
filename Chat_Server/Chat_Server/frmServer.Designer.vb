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
        Me.m_greeting = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.m_ip_port = New System.Windows.Forms.ToolStripTextBox()
        Me.m_logs = New System.Windows.Forms.ToolStripMenuItem()
        Me.mm.SuspendLayout()
        Me.SuspendLayout()
        '
        'chat_text_tb
        '
        Me.chat_text_tb.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.chat_text_tb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chat_text_tb.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chat_text_tb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.chat_text_tb.Location = New System.Drawing.Point(0, 27)
        Me.chat_text_tb.Margin = New System.Windows.Forms.Padding(0)
        Me.chat_text_tb.Multiline = True
        Me.chat_text_tb.Name = "chat_text_tb"
        Me.chat_text_tb.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.chat_text_tb.Size = New System.Drawing.Size(635, 234)
        Me.chat_text_tb.TabIndex = 5
        '
        'mm
        '
        Me.mm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.m_greeting, Me.ToolStripTextBox1, Me.m_ip_port, Me.m_logs})
        Me.mm.Location = New System.Drawing.Point(0, 0)
        Me.mm.Name = "mm"
        Me.mm.Size = New System.Drawing.Size(635, 27)
        Me.mm.TabIndex = 6
        Me.mm.Text = "MenuStrip1"
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
        'm_logs
        '
        Me.m_logs.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.m_logs.Name = "m_logs"
        Me.m_logs.Size = New System.Drawing.Size(44, 23)
        Me.m_logs.Text = "Logs"
        '
        'frmServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(635, 261)
        Me.Controls.Add(Me.chat_text_tb)
        Me.Controls.Add(Me.mm)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mm
        Me.MinimumSize = New System.Drawing.Size(489, 300)
        Me.Name = "frmServer"
        Me.Text = "Chat Server"
        Me.mm.ResumeLayout(False)
        Me.mm.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chat_text_tb As System.Windows.Forms.TextBox
    Friend WithEvents mm As System.Windows.Forms.MenuStrip
    Friend WithEvents m_greeting As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents m_ip_port As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents m_logs As System.Windows.Forms.ToolStripMenuItem

End Class
