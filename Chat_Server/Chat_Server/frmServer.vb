Imports Lidgren.Network
Imports System.Net.NetworkInformation


Imports System.IO
Imports System.String
Imports System.Text
Imports System.Web
Imports System.Net

Enum PacketTypes As Byte
    Connect = 1
    disconnect = 2
    message = 3
    chat_state = 4
    server_stoped = 5
End Enum
Public Class frmServer
    Dim running As Boolean = True
    Dim sbuf As New List(Of String)
    Dim Frmclosed As Boolean = False
    Dim wan_ip As String = ""
    Dim lan_ip As String = ""
    Dim Temp_Storage As String
    Dim file_ As FileStream
    Dim logMaxSize As Long = 1000000
    Dim current_file As String = ""
    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Frmclosed = True
        e.Cancel = True
        file_.Close()
    End Sub
    Private Function get_ip_address() As String
  
        Dim wc As New WebClient
        Dim cnt As Integer
        Dim max_tries As Integer = 50
        While cnt < max_tries
            Try
                wan_ip = wc.DownloadString("http://tnmshouse.com/getip/getip.php")
            Catch ex As Exception
                cnt += 1
            End Try
            GoTo found
        End While
        If cnt >= max_tries Then
            MsgBox("Could not connect to tnmshouse.com", MsgBoxStyle.OkOnly, "Damn..")
        End If
found:
        Dim networkInterfaces() As NetworkInterface


        networkInterfaces = NetworkInterface.GetAllNetworkInterfaces()

        For Each networkInterface In networkInterfaces
            If networkInterface.NetworkInterfaceType = NetworkInterfaceType.Wireless80211 Then
                For Each address In networkInterface.GetIPProperties().UnicastAddresses
                    If address.Address.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                        Debug.WriteLine(address.Address.ToString())
                        lan_ip = address.Address.ToString()
                    End If
                Next address
            End If
        Next networkInterface

        Return lan_ip


        'For Each ni As NetworkInterface In NetworkInterface.GetAllNetworkInterfaces()
        '    If ni.NetworkInterfaceType = NetworkInterfaceType.Wireless80211 Or ni.NetworkInterfaceType = NetworkInterfaceType.Ethernet Then
        '        Console.WriteLine(ni.Name)
        '        For Each ip As UnicastIPAddressInformation In ni.GetIPProperties().UnicastAddresses
        '            If ip.Address.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
        '                Console.WriteLine(ip.Address.ToString())
        '            End If
        '            If ip.Address.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
        '                Debug.WriteLine(ip.Address.ToString())
        '                'Return ip.Address.ToString()
        '            End If

        '        Next
        '    End If
        'Next
        'Return "this"
    End Function
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        '========================================================================================
        'setup log file
        Temp_Storage = Path.GetTempPath ' this gets the user temp storage folder
        Temp_Storage += "Coffee_Server_logs"
        If Not System.IO.Directory.Exists(Temp_Storage) Then
            System.IO.Directory.CreateDirectory(Temp_Storage)
        End If
        Dim di = Directory.GetFiles(Temp_Storage)
        Dim da As New Date(0)

        If di.Count = 0 Then
            Dim f As String = "log_" + Date.Now.ToFileTimeUtc.ToString + ".txt"
            current_file = f
            file_ = File.Open(Temp_Storage + "\" + current_file, FileMode.OpenOrCreate)
        Else

            For Each f In di
                Dim t = File.GetLastWriteTimeUtc(f)
                If t > da Then
                    current_file = f
                End If
            Next
            file_ = File.Open(current_file, FileMode.Append)
        End If
        '========================================================================================
        'setup server
        Dim config As New NetPeerConfiguration("Jack123fred321")
        config.ConnectionTimeout = 10.0!
        config.Port = 19566
        config.MaximumConnections = 100
        Dim ip = get_ip_address()
        config.EnableMessageType(NetIncomingMessageType.ConnectionApproval)
        Dim Nserver = New NetServer(config)
        Me.Show()
        Application.DoEvents()
        'For i = 1 To 10
        '    sbuf.Add(i.ToString + vbCrLf)
        'Next
        m_ip_port.Enabled = True
        m_ip_port.Text = lan_ip + " : " + wan_ip + " : 19566"
        m_ip_port.Enabled = False
        Nserver.Start()
        Dim users As New List(Of user)
        Dim inc As NetIncomingMessage
        '========================================================================================

        While running
            Dim pnt As Integer = 0
            For Each cnx In Nserver.Connections
                Select Case cnx.Status
                    Case 1
                        'Debug.WriteLine("CNX STAT 1: " + cnx.Status.ToString)
                    Case 2
                        'Debug.WriteLine("CNX STAT 2: " + cnx.Status.ToString)
                    Case 3
                        'Debug.WriteLine("CNX STAT 3: " + cnx.Status.ToString)

                End Select
                'If cnx.Status <> NetConnectionStatus.Connected Then
                '    Debug.WriteLine("CNX STAT: " + cnx.Status.ToString)
                'End If
            Next
            inc = Nserver.ReadMessage
            Application.DoEvents()
            If inc IsNot Nothing Then
                If inc.MessageType = NetIncomingMessageType.ConnectionApproval Then
                    'asking to connect?
                    If inc.ReadByte = CByte(PacketTypes.Connect) Then
                        Debug.WriteLine("connect")
                        inc.SenderConnection.Approve()
                        Dim u As New user
                        u.name = inc.ReadString
                        u.connection = inc.SenderConnection
                        users.Add(u)
                        Dim c_msg = Nserver.CreateMessage
                        ' write out 5 lines from the text q
                        c_msg.Write(PacketTypes.message)
                        If sbuf.Count > 0 Then
                            If sbuf.Count < 6 Then
                                c_msg.Write(sbuf.Count + 1)
                                For i = 0 To sbuf.Count - 1
                                    c_msg.Write(sbuf(i))
                                Next
                            Else
                                c_msg.Write(CInt(6) + 1)
                                For i = sbuf.Count - 6 To sbuf.Count - 1
                                    c_msg.Write(sbuf(i))
                                Next
                            End If
                        Else
                            c_msg.Write(CInt(1)) 'nothing in text q
                        End If
                        c_msg.Write("◄ " + My.Settings.m_greeting + " ►" + vbCrLf)
                        Nserver.SendMessage(c_msg, inc.SenderConnection, NetDeliveryMethod.ReliableOrdered, 0)

                        '----------
                        Dim o_msg = Nserver.CreateMessage
                        o_msg.Write(CByte(PacketTypes.chat_state))
                        o_msg.Write(CInt(users.Count)) 'number of users
                        For Each cu In users
                            o_msg.WriteAllProperties(cu)
                        Next
                        Nserver.SendMessage(o_msg, Nserver.Connections, NetDeliveryMethod.ReliableOrdered, 0)
                        Nserver.SendMessage(o_msg, inc.SenderConnection, NetDeliveryMethod.ReliableOrdered, 0)
                        Dim msg = Nserver.CreateMessage
                        msg.Write(CByte(PacketTypes.message))
                        msg.Write(u.name + " joined :" + Date.Now + vbCrLf)
                        check_sbuf(u.name + " joined :" + Date.Now + vbCrLf)
                        Nserver.SendMessage(msg, Nserver.Connections, NetDeliveryMethod.ReliableOrdered, 0)
                    End If
                End If
                'new message from user
                If inc.MessageType = NetIncomingMessageType.Data Then
                    Dim mtype = inc.ReadByte
                    If mtype = CByte(PacketTypes.message) Then
                        Dim str = inc.ReadString
                        check_sbuf(str)
                        Dim o_msg = Nserver.CreateMessage
                        'o_msg.Write(CInt(users.Count))
                        o_msg.Write(PacketTypes.message)
                        o_msg.Write(str)
                        'For Each cu In users
                        '    'If cu.connection = inc.SenderConnection Then
                        '    '    cu.message = str
                        '    'End If
                        '    o_msg.WriteAllProperties(cu)
                        'Next
                        'message contains:
                        'name
                        'connection
                        Nserver.SendMessage(o_msg, Nserver.Connections, NetDeliveryMethod.ReliableOrdered, 0)
                    End If
                    If mtype = PacketTypes.disconnect Then
                        Dim str = inc.ReadString
                        Dim o_msg = Nserver.CreateMessage
                        o_msg.Write(PacketTypes.message)
                        o_msg.Write(str + " left :" + Date.Now + vbCrLf)
                        check_sbuf(str + " left :" + Date.Now + vbCrLf)
                        For i = 0 To users.Count - 1
                            Try
                                If users(i).name = str Then
                                    users(i).connection.Disconnect("User Disconnect")
                                    users.RemoveAt(i)
                                End If
                            Catch ex As Exception

                            End Try
                        Next
                        For Each ch In Nserver.Connections
                            ch.SendMessage(o_msg, NetDeliveryMethod.ReliableOrdered, 0)
                        Next
                        o_msg = Nserver.CreateMessage
                        o_msg.Write(CByte(PacketTypes.chat_state))
                        o_msg.Write(CInt(users.Count)) 'number of users
                        For Each cu In users
                            o_msg.WriteAllProperties(cu)
                        Next
                        Nserver.SendMessage(o_msg, Nserver.Connections, NetDeliveryMethod.ReliableOrdered, 0)
                    End If
                End If

                If inc.MessageType = NetIncomingMessageType.DebugMessage Then
                    Dim s = inc.ReadString
                    Debug.WriteLine(s)
                End If
                If inc.MessageType = NetIncomingMessageType.WarningMessage Then
                    Dim s = inc.ReadString
                    Debug.WriteLine(s)
                End If
                If inc.MessageType = NetIncomingMessageType.StatusChanged Then

                    Dim cl = inc.SenderConnection
                    Dim msg = cl.Status.ToString
                    If msg = "Disconnected" Then
                        'some one timed out
                        Debug.WriteLine("Status Change: " + msg)

                        For i = 0 To users.Count - 1
                            If users(i).connection.RemoteUniqueIdentifier = cl.RemoteUniqueIdentifier Then
                                Dim name As String = users(i).name
                                users.RemoveAt(i)
                                Dim o_msg = Nserver.CreateMessage
                                'update everyones user list
                                o_msg.Write(CByte(PacketTypes.chat_state))
                                o_msg.Write(CInt(users.Count)) 'number of users
                                For Each cu In users
                                    o_msg.WriteAllProperties(cu)
                                Next
                                Nserver.SendMessage(o_msg, Nserver.Connections, NetDeliveryMethod.ReliableOrdered, 0)
                                o_msg = Nserver.CreateMessage
                                'tell everyone who left
                                o_msg.Write(CByte(PacketTypes.message))
                                o_msg.Write(name + " timed out :" + Date.Now + vbCrLf)
                                check_sbuf(name + " timed out :" + Date.Now + vbCrLf)
                                Nserver.SendMessage(o_msg, Nserver.Connections, NetDeliveryMethod.ReliableOrdered, 0)
                                Exit For
                            End If
                        Next
                    End If

                    If inc.ReadByte = PacketTypes.message Then
                        Dim srt = inc.ReadString
                        Debug.WriteLine("Status Change: " + srt)
                    End If
                End If

            End If
            If Frmclosed Then
                'tell everyone the server was shut down
                Dim o_msg = Nserver.CreateMessage
                o_msg.Write(PacketTypes.server_stoped) 'server stoped message
                For Each ch In Nserver.Connections
                    ch.SendMessage(o_msg, NetDeliveryMethod.ReliableOrdered, 0)
                Next
                While Nserver.Connections.Length > 0
                    Application.DoEvents()
                End While
                End
            End If
        End While


    End Sub
    Private Sub check_sbuf(ByRef s As String)
        Dim a = Encoding.UTF8.GetBytes(s)
        file_.Write(a, 0, a.Length)
        If file_.Length > logMaxSize Then
            file_.Close()
            Dim f As String = Temp_Storage + "\log_" + Date.Now.ToFileTimeUtc.ToString + ".txt"
            file_ = File.Open(f, FileMode.OpenOrCreate)
        End If
        If sbuf.Count > 30 Then
            sbuf.RemoveAt(0)
            sbuf.Add(s)
        Else
            sbuf.Add(s)
        End If
        chat_text_tb.Text = ""
        For i = 0 To sbuf.Count - 1
            chat_text_tb.Text += sbuf(i)
        Next
        chat_text_tb.SelectionLength = 0
        chat_text_tb.SelectionStart = chat_text_tb.TextLength
        chat_text_tb.ScrollToCaret()
    End Sub

    Private Sub m_greeting_Click(sender As Object, e As EventArgs) Handles m_greeting.Click

    End Sub

    Private Sub m_greeting_TextChanged(sender As Object, e As EventArgs) Handles m_greeting.TextChanged
        My.Settings.m_greeting = m_greeting.Text
        My.Settings.Save()
    End Sub

    Private Sub m_logs_Click(sender As Object, e As EventArgs) Handles m_logs.Click
        Process.Start(Path.GetDirectoryName(Temp_Storage + "\"))
    End Sub
End Class

Public Class user
    Private n As String
    Private conn As NetConnection

    Public Property name As String
        Get
            Return Me.n
        End Get
        Set(ByVal value As String)
            Me.n = value
        End Set
    End Property
    Public Property connection As NetConnection
        Get
            Return Me.conn
        End Get
        Set(ByVal value As NetConnection)
            Me.conn = value
        End Set
    End Property

    Public Sub user(ByRef n As String, ByRef c As NetConnection)
        Me.name = n
        Me.connection = c
    End Sub
End Class
