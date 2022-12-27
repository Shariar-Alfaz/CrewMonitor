using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CrewMonitor.Entity;
using Newtonsoft.Json;

namespace CrewMonitor.Services
{
    public class LoginService
    {
        private HttpClient _httpClient;
        private HttpRequestMessage request;

        public LoginService()
        {
            this._httpClient = new HttpClient();
           
        }

        public async Task<Student> Login(string username, string password)
        {
            this.request = new HttpRequestMessage(HttpMethod.Post, @"https://localhost:7022/Monitor/api/Login");
            request.Headers.Add("Accept","application/json");
            var login = new LoginDto()
            {
                Email = username,
                Password = password
            };
            string json = JsonConvert.SerializeObject(login);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string res=await response.Content.ReadAsStringAsync();
                var s = new Student();
                s = JsonConvert.DeserializeObject<Student>(res);
                return s;
            }
            return null;
        }

        public void SaveMe(Student student)
        {
            if (!Directory.Exists("D:\\Monitor"))
            {
                Directory.CreateDirectory(@"D:\Monitor");
                File.Create(@"D:\Monitor\me.json");
            }
            string json = JsonConvert.SerializeObject(student);
            File.WriteAllText("D:\\Monitor\\me.json", json);

        }
        public Student GetMe()
        {
            if(!Directory.Exists("D:\\Monitor"))
                return null;
            string json = File.ReadAllText("D:\\Monitor\\me.json");
            var student = JsonConvert.DeserializeObject<Student>(json);
            return student;
        }
    }
}
