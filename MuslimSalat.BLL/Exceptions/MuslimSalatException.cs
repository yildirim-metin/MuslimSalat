namespace MuslimSalat.BLL.Exceptions;

public class MuslimSalatException : Exception
{
    public int StatusCode { get; set; }

    public object Content { get; set; }

    public MuslimSalatException(int statusCode, object content)
    {
        StatusCode = statusCode;
        Content = content;
    }
}