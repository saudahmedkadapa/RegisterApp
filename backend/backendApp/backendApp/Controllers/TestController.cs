using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using backendApp.Models;

namespace backendApp.Controllers
{
    [RoutePrefix("api/Test")]
    public class TestController : ApiController
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlCommand cmd = null;
        SqlDataAdapter adapter = null;
        [HttpPost]
        [Route("Registration")]
        public string Registration(Employee employee)
        {
            string msg=string.Empty;
            try
            {
                cmd = new SqlCommand("usp_Registration", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@PhoneNo", employee.PhoneNo);
                cmd.Parameters.AddWithValue("@Address", employee.Address);
                cmd.Parameters.AddWithValue("@isActive", employee.isActive);

                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();

                if (i > 0)
                {
                    msg = "Data inserted.";

                }
                else
                {
                    msg = "Error";

                }

            }
            catch(Exception ex) {
                msg = ex.Message;
            }
            
            return msg;


        }

        [HttpPost]
        [Route("Login")]
        public string Login(Employee employee)
        {
            string msg = string.Empty;
            try
            {
                adapter = new SqlDataAdapter("usp_login", conn);
                adapter.SelectCommand.CommandType= CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@Name", employee.Name);
                adapter.SelectCommand.Parameters.AddWithValue("@PhoneNo", employee.PhoneNo);
                DataTable dt=new DataTable();
                adapter.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    msg = "User is valid";
                }
                else { msg = "User is Invalid"; }


            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;


        }


    }
}
