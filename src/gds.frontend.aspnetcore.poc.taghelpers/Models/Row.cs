using System.Collections.Generic;

namespace gds.frontend.aspnetcore.poc.taghelpers.Models
{
    public class Row
    {
        public Row()
        {
            Cells = new List<Cell>();
        }

        public List<Cell> Cells { get; set; }
    }
}