using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrewMonitor.Tools
{
    public class APICall<T>
    {
        public string URL { get; set; }

        private HttpClient _httpClient;

        public APICall()
        {
            this._httpClient = new HttpClient();
        }

        //public T Post()
    }
}
