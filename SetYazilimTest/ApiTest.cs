using DataAccess.Entities;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
namespace SetYazilimTest
{
    public class ApiTest 
    {
        private readonly HttpClient _httpClient;

        public ApiTest()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:44382/") };
        }

        [Fact]
        public async Task TestGet()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Employees/GetAll");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<EmployeeType>();
            Assert.NotNull(result);
        }
    }
}
