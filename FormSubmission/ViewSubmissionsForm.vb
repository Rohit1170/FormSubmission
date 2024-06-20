Imports System.Net.Http
Imports Newtonsoft.Json

Public Class ViewSubmissionsForm
    Private currentSubmissionIndex As Integer = 0 ' Stores the index of the currently displayed submission
    Private client As New HttpClient() ' Initialize HttpClient for API calls
    Private totalSubmissions As Integer = 0

    Private Async Sub ViewSubmissionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        totalSubmissions = Await GetTotalSubmissions() ' Load the total number of submissions
        If totalSubmissions > 0 Then
            LoadData(currentSubmissionIndex) ' Load initial data
        Else
            MessageBox.Show("No submissions found.", "Info")
        End If
    End Sub

    Private Async Sub LoadData(index As Integer)
        Dim url As String = "http://localhost:3000/read?index=" & index
        Dim response As HttpResponseMessage = Await client.GetAsync(url)

        If response.IsSuccessStatusCode Then
            Dim jsonResponse As String = Await response.Content.ReadAsStringAsync()
            Dim submission As Dictionary(Of String, String) = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(jsonResponse)

            ' Update TextBoxes with retrieved information
            NameTextBox.Text = submission("name")
            EmailTextBox.Text = submission("email")
            PhoneNumberTextBox.Text = submission("phone")
            GithubLinkTextBox.Text = submission("github_link")
            Stoptext.Text = submission("stopwatch_time")
        Else
            MessageBox.Show("Error loading data. Please try again.", "Error")
        End If
    End Sub

    Private Async Function GetTotalSubmissions() As Task(Of Integer)
        Dim url As String = "http://localhost:3000/total"
        Dim response As HttpResponseMessage = Await client.GetAsync(url)

        If response.IsSuccessStatusCode Then
            Dim jsonResponse As String = Await response.Content.ReadAsStringAsync()
            Dim total As Dictionary(Of String, Integer) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Integer))(jsonResponse)

            ' Return the total number of submissions
            Return total("count")
        Else
            MessageBox.Show("Error retrieving total submissions. Please try again.", "Error")
            Return 0
        End If
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If currentSubmissionIndex > 0 Then
            currentSubmissionIndex -= 1
            LoadData(currentSubmissionIndex)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If currentSubmissionIndex < totalSubmissions - 1 Then
            currentSubmissionIndex += 1
            LoadData(currentSubmissionIndex)
        End If
    End Sub

    Private Sub Next_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.N Then
            Button2.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub Prev_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.P Then
            Button1.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub Edit_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.E Then
            Button3.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim submission As New Dictionary(Of String, String) From {
            {"name", NameTextBox.Text},
            {"email", EmailTextBox.Text},
            {"phone", PhoneNumberTextBox.Text},
            {"github_link", GithubLinkTextBox.Text},
            {"stopwatch_time", Stoptext.Text}
        }
        Dim editSubmissionForm As New edit(currentSubmissionIndex, submission)
        editSubmissionForm.ShowDialog()

        ' After editing, refresh the data
        LoadData(currentSubmissionIndex)
    End Sub
End Class
