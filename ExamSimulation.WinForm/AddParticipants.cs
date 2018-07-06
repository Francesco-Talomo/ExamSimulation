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
    public partial class AddParticipants : Form
    {
        private int ID = 0;

        public AddParticipants()
        {
            InitializeComponent();
            cbTypeUser.Items.Add(TypeUser.Organizzatore);
            cbTypeUser.Items.Add(TypeUser.Invitato);
            cbTypeUser.Items.Add(TypeUser.Utente);
            DisplayData();
        }

        //Display Data in DataGridView
        private void DisplayData()
        {
            DataBase db = new DataBase();
            dgvUser.DataSource = db.GetAllUser();
        }

        //Clear Data
        private void ClearData()
        {
            txtName.Text = "";
            txtSurname.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            cbTypeUser.SelectedItem = null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
            ID = 0;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtSurname.Text != "" && txtEmail.Text != "" && txtPassword.Text != "")
            {
                DataBase db = new DataBase();
                User user = new User
                {
                    Name = txtName.Text,
                    Surname = txtSurname.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    IdTypeUser = (TypeUser)cbTypeUser.SelectedIndex + 1
                };
                db.InsertUser(user);
                MessageBox.Show(this, "Record Inserted Successfully");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show(this, "Please Provide Details!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                DataBase db = new DataBase();
                User user = new User
                {
                    Id = ID,
                    Name = txtName.Text,
                    Surname = txtSurname.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    IdTypeUser = (TypeUser)cbTypeUser.SelectedIndex + 1
                };
                db.UpdateUser(user);
                MessageBox.Show(this, "Record Updated Successfully");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show(this, "Please Select Record to Delete");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                DataBase db = new DataBase();
                db.DeleteUser(ID);
                MessageBox.Show(this, "Record Deleted Successfully!");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show(this, "Please Select Record to Delete");
            }
        }

        private void dgvUser_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(dgvUser.Rows[e.RowIndex].Cells[0].Value.ToString()))
            {
                ID = Convert.ToInt32(dgvUser.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtName.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSurname.Text = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtEmail.Text = dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPassword.Text = dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString();
                cbTypeUser.SelectedItem = Enum.Parse(typeof(TypeUser), dgvUser.Rows[e.RowIndex].Cells[5].Value.ToString());
            }
        }

        private void AddInvitati_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}