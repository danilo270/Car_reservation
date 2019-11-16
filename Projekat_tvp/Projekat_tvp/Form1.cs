using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat_tvp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminForma administracija = new AdminForma();
            administracija.Show();
        }

        private void korisnik_dugme_Click(object sender, EventArgs e)
        {
            Form fr = new FormaKupac();
            fr.Show();
        }
    }
}
