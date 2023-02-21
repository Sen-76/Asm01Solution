using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        public void Add(Order order);
        public void Update(Order order);
        public void Delete(string id);
        public void DeleteByMemberId(string id);
        public List<Order> Search(string name);
        public List<Order> AllOrder();
        public List<Order> OrderByMemberId(int id);
    }
}
