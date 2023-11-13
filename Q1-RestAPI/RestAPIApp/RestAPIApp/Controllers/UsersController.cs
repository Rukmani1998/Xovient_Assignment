using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using RestAPIApp.Models;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace RestAPIApp.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IConfiguration configuration;        
        private readonly HttpClient _client; 
        public UsersController(IConfiguration iConfig)
        {
            _client = new HttpClient();
            configuration = iConfig;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Users>> GetUsers()
        {
            try
            {
                Uri JsonUrl = new Uri(configuration.GetSection("MySettings").GetSection("JsonURL").Value);
                _client.BaseAddress = JsonUrl;
                var users = new List<Users>();

                HttpResponseMessage response = _client.GetAsync(JsonUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = response.Content.ReadAsStringAsync().Result;
                    users = JsonConvert.DeserializeObject<List<Users>>(jsonString);
                }

                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
