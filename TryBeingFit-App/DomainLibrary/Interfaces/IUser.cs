using DomainLibrary.Enums;

namespace DomainLibrary.Entities
{
    public interface IUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
        UserRole Role { get; set; }
        string Username { get; set; }
    }
}