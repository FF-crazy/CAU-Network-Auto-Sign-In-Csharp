using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AutoSignIn
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string username = Environment.GetEnvironmentVariable("CAU_USERNAME") ?? "";
            string password = Environment.GetEnvironmentVariable("CAU_PASSWORD") ?? "";
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                Console.Error.WriteLine("Please set CAU_USERNAME and CAU_PASSWORD environment variables.");
                return;
            }

            try
            {
                using (var client = new HttpClient())
                {
                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("username", username),
                        new KeyValuePair<string, string>("password", password)
                    });
                    // The actual sign-in URL may differ; update as needed.
                    var response = await client.PostAsync("https://example.com/login", content);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Sign in successful.");
                    }
                    else
                    {
                        Console.Error.WriteLine($"Sign in failed: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
