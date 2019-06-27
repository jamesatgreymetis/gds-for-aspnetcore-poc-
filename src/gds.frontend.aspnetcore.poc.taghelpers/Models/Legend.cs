using System;
using System.Collections.Generic;
using System.Text;

namespace gds.frontend.aspnetcore.poc.taghelpers.Models
{
    public class Legend
    {
        public string Text { get; set; }
        public string Html { get; set; }

        public string Classes { get; set; }

        public bool IsPageHeading { get; set; }
    }
}
