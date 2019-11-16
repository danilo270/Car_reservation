using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_tvp.klase;
namespace Projekat_tvp.klase
{
    [Serializable]
    public class Kupac:Osoba
    {
        private string password;
        public Kupac(string passwd,string ime,string prezime,int id,string telefon,int jmbg,string datumrodj)
            :base(ime,prezime,id,telefon,jmbg,datumrodj)  {
            this.password = passwd;
        }

        public Kupac():base()
        {
        }

        public string Password{ get { return password; } set { password = value; } }
    }
}
