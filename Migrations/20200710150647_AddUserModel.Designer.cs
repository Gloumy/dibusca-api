﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dibusca_api.Entities;

namespace dibusca_api.Migrations
{
  [DbContext(typeof(AppDbContext))]
  [Migration("20200710150647_AddUserModel")]
  partial class AddUserModel
  {
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder
          .HasAnnotation("ProductVersion", "3.1.5")
          .HasAnnotation("Relational:MaxIdentifierLength", 128)
          .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

      modelBuilder.Entity("dibusca_api.Models.User", b =>
          {
            b.Property<int>("UserId")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int")
                      .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            b.Property<string>("Email")
                      .HasColumnType("nvarchar(max)");

            b.HasKey("UserId");

            b.ToTable("Users");
          });
#pragma warning restore 612, 618
    }
  }
}
