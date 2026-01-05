using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace crmy
{
    internal class musteri: TemelVarlik
    {
        string ad;
        string soyad;
        string email;
        string telefon;
        
        public string Ad { get => ad; set => ad = value; }
        public string Soyad { get => soyad; set => soyad = value; }
        public string Email { get => email; set => email = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        
        public override string GetInfo()
        {
            return $"{Ad}\n{Soyad}\n{Telefon}\n{Email}";
        }

        private static FirestoreDb db = baglanti.FirestoreService.GetDb();

        

        public async Task<bool> MusteriEkle()
        {
            var data = new Dictionary<string, object>()
            {
                { "ad", Ad },
                { "soyad", Soyad },
                { "telefon", Telefon },
                { "email", Email },
                { "createdTime", CreatedTime },
                { "isActive", IsActive }

            };
            await db.Collection("musteriler").AddAsync(data);
            return true;
        }




    }
}
