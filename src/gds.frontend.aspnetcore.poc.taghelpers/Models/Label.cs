using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace gds.frontend.aspnetcore.poc.taghelpers.Models
{
    public class Label
    {
        public string Text { get; set; }
        public string Html { get; set; }
        public string For { get; set; }
        public bool IsPageHeading { get; set; }
        public string Classes { get; set; }
        public object Attributes { get; set; }
    }
}
