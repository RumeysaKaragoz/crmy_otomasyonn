using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crmy
{
    internal class baglanti
    {
        public static class FirestoreService
        {
            private static FirestoreDb _db;

            public static FirestoreDb GetDb()
            {
                if (_db == null)
                {
                    string json = @"crmy-14a60-firebase-adminsdk-fbsvc-7943879259.json";
                    string path = AppDomain.CurrentDomain.BaseDirectory + json;

                    Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

                    _db = FirestoreDb.Create("crmy-14a60");
                }

                return _db;
            }
        }
    }
}
