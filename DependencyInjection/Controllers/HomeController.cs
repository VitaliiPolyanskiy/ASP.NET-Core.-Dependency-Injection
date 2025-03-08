using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Services;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        IEnumerable<IMessageSender> _sendersServices;
        public HomeController(IEnumerable<IMessageSender> sendersServices)
        {
            _sendersServices = sendersServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2([FromServices] IMessageSender sender)
        {
            Response.ContentType = "text/html; charset=utf-8";
            return Content($"<h1>{sender.Send()}</h1>");
        }
        public IActionResult Index3()
        {
            Response.ContentType = "text/html; charset=utf-8";
            var sender = HttpContext.RequestServices.GetService<IMessageSender>();
            return Content($"<h1>{sender.Send()}</h1>");
        }
        public IActionResult Index4()
        {
            Response.ContentType = "text/html; charset=utf-8";
            string responseText = "";
            foreach (var service in _sendersServices)
            {
                responseText += $"<h1>{service.Send()}</h1>";
            }
            return Content(responseText);
        }
    }
}
