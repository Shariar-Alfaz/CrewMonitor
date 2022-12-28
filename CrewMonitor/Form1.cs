using CrewMonitor.Entity;
using CrewMonitor.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrewMonitor
{
    public partial class Form1 : Form
    {
      
        private readonly TaskLoaderService taskLoaderService;
        private DelegateService.HideForm hideForm { get; set; }
        public Form1()
        {
            InitializeComponent();
            this.taskLoaderService = new TaskLoaderService();
            this.hideForm = HideThis;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var s = this.taskLoaderService.GetMe();
            this.lblName.Text = s.Name;
            await this.populateItem();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }


        public async Task populateItem()
        {
            var taskDatas = await this.taskLoaderService.LoadTask();
            var control = new TaskData[taskDatas.Count];
            for (int i = 0;i < control.Length;i++) 
            {
                control[i] = new TaskData(hideForm);
                control[i].TaskName = taskDatas[i].Name;
                control[i].Description = taskDatas[i].Description;

                if(flowLayoutPanel1.Controls.Count < 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                }
                else
                    flowLayoutPanel1.Controls.Add(control[i]);
            }

        }

        private void HideThis()
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
