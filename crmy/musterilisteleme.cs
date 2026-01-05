using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crmy
{
  
        internal class MusteriListeleme : musteriislem
        {

        private string SafeGet(DocumentSnapshot doc, string field)
        {
            return doc.ContainsField(field) ? doc.GetValue<string>(field) : "";
        }

        public override async Task MusteriListele(DataGridView grid)
            {
                var db = baglanti.FirestoreService.GetDb();
                var snapshot = await db.Collection("musteriler").GetSnapshotAsync();
       
        DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("ad");
                dt.Columns.Add("soyad");
                dt.Columns.Add("telefon");
                dt.Columns.Add("email");

            foreach (var doc in snapshot.Documents)
            {
                dt.Rows.Add(
                    doc.Id,
                    SafeGet(doc, "ad"),
                    SafeGet(doc, "soyad"),
                    SafeGet(doc, "telefon"),
                    SafeGet(doc, "email")
                );
            }


            grid.DataSource = dt;
            }

            public override Task MusteriGuncelle(string id, string ad, string soyad, string telefon, string email)
                => throw new NotImplementedException();

            public override Task MusteriSil(string id)
                => throw new NotImplementedException();
        }
    

}
