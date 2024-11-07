using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketJam.Website.APIClient;
using TicketJam.Website.APIClient.DTO;
using TicketJam.Website.APIClient.Stubs.OrderStubs;

namespace TicketJam.Website.Controllers
{
    public class OrderController : Controller
    {
        // GET: OrderController
        OrderAPIConsumer OrderAPIConsumer = new OrderAPIConsumer("https://localhost:7168/api/v1/OrderControllerAPI");
        OrderStub OrderStub;

        public OrderController(OrderStub orderStub)
        {
            OrderStub = orderStub;
        }

        
        public ActionResult Index()
        {
            
            return View(OrderStub.GetAll());
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            // Fetch event, venue, and order lines from stubs
            var order = new Order
            {
                OrderNo = 1002, // Set an example order number
                Customer = OrderStub.customerDogStub.GetById(1), //Fetch CustomerDog
                Event = OrderStub.eventStub.GetById(1), // Fetch event
                Venue = OrderStub.venueStub.GetById(1), // Fetch venue
                OrderLines = OrderStub.orderline.GetAll().ToList() // Fetch order lines
            };

            // Pass the fully populated order to the view
            return View(order);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            try
            {
                // Ensure OrderLines is initialized
                if (order.OrderLines == null)
                {
                    order.OrderLines = new List<OrderLine>();
                }

                // Save the order using the stub or service
                order.OrderNo = OrderStub.GetAll().Max(o => o.OrderNo) + 1;
                OrderStub.AddOrder(order);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
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
    }
}
