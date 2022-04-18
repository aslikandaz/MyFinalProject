using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
        // bu IEntityRepositoryi product için yapılandırdın demektir
        //product'la ilgili veritabanında yapılacak işlemleri tutan interface
    {
        List<ProductDetailDto> GetProductDetails();
    }
}
