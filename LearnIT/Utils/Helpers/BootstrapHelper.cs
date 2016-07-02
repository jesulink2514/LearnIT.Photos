using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace LearnIT.Utils.Helpers
{
    public static class BootstrapHelper
    {
        public static MvcHtmlString BootstrapTextBoxFor<T, TProperty>
            (this HtmlHelper<T> helper,
            Expression<Func<T,TProperty>> propertyFunc,
            string placeholder=null)
        {
            var textBox = helper.TextBoxFor(propertyFunc,new
            {
                @class="form-control",
                placeholder=placeholder ?? string.Empty
            });
            return textBox;
        }

        public static MvcHtmlString BootstrapSubmit(
            this HtmlHelper helper,
            string text)
        {
            var btnTag = new TagBuilder("input");
            btnTag.AddCssClass("btn btn-primary");
            btnTag.Attributes.Add("type","submit");
            btnTag.Attributes.Add("value",text);

            return MvcHtmlString.Create(btnTag.ToString(TagRenderMode.SelfClosing));
        }


    }
}