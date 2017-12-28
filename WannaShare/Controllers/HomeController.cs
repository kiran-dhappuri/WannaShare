using MessageHelper.SMS;
using ShareFoodService.Models;
using ShareFoodService.Services;
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
        private ISMSService _smsService;
        public HomeController(IShareFoodService service, ISMSService smsService)
        {
            _service = service;
            _smsService = smsService;
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
        public async Task<ActionResult> AddFoodItem()
        {
            var item = new FoodItem() { };
            return View(item);
        }
        [HttpPost]
        public async Task<ActionResult> AddFoodItem(FoodItem item)
        {
            await _service.SaveFoodItems(new List<FoodItem>() { item });

            return View(item);
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
            var food = new FoodItem()
            {
                Name = "Test",
                Description = "Test Desc",
                PhoneNumbers = new PhoneNumber()
                    {
                         PhoneNum = "424-239-4327"
                    },
                Address = new Address()
                {
                    Line1 = "test1",
                    Line2 = "test2",
                    City = "city",
                    State = "state",
                    Counrty = "country"
                }
            };
            await _service.SaveFoodItems(new List<FoodItem>() { food });
            return RedirectToAction("Index");
        }

        public async Task SendTestSMS(string phone)
        {
            await _smsService.SendSMS(phone, "message from Kiran Dhappuri... howdy?? :D", "hi");
        } 
    }
}