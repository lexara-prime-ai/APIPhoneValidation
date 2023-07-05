using Microsoft.AspNetCore.Mvc;
using Phone_Number_Verification.Models;

namespace Phone_Number_Verification.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneVerification : ControllerBase
    {
        [HttpGet]
        // [Route("{phone}")]
        public IActionResult Get()
        {
            string API_KEY = "**********";
            string PHONE_NUMBER = "**********";

            using (var httpClient = new HttpClient())
            {
                string API_URL = $"https://phonevalidation.abstractapi.com/v1/?api_key={API_KEY}&phone={PHONE_NUMBER}";

                try
                {
                    var response = httpClient.GetAsync(API_URL).Result;
                    response.EnsureSuccessStatusCode();

                    var responseBody = response.Content.ReadAsStringAsync().Result;

                    return Ok(responseBody);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}