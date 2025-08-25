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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            notifyIcon1 = new NotifyIcon(components);
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            startWithWindowsCb = new CheckBox();
            startMinimizedCb = new CheckBox();
            disableFirstCoreCb = new CheckBox();
            disableHtCb = new CheckBox();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Too Affinity";
            notifyIcon1.DoubleClick += notifyIcon1_DoubleClick;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 139);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(234, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 17);
            // 
            // startWithWindowsCb
            // 
            startWithWindowsCb.AutoSize = true;
            startWithWindowsCb.Location = new Point(12, 62);
            startWithWindowsCb.Name = "startWithWindowsCb";
            startWithWindowsCb.Size = new Size(130, 19);
            startWithWindowsCb.TabIndex = 1;
            startWithWindowsCb.Text = "Start With Windows";
            startWithWindowsCb.UseVisualStyleBackColor = true;
            startWithWindowsCb.CheckedChanged += startWithWindowsCb_CheckedChanged;
            // 
            // startMinimizedCb
            // 
            startMinimizedCb.AutoSize = true;
            startMinimizedCb.Location = new Point(12, 87);
            startMinimizedCb.Name = "startMinimizedCb";
            startMinimizedCb.Size = new Size(109, 19);
            startMinimizedCb.TabIndex = 2;
            startMinimizedCb.Text = "Start Minimized";
            startMinimizedCb.UseVisualStyleBackColor = true;
            startMinimizedCb.CheckedChanged += startMinimizedCb_CheckedChanged;
            // 
            // disableFirstCoreCb
            // 
            disableFirstCoreCb.AutoSize = true;
            disableFirstCoreCb.Location = new Point(12, 12);
            disableFirstCoreCb.Name = "disableFirstCoreCb";
            disableFirstCoreCb.Size = new Size(117, 19);
            disableFirstCoreCb.TabIndex = 3;
            disableFirstCoreCb.Text = "Disable First Core";
            disableFirstCoreCb.UseVisualStyleBackColor = true;
            disableFirstCoreCb.CheckedChanged += disableFirstCoreCb_CheckedChanged;
            // 
            // disableHtCb
            // 
            disableHtCb.AutoSize = true;
            disableHtCb.Location = new Point(12, 37);
            disableHtCb.Name = "disableHtCb";
            disableHtCb.Size = new Size(158, 19);
            disableHtCb.TabIndex = 4;
            disableHtCb.Text = "Disable First Hyperthread";
            disableHtCb.UseVisualStyleBackColor = true;
            disableHtCb.CheckedChanged += disableHtCb_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(234, 161);
            Controls.Add(disableHtCb);
            Controls.Add(disableFirstCoreCb);
            Controls.Add(startMinimizedCb);
            Controls.Add(startWithWindowsCb);
            Controls.Add(statusStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "Too Affinity";
            Load += Form1_Load;
            Shown += Form1_Shown;
            Resize += Form1_Resize;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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