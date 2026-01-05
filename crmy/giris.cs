using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static crmy.baglanti;
using System.Configuration;

namespace crmy
{
    internal class giris
    {
        string kullanıcID = "";
        string sifre = "";
        public string ID { get { return kullanıcID; } set { kullanıcID = value; } }
        public string Sifre { get { return sifre; } set { sifre = value; } }


        //async metot olmak zorunda çünkü firestore veritabanı ile iletişim asenkron gerçekleşiyor

         
        public async Task<bool> GirAsync()
        {
            // DEMO MODE: hocanın bilgisayarında anahtarsız çalışsın diye
            bool demoMode = (ConfigurationManager.AppSettings["DemoMode"] ?? "true")
     .Equals("true", StringComparison.OrdinalIgnoreCase);

            if (demoMode)
            {
                string cfgUser = ConfigurationManager.AppSettings["DemoUsername"];
                string cfgHash = ConfigurationManager.AppSettings["DemoPasswordHash"];

                string inputHash = SecurityHelper.Sha256(sifre);

                if (kullanıcID == cfgUser && inputHash == cfgHash)

                {
                    MessageBox.Show("Başarılı (Demo)");
                    return true;
                }

                MessageBox.Show("Kullanıcı adı veya şifre hatalı (Demo)");
                return false;
            }


            if (kullanıcID == "" && sifre == "")
            {
                MessageBox.Show("Lütfen Kullanıcı Adı ve Şifre Giriniz");
                return false;
            }
            else if (sifre == "")
            {
                MessageBox.Show("Lütfen Şifre Giriniz");
                return false;
            }
            else if (kullanıcID == "")
            {
                MessageBox.Show("Lütfen Kullanıcı Adı Giriniz");
                return false;
            }
            else if (sifre != "" && kullanıcID != "")
            {
                try
                {
                    // Firestore bağlantısı
                    var db = baglanti.FirestoreService.GetDb();
                    var girisRef = db.Collection("giris");
                    var snapshot = await girisRef.GetSnapshotAsync();

                    //verilere erişim
                    foreach (var doc in snapshot.Documents)
                    {
                        string dbKullanici = doc.GetValue<string>("kullanıcıD");
                        string dbSifre = doc.GetValue<string>("sifre");
                        if (kullanıcID == dbKullanici && sifre == dbSifre)
                        {

                            MessageBox.Show("Başarılı ");
                            return true;
                        }
                        else if (kullanıcID != dbKullanici )
                        {
                            MessageBox.Show("Kullanıcı Adı Hatalı");
                            return false;
                        }
                        else if (sifre != dbSifre)
                        {
                            MessageBox.Show("Şifre Hatalı");
                            return false;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                    return false;
                }
               
            }
            return false;
        }
    }
}
