﻿using System;
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

                // Output: "username" <email> [userid]
                var userAsString =
                    "\"" + snykUser.username + "\"" +
                    " <" + snykUser.email + "> " + 
                    "["  + snykUser.id + "]";
                
                Console.WriteLine(userAsString);

//                Console.WriteLine("\n\nAccess:\n" + JsonSerializer.Serialize(snykUser.orgs, new JsonSerializerOptions() { WriteIndented = true }));

            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }

        }
    }
}
