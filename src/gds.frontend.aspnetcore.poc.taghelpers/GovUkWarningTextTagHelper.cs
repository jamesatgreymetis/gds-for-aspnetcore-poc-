using Microsoft.AspNetCore.Razor.TagHelpers;

namespace gds.frontend.aspnetcore.poc.taghelpers
{
    public class GovUkWarningTextTagHelper : TagHelper
    {
        /// <summary>
        /// Required. If html is set, this is not required. Text to use within the warning text component. If html is provided, the text argument will be ignored.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Required. The fallback text for the icon.
        /// </summary>
        public string IconFallbackText { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("class", "govuk-warning-text");
            output.Content.AppendHtml(InnerHtml());
            output.TagMode = TagMode.StartTagAndEndTag;
        }

        private string InnerHtml()
        {
            return "<span class=\"govuk-warning-text__icon\" aria-hidden=\"true\">!</span>" +
                   "<strong class=\"govuk-warning-text__text\">" +
                   $"<span class=\"govuk-warning-text__assistive\">{IconFallbackText}</span>{Text}</strong>";
        }
    }
}