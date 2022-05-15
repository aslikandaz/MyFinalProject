using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper //elimdeki (webapı/appjason daki) security helperı byte haline getiriyo ve onu simetrik key haline getiriyo çünkü stringlerle parametre geçemiyoruz
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
  
}
