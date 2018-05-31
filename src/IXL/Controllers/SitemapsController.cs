using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using IXL.Core;
using IXL.Resources;

namespace IXL.Controllers
{
    [AllowAnonymous]
    public class SitemapsController : BaseController
    {
        // GET: Sitemap
        [OutputCache(Duration = 360, Location = System.Web.UI.OutputCacheLocation.Any, VaryByCustom = "culture")]
        public ActionResult Index()
        {
            ViewBag.Title = Localization.SiteNameSiteMap;
            var sitemapNodes = SitemapHelper.GetSitemapModels(CultureHelper.GetCurrentCulture());
            var tree = sitemapNodes.GetTreeNode();
            return View(tree);
        }

        [OutputCache(Duration = 360, Location = System.Web.UI.OutputCacheLocation.Any, VaryByCustom = "none")]
        public ActionResult SitemapXml()
        {
            var sitemapNodes = SitemapHelper.GetSitemapModels();
            var xml = sitemapNodes.GetSitemapDocument();
            return this.Content(xml, "text/Xml", Encoding.UTF8);
        }
    }
}