using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //token üretecek mekanizma
        //kullanıcı adı ve parolası doğru olan kullanıcı için veritabanına gidip claimlerine bakıp token üretecek
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
      
    }
}
