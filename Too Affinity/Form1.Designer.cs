namespace Too_Affinity
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.startWithWindowsCb = new System.Windows.Forms.CheckBox();
            this.startMinimizedCb = new System.Windows.Forms.CheckBox();
            this.disableFirstCoreCb = new System.Windows.Forms.CheckBox();
            this.disableHtCb = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Too Affinity";
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 139);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(234, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(97, 17);
            this.toolStripStatusLabel1.Text = "Waiting for csgo.";
            // 
            // startWithWindowsCb
            // 
            this.startWithWindowsCb.AutoSize = true;
            this.startWithWindowsCb.Location = new System.Drawing.Point(12, 62);
            this.startWithWindowsCb.Name = "startWithWindowsCb";
            this.startWithWindowsCb.Size = new System.Drawing.Size(130, 19);
            this.startWithWindowsCb.TabIndex = 1;
            this.startWithWindowsCb.Text = "Start With Windows";
            this.startWithWindowsCb.UseVisualStyleBackColor = true;
            this.startWithWindowsCb.CheckedChanged += new System.EventHandler(this.startWithWindowsCb_CheckedChanged);
            // 
            // startMinimizedCb
            // 
            this.startMinimizedCb.AutoSize = true;
            this.startMinimizedCb.Location = new System.Drawing.Point(12, 87);
            this.startMinimizedCb.Name = "startMinimizedCb";
            this.startMinimizedCb.Size = new System.Drawing.Size(109, 19);
            this.startMinimizedCb.TabIndex = 2;
            this.startMinimizedCb.Text = "Start Minimized";
            this.startMinimizedCb.UseVisualStyleBackColor = true;
            this.startMinimizedCb.CheckedChanged += new System.EventHandler(this.startMinimizedCb_CheckedChanged);
            // 
            // disableFirstCoreCb
            // 
            this.disableFirstCoreCb.AutoSize = true;
            this.disableFirstCoreCb.Location = new System.Drawing.Point(12, 12);
            this.disableFirstCoreCb.Name = "disableFirstCoreCb";
            this.disableFirstCoreCb.Size = new System.Drawing.Size(117, 19);
            this.disableFirstCoreCb.TabIndex = 3;
            this.disableFirstCoreCb.Text = "Disable First Core";
            this.disableFirstCoreCb.UseVisualStyleBackColor = true;
            this.disableFirstCoreCb.CheckedChanged += new System.EventHandler(this.disableFirstCoreCb_CheckedChanged);
            // 
            // disableHtCb
            // 
            this.disableHtCb.AutoSize = true;
            this.disableHtCb.Location = new System.Drawing.Point(12, 37);
            this.disableHtCb.Name = "disableHtCb";
            this.disableHtCb.Size = new System.Drawing.Size(138, 19);
            this.disableHtCb.TabIndex = 4;
            this.disableHtCb.Text = "Disable Hyperthreads";
            this.disableHtCb.UseVisualStyleBackColor = true;
            this.disableHtCb.CheckedChanged += new System.EventHandler(this.disableHtCb_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 161);
            this.Controls.Add(this.disableHtCb);
            this.Controls.Add(this.disableFirstCoreCb);
            this.Controls.Add(this.startMinimizedCb);
            this.Controls.Add(this.startWithWindowsCb);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Too Affinity";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NotifyIcon notifyIcon1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private CheckBox startWithWindowsCb;
        private CheckBox startMinimizedCb;
        private CheckBox disableFirstCoreCb;
        private CheckBox disableHtCb;
    }
}