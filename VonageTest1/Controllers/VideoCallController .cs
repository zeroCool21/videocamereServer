using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenTokSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VonageTest1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoCallController : ControllerBase
    {
        private const int API_KEY = 47764221;
        private const string API_SECRET = "f765eaaa9a0ffffabe10a39c038c9a498c17a274";
        private static OpenTok openTok = new OpenTok(API_KEY, API_SECRET);
        private static string currentSessionID = openTok.CreateSession().Id;


        [HttpGet("session")]
        public IActionResult GetSessionAndToken()
        {
            //var opentok = new OpenTok(API_KEY, API_SECRET);
            //string sessionId = opentok.CreateSession().Id;
            //string token = opentok.GenerateToken(sessionId);
            string sessionId = currentSessionID;
            string token = openTok.GenerateToken(sessionId);

            return Ok(new
            {
                ApiKey = API_KEY,
                SessionId = sessionId,
                Token = token
            });
        }
    }
}
