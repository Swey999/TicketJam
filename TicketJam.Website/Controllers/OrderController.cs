﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Text.Json;
using TicketJam.Website.APIClient;
using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.Controllers
{
    public class OrderController : Controller
    {
        // GET: OrderController
        OrderAPIConsumer OrderAPIConsumer = new OrderAPIConsumer("https://localhost:7280/api/v1/OrderControllerAPI");
        CartController cartController = new CartController();


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
            Request.Cookies.TryGetValue("Order", out string? cookie);
            Order order = JsonSerializer.Deserialize<Order>(cookie) ?? new Order();

            return View(order);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order) //SLET IFORMCOLLECTION !!!!!
        {
            try
            {
                Request.Cookies.TryGetValue("Order", out string? cookie);
                order = JsonSerializer.Deserialize<Order>(cookie) ?? new Order();
                order.OrderNo = 1292;

                CustomerDTO Customer = new CustomerDTO
                {
                    id = 1,
                    FirstName = "Nicolaj",
                    LastName = "Lort",
                    PhoneNo = "123323",
                    Email = "nil",
                    CustomerNo = 1,
                    Password = "1232"
                };

                order.Customer = Customer;
                OrderAPIConsumer.AddOrder(order);
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
    }
}