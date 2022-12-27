using CrewMonitor.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrewMonitor
{
    public partial class Form1 : Form
    {
        private int count;
        KeyboardHook keyboardHook = new KeyboardHook();
        private readonly TaskLoaderService taskLoaderService;
        public Form1()
        {
            InitializeComponent();
            this.taskLoaderService = new TaskLoaderService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var s = this.taskLoaderService.GetMe();
            this.lblName.Text = s.Name;
            keyboardHook.KeyUp += new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyUp);
            keyboardHook.Install();
        }
        private void keyboardHook_KeyUp(KeyboardHook.VKeys key)
        {
            lblName.Text = count++.ToString();
        }
        private void keyboardHook_KeyDown(KeyboardHook.VKeys key)
        {
           
        }
    }
}
