using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MVCClient.Controllers
{
    public class TransactionController : Controller
    {
        string Baseurl = "https://localhost:44323/";
        public async Task<IActionResult> Index()
        {
            List<Transactions> Info = new List<Transactions>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44323/api/Transactions");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    Info = JsonConvert.DeserializeObject<List<Transactions>>(EmpResponse);

                }
                //returning the employee list to view  
                return View(Info);
            }

        }
        public async Task<IActionResult> AddTrans()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTrans(Transactions b)
        {
            b.TransId = 0;
            b.Balance = 1000;
            string accno = HttpContext.Session.GetString("accno");
            if (accno == b.AccNo)
            {
                Transactions obj = new Transactions();
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(b), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("https://localhost:44323/api/Transactions", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        
                    }
                }
                return RedirectToAction("Details");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTrans(int id)
        {
            List<Transactions> bank = new List<Transactions>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44323/api/Transactions/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    bank = JsonConvert.DeserializeObject<List<Transactions>>(apiResponse);
                }
            }

            return View(bank);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTrans(Transactions t)
        {
             Transactions receivedemp = new Transactions();

            using (var httpClient = new HttpClient())
            {

                string accno = t.AccNo;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:44323/api/Transactions/" + accno, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    receivedemp = JsonConvert.DeserializeObject<Transactions>(apiResponse);
                }
            }
            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<ActionResult> DeleteTrans(int id)
        {
            List<Transactions> info = new List<Transactions>();
             Transactions t = new Transactions();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44323/api/Transactions/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    info = JsonConvert.DeserializeObject<List<Transactions>>(apiResponse);
                }
            }

            return View();
        }
        [HttpPost]
        [ActionName("DeleteTrans")]
        public async Task<ActionResult> DeleteTrans(Transactions t)
        {

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44323/api/Transactions/" + t.TransId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");


        }
        public async Task<IActionResult> Details()
        {
            List<Transactions> Info = new List<Transactions>();
            List<Transactions> trans = new List<Transactions>();
            string accno = HttpContext.Session.GetString("accno");
            using(var client=new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44323/api/Transactions");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    Info = JsonConvert.DeserializeObject<List<Transactions>>(EmpResponse);
                }
                trans = Info.Where(c => c.AccNo == accno).Select(i=>i).ToList();
                return View(trans);
            }
        }

    }
}
