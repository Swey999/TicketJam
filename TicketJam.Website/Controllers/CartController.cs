using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TicketJam.Website.APIClient;
using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.Controllers
{
    public class CartController : Controller
    {
        // GET: CartController
        TicketAPIConsumer _ticketAPIConsumer = new TicketAPIConsumer("https://localhost:7280/api/v1/TicketControllerAPI");
        public ActionResult Index()
        {
            return View(GetCartFromCookie());
        }

        public ActionResult Add(int id, int quantity)
        {
            Order order = GetCartFromCookie();
            OrderLine existingOrderLine = order.orderLines.FirstOrDefault(ol => ol.ticketId == id);
            if (existingOrderLine != null)
            {
                existingOrderLine.quantity += quantity;
                if (existingOrderLine.quantity <= 0)
                {
                    order.orderLines.Remove(existingOrderLine);
                }
            }
            else
            {
                OrderLine newOrderLine = new OrderLine
                {
                    ticketId = _ticketAPIConsumer.GetById(id).id,
                    quantity = quantity
                };
                order.orderLines.Add(newOrderLine);
            }
            
            SaveCartToCookie(order);
            return View("Index", order);
        }

        public Order GetCartFromCookie()
        {
            Request.Cookies.TryGetValue("Order", out string? cookie);
            if (cookie == null) { return new Order(); }
            return JsonSerializer.Deserialize<Order>(cookie) ?? new Order();
        }

        private void SaveCartToCookie(Order order)
        {
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(7);
            cookieOptions.Path = "/";
            Response.Cookies.Append("Order", JsonSerializer.Serialize(order), cookieOptions);
        }

        public ActionResult EmptyCart()
        {
            Order order = GetCartFromCookie();
            order.orderLines = new List<OrderLine>(); //Check om det virker nyt shit
            SaveCartToCookie(order);
            return View("Index", order);
        }
    }
}
