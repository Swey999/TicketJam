﻿using Microsoft.AspNetCore.Mvc;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketJam.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderControllerAPI : ControllerBase
    {
        public IDAO<Order> _orderDAO;
        private IConfiguration _configuration;
        public OrderControllerAPI(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = _configuration.GetConnectionString("DBConnectionString");
            _orderDAO = new OrderDAO(connectionString);

        }

        // GET: api/<OrderControllerAPI>
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAll()
        {
            return Ok(_orderDAO.Read());
        }

        // GET api/<OrderControllerAPI>/5
        [HttpGet("{id}")]
        public ActionResult<Order> GetById(int id)
        {
            Order order = _orderDAO.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(order);
            }
        }

        // POST api/<OrderControllerAPI>
        [HttpPost]
        public ActionResult<Order> Post(Order Order)
        {
            _orderDAO.Create(Order);
            return Ok(Order);
        }

        // PUT api/<OrderControllerAPI>/5
        [HttpPut("{id}")]
        public ActionResult Put(Order order)
        {
            _orderDAO.Update(order);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }

        // DELETE api/<OrderControllerAPI>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!_orderDAO.Delete(id))
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }
    }
}