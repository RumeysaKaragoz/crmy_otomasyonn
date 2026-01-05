using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crmy
{
    internal class musteriguncelleme : Imusteriislem
    {
        public void MusteriGuncelle()
        { 
        
        }

        public void MusteriSil() => throw new NotImplementedException();
        public void MusteriEkle() => throw new NotImplementedException();
        public Task Musterilistele(System.Windows.Forms.DataGridView dataGridView) => Task.CompletedTask;
    }

    internal class musterilisteleme
    {
        public Task Musterilistele(System.Windows.Forms.DataGridView dataGridView)
        {
            // Implementation for listing customers
            return Task.CompletedTask;
        }
    }
}