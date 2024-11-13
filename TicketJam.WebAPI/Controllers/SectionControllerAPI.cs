using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;
using TicketJam.WebAPI.DTOs;

namespace TicketJam.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionControllerAPI : Controller
    {
        public IDAO<Section> _SectionDAO;
        private IConfiguration _configuration;
        public SectionControllerAPI(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = _configuration.GetConnectionString("DBConnectionString");
            _SectionDAO = new SectionDAO(connectionString);

        }

        // GET: SectionControllerAPI
        public ActionResult<IEnumerable<Section>> GetAll()
        {
            return Ok(_SectionDAO.Read());
        }

        // GET: SectionControllerAPI/Details/5
        public ActionResult<Section> GetById(int id)
        {
            Section section = _SectionDAO.GetById(id);
            if (section == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(section);
            }
        }

        // GET: SectionControllerAPI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SectionControllerAPI/Create
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

        // GET: SectionControllerAPI/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SectionControllerAPI/Edit/5
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

        // GET: SectionControllerAPI/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SectionControllerAPI/Delete/5
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
