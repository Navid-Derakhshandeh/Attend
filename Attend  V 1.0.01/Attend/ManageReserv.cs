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
    public partial class ManageReserv : Form
    {
        string connString = @"Data Source=DESKTOP-21H6HAU\DESKTOP;Initial Catalog=Attend;Integrated Security=True;
            Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        SqlDataAdapter dataAdapter;
        System.Data.DataTable table;
        SqlConnection conn;
        string selectionStatement = "Select * from MRE";
        public ManageReserv()
        {
            InitializeComponent();
        }

        private void ManageReserv_Load(object sender, EventArgs e)
        {
            cboSearch.SelectedIndex = 0;
            dataGridView1.DataSource = bindingSource3;
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
                bindingSource3.DataSource = table;
                dataGridView1.Columns[0].ReadOnly = true;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
            try
            {
                bindingSource3.EndEdit();
                dataAdapter.Update(table);
                MessageBox.Show("Update Successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            string insert = @"insert into MRE(Reserv_ID, Client_ID, Room_T, Room_N, Date_IN, Date_OUT)

                               values(@Reserv_ID, @Client_ID, @Room_T, @Room_N, @Date_IN, @Date_OUT)";
            using (conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    command = new SqlCommand(insert, conn);
                    command.Parameters.AddWithValue(@"Reserv_ID", txtREN.Text);
                    command.Parameters.AddWithValue(@"Client_ID", txtCID.Text);
                    command.Parameters.AddWithValue(@"Room_T", txtROT.Text);
                    command.Parameters.AddWithValue(@"Room_N", txtRON.Text);
                    command.Parameters.AddWithValue(@"Date_IN", dateTimePicker1.Value.Date);
                    command.Parameters.AddWithValue(@"Date_OUT", dateTimePicker2.Value.Date);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentCell.OwningRow;
            string value = row.Cells["ID"].Value.ToString();
            string value1 = row.Cells["Reserv_ID"].Value.ToString();
            string ci = row.Cells["Client_ID"].Value.ToString();
            string rot = row.Cells["Room_T"].Value.ToString();
            string ron = row.Cells["Room_N"].Value.ToString();
            DialogResult result = MessageBox.Show("Do You Want to Delete This Record " + ci + "" + rot + ", record " + value, "Message",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            string deleteState = @"Delete from MRE where id = '" + value + " ' ";

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

        private void btnEE_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet worksheet = null;
            try
            {
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Reserv List";
                for (int rowIndex = 0; rowIndex < dataGridView1.Rows.Count - 1; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++)
                    {
                        if (rowIndex == 0)
                        {
                            worksheet.Cells[rowIndex + 1, colIndex + 1] = dataGridView1.Columns[colIndex].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[rowIndex + 1, colIndex + 1] = dataGridView1.Rows[rowIndex].Cells[colIndex].Value.ToString();
                        }
                    }

                }
                if (SFD2.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(SFD2.FileName);
                    Process.Start("excel.exe", SFD2.FileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch (cboSearch.SelectedItem.ToString())
            {
                case "Reserv_ID":
                    GetData("select * from MRE where lower(reserv_id) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;
                case "Client_ID":
                    GetData("select * from MRE where lower(client_id) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;
                case "Date_IN":
                    GetData("select * from MRE where lower(date_in) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;
                case "Date_OUT":
                    GetData("select * from MRE where lower(date_out) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;
            }
        }
    }
}
