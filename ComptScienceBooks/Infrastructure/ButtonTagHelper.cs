using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ComptScienceBooks.Infrastructure
{
    [HtmlTargetElement("input", Attributes = "[type=submit]")]
    public class ButtonTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "btn btn-danger");
        }

    }
}
