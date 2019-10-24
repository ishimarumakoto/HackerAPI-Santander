using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HackerAPI_Santander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        // GET: api/API
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public async Task<JsonResult> ReturnBestStoriesAsync()
        {
            //Get first best 20
            var request = WebRequest.Create(@"https://hacker-news.firebaseio.com/v0/beststories.json");
            var response = await request.GetResponseAsync().ConfigureAwait(false);

            var responseReader = new StreamReader(response.GetResponseStream());
            var responseData = await responseReader.ReadToEndAsync();

                

        }


        // GET: api/API/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/API
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/API/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
