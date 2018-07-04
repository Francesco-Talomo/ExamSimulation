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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                DataBase db = new DataBase();
                User user = new User();
                user.Email = txtEmail.Text;
                user.Password = txtPassword.Text;
                user = db.GetUserFromLogin(user);
                if (user.IdTypeUser != 0)
                {
                    TypeUser typeUser = (TypeUser)user.IdTypeUser;
                    switch (typeUser)
                    {
                        case TypeUser.Organizzatore:
                            AddParticipants addParticipants = new AddParticipants();
                            addParticipants.Show();
                            this.Hide();
                            break;

                        case TypeUser.Invitato:
                            Partecipant guest = new Partecipant();
                            guest.Show();
                            this.Hide();
                            break;

                        case TypeUser.Utente:
                            Activity activity = new Activity();
                            activity.Show();
                            this.Hide();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Dati errati");
                }
            }
            else
            {
                MessageBox.Show("Compila tutti i campi");
            }
        }
    }
}