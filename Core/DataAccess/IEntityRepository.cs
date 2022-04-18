using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
   public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //generic constraint (generic(T) kısıt)
        //class: referans tip
        //IEntity: IEntity olabilir veya IEntity implemente eden bir nesne olabilir
        //new : newlenebilir olmalı (IEntity interface olduğu için newlenemez)
        List<T> GetAll(Expression<Func<T,bool>> filter=null); // bu bizim veri filtrelememizi sağlıyo
        // filtera null vermemizin sebebi isterse filtrelemeyip tüm veriyi de listeleyebilir
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
