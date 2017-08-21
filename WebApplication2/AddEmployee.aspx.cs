using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace WebApplication2
{
    public partial class Screen1 : System.Web.UI.Page
    {
        MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
        static String con_string1 = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString.ToString();
        MySqlConnection conn = new MySqlConnection(con_string1.ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
                String con_string = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString.ToString();
                MySqlConnection conn = new MySqlConnection(con_string.ToString());
                MySqlCommand cmd = new MySqlCommand("selectManagerData3", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
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
                    if (conn.State == ConnectionState.Closed)
                        conn.Close();

                }

            }
        }

        protected void bSave_Click(object sender, EventArgs e)
        {
            if(conn.State==ConnectionState.Closed)
                conn.Open();
            List<String> l1 = new List<string>();
            MySqlCommand mycmd = new MySqlCommand("insertEmpRoles", conn);
            mycmd.CommandType = CommandType.StoredProcedure;
            foreach (ListItem item in libRoles.Items)
            {
                if (item.Selected)
                {
                    //l1.Add(item.Text);
                    mycmd.Parameters.AddWithValue("empId", tbEmployeeId.Text);
                    mycmd.Parameters.AddWithValue("role", item.Text);
                   mycmd.ExecuteNonQuery();
                    mycmd.Parameters.Clear();
                    mycmd.Dispose();
                }
            }

            //StringBuilder stri = new StringBuilder(String.Empty);
            //foreach (string item in l1)
            //{
            //    const string qry = "insert into [Roles](employeeId,Roles)values";
            //    stri.AppendFormat("{0}('{1}''{2}');", qry, tbEmployeeId.Text, item);
            //}
            //MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            //string con_string1 = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString.ToString();

            MySqlCommand cmd1 = new MySqlCommand("insertEmpDetails", conn);
            cmd1.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter adp1 = new MySqlDataAdapter(cmd1);

            MySqlCommand cmd2 = new MySqlCommand();
           // cmd2.CommandText = stri.ToString();
            // cmd2.ExecuteNonQuery();

            DataSet ds1 = new DataSet();
            try
            {
                
                String ManagerId = "";
                ManagerId = ddlManagerList.SelectedValue;
                cmd1.Parameters.AddWithValue("emid", ManagerId);
                cmd1.Parameters.AddWithValue("eid", tbEmployeeId.Text);
                cmd1.Parameters.AddWithValue("efname", tbFirstName.Text);
                cmd1.Parameters.AddWithValue("elname", tbLastName.Text);
                int i = cmd1.ExecuteNonQuery();
                if (i != -1)
                {
                    lblStatus.Visible = true;
                    lblStatus.Text = "Employee Added Successfully!";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    ResetInfo();
                }else
                {
                    lblStatus.Visible = false;
                    lblStatus.Text = "Error Adding Employee Details";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
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
                cmd2.Dispose();

            }

        }
        protected void ddlManagerList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void bCancel_Click(object sender, EventArgs e)
        {
            ResetInfo();
        }

        protected void ResetInfo()
        {
            ddlManagerList.SelectedIndex = 0;
            tbEmployeeId.Text = "";
            tbFirstName.Text = "";
            tbLastName.Text = "";
            libRoles.SelectedIndex = 0;
           
        }
    }
}