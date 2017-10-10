using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using reserby.Reservations.API.Infrastructure.Data.Context;

namespace reserby.Reservations.API.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ReservationsContext))]
    partial class ReservationsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("reserby.Reservations.API.Infrastructure.Data.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Contact");

                    b.Property<DateTime>("EndTime");

                    b.Property<int>("EntityId");

                    b.Property<DateTime>("StartTime");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Reservations");
                });
        }
    }
}
