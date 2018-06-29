namespace Web.Infrastructure
{
    using System.Collections.Generic;
    using DataAccessLayer;
    using BusinessModel;

    public class OrderService
    {
        public List<Order> GetOrdersForCompany(int CompanyId)
        {

            var database = new OrderDAL();
            var orders = database.GetOrders();
            var orderProducts = database.GetOrderProducts();

            foreach (var order in orders)
            {
                foreach (var orderproduct in orderProducts)
                {
                    if (orderproduct.OrderId != order.OrderId)
                        continue;

                    order.OrderProducts.Add(orderproduct);
                    order.OrderTotal = order.OrderTotal + (orderproduct.Price * orderproduct.Quantity);
                }
            }

            return orders;
        }
    }
}