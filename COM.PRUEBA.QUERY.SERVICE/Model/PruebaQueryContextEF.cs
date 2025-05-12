using COM.PRUEBA.QUERY.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.QUERY.SERVICE
{
    public partial class PruebaQueryContextEF : DbContext
    {
        public readonly string? connectionString;

        public PruebaQueryContextEF(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public PruebaQueryContextEF()
           : base()
        {
        }


        public PruebaQueryContextEF(DbContextOptions<PruebaQueryContextEF> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(QueryParameters.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
