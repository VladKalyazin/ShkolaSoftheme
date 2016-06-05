using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator
{
    public interface IUser
    {
        string Name { get; set; }
        string Password { get; set; }
        string Email { get; set; }

        string GetFullInfo();
    }

    public interface IValidator
    {
        List<IUser> UsersData { get; set; }

        bool ValidateUser(IUser user);
    }

    public class User : IUser
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public string GetFullInfo() =>
            String.Format("Name: {0}; Password: {1}; Email: {2}", Name, Password, Email);
    }

    public class NameValidator : IValidator
    {
        public List<IUser> UsersData { get; set; } = new List<IUser>();

        public bool ValidateUser(IUser user)
        {
            foreach (var existedUser in UsersData)
            {
                if (existedUser.Name == user.Name && existedUser.Password == user.Password)
                    return false;
            }
            return true;
        }
    }

    public class EmailValidator : IValidator
    {
        public List<IUser> UsersData { get; set; } = new List<IUser>();

        public bool ValidateUser(IUser user)
        {
            foreach (var existedUser in UsersData)
            {
                if (existedUser.Email == user.Email && existedUser.Password == user.Password)
                    return false;
            }
            return true;
        }
    }

    class Program
    {
        public static void UserRegister(List<IUser> users)
        {
            NameValidator validator = new NameValidator();
            validator.UsersData = users;
            User user = new User();
            Console.WriteLine("Register");
            Console.WriteLine("Name:");
            user.Name = Console.ReadLine();
            if (user.Name == "exit")
                return;
            Console.WriteLine("Email:");
            user.Email = Console.ReadLine();
            Console.WriteLine("Password:");
            user.Password = Console.ReadLine();

            if (validator.ValidateUser(user))
                users.Add(user);
            else
                Console.WriteLine("error");
            UserRegister(users);
        }

        static void Main(string[] args)
        {
            List<IUser> users = new List<IUser>();
            UserRegister(users);
        }
    }
}
