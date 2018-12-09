using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EjercicioClavesABM.Models
{
    public class EjercicioClavesABMContext : DbContext
    {
        public EjercicioClavesABMContext() : base("DefaultConnection")
        {

        }

        public DbSet<Novedad> Novedades { get; set; }
    }
}