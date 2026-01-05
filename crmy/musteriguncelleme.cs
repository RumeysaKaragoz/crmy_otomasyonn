using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crmy
{
    internal class musteriguncelleme : musteriislem
    {
        public override async Task MusteriGuncelle(string id, string ad, string soyad, string telefon, string email)
        {
            try
            {
                var db = baglanti.FirestoreService.GetDb();
                DocumentReference docRef = db.Collection("musteriler").Document(id);

                Dictionary<string, object> data = new Dictionary<string, object>()
                {
                    { "ad", ad },
                    { "soyad", soyad },
                    { "telefon", telefon },
                    { "email", email },
                    { "updatedTime", Timestamp.FromDateTime(DateTime.UtcNow) }
                };

                await docRef.UpdateAsync(data);
                MessageBox.Show("Müşteri güncellendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        public override Task MusteriListele(DataGridView grid)
            => throw new NotImplementedException();

        public override     Task MusteriSil(string id)
            => throw new NotImplementedException();
    }
}

