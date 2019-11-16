using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using Projekat_tvp.klase;
namespace Projekat_tvp
{
    public partial class Administracija : Form
    {
        List<Automobili> lista_automobila = new List<Automobili>();
        List<Kupac> lista_osoba = new List<Kupac>();
        List<Ponude> lista_ponude = new List<Ponude>();
        List<Rezervacije> lista_rezervacije = new List<Rezervacije>();
        private static float br = 0;
        public Administracija()
        {
            InitializeComponent();
            passwd_tb.PasswordChar = '*';
            passwd_tb.MaxLength = 16;
        }
        public void dodaj_osobe(Kupac o)
        {
            lista_osoba.Add(o);
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = File.OpenWrite(@"Kupci.txt");
            formatter.Serialize(stream, lista_osoba);
            stream.Dispose(); 
        }
        public void dodaj(Automobili a)
        {
            lista_automobila.Add(a);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = File.OpenWrite(@"automobili.txt");
            bf.Serialize(stream, lista_automobila);
            stream.Dispose();         
         
        }
        public void izbrisi(int i)
        {
            for(int i2 = 0; i2 != lista_automobila.Count; ++i2)
            {
                if (lista_automobila[i2].Id == i)
                {
                    lista_automobila.RemoveAt(i2);
                }
            }
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"automobili.txt", FileMode.Append, FileAccess.Write);
            formatter.Serialize(stream, lista_automobila);
            stream.Dispose();
        }
        private void dodaj_dugme_Click(object sender, EventArgs e)
        {
            if(id_aut_tb.Text.Equals(" ")||marka_aut_tb.Text.Equals(" ")||model_aut_tb.Text.Equals(" "))
            {
                MessageBox.Show("Polja za marku,model ili id ne smeju biti prazna!");
                return;
            }
            dodaj(new Automobili(Int16.Parse(id_aut_tb.Text), godiste_aut_datetime.Value.ToLongDateString(), gorivo_aut_tb.Text, karoserija_aut_tb.Text, marka_aut_tb.Text, model_aut_tb.Text, kubikaza_aut_tb.Text, pogon_aut_tb.Text, menjac_aut_tb.Text,Int16.Parse(broj_vrata_tb.Text)));
            /*foreach (Automobili a in lista_automobila)
            {
                comboBox1.Items.Add(a.Id);
            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string password = passwd_tb.Text;
            string telefon = telefon_kupac_tb.Text;
            if( telefon.Length > 10)
            {
                MessageBox.Show("Morate uneti telefon u brojevima i duzina mora biti manja od 10!!!");
                return;
            }
            dodaj_osobe(new Kupac(password, ime_kupac_tb.Text,prezime_kupac_tb.Text,Int32.Parse(id_kupac_tb.Text), telefon, Int32.Parse(jmbg_kupac_tb.Text),datumrodj_kupac_datetime.Text));
            if (!password.All(char.IsLetterOrDigit) && password.Length<8)
            {
                MessageBox.Show("Morate uneti sifru sa slovima i brojevima i mora imati vise od 8 karaktera!!!");
                return;
            }
        }

        private void izmeni_dugme_Click(object sender, EventArgs e)
        {          
            Automobili izmena = new Automobili(Int16.Parse(id_aut_tb.Text), godiste_aut_datetime.Value.ToLongDateString(), gorivo_aut_tb.Text, karoserija_aut_tb.Text, marka_aut_tb.Text, model_aut_tb.Text, kubikaza_aut_tb.Text, pogon_aut_tb.Text, menjac_aut_tb.Text,Int16.Parse(broj_vrata_tb.Text));
            for (int i = 0; i != lista_automobila.Count; ++i)
            {
                if (lista_automobila[i].Id == Int16.Parse(id_aut_tb.Text))
                {
                    lista_automobila[i] = izmena;
                }
                else
                {
                    DialogResult dg = MessageBox.Show("Dati automobil ne postoji da li zelite da ga umesto toga dodate?","Ne postoji!", MessageBoxButtons.YesNo);
                    if (dg == DialogResult.Yes)
                    {
                        dodaj(izmena);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        private void izbrisi_dugme_Click(object sender, EventArgs e)
        {
            izbrisi(Int16.Parse(id_aut_tb.Text));
        }

        private void Administracija_Load(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = File.OpenRead(@"automobili.txt");
            lista_automobila = (List<Automobili>)formatter.Deserialize(stream);
            foreach (Automobili a2 in lista_automobila)
            {
                comboBox1.Items.Add(a2.Id);                
  
            }
            stream.Dispose();
            Stream stream2 = File.OpenRead(@"Kupci.txt");
            lista_osoba = (List<Kupac>)formatter.Deserialize(stream2);
            foreach (var item in lista_osoba)
            {
                comboBox2.Items.Add(item.Ime);
                MessageBox.Show(item.Password+item.Ime);
            }
            stream2.Dispose();
            Stream stream3 = File.OpenRead(@"ponude.txt");
            lista_ponude = (List<Ponude>)formatter.Deserialize(stream3);
            stream3.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DateTime dat_od = datum_od_ponude.Value;
            DateTime dat_do = datum_do_ponude.Value;
            if(dat_do.Year - dat_od.Year < 0 || dat_do.Day - dat_od.Day < 0 || dat_do.Month - dat_od.Month < 0)
            {
                MessageBox.Show("Molimo vas unesite pravilan datum!");
                return;
            }
            if (Double.Parse(ponude_cena.Text) <= 0)
            {
                MessageBox.Show("Morate uneti cenu vecu od nule!");
                return;
            }
            lista_ponude.Add(new Ponude(Int16.Parse(comboBox1.Text), datum_od_ponude.Value.ToShortDateString(), datum_do_ponude.Value.ToShortDateString(), Double.Parse(ponude_cena.Text)));
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = File.OpenWrite(@"ponude.txt");
            formatter.Serialize(stream, lista_ponude);
            stream.Dispose();
            MessageBox.Show("Uspesno ste dodali ponude");
        }

        private void Administracija_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value;
            int brojac = 0;
            foreach (var item in lista_automobila)
            {
                DateTime mesec = Convert.ToDateTime(item.Godiste);
                MessageBox.Show(""+mesec);
                if (mesec.Month == dt.Month)
                {
                    brojac++;
                }
            }
            br = (float)brojac/(float)lista_automobila.Count * 100;
            br = br * 3.6F;
            this.Paint += crtanje;
            this.Invalidate();
        }
        private void crtanje(object sender, PaintEventArgs e)
        {
            Rectangle r = new Rectangle(420, 324, 100, 100);
            e.Graphics.DrawEllipse(Pens.Black, r);
            e.Graphics.FillEllipse(Brushes.Blue, r);
            e.Graphics.FillPie(Brushes.Red, r, -90F, br);
        }

        private void izbrisi_kupca_dugme_Click(object sender, EventArgs e)
        {
            for (int i2 = 0; i2 != lista_osoba.Count; ++i2)
            {
                if (lista_osoba[i2].Id == Int16.Parse(id_kupac_tb.Text))
                {
                    lista_osoba.RemoveAt(i2);
                }
            }
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = File.OpenWrite(@"Kupac.txt");
            formatter.Serialize(stream, lista_osoba);
            stream.Dispose();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String ime= comboBox2.SelectedItem.ToString();
            Kupac kupac = new Kupac();
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = File.OpenRead(@"rezervacije.txt");
            lista_rezervacije = (List<Rezervacije>)formatter.Deserialize(stream);
            foreach (var item in lista_osoba)
            {
                if (item.Ime.Equals(ime)) kupac = item;
            }
            foreach (var item in lista_rezervacije)
            {
                if (item.Id_kupca == kupac.Id)
                {
                    listBox1.Items.Add(item);
                }
            }
            stream.Close();
        }

        private void izmeni_kupca_dugme_Click(object sender, EventArgs e)
        {
            string password = passwd_tb.Text;
            string telefon = telefon_kupac_tb.Text;
            if (telefon.Length > 10)
            {
                MessageBox.Show("Morate uneti telefon u brojevima i duzina mora biti manja od 10!!!");
                return;
            }
            if (!password.All(char.IsLetterOrDigit) && password.Length < 8)
            {
                MessageBox.Show("Morate uneti sifru sa slovima i brojevima i mora imati vise od 8 karaktera!!!");
                return;
            }
            foreach (var item in lista_osoba)
            {
                if (int.Parse(id_kupac_tb.Text).Equals(item.Id))
                {
                    item.Password = password;
                    item.Telefon = telefon;
                    item.Ime = ime_kupac_tb.Text;
                    item.Prezime = prezime_kupac_tb.Text;
                    item.JMBG = int.Parse(jmbg_kupac_tb.Text);
                    item.Datumrodj = datumrodj_kupac_datetime.Value.ToShortDateString();
                    MessageBox.Show("Uspesna promena");
                    break;
                }
            }
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = File.OpenWrite(@"Kupci.txt");
            stream.SetLength(0);
            formatter.Serialize(stream, lista_osoba);
            stream.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new PonudaIzmena();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = (int)comboBox1.SelectedItem;
            for (int i2 = 0; i2 != lista_ponude.Count; ++i2)
            {
                if (lista_ponude[i2].Id==id && datum_od_ponude.Value.ToShortDateString().Equals(lista_ponude[i2].Datum_od)
                    && datum_do_ponude.Value.ToShortDateString().Equals(lista_ponude[i2].Datum_do) && int.Parse(ponude_cena.Text).Equals(lista_ponude[i2].Cena_danu))
                {
                    lista_ponude.RemoveAt(i2);
                }
            }
            MessageBox.Show("Uspesno brisanje ponude!");
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = File.OpenWrite(@"ponude.txt");
            stream.SetLength(0);
            formatter.Serialize(stream, lista_ponude);
            stream.Dispose();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            String ime = comboBox2.SelectedItem.ToString();
            Kupac kupac = new Kupac();
            Rezervacije r = (Rezervacije)listBox1.SelectedItem;
            listBox1.Items.Remove(listBox1.Items[listBox1.SelectedIndex]);
            foreach (var item in lista_rezervacije)
            {
                if(r.Equals(item))
                {
                    item.Datum_od = dateTimePicker3.Value.ToShortDateString();
                    item.Datum_do= dateTimePicker2.Value.ToShortDateString();
                    item.Cena = double.Parse(textBox1.Text);
                }
            }     
            foreach (var item in lista_rezervacije)
            {
                if (item.Id_kupca == r.Id_kupca)
                {
                    listBox1.Items.Add(item);
                }
            }
            MessageBox.Show("Uspesno izmenjeno");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = File.OpenWrite(@"rezervacije.txt");
            stream.SetLength(0);
            formatter.Serialize(stream, lista_rezervacije);
            stream.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int kljuc = 0;
            Rezervacije r = (Rezervacije)listBox1.SelectedItem;
            listBox1.Items.Remove(listBox1.Items[listBox1.SelectedIndex]);
            foreach (Rezervacije item in lista_rezervacije)
            {
                if (r.Equals(item))
                {
                    kljuc = lista_rezervacije.IndexOf(item);
                }
            }
            lista_rezervacije.RemoveAt(kljuc);
            MessageBox.Show("Uspesno izbrisano");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = File.OpenWrite(@"rezervacije.txt");
            stream.SetLength(0);
            formatter.Serialize(stream, lista_rezervacije);
            stream.Close();
        }
    }
}
