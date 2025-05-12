using COM.PRUEBA.QUERY.DTOs;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.QUERY.SERVICE
{
    public partial class PruebaQueryContextEF
    {
        public DbSet<LoginQueryDto> LoginQueryDto { get; set; }
        public DbSet<SolicitudQueryDto> SolicitudQueryDto { get; set; }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginQueryDto>().HasNoKey().ToView(null);
            modelBuilder.Entity<SolicitudQueryDto>().HasNoKey().ToView(null);
        }
    }
}
