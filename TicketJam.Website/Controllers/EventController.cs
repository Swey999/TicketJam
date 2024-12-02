using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketJam.Website.APIClient;
using System.Text.Json;
using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.Controllers
{
    public class EventController : Controller
    {
        EventAPIConsumer EventAPIConsumer = new EventAPIConsumer("https://localhost:7280/api/v1/Event");
        SectionAPIConsumer _sectionAPIConsumer = new SectionAPIConsumer("https://localhost:7280/api/v1/Section");
        TicketAPIConsumer _ticketAPIConsumer = new TicketAPIConsumer("https://localhost:7280/api/v1/Ticket");

        // GET: EventController
        public ActionResult Index()
        {

            return View(EventAPIConsumer.GetAll());
        }


        // GET: EventController/Details/5
        public ActionResult Details(int id)
        {
            try
            {

                var eventDetails = EventAPIConsumer.GetById(id);

                return View(eventDetails);
                //return View(EventAPIConsumer.GetById(id));
            }
            catch (Exception ex)
            {
                // Optionally, log the exception here if logging is available.
                ViewBag.ErrorMessage = $"Error fetching event details: {ex.Message}";
                return View("Error");
            }
        }

        // GET: EventController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Add(int id, int quantity)
        {
            try
            {
                Ticket ticket = _ticketAPIConsumer.GetTicketWithSectionAndEvent(id); // Fetch the ticket
                Order order = GetCartFromCookie(); // Get the current cart

                // Validate that the ticket's event matches the event in the cart
                if (!IsSameEvent(order, ticket))
                {
                    return Ok(new { success = false, message = "Cannot buy tickets from multiple events." });
                }

                // Add or update the order line
                if (!TryAddOrUpdateOrderLine(order, ticket, quantity))
                {
                    return Ok(new { success = false, message = "Too many tickets per person." });
                }

                SaveCartToCookie(order); // Save the updated cart
                return Ok(new { success = true, message = "Item added to basket." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        private bool IsSameEvent(Order order, Ticket ticket)
        {
            if (!order.OrderLines.Any()) return true; // No tickets in cart, any event is valid

            // Get the EventId of the first ticket in the cart
            int existingEventId = _ticketAPIConsumer.GetTicketWithSectionAndEvent(order.OrderLines.First().TicketId).Event.Id;

            // Check if the ticket's event matches the existing event
            return ticket.Event.Id == existingEventId;
        }

        private bool TryAddOrUpdateOrderLine(Order order, Ticket ticket, int quantity)
        {
            // Find the existing order line for this ticket
            OrderLine existingOrderLine = order.OrderLines.FirstOrDefault(ol => ol.TicketId == ticket.Id);

            if (existingOrderLine != null)
            {
                // Check if the new total quantity exceeds MaxAmount
                if (existingOrderLine.Quantity + quantity > ticket.MaxAmount)
                {
                    return false; // Adding this quantity exceeds the max amount
                }

                existingOrderLine.Quantity += quantity;

                // Remove the order line if quantity becomes zero or less
                if (existingOrderLine.Quantity <= 0)
                {
                    order.OrderLines.Remove(existingOrderLine);
                }
            }
            else
            {
                // Check if the new quantity exceeds MaxAmount
                if (quantity > ticket.MaxAmount)
                {
                    return false; // Adding this quantity exceeds the max amount
                }

                // Add a new order line
                OrderLine newOrderLine = new OrderLine
                {
                    TicketId = ticket.Id,
                    Quantity = quantity
                };
                order.OrderLines.Add(newOrderLine);
            }

            return true;
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
            cookieOptions.Expires = DateTime.Now.AddMinutes(10);
            cookieOptions.Path = "/";
            Response.Cookies.Append("Order", JsonSerializer.Serialize(order), cookieOptions);
        }
    }
}