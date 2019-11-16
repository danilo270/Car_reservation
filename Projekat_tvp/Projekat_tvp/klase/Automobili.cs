using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_tvp
{
    [Serializable]
    public class Automobili
    {
        private int id,broj_vrata;
        private string godiste;
        private string gorivo, karoserija,model, marka, kubikaza, pogon, vrsta_menjaca;
        public Automobili() { }
        public Automobili(int id, string godiste, string gorivo, string karoserija, string marka, string model, string kubikaza, string pogon, string vrsta_menjaca,int broj_vrata)
        {
            this.id = id;
            this.godiste = godiste;
            this.gorivo = gorivo;
            this.karoserija = karoserija;
            this.marka = marka;
            this.model = model;
            this.kubikaza = kubikaza;
            this.pogon = pogon;
            this.vrsta_menjaca = vrsta_menjaca;
            this.broj_vrata = broj_vrata;
        }
        public string Gorivo
        {
            get { return gorivo; }
            set { this.gorivo = value; }
        }
        public string Karoserija
        {
            get { return karoserija; }
            set { this.karoserija = value; }
        }
        public string Marka
        {
            get { return marka; }
            set { this.marka = value; }
        }
        public string Model
        {
            get { return model; }
            set { this.model = value; }
        }
        public string Kubikaza
        {
            get { return kubikaza; }
            set { this.kubikaza = value; }
        }
        public string Pogon
        {
            get { return pogon; }
            set { this.pogon = value; }
        }
        public string Vrsta_menjaca
        {
            get { return vrsta_menjaca; }
            set { this.vrsta_menjaca = value; }
        }
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
        public int Broj_vrata
        {
            get { return broj_vrata; }
            set { this.broj_vrata = value; }
        }
        public string Godiste { get { return godiste; } set { godiste = value; } }
        public override string ToString()
        {
            return "Model: " + model.ToString() + "Godiste: " + godiste + "Marka: " + marka;
        }
    }
}
