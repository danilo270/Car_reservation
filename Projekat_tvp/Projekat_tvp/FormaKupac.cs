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
    public partial class FormaKupac : Form
    {
        List<Kupac> lista_osoba = new List<Kupac>();
        private int brojac = 3;
        public FormaKupac()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 16;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = File.OpenRead(@"Kupci.txt");
            lista_osoba = (List<Kupac>)formatter.Deserialize(stream);
            foreach (var Kupac in lista_osoba)
            {
                //MessageBox.Show("" + Kupac.Ime + "" + Kupac.Password);
                if (textBox1.Text.Equals(Kupac.Ime) && textBox2.Text.Equals(Kupac.Password))
                {
                    Form f1 = new IzmenaRezervacija(Kupac);
                    f1.Show();
                }
            }
            stream.Close();
        }

        private void FormaKupac_Load(object sender, EventArgs e)
        {
            
        }
    }
}
