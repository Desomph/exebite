﻿// <auto-generated />
using System;
using Exebite.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Exebite.DataAccess.Migrations
{
    [DbContext(typeof(FoodOrderingContext))]
    [Migration("20180308125141_FoodFix1")]
    partial class FoodFix1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-preview1-28290")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Exebite.DataAccess.Entities.CustomerAliasesEntities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias");

                    b.Property<int>("CustomerId");

                    b.Property<int>("RestaurantId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("CustomerAliasesEntities");
                });

            modelBuilder.Entity("Exebite.DataAccess.Entities.CustomerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppUserId");

                    b.Property<decimal>("Balance");

                    b.Property<int>("LocationId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Exebite.DataAccess.Entities.FoodEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("IsInactive");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<int?>("RestaurantEntityId");

                    b.Property<int>("RestaurantId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantEntityId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Food");
                });

            modelBuilder.Entity("Exebite.DataAccess.Entities.FoodEntityMealEntities", b =>
                {
                    b.Property<int>("FoodEntityId");

                    b.Property<int>("MealEntityId");

                    b.HasKey("FoodEntityId", "MealEntityId");

                    b.HasIndex("MealEntityId");

                    b.ToTable("FoodEntityMealEntities");
                });

            modelBuilder.Entity("Exebite.DataAccess.Entities.FoodEntityRecipeEntity", b =>
                {
                    b.Property<int>("FoodEntityId");

                    b.Property<int>("RecepieEntityId");

                    b.HasKey("FoodEntityId", "RecepieEntityId");

                    b.HasIndex("RecepieEntityId");

                    b.ToTable("FoodEntityRecipeEntity");
                });

            modelBuilder.Entity("Exebite.DataAccess.Entities.LocationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Exebite.DataAccess.Entities.MealEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Meal");
                });

            modelBuilder.Entity("Exebite.DataAccess.Entities.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("MealId");

                    b.Property<string>("Note");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("MealId")
                        .IsUnique();

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Exebite.DataAccess.Entities.RecipeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MainCourseId");

                    b.HasKey("Id");

                    b.HasIndex("MainCourseId");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("Exebite.DataAccess.Entities.RestaurantEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("Exebite.DataAccess.Entities.CustomerAliasesEntities", b =>
                {
                    b.HasOne("Exebite.DataAccess.Entities.CustomerEntity", "Customer")
                        .WithMany("Aliases")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Exebite.DataAccess.Entities.RestaurantEntity", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Exebite.DataAccess.Entities.CustomerEntity", b =>
                {
                    b.HasOne("Exebite.DataAccess.Entities.LocationEntity", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Exebite.DataAccess.Entities.FoodEntity", b =>
                {
                    b.HasOne("Exebite.DataAccess.Entities.RestaurantEntity")
                        .WithMany("DailyMenu")
                        .HasForeignKey("RestaurantEntityId");

                    b.HasOne("Exebite.DataAccess.Entities.RestaurantEntity", "Restaurant")
                        .WithMany("Foods")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Exebite.DataAccess.Entities.FoodEntityMealEntities", b =>
                {
                    b.HasOne("Exebite.DataAccess.Entities.FoodEntity", "FoodEntity")
                        .WithMany("FoodEntityMealEntity")
                        .HasForeignKey("FoodEntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Exebite.DataAccess.Entities.MealEntity", "MealEntity")
                        .WithMany("FoodEntityMealEntities")
                        .HasForeignKey("MealEntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Exebite.DataAccess.Entities.FoodEntityRecipeEntity", b =>
                {
                    b.HasOne("Exebite.DataAccess.Entities.FoodEntity", "FoodEntity")
                        .WithMany("FoodEntityRecipeEntities")
                        .HasForeignKey("FoodEntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Exebite.DataAccess.Entities.RecipeEntity", "RecipeEntity")
                        .WithMany("FoodEntityRecipeEntities")
                        .HasForeignKey("RecepieEntityId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Exebite.DataAccess.Entities.OrderEntity", b =>
                {
                    b.HasOne("Exebite.DataAccess.Entities.CustomerEntity", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Exebite.DataAccess.Entities.MealEntity", "Meal")
                        .WithOne("Order")
                        .HasForeignKey("Exebite.DataAccess.Entities.OrderEntity", "MealId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Exebite.DataAccess.Entities.RecipeEntity", b =>
                {
                    b.HasOne("Exebite.DataAccess.Entities.FoodEntity", "MainCourse")
                        .WithMany()
                        .HasForeignKey("MainCourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
