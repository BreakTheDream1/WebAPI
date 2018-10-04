using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {

        private ApplicationContext _db;

        public UserController(ApplicationContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers() {
            var userName = Request.HttpContext.User.Identity.Name;
            //_db.Users.Include(u => u.Department);
            //var users = _db.Users.Where(u => u.DepartmentId == _db.Users.FirstOrDefault(us => us.Login == user).DepartmentId).ToList();
            var users = _db.Users.Where(user => user.Department.Users.Any(u => u.Login == userName)).ToList();

            return users;

        } 
    }
}
