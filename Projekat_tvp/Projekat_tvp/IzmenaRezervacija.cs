using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projekat_tvp.klase;
namespace Projekat_tvp
{
    public partial class IzmenaRezervacija : Form
    {
        List<Rezervacije> lista_rezervacija = new List<Rezervacije>();
        Kupac kupac;
        public IzmenaRezervacija(Kupac k)
        {
            kupac = k;
            InitializeComponent();
        }

        private void IzmenaRezervacija_Load(object sender, EventArgs e)
        {
            BinaryFormatter stream = new BinaryFormatter();
            Stream fs = File.OpenRead(@"rezervacije.txt");
            lista_rezervacija = (List<Rezervacije>)stream.Deserialize(fs);
            foreach(Rezervacije r in lista_rezervacija)
            {
                if (r.Id_kupca.Equals(kupac.Id))
                {
                    listBox1.Items.Add(r);
                } 
            }
            fs.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new FormaRezervacija(kupac);
            f.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rezervacije tmp = (Rezervacije)listBox1.SelectedItem;
            //MessageBox.Show("" + lista_rezervacija.ElementAt(0));
            for(int i = 0; i != lista_rezervacija.Count; ++i)
            {
                if (tmp==lista_rezervacija[i])
                {
                    MessageBox.Show(""+i);
                    lista_rezervacija.RemoveAt(i);
                }
            }
            BinaryFormatter formater = new BinaryFormatter();
            Stream stream = File.OpenWrite(@"rezervacije.txt");
            formater.Serialize(stream, lista_rezervacija);
            listBox1.Items.Clear();
            foreach (Rezervacije r in lista_rezervacija)
            {
                if (r.Id_kupca.Equals(kupac.Id))
                {
                    listBox1.Items.Add(r);
                }
            }
            stream.Dispose();
        }
    }
}
