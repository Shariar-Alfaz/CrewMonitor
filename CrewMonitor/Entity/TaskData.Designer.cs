namespace CrewMonitor.Entity
{
    partial class TaskData
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTaskName = new System.Windows.Forms.Label();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTaskName
            // 
            this.lblTaskName.AutoSize = true;
            this.lblTaskName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblTaskName.Location = new System.Drawing.Point(7, 13);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(53, 20);
            this.lblTaskName.TabIndex = 0;
            this.lblTaskName.Text = "label1";
            // 
            // btnMonitor
            // 
            this.btnMonitor.BackColor = System.Drawing.SystemColors.Info;
            this.btnMonitor.Location = new System.Drawing.Point(497, 6);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(75, 33);
            this.btnMonitor.TabIndex = 1;
            this.btnMonitor.Text = "Monitor";
            this.btnMonitor.UseVisualStyleBackColor = false;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnStop.Location = new System.Drawing.Point(584, 6);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 33);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            // 
            // TaskData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnMonitor);
            this.Controls.Add(this.lblTaskName);
            this.Name = "TaskData";
            this.Size = new System.Drawing.Size(675, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTaskName;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.Button btnStop;
    }
}
