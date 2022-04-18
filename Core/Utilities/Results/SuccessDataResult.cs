using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        //tüm bilgilerin verildiği versiyon data,mesaj,işlem sonucu(default true verdik)
        public SuccessDataResult(T data, string message):base(data,true,message)
        {
            
        }

        // mesaj verilmedi data ve işlem sonucu var
        public SuccessDataResult(T data):base(data,true)
        {
            
        }

        // datanın default hali yani sadece mesaj gelicek
        public SuccessDataResult(string message):base(default,true,message)
        {
            
        }

        //hiçbişey vermek istemiyosam,default data
        public SuccessDataResult():base(default,true)
        {
            
        }
    }
}
