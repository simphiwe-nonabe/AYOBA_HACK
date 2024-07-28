﻿// <auto-generated />
using LotusOrganiser.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LotusOrganiser.Migrations
{
    [DbContext(typeof(LotusOrganiserDbContext))]
    [Migration("20240727192622_subscriptionAdded1111")]
    partial class subscriptionAdded1111
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LotusOrganiser.Entities.Business", b =>
                {
                    b.Property<long>("BusinessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("BusinessId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BusinessId");

                    b.ToTable("Businesses");
                });

            modelBuilder.Entity("LotusOrganiser.Entities.Subscription", b =>
                {
                    b.Property<long>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SubscriptionId"));

                    b.Property<long>("BusinessId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("SubscriptionId");

                    b.HasIndex("BusinessId");

                    b.HasIndex("UserId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("LotusOrganiser.Entities.Message", b =>
                {
                    b.Property<long>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ItemId"));

                    b.Property<long>("BusinessId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ItemId");

                    b.HasIndex("BusinessId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("LotusOrganiser.Entities.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LotusOrganiser.Entities.Subscription", b =>
                {
                    b.HasOne("LotusOrganiser.Entities.Business", "Business")
                        .WithMany()
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LotusOrganiser.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Business");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LotusOrganiser.Entities.Message", b =>
                {
                    b.HasOne("LotusOrganiser.Entities.Business", "Business")
                        .WithMany()
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Business");
                });
#pragma warning restore 612, 618
        }
    }
}
