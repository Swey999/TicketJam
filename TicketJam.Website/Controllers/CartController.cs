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
            Order order = GetCartFromCookie();
            return View(order);
        }

        public ActionResult Add(int id, int quantity)
        {
            Order order = GetCartFromCookie();
            OrderLine existingOrderLine = order.OrderLines.FirstOrDefault(ol => ol.TicketId == id);
            if (existingOrderLine != null)
            {
                existingOrderLine.Quantity += quantity;
                if (existingOrderLine.Quantity <= 0)
                {
                    order.OrderLines.Remove(existingOrderLine);
                }
            }
            else
            {
                OrderLine newOrderLine = new OrderLine
                {
                    TicketId = _ticketAPIConsumer.GetById(id).Id,
                    Quantity = quantity
                };
                order.OrderLines.Add(newOrderLine);
            }
            
            SaveCartToCookie(order);
            return RedirectToAction("Index", "Cart");
        }

        public Order GetCartFromCookie()
        {
            // Retrieve the order from the cookie
            Request.Cookies.TryGetValue("Order", out string? cookie);
            Order order = cookie != null
                ? JsonSerializer.Deserialize<Order>(cookie) ?? new Order()
                : new Order();

            // Fetch ticket details for each order line
            var ticketDetails = new List<Ticket>();
            foreach (var orderLine in order.OrderLines)
            {
                // Fetch ticket from the API based on the ticketId
                var ticket = _ticketAPIConsumer.GetById(orderLine.TicketId);    
                if (ticket != null && !ticketDetails.Any(t => t.Id == ticket.TicketId))
                {
                    ticketDetails.Add(ticket);
                }
            }

            // Store ticket details in ViewBag so the view has access to them
            ViewBag.TicketDetails = ticketDetails;

            return order;
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
            order.OrderLines = new List<OrderLine>(); //Check om det virker nyt shit
            SaveCartToCookie(order);
            return View("Index", order);
        }

        public ActionResult Delete(int id, int quantity)
        {
            Order order = GetCartFromCookie();
            OrderLine existingOrderLine = order.OrderLines.FirstOrDefault(ol => ol.TicketId == id);
            if (existingOrderLine != null)
            {
                order.OrderLines.Remove(existingOrderLine);
            }
            SaveCartToCookie(order);
            return RedirectToAction("Index", "Cart");
        }
    }
}
