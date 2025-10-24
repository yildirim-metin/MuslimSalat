using System.Linq.Expressions;
using MuslimSalat.BLL.Exceptions;
using MuslimSalat.BLL.Services.Interfaces;
using MuslimSalat.DAL.Repositories.Interfaces;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.BLL.Services;

public class ParameterService : IParameterService
{
    private readonly IParameterRepository _parameterRepository;

    public ParameterService(IParameterRepository parameterRepository)
    {
        _parameterRepository = parameterRepository;
    }

    public void Add(Parameter parameter)
    {
        _parameterRepository.Add(parameter);
    }

    public void Delete(int id)
    {
        _parameterRepository.Delete(id);
    }

    public Parameter GetParameter(int idUser)
    {
        return _parameterRepository.GetParameterByIdUser(idUser) ?? throw new MuslimSalatException(404, "Parameter not found!");
    }

    public void Update(int id, Parameter parameter)
    {
        if (!_parameterRepository.Any(p => p.Id == id))
        {
            throw new MuslimSalatException(404, "Parameter not found!");
        }
        _parameterRepository.Update(parameter);
    }

    public void UpdateCalculationStrategy(int idUser, bool strategy)
    {
        if (!_parameterRepository.UpdateCalculationStrategy(idUser, strategy))
        {
            throw new MuslimSalatException(404,"Parameter not found!");
        }
    }

    public void UpdatePrayerReminderMinutes(int idUser, byte minutes)
    {
        if (!_parameterRepository.UpdatePrayerReminderMinutes(idUser, minutes))
        {
            throw new MuslimSalatException(404, "Parameter not found!");
        }
    }
}
