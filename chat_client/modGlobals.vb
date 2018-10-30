Imports Lidgren.Network

Imports System.IO
Imports System.String


Module modGlobals
    Public client As NetClient
    Public config As New NetPeerConfiguration("Jack123fred321")
    Public hostip As String = ""
    Public user_name As String
    Public is_running As Boolean = True
    Public out_string As String = ""
    Public logout As Boolean = False
    Enum PacketTypes As Byte
        Connect = 1
        disconnect = 2
        message = 3
        chat_state = 4
        server_stoped = 5
    End Enum
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

End Module
