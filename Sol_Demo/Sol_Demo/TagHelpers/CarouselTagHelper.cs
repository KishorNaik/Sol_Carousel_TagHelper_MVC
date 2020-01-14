using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Sol_Demo.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("bootstrap-carousel")]
    public class CarouselTagHelper : TagHelper
    {
        #region Declaration
        private readonly IHtmlHelper helper = null;

        private const String ItemSourceAttributeName = "item-source";

        #endregion

        #region Constructor
        public CarouselTagHelper(IHtmlHelper helper)
        {
            this.helper = helper;
        }
        #endregion

        #region Property
        [HtmlAttributeName(ItemSourceAttributeName)]
        public List<String> ItemSource { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        #endregion 


        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //Contextualize the html helper
            (helper as IViewContextAware).Contextualize(ViewContext);

            var carouselTemplate = await helper.PartialAsync("~/Views/Shared/_BootstrapCarouselTagHelperPartialView.cshtml", ItemSource);

            output.Content.SetHtmlContent(carouselTemplate);

            //return base.ProcessAsync(context, output);
        }
    }
}
