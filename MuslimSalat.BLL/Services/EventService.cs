using MuslimSalat.BLL.Exceptions;
using MuslimSalat.BLL.Services.Interfaces;
using MuslimSalat.DAL.Repositories.Interfaces;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.BLL.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public Event GetEvent(int id)
    {
        return _eventRepository.GetOneUserIncluded(id) ?? throw new NotFoundException("Event not found!");
    }

    public IEnumerable<Event> GetEvents()
    {
        return _eventRepository.GetAllUserIncluded();
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

    public void Subscribe(int idUser, int idEvent)
    {
        if (_eventRepository.IsAlreadySubscribe(idUser, idEvent))
        {
            throw new AlreadySubscribedException();
        }
        _eventRepository.Subscribe(idUser, idEvent);
    }
}