using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;


namespace AttendWebVersion
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private SqlConnection connstring2;
        private SqlCommand command2;
        private string constring, query;
        private void Conn2()
        {
            constring = ConfigurationManager.ConnectionStrings["AttendConnectionString"].ToString();
            connstring2 = new SqlConnection(constring);
            connstring2.Open();

        }
        string connString = ConfigurationManager.ConnectionStrings["AttendConnectionString"].ConnectionString;

        SqlDataAdapter dataAdapter;
        System.Data.DataTable table;
        SqlConnection conn;
        string selectionStatement = "Select * from Inventory";

        private void bind2()
        {
            Conn2();
            query = "select *from Inventory"; 
            command2 = new SqlCommand(query, connstring2);
            SqlDataReader dr = command2.ExecuteReader();
            
            
            connstring2.Close();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        private void ExportasExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Excel" + DateTime.Now + ".xls";
            StringWriter stringwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(stringwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridView1.GridLines = GridLines.Both;
            GridView1.HeaderStyle.Font.Bold = true;
            GridView1.RenderControl(htmltextwrtter);
            Response.Write(stringwritter.ToString());
            GridView1.AllowPaging = false;
            Response.End();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                bind2();

            }
            if (!IsPostBack)
            {
                Bind();
            }

            if (!this.IsPostBack)
            {
                this.Bind3();
            }
            GetData(selectionStatement);
        }
        private void Bind3()
        {
            string connstring = ConfigurationManager.ConnectionStrings["AttendConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                using (SqlCommand command = new SqlCommand())
                {
                   
                    command.CommandText = "SELECT Name, Manufacture, Model_Name FROM Inventory WHERE Name LIKE '%' + @Name + '%'";
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@Name", txtSearch.Text.Trim());
                    DataTable datat = new DataTable();
                    using (SqlDataAdapter sqld = new SqlDataAdapter(command))
                    {
                        sqld.Fill(datat);
                        //GridView1.DataSource = datat;
                       //GridView1.DataBind();

                    }
                }
            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.Bind3();
        }
        void clear()
        {
            txtName.Text = "";
            txtModel.Text = "";
            txtQuantity.Text = "";
            txtAL.Text = "";
            txtAV.Text = "";
            txtC.Text = "";
            txtCa.Text = "";
            txtCost.Text = "";
            txtDate.Text = "";
            txtLoc.Text = "";
            txtM.Text = "";
            txtNotes.Text = "";
            txtS.Text = "";
            txtSell.Text = "";
            txtSerial.Text = "";
        }
        private void GetData(string selectCommand)
        {
            try
            {
                dataAdapter = new SqlDataAdapter(selectCommand, connString);
                table = new System.Data.DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);


            }
            catch (SqlException)
            {


            }

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            string insert = @"insert into Inventory(Date_Added, Name, Manufacture, Model_Name, Quantity, Cost_Price, Sell_Price,
                                                      Location, Condition, Availabel, Allocated, Suppliers, Notes, Category, Serial_Number)

                               values(@Date_Added, @Name, @Manufacture, @Model_Name, @Quantity, @Cost_Price, @Sell_Price,
                                                      @Location, @Condition, @Availabel, @Allocated, @Suppliers, @Notes, @Category, @Serial_Number)";
            using (conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    command = new SqlCommand(insert, conn);
                    command.Parameters.AddWithValue(@"Date_Added", txtDate.Text);
                    command.Parameters.AddWithValue(@"Name", txtName.Text);
                    command.Parameters.AddWithValue(@"Model_Name", txtModel.Text); ;
                    command.Parameters.AddWithValue(@"Quantity", txtQuantity.Text);
                    command.Parameters.AddWithValue(@"Cost_Price", txtCost.Text);
                    command.Parameters.AddWithValue(@"Sell_Price", txtSell.Text);
                    command.Parameters.AddWithValue(@"Location", txtLoc.Text);
                    command.Parameters.AddWithValue(@"Condition", txtC.Text);
                    command.Parameters.AddWithValue(@"Manufacture", txtM.Text);
                    command.Parameters.AddWithValue(@"Availabel", txtAV.Text);
                    command.Parameters.AddWithValue(@"Allocated", txtAL.Text);
                    command.Parameters.AddWithValue(@"Suppliers", txtS.Text);
                    command.Parameters.AddWithValue(@"Serial_Number", txtSerial.Text);
                    command.Parameters.AddWithValue(@"Category", txtCa.Text);
                    command.Parameters.AddWithValue(@"Notes", txtNotes.Text);
                    int w = command.ExecuteNonQuery();
                    if (w > 0)
                    {
                        Response.Write("<script>alert('Data Has Saved')</script>");
                    }
                }
                catch (Exception)
                {

                }


            }
            GetData(selectionStatement);
            Bind();
            clear();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtModel.Text = "";
            txtQuantity.Text = "";
            txtAL.Text = "";
            txtAV.Text = "";
            txtC.Text = "";
            txtCa.Text = "";
            txtCost.Text = "";
            txtDate.Text = "";
            txtLoc.Text = "";
            txtM.Text = "";
            txtNotes.Text = "";
            txtS.Text = "";
            txtSell.Text = "";
            txtSerial.Text = "";
        }
        protected void Bind()
        {

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("Select * from Inventory", conn);
                SqlDataReader reader = command.ExecuteReader();
                
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Bind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            TextBox name = GridView1.Rows[e.RowIndex].FindControl("txtName") as TextBox;
            TextBox modelname = GridView1.Rows[e.RowIndex].FindControl("txtModel") as TextBox;
            TextBox quantity = GridView1.Rows[e.RowIndex].FindControl("txtQuantity") as TextBox;
            TextBox costprice = GridView1.Rows[e.RowIndex].FindControl("txtCost") as TextBox;
            TextBox sellprice = GridView1.Rows[e.RowIndex].FindControl("txtSell") as TextBox;
            TextBox location = GridView1.Rows[e.RowIndex].FindControl("txtLoc") as TextBox;
            TextBox condition = GridView1.Rows[e.RowIndex].FindControl("txtC") as TextBox;
            TextBox manufacture = GridView1.Rows[e.RowIndex].FindControl("txtM") as TextBox;
            TextBox availabel = GridView1.Rows[e.RowIndex].FindControl("txtAV") as TextBox;
            TextBox allocated = GridView1.Rows[e.RowIndex].FindControl("txtAL") as TextBox;
            TextBox suppliers = GridView1.Rows[e.RowIndex].FindControl("txtS") as TextBox;
            TextBox serialnumber = GridView1.Rows[e.RowIndex].FindControl("txtSerial") as TextBox;
            TextBox category = GridView1.Rows[e.RowIndex].FindControl("txtCa") as TextBox;
            TextBox notes = GridView1.Rows[e.RowIndex].FindControl("txtNotes") as TextBox;
            TextBox date = GridView1.Rows[e.RowIndex].FindControl("txtDate") as TextBox;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("update Inventory set Date_Added = '" + date + "',Name = '" + name + "',Manufacture = '" + manufacture + "', Model_Name ='" + modelname + "', Quantity = '" + quantity + "', Cost_Price = '" + costprice + "', Sell_Price = '" + sellprice + "', Location = '" + location + "', Condition = '" + condition + "', Availabel = '" + availabel + "', Allocated = '" + allocated + "', Suppliers = '" + suppliers + "', Notes = '" + notes + "', Category = '" + category + "', Serial_Number ='" + serialnumber + "'where ID = '" + id + "'", conn);
                int w1 = command.ExecuteNonQuery();
                if(w1>0)
                {
                    Response.Write("<script>alert('Data Has Improved') </script>");
                    GridView1.EditIndex = -1;
                    Bind();
                }
                

            }

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Bind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            using(SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("delete from  Inventory where ID = '" + id + "'", conn);
                int W2 = command.ExecuteNonQuery();
                if(W2 > 0)
                {
                    Response.Write("<script>alert('Data Has Deleted')</script>");
                    GridView1.EditIndex = -1;
                    Bind();

                }
            }
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            ExportasExcel();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.Bind3();
            
            //GetData("select * from Inventory where Name like '%" + txtSearch.Text.ToLower() + "%'");
            //using (SqlConnection conn = new SqlConnection(connString))
            //{
            //    conn.Open();
                
            //    SqlCommand command = new SqlCommand("select * from Inventory where Name like '%" + txtSearch.Text.ToLower() + "%'", conn);
            //    //int W5 =
            //    command.ExecuteNonQuery();
            //    //if (W5 > 0)
            //    //{
            //    //    GridView1.Visible = true;
            //    //    txtSearch.Text = " ";
            //    //    Label17.Text = " ";
            //    //    Bind();
            //    //}

            //}

        }
    }
}