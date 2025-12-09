using MuslimSalat.DL.Entities;

namespace MuslimSalat.BLL.Services.Interfaces;

public interface IMissionService
{
    public Mission GetMission(int id);
    public IEnumerable<Mission> GetMissions();
    public void Add(Mission mission);
    public void Update(Mission mission);
    public void Delete(int id);
}
