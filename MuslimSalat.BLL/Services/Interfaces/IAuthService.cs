using MuslimSalat.DL.Entities;

namespace MuslimSalat.BLL.Services.Interfaces;

public interface IAuthService
{
    public string GenerateToken(User user);
}
