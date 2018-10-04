using System.Linq;
using WebAPI.Models;

namespace WebAPI {
    public static class SampleData {
        public static void Initialize(ApplicationContext context) {
            if(!context.Departments.Any()) {
                context.Departments.AddRange(
                    new Department {
                        Name = ".Net"
                    }, 
                    new Department {
                        Name = "Backend"
                    },
                    new Department {
                        Name = "Frontend"
                    }
                );
                context.SaveChanges();
            }

            var depId = context.Departments.FirstOrDefault(d => d.Name == ".Net");

            if(!context.Users.Any()) {
                context.Users.AddRange(
                    new User {
                        Login = "GMCS/knikiforov",
                        DepartmentId = depId.Id
                    },
                    new User {
                        Login = "GMCS/nantipkin",
                        DepartmentId = depId.Id
                    },
                    new User {
                        Login = "GMCS/tsalomatina",
                        DepartmentId = depId.Id
                    },
                    new User {
                        Login = "GMCS/abartoshevich",
                        DepartmentId = depId.Id
                    }
                );
                context.SaveChanges();
            }
        }
    }
}