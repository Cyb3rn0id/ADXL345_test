Public Class frmAbout

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblTitle.Text = Application.ProductName & " v." & Application.ProductVersion
        txtDesc.Text = "Version " & Application.ProductVersion & vbCrLf & vbCrLf & _
        "Author: Bernardo Giovanni" & vbCrLf & vbCrLf & _
        Application.ProductName & " shows data from a 3-axis accelerometer connected on serial port. Data must be sent in the form: x,y,z\n\r"
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Diagnostics.Process.Start("http://www.robot-italy.com?app=" & Application.ProductName)
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        System.Diagnostics.Process.Start("http://www.settorezero.com?app=" & Application.ProductName)
    End Sub
End Class