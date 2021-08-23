using DataLibrary.Models;
using GenshinImpactFanpage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.BusinessLogic;
using System.Text;
using Microsoft.AspNetCore.Hosting;

namespace GenshinImpactFanpage.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _Environment;

        public HomeController(IWebHostEnvironment Environment)
        {
            _Environment = Environment;
        }

        public IActionResult Index()
        {
            string file_location = "../Images/lightbox_images/";
            var chara = CharacterProcessor.GetLatestCharacter(); // Get the latest character and store it inside variable "chara".
            string path = Path.Combine(_Environment.WebRootPath, "DocumentFolder", "GenshinHistory.txt");
            string line;

            StringBuilder sb = new StringBuilder();
            try
            {

                StreamReader sr = new StreamReader(path);

                line = sr.ReadLine();

                while (line != null)
                {
                    sb.Append(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }


            ViewBag.genshinImages = images(file_location, "lightbox_",".jpg");
            ViewBag.genshinImages_center = images(file_location, "lightbox_center_", ".jpg");
            ViewBag.recentCharacter = chara;
            TempData["Item"] = sb;
            return View();
        }

        // loop to add all the images inside a list to send it to the front-end. 
        public List<String> images(string fileLocation, string namePrefix, string fileType)
        {
            List<string> imageList = new List<string>();

            for (int i = 1; i <= 4; i++)
            {
                imageList.Add(fileLocation + namePrefix + i + fileType);
            }

            return imageList;
        }


        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult CreateCharacter(CharacterModel cm)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CharacterProcessor.CreateCharacter(
                    cm.Id,
                    cm.Name,
                    cm.Rarity,
                    cm.Birthday,
                    cm.Allegiance,
                    cm.Element,
                    cm.Image,
                    cm.Description
                    );
                return RedirectToAction("Index");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
