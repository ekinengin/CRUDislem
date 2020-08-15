using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.DependencyResovers.Ninject
{
    public class InstenceFactory
    {
        //Bu alan niçin var ne işe yarar.
        //biz form arayüzünde cons. da bişey çağıramıyoruz bu alan onun eksikliğini tamtmlamak için
        //diğer class ta tanımlananan(business module) 4 işlem module parametresi oluyor..

        public static T GetInstence<T>()
        {
            var kernel = new StandardKernel(new BusinessModule());
            return kernel.Get<T>();
        }
    }
}
