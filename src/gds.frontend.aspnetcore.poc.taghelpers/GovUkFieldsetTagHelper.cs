using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using gds.frontend.aspnetcore.poc.taghelpers.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace gds.frontend.aspnetcore.poc.taghelpers
{
    public class GovUkFieldsetTagHelper : TagHelper
    {
        public Legend Legend { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "fieldset";
            output.Attributes.Add("class", "govuk-fieldset");           
            var content = await output.GetChildContentAsync();
            output.Content.SetHtmlContent($"{GetLegendHtml()} {content.GetContent()}");
            output.TagMode = TagMode.StartTagAndEndTag;
        }

        private string GetLegendHtml()
        {
            return $"<legend class=\"govuk-fieldset__legend govuk-fieldset__legend--xl\">" +                   
                   $"{Legend.Text}" +                  
                   "</legend>";
        }
    }
}