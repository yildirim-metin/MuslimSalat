using MuslimSalat.DAL.Configs;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.DAL.Repositories;

public class PrayerRepository : BaseRepository<Prayer>
{
    public PrayerRepository(MuslimSalatContext context) : base(context)
    {
    }
}
