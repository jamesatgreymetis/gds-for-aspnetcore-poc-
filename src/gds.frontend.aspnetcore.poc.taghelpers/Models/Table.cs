using System.Collections.Generic;

namespace gds.frontend.aspnetcore.poc.taghelpers.Models
{
    public class Table
    {
        public Table()
        {
            HeadRows = new List<Row>();
            BodyRows = new List<Row>();
        }

        /// <summary>
        /// Array of table head cells. See head.
        /// </summary>
        public List<Row> HeadRows { get; set; }
        /// <summary>
        /// Required. Array of table rows and cells. See rows.
        /// </summary>
        public List<Row> BodyRows { get; set; }
        /// <summary>
        /// Caption text
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// Classes for caption text size. Classes should correspond to the available typography heading classes.
        /// </summary>
        public string CaptionClasses { get; set; }
        /// <summary>
        /// If set to true, first cell in table row will be a TH instead of a TD.
        /// </summary>
        public bool FirstCellIsHeader { get; set; }
        /// <summary>
        /// Classes to add to the table container.
        /// </summary>
        public string Classes { get; set; }
        /// <summary>
        /// HTML attributes (for example data attributes) to add to the table container.
        /// </summary>
        public object Attributes { get; set; }
    }
}