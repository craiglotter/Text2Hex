Public Class Form1
    Private Sub Error_Handler(ByVal except As Exception, Optional ByVal message As String = "")
        Try
            MsgBox("The following error was trapped: (" & message & ") " & vbCrLf & except.ToString, MsgBoxStyle.Critical, "Critical Error")
        Catch ex As Exception
            MsgBox("The Error Handler failed due to: " & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Critical Error")
        End Try
    End Sub

    Private Sub GenerateValues()
        Try
            Dim result As String = ""
            Dim chr As Char

            For Each chr In TextBox1.Text.ToCharArray
                result = result & (Hex(Asc(chr)))
            Next
            TextBox2.Tag = result
            If RadioButton1.Checked = True Then
                If result.Length > 10 Then
                    TextBox2.Text = result.Substring(0, 10)
                Else
                    TextBox2.Text = result
                End If
            End If
            If RadioButton2.Checked = True Then
                If result.Length > 26 Then
                    TextBox2.Text = result.Substring(0, 26)
                Else
                    TextBox2.Text = result
                End If
            End If
            If RadioButton3.Checked = True Then
                TextBox2.Text = result
            End If
            counter1.Text = TextBox1.Text.Length
            counter2.Text = TextBox2.Text.Length
        Catch ex As Exception
            Error_Handler(ex, "GenerateValues")
        End Try
    End Sub

    Private Sub InputCapture(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Try
            GenerateValues()
        Catch ex As Exception
            Error_Handler(ex, "InputCapture")
        End Try
    End Sub

    Private Sub RadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged, RadioButton3.CheckedChanged
        Try
            GenerateValues()
        Catch ex As Exception
            Error_Handler(ex, "InputCapture")
        End Try
    End Sub
End Class
