using System.Net;

namespace GG.Exception.ExceptionsBase;
public class ErrorOnValidationException : GGException
{
    private List<string> Erros { get; set; }

    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
    {
        Erros = errorMessages;
    }

    public override List<string> GetErros()
    {
        return Erros;
    }
}
