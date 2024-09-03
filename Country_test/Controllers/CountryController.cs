using Country_test.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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


        private readonly string Baseurl = "https://restcountries.com/";

        public async Task<ActionResult> Index()
        {
            List<Country> name = new List<Country>();

            // Ensure TLS 1.2 or higher is used
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Bypass certificate validation (not recommended for production)
            HttpClientHandler handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            using (var client = new HttpClient(handler))
            {
                // Passing service base URL
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                // Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Sending request to find web API REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("v3.1/all");

                // Checking if the response is successful
                if (Res.IsSuccessStatusCode)
                {
                    // Storing the response details received from the web API
                    var EmpResponse = await Res.Content.ReadAsStringAsync();

                    // Deserializing the response received from the web API and storing it into the Country list
                    name = JsonConvert.DeserializeObject<List<Country>>(EmpResponse);
                }
                else
                {
                    // Log the response status code for debugging
                    Console.WriteLine($"Error: {Res.StatusCode}");
                }
            }

            // Returning the Country list to the view
            return View(name);
        }
    }
}
