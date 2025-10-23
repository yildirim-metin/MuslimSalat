using MuslimSalat.API.Models.Prayers;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.API.Mappers;

public static class PrayerMappers
{
    public static Prayer ToPrayer(this PrayerDto prayerDto)
    {
        return new()
        {
            Id = prayerDto.Id,
            Name = prayerDto.Name,
            Datetime = prayerDto.Datetime,
            Done = prayerDto.Done,
        };
    }
}
