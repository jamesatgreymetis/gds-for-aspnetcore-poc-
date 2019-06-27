namespace gds.frontend.aspnetcore.poc.taghelpers.Models
{
    /// <summary>
    /// Cell in a table row
    /// </summary>
    public class Cell
    {
        public string Text { get; set; }
        public string Html { get; set; }
        public string Classes { get; set; }
        public object Attributes { get; set; }

        public Format Format { get; set; }
        public int Rowspan { get; set; } = 1;
        public int Colspan { get; set; } = 1;
    }
}