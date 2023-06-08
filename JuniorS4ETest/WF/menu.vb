Public Class menu
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim company As New company()
        company.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim associate As New associate()
        associate.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
    End Sub
End Class