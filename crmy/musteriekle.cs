using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;


namespace crmy
{
    public partial class musteriekle : CrmyForm
    {
        public musteriekle()
        {
            InitializeComponent();
            // set the specific title for this form AFTER InitializeComponent
            this.Text = "CRMY Musteri Kayıt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || 
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) || 
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                musteri yenimüsteri=new musteri();
                yenimüsteri.Ad = textBox1.Text;
                yenimüsteri.Soyad = textBox2.Text;
                yenimüsteri.Telefon = textBox3.Text;
                yenimüsteri.Email = textBox4.Text;
                bool sonuc=await yenimüsteri.MusteriEkle();
                if (sonuc==true)
                {
                    MessageBox.Show(yenimüsteri.GetInfo(),"\n"+" Müşteri başarıyla eklendi.");
                    
                }
                else
                {
                    MessageBox.Show(yenimüsteri.GetInfo() +  "Müşteri eklenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();


        }

        private void musteriekle_Load(object sender, EventArgs e)
        {

        }
    }
}
