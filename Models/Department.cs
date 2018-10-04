using System;
using System.Collections.Generic;

namespace WebAPI.Models {
    public class Department {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}