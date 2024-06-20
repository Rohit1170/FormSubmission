Imports System.Net.Http
Imports System.Diagnostics

Public Class CreateNewSubmissionForm
    Private stopwatch As New Stopwatch()

    Private isRunning As Boolean = False
    Dim client As New HttpClient()  ' Initialize HttpClient for API calls
    Private WithEvents updateTimer As New Timer()

    Private Sub CreateNewSubmissionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True

        ' Set initial display to "00:00:00"
        Stoptext.Text = "00:00:00"

        ' Set timer interval to 100 milliseconds (0.1 second)
        updateTimer.Interval = 100
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Not isRunning Then
            stopwatch.Start()
            isRunning = True
            Button1.Text = "Stop Stopwatch"
            updateTimer.Start()
        Else
            stopwatch.Stop()
            isRunning = False
            Button1.Text = "Start Stopwatch"
            updateTimer.Stop()
            UpdateStopwatchTime()  ' Update the displayed time
        End If
    End Sub

    Private Sub UpdateStopwatchTime()
        Stoptext.Text = stopwatch.Elapsed.ToString("hh\:mm\:ss")  ' Format the elapsed time
    End Sub

    Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Collect data from TextBoxes
        Dim name As String = NameTextBox.Text
        Dim email As String = EmailTextBox.Text
        Dim phoneNumber As String = PhoneNumberTextBox.Text
        Dim githubLink As String = GithubLinkTextBox.Text
        Dim stopwatchTime As String = Stoptext.Text

        ' Build URL for backend API endpoint (replace with your actual server address and port)
        Dim url As String = "http://localhost:3000/submit"  ' Replace with your server address and port

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
            ' Submission successful!
            MessageBox.Show("Submission successful!", "Success")
        Else
            ' Handle error (e.g., display an error message)
            MessageBox.Show("Error submitting data. Please try again.", "Error")
        End If
        NameTextBox.Text = ""
        EmailTextBox.Text = ""
        PhoneNumberTextBox.Text = ""
        GithubLinkTextBox.Text = ""
        Stoptext.Text = "00:00:00"  ' Reset stopwatch display

        ' Stop the stopwatch if it's running
        If isRunning Then
            Button1.PerformClick()
            Stoptext.Text = "00:00:00"
        End If
    End Sub

    Private Sub CreateNewSubmissionForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.T Then
            Button1.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            Button2.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub updateTimer_Tick(sender As Object, e As EventArgs) Handles updateTimer.Tick
        ' Update the displayed time
        UpdateStopwatchTime()
    End Sub

End Class
