using Newtonsoft.Json;
using Sitecore.Education.Templates.Models;
using System;
using System.Net;
using System.Web.Mvc;

namespace Sitecore.Education.Templates.Controllers
{
    public class NasaNewsController : Controller
    {
        // GET: NASANews
        public ActionResult Index()
        {
            var myNews = new News();
            using (var client = new WebClient())
            {
                var address = "https://api.nasa.gov/planetary/apod?" +
                    "api_key=bhlTzfQRMR5NniLvEITra1nMgqHYM5ljRUXo9V1S&date=" + GetRandomDate();
                var httpResponse = client.DownloadString(address);
                myNews = JsonConvert.DeserializeObject<News>(httpResponse);
            }
            return View(myNews);
        }

        private string GetRandomDate()
        {
            var start = new DateTime(1995, 1, 1);
            var span = DateTime.Now.Subtract(start).TotalDays;
            var numberOfDays = Math.Floor(span * new Random().NextDouble());
            return start.AddDays(numberOfDays).ToString("yyyy-MM-dd");
        }
    }
}