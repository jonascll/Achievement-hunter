namespace Achievement_Hunter.Classes;

public class GameDialogResponse : BaseDialogResponse
{
    public GameDialogResponse(bool succeeded, Game responseObject, string errorMessage = "") : base(succeeded, responseObject, errorMessage)
    {

    }
}