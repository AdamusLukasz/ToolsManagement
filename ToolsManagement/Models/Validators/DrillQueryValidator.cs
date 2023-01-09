using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsManagement.Models.Validators
{
    public class DrillQueryValidator : AbstractValidator<DrillQuery>
    {
        private int[] allowebPageSizes = new[] { 5, 10, 15 };
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
        }
    }
}
