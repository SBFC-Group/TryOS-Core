Namespace CustomController_Data
    Public Class CustomController_Handler
        Implements CustomController_UI_Handler

        Public Function GetFormCollection() As FormCollection Implements CustomController_UI_Handler.GetFormCollection
            Return My.Application.OpenForms
        End Function
    End Class
End Namespace