using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo.Demo.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DevExpress.Xpo.Demo.Core {
    public static class XpoDemoDataHelper {
        static readonly string[][] demoData = new string[][]{
            new string[] { "Amelia", "Harper", "ameliah@dx-email.com" },
            new string[] { "Lincoln", "Bartlett", "lincolnb@dx-email.com" },
            new string[] { "Samantha", "Bright", "samanthab@dx-email.com" },
            new string[] { "David", "Jones", "davidj@dx-email.com" },
            new string[] { "Kelly", "Rodriguez", "kellyr@dx-email.com" },
            new string[] { "Bart", "Arnaz", "barta@dx-email.com" },
            new string[] { "Jennifer", "Hobbs", "jennyh@dx-email.com" },
            new string[] { "Stu", "Pizaro", "stu@dx-email.com" },
            new string[] { "Bartolomeo", "Pizaro", "bartop@dx-email.com" },
        };
        public static IApplicationBuilder UseXpoDemoData(this IApplicationBuilder app) {
            using(var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()) {
                UnitOfWork uow = scope.ServiceProvider.GetService<UnitOfWork>();
                if(!uow.Query<User>().Any()) {
                    foreach(var row in demoData) {
                        var newUser = new User(uow) {
                            FirstName = row[0],
                            LastName = row[1],
                            Email = row[2]
                        };
                    }
                    uow.CommitChanges();
                }
            }
            return app;
        }
    }
}