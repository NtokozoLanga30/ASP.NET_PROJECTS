using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ComptScienceBooks.Infrastructure
{
    [HtmlTargetElement("a", Attributes = "[role=link]")]
    public class LinkTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "text-info fst-italic");
        }
    }
}
