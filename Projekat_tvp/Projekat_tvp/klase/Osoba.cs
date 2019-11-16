using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_tvp.klase
{
    [Serializable]
    public class Osoba
    {
        private string ime, prezime, datumrodj, telefon;
        private int id, jmbg;

        public Osoba(string ime, string prezime, int id, string telefon, int jmbg, string datumrodj)
        {
            this.ime = ime;
            this.prezime = prezime;      
            this.id = id;
            this.telefon = telefon;
            this.jmbg = jmbg;
            this.datumrodj = datumrodj;
        }
        public Osoba() { }
        public string Ime { get { return ime; } set { ime = value; } }
        public string Prezime { get { return prezime; } set { prezime = value; } }
        public string Datumrodj { get { return datumrodj; } set { datumrodj = value; } }
        public int Id { get { return id; } set { id = value; } }
        public string Telefon { get { return telefon; } set { telefon= value; } }
        public int JMBG { get { return jmbg; } set { jmbg = value; } }
        //public override string ToString()
        //{
        //    return base.ToString();
        //}
    }
}
