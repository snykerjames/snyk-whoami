using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Collections.Generic;


namespace snyk_whoami
{
    class Program
    {
        private static readonly HttpClient theHttpClient = new HttpClient();

        private static HttpClient GetHttpClient() {

            Program.theHttpClient.DefaultRequestHeaders.Clear();
            Program.theHttpClient.DefaultRequestHeaders.Add("Authorization", "token " + System.Environment.GetEnvironmentVariable("SNYK_TOKEN"));
            Program.theHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            return theHttpClient;

        }
        static async Task Main(string[] args)
        {
            await WhoamiTask();
        }

        private static async Task WhoamiTask() {

            HttpClient client = GetHttpClient();

            try {

                var whoamiStreamTask = client.GetStreamAsync("https://snyk.io/api/v1/user/me");

                var snykUser = await JsonSerializer.DeserializeAsync<SnykUser>(await whoamiStreamTask);

                Console.WriteLine("      id: " + snykUser.id);
                Console.WriteLine("username: " + snykUser.username);
                Console.WriteLine("   email: " + snykUser.email);

            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }

        }
    }
}
