using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        public void Add(OrderDetail OrderDetail);
        public void Update(OrderDetail OrderDetail);
        public void Delete(int orderId, int prouctId);
        public void DeleteOrder(int orderId);
        public void DeleteProduct(int prouctId);
        public List<OrderDetail> Search(string name);
        public List<OrderDetail> AllOrderDetail();
    }
}
