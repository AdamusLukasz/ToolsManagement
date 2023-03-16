using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsManagement.Exceptions
{
    public class DrillNotFoundException : NotFoundException
    {
        public DrillNotFoundException(int id) : base($"Drill with ID {id} was NOT FOUND.")
        {

        }
    }
}
