using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Configuration;

namespace Mqeb.Web.TagHelpers
{
    public class GoogleRecaptcha : TagHelper
    {
        private IConfiguration _configuration;

        public GoogleRecaptcha(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var siteKey = _configuration.GetSection("GoogleRecaptcha")["SiteKey"];

            output.TagName = "div";
            output.AddClass("g-recaptcha", HtmlEncoder.Default);
            output.Attributes.Add("data-sitekey", siteKey);

            base.Process(context, output);
        }
    }
}