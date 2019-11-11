using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp
{
    public class GatewayService<T> : IGatewayService<T>
    {
        public string postData(string url, T payload)
        {
            var client = new HttpClient();
            var response = client.PostAsJsonAsync(url, payload);
            return response.Result.Content.ReadAsStringAsync().Result;
        }

        public string putData(string url, T payload)
        {
            var client = new HttpClient();
            var response = client.PutAsJsonAsync(url, payload);
            return response.Result.Content.ReadAsStringAsync().Result;
        }

        public IEnumerable<T> getAllData(string url)
        {
            var client = new HttpClient();
            var response = client.GetAsync(url);
            return response.Result.Content.ReadAsAsync<List<T>>().Result;
        }

        public Q getData<Q>(string url)
        {
            var client = new HttpClient();
            var response = client.GetAsync(url);
            return response.Result.Content.ReadAsAsync<Q>().Result;
        }
        public string getStringData(string url)
        {
            var client = new HttpClient();
            var response = client.GetAsync(url);
            return response.Result.Content.ReadAsStringAsync().Result;
        }

        public string deleteData(string url)
        {
            var client = new HttpClient();
            var response = client.DeleteAsync(url);
            return response.Result.Content.ReadAsStringAsync().Result;
        }
    }
}
