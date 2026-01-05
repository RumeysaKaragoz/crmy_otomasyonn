using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace crmy
{

    internal  abstract class TemelVarlik
    {  //müşteri ve talep için ortak olan varlıklar burada  tanımlandı
        public string ID { get; set; }
        public DateTime CreatedTime { get; private set; }
        public DateTime UpdatedTime { get; private set; }
        public bool IsActive { get; set; }

        public TemelVarlik()
        {
            UpdatedTime = DateTime.UtcNow;

            CreatedTime = DateTime.UtcNow;
            IsActive = true;
        }
        public void UpdateTimestamp()
        {
            UpdatedTime = DateTime.UtcNow;
        }

        public abstract string GetInfo();
        

    }
}
