using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void Add(OrderDetail OrderDetail) => OrderDetailManagerment.Instance.Add(OrderDetail);
        public void Update(OrderDetail OrderDetail) => OrderDetailManagerment.Instance.Update(OrderDetail);
        public void Delete(int OrderId, int productId) => OrderDetailManagerment.Instance.Delete(OrderId, productId);
        public void DeleteOrder(int OrderId) => OrderDetailManagerment.Instance.DeleteOrder(OrderId);
        public void DeleteProduct(int productId) => OrderDetailManagerment.Instance.DeleteProduct(productId);
        public List<OrderDetail> Search(string name)
        {
            throw new NotImplementedException();
        }
        public List<OrderDetail> AllOrderDetail() => OrderDetailManagerment.Instance.AllOrderDetail();
    }
}
