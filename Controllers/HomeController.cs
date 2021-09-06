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
        private readonly IWebHostEnvironment _Environment; // used for getting the path to wwwroot.

        public HomeController(IWebHostEnvironment Environment)
        {
            _Environment = Environment; 
        }

        public IActionResult Index()
        {
            string file_location = "../Images/lightbox_images/"; // path to the images.
            var chara = CharacterProcessor.GetLatestCharacter(); // Get the latest character and store it inside variable "chara".
            string path = Path.Combine(_Environment.WebRootPath, "DocumentFolder", "GenshinHistory.txt"); // path to wwwroot.
            string line;
            List<string> allImages = new List<string>();

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

            foreach (var img in images(file_location, "lightbox_", ".jpg")){
                allImages.Add(img);
            }

            foreach (var img in images(file_location, "lightbox_center_", ".jpg"))
            {
                allImages.Add(img);
            }

            ViewBag.genshinAllImages = allImages;
            ViewBag.genshinImages = images(file_location, "lightbox_",".jpg");
            ViewBag.genshinImages_center = images(file_location, "lightbox_center_", ".jpg");
            ViewBag.recentCharacter = chara;
            TempData["Item"] = sb;
            TempData["Paimon"] = "../Images/paimon.png";
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


        public IActionResult CharacterList()
        {
            ViewBag.getAllCharacters = CharacterProcessor.GetAllCharacter();
            return View();
        }

        [HttpGet]
        public IActionResult CreateCharacter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCharacter(CharacterModel cm)
        {
            if (ModelState.IsValid) // if there's no errors.
            {
                // character will be added.
                CharacterProcessor.CreateCharacter(
                    cm.Name,
                    cm.Rarity,
                    cm.Birthday,
                    cm.Allegiance,
                    cm.Element,
                    cm.Image,
                    cm.Description
                    );
                ViewData["Successful"] = cm.Name;
                return RedirectToAction("CreateCharacter");
                
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
