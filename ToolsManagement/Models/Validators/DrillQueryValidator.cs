using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsManagement.Data.Entities;

namespace ToolsManagement.Models.Validators
{
    public class DrillQueryValidator : AbstractValidator<DrillQuery>
    {
        private int[] allowebPageSizes = new[] { 5, 10, 15 };
        private string[] allowedSortByColumnNames = { nameof(Drill.Name) };
        public DrillQueryValidator()
        {
            RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(r => r.PageSize).Custom((value, context) =>
            {
                if (!allowebPageSizes.Contains(value))
                {
                    context.AddFailure("PageSize", $"PageSize must in [{string.Join(",", allowebPageSizes)}]");
                }
            });

            RuleFor(r => r.SortBy).Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional or must be in [{string.Join(",", allowedSortByColumnNames)}]");
        }
    }
}
