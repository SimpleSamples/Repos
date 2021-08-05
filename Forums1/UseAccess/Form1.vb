Imports System.Data.OleDb

' How to use MS Access database with VB.NET 2019
' https://docs.microsoft.com/en-us/answers/questions/324217/how-to-use-ms-access-database-with-vbnet-2019.html?childToView=324328#answer-324328

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cs As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\Sam\Documents\db1.mdb"
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter
        Dim q As String = "Select ShowName from ShowsFall2014"
        da = New OleDbDataAdapter(q, cs)
        ds.Tables.Add(dt)
        da.Fill(dt)
        DataGridView1.DataSource = dt.DefaultView
    End Sub
End Class
