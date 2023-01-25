using Microsoft.EntityFrameworkCore;
using RabbitMQDemoAPI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQDemoAPI.Consumer.Data
{
    public class APIMensalidadeDbContext : DbContext
    {
        public APIMensalidadeDbContext(DbContextOptions<APIMensalidadeDbContext> options) : base(options)
        {
        }

        public DbSet<Mensalidade> Mensalidades { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Mensalidade>().Property(x => x.Valor).HasColumnType("DECIMAL(18,2)");
        }
    }
}
