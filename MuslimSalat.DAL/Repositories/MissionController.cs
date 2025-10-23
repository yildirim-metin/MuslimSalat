using MuslimSalat.DAL.Configs;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.DAL.Repositories;

public class MissionController : BaseRepository<Mission>
{
    public MissionController(MuslimSalatContext context) : base(context)
    {
    }
}
