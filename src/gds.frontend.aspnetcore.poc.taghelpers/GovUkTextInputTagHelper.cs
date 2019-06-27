using System.Text;
using System.Threading.Tasks;
using gds.frontend.aspnetcore.poc.taghelpers.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace gds.frontend.aspnetcore.poc.taghelpers
{
    public class GovUkTextInputTagHelper : TagHelper
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Label Label { get; set; }
        public Hint Hint { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "govuk-form-group");
            var content = await output.GetChildContentAsync();
            output.Content.SetHtmlContent(GetHtml());
            output.TagMode = TagMode.StartTagAndEndTag;
        }

        private string GetHtml()
        {
            var contentHtml = new StringBuilder();
            contentHtml.AppendLine($"<label class=\"govuk-label\" for=\"{Label.For}\">{Label.Text}</label>");
            if (Hint!=null)
            {
                contentHtml.AppendLine($"<span id=\"{Hint.Id}\" class=\"govuk-hint {Hint.Classes}\">{Hint.Text}</span>");
            }

            contentHtml.AppendLine($"<input class=\"govuk-input\" id=\"{Id}\" name=\"{Name}\" type=\"text\">");

            return contentHtml.ToString();
        }
    }
}