using AspMvcQuestRoom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AspMvcQuestRoom.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db = new ApplicationContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            return View("Index", await db.QuestRooms.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Delete()
        {
            return View("Delete");
        }
        public async Task<IActionResult> Edit()
        {
            return View("Edit");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> CreateTab(QuestRoom room)
        {
            db.QuestRooms.Add(room);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteTab(QuestRoom room)
        {
            var at = db.QuestRooms.ToList();
            foreach (QuestRoom a in at)
            {
                if (a.Name == room.Name)
                {
                    db.QuestRooms.Remove(a);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditTab(QuestRoom room)
        {
            var at = db.QuestRooms.ToList();
            foreach (QuestRoom a in at)
            {
                if (a.Name == room.Name & room.Difficult == null & room.Difficult == null & room.Users == null & room.Fear == null)
                { 
                    db.QuestRooms.Remove(a);
                    await db.SaveChangesAsync();
                    return View("Edit", a);                 
                }
                if (room.Name != null & room.Difficult != null & room.Users != null & room.Fear != null)
                {              
                    db.QuestRooms.Add(room);
                    await db.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}