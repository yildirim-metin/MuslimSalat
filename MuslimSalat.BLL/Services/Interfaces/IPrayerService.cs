using MuslimSalat.DL.Entities;

namespace MuslimSalat.BLL.Services.Interfaces;

public interface IPrayerService
{
    public Prayer GetPrayer(int id);
    public void Add(Prayer prayer);
    public void Update(Prayer prayer);
    public void Delete(int id);
    public void Delete(Prayer prayer);
}
