Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Configuration
Imports Microsoft.Win32
Imports System.Net.Http
Imports System.Collections.ObjectModel
Imports System.Drawing.Imaging


Class MainWindow

    Private Sub Button_Click_7(sender As Object, e As RoutedEventArgs)
        'Dim renderengine = selectedGraphicsOption

        Dim beamNGPath = Path.Combine(GetBeamNGInstallPath)
        If Directory.Exists(beamNGPath) Then
            Dim apppath = Path.Combine(beamNGPath, "BeamNG.drive.x64.exe")
            'MessageBox.Show(apppath)
            If File.Exists(apppath) Then
                Dim startInfo As New ProcessStartInfo(apppath)
                startInfo.Arguments = "-gfx dx11"
                Process.Start(startInfo)
            Else
                'messageBox.Show("The Application file was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            'MessageBox.Show("BeamNG.drive is not installed in the Steam library.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'MessageBox.Show(beamNGPath)
            'Dim test = GetBeamNGInstallPath()
            'MessageBox.Show(test)
            'these are for debugging purposes only
        End If

    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub Button_Click_8(sender As Object, e As RoutedEventArgs)
        'Dim renderengine = selectedGraphicsOption

        Dim beamNGPath = Path.Combine(GetBeamNGInstallPath)
        If Directory.Exists(beamNGPath) Then
            Dim apppath = Path.Combine(beamNGPath, "BeamNG.drive.x64.exe")
            'MessageBox.Show(apppath)
            If File.Exists(apppath) Then
                Dim startInfo As New ProcessStartInfo(apppath)
                startInfo.Arguments = "-gfx vk"
                Process.Start(startInfo)
            Else
                'messageBox.Show("The Application file was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            'MessageBox.Show("BeamNG.drive is not installed in the Steam library.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'MessageBox.Show(beamNGPath)
            'Dim test = GetBeamNGInstallPath()
            'MessageBox.Show(test)
            'these are for debugging purposes only
        End If
    End Sub

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub Button_Click_2(sender As Object, e As RoutedEventArgs)
        Dim window2 As New Window2()
        window2.Show()
    End Sub

    Private Sub Button_Click_3(sender As Object, e As RoutedEventArgs)
        Dim psi As New ProcessStartInfo
        psi.UseShellExecute = True
        psi.FileName = "https://discord.gg/beamng"
        Process.Start(psi)
    End Sub

    Private Sub Button_Click_4(sender As Object, e As RoutedEventArgs)
        Dim modsPath = FindBeamNGModsFolder()

        If Not String.IsNullOrEmpty(modsPath) AndAlso Directory.Exists(modsPath) Then
            Process.Start("explorer.exe", modsPath)
        Else
            MessageBox.Show("The mods folder could not be found.", "Error")
        End If
    End Sub








    ' Everything Below is all used in other sections. Above are for buttons, image boxes or any other UI elements










    Private Function GetBeamNGInstallPath() As String
        ' Get the Steam installation path from the registry
        Dim regKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\WOW6432Node\Valve\Steam")

        If regKey IsNot Nothing Then
            Dim steamPath As String = regKey.GetValue("InstallPath").ToString()

            ' Check the default library folder
            Dim defaultGamePath As String = Path.Combine(steamPath, "steamapps\common\BeamNG.drive\Bin64")
            If Directory.Exists(defaultGamePath) Then
                Return defaultGamePath
            End If

            ' Check other library folders from the libraryfolders.vdf file
            Dim libraryFoldersPath As String = Path.Combine(steamPath, "steamapps\libraryfolders.vdf")

            If File.Exists(libraryFoldersPath) Then
                ' Read the libraryfolders.vdf file
                Dim lines As String() = File.ReadAllLines(libraryFoldersPath)

                For Each line As String In lines
                    If line.Contains("path") Then
                        ' Extract the path from the line
                        Dim parts As String() = line.Split(""""c)
                        If parts.Length >= 4 Then
                            Dim libraryPath As String = parts(3).Replace("\\", "\")
                            Dim gamePath As String = Path.Combine(libraryPath, "steamapps\common\BeamNG.drive\Bin64")
                            If Directory.Exists(gamePath) Then
                                Return gamePath
                            End If
                        End If
                    End If
                Next
            End If
        End If

        ' Game not found in any library folder
        Return Nothing
    End Function

    Private Function FindBeamNGModsFolder() As String
        Dim basePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BeamNG.drive")
        Dim modsFolderPath As String = Path.Combine(basePath, "0.32", "mods")

        If Directory.Exists(modsFolderPath) Then
            Return modsFolderPath
        End If

        Return Nothing
    End Function

    Private Function GetVehiclePath(debug As Boolean) As String
        Dim vehiclesPath As String = IO.Path.Combine("BeamNG.drive", "0.32", "vehicles") ' Corrected path
        Return vehiclesPath
    End Function

End Class
