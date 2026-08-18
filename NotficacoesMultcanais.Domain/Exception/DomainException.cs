namespace NotficacoesMulticanais.Domain.Exception;

public class DomainException : IOException
{
    public DomainException(string message) : base(message)
    {
    }
}
