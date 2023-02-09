using System.Collections.Generic;
using ToolsManagement.Data.Entities;
using ToolsManagement.Entities;

namespace ToolsManagement.Models.DrillModel
{
    public class DrillMagazineDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int QuantityInMagazine { get; set; }

        public static DrillMagazineDto ToDrillMagazineDTOMap(Drill drill)
        {
            return new DrillMagazineDto()
            {
                Id = drill.Id,
                Quantity = drill.Quantity,
                QuantityInMagazine = drill.QuantityInMagazine,
            };
        }
    }
}
