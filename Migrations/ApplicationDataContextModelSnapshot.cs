﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThirdSample.Data;

namespace ThirdSample.Migrations
{
    [DbContext(typeof(ApplicationDataContext))]
    partial class ApplicationDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ThirdSample.Models.Instrument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("imgpath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("itemid")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int>("typeid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("itemid");

                    b.HasIndex("typeid");

                    b.ToTable("instruments");
                });

            modelBuilder.Entity("ThirdSample.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("items");
                });

            modelBuilder.Entity("ThirdSample.Models.Type", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("itemid")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("itemid");

                    b.ToTable("types");
                });

            modelBuilder.Entity("ThirdSample.Models.Instrument", b =>
                {
                    b.HasOne("ThirdSample.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("itemid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThirdSample.Models.Type", "Type")
                        .WithMany()
                        .HasForeignKey("typeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("ThirdSample.Models.Type", b =>
                {
                    b.HasOne("ThirdSample.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("itemid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });
#pragma warning restore 612, 618
        }
    }
}
