using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class OrderManagerment
    {
        private static OrderManagerment instance = null;
        private static readonly object instanceLock = new object();
        public static OrderManagerment Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new OrderManagerment();
                }
                return instance;
            }
        }
        public List<Order> AllOrder()
        {
            List<Order> order;
            try
            {
                var context = new SaleManagerWPFContext();
                order = context.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }
        public List<Order> OrderByMemberId(int id)
        {
            List<Order> order;
            try
            {
                var context = new SaleManagerWPFContext();
                order = context.Orders.Where(x => x.MemberId == id).OrderByDescending(x => x.OrderDate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }
        public void Add(Order order)
        {
            try
            {
                var context = new SaleManagerWPFContext();
                context.Orders.Add(order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Order order)
        {
            Order orderUpdate = new Order();
            try
            {
                using (var context = new SaleManagerWPFContext())
                {
                    orderUpdate = context.Orders.Where(x => x.OrderId == order.OrderId).FirstOrDefault();
                    if (orderUpdate!=null)
                    {
                        orderUpdate.Freight = order.Freight;
                        orderUpdate.MemberId = order.MemberId;
                        orderUpdate.OrderDate = order.OrderDate;
                        orderUpdate.RequiredDate = order.RequiredDate;
                        orderUpdate.ShippedDate = order.ShippedDate;
                        context.Orders.Update(orderUpdate);
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
            Order order = context.Orders.Where(x => x.OrderId == int.Parse(id)).FirstOrDefault();
            if (order != null)
            {
                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }
        public void DeleteByMemberId(string id)
        {
            var context = new SaleManagerWPFContext();
            Order order = context.Orders.Where(x => x.MemberId == int.Parse(id)).FirstOrDefault();
            if (order != null)
            {
                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }
    }
}
