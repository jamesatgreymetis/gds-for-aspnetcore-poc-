using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace gds.frontend.aspnetcore.poc.taghelpers
{
    public class GovUkButtonTagHelper : TagHelper
    {
        private readonly IHtmlGenerator _htmlGenerator;

        public GovUkButtonTagHelper(IHtmlGenerator htmlGenerator)
        {
            _htmlGenerator = htmlGenerator;
        }
        /// <summary>
        /// Required. If html is set, this is not required. Text for the button or link. If html is provided, the text argument will be ignored and element will be automatically set to button unless href is also set, or it has already been defined. This argument has no effect if element is set to input.
        /// </summary>
        public string Text { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } // button, submit, reset
        public string Classes { get; set; }

        /// <summary>
        /// Required. If text is set, this is not required. HTML for the button or link. If html is provided, the text argument will be ignored and element will be automatically set to button unless href is also set, or it has already been defined. This argument has no effect if element is set to input.
        /// </summary>
        public string Html { get; set; }

        /// <summary>
        /// The URL that the button should link to. If this is set, element will be automatically set to a if it has not already been defined.
        /// </summary>
        public string Href { get; set; }

        private const string ActionAttributeName = "asp-action";
        private const string ControllerAttributeName = "asp-controller";
        private const string AreaAttributeName = "asp-area";

        /// <summary>
        /// The name of the action method.
        /// </summary>
        /// <remarks>
        /// Must be <c>null</c> if <see cref="Route"/> or <see cref="Page"/> is non-<c>null</c>.
        /// </remarks>
        [HtmlAttributeName(ActionAttributeName)]
        public string Action { get; set; }

        /// <summary>
        /// The name of the controller.
        /// </summary>
        /// <remarks>
        /// Must be <c>null</c> if <see cref="Route"/> or <see cref="Page"/> is non-<c>null</c>.
        /// </remarks>
        [HtmlAttributeName(ControllerAttributeName)]
        public string Controller { get; set; }

        /// <summary>
        /// The name of the area.
        /// </summary>
        /// <remarks>
        /// Must be <c>null</c> if <see cref="Route"/> is non-<c>null</c>.
        /// </remarks>
        [HtmlAttributeName(AreaAttributeName)]
        public string Area { get; set; }


        /// <summary>
        /// Gets or sets the <see cref="Microsoft.AspNetCore.Mvc.Rendering.ViewContext"/> for the current request.
        /// </summary>
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (string.IsNullOrEmpty(Href))
            {
                output.TagName = "button";
            }
            else
            {
                output.TagName = "a";

                //output.Attributes.Add("href", _urlHelper.RouteUrl());
            }
           
            output.Attributes.SetAttribute("type", Type);
            output.Attributes.SetAttribute("name", Name);
            output.Attributes.SetAttribute("class", Classes ?? "govuk-button");
            output.Content.SetContent(Text);
        }
    }
}
