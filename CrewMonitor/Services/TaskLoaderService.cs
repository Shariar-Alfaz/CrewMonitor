using CrewMonitor.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrewMonitor.Services
{
    public class TaskLoaderService
    {
        private HttpClient _httpClient;
        private HttpRequestMessage request;

        public Student GetMe()
        {
            string json = File.ReadAllText("D:\\Monitor\\me.json");
            var student = JsonConvert.DeserializeObject<Student>(json);
            return student;
        }

        public async Task<List<ClassTaskDto>> LoadTask()
        {
            string json = File.ReadAllText("D:\\Monitor\\me.json");
            var student = JsonConvert.DeserializeObject<Student>(json);

            this.request = new HttpRequestMessage(HttpMethod.Get, @"https://localhost:7022/Monitor/api/Get/ClassTask/"+student.Id);
            request.Headers.Add("Accept", "application/json");
            
            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                var s = new List<ClassTaskDto>();
                s = JsonConvert.DeserializeObject<List<ClassTaskDto>>(res);
                return s;
            }
            return null;
        }
    }
}
