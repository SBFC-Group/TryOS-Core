Public Class TryController
    Private Sub TryController_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim args As String = Environment.CommandLine

        If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\ShellName.setting") Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(UI.SettingsFolder & "\ShellName.setting")
            UI.OpenFormByName(Reader)

            Dim form As Form = UI.GetForm(Reader)
            form.BringToFront()

            Me.WindowState = FormWindowState.Minimized

            Me.ShowInTaskbar = False
        Else
            Console.Show()
            Me.WindowState = FormWindowState.Minimized
        End If

        If args.Contains("/DevMode") = True Then
            Dev = True
        End If

        If args.Contains("/TurnOff_VerifyedShellOnly") = True Then
            UI.AllowOnlyVerifyedShellCode = False
        End If



        If UI.AllowOnlyVerifyedShellCode = False Then
            If UI.NeedThat = 1 Then
                UI.ShowError("Your running in an unsafe mode. Close the program if you don't know what you're doing.", ErrorMSGBox.Alerts.Information)
            End If
        End If

        If args.Contains("/ShowConsole") = True Then
            Console.Show()
            Console.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Public Dev As Boolean = False

    Public Enum Roles
        Guest = 1
        Standard = 2
        Administrator = 3
        Program = 4
        Developer = 5
    End Enum
End Class