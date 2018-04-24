using System;
using DevExpress.Xpo;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo.Demo.Entities;

namespace DevExpress.Xpo.AspNetMvcCoreDemo.Models
{
    public class DataViewModel
    {
        public List<UserModel> Users;
        public int TotalCount;

        public DataViewModel(UnitOfWork uow) {
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
}