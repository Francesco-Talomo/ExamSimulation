using ExamSimulation.Scheduler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Principal;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Routing;

namespace ExamSimulation.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private const string DummyCacheItemKey = "Scheduler";
        public readonly static ArrayList _JobQueue = new ArrayList();

        protected void Application_Start()
        {
            RegisterCacheEntry();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private bool RegisterCacheEntry()
        {
            if (null != HttpContext.Current.Cache[DummyCacheItemKey]) return false;

            HttpContext.Current.Cache.Add(DummyCacheItemKey, "Test", null, DateTime.MaxValue, TimeSpan.FromMinutes(3),
                CacheItemPriority.Normal, new CacheItemRemovedCallback(CacheItemRemovedCallback));

            return true;
        }

        public void CacheItemRemovedCallback(string key,
            object value, CacheItemRemovedReason reason)
        {
            Debug.WriteLine("Cache item callback: " + DateTime.Now.ToString());

            DoWork();
        }

        private void DoWork()
        {
            Debug.WriteLine("Begin DoWork...");
            Debug.WriteLine("Running as: " + WindowsIdentity.GetCurrent().Name);

            DoSomeEmailSendStuff();
            ExecuteQueuedJobs();

            Debug.WriteLine("End DoWork...");
        }

        private void ExecuteQueuedJobs()
        {
            ArrayList jobs = new ArrayList();

            foreach (Job job in _JobQueue)
            {
                if (job.ExecutionTime <= DateTime.Now)
                    jobs.Add(job);
            }

            foreach (Job job in jobs)
            {
                lock (_JobQueue)
                {
                    _JobQueue.Remove(job);
                }

                job.Execute();
            }
        }

        private void DoSomeEmailSendStuff()
        {
            var fromAddress = new MailAddress("francesco.talomo@edu.itspiemonte.it", "From Name");
            var toAddress = new MailAddress("francesco.talomo@gmail.com", "To Name");
            const string fromPassword = "********";
            const string subject = "Subject";
            const string body = "Body";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}