using Hotelier.WebUI.Models.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hotelier.WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44367/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<TestimonialViewModel>>(JsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddTestimonial(TestimonialViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsdata = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsdata, Encoding.UTF8, "application/json");
            var ResponseMessage = await client.PostAsync("https://localhost:44367/api/Testimonial", stringContent);
            if (ResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            else
            {
                return View();
            }

        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44367/api/Testimonial/{id}");

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
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44367/api/Testimonial/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsdata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<TestimonialViewModel>(jsdata);
                return View(values);

            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(TestimonialViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsdata = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsdata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44367/api/Testimonial/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();

        }



    }
}

