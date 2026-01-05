using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crmy
{
    internal class MusteriSilme : musteriislem
    {
        public override async Task MusteriSil(string id)
        {
            try
            {
                var db = baglanti.FirestoreService.GetDb();
                await db.Collection("musteriler").Document(id).DeleteAsync();

                MessageBox.Show("Müşteri başarıyla silindi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        public override Task MusteriListele(DataGridView grid)
            => throw new NotImplementedException();

        public override Task MusteriGuncelle(string id, string ad, string soyad, string telefon, string email)
            => throw new NotImplementedException();
    }
}
