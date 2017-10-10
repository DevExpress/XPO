using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DevExpress.Xpo.Demo.Core;
using DevExpress.Xpo.Demo.Entities;

namespace DevExpress.Xpo.Demo.Pages
{
    public class DataModel : PageModel {
        public List<UserModel> Users { get; set; }
        public int TotalCount { get; set; }
        public void OnGet() {
            using(var uow = XpoHelper.CreateUnitOfWork()) {
                Users = uow.Query<User>()
                    .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName)
                    .Select(u => new UserModel {
                        Oid = u.Oid,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Email = u.Email
                    }).ToList();
                TotalCount = uow.Query<User>().Count();
            }
        }
        [HttpPost]
        public IActionResult OnPostDelete(Guid id) {
            using(var uow = XpoHelper.CreateUnitOfWork()) {
                var user = uow.GetObjectByKey<User>(id);
                if(user != null) {
                    uow.Delete(user);
                    uow.CommitChanges();
                }
                return RedirectToPage();
            }
        }
        [HttpPost]
        public IActionResult OnPostCreate(UserModel model) {
            using(var uow = XpoHelper.CreateUnitOfWork()) {
                if(model != null) {
                    var newUser = new User(uow) {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email
                    };
                    uow.CommitChanges();
                }
                return RedirectToPage();
            }
        }
    }
    public class UserModel {
        public Guid Oid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}