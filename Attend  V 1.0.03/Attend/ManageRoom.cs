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
    public partial class ManageRoom : Form
    {
        string connString = @"Data Source=DESKTOP-21H6HAU\DESKTOP;Initial Catalog=Attend;Integrated Security=True;
            Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        SqlDataAdapter dataAdapter;
        System.Data.DataTable table;
        SqlConnection conn;
        string selectionStatement = "Select * from MRO";

        public ManageRoom()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            string insert = @"insert into MRO(Room_Number, Room_Type, Phone, Condition)

                               values(@Room_Number, @Room_Type, @Phone, @Condition)";
            using (conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    command = new SqlCommand(insert, conn);
                    command.Parameters.AddWithValue(@"Room_Number", txtRN.Text);
                    command.Parameters.AddWithValue(@"Room_Type", txtRT.Text);
                    command.Parameters.AddWithValue(@"Phone", txtPH.Text);
                    command.Parameters.AddWithValue(@"Condition", txtCO.Text);

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
            string value1 = row.Cells["Room_Number"].Value.ToString();
            string rt = row.Cells["Room_Type"].Value.ToString();
            string co = row.Cells["Condition"].Value.ToString();
            string ph = row.Cells["Phone"].Value.ToString();
            DialogResult result = MessageBox.Show("Do You Want to Delete This Record " + rt + "" + co + ", record " + value, "Message",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            string deleteState = @"Delete from MRO where id = '" + value + " ' ";

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
                worksheet.Name = "Room List";
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
                if (SFD1.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(SFD1.FileName);
                    Process.Start("excel.exe", SFD1.FileName);
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
                case "Room_Number":
                    GetData("select * from MRO where lower(room_number) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;
                case "Room_Type":
                    GetData("select * from MRO where lower(room_type) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;
                case "Phone":
                    GetData("select * from MRO where lower(phone) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;
                case "Condition":
                    GetData("select * from MRO where lower(condition) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;
            }
        }

        private void ManageRoom_Load(object sender, EventArgs e)
        {
            cboSearch.SelectedIndex = 0;
            dataGridView1.DataSource = bindingSource2;
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
                bindingSource2.DataSource = table;
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
                bindingSource2.EndEdit();
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
