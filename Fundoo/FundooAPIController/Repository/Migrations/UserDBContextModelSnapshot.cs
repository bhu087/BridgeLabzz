﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Context;

namespace Repository.Migrations
{
    [DbContext(typeof(UserDBContext))]
    partial class UserDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Account.Login", b =>
                {
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.HasKey("Email");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("Model.Account.NotesModel", b =>
                {
                    b.Property<int>("NotesId1")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color");

                    b.Property<DateTime?>("CreatedTime");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<string>("Image");

                    b.Property<bool>("IsArchive");

                    b.Property<bool>("IsPin");

                    b.Property<bool>("IsTrash");

                    b.Property<DateTime?>("ModifiedTime");

                    b.Property<string>("Remainder");

                    b.Property<string>("Title");

                    b.HasKey("NotesId1");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Model.Account.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Registers");
                });
#pragma warning restore 612, 618
        }
    }
}
