Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

Public Class Custom_Panel
    Inherits Panel
    'https://www.youtube.com/watch?v=pYdPs1ZXUPY
    Public Property ColorTop As Color
    Public Property ColorBottom As Color


    Public Property ColorLeft As Color
    Public Property ColorRight As Color



    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim lgb As LinearGradientBrush = New LinearGradientBrush(Me.ClientRectangle, Me.ColorTop, Me.ColorBottom, 90.0F)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(lgb, Me.ClientRectangle)


        Dim lgbs As LinearGradientBrush = New LinearGradientBrush(Me.ClientRectangle, Me.ColorRight, Me.ColorLeft, 180.0F)
        Dim gs As Graphics = e.Graphics
        gs.FillRectangle(lgbs, Me.ClientRectangle)



        If RoundedB Then
            'Me.FormBorderStyle = FormBorderStyle.None
            ' Dim myPen As Pen
            ' myPen = New Pen(ColorB, RadiusC)
            '  e.Graphics.DrawRectangle(myPen, 1, 1, Me.Width - 4, Me.Height - 3)
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, Radius_AZ, Radius_AZ))
            '  Me.Padding = New Padding(0, 29, 0, 0)



            'Dim myPen As Pen
            ' myPen = New Pen(ColorBorders, 5)


            'e.Graphics.DrawRectangle(myPen, 2, 2, Me.Width - 5, Me.Height - 5)

            '  e.Graphics.FillRectangle(myPean, New RectangleF(1, 1, h.ClientRectangle.Width, h.ClientRectangle.Height))
            '  Dim k As Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(100, 100, Width - 120, Height - 120, Radius_AZ, Radius_AZ))

            ' Dim az As Rectangle = Rectangle.Round(Me.Region.GetBounds(e.Graphics))
            '  ControlPaint.DrawBorder(e.Graphics, az, Color.Red, ButtonBorderStyle.Solid)

            'e.Graphics.FillRegion(, k)
            '   Me.Refresh()
            PolyB = False
        End If


        If PolyB Then


            'Mesures from : https://stackoverflow.com/questions/40570607/drawing-hexagon-in-vb-net
            Dim p(5) As Point

            Dim v As Integer = CInt(Me.Height / 2 * Math.Sin(30 * Math.PI / 180))
            p(0) = New Point(0, Me.Height \ 2)

            p(1) = New Point(v, Me.Height)
            p(2) = New Point(Me.Width - v, Me.Height)
            p(3) = New Point(Me.Width, Me.Height \ 2)
            p(4) = New Point(Me.Width - v, 0)
            p(5) = New Point(v, 0)


            Region = System.Drawing.Region.FromHrgn(CreatePolygonRgn(p, 6, 2))




            '   Dim ndj As Region = System.Drawing.Region.FromHrgn(CreatePolygonRgn(p, 6, 2))

            e.Graphics.DrawPolygon(New Pen(New SolidBrush(Color.DeepSkyBlue), 10), p)

            RoundedB = False

        End If







        MyBase.OnPaint(e)
    End Sub





    Private Radius_AZ As Integer = 20
    Property RadiusRoundedBorder As Integer
        Get
            Return Radius_AZ
            Me.Refresh()
        End Get
        Set(value As Integer)
            Radius_AZ = value
            Me.Refresh()
        End Set
    End Property









    Private PolyB As Boolean = False

    Property HexagonForm As Boolean
        Get
            Return PolyB
            Me.Refresh()
        End Get
        Set(value As Boolean)
            PolyB = value
            Me.Refresh()
        End Set
    End Property

    <DllImport("gdi32.dll")>
    Private Shared Function CreatePolygonRgn(ByVal lppt As Point(), ByVal cPoints As Integer, ByVal fnPolyFillMode As Integer) As IntPtr

    End Function

    Private RoundedB As Boolean = True
    Property RoundedBorder As Boolean
        Get
            Return RoundedB
            Me.Refresh()
        End Get
        Set(value As Boolean)
            RoundedB = value
            Me.Refresh()
        End Set
    End Property


    <DllImport("Gdi32.dll", EntryPoint:="CreateRoundRectRgn")>
    Private Shared Function CreateRoundRectRgn(ByVal nLeftRect As Integer, ByVal nTopRect As Integer, ByVal nRightRect As Integer, ByVal nBottomRect As Integer, ByVal nWidthEllipse As Integer, ByVal nHeightEllipse As Integer) As IntPtr

    End Function


    Private Color_B As Color = Color.DeepSkyBlue
    Property ColorBorders As Color
        Get
            Return Color_B
            Me.Refresh()
        End Get
        Set(value As Color)
            Color_B = value
            Me.Refresh()
        End Set
    End Property




    ''Native API adpated from  : https://github.com/RiyadPathan/DragControl/blob/master/DragControl.vb
    <DllImport("user32.dll")>
    Public Shared Function SendMessage(ByVal a As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function
    <DllImport("user32.dll")>
    Public Shared Function ReleaseCapture() As Boolean


    End Function

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)

        If Draggable = True Then
            Dim flag As Boolean = e.Button = MouseButtons.Left

            If flag Then
                Form1.l.BringToFront() ''''
                ReleaseCapture()

                SendMessage(Me.FindForm().Handle, 161, 2, 0)


                Form1.l.BringToFront() ''''
            End If
            Form1.l.BringToFront() ''''
        End If
        Form1.l.BringToFront() ''''
    End Sub

    Private DragB As Boolean = True
    Property Draggable As Boolean
        Get
            Return DragB
            Me.Refresh()
        End Get
        Set(value As Boolean)
            DragB = value
            Me.Refresh()
        End Set
    End Property
End Class
