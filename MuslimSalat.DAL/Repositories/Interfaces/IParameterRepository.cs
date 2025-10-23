using MuslimSalat.DL.Entities;

namespace MuslimSalat.DAL.Repositories.Interfaces;

public interface IParameterRepository : IRepository<Parameter>
{
    public bool UpdatePrayerReminderMinutes(int idUser, byte minutes);
    public bool UpdateCalculationStrategy(int idUser, bool strategy);
    public Parameter? GetParameterByIdUser(int idUser);
}
