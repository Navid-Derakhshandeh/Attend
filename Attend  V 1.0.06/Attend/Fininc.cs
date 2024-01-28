using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace Attend
{
    public partial class Fininc : Form
    {
        string connString = @"Data Source=DESKTOP-21H6HAU\DESKTOP;Initial Catalog=Attend;Integrated Security=True;
            Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        SqlDataAdapter dataAdapter;
        System.Data.DataTable table;
        SqlConnection conn;
        string selectionStatement = "Select * from FIC";


        public Fininc()
        {
            InitializeComponent();
        }

        private void Fininc_Load(object sender, EventArgs e)
        {
            cboSearch.SelectedIndex = 0;
            dataGridView1.DataSource = bindingSource7;
            GetData(selectionStatement);
        }
        private void GetData(string selectCommand)
        {
            try
            {
                dataAdapter = new SqlDataAdapter(selectCommand, connString);
                table = new System.Data.DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bindingSource7.DataSource = table;
                dataGridView1.Columns[0].ReadOnly = true;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);

            }

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            string insert = @"insert into FIC(Year, Income)

                               values(@Year, @Income)";
            using (conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    command = new SqlCommand(insert, conn);
                    command.Parameters.AddWithValue(@"Year", txtY.Text);
                    command.Parameters.AddWithValue(@"Income", txtI.Text);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            GetData(selectionStatement);
            dataGridView1.Update();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch (cboSearch.SelectedItem.ToString())
            {
                case "Year":
                    GetData("select * from FIC where lower(year) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;
                case "Income":
                    GetData("select * from FIC where lower(income) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;
               
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentCell.OwningRow;
            string value = row.Cells["ID"].Value.ToString();
            string year = row.Cells["Year"].Value.ToString();
            string income = row.Cells["Income"].Value.ToString();
            DialogResult result = MessageBox.Show("Do You Want to Delete This Record " + year + "" + income + ", record " + value, "Message",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            string deleteState = @"Delete from FIC where id = '" + value + " ' ";

            if (result == DialogResult.Yes)
            {
                using (conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand comm = new SqlCommand(deleteState, conn);
                        comm.ExecuteNonQuery();
                        GetData(selectionStatement);
                        dataGridView1.Update();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void dataGridView1_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
            try
            {
                bindingSource7.EndEdit();
                dataAdapter.Update(table);
                MessageBox.Show("Update Successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
