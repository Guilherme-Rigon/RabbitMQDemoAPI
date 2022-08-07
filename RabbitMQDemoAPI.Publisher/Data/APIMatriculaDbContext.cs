using Microsoft.EntityFrameworkCore;
using RabbitMQDemoAPI.Consumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQDemoAPI.Publisher.Data
{
    public class APIMatriculaDbContext : DbContext
    {
        public APIMatriculaDbContext(DbContextOptions<APIMatriculaDbContext> options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
    }
}
