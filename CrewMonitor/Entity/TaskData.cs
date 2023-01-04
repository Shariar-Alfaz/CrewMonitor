using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrewMonitor.Services;

namespace CrewMonitor.Entity
{
    public partial class TaskData : UserControl
    {
        private int count;
        private static bool start = false;
        private Thread monitor;
        private DelegateService.HideForm hideForm { get; set; }
        private KeyboardHook keyboardHook;
        private TaskLoaderService service;

        private TaskData()
        {
            InitializeComponent();
            this.service = new TaskLoaderService();
            btnStop.Hide();
        }

        public TaskData(DelegateService.HideForm aForm):this()
        {
            this.hideForm = aForm;
        }
        private void keyboardHook_KeyUp(KeyboardHook.VKeys key)
        {
            this.lblCount.Text=count++.ToString();
        }
        private void keyboardHook_KeyDown(KeyboardHook.VKeys key)
        {

        }


        private int _id;
        private string _name;
        private string _description;

        [Category("Custom Props")]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [Category("Custom Props")]
        public string TaskName
        {
            get { return _name; }
            set { _name = value; lblTaskName.Text = value; }
        }

        [Category("Custom Props")]
        public string Description
        {
            get { return _description; }
            set { _description = value; lblDescription.Text = value; }
        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {
            keyboardHook = new KeyboardHook();
            if (start )
            {
                MessageBox.Show("A task is allready in monitoring. please stop the previous task for monitor new task",
                    "Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            monitor = new Thread(CallBack);
            start = true;
            monitor.Start();
            keyboardHook.KeyUp += new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyUp);
            keyboardHook.Install();
            btnMonitor.Hide();
            btnStop.Show();
            hideForm();
        }

        private async void CallBack()
        {
            while(start)
            {
                Thread.Sleep(5000);
                //Todo screenShoot code here
                var capture = new Bitmap(Screen.PrimaryScreen.Bounds.Width,Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
                Rectangle captuRectangle = Screen.AllScreens[0].Bounds;
                Graphics captureGraphics = Graphics.FromImage(capture);
                captureGraphics.CopyFromScreen(captuRectangle.Left, captuRectangle.Top, 0, 0, captuRectangle.Size);
                var getCurrentDir = Directory.GetCurrentDirectory();
                capture.Save(@"D:\monitor\img\img.jpg", ImageFormat.Jpeg);
                var file = new FileStream( @"D:\monitor\img\img.jpg", FileMode.Open);
                //Todo screenShoot 
                await this.service.UploadTask(file,this.Id,this.count);
                this.count = 0;
                file.Close();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                start = false;
                monitor.Abort();
                btnMonitor.Show();
                btnStop.Hide();
                keyboardHook.Uninstall();
            }
            catch (Exception ex)
            {
                // ignored
            }
        }
    }

}
