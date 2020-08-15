using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.Business.DependencyResovers.Ninject;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind.WfaWithSolid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //_productService = new ProductManager(new EfProductDal());
            //_categoryService = new CategoryManager(new EfCategoryDal());

            _productService = InstenceFactory.GetInstence<IProductService>();
            _categoryService = InstenceFactory.GetInstence<ICategoryService>();
        }

        private IProductService _productService; //Bu field ile business ı çağırdık. 
        private ICategoryService _categoryService;

        private void Form1_Load(object sender, EventArgs e)
        {
            //Burada Productdal yasak!!
            //Burada business olmalı !!
            //Business ı da field  ve ctor yardımı ile çağırdık..

            LoadProducts();

            combocat.DataSource = _categoryService.GetAll();
            combocat.DisplayMember = "CategoryName";
            combocat.ValueMember = "CategoryId";

            comboAddCat.DataSource = _categoryService.GetAll();
            comboAddCat.DisplayMember = "CategoryName";
            comboAddCat.ValueMember = "CategoryId";

            comboUpCat.DataSource = _categoryService.GetAll();
            comboUpCat.DisplayMember = "CategoryName";
            comboUpCat.ValueMember = "CategoryId";
        }

        private void combocat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Madem categolri ile işimiz neden _productService yazıyoruz.. çünki biz productı getireceğiz yine ancak belirttiğimiz categoriye göre..
                Dgv.DataSource = _productService.GetCategoryById(Convert.ToInt32(combocat.SelectedValue));
            }
            catch
            {
            }         
        }

        private void LoadProducts() //method
        {
            Dgv.DataSource = _productService.GetAll();
        }

        private void textproduct_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textproduct.Text)) //text boşşsa hepsini getir.
            {
                LoadProducts();
            }
            else
            {
                Dgv.DataSource = _productService.GetProductsByName(textproduct.Text);
            }          
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _productService.AddProduct(new Product()
            {
                CategoryId = Convert.ToInt32(comboAddCat.SelectedValue), //yukarıda formloadda tanımlı category
                ProductName = textAddName.Text,
                QuantityPerUnit = textAddPerUnit.Text,
                UnitPrice = Convert.ToDecimal(textAddPrice.Text),
                UnitsInStock = Convert.ToInt16(textAddStock.Text)
            }); ;

            LoadProducts();
            
            labelState.Text = "Product Added!!";
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            _productService.UpdateProduct(new Product()
            {
                ProductId =Convert.ToInt32(Dgv.CurrentRow.Cells[0].Value),
                CategoryId = Convert.ToInt32(comboUpCat.SelectedValue), //yukarıda formloadda tanımlı category
                ProductName = textUpName.Text,
                QuantityPerUnit = textUpPerUnit.Text,
                UnitPrice = Convert.ToDecimal(textUpPrice.Text),
                UnitsInStock = Convert.ToInt16(textUpStock.Text)
            }) ;

            LoadProducts();
            labelState.Text = "Product Updated!!";
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textUpName.Text = Dgv.CurrentRow.Cells[2].Value.ToString();
            textUpPrice.Text = Dgv.CurrentRow.Cells[3].Value.ToString();
            textUpPerUnit.Text = Dgv.CurrentRow.Cells[4].Value.ToString();
            textUpStock.Text = Dgv.CurrentRow.Cells[5].Value.ToString();
            comboUpCat.SelectedValue = Dgv.CurrentRow.Cells[1].Value;
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            //İlk açıldığında dgv ye tıklamadan silmeye çalışılabilinir. böyle durumlarda defensing programing devreye girer.
            //Aşşağıdada bunu uyguladık!!
            //Hata yönetimi business ın yeridir 

            try
            {
                if (Dgv.CurrentRow != null)
                {
                    _productService.Delete(new Product() { ProductId = Convert.ToInt32(Dgv.CurrentRow.Cells[0].Value) });
                }
            }
            catch (Exception exception)
            {
                //çift inner exception daha detaylıu bir bilgi vermemizi sağlar
                //Ama bu durum sistemle ilgili birsürü bilgiyide mesaj olarak verir.
                MessageBox.Show(exception.InnerException.InnerException.Message);
            }

            

            LoadProducts();

            labelState.Text = "Product Deleted!!";
        }
    }
}
