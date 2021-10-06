using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoLogic.Models;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private static IList<ToDoModel> toDoes = new List<ToDoModel>()
        {
            new ToDoModel(){ Id = 1, Name = "First test ToDo", Description = "Godzina 12:00", IsDone = false},
            new ToDoModel(){ Id = 2, Name = "Secound test ToDo", Description = "Godzina 12:00", IsDone = false}
        };
        
        // GET: ToDoController
        public ActionResult Index()
        {
            return View(toDoes);
        }

        // GET: ToDoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ToDoController/Create
        public ActionResult Create()
        {
            return View(new ToDoModel());
        }

        // POST: ToDoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDoModel toDoModel)
        {
            toDoModel.Id = toDoes.Count + 1;
            toDoes.Add(toDoModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: ToDoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ToDoController/Edit/5
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

        // GET: ToDoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ToDoController/Delete/5
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
