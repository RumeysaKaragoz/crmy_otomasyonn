using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace crmy
{
   
    public partial class musterislemleri : CrmyForm
    {
        public musterislemleri()
        {
            InitializeComponent();
            this.Text = "CRMY Musteri İşlemleri";
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Lütfen güncellenecek bir müşteri seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //p
            musteriislem g = new musteriguncelleme();

            await g.MusteriGuncelle(
                textBox1.Text,
                textBox2.Text,
                textBox3.Text,
                textBox4.Text,
                textBox5.Text
            );

            // Güncel listeyi tekrar çek  //poli
            musteriislem liste = new MusteriListeleme();
            await liste.MusteriListele(guna2DataGridView1);  

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private async void button5_Click(object sender, EventArgs e)
        {
        //p
            musteriislem liste = new MusteriListeleme();
            await liste.MusteriListele(guna2DataGridView1);
        

    }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Lütfen silmek için bir müşteri seçiniz.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult onay = MessageBox.Show(
                "Bu müşteriyi silmek istediğinize emin misiniz?",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (onay == DialogResult.No)
                return;

            //p
            musteriislem sil = new MusteriSilme();

            await sil.MusteriSil(textBox1.Text);

          // p değil 
            MusteriListeleme liste = new MusteriListeleme();
            await liste.MusteriListele(guna2DataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            musteriekle ek= new musteriekle();  
            ek.Show();
            this.Hide();

        }

        private void musterislemleri_Load(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox1.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                textBox2.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["Ad"].Value.ToString();
                textBox3.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["Soyad"].Value.ToString();
                textBox4.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["Telefon"].Value.ToString();
                textBox5.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            }
        }
    }
}
