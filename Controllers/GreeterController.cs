using Sitecore.Education.Templates.Models;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Education.Templates.Controllers
{
    public class GreeterController : Controller
    {
        // GET: Greeter
        public ActionResult Index()
        {
            var item = RenderingContext.Current.Rendering.Item;
            var greeting = new Greeting()
            {
                Message = new HtmlString(FieldRenderer.Render(item, "message")),
                GreetingImage = new HtmlString(FieldRenderer.Render(item, "greetingimage"))
            };
            return View(greeting);
        }
    }
}