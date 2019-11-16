using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projekat_tvp.klase;
namespace Projekat_tvp
{
    public partial class AdminForma : Form
    {
        Administrator Danilo;
        int brojac=3;
        public AdminForma()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 16;
        }

        private void AdminForma_Load(object sender, EventArgs e)
        {
            Danilo = new Administrator("sifra123","Danilo","Radulovic",1,0668089439.ToString(),130796,"13.07.1996");
        }

        private void button1_Click(object sender, EventArgs e)
        {

                if (brojac == 0) this.Close();
                if (textBox1.Text.Equals(Danilo.Ime) && textBox2.Text.Equals(Danilo.Passwd))
                {
                    Form administracija = new Administracija();
                    administracija.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Netacan username ili password imate jos:" + brojac + "Pokusaja");
                    brojac--;
                }
        }
    }
}
