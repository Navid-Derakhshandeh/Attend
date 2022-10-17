//Navid-Derakhshandeh
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;


namespace Attend
{
    public partial class IMS : Form
    {
        string connString = @"Data Source=DESKTOP-21H6HAU\DESKTOP;Initial Catalog=Attend;Integrated Security=True;
            Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        SqlDataAdapter dataAdapter;
        System.Data.DataTable table;
        SqlConnection conn;
        string selectionStatement = "Select * from Inventory";
        public IMS()
        {
            InitializeComponent();
        }

        private void IMS_Load(object sender, EventArgs e)
        {
            cboSearch.SelectedIndex = 0;
            dataGridView1.DataSource = bindingSource1;
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
                bindingSource1.DataSource = table;
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
            string insert = @"insert into Inventory(Date_Added, Name, Manufacture, Model_Name, Quantity, Cost_Price, Sell_Price,
                                                      Location, Condition, Availabel, Allocated, Suppliers, Notes, Category, Serial_Number, Image)

                               values(@Date_Added, @Name, @Manufacture, @Model_Name, @Quantity, @Cost_Price, @Sell_Price,
                                                      @Location, @Condition, @Availabel, @Allocated, @Suppliers, @Notes, @Category, @Serial_Number, @Image)";
            using (conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    command = new SqlCommand(insert, conn);
                    command.Parameters.AddWithValue(@"Date_Added", dateTimePicker1.Value.Date);
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
                    if (dlgOI.FileName != "")
                        command.Parameters.AddWithValue(@"Image", File.ReadAllBytes(dlgOI.FileName));
                    else
                        command.Parameters.Add("@Image", SqlDbType.VarBinary).Value = DBNull.Value;
                    
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
            try
            {
                bindingSource1.EndEdit();
                dataAdapter.Update(table);
                MessageBox.Show("Update Successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentCell.OwningRow;
            string value = row.Cells["ID"].Value.ToString();
            string Pname = row.Cells["Name"].Value.ToString();
            string quantity = row.Cells["Quantity"].Value.ToString();
            DialogResult result = MessageBox.Show("Do You Want to Delete This Record " + Pname + "" + quantity + ", record " + value, "Message",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            string deleteState = @"Delete from Inventory where id = '" + value + " ' ";

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch (cboSearch.SelectedItem.ToString())
            {
                case "Name":
                    GetData("select * from Inventory where lower(name) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;
                case "Manufacture":
                    GetData("select * from Inventory where lower(manufacture) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;
                case "Suppliers":
                    GetData("select * from Inventory where lower(suppliers) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;
            }
        }

        private void btnGetImage_Click(object sender, EventArgs e)
        {
            if (dlgOI.ShowDialog() == DialogResult.OK)
                pictureBox1.Load(dlgOI.FileName);
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.BackgroundImage = pictureBox1.Image;
            frm.Size = pictureBox1.Image.Size;
            frm.Show();
        }

        private void btnSaveToText_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                            sw.Write(cell.Value);
                        sw.WriteLine();
                    }
                }
                Process.Start("notepad.exe", saveFileDialog1.FileName);
            }
        }

        private void btnExportOpen_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet worksheet = null;
            try
            {
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Inventory List";
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
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog1.FileName);
                    Process.Start("excel.exe", saveFileDialog1.FileName);
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

        private void btnOpenWord_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word._Application word = new Microsoft.Office.Interop.Word.Application();
            Document doc = word.Documents.Add();
            Microsoft.Office.Interop.Word.Range rng = doc.Range(0, 0);
            Table wdTable = doc.Tables.Add(rng, dataGridView1.Rows.Count, dataGridView1.Columns.Count);
            wdTable.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleDouble;
            wdTable.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
            try
            {
                doc = word.ActiveDocument;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        wdTable.Cell(i + 1, j + 1).Range.InsertAfter(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    }
                }
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    doc.SaveAs(saveFileDialog1.FileName);
                    Process.Start("winword.exe", saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                word.Quit();
                word = null;
                doc = null;

            }
        }
    }
}
