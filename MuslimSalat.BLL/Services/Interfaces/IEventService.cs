using MuslimSalat.DL.Entities;

namespace MuslimSalat.BLL.Services.Interfaces;

public interface IEventService
{
    public Event GetEvent(int id);
    public IEnumerable<Event> GetEvents();
    public void Add(Event e);
    public void Update(Event e);
    public void Delete(int id);
    public void Subscribe(int idUser, int idEvent);
}
