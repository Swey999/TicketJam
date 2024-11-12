using Microsoft.AspNetCore.Mvc;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;
using TicketJam.WebAPI.DTOs;

namespace TicketJam.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerControllerAPI : Controller
    {
        public IDAO<Customer> _customerDAO;
        private IConfiguration _configuration;
        public CustomerControllerAPI(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = _configuration.GetConnectionString("DBConnectionString");
            _customerDAO = new CustomerDAO(connectionString);

        }


        //[HttpPost]
        //public ActionResult<Customer> Create(Customer customer)
        //{
        //    customer = _customerDAO.Create(customer);

        //    return Created($"{baseURL}/{customer.Id}", customer);
        //}

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



    }
}
