using ClimbingDiary.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimbingDiary.API.DbContexts
{
    public class ClimbingDiaryContext: DbContext
    {
        public ClimbingDiaryContext(DbContextOptions<ClimbingDiaryContext> options)
            :base(options)
        {

        }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Climber> Climbers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sector>().HasData(
                new Sector()
                {
                    Id = Guid.Parse("17612c45-d23a-4f71-9bef-c6fb0c0a6a0e"),
                    Name="Rzedkowice",
                    Country="Poland",
                    Category="Vertical",
                    Description="Rzechowice"
                },
                 new Sector()
                 {
                     Id = Guid.Parse("28612c45-d23a-4f71-9bef-c6fb0c0a6a0e"),
                     Name = "Mirow",
                     Country = "Poland",
                     Category = "Vertical",
                     Description = "Mirow"
                 },
                  new Sector()
                  {
                      Id = Guid.Parse("39612c45-d23a-4f71-9bef-c6fb0c0a6a0e"),
                      Name = "Sulovskie skaly",
                      Country = "Slovakia",
                      Category = "Vertical",
                      Description = "Sample description"
                  }
                );
            modelBuilder.Entity<Route>().HasData(
                new Route
                {
                    Id = Guid.Parse("29b94dca-3d64-4987-be20-52f5f3f4ba19"),
                    SectorId = Guid.Parse("17612c45-d23a-4f71-9bef-c6fb0c0a6a0e"),
                    Name="Magnezjowka",
                    Author="Jakistam",
                    Grade="VI.2",
                    Description="Very nice Keepo"
                    
                },
                new Route
                {
                    Id = Guid.Parse("39b94dca-3d64-4987-be20-52f5f3f4ba19"),
                    SectorId = Guid.Parse("28612c45-d23a-4f71-9bef-c6fb0c0a6a0e"),
                    Name = "Najwazniejeszy pierwszy krok",
                    Author = "Jakistam",
                    Grade = "VI.1",
                    Description = "Very nice Keepo"

                }
               
               
                );
            modelBuilder.Entity<Climber>().HasData
                (
                new Climber
                {
                    Id=Guid.Parse("59b94dca-3d64-4987-be20-52f5f3f4ba19"),
                    FirstName="Michal",
                    SecondName="Iksde",
                    DateOfBirth=new DateTime(1997,01,01),
                    AboutMe="Eluwina"
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
