using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace gds.frontend.aspnetcore.poc.taghelpers
{
    public class GovUkBackLinkTagHelper : TagHelper
    {
        /// <summary>
        /// Required. If <see cref="Html" /> is set, this is not required. Text to use within the back link component. If <see cref="Html" /> is provided, the text argument will be ignored.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Required. If <see cref="Text" /> is set, this is not required. HTML to use within the back link component. If <see cref="Html" /> is provided, the <see cref="Text" /> argument will be ignored.
        /// </summary>
        public string Html { get; set; }
        /// <summary>
        /// Required. The value of the link href attribute.
        /// </summary>
        public string Href { get; set; }
        /// <summary>
        /// Classes to add to the anchor tag.
        /// </summary>
        public string Classes { get; set; }
        /// <summary>
        /// HTML attributes (for example data attributes) to add to the anchor tag.
        /// </summary>
        public object Attributes { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // <a href="#" class="govuk-back-link">Back</a>
            output.TagName = "a";
            output.Attributes.Add("href", Href);
            output.Attributes.Add("class", "govuk-back-link");
            output.Content.SetContent(Text);
        }
    }
}
