using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;

namespace Attend
{
    public partial class Employee : Form
    {
        private SQLiteCommand sqlCommand;
        private SQLiteDataAdapter DataAdapter;
        private DataSet Daset = new DataSet();
        private System.Data.DataTable sqlTable = new System.Data.DataTable();
        private SQLiteConnection sqlConnection;

        public Employee()
        {

            InitializeComponent();
            uData();
        }
        private void Connect()
        {
            sqlConnection = new SQLiteConnection("Data Source = C:\\Users\\N.D\\Desktop\\Attend  V 1.0.04\\Attend\\bin\\Debug\\Attend.db");
        }
        private void ExQ(string QueryData)
        {
            Connect();
            sqlConnection.Open();
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = QueryData;
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            sqlConnection.Close();
        }
        private void uData()
        {
            Connect();
            sqlConnection.Open();
            sqlCommand = sqlConnection.CreateCommand();
            string CommandText = "Select * from Employee";
            DataAdapter = new SQLiteDataAdapter(CommandText, sqlConnection);
            Daset.Reset();
            DataAdapter.Fill(Daset);
            sqlTable = Daset.Tables[0];
            Grid.DataSource = sqlTable;
            sqlConnection.Close();
        }
        private void Employee_Load(object sender, EventArgs e)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                using (SQLiteDataAdapter DataAdapter = new SQLiteDataAdapter("select * from Employee", sqlConnection))
                {
                    System.Data.DataTable sqlTable = new System.Data.DataTable("First_Name");
                    DataAdapter.Fill(sqlTable);
                    Grid.DataSource = sqlTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Attend", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            string QueryData = "insert into Employee(Personal_ID, First_Name, Last_Name, Gender, Date, " +
                "Cellphone_Number, Address, Postal_Code, Mail, Position)" +
                "Values('" + txtPID.Text + "','" + txtFN.Text + "','" + txtLN.Text + "','" +
                cboG.Text + "','" + datePicker.Text + "','" +
                txtC.Text + "','" + txtA.Text + "','" + txtPC.Text + "','" +
                txtMA.Text + "','" + txtPT.Text + "')";

            ExQ(QueryData);
            uData();
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            string QueryData = "delete from Employee where Personal_ID = '" + txtPID.Text + "'";
            ExQ(QueryData);
            uData();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet worksheet = null;
            try
            {
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Employee List";
                for (int rowIndex = 0; rowIndex < Grid.Rows.Count - 1; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < Grid.Columns.Count; colIndex++)
                    {
                        if (rowIndex == 0)
                        {
                            worksheet.Cells[rowIndex + 1, colIndex + 1] = Grid.Columns[colIndex].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[rowIndex + 1, colIndex + 1] = Grid.Rows[rowIndex].Cells[colIndex].Value.ToString();
                        }
                    }

                }
                if (SFDEM12.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(SFDEM12.FileName);
                    Process.Start("excel.exe", SFDEM12.FileName);
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

        private void btnS_Click(object sender, EventArgs e)
        {
            DataView DataV = sqlTable.DefaultView;
            DataV.RowFilter = string.Format("Last_Name like '%{0}%'", txtS.Text);
            Grid.DataSource = DataV.ToTable();

        }



        private void txtS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView DataV = sqlTable.DefaultView;
                DataV.RowFilter = string.Format("Last_Name like '%{0}%'", txtS.Text);
                Grid.DataSource = DataV.ToTable();
            }
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtPID.Text = Grid.SelectedRows[0].Cells[1].Value.ToString();
                txtFN.Text = Grid.SelectedRows[0].Cells[2].Value.ToString();
                txtLN.Text = Grid.SelectedRows[0].Cells[3].Value.ToString();
                txtA.Text = Grid.SelectedRows[0].Cells[4].Value.ToString();
                txtC.Text = Grid.SelectedRows[0].Cells[5].Value.ToString();
                txtMA.Text = Grid.SelectedRows[0].Cells[6].Value.ToString();
                cboG.Text = Grid.SelectedRows[0].Cells[7].Value.ToString();
                datePicker.Text = (string)Grid.SelectedRows[0].Cells[8].Value.ToString();
                txtPC.Text = Grid.SelectedRows[0].Cells[9].Value.ToString();
                txtPT.Text = Grid.SelectedRows[0].Cells[10].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Attend", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRE_Click(object sender, EventArgs e)
        {
            try
            {
                datePicker.ResetText();
                foreach (Control txt in panel.Controls)
                {
                    if (txt is System.Windows.Forms.TextBox)
                        ((System.Windows.Forms.TextBox)txt).Clear();
                }

                foreach (Control cbo in panel.Controls)
                {
                    if (cbo is ComboBox)
                    {
                        ((ComboBox)cbo).Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atend", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUP_Click(object sender, EventArgs e)
        {
            
            using (SQLiteConnection sqlConnection1 = new SQLiteConnection())
            {
                sqlConnection1.ConnectionString = "Data Source = C:\\Users\\N.D\\Desktop\\Attend  V 1.0.04\\Attend\\bin\\Debug\\Attend.db";
                sqlConnection1.Open();
                using (SQLiteCommand sqlCommand1 = new SQLiteCommand(sqlConnection1))
                {
                    sqlCommand1.CommandText =
                        ("update Employee set Gender='" + cboG.Text + "',Postal_Code='" + txtPC.Text + "',Mail='" + txtMA.Text + "',Address='" + txtA.Text + "',Position='" + txtPT.Text + "',First_Name='" + txtFN.Text + "',Cellphone_Number='" + txtC.Text + "', Last_Name ='" + txtLN.Text + "' where Personal_ID='" + txtPID.Text + "'");

                    sqlCommand1.Parameters.Add("Cellphone_Number", DbType.String).Value = txtC.Text;
                    sqlCommand1.Parameters.Add("Last_Name", DbType.String).Value = txtLN.Text;
                    sqlCommand1.Parameters.Add("Personal_ID", DbType.String).Value = txtPID.Text;
                    sqlCommand1.Parameters.Add("Gender", DbType.String).Value = cboG.Text;
                    sqlCommand1.Parameters.Add("First_Name", DbType.String).Value = txtFN.Text;
                    sqlCommand1.Parameters.Add("Mail", DbType.String).Value = txtMA.Text;
                    sqlCommand1.Parameters.Add("Postal_Code", DbType.String).Value = txtPC.Text;
                    sqlCommand1.Parameters.Add("Position", DbType.String).Value = txtPT.Text;
                    sqlCommand1.Parameters.Add("Address", DbType.String).Value = txtA.Text;
                    sqlCommand1.ExecuteNonQuery();
                }
            }
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word._Application word = new Microsoft.Office.Interop.Word.Application();
            Document doc = word.Documents.Add();
            Microsoft.Office.Interop.Word.Range rng = doc.Range(0, 0);
            Table wdTable = doc.Tables.Add(rng, Grid.Rows.Count, Grid.Columns.Count);
            wdTable.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleDouble;
            wdTable.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
            try
            {
                doc = word.ActiveDocument;
                for (int i = 0; i < Grid.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < Grid.Columns.Count; j++)
                    {
                        wdTable.Cell(i + 1, j + 1).Range.InsertAfter(Grid.Rows[i].Cells[j].Value.ToString());
                    }
                }
                if (SFDEM12.ShowDialog() == DialogResult.OK)
                {
                    doc.SaveAs(SFDEM12.FileName);
                    Process.Start("winword.exe", SFDEM12.FileName);
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
