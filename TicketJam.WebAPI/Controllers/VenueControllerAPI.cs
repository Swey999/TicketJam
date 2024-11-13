using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;
using TicketJam.WebAPI.DTOs;

namespace TicketJam.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueControllerAPI : Controller
    {
        public IDAO<Venue> _VenueDAO;
        private IConfiguration _configuration;
        public VenueControllerAPI(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = _configuration.GetConnectionString("DBConnectionString");
            _VenueDAO = new VenueDAO(connectionString);

        }
        // GET: VenueControllerAPI
        public ActionResult<IEnumerable<Venue>> GetAll()
        {
            return Ok(_VenueDAO.Read());
        }

        // GET: VenueControllerAPI/Details/5
        public ActionResult<Venue> GetById(int id)
        {
            Venue venue = _VenueDAO.GetById(id);
            if (venue == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(venue);
            }
        }

        // GET: VenueControllerAPI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VenueControllerAPI/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: VenueControllerAPI/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VenueControllerAPI/Edit/5
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

        // GET: VenueControllerAPI/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VenueControllerAPI/Delete/5
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
