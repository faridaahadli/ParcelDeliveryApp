using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Helpers
{
    public static class HashHelper
    {
        public static string Hash(string input,string salt)
        {
            string result=string.Empty;
            var asByteArr=Encoding.UTF8.GetBytes(input);
            var saltByteArr=Encoding.UTF8.GetBytes(salt);
            using(var sha =new HMACSHA256(saltByteArr))
            {
              result= Convert.ToBase64String(sha.ComputeHash(asByteArr));
            }
           
            return result;
        }
    }
}
