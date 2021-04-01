using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace testASPSQLC
{
    public partial class webTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList1.Items[0].Attributes["disabled"] = "disabled";
            if (!IsPostBack)
            {
                bindData();
            }
            
        }

        protected void bindData()
        {
            string mycon = "server =localhost; Uid=root; password = ; persistsecurityinfo = True; database = aldingtest; SslMode = none";
            MySqlConnection con = new MySqlConnection(mycon);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from demo", con);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
            


        }

        protected void submit_Click(object sender, EventArgs e)
        {   
       
            string name = Request.Form.Get("name");
            string eml = Request.Form.Get("email");
            string pwd = Request.Form.Get("password");
           

            Regex hasUpper = new Regex(@"(?=.*[A-Z]).(?=.*[A-Z]).{8,}$"); // check for at least 2 upper case
            Regex hasSpec = new Regex(@"(?=.*\W).(?=.*\W).{8,}$"); // check for at least 3 special characters
            Regex hasNum = new Regex(@"(?=.*\d).{8,}$"); // check for at least one number
            
            if (!hasUpper.IsMatch(pwd) || !hasSpec.IsMatch(pwd) || !hasNum.IsMatch(pwd))
            {
                Response.Write("<script>alert('Password must contain at least two uppercase letters, three special characters, and one number, and at least 8 characters')</script>");
                return;
            }

            string date = Request.Form.Get("date");
            string radio = Request.Form.Get("gender");
            string mycon = "server =localhost; Uid=root; password = ; persistsecurityinfo = True; database = aldingtest; SslMode = none";

            MySqlConnection con = new MySqlConnection(mycon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into demo(Name, Email, Password, City, Gender, Date, Java, Python, Cplus) values(@a1, @a2, @a3, @a4, @a5, @a6, @a7, @a8, @a9)", con);
                cmd.Parameters.AddWithValue("@a1", name);
                cmd.Parameters.AddWithValue("@a2", eml);
                cmd.Parameters.AddWithValue("@a3", pwd);
                cmd.Parameters.AddWithValue("@a4", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@a5", radio);
                cmd.Parameters.AddWithValue("@a6", date);
                if (CheckBox1.Checked) // Inputting value of checkboxes into sql
                {
                    cmd.Parameters.AddWithValue("@a7", 1);
                } else
                {
                    cmd.Parameters.AddWithValue("@a7", 0);
                }
                if (CheckBox2.Checked)
                {
                    cmd.Parameters.AddWithValue("@a8", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@a8", 0);
                }
                if (CheckBox3.Checked)
                {
                    cmd.Parameters.AddWithValue("@a9", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@a9", 0);
                }
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            } catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                con.Close();
            }
            Response.Write("<script>alert('Data saved successfully')</script>");
          
         
        }

        protected void retrieve_Click(object sender, EventArgs e)
        {
            string mycon = "server =localhost; Uid=root; password = ; persistsecurityinfo = True; database = aldingtest; SslMode = none";
            MySqlConnection con = new MySqlConnection(mycon);
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select * from demo", con);
                con.Open();
                dt.Load(cmd.ExecuteReader());
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                con.Close();
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
           
           
        }

        protected void update_Click(object sender, EventArgs e)
        {
            string id = Request.Form.Get("updateID");
            string name = Request.Form.Get("name");
            string eml = Request.Form.Get("email");
            string pwd = Request.Form.Get("password");
            Regex hasUpper = new Regex(@"(?=.*[A-Z]).(?=.*[A-Z]).{8,}$"); // check for at least 2 upper case
            Regex hasSpec = new Regex(@"(?=.*\W).(?=.*\W).{8,}$"); // check for at least 3 special characters
            Regex hasNum = new Regex(@"(?=.*\d).{8,}$"); // check for at least one number

            if (pwd == "")
            {

            }
            else if (!hasUpper.IsMatch(pwd) || !hasSpec.IsMatch(pwd) || !hasNum.IsMatch(pwd))
            {
                Response.Write("<script>alert('Password must contain at least two uppercase letters, three special characters, and one number, and at least 8 characters')</script>");
                return;
            }
            string date = Request.Form.Get("date");
            string radio = Request.Form.Get("gender");
            string mycon = "server =localhost; Uid=root; password = ; persistsecurityinfo = True; database = aldingtest; SslMode = none";
            MySqlConnection con = new MySqlConnection(mycon);
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Update demo set Name = '" + name + "', Email = '" + eml + "', City = '" + DropDownList1.SelectedItem.Value + "', " +
                    "Password = '" + pwd + "', Date = '" + date + "', Gender = '" + radio + "' where id = '" + id + "'", con);
                con.Open();
                dt.Load(cmd.ExecuteReader());
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                con.Close();
            }
            Response.Write("<script>alert('Data updated successfully')</script>");
            GridView1.DataSource = dt;
            GridView1.DataBind();
           
           
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            string id = Request.Form.Get("updateID");       
            string mycon = "server =localhost; Uid=root; password = ; persistsecurityinfo = True; database = aldingtest; SslMode = none";
            MySqlConnection con = new MySqlConnection(mycon);
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from demo where id = '" + id + "'", con);
                con.Open();
                dt.Load(cmd.ExecuteReader());
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                con.Close();
            }
            Response.Write("<script>alert('Data deleted successfully')</script>");
            GridView1.DataSource = dt;
            GridView1.DataBind();
           
           
        }



        protected void search_Click(object sender, EventArgs e)
        {
            string id = Request.Form.Get("searchID");
            string mycon = "server =localhost; Uid=root; password = ; persistsecurityinfo = True; database = aldingtest; SslMode = none";
            MySqlDataAdapter da = new MySqlDataAdapter("Select * from demo where id like '" + int.Parse(id) + "%'", mycon);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            
           


        }
        
        

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bindData();
        }

        protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpr = e.SortExpression;
            
            if (SortDir == SortDirection.Ascending)
            {
                SortDir = SortDirection.Descending;
                SortGridView(sortExpr, " DESC");
            }
            else
            {
                SortDir = SortDirection.Ascending;
                SortGridView(sortExpr, " ASC");
            }
            


        }

        private void SortGridView(string sortExpression, string direction)
        {
            string mycon = "server =localhost; Uid=root; password = ; persistsecurityinfo = True; database = aldingtest; SslMode = none";
            MySqlConnection con = new MySqlConnection(mycon);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from demo ", con);
            DataTable dt = new DataTable();
            DataView dv = new DataView(dt);
            dt.Load(cmd.ExecuteReader());
            dv.Sort = sortExpression + direction;
            GridView1.DataSource = dv;
            GridView1.DataBind();
            con.Close();

        }

        public SortDirection SortDir
        {
            get {
                if (ViewState["sortDirection"] == null) {
                    ViewState["sortDirection"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["sortDirection"];
                }
            set { 
                ViewState["sortDirection"] = value;
            }
        }

      
    }
}