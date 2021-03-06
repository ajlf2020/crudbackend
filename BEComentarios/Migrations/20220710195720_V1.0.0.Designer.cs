// <auto-generated />
using System;
using BEComentarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BEComentarios.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20220710195720_V1.0.0")]
    partial class V100
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BEComentarios.Models.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Creador")
                        .IsRequired();

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<string>("Texto")
                        .IsRequired();

                    b.Property<string>("Titulo")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Comentario");
                });
#pragma warning restore 612, 618
        }
    }
}
