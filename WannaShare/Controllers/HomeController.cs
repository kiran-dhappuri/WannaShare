using ShareFoodService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WannaShare.Controllers
{
    public class HomeController : Controller
    {
        public IShareFoodService _service;
        public HomeController(IShareFoodService service)
        {
            _service = service;
        }
        public ActionResult Index()
        {
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

        public ActionResult Address()
        {
            ViewBag.Message = "Select address.";
            return View();
        }

        public async Task<ActionResult> List()
        {
            var res = await _service?.GetFoodItems();

            return View(res);
        }

        /// <summary>
        /// ToDO: Remove this code.  Testing purposes only.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> AddFood()
        {
            await _service.SaveFoodItems();
            return RedirectToAction("Index");
        }
    }
}