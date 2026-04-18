namespace Achievement_Hunter.Classes;

public class BaseDialogResponse
{
    private bool succeeded;
    public bool Succeeded
    {
        get { return succeeded; }
    }
    private string errorMessage;

    public string ErrorMessage { get { return errorMessage; } }
    private BaseObject responseObject;
    public BaseObject ResponseObject
    {
        get { return responseObject; }
    }

    public BaseDialogResponse(bool succeeded, BaseObject responseObject, string errorMessage = "")
    {
        this.succeeded = succeeded;
        this.responseObject = responseObject;
        this.errorMessage = errorMessage;
    }
}