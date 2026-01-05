using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crmy
{
    internal abstract class Italep:TemelVarlik
    {
        public abstract Task<bool> TalepEkle(string musteriId, string talepTipi, string aciklama);
        public abstract Task<bool> TalepSil(string id);
        public abstract Task<bool> TalepGuncelle(string id, string talepTipi, string aciklama,Talepİşlemleri.TalepDurumu durum);
        public abstract Task TalepListele(DataGridView grid);
    }
}
