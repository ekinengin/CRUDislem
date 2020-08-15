using FluentValidation;
using Northwind.Business.Abstract;
using Northwind.Business.Utilities;
using Northwind.Business.ValidationRules.FluentValidation;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Concrete
{
    public class ProductManager:IProductService
    {

        //EfProductDal _productDal = new EfProductDal(); OLMAZ!!
        //Business da solid in 'd'si olan dependency injection tabirini en belirgin şekilde uygularız..
        //dependency inj. olayı new leme bağımlılığının ortdan kalkması

        public IProductDal _productDal;   //Burada d.i. uyguladık ctor ile.. ve newlendiğinde

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void AddProduct(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product); //static classlar bu şekilde çağırılıyordu hatırla!!
            _productDal.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            _productDal.Update(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetCategoryById(int categoryId) //burası convertedilen combocatin selectedvalue su
        {
            return _productDal.GetAll(x => x.CategoryId == categoryId);
        }

        public List<Product> GetProductsByName(string productName)
        {
            return _productDal.GetAll(x => x.ProductName.ToLower().Contains(productName.ToLower()));
        }

        
    }
}
