using DomainLibrary.DB;
using DomainLibrary.Entities;
using ServicesLibrary.Helpers;
using System;
using System.Linq;

namespace ServicesLibrary.Services
{
    public class UserService<T> : IUserService<T> where T : User
    {

        private IDb<T> _db;

        public UserService()
        {
            _db = new FileSystemDB<T>();
        }

        // 1) --------------LOG IN of existing user---------------------
        public T LogIn(string username, string password)
        {
            T userFound = _db.GetAll().SingleOrDefault(x => x.Username == username && x.Password == password);

            if (userFound == null)
            {
                MessageHelper.Color("[ERROR] Username or Password do not match!", ConsoleColor.Red);
                return null;
            }
            return userFound;
        }
        // 2) --------------REGISTER / INSERT USER-------------------
        public T Register(T user)
        {
            if (ValidationHelper.ValidateFirstLastName(user.FirstName) == null ||
                ValidationHelper.ValidateFirstLastName(user.LastName) == null ||
                ValidationHelper.ValidateUsername(user.Username) == null ||
                ValidationHelper.ValidatePassword(user.Password) == null)
            {
                MessageHelper.Color("[ERROR] Invalid information provided!", ConsoleColor.Red);
                return null;
            }

            int id = _db.Insert(user);
            return _db.GetById(id);
        }
        // 3) --------------GET USER BY ID-------------
        public T GetUserById(int id)
        {
            return _db.GetById(id);
        }
        // 4) --------------CHANGE PASSWORD------------
        public void ChangePassword(int userId, string oldPassword, string newPassword)
        {
            T user = _db.GetById(userId);

            if (user.Password != oldPassword)
            {
                MessageHelper.Color("[ERROR] Incorect old password!", ConsoleColor.Red);
                Console.ReadLine();
                return;
            }
            if (newPassword == oldPassword)
            {
                MessageHelper.Color("[ERROR] New password same as old password!", ConsoleColor.Red);
                Console.ReadLine();
                return;
            }
            if (ValidationHelper.ValidatePassword(newPassword) == null)
            {
                MessageHelper.Color("[ERROR] Invalid new password", ConsoleColor.Red);
                Console.ReadLine();
                return;
            }

            user.Password = newPassword;
            _db.Update(user);
            MessageHelper.Color("Password successfully changed!", ConsoleColor.Green);
            Console.ReadLine();
        }
        // 5) ---------------CHANGE INFO---------------
        public void ChangeInfo(int userId, string firstName, string lastName)
        {
            T user = _db.GetById(userId);
            if (ValidationHelper.ValidateFirstLastName(firstName) == null ||
                ValidationHelper.ValidateFirstLastName(lastName) == null)
            {
                MessageHelper.Color("[ERROR] Invalid first name and last name entered!", ConsoleColor.Red);
                Console.ReadLine();
                return;
            }
            user.FirstName = firstName;
            user.LastName = lastName;
            _db.Update(user);
            MessageHelper.Color("First name and last name successfully changed!", ConsoleColor.Green);
            Console.ReadLine();
        }
        // 6) ---------------- IS DB EMPTY--------------
        public bool IsDbEmpty()
        {
            if (_db.GetAll() == null || _db.GetAll().Count == 0)
                return true;

            return false;
        }
    }
}
