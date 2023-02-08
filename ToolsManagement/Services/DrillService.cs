using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using ToolsManagement.Entities;
using ToolsManagement.Exceptions;
using ToolsManagement.Models.DrillModel;
using Microsoft.EntityFrameworkCore;
using ToolsManagement.Services.Interfaces;
using ToolsManagement.Data.Context;
using ToolsManagement.Data.Entities;
using System;
using Microsoft.Extensions.Logging;
using ToolsManagement.Models;
using System.Linq.Expressions;
using ToolsManagement.Models.DrillParametersModels;
using System.Threading.Tasks;

namespace ToolsManagement.Services
{
    public class DrillService : IDrillService
    {
        private readonly ToolsManagementDbContext _dbContext;
        private readonly ILogger<DrillService> _logger;

        public DrillService(ToolsManagementDbContext dbContext, ILogger<DrillService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public PagedResult<DrillMagazineDto> GetPaginated(DrillQuery query)
        {
            var baseQuery = _dbContext
                .Drills
                .Where(q => query.SearchPhrase == null || (q.Name.ToLower().Contains(query.SearchPhrase.ToLower())))
                .Select(n => new DrillMagazineDto()
                {
                    Id = n.Id,
                    Name = n.Name,
                    Length = n.Length,
                    Diameter = n.Diameter,
                });

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelector = new Dictionary<string, Expression<Func<Drill, object>>>
                {
                    { nameof(Drill.Name), r => r.Name}
                };

                var selectedColumn = columnsSelector[query.SortBy];

                baseQuery = query.SortDirection == SortDirection.ASC
                    ? baseQuery.OrderBy(r => r.Name)
                    : baseQuery.OrderByDescending(c => c.Name);
            }

            var drills = baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToList();

            var totalItemsCount = baseQuery.Count();

            var result = new PagedResult<DrillMagazineDto>(drills, totalItemsCount, query.PageSize, query.PageNumber);

            return result;
        }
        public DrillMagazineDto GetById(int id)
        {
            var drill = _dbContext
                .Drills
                .Select(n => new DrillMagazineDto()
                {
                    Id = n.Id,
                    Name = n.Name,
                    Length = n.Length,
                    Diameter = n.Diameter
                })
                .FirstOrDefault(d => d.Id == id);
            if (drill is null)
            {
                throw new DrillNotFoundException(id);
            }
            return drill;
        }

        public IEnumerable<DrillMagazineDto> GetDrillForDeclaredDiameters(int minDiameter, int maxDiameter)
        {
            var drills = _dbContext
                .Drills
                .Where(d => d.Diameter >= minDiameter && d.Diameter <= maxDiameter)
                .Select(n => new DrillMagazineDto()
                {
                    Id = n.Id,
                    Name = n.Name,
                    Length = n.Length,
                    Diameter = n.Diameter,
                })
                .ToList();

            if (minDiameter >= maxDiameter)
            {
                throw new WrongValueException("Min value of diameter is grater than max value.");
            }
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

            bool isDigit = drill.Name.Any(char.IsDigit);

            if (createDrillDto.Diameter <= 0 || createDrillDto.Diameter > 100)
            {
                throw new WrongValueException("You put diameter less than 0 or more than 100.");
            }
            if (createDrillDto.Length <= 0 || createDrillDto.Length > 500)

            {
                throw new WrongValueException("You put length less than 0 or more than 500.");
            }

            if (isDigit)
            {
                throw new WrongValueException("You can't put any digits to tool name.");
            }

            if (_dbContext.Drills.Any(d => d.Name == drill.Name))
            {
                throw new WrongValueException("Record exist.");

            }
            _dbContext.Drills.Add(drill);
            _dbContext.SaveChanges();
            return drill.Id;
        }
        public void Delete(int id)
        {
            _logger.LogError($"Drill with id: {id} DELETE action invoked.");
            var drill = _dbContext
                .Drills
                .FirstOrDefault(d => d.Id == id);
            if (drill is null)
            {
                throw new DrillNotFoundException(id);
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

        public async Task<IEnumerable<DrillDto>> GetAll()
        {
            var drill = await _dbContext.Drills
                .Include(a => a.Materials)
                .ThenInclude(b => b.DrillParameters)
                .Select(a => DrillDto.ToDrillDTOMap(a))
                .ToListAsync();
            return drill;
        }
    }
}
