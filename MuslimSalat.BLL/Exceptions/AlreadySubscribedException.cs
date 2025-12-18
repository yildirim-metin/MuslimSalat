namespace MuslimSalat.BLL.Exceptions;

public class AlreadySubscribedException : Exception
{
    public AlreadySubscribedException() : base("User is already subscribed to this event!")
    {
        
    }
}
