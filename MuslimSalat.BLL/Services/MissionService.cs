using MuslimSalat.BLL.Exceptions;
using MuslimSalat.BLL.Services.Interfaces;
using MuslimSalat.DAL.Repositories.Interfaces;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.BLL.Services;

public class MissionService : IMissionService
{
    private readonly IRepository<Mission> _missionRepository;

    public MissionService(IRepository<Mission> missionRepository)
    {
        _missionRepository = missionRepository;
    }

    public void Add(Mission mission)
    {
        _missionRepository.Add(mission);
    }

    public void Delete(int id)
    {
        _missionRepository.Delete(id);
    }

    public Mission GetMission(int id)
    {
        return _missionRepository.GetOne(id) ?? throw new NotFoundException("Mission not found!");
    }

    public void Update(Mission mission)
    {
        _missionRepository.Update(mission);
    }
}
