using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_tvp.klase
{
    class Administrator:Osoba
    {
        private string password;
        public Administrator(string passwd, string ime, string prezime, int id, string telefon, int jmbg, string datumrodj)
            : base(ime, prezime, id, telefon, jmbg, datumrodj)
        {
            this.password = passwd;
        }
        public string Passwd { get { return password; } set { this.password = value; } }
    }
}
