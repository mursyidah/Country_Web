using Country_test.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Country_test.Controllers
{
    public class CountryController : Controller
    {
        // GET: Country


        //Hosted web API REST Service base url  
        string Baseurl = "https://restcountries.eu/rest/v2/all";
        public async Task<ActionResult> Index()
        {
            List<Country> name = new List<Country>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("https://restcountries.eu/rest/v2/all");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    name = JsonConvert.DeserializeObject<List<Country>>(EmpResponse);

                }
                //returning the employee list to view  
                return View(name);
            }
        }
    }
}
