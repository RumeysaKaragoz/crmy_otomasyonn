using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crmy
{

    public abstract class musteriislem
    {
     
          virtual public  Task MusteriListele(DataGridView grid)
        {
            MessageBox.Show("Müşteriler listelendi"); 
            return Task.CompletedTask;
        }
        virtual public Task MusteriGuncelle(string id, string ad, string soyad, string telefon, string email)
        {
           MessageBox.Show("Müşteriler Güncellendi"); 
            return Task.CompletedTask;
        }
        virtual public Task MusteriSil(string id)
        {
            MessageBox.Show("Müşteriler listelendi");
            return Task.CompletedTask;
        }

        }



    }
