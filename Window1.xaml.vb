Imports System.IO
Imports System.Net.Mime.MediaTypeNames

Public Class Window1
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim screenshotsPath = FindBeamNGScreenshotsFolder()
        Process.Start("explorer.exe", screenshotsPath)
    End Sub

    Private Function FindBeamNGScreenshotsFolder() As String
        Dim basePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BeamNG.drive")
        Dim screenshotsFolderPath As String = Path.Combine(basePath, "0.32", "screenshots")

        If Directory.Exists(screenshotsFolderPath) Then
            Return screenshotsFolderPath
        End If

        Return Nothing
    End Function

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

        ' Define the path to the BeamNG screenshots folder
        Dim basePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BeamNG.drive")
        Dim screenshotsFolder As String = Path.Combine(basePath, "0.32", "screenshots")
        ' Get the most recent 11 image files
        Dim recentImages = Directory.GetFiles(screenshotsFolder, "*.png", SearchOption.AllDirectories).
                                OrderByDescending(Function(f) File.GetLastWriteTime(f)).
                                Take(11).ToArray()

        ' Get references to the Image controls
        Dim images() As System.Windows.Controls.Image = {image1, image2, image3, image4, image5, image6, image7, image8, image9, image10, image11}

        For i As Integer = 0 To recentImages.Length - 1
            Dim bitmap As New BitmapImage()
            bitmap.BeginInit()
            bitmap.UriSource = New Uri(recentImages(i))
            bitmap.EndInit()

            images(i).Source = bitmap
        Next
    End Sub


End Class
