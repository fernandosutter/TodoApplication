using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApplicationWebApi.Controllers
{
    public class TodoItemController : Controller
    {
        // GET: TodoItemController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TodoItemController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TodoItemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TodoItemController/Create
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

        // GET: TodoItemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TodoItemController/Edit/5
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

        // GET: TodoItemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TodoItemController/Delete/5
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
