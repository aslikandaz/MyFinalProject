using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message):this(success) // buradaki this ile tek parametreli olanı çalıştırdık
        {
            Message = message;
           //Success = success; bu işlemi burada yapmıyoruz çünkü bu görevi diğer constructor a veriyoruz kod tekrarı olmaması için
        }
        //mesaj vermek istemediğimiz sadece success durumunu basmak istediğimiz durumlar için constructor overloading yaptık

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }//=> dan sonra yazdığımız şeyi return edecek

        public string Message { get; }
    }
}
