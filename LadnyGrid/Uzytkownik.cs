using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadnyGrid
{
    class Uzytkownik
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }

        public Uzytkownik(int Id, string Login, string Haslo)
        {
            this.Id = Id;
            this.Login = Login;
            this.Haslo = Haslo;
        }
    }
}
