Imports System.IO
Imports System.String



Public Class frmSounds

    Private Sub frmSounds_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub frmSounds_Load(sender As Object, e As EventArgs) Handles Me.Load

        For i = 0 To frmClient.sounds.Length - 2
            Dim b = New Button
            b.AutoSize = False
            b.ForeColor = Color.White
            b.Width = 100
            b.Text = Path.GetFileName(frmClient.sounds(i).path)
            b.Tag = frmClient.sounds(i).path
            b.Location = New Point(6, b.Height * i + 5)
            AddHandler b.Click, AddressOf set_message_sound
            TabControl1.Controls(0).Controls.Add(b)
        Next

        For i = 0 To frmClient.sounds.Length - 2
            Dim b = New Button
            b.AutoSize = False
            b.ForeColor = Color.White
            b.Width = 100
            b.Text = Path.GetFileName(frmClient.sounds(i).path)
            b.Tag = frmClient.sounds(i).path
            b.Location = New Point(6, b.Height * i + 5)
            AddHandler b.Click, AddressOf set_enter_sound
            TabControl1.Controls(1).Controls.Add(b)
        Next

    End Sub

    Private Sub set_message_sound(sender As Object, e As EventArgs)
        Dim b = DirectCast(sender, Button)
        frmClient.player.SoundLocation = b.Tag
        frmClient.player.Play()
        My.Settings.message_sound = b.Tag
    End Sub
    Private Sub set_enter_sound(sender As Object, e As EventArgs)
        Dim b = DirectCast(sender, Button)
        frmClient.player.SoundLocation = b.Tag
        frmClient.player.Play()
        My.Settings.enter_sound = b.Tag
    End Sub

End Class