using Ninject.Modules;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.DependencyResovers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()  //bu override edildi otomatik geldi
        {
            //Buradı özellikle formda yaptığımız newlemeler ile ilgiliydi..
            //yani     _productService = new ProductManager(new EfProductDal()); 
            //bu şekilde yapmıştık hatırlarsan....

            //biri senden servise isterse managerı gönder..
            //biri senden dal isterse efdal ı gönder..
            //interfaceleri classlara çevirdik gibi...
            //hepsi için demiş olduk bind<>().to<>() ile......


            //product için
            Bind<IProductService>().To<ProductManager>().InSingletonScope(); //in singleton performans arttırır
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            //category için
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();
        }
    }
}
