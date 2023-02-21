using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void Add(Order order) => OrderManagerment.Instance.Add(order);

        public List<Order> AllOrder() => OrderManagerment.Instance.AllOrder();

        public void Delete(string id) => OrderManagerment.Instance.Delete(id);

        public void Update(Order order) => OrderManagerment.Instance.Update(order);

        public void DeleteByMemberId(string id) => OrderManagerment.Instance.DeleteByMemberId(id);
        public List<Order> Search(string name)
        {
            throw new NotImplementedException();
        }

        public List<Order> OrderByMemberId(int id) => OrderManagerment.Instance.OrderByMemberId(id);
    }
}
