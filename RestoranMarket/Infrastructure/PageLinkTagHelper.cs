using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using RestoranMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestoranMarket.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory _urlHelperFactory)
        {
            urlHelperFactory = _urlHelperFactory;
        }

        [ViewContext] //bunun bir context olduğunu
        [HtmlAttributeNotBound] //ve html attribute ile bağlanmayacağını belirttik
        public ViewContext ViewContext { get; set; }

        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            var result = new TagBuilder("div"); //kapsayıcı eleman
            for (int i = 1; i < PageModel.TotalPages()+1; i++)
            {
                var tag = new TagBuilder("a");
                tag.Attributes["href"] = urlHelper.Action(PageAction, new { page = i });
                tag.InnerHtml.Append(i.ToString());
                if (i == PageModel.CurrentPage)
                {
                    tag.AddCssClass("btn bg-success mx-2");
                }
                else
                {
                    tag.AddCssClass("btn mx-2");
                }
                result.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
