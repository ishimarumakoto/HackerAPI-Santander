using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HackerAPI_Santander.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HackerAPI_Santander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        // GET: api/API
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet]
        public async Task<string> ReturnBestStoriesAsync()
        {
            //Get first best 20
            var requestBestStories = WebRequest.Create(@"https://hacker-news.firebaseio.com/v0/beststories.json");
            var responseBestStories = await requestBestStories.GetResponseAsync().ConfigureAwait(false);

            var responseBestStoriesReader = new StreamReader(responseBestStories.GetResponseStream());
            var responseBestStorieseData = await responseBestStoriesReader.ReadToEndAsync();

            //mount array with first 20 values
            var PostsIds = JArray.Parse(responseBestStorieseData);

            List<string> best20 = new List<string>();
            for (int i = 0; i < 20; i++)
            {
                best20.Add(PostsIds[i].ToString());
            }

            //Pick The Value from the 20 bests

            List<Post> listBest20 = new List<Post>;

            foreach (var item in best20)
            {
                string urlPost = @"https://hacker-news.firebaseio.com/v0/item/" + item + ".json";

                var requestBestPost = WebRequest.Create(urlPost);
                var responseBestPost = await requestBestPost.GetResponseAsync().ConfigureAwait(false);

                var responseBestPostReader = new StreamReader(responseBestPost.GetResponseStream());
                var responseBestPostData = await responseBestPostReader.ReadToEndAsync();

                var result = JsonConvert.DeserializeObject<Post>(responseBestPostData);

                listBest20.Add(result);

            }


            


            return responseBestStorieseData.ToString();
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
