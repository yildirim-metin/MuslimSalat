using MuslimSalat.API.Models.Parameters;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.API.Mappers;

public static class ParameterMappers
{
    public static Parameter ToParameter(this ParameterDto parameterDto)
    {
        return new()
        {
            Id = parameterDto.Id,
            CalculationStrategy = parameterDto.CalculationStrategy,
            IdUser = parameterDto.IdUser,
            PrayerReminderMinutes = parameterDto.PrayerReminderMinutes,
        };
    }

    public static ParameterDto ToParameterDto(this Parameter parameter)
    {
        return new()
        {
            Id = parameter.Id,
            CalculationStrategy = parameter.CalculationStrategy,
            IdUser = parameter.IdUser,
            PrayerReminderMinutes = parameter.PrayerReminderMinutes,
        };
    }
}
