using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace ConfigureEFDbContext.MSUnitTest.Extensions
{
    public static class ContentExtensions
    {
        public static StringContent ToJsonContent<T>(this T obj) => new StringContent(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json");
    }
}
