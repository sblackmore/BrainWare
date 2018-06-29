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

            
            //Get the order products
            var sql2 =
                "SELECT op.price, op.order_id, op.product_id, op.quantity, p.name, p.price FROM orderproduct op INNER JOIN product p on op.product_id=p.product_id";

            var orderProducts = database.GetOrderProducts(sql2);

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