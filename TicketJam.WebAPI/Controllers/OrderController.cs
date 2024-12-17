using Microsoft.AspNetCore.Mvc;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;
using TicketJam.WebAPI.DTOs;
using TicketJam.WebAPI.DTOs.Converters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketJam.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public IDAO<Order> _orderDAO;
        public IOrderDAO _orderDAO2;

        public OrderController(IDAO<Order> iDAO, IOrderDAO orderDAO)
        {
            _orderDAO = iDAO;
            _orderDAO2 = orderDAO;
        }

        /// <summary>
        /// Returns list of all orders
        /// </summary>
        /// <returns></returns>

        // GET: api/<OrderControllerAPI>
        [HttpGet]
        public ActionResult<IEnumerable<OrderDto>> GetAll()
        {
            return Ok(_orderDAO.Read().ToDtos());
        }

        /// <summary>
        /// Returns order matching ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public ActionResult<OrderDto> GetById(int id)
        {
            Order order = _orderDAO.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(order.ToDto());
            }
        }

        /// <summary>
        /// Creates an order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult<OrderDto> Post(OrderDto order)
        {
            Order orderDtoToConvert = _orderDAO.Create(order.FromDto());
            return Ok(orderDtoToConvert.ToDto());
        }

        /// <summary>
        /// Updates order given an order object
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public ActionResult Put(OrderDto order)
        {
            _orderDAO.Update(order.FromDto());
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }

        /// <summary>
        /// Deletes an order with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

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

        /// <summary>
        /// Gets all orders associated with customer id input
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>

        [HttpGet("orders/{customerId}/purchases")]
        public ActionResult<IEnumerable<OrderDto>> GetOrdersByCustomer(int customerId)
        {
            var orders = _orderDAO2.GetOrdersByCustomer(customerId);
            if (orders == null || !orders.Any())
            {
                return NotFound($"No orders found for customer with ID {customerId}");
            }
            return Ok(orders.ToDtos());

        }
    }
}
