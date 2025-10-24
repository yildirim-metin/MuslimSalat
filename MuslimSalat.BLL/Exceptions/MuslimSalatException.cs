

namespace MuslimSalat.BLL.Exceptions;

[System.Serializable]
public class MuslimSalatException : System.Exception
{
    public int StatusCode { get; set; }

    public object Content { get; set; }
    public MuslimSalatException(int statusCode, object content)
    {
        StatusCode = statusCode;
        Content = content;
    }
   
}