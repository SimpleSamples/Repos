Module Module1

    Sub Main()
        RunByIP("10.10.11.1")
        RunByIP("10.140.10.1")
    End Sub

    Sub RunByIP(ipString As String)
        Dim ipArray() As String = Split(ipString, ".")
        If ipArray(0) <> "10" Then
            Exit Sub
        End If
        If ipArray(1) = "10" And (ipArray(2) = "11" Or ipArray(2) = "12") Then
            Console.WriteLine("run command")
        Else
            If ipArray(1) = "140" Then
                If ipArray(2) = "10" Or ipArray(2) = "11" Then
                    Console.WriteLine("run 2nd command")
                End If
            End If
        End If
    End Sub
End Module

' If IP address is 10.10.11.x or 10.10.12.x then run command
' If IP address Is 10.140.10.x Or 10.140.11.x Then run 2nd command