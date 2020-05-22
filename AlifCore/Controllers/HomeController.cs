using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AlifCore.Models;
using Dapper;
using System.Data.SqlClient;

namespace AlifCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (var context = new SqlConnection(GetStringCon()))
            {
                var list = context.Query<Person>("SELECT * FROM Person");
                return View(list);
            }
        }
        static string GetStringCon()
        {
            return "Data Source=localhost;Initial Catalog=Test;Integrated Security=True";
        }
    }
}
