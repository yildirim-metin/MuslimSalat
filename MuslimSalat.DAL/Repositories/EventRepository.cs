using Microsoft.EntityFrameworkCore;
using MuslimSalat.DAL.Configs;
using MuslimSalat.DAL.Repositories.Interfaces;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.DAL.Repositories;

public class EventRepository : BaseRepository<Event>, IEventRepository
{
    public EventRepository(MuslimSalatContext context) : base(context)
    {
    }

    public IEnumerable<Event> GetAllUserIncluded(Func<Event, bool>? predicate = null)
    {
        return predicate is not null ? _data.Include(d => d.IdUserResponsibleNavigation).Where(predicate) : _data.Include(d => d.IdUserResponsibleNavigation);
    }

    public void Subscribe(int idUser, int idEvent)
    {
        _context.EventUsers.Add(new EventUser { IdUser = idUser, IdEvent = idEvent });
        _context.SaveChanges();
    }

    public bool IsAlreadySubscribe(int idUser, int idEvent)
    {
        return _context.EventUsers.Any(eu => eu.IdUser == idUser && eu.IdEvent == idEvent);
    }

    public Event? GetOneUserIncluded(int id)
    {
        return _data.Include(d => d.IdUserResponsibleNavigation).FirstOrDefault(e => e.Id == id);
    }
}