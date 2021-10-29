using HW_mvc_part_1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Logging;

namespace HW_mvc_part_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly string _conString = "Data source = localhost; Initial catalog = AcademySummer; Integrated Security = True";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            List<Person> people = new List<Person>();
            using (IDbConnection con = new SqlConnection(_conString))
            {
                people = con.Query<Person>("Select * from Person").ToList();
            }
            return View(people);
        }
    }
}
