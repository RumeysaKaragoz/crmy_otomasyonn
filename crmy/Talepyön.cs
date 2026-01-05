using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace crmy
{
    public partial class Talepyön : CrmyForm

    {
        public Talepyön()
        {
            InitializeComponent();
            this.Text = "CRMY Talep";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null ||
        comboBox2.SelectedItem == null ||
        string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!");
                return;
            }
            var selected = comboBox1.SelectedItem as ComboBoxItem;
            if (selected == null)
            {
                MessageBox.Show("Geçerli bir müşteri seçin.");
                return;
            }
            //poli
            Italep talep = new Talepİşlemleri();
            string musteriId = selected.Value;
            string talepTipi = comboBox2.SelectedItem.ToString();


            bool result = await talep.TalepEkle(musteriId, talepTipi, richTextBox1.Text);


            if (result)
            {
                MessageBox.Show("Talep başarıyla eklendi!");
                await Listele(); // tabloyu yenile
            }
        }


        private async void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Güncellemek için listeden bir talep seçin!");
                return;
            }

            Italep talep = new Talepİşlemleri();

            // Get the selected TalepDurumu from comboBox3
            if (comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir talep durumu seçin!");
                return;
            }
            Talepİşlemleri.TalepDurumu durum = (Talepİşlemleri.TalepDurumu)Enum.Parse(
                typeof(Talepİşlemleri.TalepDurumu), comboBox3.SelectedItem.ToString());

            bool result = await talep.TalepGuncelle(
                textBox1.Text,
                comboBox1.SelectedItem.ToString(),
                richTextBox1.Text,
                durum
            );

            if (result == true) 
            {
                MessageBox.Show("Talep başarıyla güncellendi!");
                await Listele();
            }
        }
        private async Task Listele()
        {
            Italep talep = new Talepİşlemleri();
            await talep.TalepListele(guna2DataGridView1);
        }

        private async void button4_Click(object sender, EventArgs e)
        {

            await Listele();


        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Silmek için listeden talep seçin!");
                return;
            }

            Italep talep = new Talepİşlemleri(); 

            bool result = await talep.TalepSil(textBox1.Text);

            if (result)
            {
                MessageBox.Show("Talep silindi!");
              await  Listele();
            }
        }

        private  void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
       
        private void TalepTipiComboDoldur()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Şikayet");
            comboBox2.Items.Add("Öneri");
            comboBox2.Items.Add("Bilgi Talebi");
            comboBox2.Items.Add("Destek Talebi");
            comboBox2.Items.Add("Diğer");
        }
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public override string ToString() => Text;
        }//ıd ve ad bilgilerini tutmak için

        private async void Talepyön_Load(object sender, EventArgs e)
        {
            Italep talep = new Talepİşlemleri();
        
            var db = baglanti.FirestoreService.GetDb();
            var snapshot = await db.Collection("musteriler").GetSnapshotAsync();

            var list = snapshot.Documents
                .Select(doc => new ComboBoxItem
                {
                    Text = $"{doc.GetValue<string>("ad")} {doc.GetValue<string>("soyad")}",
                    Value = doc.Id
                })
                .ToList();

            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";

            comboBox3.Items.Clear();
            comboBox3.Items.AddRange(Enum.GetNames(typeof(Talepİşlemleri.TalepDurumu)));
            //await MusteriComboDoldur();
            TalepTipiComboDoldur();

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox1.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                string musteriId = guna2DataGridView1.Rows[e.RowIndex].Cells["MusteriID"].Value.ToString();
                string talepTipi = guna2DataGridView1.Rows[e.RowIndex].Cells["TalepTipi"].Value.ToString();
                richTextBox1.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["Aciklama"].Value.ToString();

                var match = comboBox1.Items.Cast<ComboBoxItem>()
                     .FirstOrDefault(i => i.Value == musteriId);
                if (match != null)
                    comboBox1.SelectedItem = match;

                comboBox2.SelectedItem = talepTipi;
            }
        }
    }
}

