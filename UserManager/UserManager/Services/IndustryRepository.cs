using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserManager.Models;

namespace UserManager.Services
{
    class IndustryRepository
    {
        //HttpClient client;

        public List<Industry> Industries { get; private set; }

        public IndustryRepository()
        {
            //client = new HttpClient();
        }

        public async Task<List<Industry>> GetIndustries()
        {
            Industries = new List<Industry>();

            Uri uri = new Uri(String.Format(Constants.GetAllIndustriesURL, String.Empty));

            //HttpClientHandler handler = new HttpClientHandler();
            //handler.UseDefaultCredentials = true;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //HttpResponseMessage response = await client.GetAsync(uri);
                    //client.DefaultRequestHeaders.Clear();

                    HttpResponseMessage response = await client.GetAsync(uri);
                    //var response = await client.GetStringAsync(uri);
                    //var industries = JsonConvert.DeserializeObject<List<Industry>>(response);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        Industries = JsonConvert.DeserializeObject<List<Industry>>(content);
                    }
                    else
                    {
                        Console.WriteLine("nothing");
                    }
                }
                catch (System.Net.Http.HttpRequestException ex)
                {
                    Debug.WriteLine(@"\tERROR {0}", ex.Message);
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(@"\tERROR {0}", ex.Message);
                }
            }






            return Industries;
        }
    }
}
