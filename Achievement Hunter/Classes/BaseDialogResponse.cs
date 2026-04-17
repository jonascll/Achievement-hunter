namespace Achievement_Hunter.Classes;

public class BaseDialogResponse
{
    private bool succeeded;
    public bool Succeeded
    {
        get { return succeeded; }
    }

    private BaseObject responseObject;
    public BaseObject ResponseObject
    {
        get { return responseObject; }
    }

    public BaseDialogResponse(bool succeeded, BaseObject responseObject)
    {
        this.succeeded = succeeded;
        this.responseObject = responseObject;
    }
}