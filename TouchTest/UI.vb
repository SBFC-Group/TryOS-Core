Imports System.Reflection

Public Class UI
    Public SettingsFolder As String = My.Application.Info.DirectoryPath & "\Settings"
    Public WallpaperFolder As String = My.Application.Info.DirectoryPath & "\Wallpapers"
    Public UsersFolder As String = My.Application.Info.DirectoryPath & "\Users"

    Public AllowOnlyVerifyedShellCode As Boolean = False
    Public NeedThat As Int64 = 1

    'The User that is logged in's Folder
    Public UserFolder As String = My.Application.Info.DirectoryPath & "\Users\"

    Public Sub RunCommands(Command As String, Optional TheForm As Object = Nothing)
        If Command.Contains("exit") = True Then
            Try
                TheForm.Close()
            Catch ex As Exception

            End Try
        ElseIf Command.Contains("end") = True Then
            Try
                End
            Catch ex As Exception
                System.Threading.Thread.Sleep(1000)
            End Try

        ElseIf Command.Contains("windowmode=mini") = True Then
            Try
                TheForm.WindowState = FormWindowState.Minimized
                TheForm.ShowInTaskbar = False
            Catch ex As Exception

            End Try
        ElseIf Command.Contains("run ") = True Then
            Dim Text1 As String = Command
            Text1 = Text1.Replace("Console>", "")
            Text1 = Text1.Replace("run ", "")
            RunShellPrograms(Text1)
        ElseIf Command.Contains("start ") = True Then
            Dim Text1 As String = Command
            Text1 = Text1.Replace("Console>", "")
            Text1 = Text1.Replace("start ", "")
            OpenFormByName("TouchTest." & Text1)
        ElseIf Command.Contains("Loadjpg ") = True Then
            Dim Text1 As String = Command
            Text1 = Text1.Replace("Console>", "")
            Text1 = Text1.Replace("Loadjpg ", "")
            UploadWallpaperToShell(Convert.ToInt64(Text1), "jpg")
        ElseIf Command.Contains("Loadpng ") = True Then
            Dim Text1 As String = Command
            Text1 = Text1.Replace("Console>", "")
            Text1 = Text1.Replace("Loadpng ", "")
            UploadWallpaperToShell(Convert.ToInt64(Text1), "png")
        ElseIf Command.Contains("Loadgif ") = True Then
            Dim Text1 As String = Command
            Text1 = Text1.Replace("Console>", "")
            Text1 = Text1.Replace("Loadgif ", "")
            UploadWallpaperToShell(Convert.ToInt64(Text1), "gif")
        ElseIf Command.Contains("RunUserControl ") = True Then
            Dim Text1 As String = Command
            Text1 = Text1.Replace("Console>", "")
            Text1 = Text1.Replace("RunUserControl ", "")
            RunUserControl(Text1)
        ElseIf Command.Contains("RunTestSniper") = True Then
            Dim gg As New Sniper
            gg.ShowDialog()
        End If
    End Sub
    Public Sub StartCMD(Optional GG As String = "New")
        Commander.Show()
        Commander.WindowState = FormWindowState.Normal
        Commander.FormBorderStyle = FormBorderStyle.Sizable
    End Sub

    Public Sub RunUserControl(UserControl As String)
        Dim UserControlThing = UserControl
        If UserControl = "InfoApp" Then
            'Dim WindowThing As New Form
            'Dim UserControlThing2 As New InfoApp
            'WindowThing.Dock = DockStyle.None
            'WindowThing.Controls.Add(UserControlThing2)
            'WindowThing.Size = UserControlThing2.Size
            'WindowThing.Text = UserControlThing2.Name
            'WindowThing.Show()
        End If
    End Sub


    Public Sub LoadShell(Optional Username As String = "", Optional Password As String = "")
        'form1.Show()
        'Form1.Panel2.BackColor = Color.FromArgb(55, Color.Silver)
        'Form1.TimebarPanel.BackColor = Color.FromArgb(55, Color.Silver)
        If Username = "" Then

        Else
            'Form1.Username = Username
            'Form1.Password = Password
        End If
    End Sub

    Public Sub RunShellPrograms(Run_ As String)
        If Run_ = "shell" Then
            LoadShell()
            Console.ShowInTaskbar = False
            Console.WindowState = FormWindowState.Minimized
        ElseIf Run_ = "Data" Then
            Data_Formater.Show()
        End If
    End Sub

    Public Sub Run(Run_ As String)

        If Run_ = "AppRunner" Then
            AppRunner.Show()
        ElseIf Run_ = "Console" Then
            Console.Show()
        ElseIf Run_ = "UI" Then
            Show()
        ElseIf Run_ = "About2" Then
            About2.Show()
        ElseIf Run_ = "Data Formater" Then
            Data_Formater.Show()
        ElseIf Run_ = "HelpWindow" Then
            HelpWindow.Show()
        ElseIf Run_ = "DebugApp" Then
            DebugApp.Show()
        ElseIf Run_ = "Commander" Then
            Commander.Show()
        ElseIf Run_ = "TryController" Then
            TryController.Show()
        ElseIf Run_ = "About2" Then
            About2.Show()
        End If
    End Sub

    Public Sub RunApp(Run_ As String, Optional arg1 As String = "Null=Nothing")

    End Sub

    Public GiveValuestoForm1 As Boolean = True
    Public WallpaperNumber As Integer = 1
    Public Sub UploadWallpaperToShell(Number As Integer, FileFormat As String)
        If FileFormat.StartsWith(".") Then
            FileFormat = FileFormat.Replace(".", "")
        End If
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Wallpapers\Wallpaper_" & Number.ToString & "." & FileFormat) Then
            WallpaperNumber = Number

            Dim Test As Bitmap = Bitmap.FromFile(WallpaperFolder & "\Wallpaper_" & Number.ToString & "." & FileFormat)
            'Dim sd As New PictureBox
            'sd.Load(My.Application.Info.DirectoryPath & "\Wallpapers\Wallpaper_" & Number.ToString & "." & FileFormat)
            'Form1.Panel1.BackgroundImage = Test
            If GiveValuestoForm1 = True Then
                'Form1.LoadedWallpaper = Number
                'Form1.WallpaperFileFormat = FileFormat
            End If
        Else
            If Number = 0 Then
            Else
                Dim Number2 As Integer = Number
                Number2 = Number2 - 1
                UploadWallpaperToShell(Number2, FileFormat)
            End If
        End If
    End Sub

    Public InfoForms_Info As String = "OnlyOkButton"

    Public Sub GetIntoToInfoForm(Optional OnlyOk As Boolean = True, Optional OKCancelOrYesNo As Boolean = False)
        If OnlyOk = True Then
            InfoForms_Info = "OnlyOkButton"
        ElseIf OnlyOk = False Then
            If OKCancelOrYesNo = True Then
                InfoForms_Info = "YesNoButton"
            ElseIf OKCancelOrYesNo = False Then
                InfoForms_Info = "OKCancelButton"
            End If
        End If
    End Sub

    ' GetIntoToInfoForm(True)
    '        InfoDialog.TextBox1.Text = "This is a test"
    '        If InfoDialog.ShowDialog = DialogResult.OK Then
    '            MsgBox("This Worked!")
    '        End If
    'ElseIf CommandText.Contains("msg 2ok") = True Then
    '        GetIntoToInfoForm(False, False)
    '        InfoDialog.TextBox1.Text = "This is a test"
    '        If InfoDialog.ShowDialog = DialogResult.OK Then
    '            MsgBox("This Worked!")
    '        End If
    'ElseIf CommandText.Contains("msg cal") = True Then
    '        GetIntoToInfoForm(False, False)
    '        InfoDialog.TextBox1.Text = "This is a test"
    '        If InfoDialog.ShowDialog = DialogResult.Cancel Then
    '            MsgBox("This Worked!")
    '        End If
    'ElseIf CommandText.Contains("msg yes") = True Then
    '        GetIntoToInfoForm(False, True)
    '        InfoDialog.TextBox1.Text = "This is a test"
    '        If InfoDialog.ShowDialog = DialogResult.Yes Then
    '            MsgBox("This Worked!")
    '        End If
    'ElseIf CommandText.Contains("msg no") = True Then
    '        GetIntoToInfoForm(False, True)
    '        InfoDialog.TextBox1.Text = "This is a test"
    '        If InfoDialog.ShowDialog = DialogResult.No Then
    '            MsgBox("This Worked!")
    '        End If

    Public Sub OpenFormByName(formName As String)
        ' Get the current assembly
        Dim asm As Assembly = Assembly.GetExecutingAssembly()

        ' Get the type from the assembly by name
        Dim formType As Type = asm.GetType(formName)

        ' Check if the type exists and is a Form
        If formType IsNot Nothing AndAlso formType.IsSubclassOf(GetType(Form)) Then
            ' Create an instance of the form dynamically
            Dim formInstance As Form = CType(Activator.CreateInstance(formType), Form)
            Try
                formInstance.Show()
            Catch ex As Exception

            End Try
        Else
            MsgBox("Form '" & formName & "' not found or is not a valid Form.")
        End If
    End Sub

    Public Function GetForm(formName As String) As Object
        ' Get the current assembly
        Dim asm As Assembly = Assembly.GetExecutingAssembly()

        ' Get the type from the assembly by name
        Dim formType As Type = asm.GetType(formName)

        ' Check if the type exists and is a Form
        If formType IsNot Nothing AndAlso formType.IsSubclassOf(GetType(Form)) Then
            ' Create an instance of the form dynamically
            Dim formInstance As Form = CType(Activator.CreateInstance(formType), Form)
            'formInstance.Show()
            Return formInstance
        Else
            MsgBox("Form '" & formName & "' not found or is not a valid Form.")
            Return Nothing
        End If
    End Function

    Public Sub ChangeObjectPropertyByName(container As Object, objectName As String, propertyName As String, value As Object)
        ' Get the field (control) from the container using reflection
        Dim objField As FieldInfo = container.GetType().GetField(objectName, BindingFlags.NonPublic Or BindingFlags.Instance)

        If objField IsNot Nothing Then
            Dim controlObj As Object = objField.GetValue(container)

            ' Get the property to change
            Dim prop As PropertyInfo = controlObj.GetType().GetProperty(propertyName)

            If prop IsNot Nothing AndAlso prop.CanWrite Then
                prop.SetValue(controlObj, value)
            Else
                MessageBox.Show("Property not found or not writable.")
            End If
        Else
            MessageBox.Show("Object not found.")
        End If
    End Sub
    'ChangeObjectPropertyByName(Me, "Button1", "Text", "Clicked!")

    Public Sub ShowStopWindow(ex As Exception)
        Dim MyForm As New StopWindow
        MyForm.RichTextBox1.Text = ex.Message & "

" & ex.Source
        MyForm.Show()
    End Sub

    Public Sub ShowStopWindow(ex As String)
        Dim MyForm As New StopWindow
        MyForm.RichTextBox1.Text = ex
        MyForm.Show()
    End Sub

    Public Sub ShowStopWindow(ex As String, source As String)
        Dim MyForm As New StopWindow
        MyForm.FullStopMessage = ex
        MyForm.RichTextBox1.Text = ex & "

" & source

        MyForm.Show()
    End Sub

    Public Sub ShowError()
        ErrorMSGBox.ShowError("", ErrorMSGBox.Alerts.Information)
    End Sub

    Public Sub ShowError(Text As String)
        ErrorMSGBox.ShowError(Text, ErrorMSGBox.Alerts.Information)
    End Sub

    Public Sub ShowError(Text As String, Alert As ErrorMSGBox.Alerts)
        ErrorMSGBox.ShowError(Text, Alert)
    End Sub

End Class