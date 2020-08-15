using Northwind.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T: class, IEntity ,new()
    {
        //dedikki getall methodu parametre alabilir. veya boş verilip tüm db çağırılabilinir
        List<T> GetAll(Expression<Func<T,bool>> filter =  null); 
        T GetProduct(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
