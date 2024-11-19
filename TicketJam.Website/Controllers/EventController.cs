using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketJam.Website.APIClient;
using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.Controllers
{
    public class EventController : Controller
    {
        EventAPIConsumer EventAPIConsumer = new EventAPIConsumer("https://localhost:7280/api/v1/EventControllerAPI");
        SectionAPIConsumer _sectionAPIConsumer = new SectionAPIConsumer("https://localhost:7280/api/v1/SectionControllerAPI");

        // GET: EventController
        public ActionResult Index()
        {

            return View(EventAPIConsumer.GetAll());
        }


        // GET: EventController/Details/5
        public ActionResult Details(int id)
        {
            try
            {

                var eventDetails = EventAPIConsumer.GetById(id);


                int venueId = eventDetails.Id;
                var sectionDetails = new List<Section>();
                var sections = _sectionAPIConsumer.GetSectionsByVenue(venueId);

                foreach (var section in sections)
                {
                    sectionDetails.Add(section);
                }
           

                ViewBag.Sections = sectionDetails;

                return View(eventDetails);
                //return View(EventAPIConsumer.GetById(id));
            }
            catch (Exception ex)
            {
                // Optionally, log the exception here if logging is available.
                ViewBag.ErrorMessage = $"Error fetching event details: {ex.Message}";
                return View("Error");
            }
        }

        // GET: EventController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventController/Create
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

        // GET: EventController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EventController/Edit/5
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

        // GET: EventController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EventController/Delete/5
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