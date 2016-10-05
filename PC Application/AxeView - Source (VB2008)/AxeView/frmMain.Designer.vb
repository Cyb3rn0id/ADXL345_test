<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.cmbCom = New System.Windows.Forms.ComboBox
        Me.cmbBaud = New System.Windows.Forms.ComboBox
        Me.btnConnection = New System.Windows.Forms.Button
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.grpCom = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtAZValue = New System.Windows.Forms.TextBox
        Me.txtAYValue = New System.Windows.Forms.TextBox
        Me.txtAXvalue = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtGZValue = New System.Windows.Forms.TextBox
        Me.txtGYValue = New System.Windows.Forms.TextBox
        Me.txtGXValue = New System.Windows.Forms.TextBox
        Me.txtZValue = New System.Windows.Forms.TextBox
        Me.txtYValue = New System.Windows.Forms.TextBox
        Me.txtXValue = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.zgX = New ZedGraph.ZedGraphControl
        Me.zgY = New ZedGraph.ZedGraphControl
        Me.zgZ = New ZedGraph.ZedGraphControl
        Me.gbSettings = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtGMultiplier = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtSamples = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtMaxGVal = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.btnAbout = New System.Windows.Forms.Button
        Me.pbxPitch = New System.Windows.Forms.PictureBox
        Me.pby = New System.Windows.Forms.PictureBox
        Me.pbxRoll = New System.Windows.Forms.PictureBox
        Me.pbX = New System.Windows.Forms.PictureBox
        Me.BGDataReceive = New System.ComponentModel.BackgroundWorker
        Me.grpCom.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbSettings.SuspendLayout()
        CType(Me.pbxPitch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pby, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxRoll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbCom
        '
        Me.cmbCom.FormattingEnabled = True
        Me.cmbCom.Location = New System.Drawing.Point(94, 19)
        Me.cmbCom.Name = "cmbCom"
        Me.cmbCom.Size = New System.Drawing.Size(94, 21)
        Me.cmbCom.TabIndex = 0
        '
        'cmbBaud
        '
        Me.cmbBaud.FormattingEnabled = True
        Me.cmbBaud.Location = New System.Drawing.Point(94, 46)
        Me.cmbBaud.Name = "cmbBaud"
        Me.cmbBaud.Size = New System.Drawing.Size(94, 21)
        Me.cmbBaud.TabIndex = 1
        '
        'btnConnection
        '
        Me.btnConnection.Location = New System.Drawing.Point(6, 85)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(89, 26)
        Me.btnConnection.TabIndex = 2
        Me.btnConnection.Text = "Connect"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(101, 85)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(89, 26)
        Me.btnRefresh.TabIndex = 3
        Me.btnRefresh.Text = "Refresh list"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'SerialPort1
        '
        Me.SerialPort1.BaudRate = 115200
        Me.SerialPort1.DtrEnable = True
        Me.SerialPort1.ReadBufferSize = 40
        Me.SerialPort1.RtsEnable = True
        '
        'grpCom
        '
        Me.grpCom.Controls.Add(Me.Label2)
        Me.grpCom.Controls.Add(Me.Label1)
        Me.grpCom.Controls.Add(Me.cmbCom)
        Me.grpCom.Controls.Add(Me.cmbBaud)
        Me.grpCom.Controls.Add(Me.btnRefresh)
        Me.grpCom.Controls.Add(Me.btnConnection)
        Me.grpCom.Location = New System.Drawing.Point(12, 12)
        Me.grpCom.Name = "grpCom"
        Me.grpCom.Size = New System.Drawing.Size(250, 124)
        Me.grpCom.TabIndex = 5
        Me.grpCom.TabStop = False
        Me.grpCom.Text = "Com Port"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Baud Rate:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Available Coms:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtAZValue)
        Me.GroupBox1.Controls.Add(Me.txtAYValue)
        Me.GroupBox1.Controls.Add(Me.txtAXvalue)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtGZValue)
        Me.GroupBox1.Controls.Add(Me.txtGYValue)
        Me.GroupBox1.Controls.Add(Me.txtGXValue)
        Me.GroupBox1.Controls.Add(Me.txtZValue)
        Me.GroupBox1.Controls.Add(Me.txtYValue)
        Me.GroupBox1.Controls.Add(Me.txtXValue)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 250)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(250, 123)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Accelerometer Data"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(177, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "ANGLE"
        '
        'txtAZValue
        '
        Me.txtAZValue.Location = New System.Drawing.Point(169, 88)
        Me.txtAZValue.Name = "txtAZValue"
        Me.txtAZValue.Size = New System.Drawing.Size(60, 20)
        Me.txtAZValue.TabIndex = 19
        '
        'txtAYValue
        '
        Me.txtAYValue.Location = New System.Drawing.Point(169, 62)
        Me.txtAYValue.Name = "txtAYValue"
        Me.txtAYValue.Size = New System.Drawing.Size(60, 20)
        Me.txtAYValue.TabIndex = 18
        '
        'txtAXvalue
        '
        Me.txtAXvalue.Location = New System.Drawing.Point(169, 36)
        Me.txtAXvalue.Name = "txtAXvalue"
        Me.txtAXvalue.Size = New System.Drawing.Size(60, 20)
        Me.txtAXvalue.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(124, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "G"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(49, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "RAW"
        '
        'txtGZValue
        '
        Me.txtGZValue.Location = New System.Drawing.Point(103, 88)
        Me.txtGZValue.Name = "txtGZValue"
        Me.txtGZValue.Size = New System.Drawing.Size(60, 20)
        Me.txtGZValue.TabIndex = 14
        '
        'txtGYValue
        '
        Me.txtGYValue.Location = New System.Drawing.Point(103, 62)
        Me.txtGYValue.Name = "txtGYValue"
        Me.txtGYValue.Size = New System.Drawing.Size(60, 20)
        Me.txtGYValue.TabIndex = 13
        '
        'txtGXValue
        '
        Me.txtGXValue.Location = New System.Drawing.Point(103, 36)
        Me.txtGXValue.Name = "txtGXValue"
        Me.txtGXValue.Size = New System.Drawing.Size(60, 20)
        Me.txtGXValue.TabIndex = 12
        '
        'txtZValue
        '
        Me.txtZValue.Location = New System.Drawing.Point(37, 88)
        Me.txtZValue.Name = "txtZValue"
        Me.txtZValue.Size = New System.Drawing.Size(60, 20)
        Me.txtZValue.TabIndex = 11
        '
        'txtYValue
        '
        Me.txtYValue.Location = New System.Drawing.Point(37, 62)
        Me.txtYValue.Name = "txtYValue"
        Me.txtYValue.Size = New System.Drawing.Size(60, 20)
        Me.txtYValue.TabIndex = 10
        '
        'txtXValue
        '
        Me.txtXValue.Location = New System.Drawing.Point(37, 36)
        Me.txtXValue.Name = "txtXValue"
        Me.txtXValue.Size = New System.Drawing.Size(60, 20)
        Me.txtXValue.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Z"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Y"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "X"
        '
        'zgX
        '
        Me.zgX.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.zgX.ForeColor = System.Drawing.Color.Black
        Me.zgX.Location = New System.Drawing.Point(268, 12)
        Me.zgX.Name = "zgX"
        Me.zgX.ScrollGrace = 0
        Me.zgX.ScrollMaxX = 0
        Me.zgX.ScrollMaxY = 0
        Me.zgX.ScrollMaxY2 = 0
        Me.zgX.ScrollMinX = 0
        Me.zgX.ScrollMinY = 0
        Me.zgX.ScrollMinY2 = 0
        Me.zgX.Size = New System.Drawing.Size(575, 204)
        Me.zgX.TabIndex = 7
        '
        'zgY
        '
        Me.zgY.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.zgY.Location = New System.Drawing.Point(268, 215)
        Me.zgY.Name = "zgY"
        Me.zgY.ScrollGrace = 0
        Me.zgY.ScrollMaxX = 0
        Me.zgY.ScrollMaxY = 0
        Me.zgY.ScrollMaxY2 = 0
        Me.zgY.ScrollMinX = 0
        Me.zgY.ScrollMinY = 0
        Me.zgY.ScrollMinY2 = 0
        Me.zgY.Size = New System.Drawing.Size(575, 204)
        Me.zgY.TabIndex = 8
        '
        'zgZ
        '
        Me.zgZ.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.zgZ.Location = New System.Drawing.Point(268, 418)
        Me.zgZ.Name = "zgZ"
        Me.zgZ.ScrollGrace = 0
        Me.zgZ.ScrollMaxX = 0
        Me.zgZ.ScrollMaxY = 0
        Me.zgZ.ScrollMaxY2 = 0
        Me.zgZ.ScrollMinX = 0
        Me.zgZ.ScrollMinY = 0
        Me.zgZ.ScrollMinY2 = 0
        Me.zgZ.Size = New System.Drawing.Size(575, 204)
        Me.zgZ.TabIndex = 9
        '
        'gbSettings
        '
        Me.gbSettings.Controls.Add(Me.Label11)
        Me.gbSettings.Controls.Add(Me.txtGMultiplier)
        Me.gbSettings.Controls.Add(Me.Label10)
        Me.gbSettings.Controls.Add(Me.txtSamples)
        Me.gbSettings.Controls.Add(Me.Label9)
        Me.gbSettings.Controls.Add(Me.txtMaxGVal)
        Me.gbSettings.Location = New System.Drawing.Point(12, 142)
        Me.gbSettings.Name = "gbSettings"
        Me.gbSettings.Size = New System.Drawing.Size(250, 102)
        Me.gbSettings.TabIndex = 10
        Me.gbSettings.TabStop = False
        Me.gbSettings.Text = "Settings"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "g multiplier"
        '
        'txtGMultiplier
        '
        Me.txtGMultiplier.Location = New System.Drawing.Point(105, 71)
        Me.txtGMultiplier.Name = "txtGMultiplier"
        Me.txtGMultiplier.Size = New System.Drawing.Size(85, 20)
        Me.txtGMultiplier.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Samples on graphs"
        '
        'txtSamples
        '
        Me.txtSamples.Location = New System.Drawing.Point(105, 45)
        Me.txtSamples.Name = "txtSamples"
        Me.txtSamples.Size = New System.Drawing.Size(85, 20)
        Me.txtSamples.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Max g value ±"
        '
        'txtMaxGVal
        '
        Me.txtMaxGVal.Location = New System.Drawing.Point(105, 19)
        Me.txtMaxGVal.Name = "txtMaxGVal"
        Me.txtMaxGVal.Size = New System.Drawing.Size(85, 20)
        Me.txtMaxGVal.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(56, 502)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 13)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "ROLL"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(179, 502)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(39, 13)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "PITCH"
        '
        'btnAbout
        '
        Me.btnAbout.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAbout.Location = New System.Drawing.Point(12, 599)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(68, 23)
        Me.btnAbout.TabIndex = 17
        Me.btnAbout.Text = "About"
        Me.btnAbout.UseVisualStyleBackColor = True
        '
        'pbxPitch
        '
        Me.pbxPitch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbxPitch.Location = New System.Drawing.Point(142, 376)
        Me.pbxPitch.Name = "pbxPitch"
        Me.pbxPitch.Size = New System.Drawing.Size(120, 120)
        Me.pbxPitch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbxPitch.TabIndex = 14
        Me.pbxPitch.TabStop = False
        '
        'pby
        '
        Me.pby.Image = Global.AxeView.My.Resources.Resources.lateral
        Me.pby.Location = New System.Drawing.Point(142, 500)
        Me.pby.Name = "pby"
        Me.pby.Size = New System.Drawing.Size(25, 20)
        Me.pby.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pby.TabIndex = 13
        Me.pby.TabStop = False
        Me.pby.Visible = False
        '
        'pbxRoll
        '
        Me.pbxRoll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbxRoll.Location = New System.Drawing.Point(12, 376)
        Me.pbxRoll.Name = "pbxRoll"
        Me.pbxRoll.Size = New System.Drawing.Size(120, 120)
        Me.pbxRoll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbxRoll.TabIndex = 12
        Me.pbxRoll.TabStop = False
        '
        'pbX
        '
        Me.pbX.Image = Global.AxeView.My.Resources.Resources.front
        Me.pbX.Location = New System.Drawing.Point(12, 500)
        Me.pbX.Name = "pbX"
        Me.pbX.Size = New System.Drawing.Size(25, 22)
        Me.pbX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbX.TabIndex = 11
        Me.pbX.TabStop = False
        Me.pbX.Visible = False
        '
        'BGDataReceive
        '
        Me.BGDataReceive.WorkerSupportsCancellation = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(855, 627)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.pbxPitch)
        Me.Controls.Add(Me.pby)
        Me.Controls.Add(Me.pbxRoll)
        Me.Controls.Add(Me.pbX)
        Me.Controls.Add(Me.gbSettings)
        Me.Controls.Add(Me.zgZ)
        Me.Controls.Add(Me.zgY)
        Me.Controls.Add(Me.zgX)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpCom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "frmMain"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpCom.ResumeLayout(False)
        Me.grpCom.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbSettings.ResumeLayout(False)
        Me.gbSettings.PerformLayout()
        CType(Me.pbxPitch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pby, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxRoll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbCom As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBaud As System.Windows.Forms.ComboBox
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents grpCom As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtZValue As System.Windows.Forms.TextBox
    Friend WithEvents txtYValue As System.Windows.Forms.TextBox
    Friend WithEvents txtXValue As System.Windows.Forms.TextBox
    Friend WithEvents txtGZValue As System.Windows.Forms.TextBox
    Friend WithEvents txtGYValue As System.Windows.Forms.TextBox
    Friend WithEvents txtGXValue As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAZValue As System.Windows.Forms.TextBox
    Friend WithEvents txtAYValue As System.Windows.Forms.TextBox
    Friend WithEvents txtAXvalue As System.Windows.Forms.TextBox
    Friend WithEvents zgX As ZedGraph.ZedGraphControl
    Friend WithEvents zgY As ZedGraph.ZedGraphControl
    Friend WithEvents zgZ As ZedGraph.ZedGraphControl
    Friend WithEvents gbSettings As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSamples As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtMaxGVal As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtGMultiplier As System.Windows.Forms.TextBox
    Friend WithEvents pbX As System.Windows.Forms.PictureBox
    Friend WithEvents pbxRoll As System.Windows.Forms.PictureBox
    Friend WithEvents pby As System.Windows.Forms.PictureBox
    Friend WithEvents pbxPitch As System.Windows.Forms.PictureBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnAbout As System.Windows.Forms.Button
    Friend WithEvents BGDataReceive As System.ComponentModel.BackgroundWorker

End Class
