using System;
using System.Threading.Tasks;

namespace AutoSignIn
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            string? username = null;
            string? password = null;
            string url = "https://example.com/login";

            foreach (var arg in args)
            {
                if (arg.StartsWith("--username="))
                    username = arg.Substring("--username=".Length);
                else if (arg.StartsWith("--password="))
                    password = arg.Substring("--password=".Length);
                else if (arg.StartsWith("--url="))
                    url = arg.Substring("--url=".Length);
            }

            username ??= Environment.GetEnvironmentVariable("CAU_USERNAME");
            password ??= Environment.GetEnvironmentVariable("CAU_PASSWORD");

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                Console.Error.WriteLine("Provide username and password via arguments or environment variables CAU_USERNAME and CAU_PASSWORD.");
                return 1;
            }

            var client = new SignInClient(url);
            bool success = await client.SignInAsync(username, password);
            Console.WriteLine(success ? "Sign in successful." : "Sign in failed.");
            return success ? 0 : 1;
        }
    }
}
