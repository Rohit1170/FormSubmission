Imports System.Net.Http
Imports Newtonsoft.Json

Public Class edit
    Private client As New HttpClient()
    Private submissionIndex As Integer

    Private Sub edit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.KeyPreview = True
    End Sub
    Public Sub New(index As Integer, submission As Dictionary(Of String, String))
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        submissionIndex = index

        ' Initialize text boxes with submission data
        NameTextBox.Text = submission("name")
        EmailTextBox.Text = submission("email")
        PhoneNumberTextBox.Text = submission("phone")
        GithubLinkTextBox.Text = submission("github_link")
        Stoptext.Text = submission("stopwatch_time")
    End Sub



    Private Async Sub SaveButton_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Collect data from TextBoxes
        Dim name As String = NameTextBox.Text
        Dim email As String = EmailTextBox.Text
        Dim phoneNumber As String = PhoneNumberTextBox.Text
        Dim githubLink As String = GithubLinkTextBox.Text
        Dim stopwatchTime As String = Stoptext.Text

        ' Build URL for backend API endpoint (replace with your actual server address and port)
        Dim url As String = "http://localhost:3000/update?index=" & submissionIndex

        ' Create FormUrlEncodedContent object for form data
        Dim content As New FormUrlEncodedContent(New Dictionary(Of String, String)() From {
            {"name", name},
            {"email", email},
            {"phone", phoneNumber},
            {"github_link", githubLink},
            {"stopwatch_time", stopwatchTime}
        })

        ' Make POST request to submit data
        Dim response As HttpResponseMessage = Await client.PostAsync(url, content)

        If response.IsSuccessStatusCode Then
            ' Update successful!
            MessageBox.Show("Update successful!", "Success")
            Me.Close()
        Else
            ' Handle error (e.g., display an error message)
            MessageBox.Show("Error updating data. Please try again.", "Error")
        End If
    End Sub
    Private Sub Save_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.S Then

            Button2.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub Edit_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.D Then

            Button1.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Async Function Button1_ClickAsync(sender As Object, e As EventArgs) As Task Handles Button1.Click
        Dim url As String = "http://localhost:3000/delete?index=" & submissionIndex

        ' Make DELETE request to delete data
        Dim response As HttpResponseMessage = Await client.DeleteAsync(url)

        If response.IsSuccessStatusCode Then
            ' Deletion successful!
            MessageBox.Show("Deletion successful!", "Success")
            Me.Close()
        Else
            ' Handle error (e.g., display an error message)
            MessageBox.Show("Error deleting data. Please try again.", "Error")
        End If
    End Function
End Class