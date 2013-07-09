namespace ExportTasks
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.retrieveItems = new System.Windows.Forms.Button();
            this.createEmail = new System.Windows.Forms.Button();
            this.taskList = new System.Windows.Forms.DataGridView();
            this.taskContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yellowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blauwToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hiddenDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskDueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.taskPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortByDate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.taskList)).BeginInit();
            this.taskContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // retrieveItems
            // 
            this.retrieveItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.retrieveItems.Location = new System.Drawing.Point(616, 508);
            this.retrieveItems.Name = "retrieveItems";
            this.retrieveItems.Size = new System.Drawing.Size(75, 41);
            this.retrieveItems.TabIndex = 0;
            this.retrieveItems.Text = "Retrieve Tasks";
            this.retrieveItems.UseVisualStyleBackColor = true;
            this.retrieveItems.Click += new System.EventHandler(this.retrieveTasks_Click);
            // 
            // createEmail
            // 
            this.createEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.createEmail.Location = new System.Drawing.Point(697, 508);
            this.createEmail.Name = "createEmail";
            this.createEmail.Size = new System.Drawing.Size(75, 41);
            this.createEmail.TabIndex = 6;
            this.createEmail.Text = "Mail";
            this.createEmail.UseVisualStyleBackColor = true;
            this.createEmail.Click += new System.EventHandler(this.exportToMail_Click);
            // 
            // taskList
            // 
            this.taskList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taskList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.taskList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.taskList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.index,
            this.hiddenDate,
            this.taskSubject,
            this.taskStartDate,
            this.taskDueDate,
            this.taskProgress,
            this.taskStatus,
            this.taskPriority});
            this.taskList.Location = new System.Drawing.Point(12, 12);
            this.taskList.Name = "taskList";
            this.taskList.Size = new System.Drawing.Size(760, 490);
            this.taskList.TabIndex = 7;
            this.taskList.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.taskList_MouseDown);
            // 
            // taskContextMenu
            // 
            this.taskContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yellowToolStripMenuItem,
            this.greenToolStripMenuItem,
            this.redToolStripMenuItem,
            this.blauwToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteToolStripMenuItem});
            this.taskContextMenu.Name = "taskContextMenu";
            this.taskContextMenu.Size = new System.Drawing.Size(110, 120);
            // 
            // yellowToolStripMenuItem
            // 
            this.yellowToolStripMenuItem.Name = "yellowToolStripMenuItem";
            this.yellowToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.yellowToolStripMenuItem.Text = "Yellow";
            this.yellowToolStripMenuItem.Click += new System.EventHandler(this.markYellow_Click);
            // 
            // greenToolStripMenuItem
            // 
            this.greenToolStripMenuItem.Name = "greenToolStripMenuItem";
            this.greenToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.greenToolStripMenuItem.Text = "Green";
            this.greenToolStripMenuItem.Click += new System.EventHandler(this.markGreen_Click);
            // 
            // redToolStripMenuItem
            // 
            this.redToolStripMenuItem.Name = "redToolStripMenuItem";
            this.redToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.redToolStripMenuItem.Text = "Red";
            this.redToolStripMenuItem.Click += new System.EventHandler(this.markRed_Click);
            // 
            // blauwToolStripMenuItem
            // 
            this.blauwToolStripMenuItem.Name = "blauwToolStripMenuItem";
            this.blauwToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.blauwToolStripMenuItem.Text = "Blue";
            this.blauwToolStripMenuItem.Click += new System.EventHandler(this.markBlue_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(106, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // index
            // 
            this.index.FillWeight = 104.8223F;
            this.index.HeaderText = "#";
            this.index.Name = "index";
            this.index.Visible = false;
            // 
            // hiddenDate
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.hiddenDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.hiddenDate.HeaderText = "Date";
            this.hiddenDate.Name = "hiddenDate";
            this.hiddenDate.ReadOnly = true;
            this.hiddenDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.hiddenDate.Visible = false;
            // 
            // taskSubject
            // 
            this.taskSubject.FillWeight = 104.8223F;
            this.taskSubject.HeaderText = "Subject";
            this.taskSubject.Name = "taskSubject";
            // 
            // taskStartDate
            // 
            dataGridViewCellStyle2.NullValue = "Geen";
            this.taskStartDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.taskStartDate.FillWeight = 104.8223F;
            this.taskStartDate.HeaderText = "Start Date";
            this.taskStartDate.Name = "taskStartDate";
            // 
            // taskDueDate
            // 
            dataGridViewCellStyle3.NullValue = "Geen";
            this.taskDueDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.taskDueDate.FillWeight = 104.8223F;
            this.taskDueDate.HeaderText = "Due Date";
            this.taskDueDate.Name = "taskDueDate";
            // 
            // taskProgress
            // 
            this.taskProgress.FillWeight = 71.06599F;
            this.taskProgress.HeaderText = "Percent Complete";
            this.taskProgress.Name = "taskProgress";
            // 
            // taskStatus
            // 
            this.taskStatus.FillWeight = 104.8223F;
            this.taskStatus.HeaderText = "Status";
            this.taskStatus.Items.AddRange(new object[] {
            "Niet gestart",
            "Wordt uitgevoerd",
            "Taak voltooid",
            "Wacht op klant",
            "Uitgesteld"});
            this.taskStatus.Name = "taskStatus";
            this.taskStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.taskStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // taskPriority
            // 
            this.taskPriority.FillWeight = 104.8223F;
            this.taskPriority.HeaderText = "Priority";
            this.taskPriority.Name = "taskPriority";
            // 
            // sortByDate
            // 
            this.sortByDate.Location = new System.Drawing.Point(12, 508);
            this.sortByDate.Name = "sortByDate";
            this.sortByDate.Size = new System.Drawing.Size(75, 41);
            this.sortByDate.TabIndex = 8;
            this.sortByDate.Text = "Sort by Date";
            this.sortByDate.UseVisualStyleBackColor = true;
            this.sortByDate.Click += new System.EventHandler(this.sortByDate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.sortByDate);
            this.Controls.Add(this.taskList);
            this.Controls.Add(this.createEmail);
            this.Controls.Add(this.retrieveItems);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Export Tasks";
            ((System.ComponentModel.ISupportInitialize)(this.taskList)).EndInit();
            this.taskContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button retrieveItems;
        private System.Windows.Forms.Button createEmail;
        private System.Windows.Forms.DataGridView taskList;
        private System.Windows.Forms.ContextMenuStrip taskContextMenu;
        private System.Windows.Forms.ToolStripMenuItem yellowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blauwToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn index;
        private System.Windows.Forms.DataGridViewTextBoxColumn hiddenDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskDueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskProgress;
        private System.Windows.Forms.DataGridViewComboBoxColumn taskStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskPriority;
        private System.Windows.Forms.Button sortByDate;
    }
}

