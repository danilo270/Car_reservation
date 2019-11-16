using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_tvp.klase
{
    [Serializable]
    class Rezervacije
    {
        private int id_automobila, id_kupca;
        private string datum_od, datum_do;
        private double cena;
        public Rezervacije(int id_automobila, int id_kupca, string datum_od, string datum_do, double cena)
        {
            this.id_automobila = id_automobila;
            this.id_kupca = id_kupca;
            this.datum_od = datum_od;
            this.datum_do = datum_do;
            this.cena = cena;
        }
        public int Id_kupca{ get { return id_kupca; } set {id_kupca=value; } }
        public int Id_automobila { get { return id_automobila; } set { id_automobila = value; } }
        public string Datum_od{ get { return datum_od; } set { this.datum_od = value; } }
        public string Datum_do { get { return datum_do; } set { this.datum_do = value; } }
        public double Cena { get { return cena; } set { this.cena = value; } }
        public override string ToString()
        {
            return ""+datum_od+","+datum_do+", Cena:"+cena;
        }
    }
}
