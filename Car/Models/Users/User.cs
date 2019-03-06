using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDestiny.Models
{
    public class User
    {
        public User(string name, string password, string rights)
        {
            Password = password;
            Name = name;
            Rights = rights;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Rights{ get; set; }

    }

}