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

namespace GenshinImpactFanpage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string file_location = "../Images/lightbox_images/";
            List<string> images = new List<string>();
            List<string> images_c = new List<string>();
            var chara = CharacterProcessor.GetLatestCharacter(); // Get the latest character and store it inside variable "chara".

            for(int i = 1; i<=4; i++)
            {
                images.Add(file_location+"lightbox_"+i+".jpg");
            }

            for (int i = 1; i <= 4; i++)
            {
                images_c.Add(file_location + "lightbox_center_" + i + ".jpg");
            }
            
            ViewBag.genshinImages = images;
            ViewBag.genshinImages_center = images_c;
            ViewBag.recentCharacter = chara;
            return View();
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
