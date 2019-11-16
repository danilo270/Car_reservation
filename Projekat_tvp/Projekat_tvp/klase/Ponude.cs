using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_tvp.klase
{
    [Serializable]
    class Ponude
    {

        private int id_automobila;
        string datum_od;
        string datum_do;
        double cena_danu;

        public Ponude(int id_automobila, string datum_od, string datum_do, double cena_danu)
        {
            this.id_automobila = id_automobila;
            this.datum_od = datum_od;
            this.datum_do = datum_do;
            this.cena_danu = cena_danu;
        }
        public int Id { get {
                return this.id_automobila;
            }
            set { this.id_automobila = value; } }
        public string Datum_od { get { return datum_od; } set { this.datum_od = value; } }
        public string Datum_do { get { return datum_do; } set { this.datum_do = value; } }
        public double Cena_danu { get {return this.cena_danu;} set { cena_danu = value; } }

        public override string ToString()
        {
            return "id"+id_automobila+"od:" + Datum_od + "do:" + datum_do;
        }
    }

}
