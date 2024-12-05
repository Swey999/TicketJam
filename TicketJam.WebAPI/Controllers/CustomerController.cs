using Microsoft.AspNetCore.Mvc;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;
using TicketJam.WebAPI.DTOs;
using TicketJam.WebAPI.DTOs.Converters;

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
        public ActionResult<CustomerDto> GetById(int id)
        {
            Customer customer = _customerDAO.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customer.ToDto());
            }
        }


        // POST api/<OrderControllerAPI>
        [HttpPost]
        public ActionResult<CustomerDto> Post(CustomerDto customer)
        {
            Customer customerDtoToConvert = _customerDAO.Create(customer.FromDto());
            return Ok(customerDtoToConvert.ToDto());
        }

        [HttpGet("by-email/{email}")]
        public ActionResult<CustomerDto> GetCustomerByEmail([FromRoute] string email)
        {
            Customer customer = new Customer();
            customer = _icustDAO.GetCustomerByEmail(email);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customer.ToDto());
            }
        }
    }
}
