﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmidgeApp.Web.Services
{
    interface IEmailSender
    {
        Task Sender(string UserId, string message);
    }
}
