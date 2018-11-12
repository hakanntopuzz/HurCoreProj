using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HurCoreProj.Service.Helper
{
    public static class ExtensionMethods
    {
        public static string ToAmpHtml(this string html)
        {
            html = html.Replace("iframe", "amp-iframe");
            html = html.Replace("img", "amp-img");
            html = html.Replace("video", "amp-video");
            html = html.Replace("audio", "amp-audio");
            html = html.Replace("!important", "");
            html = html.Replace("font-weigth:", "");
            html = html.Replace("width='100%'", "");
            html = html.Replace("height='100%'", "");

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);

            var elementsStartWithOnAttribute = document.DocumentNode.SelectNodes("//*/@*[starts-with(local-name(), 'on')]");

            if (elementsStartWithOnAttribute != null)
            {
                foreach (var element in elementsStartWithOnAttribute)
                {
                    var onAttributes = element.Attributes.Where(q => q.Name.StartsWith("on")).Select(s => s.Name)
                        .ToList();

                    foreach (var attribute in onAttributes)
                    {
                        element.Attributes[attribute].Remove();
                    }
                }
            }
            
            using (StringWriter writer = new StringWriter())
            {
                document.Save(writer);
                html = writer.ToString();
            }

            return html;
        }
    }
}
