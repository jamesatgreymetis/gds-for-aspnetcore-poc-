using Microsoft.AspNetCore.Razor.TagHelpers;

namespace gds.frontend.aspnetcore.poc.taghelpers
{
    /// <summary>
    /// Use options to customise the appearance, content and behaviour of a component when using a macro, for example, changing the text.
    /// Some options are required for the macro to work; these are marked as "Required" in the option description.
    /// If you're using TagHelpers in production with "html" options, or ones ending with "html", you must sanitise the HTML to protect against cross-site scripting exploits.
    /// </summary>
    public class GovUkCheckboxesTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
        }
    }
}
