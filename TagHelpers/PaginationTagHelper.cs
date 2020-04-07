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

        public PaginationDetails PaginationDetails { get; set; }

        public string PageAction { get; set; }
        public string PageCss { get; set; }
        public string UnSelectedPagesCss { get; set; }
        public string SelectedPagesCss { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            var divTagBuilder = new TagBuilder("div");

            for (var i = 1; i <= PaginationDetails.TotalPages; i++)
            {
                var aTag = new TagBuilder("a");
                var url = PaginationDetails.Url.Replace(":", i.ToString());
                aTag.Attributes["href"] = url;
                aTag.AddCssClass(PageCss);

                aTag.AddCssClass(i == PaginationDetails.CurrentPage ? SelectedPagesCss : UnSelectedPagesCss);
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
