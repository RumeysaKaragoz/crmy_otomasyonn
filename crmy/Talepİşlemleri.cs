using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace crmy
{
    internal class Talepİşlemleri:Italep
    {

        string musteriId;
        string talepTipi;
        string aciklama;
        
       
        public TalepDurumu Durum { get; set; }= TalepDurumu.Açık;
        public enum TalepDurumu { Açık, Beklemede, Kapalı }
        public string MusteriId { get => musteriId; set => musteriId = value; }
        public string TalepTipi { get => talepTipi; set => talepTipi = value; }
        public string Aciklama { get => aciklama; set => aciklama = value; }

        public override string GetInfo() //çift kalıtımdan gelen
        {
            return $"Talep [ {Durum} ] {TalepTipi} : {Aciklama}";


        }

        private FirestoreDb db = baglanti.FirestoreService.GetDb();
        private T SafeGet<T>(DocumentSnapshot doc, string field)
        {
            if (!doc.ContainsField(field))
                return default;

            object value = doc.GetValue<object>(field);

            try
            {
                // String isteniyorsa, gelen ne olursa olsun ToString'e çevir
                if (typeof(T) == typeof(string))
                    return (T)(object)value.ToString();

                // Enum isteniyorsa, sayısal/string değerleri enum'a çevirmeyi dene
                if (typeof(T).IsEnum)
                {
                    if (value is string s)
                        return (T)Enum.Parse(typeof(T), s, ignoreCase: true);

                    return (T)Enum.ToObject(typeof(T), value);
                }

                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                return default;
            }
        }
        public override async Task<bool> TalepEkle(string musteriId, string talepTipi, string aciklama)
        {
            var data = new Dictionary<string, object>()
            {
                { "musteriId", musteriId },
                { "talepTipi", talepTipi },
                { "aciklama", aciklama },
                { "durum", "Açık"},
                { "tarih", Timestamp.FromDateTime(CreatedTime) }
            };

            await db.Collection("Talepler").AddAsync(data);
            return true;
        }

    public override async Task<bool> TalepSil(string id)
        {
            await db.Collection("Talepler").Document(id).DeleteAsync();
            return true;
        }

    public override async Task<bool> TalepGuncelle(string id, string talepTipi, string aciklama,TalepDurumu durum)
        {
            UpdateTimestamp();

            var data = new Dictionary<string, object>()
            {
                { "talepTipi", talepTipi },
                { "aciklama", aciklama },
                {"durum" ,durum.ToString()},
                { "updatedTime", Timestamp.FromDateTime(UpdatedTime) }
            };

            await db.Collection("Talepler").Document(id).UpdateAsync(data);
            return true;
        }

    public override async Task TalepListele(DataGridView grid)
        {
          
          var snapshot = await db.Collection("Talepler").GetSnapshotAsync();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("MusteriID");
            dt.Columns.Add("TalepTipi");
            dt.Columns.Add("Aciklama");
            dt.Columns.Add("Durum");
            dt.Columns.Add("Tarih");


          foreach (var doc in snapshot.Documents)
             {
        string musteriId = SafeGet <string>(doc, "musteriId");
        string talepTipi = SafeGet<string>(doc, "talepTipi");
        string aciklama = SafeGet<string>(doc, "aciklama");
        string durum = SafeGet<string>(doc, "durum");
        Timestamp tarihTs = SafeGet<Timestamp>(doc, "tarih");

        DateTime? tarih = tarihTs != null ? tarihTs.ToDateTime() : (DateTime?)null;

        dt.Rows.Add(doc.Id, musteriId, talepTipi, aciklama, durum, tarih);
}


    grid.DataSource = dt;
        }

    public async Task<string> MusteriAdSoyadGetir(string musteriId)
        {
            var db = baglanti.FirestoreService.GetDb();
            var snap = await db.Collection("musteriler").Document(musteriId).GetSnapshotAsync();

            if (!snap.Exists) return "";

            string ad = snap.GetValue<string>("ad");
            string soyad = snap.GetValue<string>("soyad");
            string telefon = snap.GetValue<string>("telefon");

            return $"{ad} {soyad}  {telefon}";
        }




    }
}
