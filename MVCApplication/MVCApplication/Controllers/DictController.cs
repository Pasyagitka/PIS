using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Controllers
{
    public class DictController : Controller
    {
        private Models.Phonebook m_TelephoneDictionary = new Models.Phonebook();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Telephones = m_TelephoneDictionary.GetAllOrdered();
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
            m_TelephoneDictionary.Insert(args[0], args[1].Trim());
            ViewBag.Telephones = m_TelephoneDictionary.GetAllOrdered();
            return Redirect("~/Dict/Index");
        }

        [HttpGet]
        [Route("/update/{id:int}")]
        public ActionResult Update(int id)
        {
            ViewBag.Telephones = m_TelephoneDictionary.Get(id);
            return View();
        }

        [HttpPost]
        public RedirectResult UpdateSave(int id, string record)
        {
            var args = record.Split(',');
            m_TelephoneDictionary.Update(id, args[0], args[1].Trim());
            ViewBag.Telephones = m_TelephoneDictionary.GetAllOrdered();
            return Redirect("~/Dict/Index");
        }

        [HttpGet]
        [Route("/delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            ViewBag.Telephones = m_TelephoneDictionary.Get(id);
            return View();
        }

        [HttpPost]
        public RedirectResult DeleteSave(int id)
        {
            m_TelephoneDictionary.Delete(id);
            ViewBag.Telephones = m_TelephoneDictionary.GetAllOrdered();
            return Redirect("~/Dict/Index");
        }
    }
}