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
        
        // GET: ToDo
        public ActionResult Index()
        {
            return View(toDoes.Where(x => !x.IsDone));
        }

        // GET: ToDo/Details/5
        public ActionResult Details(int id)
        {
            return View(toDoes.FirstOrDefault(x => x.Id == id));
        }

        // GET: ToDo/Create
        public ActionResult Create()
        {
            return View(new ToDoModel());
        }

        // POST: ToDo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDoModel toDoModel)
        {
            int lastId;

            if (toDoes != null && !toDoes.Any())
            {
                lastId = 1;
            }
            else
            {
                lastId = toDoes.Max(x => x.Id) + 1;
            }

            toDoModel.Id = lastId;
            toDoes.Add(toDoModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: ToDo/Edit/5
        public ActionResult Edit(int id)
        {
            return View(toDoes.FirstOrDefault(x => x.Id == id));
        }

        // POST: ToDo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ToDoModel toDoModels)
        {
            ToDoModel toDo = toDoes.FirstOrDefault(x => x.Id == id);

            toDo.Name = toDoModels.Name;
            toDo.Description = toDoModels.Description;

            return RedirectToAction(nameof(Index));
        }

        // GET: ToDo/Delete/5
        public ActionResult Delete(int id)
        {
            return View(toDoes.FirstOrDefault(x => x.Id == id));
        }

        // POST: ToDo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ToDoModel toDoModel)
        {
            ToDoModel toDo = toDoes.FirstOrDefault(x => x.Id == id);

            toDoes.Remove(toDo);

            return RedirectToAction(nameof(Index));
        }

        // GET: ToDo/Done/5
        public ActionResult Done(int id, ToDoModel toDoModel)
        {
            ToDoModel toDo = toDoes.FirstOrDefault(x => x.Id == id);

            toDo.IsDone = true;

            return RedirectToAction(nameof(Index));
        }
    }
}
