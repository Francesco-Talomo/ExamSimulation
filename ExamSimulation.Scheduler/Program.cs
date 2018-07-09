using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Mail;

namespace ExamSimulation.Scheduler
{
    internal class Program
    {
        //private static CacheItemRemovedCallback OnCacheRemove = null;
        private const string DummyCacheItemKey = "Scheduler";

        public static void Main(string[] args)
        {
            //AddTask("DoStuff", 60);
            RegisterCacheEntry();
        }

        private bool RegisterCacheEntry()
        {
            if (null != HttpContext.Current.Cache[DummyCacheItemKey]) return false;

            HttpContext.Current.Cache.Add(DummyCacheItemKey, "Test", null,
                DateTime.MaxValue, TimeSpan.FromMinutes(1),
                CacheItemPriority.Normal,
                new CacheItemRemovedCallback(CacheItemRemovedCallback));

            return true;
        }

        public void CacheItemRemovedCallback(string key,
            object value, CacheItemRemovedReason reason)
        {
            Debug.WriteLine("Cache item callback: " + DateTime.Now.ToString());

            // Do the service works

            DoWork();
        }

        private void DoWork()
        {
            Debug.WriteLine("Begin DoWork...");
            Debug.WriteLine("Running as: " +
                  WindowsIdentity.GetCurrent().Name);

            //DoSomeFileWritingStuff();
            //DoSomeDatabaseOperation();
            DoSomeEmailSendStuff();

            Debug.WriteLine("End DoWork...");
        }

        private void DoSomeFileWritingStuff()
        {
            Debug.WriteLine("Writing to file...");

            try
            {
                using (StreamWriter writer =
                 new StreamWriter(@"c:\temp\Cachecallback.txt", true))
                {
                    writer.WriteLine("Cache Callback: {0}", DateTime.Now);
                    writer.Close();
                }
            }
            catch (Exception x)
            {
                Debug.WriteLine(x);
            }

            Debug.WriteLine("File write successful");
        }

        private void DoSomeDatabaseOperation()
        {
            Debug.WriteLine("Connecting to database...");

            using (SqlConnection con = new SqlConnection("Data Source" +
                   "=(local);Initial Catalog=tempdb;Integrated Security=SSPI;"))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT" +
                       " INTO ASPNETServiceLog VALUES" +
                       " (@Message, @DateTime)", con))
                {
                    cmd.Parameters.Add("@Message", SqlDbType.VarChar, 1024).Value =
                                       "Hi I'm the ASP NET Service";
                    cmd.Parameters.Add("@DateTime", SqlDbType.DateTime).Value =
                                       DateTime.Now;

                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }

            Debug.WriteLine("Database connection successful");
        }

        private void DoSomeEmailSendStuff()
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = "francesco.talomo@gmail.com";
                msg.To = "francesco.talomo@gmail.com";
                msg.Subject = "Reminder: " + DateTime.Now.ToString();
                msg.Body = "This is a server generated message";

                SmtpMail.Send(msg);
            }
            catch (Exception x)
            {
                Debug.WriteLine(x);
            }
        }
    }
}