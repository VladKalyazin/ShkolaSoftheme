using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    public class User : ICloneable
    {
        public string Password { get; set; }

        public object Clone()
        {
            var user = new User();
            user.Password = Password;
            return user;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // value copy
            int firstValue = 5;
            int secondValue = firstValue;
            // ref copy
            var firstUser = new User();
            firstUser.Password = "123";
            User secondUser = firstUser.Clone() as User;
        }
    }
}
