using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevExpress.Xpo.AspNetMvcCoreDemo.Models;
using DevExpress.Xpo.Demo.Entities;

namespace DevExpress.Xpo.AspNetMvcCoreDemo.Controllers
{
    public class DataController : Controller
    {
        readonly UnitOfWork uow;

        public DataController(UnitOfWork uow)
        {
            this.uow = uow;
        }

        public IActionResult Index()
        {
            DataViewModel viewModel = new DataViewModel(uow);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(Guid id) 
        {
            var user = uow.GetObjectByKey<User>(id);
            if(user != null) {
                uow.Delete(user);
                uow.CommitChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(UserModel model)
        {
            if(model != null) {
                var newUser = new User(uow) {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email
                };
                uow.CommitChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
