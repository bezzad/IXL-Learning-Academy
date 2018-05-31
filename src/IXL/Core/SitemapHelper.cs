using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Dapper;
using IXL.Models;

namespace IXL.Core
{
    public static class SitemapHelper
    {
        public static IEnumerable<SitemapModels> GetSitemapModels()
        {
            var nodes = Connections.IxlDb.SqlConn.Query<SitemapModels>("Select * From Sitemap");

            return nodes;
        }

        public static IEnumerable<SitemapModels> GetSitemapModels(string culture)
        {
            var langId = CultureHelper.Languages[culture].LangId;
            var nodes = Connections.IxlDb.SqlConn.Query<SitemapModels>("Select * From Sitemap Where LangId = @langId", new { langId });

            return nodes;
        }

        public static string GetSitemapDocument(this IEnumerable<SitemapModels> sitemapModelss)
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");
            foreach (SitemapModels sitemapModels in sitemapModelss)
            {
                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapModels.Url)),
                    sitemapModels.LastModified == null ? null : new XElement(
                        xmlns + "lastmod",
                        sitemapModels.LastModified.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
                    sitemapModels.Frequency == null ? null : new XElement(
                        xmlns + "changefreq",
                        sitemapModels.Frequency.Value.ToString().ToLowerInvariant()),
                    sitemapModels.Priority == null ? null : new XElement(
                        xmlns + "priority",
                        sitemapModels.Priority.Value.ToString("F1", CultureInfo.InvariantCulture)));
                root.Add(urlElement);
            }
            XDocument document = new XDocument(root);
            return document.ToString();
        }

        public static TreeNode<SitemapModels> GetTreeNode(this IEnumerable<SitemapModels> sitemapModelss, string headerName = "")
        {
            var tree = new TreeNode<SitemapModels>(new SitemapModels() { Title = headerName, Url = "/", Id = null, ParentId = null });

            sitemapModelss.FillTreeNodeOfThisParent(tree);

            return tree;
        }

        private static void FillTreeNodeOfThisParent(this IEnumerable<SitemapModels> sitemapModelss, TreeNode<SitemapModels> parent)
        {
            var children = sitemapModelss.Where(s => s.ParentId == parent?.Value?.Id);

            foreach (var child in children)
            {
                var pNode = parent.AddChild(child);
                sitemapModelss.FillTreeNodeOfThisParent(pNode);
            }
        }
    }
}