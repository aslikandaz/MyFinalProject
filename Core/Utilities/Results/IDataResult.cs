using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult // generic kullanmamızın sebebi tüm türler için(product,category...)kullanabilmek
    // aynı zamanda IResult implemente ederek hem data hemde mesaj ve success dönmeyi sağlamış olduk
    {
        T Data { get; }
    }
}
