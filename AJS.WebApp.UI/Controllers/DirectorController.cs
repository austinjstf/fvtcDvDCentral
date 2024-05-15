using AJS.DVDCentral.BL;
using AJS.DVDCentral.BL.Models;
using AJS.DVDCentral.PL2.Data;
using AJS.WebApp.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Xml.Linq;

namespace AJS.WebApp.UI
{
    public class DirectorController : Controller
    {
        private readonly DbContextOptions<DVDCentralEntities> options;
        private readonly ILogger<DirectorController> logger;

        public DirectorController(ILogger<DirectorController> logger, DbContextOptions<DVDCentralEntities> options)
        {
            this.options = options;
            this.logger = logger;
            logger.LogWarning("Movie Controller Check");
        }


        // GET: DirectorController

        [AllowAnonymous]

        public ActionResult Index()
        {
            ViewBag.Title = "Directors";
            return View(new DirectorManager(options).Load());
        }
        [AllowAnonymous]

        // GET: DirectorController/Details/5
        public ActionResult Details(Guid id)
        {
            var item = new DirectorManager(options).LoadById(id);
            ViewBag.Title = "Details";
            return View(item);
        }

        [Authorize]

        // GET: DirectorController/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create a Director";
            
                return View();
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
        }
        [Authorize]

        // POST: DirectorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Director director, bool rollback = false)
        {
            try
            {
                int result = new DirectorManager(options).Insert(director);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Authorize]

        // GET: DirectorController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var item = new DirectorManager(options).LoadById(id);
            ViewBag.Title = "Edit " + item.FullName;
      
                return View(item);
     
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
        }
        [Authorize]

        // POST: DirectorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, Director director, bool rollback = false)
        {
            try
            {
                int result =  new DirectorManager(options).Update(director, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(director);
            }
        }
        [Authorize]

        // GET: DirectorController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var item = new DirectorManager(options).LoadById(id);
            ViewBag.Title = "Delete " + item.FullName;
            return View(item);
        }
        [Authorize]

        // POST: DirectorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id, Director director, bool rollback = false)
        {
            try
            {
                int result = new DirectorManager(options).Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(director);
            }
        }
    }
}
