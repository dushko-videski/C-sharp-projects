using DomainLibrary.Entities;

namespace ServicesLibrary.Services
{
    public interface IUserService<T> where T : User
    {
        T LogIn(string username, string password);
        T Register(T user);
        T GetUserById(int id);

        void ChangePassword(int userId, string oldPassword, string newPassword);
        void ChangeInfo(int userId, string firstName, string lastName);
        bool IsDbEmpty();

    }
}
