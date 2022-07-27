using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ToolsManagement.Data.Context;
using ToolsManagement.Entities;
using ToolsManagement.Exceptions;
using ToolsManagement.Models.EndMillCutter;

namespace ToolsManagement.Services
{
    public interface IEndMillCutterService
    {
        IEnumerable<EndMillCutterDto> GetAll();
        EndMillCutterDto GetById(int id);

        int Create(CreateEndMillCutterDto dto);
        void Delete(int id);
        void Update(int id, UpdateEndMillCutterDto dto);
    }
    public class EndMillCutterService : IEndMillCutterService
    {
        private readonly ToolsManagementDbContext _dbcontext;

        public EndMillCutterService(ToolsManagementDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IEnumerable<EndMillCutterDto> GetAll()
        {
            var endMillCutter = _dbcontext.EndMillCutters.Select(x => new EndMillCutterDto()
            {
                Id = x.Id,
                Name = x.Name,
                Diameter = x.Diameter,
                //Vc = x.Vc,
                //Fz = x.Fz,
                //NumberOfTeeth = x.NumberOfTeeth,
                //WorkingLength = x.WorkingLength
            }).
            ToList();
            return endMillCutter;
        }
        public EndMillCutterDto GetById(int id)
        {
            var endMillCutter = _dbcontext
                .EndMillCutters
                .Select(x => new EndMillCutterDto()
                { Name = x.Name, Diameter = x.Diameter, /*Fz = x.Fz, Vc = x.Vc, NumberOfTeeth = x.NumberOfTeeth, WorkingLength = x.WorkingLength*/ })
                .FirstOrDefault(e => e.Id == id);
            if (endMillCutter is null)
            {
                throw new NotFoundException("End Mill Cutter not found.");
            }
            return endMillCutter;
        }
        public int Create(CreateEndMillCutterDto dto)
        {
            var endMillCutter = new EndMillCutter()
            {
                Name = dto.Name,
                Diameter = dto.Diameter,
                //Vc = dto.Vc,
                //Fz = dto.Fz,
                //NumberOfTeeth = dto.NumberOfTeeth,
                //WorkingLength = dto.WorkingLength
            };

            _dbcontext.EndMillCutters.Add(endMillCutter);
            _dbcontext.SaveChanges();
            return endMillCutter.Id;
        }
        public void Delete(int id)
        {
            var endMillCutter = _dbcontext
                .EndMillCutters
                .FirstOrDefault(e => e.Id == id);
            if (endMillCutter is null)
            {
                throw new NotFoundException("EndMillCutter not found.");
            }
            _dbcontext.EndMillCutters.Remove(endMillCutter);
            _dbcontext.SaveChanges();
        }
        public void Update(int id, UpdateEndMillCutterDto dto)
        {
            var endMillCutter = _dbcontext
                .EndMillCutters
                .FirstOrDefault(e => e.Id == id);
            if (endMillCutter is null)
            {
                throw new NotFoundException("End Mill Cutter not found.");
            }
            endMillCutter.Name = dto.Name;
            endMillCutter.Diameter = dto.Diameter;
            //endMillCutter.Vc = dto.Vc;
            //endMillCutter.Fz = dto.Fz;
            //endMillCutter.NumberOfTeeth = dto.NumberOfTeeth;
            //endMillCutter.WorkingLength = dto.WorkingLength;
            _dbcontext.SaveChanges();
        }
    }
}
