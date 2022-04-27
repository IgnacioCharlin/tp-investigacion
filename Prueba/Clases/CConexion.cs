using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;


namespace Prueba.Clases
{
    class CConexion
    {
        static string servidor= "localhost";
        static string puerto= "27017";

        public static MongoClient cliente = new MongoClient($"mongodb://{servidor}:{puerto}");

        public MongoClient establecerConexion()
        {
            try
            {
                List<String> NombresBasesDeDatos = cliente.ListDatabaseNames().ToList();
                foreach(var db in NombresBasesDeDatos)
                {
                    Console.WriteLine($"Se conecto correctamente a : {db}");
                }
            }
            catch (MongoClientException e){
                Console.WriteLine("No se logro conectar a mongoDb , error"+e.ToString());
            }

            return cliente;
        }
    }
}
