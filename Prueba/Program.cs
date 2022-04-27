/*using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Prueba.Model
{
    internal class Program { 
        static void Main(string[] args)
        {
            Clases.CConexion conexion= new Clases.CConexion();
            conexion.establecerConexion();
        }
    }
}
*/
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Prueba.Model
{
    internal class Program
    {

        internal enum ConnectionType
        {
            MongoDb
        }


        static async Task Main(string[] args)
        {

            var dbContextOptions = GetDbContextOption().Options; 

            var Users = GetUsuarios();
            
            using(var context = new UserDbContext(dbContextOptions))
            {
                await context.Usuarios.AddRangeAsync(Users);
                await context.SaveChangesAsync();
            
                if(await context.Usuarios.AnyAsync())
                {
                    var usuariosCount = await context.Usuarios.CountAsync();
                    Console.WriteLine($"Found {usuariosCount} in Database");

                    var julio = context.Usuarios.FirstOrDefaultAsync();
                }
            }
        }

        private static DbContextOptionsBuilder GetDbContextOption()
        {
            
                    var mongoCliente = GetMongoClient();
                    return new DbContextOptionsBuilder()
                        .UseMongoDb(mongoCliente);
               
        }

        private static MongoClient GetMongoClient()
        {
            Clases.CConexion conexion = new Clases.CConexion();
            return conexion.establecerConexion();
        }

        private static IEnumerable<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            Usuario usuario1 = new Usuario
            {
                Nombre = "Federico",
                Apellido = "Gonzales",
                Sexo = "Masculino"
            };

            Usuario usuario2 = new Usuario
            {
                Nombre = "Rodrigo",
                Apellido = "Perez",
                Sexo = "Masculino"
            };

            usuarios.Add(usuario1);

            usuarios.Add(usuario2);

            return usuarios;
        }
    }
}
