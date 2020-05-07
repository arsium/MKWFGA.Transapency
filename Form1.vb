Imports System.Runtime.InteropServices

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
    Public h As Boolean = False
    Protected Overrides Sub OnResize(e As EventArgs)

        h = True

        If h Then

            l.Size = New Size(Me.Width - 50, Me.Height - 50)
        End If
        MyBase.OnResize(e)

        h = False
        l.BringToFront()
    End Sub
    Public l As New T2
    Public h2 As Boolean = False

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        l.ShowIcon = False
        l.ShowInTaskbar = False
        l.Size = New Size(Me.Width - 50, Me.Height - 50)
        l.TopLevel = True
        l.Show()

    End Sub

    Private Sub Form1_Move(sender As Object, e As EventArgs) Handles MyBase.Move
        h2 = True

        If h2 Then
            l.Location = New Point(Me.Location.X + 25, Me.Location.Y + 25)
        End If

        h2 = False

    End Sub
End Class
