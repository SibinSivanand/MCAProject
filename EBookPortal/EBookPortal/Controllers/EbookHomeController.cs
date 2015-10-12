using EBookPortal.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace EBookPortal.Controllers
{
    public class EbookHomeController : Controller
    {
        // GET: EbookHome
        public ActionResult Index()
        {
            BookViewModel bookViewModel = new BookViewModel();
            bookViewModel.HeaderQuote = GetRandomQuoteFromJson();
            return View();
        }

        /// <summary>
        /// Get Random Quote to show in Home Page
        /// </summary>
        /// <returns></returns>
        private string GetRandomQuoteFromJson()
        {
            string appPath = HostingEnvironment.ApplicationPhysicalPath;
            var jsonPath = appPath + "\\Json\\Quotes.json";
            using (StreamReader reader = new StreamReader(jsonPath))
            {
                string jsonString = reader.ReadToEnd();
                dynamic jsonArray = JsonConvert.DeserializeObject(jsonString);
                var random = new Random();
                return jsonArray.quotesOnReading[random.Next(0, jsonArray.quotesOnReading.Count)].quote;
            }
        }
    }
}