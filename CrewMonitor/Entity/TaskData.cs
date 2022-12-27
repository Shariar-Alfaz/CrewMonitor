using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrewMonitor.Entity
{
    public partial class TaskData : UserControl
    {
        public TaskData()
        {
            InitializeComponent();
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




    }
    
    
    
}
