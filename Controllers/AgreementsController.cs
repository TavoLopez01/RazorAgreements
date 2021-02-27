using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RazorAgreements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RazorAgreements.Controllers
{
    public class AgreementsController: Controller
    {
        public async Task<IActionResult> Index()
        {
            List<AgreementsModel> agreementsList = new List<AgreementsModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44328/Agreements"))
                {
                    string result = await response.Content.ReadAsStringAsync();
                    agreementsList = JsonConvert.DeserializeObject<List<AgreementsModel>>(result);
                }
            }
            return View(agreementsList);
        }
    }
}
