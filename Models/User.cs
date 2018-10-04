using System;

namespace WebAPI.Models {
    public class User {
        public int Id { get; set; }
        public string Login { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}