Public Class Form1

    Public Sub New()
        InitializeComponent()
        UserControl11.ButtonClicked = AddressOf ButtonClicked
        UserControl11.SomethingChanged = AddressOf SomethingChanged
    End Sub

    Private Sub ButtonClicked(ByVal text As String)
        Label1.Text = text
    End Sub

    Private Sub SomethingChanged(ByVal text As String)
        Label2.Text = text
    End Sub
End Class
