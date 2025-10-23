using MuslimSalat.BLL.Services.Interfaces;
using MuslimSalat.DAL.Repositories.Interfaces;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.BLL.Services;

public class PrayerService : IPrayerService
{
    private readonly IRepository<Prayer> _prayerRepository;

    public PrayerService(IRepository<Prayer> prayerRepository)
    {
        _prayerRepository = prayerRepository;
    }

    public void Add(Prayer prayer)
    {
        _prayerRepository.Add(prayer);
    }

    public void Delete(int id)
    {
        _prayerRepository.Delete(id);
    }

    public void Delete(Prayer prayer)
    {
        _prayerRepository.Delete(prayer);
    }

    public Prayer GetPrayer(int id)
    {
        return _prayerRepository.GetOne(id) ?? throw new Exception("Prayer not found!");
    }

    public void Update(Prayer prayer)
    {
        _prayerRepository.Update(prayer);
    }
}
