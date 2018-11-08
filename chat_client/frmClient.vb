Imports Lidgren.Network

Imports System.IO
Imports System.String

Public Class frmClient
    Public player As New System.Media.SoundPlayer
    Dim users As New List(Of user)
    Dim sbuf As New List(Of String)
    Public sounds() As sounds_
    Public Structure sounds_
        Public path As String
        Public index As Integer
    End Structure
    Private Sub m_login_Click(sender As Object, e As EventArgs) Handles m_login.Click
        Dim topmost = Me.TopMost
        Me.TopMost = False
        frmLogin.ShowDialog()
        Me.TopMost = topmost
        Try
            config.ConnectionTimeout = 10.0!
        Catch ex As Exception
        End Try
        client = New NetClient(config)

        Dim o_msg = client.CreateMessage

        client.Start()
        out_string = ""
        o_msg.Write(CByte(PacketTypes.Connect))

        o_msg.Write(user_name)
        Try
            client.Connect(hostip, 19566, o_msg)

        Catch ex As Exception
            MsgBox("Unable to login. Bad IP?", MsgBoxStyle.Exclamation, "Login Error")
            Return
        End Try

        If WaitForStratingInfo() Then
            update_timer.Start()
            While is_running
                GetInputAndSendItToServer()
                Application.DoEvents()
                Threading.Thread.Sleep(10)
            End While
        End If
    End Sub
    Private Function WaitForStratingInfo() As Boolean
        Dim canStart As Boolean = False
        Dim inc As NetIncomingMessage
        Dim sw As New Stopwatch
        sw.Start()
        sbuf.Clear()
        While True
            Application.DoEvents()
            inc = client.ReadMessage
            If inc IsNot Nothing Then

                If inc.MessageType = NetIncomingMessageType.Data Then
                    Dim mType = inc.ReadByte
                    If mType = CByte(PacketTypes.chat_state) Then
                        users.Clear()
                        Dim cnt As Integer
                        cnt = inc.ReadInt32
                        users_tb.Text = ""
                        For i = 0 To cnt - 1

                            Dim ch = New user
                            inc.ReadAllProperties(ch)
                            users.Add(ch)
                            users_tb.Text += ch.name + vbCrLf
                        Next
                        users_tb.SelectionStart = 0
                        users_tb.SelectionLength = 0
                        m_login.Enabled = False
                        m_logout.Enabled = True

                        Return True
                    End If
                    If mType = PacketTypes.message Then
                        Dim cnt = inc.ReadInt32
                        For i = 0 To cnt - 1
                            Dim str = inc.ReadString
                            If i = cnt - 1 Then
                                Me.Text = str
                            End If
                            check_sbuf(str)
                            Application.DoEvents()
                        Next

                    End If
                End If
            End If
            Dim et = sw.ElapsedMilliseconds
            If et > 5000 Then
                update_timer.Stop()
                MsgBox("Could not connect to the server!", MsgBoxStyle.Exclamation, "Connection Timeout")
                m_login.Enabled = True
                m_logout.Enabled = False
                Return False
            End If
            Application.DoEvents()
        End While
        Return False
    End Function
    Private Sub check_sbuf(ByVal s As String)
        If sbuf.Count > 30 Then
            sbuf.RemoveAt(0)
            sbuf.Add(s)
        Else
            sbuf.Add(s)
        End If
        chat_text_tb.Text = ""
        Dim os As String = ""
        For i = 0 To sbuf.Count - 1
            os += sbuf(i)
        Next
        chat_text_tb.Text = os
        chat_text_tb.SelectionLength = 0
        chat_text_tb.SelectionStart = chat_text_tb.TextLength
        chat_text_tb.ScrollToCaret()
        input_tb.Focus()
        Application.DoEvents()
    End Sub
    Private Sub CheckServerMessages()
        Dim inc As NetIncomingMessage

        inc = client.ReadMessage
        If inc IsNot Nothing Then
            If (inc.MessageType = NetIncomingMessageType.Data) Then
                Dim mtype = inc.ReadByte
                If mtype = CByte(PacketTypes.chat_state) Then
                    Play_enter_Sound()
                    users.Clear()
                    Dim j As Integer = 0
                    j = inc.ReadInt32
                    users_tb.Text = ""
                    For i = 0 To j - 1
                        Dim ch = New user
                        inc.ReadAllProperties(ch)
                        users.Add(ch)
                        users_tb.Text += ch.name + vbCrLf
                    Next
                    users_tb.SelectionStart = 0
                    users_tb.SelectionLength = 0
                End If
                If mtype = PacketTypes.message Then
                    Play_message_Sound()
                    Dim str = inc.ReadString
                    check_sbuf(str)
                End If
                If mtype = PacketTypes.Connect Then
                    Dim s = inc.ReadString
                End If
                If mtype = PacketTypes.server_stoped Then
                    client.Disconnect(user_name)
                    MsgBox("Server has was shutdown!", MsgBoxStyle.Exclamation, "Server shutdown my operator")
                    m_login.Enabled = True
                    m_logout.Enabled = False
                    Me.Focus()
                End If
                If mtype = PacketTypes.disconnect Then
                    Dim str = inc.ReadString
                    check_sbuf(str)
                    m_login.Enabled = True
                    m_logout.Enabled = False
                End If
            End If
            If (inc.MessageType = NetIncomingMessageType.StatusChanged) Then
                If client.ConnectionsCount = 0 Then
                    check_sbuf("You logged out" + vbCrLf)
                    m_login.Enabled = True
                    m_logout.Enabled = False
                End If

            End If
        End If
        Application.DoEvents()
    End Sub
    Private Sub GetInputAndSendItToServer()
        If logout Then
            Dim o_msg = client.CreateMessage
            o_msg.Write(PacketTypes.disconnect)
            o_msg.Write(user_name)
            client.SendMessage(o_msg, NetDeliveryMethod.ReliableOrdered, 0)
            logout = False
            m_login.Enabled = True
            m_logout.Enabled = False

            Return
        End If
        If out_string.Length > 0 Then
            Dim o_msg = client.CreateMessage
            o_msg.Write(CByte(PacketTypes.message))
            out_string = user_name + " ► " + out_string
            o_msg.Write(out_string)
            client.SendMessage(o_msg, NetDeliveryMethod.ReliableOrdered, 0)
            out_string = ""
        End If

    End Sub
    Private Sub frmClient_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try

            Dim o_msg = client.CreateMessage
            o_msg.Write(PacketTypes.disconnect)
            o_msg.Write(user_name)
            client.SendMessage(o_msg, NetDeliveryMethod.ReliableOrdered, 0)
        Catch ex As Exception

        End Try
        Try
            While client.ConnectionsCount > 0
                Application.DoEvents()
            End While
        Catch ex As Exception
        End Try
        is_running = False
    End Sub

    Private Sub frmClient_Load(sender As Object, e As EventArgs) Handles Me.Load
        m_sound.ForeColor = Color.Red
        populate_sound_list()
    End Sub

    Private Sub update_timer_Tick(sender As Object, e As EventArgs) Handles update_timer.Tick
        CheckServerMessages()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles input_tb.TextChanged

        If input_tb.Text.Contains(vbCrLf) Then
            If input_tb.Text.Length > 0 Then
                If input_tb.Text = "*clr" + vbCrLf Then
                    clear_buf()
                    input_tb.Text = ""
                    Return
                End If
                out_string = input_tb.Text
                input_tb.Text = ""

            End If
        End If
    End Sub
    Private Sub clear_buf()
        sbuf.Clear()
        chat_text_tb.Text = ""
    End Sub
    Private Sub m_logout_Click(sender As Object, e As EventArgs) Handles m_logout.Click
        logout = True
    End Sub

    Sub populate_sound_list()
        Dim p = Application.StartupPath + "\sounds"
        Dim d = Directory.GetFiles(p)
        Dim c As Integer = 0
        ReDim sounds(d.Count)
        For Each s In d
            sounds(c) = New sounds_
            sounds(c).path = s
            sounds(c).index = c
            c += 1
        Next
    End Sub
    Sub Play_message_Sound()
        If m_sound.Checked Then
            player.SoundLocation = My.Settings.message_sound
            player.Play()
        End If
    End Sub
    Sub Play_enter_Sound()
        If m_sound.Checked Then
            player.SoundLocation = My.Settings.enter_sound
            player.Play()
        End If
    End Sub

    Private Sub m_sound_Click(sender As Object, e As EventArgs) Handles m_sound.Click
        If m_sound.Checked Then
            m_sound.ForeColor = Color.Red
        Else
            m_sound.ForeColor = Color.Black
        End If
    End Sub

    Private Sub m_keep_on_top_Click(sender As Object, e As EventArgs) Handles m_keep_on_top.Click
        If m_keep_on_top.Checked Then
            m_keep_on_top.ForeColor = Color.Red
            Me.TopMost = True
        Else
            m_keep_on_top.ForeColor = Color.Black
            Me.TopMost = False
        End If
    End Sub

    Private Sub m_set_font_Click(sender As Object, e As EventArgs) Handles m_set_font.Click
        If FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim f = FontDialog1.Font
            chat_text_tb.Font = f
            input_tb.Font = f
        End If
    End Sub

    Private Sub chat_text_tb_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles chat_text_tb.LinkClicked
        System.Diagnostics.Process.Start(e.LinkText)
    End Sub

    Private Sub m_set_sounds_Click(sender As Object, e As EventArgs) Handles m_set_sounds.Click
        frmSounds.ShowDialog()

    End Sub
End Class
