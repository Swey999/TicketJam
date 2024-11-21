using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;
using TicketJam.Website.APIClient;
using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.Controllers
{
    public class CustomerController : Controller
    {
        CustomerAPIConsumer _customerAPIConsumer = new CustomerAPIConsumer("https://localhost:7280/api/v1/CustomerControllerAPI");

        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(APIClient.DTO.Customer customer)
        {
            try
            {
                customer.Password = "sejtpassword";
                customer.CustomerNo = 111;
                //customer.Address = ; 
                _customerAPIConsumer.Add(customer);
                return Redirect("/Order/Create");
            }
            catch
            {
                return View(customer);
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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
