using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        //tüm bilgilerin verildiği versiyon data,mesaj,işlem sonucu(default false verdik)
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        // mesaj verilmedi data ve işlem sonucu var
        public ErrorDataResult(T data) : base(data, false)
        {

        }

        // datanın default hali yani sadece mesaj gelicek
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        //hiçbişey vermek istemiyosam,default data
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
