Module Module1

    Sub Main()
        Dim drawingUID As String = "drawingUID"
        Dim DestPathContractDB As String = "DestPathContractDB"
        Dim LinkPath As String = "LinkPath"
        Dim scanFilename As String = "scanFilename"
        Dim jsonString As String = "{ ""id"": """ + drawingUID + """, ""fullPath"": """ + DestPathContractDB + """, ""link"": """ + LinkPath + """, ""scanFilename"": """ + scanFilename + """ }"
        Console.WriteLine(jsonString)
    End Sub

End Module
