namespace Web.Controllers
{
    using BusinessModel;
    using System.Collections.Generic;
    using System.Web.Http;
    using BusinessLogic;

    public class OrderController : ApiController
    {
        [HttpGet]
        public IEnumerable<Order> GetOrders(int id = 1)
        {
            var data = new OrderService();

            return data.GetOrdersForCompany(id);
        }
    }
}
