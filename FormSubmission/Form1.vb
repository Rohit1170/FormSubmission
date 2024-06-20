Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Enable key preview to handle key events at the form level
        Me.KeyPreview = True
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim viewSubmissionsForm As New ViewSubmissionsForm()
        viewSubmissionsForm.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim createNewSubmissionForm As New CreateNewSubmissionForm()
        createNewSubmissionForm.Show()
    End Sub

    Private Sub View_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then

            Button1.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub Create_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.N Then

            Button2.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

End Class