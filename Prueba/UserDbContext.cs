using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Prueba.Model
{
    internal class UserDbContext:DbContext
    {
        //Contructor
        public UserDbContext(DbContextOptions options) : base(options) { }


        public DbSet<Usuario> Usuarios { get; set; }
        
    }
}
