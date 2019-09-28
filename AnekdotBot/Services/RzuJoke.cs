using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace AnekdotBot.Services
{
    class RzuJoke : IJoke
    {
        private const string Url = "http://rzhunemogu.ru/RandJSON.aspx?CType=";
        public async Task<string> Get(Category cat)
        {
            var client = new HttpClient();
            var s = await client.GetByteArrayAsync(Url + (int)cat);

            var result = JObject.Parse(Encoding.GetEncoding(1251).GetString(s));
            return result["content"].ToString();
        }
    }
}