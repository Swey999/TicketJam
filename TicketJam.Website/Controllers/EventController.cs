using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketJam.Website.APIClient;
using System.Text.Json;
using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.Controllers
{
    public class EventController : Controller
    {
        EventAPIConsumer EventAPIConsumer = new EventAPIConsumer("https://localhost:7280/api/v1/EventControllerAPI");
        SectionAPIConsumer _sectionAPIConsumer = new SectionAPIConsumer("https://localhost:7280/api/v1/SectionControllerAPI");
        TicketAPIConsumer _ticketAPIConsumer = new TicketAPIConsumer("https://localhost:7280/api/v1/TicketControllerAPI");

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


                int venueId = eventDetails.Id;
                var sectionDetails = new List<Section>();
                var sections = _sectionAPIConsumer.GetSectionsByVenue(venueId);

                foreach (var section in sections)
                {
                    sectionDetails.Add(section);
                }
           

                ViewBag.Sections = sectionDetails;

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
                return Ok(new { success = true, message = "Item added to basket" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
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