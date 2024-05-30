using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ComptScienceBooks.Infrastructure
{
    [HtmlTargetElement("h2")]
    public class HeadingTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "bg-secondary text-center text-white fw-bold");
        }
    }
}
