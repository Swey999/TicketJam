using Microsoft.AspNetCore.Mvc;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;
using TicketJam.WebAPI.DTOs;

namespace TicketJam.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerControllerAPI : Controller
    {
        public IDAO<Customer> _customerDAO;
        public CustomerControllerAPI(IDAO<Customer> customerDAO)
        {
            _customerDAO = customerDAO;
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



    }
}
