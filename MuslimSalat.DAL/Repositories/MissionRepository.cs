using MuslimSalat.DAL.Configs;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.DAL.Repositories;

public class MissionRepository : BaseRepository<Mission>
{
    public MissionRepository(MuslimSalatContext context) : base(context)
    {
    }
}
