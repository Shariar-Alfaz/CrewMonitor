using CrewMonitor.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrewMonitor.Services
{
    public class TaskLoaderService
    {
        public Student GetMe()
        {
            string json = File.ReadAllText("D:\\Monitor\\me.json");
            var student = JsonConvert.DeserializeObject<Student>(json);
            return student;
        }
    }
}
