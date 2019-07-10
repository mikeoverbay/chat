<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.user_name_tb = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.longin_bt = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ip_tb = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'user_name_tb
        '
        Me.user_name_tb.AcceptsReturn = True
        Me.user_name_tb.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.chat_client.My.MySettings.Default, "user_name", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.user_name_tb.Location = New System.Drawing.Point(54, 46)
        Me.user_name_tb.Multiline = True
        Me.user_name_tb.Name = "user_name_tb"
        Me.user_name_tb.Size = New System.Drawing.Size(121, 20)
        Me.user_name_tb.TabIndex = 0
        Me.user_name_tb.Text = Global.chat_client.My.MySettings.Default.user_name
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(13, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name"
        '
        'longin_bt
        '
        Me.longin_bt.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.longin_bt.Location = New System.Drawing.Point(16, 83)
        Me.longin_bt.Name = "longin_bt"
        Me.longin_bt.Size = New System.Drawing.Size(159, 23)
        Me.longin_bt.TabIndex = 2
        Me.longin_bt.Text = "Login"
        Me.longin_bt.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(3, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Address"
        '
        'ip_tb
        '
        Me.ip_tb.AcceptsReturn = True
        Me.ip_tb.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.chat_client.My.MySettings.Default, "ip_address", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ip_tb.Location = New System.Drawing.Point(54, 12)
        Me.ip_tb.Multiline = True
        Me.ip_tb.Name = "ip_tb"
        Me.ip_tb.Size = New System.Drawing.Size(121, 20)
        Me.ip_tb.TabIndex = 3
        Me.ip_tb.Text = Global.chat_client.My.MySettings.Default.ip_address
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(196, 120)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ip_tb)
        Me.Controls.Add(Me.longin_bt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.user_name_tb)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Login to chat..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents user_name_tb As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents longin_bt As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ip_tb As System.Windows.Forms.TextBox
End Class
