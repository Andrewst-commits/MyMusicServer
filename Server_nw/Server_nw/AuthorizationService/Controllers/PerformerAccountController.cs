using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.AuthorizationApplication.Controllers
{
    public class PerformerController : Controller
    {
        // GET: PerformerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PerformerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PerformerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PerformerController/Create
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

        // GET: PerformerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PerformerController/Edit/5
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

        // GET: PerformerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PerformerController/Delete/5
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
