using ExamSimulation.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamSimulation.WinForm
{
    public partial class Activity : Form
    {
        public Activity()
        {
            InitializeComponent();
            DataBase db = new DataBase();
            dataGridView1.DataSource = db.GetTableByQueryOrStoredProcedure("GetCountForDate", true);
        }

        private void Activity_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}