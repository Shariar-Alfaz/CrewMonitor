using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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

        private TaskData()
        {
            InitializeComponent();
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
                Thread.Sleep(200);
                //Todo screenShoot code here
                //Todo screenShoot upload code here
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
