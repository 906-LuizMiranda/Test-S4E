Public Class welcome
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim menu As New menu()
        menu.Show()
        Me.Hide()
    End Sub
End Class