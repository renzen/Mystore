﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using clientapi.models;

namespace ClientApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190415081453_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("clientapi.models.Item", b =>
                {
                    b.Property<long>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<long?>("StudioId");

                    b.HasKey("ItemId");

                    b.HasIndex("StudioId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("clientapi.models.Rating", b =>
                {
                    b.Property<long>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ItemId");

                    b.Property<int>("Stars");

                    b.HasKey("RatingId");

                    b.HasIndex("ItemId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("clientapi.models.Studio", b =>
                {
                    b.Property<long>("StudioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Name");

                    b.Property<string>("State");

                    b.HasKey("StudioId");

                    b.ToTable("Studios");
                });

            modelBuilder.Entity("clientapi.models.Item", b =>
                {
                    b.HasOne("clientapi.models.Studio", "Studio")
                        .WithMany("Items")
                        .HasForeignKey("StudioId");
                });

            modelBuilder.Entity("clientapi.models.Rating", b =>
                {
                    b.HasOne("clientapi.models.Item", "Item")
                        .WithMany("Ratings")
                        .HasForeignKey("ItemId");
                });
#pragma warning restore 612, 618
        }
    }
}
