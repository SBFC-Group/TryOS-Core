Namespace CustomController_Data
    Public Interface CustomController_Interface
        ReadOnly Property Name As String

        ReadOnly Property VerifyedCode_ID As String

        ReadOnly Property RemoveTaskbar As Boolean

        Sub ExecuteForm1Subs(Form1_Form As Console)

        Sub ExecuteUISubs(UI_Form As UI)

        Sub ExecuteTryControllerSubs(TryController_Form As TryController)

        Sub ConfigFormCollection(Collection As FormCollection)

        Sub Initialize(host As CustomController_UI_Handler)
    End Interface
End Namespace