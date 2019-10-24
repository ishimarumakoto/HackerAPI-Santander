using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Xunit;
using HackerAPI_Santander.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace HackerAPI_Santander_Tests
{
    public class GetTest
    {
        [Fact]
        public async System.Threading.Tasks.Task TestGetAsync()
        {
            // Arrange
            var controller = new APIController();

            // Act
            JObject ret = await controller.ReturnBestStoriesAsync();

            // Assert
            Assert.NotNull(ret);
            
        }
    }
}
