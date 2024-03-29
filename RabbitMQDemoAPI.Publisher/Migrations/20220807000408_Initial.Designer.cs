﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RabbitMQDemoAPI.Publisher.Data;

namespace RabbitMQDemoAPI.Publisher.Migrations
{
    [DbContext(typeof(APIMatriculaDbContext))]
    [Migration("20220807000408_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RabbitMQDemoAPI.Consumer.Models.Aluno", b =>
                {
                    b.Property<string>("Matricula")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Curso")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Matricula");

                    b.ToTable("Alunos");
                });
#pragma warning restore 612, 618
        }
    }
}
