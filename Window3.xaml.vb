Imports Microsoft.Win32
Imports System.IO
Imports System.Net.Mime.MediaTypeNames

Public Class Window3

    Inherits Window


    Dim vehicletype As String = "tempname"
    Dim basePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BeamNG.drive")
    Dim DestinationFolder As String = Path.Combine(basePath, "0.32", "vehicles")


    Private selectedFilePath As String





    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        ' Create an instance of OpenFileDialog
        Dim openFileDialog As New OpenFileDialog()

        ' Set filter for file extension and default file extension
        openFileDialog.Filter = "PC files (*.pc)|*.pc|All files (*.*)|*.*"

        ' Display OpenFileDialog by calling ShowDialog method 
        Dim result As Nullable(Of Boolean) = openFileDialog.ShowDialog()

        ' Store the selected file path
        If result = True Then
            selectedFilePath = openFileDialog.FileName
            MessageBox.Show("Selected file: " & selectedFilePath)
        End If
    End Sub

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        If String.IsNullOrEmpty(selectedFilePath) Then
            MessageBox.Show("No file selected. Please select a file first.")
            Return
        End If

        ' Determine the destination file path
        Dim fileName As String = Path.GetFileName(selectedFilePath)
        Dim destinationFilePath As String = Path.Combine(DestinationFolder, vehicletype, fileName)
        MessageBox.Show(destinationFilePath)

        ' Copy the file to the destination folder
        Try
            File.Copy(selectedFilePath, destinationFilePath, True)
            MessageBox.Show("File copied successfully to: " & destinationFilePath)
        Catch ex As Exception
            Directory.CreateDirectory(destinationFilePath)
            MessageBox.Show("Created Folder: " & DestinationFolder & vehicletype & ".")
        End Try
    End Sub


    Private ReadOnly folderMappings As New Dictionary(Of String, String) From {
             {"Autobello Piccolina", "piccolina"},
             {"Autobello Stambecco", "stambecco"},
             {"Bruckel Bastion", "bastion"},
             {"Bruckel Legran", "legran"},
             {"Bruckel Moonhawk", "moonhawk"},
             {"Burnside Special", "burnside"},
             {"Cherrier vivace", "vivace"},
             {"Civetta Bolide", "bolide"},
             {"Civetta scintilla", "scintilla"},
             {"ETK I series", "etki"},
             {"ETK K series", "etkc"},
             {"ETK 800 series", "etk800"},
             {"Wydra", "atv"},
             {"Gavril barstow", "barstow"},
             {"Gavril blueback", "bluebuck"},
             {"Gavril D series", "pickup"},
             {"Gavril H series", "van"},
             {"Gavril Roamer", "roamer"},
             {"Gavril T series", "us_semi"},
             {"Hirochi SBR", "sbr"},
             {"Hirochi autra", "utv"},
             {"Ibishu BX series", "bx"},
             {"Ibishu covet", "covet"},
             {"Ibishu hopper", "hopper"},
             {"Ibishu miramer", "miramer"},
             {"Ibishu wigeon", "wigeon"},
             {"Ibishu pessima MK1", "pessima"},
             {"Ibishu pessima MK2", "midsize"},
             {"Soliad Wendover", "wendover"},
             {"Soliad lansdale", "lansdale"},
             {"Rockbasher", "rockbouncer"},
             {"Dunekicker", "racetruck"}
         }

    Public Sub New()
        InitializeComponent()

        ' Clear existing items if any and set ItemsSource
        listBox.Items.Clear()
        listBox.ItemsSource = folderMappings.Keys.ToList()
    End Sub
    Private Sub listBox_SelectionChanged_1(sender As Object, e As SelectionChangedEventArgs) Handles listBox.SelectionChanged
        ' Retrieve the selected item
        Dim selectedKey As String = CType(listBox.SelectedItem, String)
        MessageBox.Show("selected: " & selectedKey)
        If selectedKey IsNot Nothing AndAlso folderMappings.ContainsKey(selectedKey) Then
            ' Update vehicletype with the corresponding value from the dictionary
            vehicletype = folderMappings(selectedKey)
        End If
    End Sub
End Class
