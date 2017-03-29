using ClintConvertiseurV1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClintConvertiseurV1.Service
{
    public class WSService
    {

        private static WSService instance;
        public static WSService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WSService();
                }
                return instance;
            }
        }

        private HttpClient client;

        public WSService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2733/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Devise>> getAllDeviseAsync()
        {
           
            List<Devise> d = new List<Devise>();
            HttpResponseMessage response = await client.GetAsync("Devise");
            if (response.IsSuccessStatusCode)
            {
                d = await response.Content.ReadAsAsync<List<Devise>>();
            }
            return d;
        }



    }
}
