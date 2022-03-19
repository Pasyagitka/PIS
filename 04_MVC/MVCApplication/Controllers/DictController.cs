using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Controllers
{
    public class DictController : Controller
    {
        private Models.Phonebook _telephoneDictionary = new Models.Phonebook();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Telephones = _telephoneDictionary.GetAllOrdered();
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult AddSave(string record, string phone)
        {
            string name = record ?? "default";
            _telephoneDictionary.Insert(name, phone);
            ViewBag.Telephones = _telephoneDictionary.GetAllOrdered();
            return Redirect("~/Dict/Index");
        }

        [HttpGet]
        [Route("/update/{id:int}")]
        public ActionResult Update(int id)
        {
            ViewBag.Telephones = _telephoneDictionary.Get(id);
            return View();
        }

        [HttpPost]
        public RedirectResult UpdateSave(int id, string record, string phone)
        {
            _telephoneDictionary.Update(id, record ?? "default", phone);
            ViewBag.Telephones = _telephoneDictionary.GetAllOrdered();
            return Redirect("~/Dict/Index");
        }

        [HttpGet]
        [Route("/delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            ViewBag.Telephones = _telephoneDictionary.Get(id);
            return View();
        }

        [HttpPost]
        public RedirectResult DeleteSave(int id)
        {
            _telephoneDictionary.Delete(id);
            ViewBag.Telephones = _telephoneDictionary.GetAllOrdered();
            return Redirect("~/Dict/Index");
        }
    }
}