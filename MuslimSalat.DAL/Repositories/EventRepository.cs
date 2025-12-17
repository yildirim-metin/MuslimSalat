using MuslimSalat.DAL.Configs;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.DAL.Repositories;

public class EventRepository : BaseRepository<Event>
{
    public EventRepository(MuslimSalatContext context) : base(context)
    {
    }
}
