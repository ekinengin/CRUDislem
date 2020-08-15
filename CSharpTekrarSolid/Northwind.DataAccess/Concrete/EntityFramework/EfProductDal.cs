using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.EntityFramework
{
    //DataAccess kısmı burada sahip olduğumuz methodları yazacağız daha sonra kullanacağımız vakit classı newleyerek 
    //methodlarımızı kullanabileceğiz..

    public class EfProductDal : EfEntityRepositoryBase<Product,NorthwindContext>, IProductDal
    {

        
    }
}
