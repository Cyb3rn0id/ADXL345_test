Public Class Settings

    Public GMultiplier As Double = 0.004
    Public MaxGValue As Double = 2
    Public MaxSamples As Int64 = 50
    Public ComPort As String = "COM1"
    Public BaudRate As String = "115200"


    ''' <summary>
    ''' Salva la impostazioni nel file specificato
    ''' </summary>
    ''' <param name="File">Nome del file</param>
    ''' <remarks></remarks>
    Public Sub Save(ByVal File As String)
        Dim F As New IO.FileStream(File, IO.FileMode.Create)
        Dim S As New Xml.Serialization.XmlSerializer(Me.GetType)
        S.Serialize(F, Me)
        F.Close()
    End Sub
    ''' <summary>
    ''' Carica le impostazioni dal file specificato
    ''' </summary>
    ''' <param name="File">File XML da cui caricare le impostazioni</param>
    ''' <returns>Oggetto Settings</returns>
    ''' <remarks></remarks>
    Public Function Load(ByVal File As String)
        Dim F As New IO.FileStream(File, IO.FileMode.Open)
        Dim S As New Xml.Serialization.XmlSerializer(Me.GetType)
        Dim Obj As Settings
        Obj = S.Deserialize(F)
        F.Close()
        Return Obj
    End Function

End Class
