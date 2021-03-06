using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoCommon.Entities;
using ToDoLogic.Models;
using ToDoLogic.Services;

namespace ToDo.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoService _toDoService;

        public ToDoController(ToDoService toDoService)
        {
            _toDoService = toDoService;
        }
        
        // GET: ToDo
        public ActionResult Index()
        {
            return View(_toDoService.GetNotDone());
        }

        // GET: ToDo/Details/5
        public ActionResult Details(int id)
        {
            return View(_toDoService.Details(id));
        }

        // GET: ToDo/Create
        public ActionResult Create()
        {
            return View(new ToDoDb());
        }

        // POST: ToDo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDoDto dto)
        {
            _toDoService.Create(dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: ToDo/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_toDoService.Edit(id));
        }

        // POST: ToDo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ToDoDto dto)
        {
            _toDoService.Edit(id, dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: ToDo/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_toDoService.Delete(id));
        }

        // POST: ToDo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ToDoDto dto)
        {
            _toDoService.Delete(dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: ToDo/Done/5
        public ActionResult Done(int id)
        {
            _toDoService.Done(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
