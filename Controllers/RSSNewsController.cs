using Microsoft.Toolkit.Parsers.Rss;
using Sitecore.Mvc.Presentation;
using System;
using System.Net;
using System.Web.Mvc;

namespace Sitecore.Education.Templates.Controllers
{
    public class RSSNewsController : Controller
    {
        // GET: RSSNews
        public ActionResult Index()
        {
            string feed = null;
            using (var client = new WebClient())
            {
                try
                {
                    var defaultFeedUrl = "https://cointelegraph.com/rss/tag/blockchain";
                    var feedUrl = RenderingContext.Current.Rendering.Parameters["feedUrl"];
                    feed = client.DownloadString(feedUrl ?? defaultFeedUrl);
                }
                catch(Exception e) {
                    Response.Write(e.Message);
                }
            }
            var newsItems = new RssParser().Parse(feed);
            return View(newsItems);
        }
    }
}