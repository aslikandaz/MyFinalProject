using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class TokenOptions
    {// bir helper class tır optionları içerdiği için çoğul aşağıdakilerin her biri bir option
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }// dakika cinsinden 
        public string SecurityKey { get; set; }
    }
}
