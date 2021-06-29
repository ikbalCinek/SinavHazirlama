using DataAccess.Concrete;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class ExamController : Controller
    {

        private readonly ExamContext _context;
        ExamDal _examDal;
        AdminDal _adminDal;
        public ExamController(ExamContext examContext)
        {
            _context = examContext;
            _examDal = new ExamDal(examContext);
            _adminDal = new AdminDal(examContext);

        }

        [HttpGet]
        public ActionResult CreateExam(int id)
        {
            //Exam exam = _examDal.GetByID(id);
            //exam.AdminId =int.Parse(Request.Cookies["id"]);
            //exam.Admin = _adminDal.GetByID(int.Parse(Request.Cookies["id"]));

            Exam exam = _examDal.GetByID(id);
            ExamDto examDto = new ExamDto();
            examDto.Title = exam.Title;
            examDto.Content = exam.Content;

           
            return View(examDto);

        }


        [HttpPost]
        public ActionResult CreateExam(Exam exam)
        {
            if (!string.IsNullOrEmpty(Request.Cookies["id"]))
            {
              
                exam.AdminId = int.Parse(Request.Cookies["id"]);
                exam.IsActive = true;
                
                _examDal.Add(exam);
                return RedirectToAction("Index", "Home");
            }
            else return RedirectToAction("Index", "Home"); //todo: chechk ayrım yap
        }


        // GET: ExamController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ExamController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExamController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExamController/Create
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

        // GET: ExamController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExamController/Edit/5
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

        // GET: ExamController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExamController/Delete/5
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
