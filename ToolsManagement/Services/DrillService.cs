using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using ToolsManagement.Entities;
using ToolsManagement.Exceptions;
using ToolsManagement.Models.Drill;
using Microsoft.EntityFrameworkCore;
using ToolsManagement.Services.Interfaces;
using ToolsManagement.Data.Context;
using ToolsManagement.Data.Entities;

namespace ToolsManagement.Services
{
    public class DrillService : IDrillService
    {
        private readonly ToolsManagementDbContext _dbContext;
        public DrillService(ToolsManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<DrillDto> GetAll()
        {
            var drills = _dbContext
                .Drills
                .Select(n => new DrillDto()
                {
                    Id = n.Id,
                    Name = n.Name,
                    Length = n.Length,
                    Diameter = n.Diameter,
                    Quantity = n.Quantity
                })
                .ToList();
            return drills;
        }
        public int CreateDrill(CreateDrillDto createDrillDto)
        {
            var drill = new Drill()
            {
                Name = createDrillDto.Name,
                Diameter = createDrillDto.Diameter,
                Length = createDrillDto.Length,
            };
            _dbContext.Drills.Add(drill);
            _dbContext.SaveChanges();
            return drill.Id;
        }   
        public DrillDto GetById(int id)
        {
            var drill = _dbContext
                .Drills
                .Select(n => new DrillDto()
                { 
                    Id = n.Id,
                    Name = n.Name, 
                    Length = n.Length, 
                    Diameter = n.Diameter 
                })
                .FirstOrDefault(d => d.Id == id);
            if (drill is null)
            {
                throw new NotFoundException("Drill not found.");
            }
            return drill;
        }
        public void Delete(int id)
        {
            var drill = _dbContext
                .Drills
                .FirstOrDefault(d => d.Id == id);
            if (drill is null)
            {
                throw new NotFoundException("Drill not found.");
            }
            _dbContext.Drills.Remove(drill);
            _dbContext.SaveChanges();
        }
        public void Update(int id, UpdateDrillDto dto)
        {
            var drill = _dbContext
                .Drills
                .FirstOrDefault(d => d.Id == id);
            if (drill is null)
            {
                throw new NotFoundException("Drill not found.");
            }

            var name = dto.Name;
            var diameter = dto.Diameter;
            var length = dto.Length;

            if (name is not null)
            {
                drill.Name = dto.Name;
            }
            if (diameter != 0)
            {
                drill.Diameter = dto.Diameter;
            }
            if (length != 0)
            {
                drill.Length = dto.Length;
            }
            
            _dbContext.SaveChanges();
        }
    }
}
