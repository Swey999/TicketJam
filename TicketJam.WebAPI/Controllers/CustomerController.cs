using Microsoft.AspNetCore.Mvc;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;
using TicketJam.WebAPI.DTOs;

namespace TicketJam.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        public IDAO<Customer> _customerDAO;
        public ICustomerDAO _icustDAO;

        public CustomerController(IDAO<Customer> customerDAO, ICustomerDAO icustDAO)
        {
            _customerDAO = customerDAO;
            _icustDAO = icustDAO;
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetById(int id)
        {
            Customer customer = _customerDAO.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customer);
            }
        }


        // POST api/<OrderControllerAPI>
        [HttpPost]
        public ActionResult<Customer> Post(Customer customer)
        {
            _customerDAO.Create(customer);
            return Ok(customer);
        }

        [HttpGet("by-email/{email}")]
        public ActionResult<Customer> GetCustomerByEmail([FromRoute] string email)
        {
            Customer customer = new Customer();
            customer = _icustDAO.GetCustomerByEmail(email);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customer);
            }
        }



    }
}
