using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp
{
    public interface IGatewayService<T>
    {
        string postData(string url, T payload);
        IEnumerable<T> getAllData(string apiBase);
        Q getData<Q>(string apiBase);
        string getStringData(string apiBase);
        string deleteData(string apiBase);
        string putData(string apiBase, T body);
    }
}