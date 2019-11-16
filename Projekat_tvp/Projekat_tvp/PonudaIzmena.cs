using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Projekat_tvp.klase;
namespace Projekat_tvp
{
    public partial class PonudaIzmena : Form
    {
        List<Ponude> lista_ponude;
        List<Automobili> lista_automobila;
        public PonudaIzmena()
        {
            lista_ponude = new List<Ponude>();
            lista_automobila = new List<Automobili>();
            InitializeComponent();
        }

        private void PonudaIzmena_Load(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream3 = File.OpenRead(@"ponude.txt");
            lista_ponude = (List<Ponude>)formatter.Deserialize(stream3);
            foreach (var item in lista_ponude)
            {
                listBox1.Items.Add(item);
            }
            stream3.Dispose();
            Stream stream = File.OpenRead(@"automobili.txt");
            lista_automobila = (List<Automobili>)formatter.Deserialize(stream);
            stream.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean flag = false;
            Ponude ponude = (Ponude)listBox1.SelectedItem;
            foreach (var item in lista_automobila)
            {
                if(item.Id== int.Parse(textBox1.Text))
                {
                    MessageBox.Show("Nadjen automobil");
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                MessageBox.Show("Nije nadjen automobil unesite ispravan id!");
                return;
            }
            int index = 0;
            foreach (Ponude item in lista_ponude)
            {
                if (item==ponude)
                {
                    index = lista_ponude.IndexOf(item);
                    
                }
            }
            bool greska;
            lista_ponude[index].Id = Int32.Parse(textBox1.Text);
            lista_ponude[index].Datum_od = dateTimePicker1.Value.ToShortDateString();
            MessageBox.Show("" + index);
            lista_ponude[index].Datum_do = dateTimePicker2.Value.ToShortDateString();
            lista_ponude[index].Cena_danu = double.Parse(textBox2.Text);
            MessageBox.Show("Uspesna izmena");
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = File.OpenWrite(@"ponude.txt");
            stream.SetLength(0);
            formatter.Serialize(stream, lista_ponude);
            stream.Dispose();
        }
    }
}
