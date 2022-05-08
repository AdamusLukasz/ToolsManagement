using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using ToolsManagement.Entities;
using ToolsManagement.Models;
using ToolsManagement.Exceptions;

namespace ToolsManagement.Services
{
    public interface IDrillService
    {
        IEnumerable<DrillDto> GetAll();
        int Create(CreateDrillDto dto);
        DrillDto GetById(int id);
        void Delete(int id);
    }
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
                .Select(x => new DrillDto()
                { Id = x.Id, Name = x.Name, Diameter = x.Diameter, Vc = x.Vc, Fz = x.Fz})
                .ToList();
            return drills;
        }
        public int Create(CreateDrillDto dto)
        {
            var drill = new Drill()
            {
                Name = dto.Name,
                Diameter = dto.Diameter, 
                Fz = dto.Fz, 
                Vc = dto.Vc
            };
            _dbContext.Add(drill);
            _dbContext.SaveChanges();
            return drill.Id;
        }
        public DrillDto GetById(int id)
        {
            var drill = _dbContext
                .Drills
                .Select(x => new DrillDto()
                { Id = x.Id, Name = x.Name, Diameter = x.Diameter, Vc = x.Vc, Fz = x.Fz })
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
    }
}
