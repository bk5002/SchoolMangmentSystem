using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApplication10.TagHelpers
{
    [HtmlTargetElement("input", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("textarea")]
    public class ShortName1 : InputTagHelper
    {
        [HtmlAttributeName("asp-short-name")]
        public bool IsShortName { set; get; }

        public ShortName1(IHtmlGenerator generator) : base(generator){}
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (IsShortName)
            {
                string nameAttrValue = (string)output.Attributes.Single(a => a.Name == "name").Value;
                var attr = nameAttrValue.Split('.').Last();
                output.Attributes.SetAttribute("name", attr);
                output.Attributes.SetAttribute("id", attr);
            }
            try {
                base.Process(context, output);
            }
            catch(Exception e)  {
                Console.WriteLine("Error" + e);
            }
        }
    }

    [HtmlTargetElement("span")]
    public class ShortName2 : TagHelper
    {
        [HtmlAttributeName("asp-short-name")]
        public bool IsShortName { set; get; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (IsShortName)
            {
                string nameAttrValue = (string)output.Attributes.Single(a => a.Name == "data-valmsg-for").Value;
                output.Attributes.SetAttribute("data-valmsg-for", nameAttrValue.Split('.').Last());
            }
        }
    }
}
