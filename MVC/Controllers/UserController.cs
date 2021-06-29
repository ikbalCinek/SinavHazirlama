using DataAccess.Concrete;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ExamContext _context;
        UserDal _userDal;
        ExamDal _examDal;
        public UserController(ExamContext context)
        {
            _context = context;
            _userDal = new UserDal(context);
            _examDal = new ExamDal(context);
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View(new User());
        }

        [HttpPost]

        public ActionResult LogIn(User user)
        {
            if (_userDal.CanLogin(user))
            {
                User newUser = _userDal.Get(a => a.UserName == user.UserName);
                AddCookie(newUser);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("GirisHata", "Bilgileri kontrol ediniz."); //todo:check
            return View(user);
        }

        private void AddCookie(User  user)
        {

            if (string.IsNullOrEmpty(Request.Cookies["id"]))
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddMinutes(40);

                Response.Cookies.Append("id", user.Id.ToString(), options);
            }
        }


        // GET: UserController
        public ActionResult GetAllExams()
        {
            if (string.IsNullOrEmpty(Request.Cookies["id"]))
            {
                IEnumerable<Exam> exams = _examDal.GetAll(a => a.IsActive);

                return View(exams);
            }
            return RedirectToAction("Index","Home");
        }



        public ActionResult ShowExamForUser(int id)
        {
            Exam exam = _examDal.GetByID(id);
            return View(exam);

        }



        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
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

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
