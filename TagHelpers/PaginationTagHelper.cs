using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SparkAuto.Models;

namespace SparkAuto.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory _helperFactory;

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }    //provide access to requests and responses

        public PaginationDetails PageModel { get; set; }

        public string PageAction { get; set; }
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var urlHelper = _helperFactory.GetUrlHelper(ViewContext);
            var divTagBuilder = new TagBuilder("div");

            for (var i = 1; i <= PageModel.TotalPages; i++)
            {
                var aTag = new TagBuilder("a");
                var url = PageModel.Url.Replace(":", i.ToString());
                aTag.Attributes["href"] = url;
                aTag.AddCssClass(PageClass);

                aTag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                aTag.InnerHtml.Append(i.ToString());

                divTagBuilder.InnerHtml.AppendHtml(aTag);
            }

            output.Content.AppendHtml(divTagBuilder.InnerHtml);
        }

        public PaginationTagHelper(IUrlHelperFactory helperFactory)
        {
            _helperFactory = helperFactory;
        }
    }
}
