using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace usersApp
{
    internal class AppCon : DbContext
    {
        public DbSet<User> Users { get; set; } // list with User class elements

        public AppCon() : base("DefaultConnection") { }
    }
}
