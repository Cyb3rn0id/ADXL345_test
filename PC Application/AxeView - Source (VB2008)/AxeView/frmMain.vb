' AxeView
' Accelerometer viewing utility
' (C)2016 Bernardo Giovanni - www.settorezero.com
' All rights reserved


Imports ZedGraph
Imports System.IO
Imports System.Drawing.Drawing2D

Public Class frmMain

    Dim RxBuffer As String = "" ' uart receiving buffer
    Dim FileSettings As String = Application.StartupPath & "\settings.xml" ' settings file
    Dim counter As Int64 = 0 ' data counter
    ' curves used by zedgraph
    Dim XCurve As LineItem
    Dim YCurve As LineItem
    Dim ZCurve As LineItem
    ' decimal separator on this system
    Dim Sep As Short = Asc(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)
    Dim RxProcessing As Boolean = False
    Dim ContinueSerialReading As Boolean = False
    Dim ClosingInProgress As Boolean = False

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' opening settings file, if exists
        If File.Exists(FileSettings) Then
            mySettings = mySettings.Load(FileSettings)
        Else
            ' or create a new if doesn't
            mySettings = New Settings
        End If

        ComList() ' available comports on this pc
        ' preparing controls
        Me.Text = Application.ProductName '& " " & Application.ProductVersion
        cmbBaud.DataSource = BaudRateList
        txtGMultiplier.Text = mySettings.GMultiplier
        txtSamples.Text = mySettings.MaxSamples
        txtMaxGVal.Text = mySettings.MaxGValue
        PrepareGraphs()
        'pbxPitch.BorderStyle = BorderStyle.None
        'pbxRoll.BorderStyle = BorderStyle.None
        RedrawImage(pbX, pbxRoll, 0)
        RedrawImage(pby, pbxPitch, 0)
    End Sub
    Private Sub frmMain_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        ' autoselect last values on the combobox
        cmbBaud.Text = mySettings.BaudRate
        If (cmbCom.Items.Count) Then
            If (cmbCom.Items.Contains(mySettings.ComPort)) Then
                cmbCom.Text = mySettings.ComPort
            Else
                cmbCom.Text = cmbCom.Items(0).ToString
            End If
        End If

    End Sub
    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        ClosingInProgress = True
        ContinueSerialReading = False

        Try
            BGDataReceive.CancelAsync()
        Catch ex As Exception
        End Try

        'save settings on exit
        Try
            mySettings.BaudRate = CStr(cmbBaud.SelectedValue)
            mySettings.ComPort = CStr(cmbCom.SelectedValue)
            mySettings.Save(FileSettings)
        Catch
        End Try

        'close serial port if open
        If SerialPort1.IsOpen Then
            Try
                SerialPort1.Close()
            Catch ex As Exception
            End Try
        End If

    End Sub
    Private Sub PrepareGraphs()

        ' Every zedgraph control must have a graphic pane
        Dim XPane As GraphPane = zgX.GraphPane
        Dim YPane As GraphPane = zgY.GraphPane
        Dim ZPane As GraphPane = zgZ.GraphPane

        ' Font definition
        Dim myFontX As FontSpec = New FontSpec("Trebuchet MS", 20, Color.Black, False, False, False, Color.Transparent, Brushes.Transparent, FillType.None)
        myFontX.Border.IsVisible = False ' by default the font has a border, I don't want it
        Dim myFontTitle As FontSpec = New FontSpec("Trebuchet MS", 30, Color.Black, False, False, False, Color.Transparent, Brushes.Transparent, FillType.None)
        myFontTitle.Border.IsVisible = False ' by default the font has a border, I don't want it
        myFontTitle.IsBold = True

        Dim myFontY As FontSpec = New FontSpec("Trebuchet MS", 18, Color.Black, False, False, False, Color.Transparent, Brushes.Transparent, FillType.None)
        myFontY.Border.IsVisible = False ' by default the font has a border, I don't want it
        myFontY.Angle = 90

        Dim myBorder As New Border(False, Color.Gainsboro, 1)
        Dim myPaneFill As New Fill(Me.BackColor) ' same color of the form
        Dim myChartFill As New Fill(Color.Gray, Color.Gray, Color.Gray)

        XPane.Border = myBorder
        YPane.Border = myBorder
        ZPane.Border = myBorder

        XPane.Fill = myPaneFill
        YPane.Fill = myPaneFill
        ZPane.Fill = myPaneFill

        XPane.Chart.Border = myBorder
        XPane.Chart.Fill = myChartFill
        YPane.Chart.Border = myBorder
        YPane.Chart.Fill = myChartFill
        ZPane.Chart.Border = myBorder
        ZPane.Chart.Fill = myChartFill

        ' Axes titles
        XPane.Title.Text = "X - axis"
        XPane.Title.FontSpec = myFontTitle
        XPane.Title.IsVisible = True
        XPane.TitleGap = 0
        YPane.Title.Text = "Y - axis"
        YPane.Title.FontSpec = myFontTitle
        YPane.Title.IsVisible = True
        YPane.TitleGap = 0
        ZPane.Title.Text = "Z - axis"
        ZPane.Title.FontSpec = myFontTitle
        ZPane.Title.IsVisible = True
        ZPane.TitleGap = 0

        '
        ' Graphic Pane definitions - X
        '
        With XPane.XAxis
            .Color = Color.Gainsboro
            '.Title.Text = "x-x"
            '.Title.FontSpec = myFont
            .Title.IsVisible = False
            .MajorTic.IsInside = False
            .MinorTic.IsInside = False
            ' IsOpposite property serves to show tics also on the secondary axes (the opposite axe)
            .MajorTic.IsOpposite = False
            .MinorTic.IsOpposite = False
            .Scale.Min = 1
            .Scale.Max = CInt(txtSamples.Text)
            .Scale.MajorStep = 10
            .Scale.MinorStep = CInt(CInt(txtSamples.Text) / 10)
            .Scale.Format = "0"
            .Scale.FontSpec = myFontX
        End With
        With XPane.YAxis
            '.Title.Text = "x-y"
            '.Title.FontSpec = myFont
            .Title.IsVisible = False
            .MajorTic.IsInside = False
            .MinorTic.IsInside = False
            .MajorTic.IsOpposite = False
            .MinorTic.IsOpposite = False
            .MajorGrid.IsVisible = True
            .MajorGrid.Color = Color.LightGray
            .Color = Color.Gainsboro
            .Scale.Min = -CDbl(txtMaxGVal.Text)
            .Scale.Max = CDbl(txtMaxGVal.Text)
            .Scale.MajorStep = 1
            .Scale.MinorStep = 0.2
            .Scale.Format = "0.0"
            .Scale.FontSpec = myFontY
        End With
        ' A graphic pane must have one curve at least
        ' Blue color for X
        XCurve = XPane.AddCurve("plot", New PointPairList, Color.Violet, SymbolType.None)
        With XCurve
            .Label.IsVisible = False
            .Line.IsAntiAlias = True
            .Line.IsSmooth = True
            .IsVisible = True
            .Line.Width = 3
        End With

        '
        ' Graphic Pane definitions - Y
        '
        With YPane.XAxis
            .Color = Color.Gainsboro
            '.Title.Text = "y-x"
            '.Title.FontSpec = myFont
            .Title.IsVisible = False
            .MajorTic.IsInside = False
            .MinorTic.IsInside = False
            .MajorTic.IsOpposite = False
            .MinorTic.IsOpposite = False
            .Color = Color.Gainsboro
            .Scale.Min = 1
            .Scale.Max = CInt(txtSamples.Text)
            .Scale.MajorStep = 10
            .Scale.MinorStep = CInt(CInt(txtSamples.Text) / 10)
            .Scale.Format = "0"
            .Scale.FontSpec = myFontX
        End With
        With YPane.YAxis
            '.Title.Text = "y-y"
            '.Title.FontSpec = myFont
            .Title.IsVisible = False
            .MajorTic.IsInside = False
            .MinorTic.IsInside = False
            .MajorTic.IsOpposite = False
            .MinorTic.IsOpposite = False
            .MajorGrid.IsVisible = True
            .MajorGrid.Color = Color.LightGray
            .Color = Color.Gainsboro
            .Scale.Min = -CDbl(txtMaxGVal.Text)
            .Scale.Max = CDbl(txtMaxGVal.Text)
            .Scale.MajorStep = 1
            .Scale.MinorStep = 0.2
            .Scale.Format = "0.0"
            .Scale.FontSpec = myFontY
        End With
        ' Orange color for Y
        YCurve = YPane.AddCurve("plot", New PointPairList, Color.Orange, SymbolType.None)
        With YCurve
            .Label.IsVisible = False
            .Line.IsAntiAlias = True
            .Line.IsSmooth = True
            .IsVisible = True
            .Line.Width = 3
        End With

        '
        ' Graphic Pane definitions - Z
        '
        With ZPane.XAxis
            .Color = Color.Gainsboro
            '.Title.Text = "z-x"
            '.Title.FontSpec = myFont
            .Title.IsVisible = False
            .MajorTic.IsInside = False
            .MinorTic.IsInside = False
            .MajorTic.IsOpposite = False
            .MinorTic.IsOpposite = False
            .Color = Color.Gainsboro
            .Scale.Min = 1
            .Scale.Max = CInt(txtSamples.Text)
            .Scale.MajorStep = 10
            .Scale.MinorStep = CInt(CInt(txtSamples.Text) / 10)
            .Scale.Format = "0"
            .Scale.FontSpec = myFontX
        End With
        With ZPane.YAxis
            '.Title.Text = "z-y"
            '.Title.FontSpec = myFont
            .Title.IsVisible = False
            .MajorTic.IsInside = False
            .MinorTic.IsInside = False
            .MajorTic.IsOpposite = False
            .MinorTic.IsOpposite = False
            .MajorGrid.IsVisible = True
            .MajorGrid.Color = Color.LightGray
            .Color = Color.Gainsboro
            .Scale.Min = -CDbl(txtMaxGVal.Text)
            .Scale.Max = CDbl(txtMaxGVal.Text)
            .Scale.MajorStep = 1
            .Scale.MinorStep = 0.2
            .Scale.Format = "0.0"
            .Scale.FontSpec = myFontY
        End With
        ' Green color for Z
        ZCurve = ZPane.AddCurve("plot", New PointPairList, Color.Lime, SymbolType.None)
        With ZCurve
            .Label.IsVisible = False
            .Line.IsAntiAlias = True
            .Line.IsSmooth = True
            .IsVisible = True
            .Line.Width = 3
        End With

        ' Update ZedGraph controls
        zgX.Invalidate()
        zgY.Invalidate()
        zgZ.Invalidate()

    End Sub
    Private Function ComList() As Boolean

        ' Available Com Ports on this pc
        cmbCom.DataSource = Nothing
        cmbCom.Enabled = False
        btnConnection.Enabled = False
        cmbBaud.Enabled = False

        ' ComPorts list object
        Dim ListCom As New ArrayList
        ' fill the object with available comports
        For i As Integer = 0 To (My.Computer.Ports.SerialPortNames.Count - 1)
            ListCom.Add(My.Computer.Ports.SerialPortNames(i))
        Next

        ' No Com available, show a warning message
        If ListCom.Count = 0 Then
            MessageBox.Show("No COM ports available on this computer" & vbCrLf & _
                            "OR Interface not connected." & vbCrLf & _
"If you're using ad usb interface, please connect it, wait about 5 seconds" & vbCrLf & _
"The press Settings->Refresh Com list", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            cmbCom.Text = "No Com Ports"

        Else ' at least one Com port available, enable the controls

            cmbCom.Enabled = True
            btnConnection.Enabled = True
            cmbBaud.Enabled = True
            cmbCom.DataSource = ListCom

        End If

    End Function
    Private Sub cmbCom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCom.KeyPress
        ' you cannot write in this combo
        e.Handled = True
    End Sub
    Private Sub cmbBaud_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbBaud.KeyPress
        ' you cannot write in this combo
        e.Handled = True
    End Sub
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        ' press on refresh button
        ComList()
    End Sub
    Private Sub btnConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click

        Dim errlev As Short = 0
        If (txtMaxGVal.Text = "") Or (Not IsNumeric(txtMaxGVal.Text)) Then
            errlev += 1
        End If
        If (txtSamples.Text = "") Or (Not IsNumeric(txtSamples.Text)) Then
            errlev += 2
        End If
        If (txtGMultiplier.Text = "") Or (Not IsNumeric(txtGMultiplier.Text)) Then
            errlev += 4
        End If

        If errlev > 0 Then
            Dim s As String = "Can't start. You must set following parameters:" & vbCrLf & vbCrLf
            If (errlev And 1) Then s &= "- Max g value" & vbCrLf
            If (errlev And 2) Then s &= "- Samples number" & vbCrLf
            If (errlev And 4) Then s &= "- g value for 1 bit" & vbCrLf
            MessageBox.Show(s, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        mySettings.MaxGValue = CDbl(txtMaxGVal.Text)
        mySettings.MaxSamples = CInt(txtSamples.Text)
        mySettings.GMultiplier = CDbl(txtGMultiplier.Text)

        If SerialPort1.IsOpen Then
            ' it's open : we must close it
            Try
                ContinueSerialReading = False
                RxProcessing = False
                SerialPort1.Close()
            Catch ex As Exception
                MessageBox.Show("Error closing COM", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            btnRefresh.Enabled = True
            cmbBaud.Enabled = True
            cmbCom.Enabled = True
            btnConnection.Text = "Connect"
            gbSettings.Enabled = True
            Me.Refresh()
            Exit Sub
        Else
            ' it's closed : we must open it

            btnRefresh.Enabled = False
            cmbCom.Enabled = False
            cmbBaud.Enabled = False
            btnConnection.Text = "Disconnect"
            Me.Refresh()

            With SerialPort1
                .BaudRate = CInt(cmbBaud.SelectedValue)
                .PortName = cmbCom.SelectedValue
                .Parity = IO.Ports.Parity.None
                .DataBits = 8
                .StopBits = IO.Ports.StopBits.One
                .Handshake = IO.Ports.Handshake.None
                .Encoding = System.Text.Encoding.GetEncoding(28591)
                .ReadBufferSize = 50
                ' those 2 settings are required for Arduino
                .RtsEnable = True
                .DtrEnable = True
            End With
            Try
                SerialPort1.Open()
                counter = 0
                gbSettings.Enabled = False
                ' clear the curves
                XCurve.Clear()
                YCurve.Clear()
                ZCurve.Clear()
                ' redraw graphs
                PrepareGraphs()

                RxProcessing = False
                ContinueSerialReading = True

                If Not (BGDataReceive.IsBusy) Then
                    BGDataReceive.RunWorkerAsync()
                End If

            Catch ex As Exception
                MessageBox.Show("Unable to open " & cmbCom.SelectedText & vbCrLf & vbCrLf & "Error:" & vbCrLf & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub
    
    ''' <summary>
    ''' Function for rotating an image by a specified rotation angle
    ''' </summary>
    ''' <param name="bmp">The image we're rotating</param>
    ''' <param name="angle">The angle to rotate it by</param>
    ''' <returns>The rotated image</returns>
    Public Function RotateImageByAngle(ByVal bmp As Bitmap, ByVal angle As Single) As Bitmap

        Dim Mx As New Drawing2D.Matrix
        Dim RectSrc As Rectangle = New Rectangle(0, 0, bmp.Width, bmp.Height)

        ' calculate the size of the new image
        'Dim ASize As Single = Math.Abs(bmp.Height * Math.Sin(angle)) + Math.Abs(bmp.Width * Math.Cos(angle))
        'Dim BSize As Single = Math.Abs(bmp.Height * Math.Cos(angle)) + Math.Abs(bmp.Width * Math.Sin(angle))
        'Dim bm As Bitmap = New Bitmap(Math.Abs(CInt(ASize)), Math.Abs(CInt(BSize)))
        Dim ASize As Integer = Math.Abs(CInt(Math.Max(bmp.Height, bmp.Width))) + 20
        Dim BSize As Integer = ASize
        Dim bm As Bitmap = New Bitmap(ASize, BSize)

        Dim centerpoint As PointF = New PointF(bm.Width / 2, bm.Height / 2)
        Dim RectDst As Rectangle = New Rectangle((bm.Width - RectSrc.Width) / 2, (bm.Height - RectSrc.Height) / 2, RectSrc.Width, RectSrc.Height)

        Using gr As Graphics = Graphics.FromImage(bm)
            'If you want to have nice images use High Quality
            gr.InterpolationMode = InterpolationMode.HighQualityBicubic

            'If you just want to calculate some image datas use faster methode NearestNeighbor
            'gr.InterpolationMode = InterpolationMode.NearestNeighbor
            'Clear the image
            'gr.Clear(Color.Black)
            'Rotate the image
            Mx.RotateAt(angle, centerpoint)
            gr.Transform = Mx
            'Draw the image
            gr.DrawImage(bmp, RectDst, RectSrc, GraphicsUnit.Pixel)
        End Using

        'Return the new image
        Return bm

    End Function
    ''' <summary>
    ''' Redraw the image contained in a picturebox in another picturebox, rotated by an angle
    ''' </summary>
    ''' <param name="pbxSource">Source PictureBox</param>
    ''' <param name="pbxDest">Destination PictureBox</param>
    ''' <param name="Angle">Angle in degree</param>
    ''' <remarks></remarks>
    Private Sub RedrawImage(ByRef pbxSource As PictureBox, ByRef pbxDest As PictureBox, ByVal Angle As Double)

        Dim Im As Bitmap = pbxSource.Image
        Dim newBmp As Bitmap = RotateImageByAngle(Im, Angle)

        'pbxDest.Image = newBmp
        'pbxDest.Invalidate()
        'Exit Sub

        Dim divideByW As Double = newBmp.Width / pbxDest.Width
        Dim divideByH As Double = newBmp.Height / pbxDest.Height
        Dim divideby As Double

        Dim imgShow As Bitmap
        Dim g As Graphics

        If divideByW > 1 Or divideByH > 1 Then
            If divideByW > divideByH Then
                divideby = divideByW
            Else
                divideby = divideByH
            End If
            imgShow = New Bitmap(CInt(CDbl(newBmp.Width) / divideby), CInt(CDbl(newBmp.Height) / divideby))
            imgShow.SetResolution(newBmp.HorizontalResolution, newBmp.VerticalResolution)
            g = Graphics.FromImage(imgShow)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(newBmp, New Rectangle(0, 0, CInt(CDbl(newBmp.Width) / divideby), CInt(CDbl(newBmp.Height) / divideby)), 0, 0, newBmp.Width, newBmp.Height, GraphicsUnit.Pixel)
            g.Dispose()
        Else
            imgShow = New Bitmap(newBmp.Width, newBmp.Height)
            imgShow.SetResolution(newBmp.HorizontalResolution, newBmp.VerticalResolution)
            g = Graphics.FromImage(imgShow)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(newBmp, New Rectangle(0, 0, newBmp.Width, newBmp.Height), 0, 0, newBmp.Width, newBmp.Height, GraphicsUnit.Pixel)
            g.Dispose()
        End If

        'newBmp.Dispose()
        'Im.Dispose()
        pbxDest.Image = imgShow
        'pbxDest.Invalidate()

    End Sub

    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click
        frmAbout.ShowDialog()
    End Sub
    Private Sub txtMaxGVal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMaxGVal.KeyPress
        ' only positive integer/decimals allowed in this textbox
        Dim KeyAscii As Short = Asc(e.KeyChar)
        ' you can press numbers, backspace, del, and decimal separator
        If KeyAscii < 48 And KeyAscii <> 24 And KeyAscii <> 8 And KeyAscii <> Sep Then
            KeyAscii = 0
        ElseIf KeyAscii > 57 Then
            KeyAscii = 0
        End If
        ' decimal separator is allowed but not as first char
        If txtMaxGVal.TextLength = 0 And KeyAscii = Sep Then
            KeyAscii = 0
        End If
        'only one decimal separator allowed
        If (KeyAscii = Sep) And _
            txtMaxGVal.Text.IndexOf(Chr(Sep)) > 0 Then
            KeyAscii = 0
        End If
        ' return correct keychar
        e.KeyChar = Chr(KeyAscii)
    End Sub
    Private Sub txtSamples_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSamples.KeyPress
        ' only positive integers allowed
        Dim KeyAscii As Short = Asc(e.KeyChar)
        ' you can press numbers, backspace, and del
        If KeyAscii < 48 And KeyAscii <> 24 And KeyAscii <> 8 Then
            KeyAscii = 0
        ElseIf KeyAscii > 57 Then
            KeyAscii = 0
        End If
        ' 0 not allowed as first char
        If e.KeyChar = "0" And txtSamples.TextLength = 0 Then
            KeyAscii = 0
        End If
        ' return correct keychar      
        e.KeyChar = Chr(KeyAscii)
    End Sub
    Private Sub txtGMultiplier_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGMultiplier.KeyPress
        ' only positive integer/decimals allowed in this textbox
        Dim KeyAscii As Short = Asc(e.KeyChar)
        ' you can press numbers, backspace, del, and decimal separator
        If KeyAscii < 48 And KeyAscii <> 24 And KeyAscii <> 8 And KeyAscii <> Sep Then
            KeyAscii = 0
        ElseIf KeyAscii > 57 Then
            KeyAscii = 0
        End If
        ' decimal separator is allowed but not as first char
        If txtGMultiplier.TextLength = 0 And KeyAscii = Sep Then
            KeyAscii = 0
        End If
        'only one decimal separator allowed
        If (KeyAscii = Sep) And _
            txtGMultiplier.Text.IndexOf(Chr(Sep)) > 0 Then
            KeyAscii = 0
        End If
        ' return correct keychar
        e.KeyChar = Chr(KeyAscii)
    End Sub

    Private Sub BGDataReceive_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGDataReceive.DoWork

        Dim ErrorOccurred As Boolean = False
        Dim rxBufferTemp As String = ""

        While (ContinueSerialReading)

            Try
                rxBufferTemp = SerialPort1.ReadLine
            Catch ex As TimeoutException
                ErrorOccurred = True
            Catch ex As Exception
                ErrorOccurred = True
            End Try

            If (Not ClosingInProgress) And (Not RxProcessing) Then
                RxBuffer = rxBufferTemp
                SerialPort1.DiscardInBuffer()
                Try
                    Me.Invoke(New MethodInvoker(AddressOf SerialDataProcessing))
                Catch ex As Exception

                End Try

            End If


            If (ErrorOccurred) Then
                Try
                    'SerialPort1.Close()
                Catch ex As Exception
                End Try
                SerialPort1.DiscardInBuffer()
                ErrorOccurred = False
                'ContinueSerialReading = False

            End If

        End While

    End Sub

    Private Sub SerialDataProcessing()
        RxProcessing = True
        ' elaborate data received and update graphics
        Dim x, y, z As Integer
        Dim gx, gy, gz As Double
        Dim ax, ay, az As Double
        Dim AcData(3) As String

        RxBuffer.Replace(vbCr, "")
        RxBuffer.Replace(vbLf, "")
        AcData = RxBuffer.Split(",")
        Try
            x = CInt(AcData(0))
            y = CInt(AcData(1))
            z = CInt(AcData(2))

        Catch ex As Exception
            Debug.Print("Error in X,Y,Z data extracting. Received: " & RxBuffer)
            RxProcessing = False
            Exit Sub
        End Try

        gx = x * mySettings.GMultiplier
        gy = y * mySettings.GMultiplier
        gz = z * mySettings.GMultiplier

        txtXValue.Text = x
        txtYValue.Text = y
        txtZValue.Text = z
        txtGXValue.Text = Format(gx, "0.00")
        txtGYValue.Text = Format(gy, "0.00")
        txtGZValue.Text = Format(gz, "0.00")

        XCurve.AddPoint(counter, gx)
        YCurve.AddPoint(counter, gy)
        ZCurve.AddPoint(counter, gz)

        ' roll graphs by eliminating first point and move the other points
        ' to the left
        If counter > CInt(txtSamples.Text) Then
            XCurve.RemovePoint(0)
            Dim px As New PointPairList
            px = XCurve.Points
            For a As Integer = 0 To px.Count - 1
                XCurve.Points.Item(a).X = a
                XCurve.Points.Item(a).Y = px(a).Y
            Next
            YCurve.RemovePoint(0)
            Dim py As New PointPairList
            py = YCurve.Points
            For a As Integer = 0 To py.Count - 1
                YCurve.Points.Item(a).X = a
                YCurve.Points.Item(a).Y = py(a).Y
            Next
            ZCurve.RemovePoint(0)
            Dim pz As New PointPairList
            pz = ZCurve.Points
            For a As Integer = 0 To pz.Count - 1
                ZCurve.Points.Item(a).X = a
                ZCurve.Points.Item(a).Y = pz(a).Y
            Next
        End If


        ' calculate angles only if there are no more acceleration values than gravity
        'If gx > 1 Then gx = 1
        'If gx < -1 Then gx = -1
        'If gy > 1 Then gy = 1
        'If gy < -1 Then gy = -1
        'If gz > 1 Then gz = 1
        'If gz < -1 Then gz = -1

        If (gx <= 1.1) And (gx >= -1.1) And (gy <= 1.1) And (gy >= -1.1) And (gz <= 1.1) And (gz >= -1.1) Then

            ay = Math.Atan(gy / Math.Sqrt((gx ^ 2) + (gz ^ 2))) * (180 / Math.PI)
            az = Math.Atan(gz / Math.Sqrt((gx ^ 2) + (gy ^ 2))) * (180 / Math.PI)
            ax = Math.Atan(gx / Math.Sqrt((gy ^ 2) + (gz ^ 2))) * (180 / Math.PI)
            txtAXvalue.Text = Format(ax, "0.0°")
            txtAYValue.Text = Format(ay, "0.0°")
            txtAZValue.Text = Format(az, "0.0°")

            ' rotate the vehicle
            Dim Aroll, Apitch As Double

            If (az < 0) Then
                Aroll = 180 - ax
            Else
                Aroll = ax
            End If
            Aroll = CInt(Aroll)
            RedrawImage(pbX, pbxRoll, Aroll)

            If (az < 0) Then
                Apitch = 180 + ay
            Else
                Apitch = -ay
            End If
            Apitch = CInt(Apitch)
            RedrawImage(pby, pbxPitch, Apitch)

        End If

        ' refresh graphics
        zgX.Invalidate()
        zgY.Invalidate()
        zgZ.Invalidate()
        Me.Invalidate()
        Me.Refresh()

        counter = counter + 1
        RxProcessing = False

    End Sub
End Class
