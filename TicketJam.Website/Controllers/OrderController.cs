using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Security.Claims;
using System.Text.Json;
using TicketJam.Website.APIClient;
using TicketJam.Website.APIClient.DTO;
using TicketJam.Website.Models;

namespace TicketJam.Website.Controllers
{
    public class OrderController : Controller
    {
        // GET: OrderController
        OrderAPIConsumer OrderAPIConsumer = new OrderAPIConsumer("https://localhost:7280/api/v1/OrderControllerAPI");
        CustomerAPIConsumer customerAPIConsumer = new CustomerAPIConsumer("https://localhost:7280/api/v1/CustomerControllerAPI");
        CartController cartController = new CartController();
        TicketAPIConsumer _ticketAPIConsumer = new TicketAPIConsumer("https://localhost:7280/api/v1/TicketControllerAPI");



        public OrderController()
        {

        }


        public ActionResult Index()
        {

            return View();
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email); // Get email from claims

            if (string.IsNullOrEmpty(userEmail))
            {
                throw new Exception("User email not found. Please ensure the user is logged in and authenticated.");
            }

            Customer customer = customerAPIConsumer.GetCustomerByEmail(userEmail);

            Request.Cookies.TryGetValue("Order", out string? cookie);
            Order order = JsonSerializer.Deserialize<Order>(cookie) ?? new Order();

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
            ViewBag.Customer = customer;
            ViewBag.CustomerAddress = customer.Address;


            if (customer == null)
            {
                return Redirect("/Customer/Create");
            }
            return View(order);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            try
            {
                //Find Customer from login cookie and Email.
                var userEmail = User.FindFirstValue(ClaimTypes.Email); // Get email from claims

                if (string.IsNullOrEmpty(userEmail))
                {
                    throw new Exception("User email not found. Please ensure the user is logged in and authenticated.");
                }

                Customer customer = customerAPIConsumer.GetCustomerByEmail(userEmail);
                if (customer == null)
                {
                    throw new Exception("Customer not found in the system.");
                }

                //Find Order Cookie
                Request.Cookies.TryGetValue("Order", out string? cookie);
                order = JsonSerializer.Deserialize<Order>(cookie) ?? new Order();
                order.OrderNo = 1492;
                order.CustomerId = customer.Id;

                //Count ticketAmount on Section down and ticketamount on Event.
                //TODO: ADD IFSTATEMENT SO THAT THE TICKETS ONLY GETS REMOVED IF THE ORDER TRANSACTION SUCCEDS.
                OrderAPIConsumer.Add(order);

                //foreach(var orderline in order.OrderLines)
                //{
                //    Ticket ticket = _ticketAPIConsumer.GetTicketWithSectionAndEvent(orderline.TicketId);

                //    ticket.Section.TicketAmount -= orderline.Quantity;
                //    ticket.Event.TotalAmount -= orderline.Quantity;
                //    _ticketAPIConsumer.Update(ticket);
                //}



                return View(order);
            }
            catch
            {
                return View(order);
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
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

        public ActionResult Purchases()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email); // Get email from claims

            try
            {
                Customer customer = customerAPIConsumer.GetCustomerByEmail(userEmail);

                if (customer == null)
                {
                    return Redirect("/Customer/Create");
                }

                var orders = OrderAPIConsumer.GetOrdersByCustomer(customer.Id);

                // Fetch ticket details for each order line
                var ticketDetails = new List<Ticket>();
                foreach (var order in orders)
                {
                    foreach(var orderLine in order.OrderLines)
                    {
                    // Fetch ticket from the API based on the ticketId
                    var ticket = _ticketAPIConsumer.TicketWithSectionAndEvent(orderLine.TicketId);
                    if (ticket != null && !ticketDetails.Any(t => t.Id == ticket.TicketId))
                    {
                        ticketDetails.Add(ticket);
                    }

                    }
                }
                // Store ticket details in ViewBag so the view has access to them
                ViewBag.TicketDetails = ticketDetails;


                return View("Purchases", orders);
            }
            catch 
            {
                return View();
            }
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
            return RedirectToAction("Create", "Order");
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
        public ActionResult DeleteOrderLine(int id, int quantity)
        {
            Order order = GetCartFromCookie();
            OrderLine existingOrderLine = order.OrderLines.FirstOrDefault(ol => ol.TicketId == id);
            if (existingOrderLine != null)
            {
                order.OrderLines.Remove(existingOrderLine);
            }
            SaveCartToCookie(order);
            return RedirectToAction("Create", "Order");
        }


    }
}