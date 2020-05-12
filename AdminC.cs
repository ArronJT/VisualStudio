using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AdminC
    {
        [Required(ErrorMessage = "field is needed")]
        [Display(Name = "User name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "field is needed")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember on this computer")]
        public bool RememberMe { get; set; }

        public string LogError { get; set; }


        public bool Check() //this is used by Login controller method
        {
            using (var cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arron\source\repos\WebApplication1\WebApplication1\App_Data\Database.mdf;Integrated Security=True"))
            {
                string _sql = @"SELECT [Username] FROM [dbo].[ADtable] WHERE [Username] = @u AND [Password] = @p";
                var cmd = new SqlCommand(_sql, cn);
                cmd.Parameters.Add(new SqlParameter("@u", SqlDbType.NVarChar)).Value = Username;
                cmd.Parameters.Add(new SqlParameter("@p", SqlDbType.NVarChar)).Value = Password;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    reader.Dispose();
                    cmd.Dispose();
                    return true;
                }
                else
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return false;
                }
            }
        }
    }
}