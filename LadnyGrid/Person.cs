using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LadnyGrid
{


    class Person
    {
        public enum Gender
        {
            Male,
            Female
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public bool Engaged { get; set; }
        public string Email { get; set; }
        public Gender Sex { get; set; }
   

        public Person(int ID, string Name, string Surname, int Age, bool Engaged, string Email, Gender Sex)
        {
            this.ID = ID;
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
            this.Engaged = Engaged;
            this.Email = Email;
            this.Sex = Sex;


           
        }

        public string  getSexString()
        {
            string s = "M";
            if (Sex == Gender.Female)
                s = "K";
            return s;
        }
    }
}
