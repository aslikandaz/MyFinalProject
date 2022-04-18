using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //temel voidler için başlangıç
    // işlem sonucu, kullanıcı bilgilendirme mesajı
    public interface IResult
    {
        bool Success { get; } // get sadece okumak için, bişeyi return et demek
        string Message { get; }
    }
}
