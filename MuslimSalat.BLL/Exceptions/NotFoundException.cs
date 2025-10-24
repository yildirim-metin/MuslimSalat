namespace MuslimSalat.BLL.Exceptions;

public class NotFoundException : MuslimSalatException
{
    public NotFoundException(object content) : base(404, content)
    {
    }
}
