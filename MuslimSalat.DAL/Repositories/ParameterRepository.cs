using MuslimSalat.DAL.Configs;
using MuslimSalat.DAL.Repositories.Interfaces;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.DAL.Repositories;

public class ParameterRepository : BaseRepository<Parameter>, IParameterRepository
{
    public ParameterRepository(MuslimSalatContext context) : base(context)
    {
    }

    public Parameter? GetParameterByIdUser(int idUser)
    {
        return _data.SingleOrDefault(p => p.IdUser == idUser);
    }

    public bool UpdateCalculationStrategy(int idUser, bool strategy)
    {
        Parameter? parameter = _data.SingleOrDefault(p => p.IdUser == idUser);
        if (parameter is null)
        {
            return false;
        }

        parameter.CalculationStrategy = strategy;
        return Update(parameter);
    }

    public bool UpdatePrayerReminderMinutes(int idUser, byte minutes)
    {
        Parameter? parameter = _data.SingleOrDefault(p => p.IdUser == idUser);
        if (parameter is null)
        {
            return false;
        }

        parameter.PrayerReminderMinutes = minutes;
        return Update(parameter);
    }
}
