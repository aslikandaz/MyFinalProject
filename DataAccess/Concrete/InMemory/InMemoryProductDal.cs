using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            // bu kısım projeyi çalıştırdığımızda bellekte ürün oluşturur
            _products = new List<Product>
            {
                new Product{ProductId = 1, CategoryId = 1, ProductName = "bardak", UnitPrice = 15,UnitsInStock = 15},
                new Product{ProductId = 2, CategoryId = 1, ProductName = "kamera", UnitPrice = 500, UnitsInStock = 3},
                new Product{ProductId = 3, CategoryId = 2, ProductName = "telefon", UnitPrice = 1500,UnitsInStock = 2},
                new Product{ProductId = 4, CategoryId = 2, ProductName = "klavye", UnitPrice = 150,UnitsInStock = 65},
                new Product{ProductId = 5, CategoryId = 2, ProductName = "fare", UnitPrice = 85,UnitsInStock = 1}

            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //} bu işlem aşağıdaki tek satırla aynı işi yapar

            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId); // tek bir eleman bulmaya yarar ürünleri tek tek dolaşır
            // p=> her p için demek
            // burada singleordefault yerine first kullansak da olur firstordefault kullansak da olur

            _products.Remove(productToDelete); 

              //products.Remove(product); direk  bu şekilde silme yapamayız çünkü referans adresi farklı olur
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList(); 
            // where içindeki şarta uyan bütün elemanları yeni bir liste yapar ve onu döndürür
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            // gönderdiğim ürün ıdsine sahip olan listedeki ürünü bul 
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId); // burad referans numarasını getirdiğimiz için güncelleme yapabiliriz
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
    }
}
