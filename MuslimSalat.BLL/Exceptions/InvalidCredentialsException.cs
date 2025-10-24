namespace MuslimSalat.BLL.Exceptions;

public class InvalidCredentialsException : MuslimSalatException
{
    public InvalidCredentialsException() : base(401, "Invalid credentials")
    {
    }
}
