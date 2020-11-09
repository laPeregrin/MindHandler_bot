using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MindHandler_bot.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            string x = "My bot is running";
            return x;
        }

    }
}
