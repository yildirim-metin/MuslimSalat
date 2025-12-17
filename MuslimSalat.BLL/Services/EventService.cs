using MuslimSalat.BLL.Exceptions;
using MuslimSalat.BLL.Services.Interfaces;
using MuslimSalat.DAL.Repositories.Interfaces;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.BLL.Services;

public class EventService : IEventService
{
    private readonly IRepository<Event> _eventRepository;

    public EventService(IRepository<Event> eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public Event GetEvent(int id)
    {
        return _eventRepository.GetOne(id) ?? throw new NotFoundException("Event not found!");
    }

    public IEnumerable<Event> GetEvents()
    {
        return _eventRepository.GetAll();
    }

    public void Add(Event e)
    {
        _eventRepository.Add(e);
    }

    public void Update(Event e)
    {
        _eventRepository.Update(e);
    }

    public void Delete(int id)
    {
        _eventRepository.Delete(id);
    }
}