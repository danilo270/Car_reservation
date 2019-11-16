using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projekat_tvp.klase;
namespace Projekat_tvp
{
    public partial class FormaRezervacija : Form
    {
        List<Automobili> lista_automobila=new List<Automobili>();
        List<Ponude> lista_ponuda=new List<Ponude>();
        List<Rezervacije> lista_rezervacija=new List<Rezervacije>();
        Kupac narucioc;
        public FormaRezervacija(Kupac narucioc2)
        {
            InitializeComponent();
            this.narucioc = narucioc2;
        }

        private void FormaRezervacija_Load(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream1 = File.OpenRead(@"automobili.txt");
            FileStream stream2 = File.OpenRead(@"rezervacije.txt");
            lista_rezervacija = (List<Rezervacije>)formatter.Deserialize(stream2);
            lista_automobila = (List<Automobili>)formatter.Deserialize(stream1);
            comboBox1.DisplayMember = lista_automobila[0].Marka;
            comboBox1.DataSource = lista_automobila;
            /*foreach (Automobili a2 in lista_automobila)
            {
                comboBox1.ValueMember = a2.Marka;
            }*/
            stream1.Dispose();
            stream2.Dispose();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear(); comboBox3.Items.Clear(); comboBox4.Items.Clear(); comboBox5.Items.Clear();
            comboBox6.Items.Clear(); comboBox7.Items.Clear(); comboBox8.Items.Clear(); comboBox9.Items.Clear();
            Automobili aut = (Automobili)comboBox1.SelectedItem;
            foreach (Automobili a in lista_automobila)
            {
                if (aut.Equals(a))
                {
                    comboBox2.Items.Add(a.Kubikaza);
                    comboBox3.Items.Add(a.Gorivo);
                    comboBox4.Items.Add(a.Pogon);
                    comboBox5.Items.Add(a.Karoserija);
                    comboBox6.Items.Add(a.Model);
                    comboBox7.Items.Add(a.Vrsta_menjaca);
                    comboBox8.Items.Add(a.Broj_vrata);
                    comboBox9.Items.Add(a.Godiste);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Automobili ponuda_automobil=new Automobili();
            foreach (Automobili a in lista_automobila)
            {
                if (comboBox1.Text.Equals(a.Marka))
                {
                    ponuda_automobil = a;
                }
            }
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream2 = File.OpenRead(@"ponude.txt");
            lista_ponuda =formatter.Deserialize(stream2) as List<Ponude>;
            foreach (Ponude item in lista_ponuda)
            {
                if (ponuda_automobil.Id == item.Id)
                {
                    listBox1.Items.Add(item);
                }
            }
            stream2.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Boolean flag = false;
            Ponude p2 = (Ponude)listBox1.SelectedItem;
            DateTime dt = dateTimePicker1.Value.Date;
            DateTime dt2 = dateTimePicker2.Value.Date;
            Automobili auto = new Automobili();
            if(DateTime.Compare(Convert.ToDateTime(p2.Datum_od).Date, dt) <=0&& DateTime.Compare(Convert.ToDateTime(p2.Datum_do).Date, dt2)>=0)
            {
                MessageBox.Show("Uspesna rezervacija");
            }
            else{
                MessageBox.Show("Neuspesna rezervacija unesite datum u okviru selektovane ponude!");
                return;
            }
            foreach(Automobili a in lista_automobila)
            {
                if(a.Kubikaza==comboBox2.Text&&a.Gorivo== comboBox3.Text&& a.Pogon== comboBox4.Text&&
                    a.Karoserija == comboBox5.Text&& a.Model == comboBox6.Text&& a.Vrsta_menjaca == comboBox7.Text&&
                    a.Broj_vrata == Int16.Parse(comboBox8.Text)&& a.Godiste== comboBox9.Text)
                {
                    MessageBox.Show("Uspesna provera automobila");
                    lista_rezervacija.Add(new Rezervacije(a.Id, narucioc.Id, dt.ToShortDateString(), dt2.ToShortDateString(), p2.Cena_danu));
                    flag = true;
                }
            }
            if (!flag)
            {
                MessageBox.Show("Neuspesna provera automobila molimo vas izmenite podatke");
                return;
            }
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = File.OpenWrite(@"rezervacije.txt");
            formatter.Serialize(stream, lista_rezervacija);
            stream.Dispose();
            Form f = new IzmenaRezervacija(narucioc);
            f.Show();
            this.Close();
        }
    }
}
