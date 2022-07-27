using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using ToolsManagement.Entities;
using ToolsManagement.Exceptions;
using ToolsManagement.Models.Drill;
using Microsoft.EntityFrameworkCore;
using ToolsManagement.Services.Interfaces;
using ToolsManagement.Data.Context;

namespace ToolsManagement.Services
{
    public class DrillService : IDrillService
    {
        private readonly ToolsManagementDbContext _dbContext;
        //private readonly IMapper _mapper;
        public DrillService(ToolsManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<DrillDto> GetAll()
        {
            var drills = _dbContext
                .Drills
                .Include(x => x.DrillParameters)
                .Select(x => new DrillDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Diameter = x.Diameter,
                    Length = x.Length,
                    DrillParameters = x.DrillParameters.Select(y => new DrillParametersDto() { Id = y.Id, Vc = y.Vc, Fz = y.Fz}).ToList(),
                })
                .ToList();
            return drills;
        }
        public int CreateDrill(CreateDrillDto createDrillDto)
        {
            //var drillParameters = new List<DrillParameters>();
            //foreach (var drillParameter in createDrillDto.DrillParameters)
            //{
            //    drillParameters.Add(new DrillParameters() { Vc = drillParameter.Vc, Fz = drillParameter.Fz});
            //}
            var drill = new Drill()
            {
                Name = createDrillDto.Name,
                Diameter = createDrillDto.Diameter,
            };
            _dbContext.Drills.Add(drill);
            _dbContext.SaveChanges();
            return drill.Id;
        }   
        public DrillDto GetById(int id)
        {
            var drill = _dbContext
                .Drills
                .Include(x => x.DrillParameters)
                .Select(x => new DrillDto()
                { Id = x.Id, Name = x.Name, Diameter = x.Diameter })
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
            //drill.Vc = dto.Vc;
            //drill.Fz = dto.Fz;
            _dbContext.SaveChanges();
        }
    }
}
