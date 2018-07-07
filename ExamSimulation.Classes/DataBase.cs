using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSimulation.Classes
{
    public class DataBase
    {
        public string connectionString = @"Data Source=LI-677\SQLEXPRESS01;Initial Catalog=BachelorParty;Integrated Security=True;";

        public DataTable GetAllUser()
        {
            //BEGIN
            //SELECT u.Id
            //      ,u.Name
            //      ,u.Surname
            //      ,u.Email
            //      ,u.Password
            //      ,t.TypeUser
            //  FROM Users u
            //  inner join TypeUser t
            //  on t.IdTypeUser = u.IdTypeUser
            //END
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetAllUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dt);
                    }
                }
                connection.Close();
            }
            return dt;
        }

        public List<User> GetAllUserInListUser()
        {
            List<User> users = new List<User>();
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetAllUserWithIdTypeUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dt);
                    }
                }
                connection.Close();
            }
            foreach (DataRow dr in dt.Rows)
            {
                TypeUser typeUser = new TypeUser();
                users.Add(
                    new User
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Surname = Convert.ToString(dr["Surname"]),
                        Email = Convert.ToString(dr["Email"]),
                        Password = Convert.ToString(dr["Password"]),
                        IdTypeUser = (TypeUser)Convert.ToInt32(dr["IdTypeUser"])
                        //IdTypeUser = Enum.Parse(typeof(TypeUser), Convert.ToInt32[(dr["IdTypeUser"])])
                    });
            }
            return users;
        }

        public bool InsertUser(User user)
        {
            int count = 0;
            //--Add the parameters for the stored procedure here
            //@name nvarchar(255),
            //@surname nvarchar(255),
            //@email nvarchar(255),
            //@password nvarchar(255),
            //@idTypeUser int
            //AS
            //BEGIN
            //insert into[Users](Name, Surname, Email, Password, IdTypeUser)
            //values(@name, @surname, @email, @password, @idTypeUser)
            //END
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("InsertUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", user.Name);
                    command.Parameters.AddWithValue("@surname", user.Surname);
                    command.Parameters.AddWithValue("@email", user.Email);
                    command.Parameters.AddWithValue("@password", user.Password);
                    command.Parameters.AddWithValue("@idTypeUser", user.IdTypeUser);
                    count = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return (count > 0) ? true : false;
        }

        public bool UpdateUser(User user)
        {
            int count = 0;
            //--Add the parameters for the stored procedure here
            //@id int,
            //@name nvarchar(255),
            //@surname nvarchar(255),
            //@email nvarchar(255),
            //@password nvarchar(255),
            //@idTypeUser int
            //AS
            //BEGIN
            //update[Users] set Name = @name, Surname = @surname, Email = @email, Password = @password, IdTypeUser = @idTypeUser where Id = @id
            //END
            //GO
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("[dbo].[UpdateUser]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", user.Id);
                    command.Parameters.AddWithValue("@name", user.Name);
                    command.Parameters.AddWithValue("@surname", user.Surname);
                    command.Parameters.AddWithValue("@email", user.Email);
                    command.Parameters.AddWithValue("@password", user.Password);
                    command.Parameters.AddWithValue("@idTypeUser", user.IdTypeUser);
                    count = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return (count > 0) ? true : false;
        }

        public bool DeleteUser(int id)
        {
            int count = 0;
            //--Add the parameters for the stored procedure here
            //@id int
            //AS
            //BEGIN
            //delete[Users] where Id = @id
            //END
            //GO
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("[dbo].[DeleteUser]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return (count > 0) ? true : false;
        }

        public User GetUserFromLogin(Login login)
        {
            User user = new User();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("[dbo].[GetUserByEmailAndPassword]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@email", login.Email);
                    command.Parameters.AddWithValue("@password", login.Password);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user.Id = (int)reader["Id"];
                            user.Name = reader["Name"].ToString();
                            user.Surname = reader["Surname"].ToString();
                            user.Email = reader["Email"].ToString();
                            user.Password = reader["Password"].ToString();
                            user.IdTypeUser = (TypeUser)(int)reader["IdTypeUser"];
                        }
                    }
                }
                connection.Close();
            }
            return user;
        }

        public DataTable GetTableByQueryOrStoredProcedure(string text, bool isStoredProcedure = false)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(text, connection))
                {
                    if (isStoredProcedure)
                    {
                        command.CommandType = CommandType.StoredProcedure;
                    }
                    command.ExecuteNonQuery();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dt);
                    }
                }
                connection.Close();
            }
            return dt;
        }

        public List<ActivityForGuest> GetActivityForGuest()
        {
            List<ActivityForGuest> activity = new List<ActivityForGuest>();
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetCountForDate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dt);
                    }
                }
                connection.Close();
            }
            foreach (DataRow dr in dt.Rows)
            {
                activity.Add(
                    new ActivityForGuest
                    {
                        CountPartecipant = Convert.ToInt32(dr["CountPartecipant"]),
                        Date = Convert.ToDateTime(dr["Date"])
                    });
            }
            return activity;
        }

        public List<Activity> GetActivityList()
        {
            List<Activity> activity = new List<Activity>();
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetAllActivity", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dt);
                    }
                }
                connection.Close();
            }
            foreach (DataRow dr in dt.Rows)
            {
                activity.Add(
                    new Activity
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Title = Convert.ToString(dr["Title"]),
                        Description = Convert.ToString(dr["Description"]),
                        Place = Convert.ToString(dr["Place"]),
                        Date = Convert.ToDateTime(dr["Date"]),
                    });
            }
            return activity;
        }
    }
}