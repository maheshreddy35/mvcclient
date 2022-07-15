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
using VisioForge.Libs.MediaFoundation.OPM;


namespace MVCClient.Controllers
{
    public class BankController : Controller
    {
        string Baseurl = "https://localhost:44323/";
        public async Task<IActionResult> Index()
        {
            List<Bank> Info = new List<Bank>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44323/api/BankAccounts");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    Info = JsonConvert.DeserializeObject<List<Bank>>(EmpResponse);

                }
                //returning the employee list to view  
                return View(Info);
            }
            
        }
        public async Task<IActionResult> AddAccount()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAccount(Bank b)
        {
            HttpContext.Session.SetString("accno", b.AccNo);
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(b), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44323/api/BankAccounts", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    
                }
            }
            return RedirectToAction("Details");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAccount(string id)
        {
            List<Bank> bank = new List<Bank>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44323/api/BankAccounts/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    bank = JsonConvert.DeserializeObject<List<Bank>>(apiResponse);
                }
            }
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAccount(Bank b)
        {
            Bank receivedemp = new Bank();

            using (var httpClient = new HttpClient())
            {
                
                string accno= b.AccNo;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(b), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:44323/api/BankAccounts/" + accno, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    receivedemp = JsonConvert.DeserializeObject<Bank>(apiResponse);
                }
            }
            return RedirectToAction("index");
        }
        
        [HttpGet]
        public async Task<ActionResult> DeleteAccount(string accno)
        {
            List<Bank> info = new List<Bank>();
            Bank b = new Bank();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44323/api/BankAccounts/" + accno))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    info = JsonConvert.DeserializeObject<List<Bank>>(apiResponse);
                }
            }
            
            return View(b);
        }
        [HttpPost]
        [ActionName("DeleteAccount")]
        public async Task<ActionResult> DeleteAccount(Bank b)
        {
            
              using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync("https://localhost:44323/api/BankAccounts/" + b.AccNo))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
                return RedirectToAction("Index");
           
            
        }
        public async Task<IActionResult> Details(string accno)
        {
            accno = HttpContext.Session.GetString("accno");
            List<Bank> Info = new List<Bank>();
            Bank bank = new Bank();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44323/api/BankAccounts");
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    Info = JsonConvert.DeserializeObject<List<Bank>>(EmpResponse);
                    
                }
                bank = Info.Where(c=>c.AccNo==accno).FirstOrDefault();
                //returning the employee list to view  
                return View(bank);
            }
        

        }
        public async Task<IActionResult> logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
