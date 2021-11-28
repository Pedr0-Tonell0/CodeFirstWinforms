using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Contexto:DbContext
    {
        public Contexto():base("CadenaConexion")
        {

        }
        public DbSet<Producto> Productos { get; set; }
    }
}
