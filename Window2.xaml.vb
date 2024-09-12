Public Class Window2
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim window1 As New Window1()
        window1.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As RoutedEventArgs)
        Dim window3 As New Window3()
        window3.Show()
    End Sub
End Class
