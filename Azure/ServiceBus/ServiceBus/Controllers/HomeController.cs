using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace ServiceBus.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string connectionString = "Endpoint=sb://kalyazin.servicebus.windows.net/;SharedAccessKeyName=producer;SharedAccessKey=O3uttOYGpuLH3W2SaGhC6FI3b6Z7ikyP0OIozlqWSeU=";
            var client = QueueClient.CreateFromConnectionString(connectionString, "kalyazin-queue");

            var message = new BrokeredMessage("Message was sent at " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss;"));
            client.Send(message);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}