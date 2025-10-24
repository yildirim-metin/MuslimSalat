namespace MuslimSalat.BLL.Exceptions;

public class JwtKeyException : MuslimSalatException
{
    public JwtKeyException() : base(500, "Configuration is needed for Jwt:Key")
    {
    }
}
