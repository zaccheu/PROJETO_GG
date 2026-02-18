namespace GG.Exception.ExceptionsBase;

public class NotFoundException : GGException
{
    public NotFoundException(string message) : base(message)
    {
    }

    public override int StatusCode => 404;
}
