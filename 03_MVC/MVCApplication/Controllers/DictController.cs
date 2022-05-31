using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Controllers
{
    public class DictController : Controller
    {
        private Models.Phonebook _phonebook = new Models.Phonebook();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Telephones = _phonebook.GetAllOrdered();
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult AddSave(string record)
        {
            var args = record.Split(',');
            _phonebook.Insert(args[0], args[1].Trim());
            ViewBag.Telephones = _phonebook.GetAllOrdered();
            return Redirect("~/Dict/Index");
        }

        [HttpGet]
        [Route("/update/{id:int}")]
        public ActionResult Update(int id)
        {
            ViewBag.Telephones = _phonebook.Get(id);
            return View();
        }

        [HttpPost]
        public RedirectResult UpdateSave(int id, string record)
        {
            var args = record.Split(',');
            _phonebook.Update(id, args[0], args[1].Trim());
            ViewBag.Telephones = _phonebook.GetAllOrdered();
            return Redirect("~/Dict/Index");
        }

        [HttpGet]
        [Route("/delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            ViewBag.Telephones = _phonebook.Get(id);
            return View();
        }

        [HttpPost]
        public RedirectResult DeleteSave(int id)
        {
            _phonebook.Delete(id);
            ViewBag.Telephones = _phonebook.GetAllOrdered();
            return Redirect("~/Dict/Index");
        }
    }
}