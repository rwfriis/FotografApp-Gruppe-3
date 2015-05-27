using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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

                try
                {
                    var response = client.GetAsync("api/Users").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var orders = response.Content.ReadAsAsync<List<Users>>().Result;
                        Console.WriteLine(orders.Count());
                        foreach (var order in orders)
                        {
                            Console.WriteLine(order);
                        }
                        Console.WriteLine("done");
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            Console.ReadKey();
        }
    }
}
