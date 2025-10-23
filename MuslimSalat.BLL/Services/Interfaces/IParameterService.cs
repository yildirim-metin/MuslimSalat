using MuslimSalat.DL.Entities;

namespace MuslimSalat.BLL.Services.Interfaces;

public interface IParameterService
{
    public void UpdatePrayerReminderMinutes(int idUser, byte minutes);
    public void UpdateCalculationStrategy(int idUser, bool strategy);
    public Parameter GetParameter(int idUser);
    public void Add(Parameter parameter);
    public void Update(int id, Parameter parameter);
    public void Delete(int id);
}
