namespace GG.Exception.ExceptionsBase;
public abstract class GGException : SystemException
{
    protected GGException(string message)
        : base(message)
    {

    }

    public abstract int StatusCode { get; }

    public virtual List<string> GetErros()
    {
        return [Message];
    }
}
