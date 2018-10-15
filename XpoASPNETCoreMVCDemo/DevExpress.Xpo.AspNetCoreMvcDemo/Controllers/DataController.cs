using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevExpress.Xpo.AspNetCoreMvcDemo.Models;
using DevExpress.Xpo.Demo.Entities;

namespace DevExpress.Xpo.AspNetCoreMvcDemo.Controllers {
    public class DataController : Controller {
        readonly UnitOfWork uow;

        public DataController(UnitOfWork uow) {
            this.uow = uow;
        }

        public async Task<IActionResult> Index() {
            var users = await uow.Query<User>()
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new UserModel {
                    Oid = u.Oid,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email
                }).ToListAsync();

            int totalCount = await uow.Query<User>().CountAsync();

            var viewModel = new DataViewModel() {
                Users = users,
                TotalCount = totalCount
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id) {
            var user = await uow.GetObjectByKeyAsync<User>(id);
            if(user != null) {
                uow.Delete(user);
                await uow.CommitChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserModel model) {
            if(model != null) {
                var newUser = new User(uow) {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email
                };
                await uow.CommitChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
