using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportTasks
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
            CenterToScreen();
        }



        private void UpdateMax(int value)
        {
            taskLoadingProgress.Maximum = value;
        }
        delegate void m_UpdateMax(int value);

        public void UpdateMaxValue(int value)
        {
            if (taskLoadingProgress.InvokeRequired)
            {
                m_UpdateMax setLabel = UpdateMax;
                Invoke(setLabel, value);
            }
            else
            {
                taskLoadingProgress.Maximum = value;
            }
        }

        private void UpdateTaskLabel(string taskText, int value)
        {
            taskName.Text = taskText;
            taskLoadingProgress.Value = value;
            taskLoadingProgress.Refresh();
            int percent = (int)(((double)taskLoadingProgress.Value / (double)taskLoadingProgress.Maximum) * 100);
            taskLoadingProgress.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(taskLoadingProgress.Width / 2 - 10, taskLoadingProgress.Height / 2 - 7));
        }
        delegate void m_UpdateTaskLabel(string taskText, int value);

        public void UpdateCurrentTask(string taskText, int value)
        {
            if (taskName.InvokeRequired)
            {
                m_UpdateTaskLabel setLabel = UpdateTaskLabel;
                Invoke(setLabel, taskText, value);
            }
            else
            {
                taskName.Text = taskText;
                taskLoadingProgress.Refresh();
                int percent = (int)(((double)taskLoadingProgress.Value / (double)taskLoadingProgress.Maximum) * 100);
                taskLoadingProgress.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(taskLoadingProgress.Width / 2 - 10, taskLoadingProgress.Height / 2 - 7));
            }
        }
        

    }
}
