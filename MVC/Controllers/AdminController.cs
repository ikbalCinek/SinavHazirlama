using DataAccess.Concrete;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using System.Xml;
using HtmlAgilityPack;

namespace MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly ExamContext _context;

        AdminDal _adminDal;
        ExamDal _examDal;
        public AdminController(ExamContext context)
        {
            _context = context;
            _adminDal = new AdminDal(context);
            _examDal = new ExamDal(context);
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View(new Admin());
        }

        [HttpPost]

        public ActionResult LogIn(Admin admin)
        {
            if (_adminDal.CanLogin(admin))
            {
               Admin newAdmin=  _adminDal.Get(a=>a.UserName==admin.UserName);
                AddCookie(newAdmin);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("GirisHata", "Bilgileri kontrol ediniz."); //todo:check
            return View(admin);
        }


        private void AddCookie(Admin admin)
        {

            if ( string.IsNullOrEmpty(Request.Cookies["id"]))
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddMinutes(40);
               
                Response.Cookies.Append("id",  admin.Id.ToString(), options);
            }
        }

        public ActionResult Show()
        {
            List<Exam> exams = new List<Exam>();
            IEnumerable<Exam> list = _examDal.GetLatestFivePosts();
            foreach (var item in list)
            {
                Exam exam = _examDal.GetPost(item);
                exam.Admin = _adminDal.GetByID(int.Parse(Request.Cookies["id"]));
                exam.AdminId = int.Parse(Request.Cookies["id"]);

                _examDal.Add(exam);
                exams.Add(exam);
            }
            return View(exams);
        }



       



        //public static IEnumerable<FeedItem> GetLatestFivePosts()
        //{
        //    var reader = XmlReader.Create("https://sibeeshpassion.com/feed/");
        //    var feed = SyndicationFeed.Load(reader);
        //    reader.Close();
        //    return (from itm in feed.Items
        //            select new FeedItem
        //            {
        //                Title = itm.Title.Text,
        //                Link = itm.Id
        //            }).ToList().Take(5);
        //}

        //public class FeedItem
        //{
        //    public string Title
        //    {
        //        get;
        //        set;
        //    }
        //    public string Link
        //    {
        //        get;
        //        set;
        //    }
        //}






        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
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

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
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

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
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
