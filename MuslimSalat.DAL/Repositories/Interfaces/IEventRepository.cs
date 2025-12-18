using System;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.DAL.Repositories.Interfaces;

public interface IEventRepository : IRepository<Event>
{
    public IEnumerable<Event> GetAllUserIncluded(Func<Event, bool>? predicate = null);
    public void Subscribe(int idUser, int idEvent);
    public bool IsAlreadySubscribe(int idUser, int idEvent);
    public Event? GetOneUserIncluded(int id);
}
