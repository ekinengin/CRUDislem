using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        //Burada sadece Product nesnesi için çalışmayacağız bi< aynı zamanda category customer gibi
        //classlarla da çalışabiliriz. onun için daha önceden öğrendiğimiz repository sınıfını generic tipde
        //oluşturmamız ve bu sınıfa miras vermemiz gerekmektedir..



    }
}
