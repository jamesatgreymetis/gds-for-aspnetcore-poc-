using gds.frontend.aspnetcore.poc.taghelpers.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace gds.frontend.aspnetcore.poc.taghelpers
{
    public class GovUkPhaseBannerTagHelper : TagHelper
    {
        /// <summary>
        /// Required. If html is set, this is not required. Text to use within the phase banner. If html is provided, the text argument will be ignored.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Required. If text is set, this is not required. HTML to use within the phase banner. If html is provided, the text argument will be ignored.
        /// </summary>
        public string Html { get; set; }

        public string Tag { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "govuk-phase-banner");
            output.Content.AppendHtml(InnerHtml());
        }

        private TagBuilder InnerHtml()
        {
            var p = new TagBuilder("p");
            p.AddCssClass("govuk-phase-banner__content");

            // this strong tag could also be used for the tag component. Look into how it could be reused.
            var strong = new TagBuilder("strong");
            strong.AddCssClass("govuk-tag govuk-phase-banner__content__tag");
            strong.InnerHtml.Append(Tag);

            var span = new TagBuilder("span");
            span.AddCssClass("govuk-phase-banner__text");
            AppendHtmlOrText(span);

            p.InnerHtml.AppendHtml(strong);
            p.InnerHtml.AppendHtml(span);

            return p;
        }


        private void AppendHtmlOrText(TagBuilder tagBuilder)
        {
            if (string.IsNullOrWhiteSpace(Html))
            {
                tagBuilder.InnerHtml.Append(Text);
            }
            else
            {
                tagBuilder.InnerHtml.AppendHtml(Html);
            }
        }
    }
}