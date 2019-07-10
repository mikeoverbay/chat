<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClient
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClient))
        Me.MM = New System.Windows.Forms.MenuStrip()
        Me.m_login = New System.Windows.Forms.ToolStripMenuItem()
        Me.m_logout = New System.Windows.Forms.ToolStripMenuItem()
        Me.m_set_font = New System.Windows.Forms.ToolStripMenuItem()
        Me.m_stop_sending = New System.Windows.Forms.ToolStripMenuItem()
        Me.m_set_sounds = New System.Windows.Forms.ToolStripMenuItem()
        Me.m_sound = New System.Windows.Forms.ToolStripMenuItem()
        Me.m_keep_on_top = New System.Windows.Forms.ToolStripMenuItem()
        Me.users_tb = New System.Windows.Forms.TextBox()
        Me.update_timer = New System.Windows.Forms.Timer(Me.components)
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.input_tb = New System.Windows.Forms.TextBox()
        Me.chat_text_tb = New System.Windows.Forms.RichTextBox()
        Me.m_auto_Connect = New System.Windows.Forms.ToolStripMenuItem()
        Me.MM.SuspendLayout()
        Me.SuspendLayout()
        '
        'MM
        '
        Me.MM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.m_login, Me.m_logout, Me.m_auto_Connect, Me.m_set_font, Me.m_stop_sending, Me.m_set_sounds, Me.m_sound, Me.m_keep_on_top})
        Me.MM.Location = New System.Drawing.Point(0, 0)
        Me.MM.Name = "MM"
        Me.MM.Size = New System.Drawing.Size(513, 24)
        Me.MM.TabIndex = 0
        Me.MM.Text = "MenuStrip1"
        '
        'm_login
        '
        Me.m_login.Name = "m_login"
        Me.m_login.Size = New System.Drawing.Size(49, 20)
        Me.m_login.Text = "Login"
        '
        'm_logout
        '
        Me.m_logout.Name = "m_logout"
        Me.m_logout.Size = New System.Drawing.Size(57, 20)
        Me.m_logout.Text = "Logout"
        '
        'm_set_font
        '
        Me.m_set_font.Name = "m_set_font"
        Me.m_set_font.Size = New System.Drawing.Size(62, 20)
        Me.m_set_font.Text = "Set Font"
        '
        'm_stop_sending
        '
        Me.m_stop_sending.CheckOnClick = True
        Me.m_stop_sending.Name = "m_stop_sending"
        Me.m_stop_sending.Size = New System.Drawing.Size(99, 20)
        Me.m_stop_sending.Text = "STOP SENDING"
        Me.m_stop_sending.Visible = False
        '
        'm_set_sounds
        '
        Me.m_set_sounds.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.m_set_sounds.Name = "m_set_sounds"
        Me.m_set_sounds.Size = New System.Drawing.Size(77, 20)
        Me.m_set_sounds.Text = "Set Sounds"
        '
        'm_sound
        '
        Me.m_sound.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.m_sound.Checked = True
        Me.m_sound.CheckOnClick = True
        Me.m_sound.CheckState = System.Windows.Forms.CheckState.Checked
        Me.m_sound.Name = "m_sound"
        Me.m_sound.Size = New System.Drawing.Size(53, 20)
        Me.m_sound.Text = "Sound"
        '
        'm_keep_on_top
        '
        Me.m_keep_on_top.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.m_keep_on_top.Checked = True
        Me.m_keep_on_top.CheckOnClick = True
        Me.m_keep_on_top.CheckState = System.Windows.Forms.CheckState.Checked
        Me.m_keep_on_top.ForeColor = System.Drawing.Color.Red
        Me.m_keep_on_top.Name = "m_keep_on_top"
        Me.m_keep_on_top.Size = New System.Drawing.Size(87, 20)
        Me.m_keep_on_top.Text = "Keep On Top"
        '
        'users_tb
        '
        Me.users_tb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.users_tb.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.users_tb.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.users_tb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.users_tb.Location = New System.Drawing.Point(396, 24)
        Me.users_tb.Margin = New System.Windows.Forms.Padding(0)
        Me.users_tb.Multiline = True
        Me.users_tb.Name = "users_tb"
        Me.users_tb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.users_tb.Size = New System.Drawing.Size(117, 214)
        Me.users_tb.TabIndex = 3
        '
        'update_timer
        '
        Me.update_timer.Interval = 50
        '
        'input_tb
        '
        Me.input_tb.AcceptsReturn = True
        Me.input_tb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.input_tb.BackColor = System.Drawing.Color.Black
        Me.input_tb.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.chat_client.My.MySettings.Default, "font", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.input_tb.Font = Global.chat_client.My.MySettings.Default.font
        Me.input_tb.ForeColor = System.Drawing.Color.White
        Me.input_tb.Location = New System.Drawing.Point(0, 190)
        Me.input_tb.Margin = New System.Windows.Forms.Padding(0)
        Me.input_tb.Multiline = True
        Me.input_tb.Name = "input_tb"
        Me.input_tb.Size = New System.Drawing.Size(396, 48)
        Me.input_tb.TabIndex = 2
        '
        'chat_text_tb
        '
        Me.chat_text_tb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chat_text_tb.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chat_text_tb.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.chat_client.My.MySettings.Default, "font", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chat_text_tb.Font = Global.chat_client.My.MySettings.Default.font
        Me.chat_text_tb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.chat_text_tb.Location = New System.Drawing.Point(0, 24)
        Me.chat_text_tb.Margin = New System.Windows.Forms.Padding(0)
        Me.chat_text_tb.Name = "chat_text_tb"
        Me.chat_text_tb.Size = New System.Drawing.Size(396, 166)
        Me.chat_text_tb.TabIndex = 1
        Me.chat_text_tb.Text = "*clr to clear this screen at anytime." & Global.Microsoft.VisualBasic.ChrW(10) & "5 lines of the server chat buffer is sent a" & _
    "fter login." & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'm_auto_Connect
        '
        Me.m_auto_Connect.Checked = Global.chat_client.My.MySettings.Default.Auto_Connect
        Me.m_auto_Connect.CheckOnClick = True
        Me.m_auto_Connect.Name = "m_auto_Connect"
        Me.m_auto_Connect.Size = New System.Drawing.Size(93, 20)
        Me.m_auto_Connect.Text = "Auto Connect"
        '
        'frmClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(513, 238)
        Me.Controls.Add(Me.users_tb)
        Me.Controls.Add(Me.input_tb)
        Me.Controls.Add(Me.chat_text_tb)
        Me.Controls.Add(Me.MM)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MM
        Me.Name = "frmClient"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Client"
        Me.TopMost = True
        Me.MM.ResumeLayout(False)
        Me.MM.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MM As System.Windows.Forms.MenuStrip
    Friend WithEvents chat_text_tb As System.Windows.Forms.RichTextBox
    Friend WithEvents input_tb As System.Windows.Forms.TextBox
    Friend WithEvents m_login As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents users_tb As System.Windows.Forms.TextBox
    Friend WithEvents update_timer As System.Windows.Forms.Timer
    Friend WithEvents m_logout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m_sound As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m_keep_on_top As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m_set_font As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents m_set_sounds As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m_stop_sending As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m_auto_Connect As System.Windows.Forms.ToolStripMenuItem

End Class
