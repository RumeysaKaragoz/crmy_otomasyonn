using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Security.Cryptography; 


namespace crmy
{
    internal class SecurityHelper
    {


        public static string Sha256(string input)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha.ComputeHash(bytes);

                var sb = new StringBuilder();
                foreach (var b in hash) 
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }

    }
}
