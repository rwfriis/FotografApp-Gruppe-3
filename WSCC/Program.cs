using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Webservice;

namespace WSCC
{
    class Program
    {
        static void Main(string[] args)
        {
            const string serverUrl = "http://localhost:55001";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("api/Users").Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var users = JsonConvert.DeserializeObject<List<Users>>(json);
                    Console.WriteLine(users.Count());
                    foreach (var user in users.Where(user => user.Password == "1234" && user.Email == "test"))
                    {
                        Console.WriteLine(user.Email);
                    }
                }
                else
                {
                    Console.WriteLine(response.StatusCode);
                }
            }
            Console.ReadKey();
        }
    }
}
