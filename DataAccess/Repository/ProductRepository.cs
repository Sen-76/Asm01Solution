using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void Add(Product product) => ProductManagerment.Instance.Add(product);

        public List<Product> AllProduct() => ProductManagerment.Instance.AllProduct();

        public void Delete(string id) => ProductManagerment.Instance.Delete(id);

        public void Update(Product product) => ProductManagerment.Instance.Update(product);

        public List<Product> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
