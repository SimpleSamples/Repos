Public Class UserControl1
    Public Delegate Sub ButtonClickedEvent(ByVal text As String)
    Public ButtonClicked As ButtonClickedEvent = Nothing
    Public Delegate Sub SomethingChangedEvent(ByVal text As String)
    Public SomethingChanged As SomethingChangedEvent = Nothing

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ButtonClicked?.Invoke("Button clicked at " & Date.Now.ToString())
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        SomethingChanged?.Invoke(TextBox1.Text)
    End Sub
End Class
