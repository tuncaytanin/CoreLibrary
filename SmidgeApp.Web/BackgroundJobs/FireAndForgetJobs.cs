using Hangfire;
using SmidgeApp.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmidgeApp.Web.BackgroundJobs
{


    public class FireAndForgetJobs
    {

        public static void EmailSendToUserJob(string userID,string message)
        {
            // tek sefer çalışan job işlemi
            Hangfire.BackgroundJob.Enqueue<IEmailSender>(x => x.Sender(userID, message));
        }
    }
}
