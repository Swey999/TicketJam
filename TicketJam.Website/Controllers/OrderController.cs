using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketJam.Website.APIClient;
using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.Controllers
{
    public class OrderController : Controller
    {
        // GET: OrderController
        OrderAPIConsumer OrderAPIConsumer = new OrderAPIConsumer("https://localhost:7280/api/v1/OrderControllerAPI");
        

        public OrderController()
        {

        }


        public ActionResult Index()
        {

            return View(OrderAPIConsumer.GetAll());
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            //Maybe i should have Order in parameter (and then the order isnt in the database yet).
            //Order order = OrderAPIConsumer.GetById(id);
            var order = new Order();

            return View(order);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            try
            {
                // OrderAPIConsumer will save the order with associated order lines
                order.OrderNo = 20;
                OrderAPIConsumer.AddOrder(order);
                return Ok(); // Respond with 200 OK
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating order");
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
