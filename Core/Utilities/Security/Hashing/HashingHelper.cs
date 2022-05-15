using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
   public  class HashingHelper // hash oluşturmaya ve onu doğrulamaya yarıyor
    {
        public static void CreatePasswordHash(string password,out byte[] passwordHash, out byte[] passwordSalt) 
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; // buradaki key ilgili algoritmanın o an oluşturduğu key değeri, her kullanıcı için farklı
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));// parantezin içerisi stringin byte karşılığını almamızı sağlar
            }
        }
        // bu kod ona verdiğimiz ilk password un bize hashini ve saltını oluşturuyo

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) // burada out olmamasının sebebi değerleri biz veriyoruz
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//oluşan değer bir byte array
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])// iki değeri karşılaştırıyoruz
                    {
                        return false; // parolanın hashleri eşleşmezse parola yanlış
                    }
                }
               
            }
            return true;

        }
        // buradaki parola kullanıcı sisteme tekrar girmeye çalıştığında yazdığı parola
        // biz bu parolanın hashlerini karşılaştırıcaz aynıysa sisteme girebilecek
    }
}
