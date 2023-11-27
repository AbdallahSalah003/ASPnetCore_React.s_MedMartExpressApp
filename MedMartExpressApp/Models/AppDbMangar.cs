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
            User newuser = new User();
            if (dt.Rows.Count>0)
            {
                newuser.id = Convert.ToInt32(dt.Rows[0]["id"]);
                newuser.Fname = Convert.ToString(dt.Rows[0]["Fname"]);
                newuser.Lname = Convert.ToString(dt.Rows[0]["Lname"]);
                newuser.Password = Convert.ToString(dt.Rows[0]["Password"]);
                newuser.email = Convert.ToString(dt.Rows[0]["email"]);
                newuser.Type = Convert.ToString(dt.Rows[0]["Type"]);
                res.StatusMessage = "200";
                res.StatusMessage = "Login successfully!";
                res.user = newuser;
            }
            else
            {
                res.StatusMessage = "100";
                res.StatusMessage = "Login Failed!";
                res.user = null;
            }
            return res;
        }
        public Response viewProfile(User user, SqlConnection conn)
        {
            Response res = new Response();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("sp_viewProfile", conn);
            sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue(@"id", user.id);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            User newuser = new User();
            if (dt.Rows.Count > 0)
            {
                newuser.id  = Convert.ToInt32(dt.Rows[0]["id"]);
                newuser.Fname = Convert.ToString(dt.Rows[0]["Fname"]);
                newuser.Lname = Convert.ToString(dt.Rows[0]["Lname"]);
                newuser.Password = Convert.ToString(dt.Rows[0]["Password"]);
                newuser.email = Convert.ToString(dt.Rows[0]["email"]);
                newuser.Type = Convert.ToString(dt.Rows[0]["Type"]);
                newuser.Fund = Convert.ToDecimal(dt.Rows[0]["Fund"]);
                newuser.Password = Convert.ToString(dt.Rows[0]["Password"]);
                newuser.createdon = Convert.ToDateTime(dt.Rows[0]["createdon"]);
                res.StatusMessage = "200";
                res.StatusMessage = "Login successfully!";
                res.user = newuser;
            }
            else
            {
                res.StatusMessage = "100";
                res.StatusMessage = "Login Failed!";
                res.user = null;
            }
            return res;
        }
        public Response editProfile(User user, SqlConnection conn)
        {
            Response res = new Response();
            SqlCommand cmd = new SqlCommand("sp_editProfile", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(@"Fname", user.Fname);
            cmd.Parameters.AddWithValue(@"Lname", user.Lname);
            cmd.Parameters.AddWithValue(@"Password", user.Password);
            conn.Open();
            int check = cmd.ExecuteNonQuery();
            conn.Close();
            if(check >1)
            {
                res.StatusMessage = "200";
                res.StatusMessage = "Profile is Edited successfully!";
            }
            else
            {
                res.StatusMessage = "100";
                res.StatusMessage = "Failed to Edit Profile!";
            }
            return res;
        }
    }
}
