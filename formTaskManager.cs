using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleTaskManager
{
    public partial class formTaskManager : Form
    {
        Process[] process;
        public formTaskManager()
        {
            InitializeComponent();
        }

        private void GetAllProcesses()
        {

            process = Process.GetProcesses();
            listBox.Items.Clear();
            foreach (Process p in process)
                listBox.Items.Add(p.ProcessName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetAllProcesses();
        }

        private void btnEndTask_Click(object sender, EventArgs e)
        {
            try 
            { 
                process[listBox.SelectedIndex].Kill();
                GetAllProcesses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void runNewTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                formNewTask form = new formNewTask();
                form.ShowDialog();
                GetAllProcesses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made By:\n\nAhmed Elazony\tsection 4\nAdham Elsaid\tsection 4", "Credits", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
