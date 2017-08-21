using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;

namespace WebApplication2
{
    public partial class Screen2 : System.Web.UI.Page
    {
        MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
        static String con_string = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString.ToString();
        MySqlConnection conn = new MySqlConnection(con_string.ToString());
        string managerid = "All";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                MySqlCommand cmd = new MySqlCommand("selectManagerData3", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                try
                {
                    if(conn.State==ConnectionState.Closed)
                        conn.Open();
                    cmd.ExecuteScalar();
                    adp.Fill(ds);

                    ddlManagerList.DataSource = ds;
                    ddlManagerList.DataTextField = "employeeName";
                    ddlManagerList.DataValueField = "employeeId";
                    ddlManagerList.DataBind();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
                finally
                {
                    conn.Close();
                    cmd.Dispose();
                }
            
                BindData();
            }
        }

        protected void ddlManagerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            managerid = ddlManagerList.SelectedValue;

           BindData();
        }

        protected void BindData()
        {
            MySqlCommand cmd1 = new MySqlCommand("selectEmployeeData", conn);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("mid", managerid);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                adp1.Fill(ds);
                gdEmployee.DataSource = ds;
                gdEmployee.DataBind();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                cmd1.Dispose();
            }
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AddEmployee.aspx");
        }
    }
}