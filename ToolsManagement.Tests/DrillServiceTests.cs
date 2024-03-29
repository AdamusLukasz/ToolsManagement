﻿using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ToolsManagement.Data.Context;
using ToolsManagement.Data.Entities;
using Xunit;


namespace ToolsManagement.Tests
{
    public class DrillServiceTests
    {
        [Fact]
        public void CreateDrill_AddNewDrillToDatabase_AddedDrillSucceeded()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<ToolsManagementDbContext>();
            builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ToolsManagement-test;Trusted_Connection=True;");

            using (var context = new ToolsManagementDbContext(builder.Options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var drill = new Drill { Name = "iscar", Diameter = 10, Length = 15 };

                //Act

                context.Drills.Add(drill);
                context.SaveChanges();

                //Assert 

                drill.Id.Should().NotBe(null);
            }
        }
    }
}
