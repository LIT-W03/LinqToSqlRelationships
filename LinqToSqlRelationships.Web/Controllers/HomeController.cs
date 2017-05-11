using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinqToSqlRelationships.Data;
using LinqToSqlRelationships.Web.Models;

namespace LinqToSqlRelationships.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var vm = new IndexViewModel();
            var repo = new PersonRepository(Properties.Settings.Default.ConStr);
            vm.People = repo.GetPeople();
            return View(vm);
        }

        public ActionResult NewPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPerson(Person person)
        {
            var repo = new PersonRepository(Properties.Settings.Default.ConStr);
            repo.AddPerson(person);
            return RedirectToAction("Index");
        }

        public ActionResult NewCar(int personId)
        {
            var vm = new AddCarViewModel();
            var repo = new PersonRepository(Properties.Settings.Default.ConStr);
            vm.Person = repo.GetPerson(personId);
            return View(vm);
        }

        [HttpPost]
        public ActionResult AddCar(Car car)
        {
            var repo = new PersonRepository(Properties.Settings.Default.ConStr);
            repo.AddCar(car);
            return RedirectToAction("Index");
        }
    }
}