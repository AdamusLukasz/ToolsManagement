﻿using System.Collections.Generic;
using ToolsManagement.Models.Drill;

namespace ToolsManagement.Services
{
    public interface IMagazineService
    {
        IEnumerable<DrillDto> GetAll();
    }
}