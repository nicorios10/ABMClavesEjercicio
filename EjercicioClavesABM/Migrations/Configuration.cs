namespace EjercicioClavesABM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EjercicioClavesABM.Models.EjercicioClavesABMContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "EjercicioClavesABM.Models.EjercicioClavesABMContext";
        }

        protected override void Seed(EjercicioClavesABM.Models.EjercicioClavesABMContext context)
        {
            
        }
    }
}
