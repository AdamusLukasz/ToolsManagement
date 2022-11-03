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
                .Include(a => a.Materials)
                .Select(n => new DrillDto()
                {
                    Id = n.Id,
                    Name = n.Name,
                    Length = n.Length,
                    Diameter = n.Diameter
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
        public Drill GetById(int id)
        {
            var drill = _dbContext
                .Drills
                .Include(x => x.Materials)
                .ThenInclude(y => y.DrillParameters)
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
            drill.Name = dto.Name;
            drill.Diameter = dto.Diameter;
            _dbContext.SaveChanges();
        }
    }
}
