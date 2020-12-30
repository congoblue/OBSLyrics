Imports System.IO

Public Class Form1
    Sub Select2Lines()
        'Get the current line
        Dim current_line As Integer = TextBox1.GetLineFromCharIndex(TextBox1.SelectionStart)
        'Get the length of the line
        Dim i
        Dim tlen = 0
        For i = 1 To CInt(TextBox3.Text)
            tlen = tlen + TextBox1.Lines(current_line + i - 1).Length + 2
        Next
        tlen = tlen - 2

        'Start the selection at the beginning of the line we clicked
        TextBox1.SelectionStart = TextBox1.GetFirstCharIndexFromLine(current_line)

        'Select that line's length
        TextBox1.SelectionLength = tlen '2 for the vbcrlf

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Len(TextBox1.SelectedText) = 0 Then
            Button4.PerformClick()
        Else
            'select the previous n lines
            Dim i As Integer
            For i = 1 To CInt(TextBox3.Text)
                If TextBox1.SelectionStart > 2 Then
                    TextBox1.SelectionStart = TextBox1.SelectionStart - 2
                    Dim current_line As Integer = TextBox1.GetLineFromCharIndex(TextBox1.SelectionStart)
                    TextBox1.SelectionStart = TextBox1.GetFirstCharIndexFromLine(current_line)
                Else
                    TextBox1.SelectionStart = 0
                    Exit For
                End If
            Next
            Select2Lines()

            Dim sw As New StreamWriter(File.Open(TextBox2.Text, FileMode.Create)) 'the file obs is using
            sw.WriteLine(TextBox1.SelectedText)
            sw.Close()
        End If
        Button5.Text = "Blank"

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\obscaption.txt"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Len(TextBox1.SelectedText) = 0 Then
            Button4.PerformClick()
        Else
            'select the following 2 lines so we can see where we are
            Dim ns = TextBox1.SelectionStart + TextBox1.SelectionLength + 2
            If (ns < TextBox1.TextLength) Then
                TextBox1.SelectionStart = ns
                Select2Lines()
            Else
                TextBox1.SelectionLength = 0
            End If

            Dim sw As New StreamWriter(File.Open(TextBox2.Text, FileMode.Create)) 'the file obs is using
            sw.WriteLine(TextBox1.SelectedText)
            sw.Close()
        End If
        Button5.Text = "Blank"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.SelectionStart = 0
        Select2Lines()

        Dim sw As New StreamWriter(File.Open(TextBox2.Text, FileMode.Create)) 'the file obs is using
        sw.WriteLine(TextBox1.SelectedText)
        sw.Close()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Button5.Text = "Blank" Then
            Dim sw As New StreamWriter(File.Open(TextBox2.Text, FileMode.Create)) 'the file obs is using
            sw.Close()
            Button5.Text = "Unblank"
        Else
            Dim sw As New StreamWriter(File.Open(TextBox2.Text, FileMode.Create)) 'the file obs is using
            sw.WriteLine(TextBox1.SelectedText)
            sw.Close()
            Button5.Text = "Blank"
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class
