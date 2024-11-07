using Microsoft.AspNetCore.Mvc;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;

namespace TicketJam.WebAPI.Controllers
{
    [ApiController]
    [Route(baseURL)]
    public class CustomersController : Controller
    {
        const string baseURL = "api/v1/[controller]";
        private IDao<Customer> _customerDao;

        public CustomersController(IDao<Customer> customerDao)
        {
            _customerDao = customerDao;
        }


        [HttpPost]
        public ActionResult<Customer> Create(Customer customer)
        {
            customer = _customerDao.Create(customer);

            return Created($"{baseURL}/{customer.Id}", customer);
        }


    }
}
