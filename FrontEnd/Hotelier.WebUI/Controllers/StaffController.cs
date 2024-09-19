using Hotelier.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hotelier.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44367/api/Staff");
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<StaffViewModel>>(JsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsdata = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsdata, Encoding.UTF8, "application/json");
            var ResponseMessage = await client.PostAsync("https://localhost:44367/api/Staff", stringContent);
            if (ResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            else
            {
                return View();
            }

        }

        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44367/api/Staff/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44367/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsdata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsdata);
                return View(values);

            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsdata = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsdata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44367/api/Staff/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();

        }



    }
}
