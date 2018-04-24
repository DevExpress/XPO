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
    }
}