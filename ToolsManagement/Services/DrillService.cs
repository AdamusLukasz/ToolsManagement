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
        int Create(CreateDrillDto dto, CreateDrillParametersDto createDrillParametersDto);
        DrillDto GetById(int id);
        void Delete(int id);
        void Update(int id, UpdateDrillDto dto);
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
                { Id = x.Id, Name = x.Name, Diameter = x.Diameter, /*Vc = x.Vc, Fz = x.Fz*/})
                .ToList();
            return drills;
        }
        public int Create(CreateDrillDto createDrillDto, CreateDrillParametersDto createDrillParametersDto)
        {
            var drill = new Drill()
            {
                Name = createDrillDto.Name,
                Diameter = createDrillDto.Diameter,
                DrillParameters = new List<DrillParameters>() { new DrillParameters() { Vc = createDrillParametersDto.Vc, Fz = createDrillParametersDto.Fz} },
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
                { Id = x.Id, Name = x.Name, Diameter = x.Diameter, /*Vc = x.Vc, Fz = x.Fz */})
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
