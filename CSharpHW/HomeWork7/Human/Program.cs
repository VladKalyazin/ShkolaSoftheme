using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human
{
    public class Human
    {
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age
        {
            get
            {
                DateTime zeroTime = new DateTime(1, 1, 1);
                TimeSpan span = DateTime.Now - BirthDate;
                return (zeroTime + span).Year - 1;
            } 
        }

        public Human() : this(DateTime.Now, "", "")
        {

        }

        public Human(DateTime birthDate, string firstName, string lastName)
        {
            BirthDate = birthDate;
            FirstName = firstName;
            LastName = lastName;
        }

        public override bool Equals(object obj)
        {
            Human human = obj as Human;
            if (human == null)
                return false;
            return (BirthDate == human.BirthDate) && 
                (FirstName == human.FirstName) && 
                (LastName == human.LastName);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Human h1 = new Human(new DateTime(2000, 1, 1), "123", "123");
            Human h2 = new Human(new DateTime(2000, 1, 1), "123", "123");
            Console.WriteLine(h1.Equals(h2));

            Console.ReadKey();
        }
    }
}
