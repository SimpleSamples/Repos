Class MainWindow
    Private Sub ClickMe_Click(sender As Object, e As RoutedEventArgs) Handles ClickMe.Click
        HelloMessage.Text = "Hello, Windows 10 IoT Core!"
    End Sub

    Private Sub NumberButton_Click(sender As Object, e As RoutedEventArgs)
        Dim b As Button = TryCast(sender, Button)
        If b Is Nothing Then
            Return
        End If
        HelloMessage.Text = b.Content(1)
    End Sub

    Private Sub OperationButton_Click(sender As Object, e As RoutedEventArgs)
        Dim b As Button = TryCast(sender, Button)
        If b Is Nothing Then
            Return
        End If
        HelloMessage.Text = b.Content(1)
    End Sub
End Class
