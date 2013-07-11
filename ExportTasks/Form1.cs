using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Interop.Outlook;

namespace ExportTasks
{
    public partial class Form1 : Form
    {
        public LoadingScreen loadingWindow;
        public Form1()
        {
            
            InitializeComponent();
            retrieveTasks();
            CenterToScreen();
        }

        private void loadingScreen()
        {
            loadingWindow = new LoadingScreen();
            System.Windows.Forms.Application.Run(loadingWindow);
        }

        private void retrieveTasks()
        {
            Thread loadingThread = new Thread(new ThreadStart(loadingScreen));
            loadingThread.Start();
            //Clear datagrid so we won't have duplicate information
            taskList.Rows.Clear();

            //Define some properties so we can use these to retrieve the tasks
            Outlook.Application app = null;
            _NameSpace ns = null;
            Store outlookStore = null;
            Outlook.MAPIFolder taskFolder = null;
            TaskItem task = null;
            DateTime nonDate = new DateTime(4501, 1, 1);

            try
            {
                //Connect to Outlook via MAPI
                app = new Outlook.Application();
                ns = app.GetNamespace("MAPI");
                ns.Logon(null, null, false, false);

                //Get the taskfolder containing the Outlook tasks
                outlookStore = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox).Store;
                taskFolder = outlookStore.GetSpecialFolder(OlSpecialFolders.olSpecialFolderAllTasks);
                loadingWindow.UpdateMaxValue(taskFolder.Items.Count);
                for (int i = 1; i <= taskFolder.Items.Count; i++)
                {
                    //Get task from taskfolder
                    Object item = taskFolder.Items[i];
                    if (item is Outlook.MailItem)
                    {
                        MailItem mail = (Outlook.MailItem)item;
                        if (mail.TaskCompletedDate.Equals(nonDate))
                        {
                            string taskPrio = "";
                            if (mail.UserProperties.Find("Prio") == null)
                            {
                                taskPrio = "";
                            }
                            else
                            {
                                taskPrio = mail.UserProperties.Find("Prio").Value.ToString();
                            }

                            string percentComplete = mail.PropertyAccessor.GetProperty("http://schemas.microsoft.com/mapi/id/{00062003-0000-0000-C000-000000000046}/81020005").ToString("0%");
                            string taskStatus = statusToFriendlyName(mail.PropertyAccessor.GetProperty("http://schemas.microsoft.com/mapi/id/{00062003-0000-0000-C000-000000000046}/81010003").ToString(), 1);

                            loadingWindow.UpdateCurrentTask(mail.TaskSubject, i);

                            string parsedDate = "";
                            if (mail.TaskStartDate.ToString() == "1-1-4501 00:00:00")
                            {
                                parsedDate = "1-1-1000 00:00:00";
                            }
                            else
                            {
                                parsedDate = mail.TaskStartDate.ToString();
                            }
                            DateTime hiddenDate = Convert.ToDateTime(parsedDate);

                            //Add the tasks details to the datagrid
                            taskList.Rows.Add(
                                i.ToString(),
                                hiddenDate,
                                checkForNull(mail.TaskSubject),
                                parseDate(mail.TaskStartDate.ToString()),
                                parseDate(mail.TaskDueDate.ToString()),
                                percentComplete,
                                taskStatus,
                                taskPrio
                            );
                        }
                    }
                    else if (item is Outlook.TaskItem)
                    {
                        task = (Outlook.TaskItem)item;
                        loadingWindow.UpdateCurrentTask(task.Subject, i);
                        if (task.Complete == false)
                        {
                            string taskPrio = "";

                            //Make sure custom task property is failed or set it to empty text to prevent crashes
                            if (task.UserProperties.Find("Prio") == null)
                            {
                                taskPrio = "";
                            }
                            else
                            {
                                taskPrio = task.UserProperties.Find("Prio").Value.ToString();
                            }

                            string parsedDate = "";
                            if (task.StartDate.ToString() == "1-1-4501 00:00:00")
                            {
                                parsedDate = "1-1-1000 00:00:00";
                            }
                            else
                            {
                                parsedDate = task.StartDate.ToString();
                            }
                            DateTime hiddenDate = Convert.ToDateTime(parsedDate);


                            //Add the tasks details to the datagrid
                            taskList.Rows.Add(
                                i.ToString(),
                                hiddenDate,
                                task.Subject.ToString(),
                                parseDate(task.StartDate.ToString()),
                                parseDate(task.DueDate.ToString()),
                                task.PercentComplete.ToString() + "%",
                                statusToFriendlyName(task.Status.ToString(), 0),
                                taskPrio
                            );
                        }
                    }
                    
                    
                }
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //Release Outlook sources
                ns = null;
                app = null;
            }

            taskList.Sort(this.taskSubject, ListSortDirection.Ascending);
            taskList.Sort(this.hiddenDate, ListSortDirection.Ascending);
            taskList.Focus();
            loadingThread.Abort();
            autoColor();
        }

        private void retrieveTasks_Click(object sender, EventArgs e)
        {
            retrieveTasks();
        }

        private string parseDate(string date)
        {
            //Check if date is 1-1-4501 00:00:00 which means no date was set
            if (date == "1-1-4501 00:00:00")
            {
                return "Geen";
            }
            else
            {
                DateTime parsedDate;
                if(DateTime.TryParse(date, out parsedDate))
                {
                    return parsedDate.ToString("ddd d-M-yyyy");
                }else{
                    return date;
                }
            }
        }

        private string checkForNull(object check)
        {
            try
            {
                if (string.IsNullOrEmpty((string)check))
                {
                    return "";
                }
                else
                {
                    return check.ToString();
                }
            }
            catch
            {
                return "";
            }
        }

        private string statusToFriendlyName(string status, int type)
        {
            //Translate builtin Outlook properties to friendly text
            if (type == 0)
            {
                switch (status)
                {
                    case "olTaskNotStarted":
                        return "Niet gestart";
                    case "olTaskInProgress":
                        return "Wordt uitgevoerd";
                    case "olTaskComplete":
                        return "Taak voltooid";
                    case "olTaskWaiting":
                        return "Wacht op klant";
                    case "olTaskDeferred":
                        return "Uitgesteld";
                    default:
                        return "Geen status";
                }
            }
            else if (type == 1)
            {
                switch (status)
                {
                    case "0":
                        return "Niet gestart";
                    case "1":
                        return "Wordt uitgevoerd";
                    case "2":
                        return "Taak voltooid";
                    case "3":
                        return "Wacht op klant";
                    case "4":
                        return "Uitgesteld";
                    default:
                        return "Geen status";
                }
            }
            else
            {
                return "Geen status";
            }
        }

        private string generateHTML()
        {
            //Generate table header
            string tableHeader = "<table border=1 cellpadding=3 cellspacing=0 style='border: 1pt solid #000000; border-Collapse: collapse'><tr><td style='border: 1pt solid #000000'>Taakonderwerp</td><td style='border: 1pt solid #000000'>Begindatum</td><td style='border: 1pt solid #000000'>Einddatum</td><td style='border: 1pt solid #000000'>% voltooid</td><td style='border: 1pt solid #000000'>Status</td><td style='border: 1pt solid #000000'>Prio</td></tr>";
            string tableContent = "";
            foreach (DataGridViewRow row in taskList.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    tableContent = tableContent + "<tr bgcolor='" + ColorTranslator.ToHtml(row.DefaultCellStyle.BackColor) + "'><td style='border: 1pt solid #000000'>" + row.Cells[2].Value + "</td><td style='border: 1pt solid #000000'>" + row.Cells[3].Value + "</td><td style='border: 1pt solid #000000'>" + row.Cells[4].Value + "</td><td style='border: 1pt solid #000000'>" + row.Cells[5].Value + "</td><td style='border: 1pt solid #000000'>" + row.Cells[6].Value + "</td><td style='border: 1pt solid #000000'>" + row.Cells[7].Value + "</td></tr>";
                }
            }

            string fullHTML = tableHeader + tableContent + "</table>";
            return fullHTML; 
        }

        private void exportToMail_Click(object sender, EventArgs e)
        {
            Outlook.Application oApp = new Outlook.Application();
            Outlook._MailItem oMailItem = (Outlook._MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
            oMailItem.To = "support@on-site.nl";
            oMailItem.HTMLBody = this.generateHTML();
            oMailItem.Display(true);           
        }

        private void markYellow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in taskList.SelectedCells)
            {
                cell.OwningRow.DefaultCellStyle.BackColor = Color.Yellow;
            }
        }

        private void markGreen_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in taskList.SelectedCells)
            {
                cell.OwningRow.Cells[6].Value = "Taak voltooid";
                cell.OwningRow.DefaultCellStyle.BackColor = Color.YellowGreen;
            }
        }

        private void markRed_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in taskList.SelectedCells)
            {
                cell.OwningRow.Cells[6].Value = "Wacht op klant";
                cell.OwningRow.DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void markBlue_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewCell cell in taskList.SelectedCells)
            {
                cell.OwningRow.DefaultCellStyle.BackColor = Color.DodgerBlue;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewCell cell in taskList.SelectedCells)
            {
                if(cell.Selected){
                    taskList.Rows.RemoveAt(cell.RowIndex);
                }
            }
        }

        private void taskList_MouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridViewCell clickedCell = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex];

                    if (clickedCell.Selected == false)
                    {
                        this.taskList.CurrentCell = clickedCell;
                    }

                    // Here you can do whatever you want with the cell
                    
                    //  // Select the clicked cell, for instance

                    // Get mouse position relative to the vehicles grid
                    var relativeMousePosition = taskList.PointToClient(Cursor.Position);

                    // Show the context menu
                    this.taskContextMenu.Show(taskList, relativeMousePosition);
                }
            }
        }
        
        private void autoColor()
        {
            foreach (DataGridViewRow row in taskList.Rows)
            {
                string percentComplete = checkForNull((string)row.Cells[5].Value);
                if (percentComplete.StartsWith("99"))
                {
                    row.Cells[6].Value = "Taak voltooid";
                    row.DefaultCellStyle.BackColor = Color.YellowGreen;
                }
                if ((string)row.Cells[6].Value == "Wacht op klant")
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
        
        private void sortByDate_Click(object sender, EventArgs e)
        {
            taskList.Sort(this.taskSubject, ListSortDirection.Ascending);
            taskList.Sort(this.hiddenDate, ListSortDirection.Ascending);
        }

        private void taskList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach(DataGridViewCell cell in taskList.SelectedCells)
                {
                    cell.Value = "";
                }
            }
            if (e.KeyCode == Keys.Control)
            {
                if (e.KeyCode == Keys.Z)
                {

                }
            }
        }
    }
}
