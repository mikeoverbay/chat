Imports Lidgren.Network

Imports System.IO
Imports System.String

Imports System.Net

Public Class frmLogin

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles user_name_tb.TextChanged
        If user_name_tb.Text.Contains(vbCrLf) Then
            user_name_tb.Text = user_name_tb.Text.Replace(vbCrLf, "")
            longin_bt.Focus()
        End If

    End Sub

    Private Sub longin_bt_Click(sender As Object, e As EventArgs) Handles longin_bt.Click
        logout = False
        hostip = ip_tb.Text
        user_name = user_name_tb.Text
        Dim address As IPAddress = Nothing
        If IPAddress.TryParse(ip_tb.Text, address) Then
            Dim a = ip_tb.Text.Split(".")
            If a.Length <> 4 Then
                MsgBox("Invalid IP Address", MsgBoxStyle.Exclamation, "Bad IP Address")
                ip_tb.Text = ""
                ip_tb.Focus()
                Me.DialogResult = Windows.Forms.DialogResult.Abort
                Return
            End If
            user_name_tb.Focus()
            Me.Hide()
            Return
        Else
            MsgBox("Invalid IP Address", MsgBoxStyle.Exclamation, "Bad IP Address")
            ip_tb.Text = ""
            ip_tb.Focus()
            Me.DialogResult = Windows.Forms.DialogResult.Abort
            Return
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Hide()
        Return
    End Sub

    Private Sub frmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
        Me.DialogResult = Windows.Forms.DialogResult.Abort
    End Sub

    Private Sub ip_tb_TextChanged(sender As Object, e As EventArgs) Handles ip_tb.TextChanged
        If ip_tb.Text.Contains(vbCrLf) Then
            ip_tb.Text = ip_tb.Text.Replace(vbCrLf, "")
            Dim address As IPAddress = Nothing
            If IPAddress.TryParse(ip_tb.Text, address) Then
                Dim a = ip_tb.Text.Split(".")
                If a.Length <> 4 Then
                    MsgBox("Invalid IP Address", MsgBoxStyle.Exclamation, "Bad IP Address")
                    ip_tb.Text = ""
                    ip_tb.Focus()
                    Me.DialogResult = Windows.Forms.DialogResult.Abort
                    Return
                End If
                user_name_tb.Focus()
                Return
            Else
                MsgBox("Invalid IP Address", MsgBoxStyle.Exclamation, "Bad IP Address")
                ip_tb.Text = ""
                ip_tb.Focus()
            End If
        End If
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim wc As New WebClient
        Dim cnt As Integer
        Dim max_tries As Integer = 50
        Dim wan_ip As String = ""
        While cnt < max_tries
            Try
                wan_ip = wc.DownloadString("http://tnmshouse.com/getip/getserverip.php")
            Catch ex As Exception
                cnt += 1
            End Try
            GoTo found
        End While
        If cnt >= max_tries Then
            MsgBox("Could not connect to tnmshouse.com", MsgBoxStyle.OkOnly, "Damn..")
            Me.DialogResult = Windows.Forms.DialogResult.Abort
            Return
        End If
found:
        Me.Show()
        Application.DoEvents()
        ip_tb.Text = wan_ip
    End Sub
End Class