using System;
using System.Collections.Generic;
using System.Text;

namespace RaneenProject.Models
{
    public class Users
    {
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public List<Product> Cart { get; set; }
        public List<Product> Wishlist { get; set; }

    }
}
