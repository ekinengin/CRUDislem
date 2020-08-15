using FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.ValidationRules.FluentValidation
{
    //FluentValidation > dataanotation (dao) direk classlara [attribute] vermekti.. ancak bu daha iyi bir yöntem

    //Validasyon işlemleri genellikle db classlarına yapılır..
    //business katmanına fluentvalidation nugetten eklenir.
    //ve ilgili classa validatör ismini ekleyerek :AbstractValidator den inherit edilir

    //Ek bilgi snippet kısa yazma ctor tab gibi

    public class ProductValidator: AbstractValidator<Product> //product la çalışacağımızı böyle belirttik.
    {
        public ProductValidator() //ctorunun oluşturulması lazım
        {

            //Boş geçilemez kısmı------------------
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün ismi boş olamaz");
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitsInStock).NotEmpty();
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.CategoryId).NotEmpty();

            RuleFor(p => p.UnitPrice).GreaterThan(0);  //dan büyük olmalı
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0); //başta sıfır olabilir aded oyüzden 0 a eşit ve büyük
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 2); //Id si2 olanın fiyatı 10dan  büyük

            RuleFor(p => p.ProductName).Must(StartswithA); //Bunda StartswithA methodunu biz generate ederek aşşağıya oluşturduk
            //Asıl methodumuz aslında must onun içine yazıp aşşağıdaki methodda da  kuralımıız belirttik.
        }

        private bool StartswithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
