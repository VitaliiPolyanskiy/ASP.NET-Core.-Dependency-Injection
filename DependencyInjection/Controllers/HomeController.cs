using System.Text;
using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Services;

namespace DependencyInjection.Controllers;

// Використання первинного конструктора (C# 12) для ін'єкції колекції сервісів
public class HomeController(IEnumerable<IMessageSender> sendersServices) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Index2([FromServices] IMessageSender sender)
    {
        // Повернення контенту з автоматичним встановленням Content-Type та кодування
        return Content($"<h1>{sender.Send()}</h1>", "text/html", Encoding.UTF8);
    }

    public IActionResult Index3()
    {
        var sender = HttpContext.RequestServices.GetRequiredService<IMessageSender>();
        return Content($"<h1>{sender.Send()}</h1>", "text/html", Encoding.UTF8);
    }

    public IActionResult Index4()
    {
        var htmlContent = string.Join("", sendersServices.Select(service => $"<h1>{service.Send()}</h1>"));
        return Content(htmlContent, "text/html", Encoding.UTF8);
    }
}