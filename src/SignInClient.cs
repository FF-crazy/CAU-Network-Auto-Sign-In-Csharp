using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AutoSignIn
{
    public class SignInClient
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly string _url;

        public SignInClient(string url)
        {
            _url = url;
        }

        public async Task<bool> SignInAsync(string username, string password)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            try
            {
                var response = await _client.PostAsync(_url, content);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
