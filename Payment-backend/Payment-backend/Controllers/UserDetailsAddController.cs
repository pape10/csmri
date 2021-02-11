using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Payment_backend.Models;

namespace Payment_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsAddController : Controller
    {
        private readonly IConfiguration _configuration;

        public UserDetailsAddController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            
            string query = @"select * from dbo.FormTable";
            DataTable dataTable = new DataTable();
            string jsonResult;
            string sqlDataSource = _configuration.GetConnectionString("FormDetailsCon");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, myCon))
                {
                    // DataSet ds = new DataSet();
                    adapter.Fill(dataTable);
                    jsonResult = JsonConvert.SerializeObject(dataTable);
                    Response.WriteAsync(jsonResult);
                    myCon.Close();
                }
            }
            return new JsonResult(jsonResult);
        }

        [HttpPost]
        public JsonResult Post( UserDetails userDetails)
        {
            string query = $"insert into dbo.FormTable values ('{userDetails.FirstName}', '{userDetails.LastName}','{userDetails.Email}','{userDetails.Phone}','{userDetails.userAdd}','{userDetails.UserState}','{userDetails.UserCountry}','{userDetails.ReferredPersonName}','{userDetails.ReferredPersonMail}',{userDetails.ZIP})";
            DataTable dataTable = new DataTable();
            string jsonResult;
            string sqlDataSource = _configuration.GetConnectionString("FormDetailsCon");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, myCon))
                {
                    // DataSet ds = new DataSet();
                    adapter.Fill(dataTable);
                    jsonResult = JsonConvert.SerializeObject(dataTable);
                    Response.WriteAsync(jsonResult);
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }

    }
}