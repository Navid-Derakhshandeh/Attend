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
    public partial class MAC : Form
    {
        string connString = @"Data Source=DESKTOP-21H6HAU\DESKTOP;Initial Catalog=Attend;Integrated Security=True;
            Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        SqlDataAdapter dataAdapter;
        System.Data.DataTable table;
        SqlConnection conn;
        string selectionStatement = "Select * from MC";
        public MAC()
        {
            InitializeComponent();
        }

        private void MAC_Load(object sender, EventArgs e)
        {
            cboSearch.SelectedIndex = 0;
            dataGridView1.DataSource = bindingSource4;
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
                bindingSource4.DataSource = table;
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
                bindingSource4.EndEdit();
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
            string insert = @"insert into MC(First_Name, Last_Name, Phone_C, Country, Image_C)

                               values(@First_Name, @Last_Name, @Phone_C, @Country, @Image_C)";
            using (conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    command = new SqlCommand(insert, conn);
                    command.Parameters.AddWithValue(@"Last_Name", txtLN.Text);
                    command.Parameters.AddWithValue(@"First_Name", txtFN.Text);
                    command.Parameters.AddWithValue(@"Country", txtNAT.Text);
                    command.Parameters.AddWithValue(@"Phone_C", txtPHO.Text);
                    if (openFileDialog2.FileName != "")
                        command.Parameters.AddWithValue(@"Image_C", File.ReadAllBytes(openFileDialog2.FileName));
                    else
                        command.Parameters.Add("@Image_C", SqlDbType.VarBinary).Value = DBNull.Value;

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.BackgroundImage = pictureBox1.Image;
            frm.Size = pictureBox1.Image.Size;
            frm.Show();
        }

        private void btnGetImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
                pictureBox1.Load(openFileDialog2.FileName);
        }

        private void btnEE_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet worksheet = null;
            try
            {
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Clients List";
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
                if (SFD4.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(SFD4.FileName);
                    Process.Start("excel.exe", SFD4.FileName);
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
                case "First_Name":
                    GetData("select * from MC where lower(first_name) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;
                case "Last_Name":
                    GetData("select * from MC where lower(last_name) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;
                case "Phone_C":
                    GetData("select * from MC where lower(phone_c) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;
                case "Country":
                    GetData("select * from MC where lower(country) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;
            }
        }
    }
}
