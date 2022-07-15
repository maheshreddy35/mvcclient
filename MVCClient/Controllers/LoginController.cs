using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MVCClient.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> login(Bank b)
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
                var res = Info.Where(c => c.AccNo == b.AccNo && c.Password == b.Password).FirstOrDefault();
                if (res != null)
                {
                    HttpContext.Session.SetString("uname", res.AccHolderName);
                    HttpContext.Session.SetString("accno", res.AccNo);
                    return RedirectToAction("Index","Login");
                }
                else
                {
                    return View();
                }
            }
        }
    }
}
