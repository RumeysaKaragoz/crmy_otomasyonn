using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crmy
{
    public partial class Form2 : CrmyForm
    {
        public Form2()
        {
            InitializeComponent();
            this.Text = "CRMY AnaMenü";
        }

        private void label1_Click(object sender, EventArgs e)
        { 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            musteriekle ekle = new musteriekle();
            ekle.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            musterislemleri islemleri = new musterislemleri();
            islemleri.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Talepyön t=new Talepyön();
            t.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
