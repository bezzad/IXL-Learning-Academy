using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IXL.Models
{
    public class SitemapModels
    {
        public long? Id { get; set; }
        public string Title { get; set; }
        public ChangeFrequency? Frequency { get; set; }
        public DateTime? LastModified { get; set; }
        public double? Priority { get; set; }
        public string Url { get; set; }
        public int LangId { get; set; }
        public long? ParentId { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Title)) return string.Empty;

            var aTag = new TagBuilder("a");
            aTag.Attributes.Add("href", Url);
            aTag.InnerHtml = Title;
            return aTag.ToString();
        }
    }
}