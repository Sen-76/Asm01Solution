using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class ProductManagerment
    {
        private static ProductManagerment instance = null;
        private static readonly object instanceLock = new object();
        public static ProductManagerment Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new ProductManagerment();
                }
                return instance;
            }
        }
        public List<Product> AllProduct()
        {
            List<Product> Product;
            try
            {
                var context = new SaleManagerWPFContext();
                Product = context.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Product;
        }
        public List<Product> Filter(string? name, decimal? unitPrice, int? stock)
        {
            List<Product> Product;
            try
            {
                var context = new SaleManagerWPFContext();
                Product = context.Products.Where(x => x.ProductName.Contains(name) && x.UnitPrice >= unitPrice && x.UnitsInStock >= stock).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Product;
        }
        public void Add(Product Product)
        {
            try
            {
                var context = new SaleManagerWPFContext();
                context.Products.Add(Product);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Product Product)
        {
            Product ProductUpdate = new Product();
            try
            {
                using (var context = new SaleManagerWPFContext())
                {
                    ProductUpdate = context.Products.Where(x => x.ProductId == Product.ProductId).FirstOrDefault();
                    if (ProductUpdate!=null)
                    {
                        ProductUpdate.ProductId = Product.ProductId;
                        ProductUpdate.ProductName = Product.ProductName;
                        ProductUpdate.CategoryId = Product.CategoryId;
                        ProductUpdate.Weight = Product.Weight;
                        ProductUpdate.UnitPrice = Product.UnitPrice;
                        ProductUpdate.UnitsInStock = Product.UnitsInStock;
                        context.Products.Update(ProductUpdate);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(string id)
        {
            var context = new SaleManagerWPFContext();
            Product Product = context.Products.Where(x => x.ProductId == int.Parse(id)).FirstOrDefault();
            if (Product != null)
            {
                context.Products.Remove(Product);
                context.SaveChanges();
            }
        }
    }
}
