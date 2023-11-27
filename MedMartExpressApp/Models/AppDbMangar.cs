using System.Data.SqlClient;
using System.Data;

namespace MedMartExpressApp.Models
{
    public class AppDbMangar
    {
        public Response register(User user, SqlConnection conn)
        {
            Response res = new Response();
            SqlCommand cmd = new SqlCommand("sp_register", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(@"Fname", user.Fname);
            cmd.Parameters.AddWithValue(@"Lname", user.Lname);
            cmd.Parameters.AddWithValue(@"Password", user.Password);
            cmd.Parameters.AddWithValue(@"email", user.email);
            cmd.Parameters.AddWithValue(@"Fund", user.Fund);
            cmd.Parameters.AddWithValue(@"Type", user.Type);
            cmd.Parameters.AddWithValue(@"status", user.status);
            cmd.Parameters.AddWithValue(@"createdon", user.createdon);
            conn.Open();
            int check = cmd.ExecuteNonQuery();
            conn.Close();
            if(check>0)
            {
                res.StatusMessage = "200";
                res.StatusMessage = "User is registered successfully!";
            }
            else
            {
                res.StatusMessage = "100";
                res.StatusMessage = "User registeration Failed!";
            }
            return res;
        }
        public Response Login(User user, SqlConnection conn)
        {
            Response res = new Response();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("sp_login",conn);
            sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue(@"email", user.email);
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue(@"Password", user.Password);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            if(dt.Rows.Count>0)
            {
                res.StatusMessage = "200";
                res.StatusMessage = "Login successfully!";
            }
            else
            {
                res.StatusMessage = "100";
                res.StatusMessage = "Login Failed!";
            }
            return res;
        }
    }
}
