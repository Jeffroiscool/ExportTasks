namespace ExportTasks
{
    partial class LoadingScreen
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.taskLoadingProgress = new System.Windows.Forms.ProgressBar();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.taskName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // taskLoadingProgress
            // 
            this.taskLoadingProgress.Location = new System.Drawing.Point(12, 12);
            this.taskLoadingProgress.Name = "taskLoadingProgress";
            this.taskLoadingProgress.Size = new System.Drawing.Size(460, 23);
            this.taskLoadingProgress.TabIndex = 0;
            // 
            // loadingLabel
            // 
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.Location = new System.Drawing.Point(9, 46);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(75, 13);
            this.loadingLabel.TabIndex = 1;
            this.loadingLabel.Text = "Loading Task:";
            // 
            // taskName
            // 
            this.taskName.AutoSize = true;
            this.taskName.Location = new System.Drawing.Point(91, 46);
            this.taskName.Name = "taskName";
            this.taskName.Size = new System.Drawing.Size(55, 13);
            this.taskName.TabIndex = 2;
            this.taskName.Text = "taskName";
            // 
            // LoadingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 111);
            this.ControlBox = false;
            this.Controls.Add(this.taskName);
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.taskLoadingProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LoadingScreen";
            this.ShowIcon = false;
            this.Text = "Loading Tasklist";
            this.UseWaitCursor = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar taskLoadingProgress;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.Label taskName;
    }
}