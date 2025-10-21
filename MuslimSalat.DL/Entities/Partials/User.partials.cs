using System.ComponentModel.DataAnnotations.Schema;
using MuslimSalat.DL.Enums;

namespace MuslimSalat.DL.Entities;

public partial class User
{
    [NotMapped]
    public UserRole RoleValue
    {
        get => Enum.TryParse<UserRole>(Role, out var role) ? role : UserRole.User;
        set => Role = value.ToString();
    }
}
