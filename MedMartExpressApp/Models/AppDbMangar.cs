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
            if (check > 1)
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
        public Response addToCart(Cart cart, SqlConnection conn)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_addToCart", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userId", cart.userId);
            cmd.Parameters.AddWithValue("@UnitPrice", cart.UnitPrice);
            cmd.Parameters.AddWithValue("@Discount", cart.Discount);
            cmd.Parameters.AddWithValue("@quantity", cart.quantity);
            cmd.Parameters.AddWithValue("@TotPrice", cart.TotPrice);
            cmd.Parameters.AddWithValue("@MedId", cart.MedId);
            conn.Open();
            int check =  cmd.ExecuteNonQuery();
            conn.Close();
            if (check > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Item addedd successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Item could not be added";
            }
            return response;
        }
        public Response placeOrder(User user, SqlConnection conn)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_placeOrder", conn);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(@"id", user.id);
            conn.Open();
            int check = cmd.ExecuteNonQuery();
            conn.Close();
            if (check > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Order is placed successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Failed to place the order";
            }
            return response;
        }
        public Response viewOrders(User user, SqlConnection conn)
        {
            Response response = new Response();
            List<Order> Userorders = new List<Order>();
            SqlDataAdapter adapter = new SqlDataAdapter("sp_viewOrders", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue(@"Type", user.Type);
            adapter.SelectCommand.Parameters.AddWithValue(@"id", user.id);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Order order = new Order();
                    order.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    order.OrderNO = Convert.ToString(dt.Rows[i]["OrderNO"]);
                    order.OrderTotal = Convert.ToDecimal(dt.Rows[i]["OrderTotal"]);
                    order.OrderStatus = Convert.ToString(dt.Rows[i]["OrderStatus"]);
                    Userorders.Add(order);
                }
                response.listOfOrders = Userorders;
                response.StatusCode = 200;
                response.StatusMessage = "orders details fetched";
            }
            else
            {
                response.listOfOrders = null;
                response.StatusCode = 100;
                response.StatusMessage = "no orders found!";
            }
            return response;
        }
    }
}
