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
    public partial class Partecipant : Form
    {
        public Partecipant()
        {
            InitializeComponent();
            DataBase db = new DataBase();
            dataGridView2.DataSource = db.GetTableByQueryOrStoredProcedure("GetAllActivityForUser", true);
        }

        private void Guest_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}