using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class OrderDetailManagerment
    {
        private static OrderDetailManagerment instance = null;
        private static readonly object instanceLock = new object();
        public static OrderDetailManagerment Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new OrderDetailManagerment();
                }
                return instance;
            }
        }
        public List<OrderDetail> AllOrderDetail()
        {
            List<OrderDetail> OrderDetail;
            try
            {
                var context = new SaleManagerWPFContext();
                OrderDetail = context.OrderDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return OrderDetail;
        }
        public void Add(OrderDetail OrderDetail)
        {
            try
            {
                var context = new SaleManagerWPFContext();
                context.OrderDetails.Add(OrderDetail);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(OrderDetail OrderDetail)
        {
            OrderDetail OrderDetailUpdate = new OrderDetail();
            try
            {
                using (var context = new SaleManagerWPFContext())
                {
                    OrderDetailUpdate = context.OrderDetails.Where(x => x.OrderId == OrderDetail.OrderId && x.ProductId == OrderDetail.ProductId).FirstOrDefault();
                    if (OrderDetailUpdate!=null)
                    {
                        OrderDetailUpdate.OrderId= OrderDetail.OrderId;
                        OrderDetailUpdate.ProductId = OrderDetail.ProductId;
                        OrderDetailUpdate.UnitPrice = OrderDetail.UnitPrice;
                        OrderDetailUpdate.Quantity = OrderDetail.Quantity;
                        OrderDetailUpdate.Discount = OrderDetail.Discount;
                        context.OrderDetails.Update(OrderDetailUpdate);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int OrderId, int ProductId)
        {
            var context = new SaleManagerWPFContext();
            OrderDetail OrderDetail = context.OrderDetails.Where(x => x.OrderId == OrderId && x.ProductId == ProductId).FirstOrDefault();
            if (OrderDetail != null)
            {
                context.OrderDetails.Remove(OrderDetail);
                context.SaveChanges();
            }
        }
        public void DeleteProduct(int ProductId)
        {
            var context = new SaleManagerWPFContext();
            OrderDetail OrderDetail = context.OrderDetails.Where(x => x.ProductId == ProductId).FirstOrDefault();
            if (OrderDetail != null)
            {
                context.OrderDetails.Remove(OrderDetail);
                context.SaveChanges();
            }
        }
        public void DeleteOrder(int OrderId)
        {
            var context = new SaleManagerWPFContext();
            OrderDetail OrderDetail = context.OrderDetails.Where(x => x.OrderId == OrderId).FirstOrDefault();
            if (OrderDetail != null)
            {
                context.OrderDetails.Remove(OrderDetail);
                context.SaveChanges();
            }
        }
    }
}
