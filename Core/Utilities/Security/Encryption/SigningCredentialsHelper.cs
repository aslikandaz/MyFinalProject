using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper // JWT sistemine anahtarın bu şifreleme algoritman da bu diyosun
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) // asp.net e kullanacağı anahtar ve algoritmayı veriyoruz
        {
            return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
