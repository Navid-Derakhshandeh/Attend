
namespace Attend
{
    partial class MAC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFN = new System.Windows.Forms.TextBox();
            this.txtLN = new System.Windows.Forms.TextBox();
            this.txtPHO = new System.Windows.Forms.TextBox();
            this.txtNAT = new System.Windows.Forms.TextBox();
            this.bindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.SFD4 = new System.Windows.Forms.SaveFileDialog();
            this.btnEE = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboSearch = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnGetImage = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(29, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(29, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(60, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Phone:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(33, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 40);
            this.label4.TabIndex = 3;
            this.label4.Text = "Country or \r\nNationality:";
            // 
            // txtFN
            // 
            this.txtFN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtFN.Location = new System.Drawing.Point(147, 29);
            this.txtFN.Name = "txtFN";
            this.txtFN.Size = new System.Drawing.Size(164, 26);
            this.txtFN.TabIndex = 4;
            // 
            // txtLN
            // 
            this.txtLN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtLN.Location = new System.Drawing.Point(147, 77);
            this.txtLN.Name = "txtLN";
            this.txtLN.Size = new System.Drawing.Size(164, 26);
            this.txtLN.TabIndex = 5;
            // 
            // txtPHO
            // 
            this.txtPHO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPHO.Location = new System.Drawing.Point(147, 123);
            this.txtPHO.Name = "txtPHO";
            this.txtPHO.Size = new System.Drawing.Size(164, 26);
            this.txtPHO.TabIndex = 6;
            // 
            // txtNAT
            // 
            this.txtNAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtNAT.Location = new System.Drawing.Point(147, 179);
            this.txtNAT.Name = "txtNAT";
            this.txtNAT.Size = new System.Drawing.Size(164, 26);
            this.txtNAT.TabIndex = 7;
            // 
            // bindingSource4
            // 
            this.bindingSource4.DataSource = typeof(Attend.MC);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // SFD4
            // 
            this.SFD4.Filter = "(*.xlsx)|*.xlsx|(*.txt)|*.txt|(*.docx)|*.docx";
            // 
            // btnEE
            // 
            this.btnEE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnEE.Location = new System.Drawing.Point(354, 165);
            this.btnEE.Name = "btnEE";
            this.btnEE.Size = new System.Drawing.Size(192, 40);
            this.btnEE.TabIndex = 125;
            this.btnEE.Text = "Export As Excel File";
            this.btnEE.UseVisualStyleBackColor = true;
            this.btnEE.Click += new System.EventHandler(this.btnEE_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAdd.Location = new System.Drawing.Point(392, 94);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 33);
            this.btnAdd.TabIndex = 124;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSearch.Location = new System.Drawing.Point(49, 318);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(93, 33);
            this.btnSearch.TabIndex = 137;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboSearch
            // 
            this.cboSearch.FormattingEnabled = true;
            this.cboSearch.Items.AddRange(new object[] {
            "First_Name",
            "Last_Name",
            "Phone_C",
            "Country"});
            this.cboSearch.Location = new System.Drawing.Point(39, 281);
            this.cboSearch.Name = "cboSearch";
            this.cboSearch.Size = new System.Drawing.Size(121, 21);
            this.cboSearch.TabIndex = 136;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(105, 234);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(230, 20);
            this.txtSearch.TabIndex = 135;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.Location = new System.Drawing.Point(35, 234);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 20);
            this.label10.TabIndex = 134;
            this.label10.Text = "Search:";
            // 
            // btnGetImage
            // 
            this.btnGetImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnGetImage.Location = new System.Drawing.Point(371, 29);
            this.btnGetImage.Name = "btnGetImage";
            this.btnGetImage.Size = new System.Drawing.Size(154, 46);
            this.btnGetImage.TabIndex = 139;
            this.btnGetImage.Text = "Upload Image";
            this.btnGetImage.UseVisualStyleBackColor = true;
            this.btnGetImage.Click += new System.EventHandler(this.btnGetImage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(563, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 225);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 138;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(313, 274);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(475, 202);
            this.dataGridView1.TabIndex = 140;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // MAC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 488);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGetImage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cboSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnEE);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtNAT);
            this.Controls.Add(this.txtPHO);
            this.Controls.Add(this.txtLN);
            this.Controls.Add(this.txtFN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MAC";
            this.Text = "Manage Clients";
            this.Load += new System.EventHandler(this.MAC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFN;
        private System.Windows.Forms.TextBox txtLN;
        private System.Windows.Forms.TextBox txtPHO;
        private System.Windows.Forms.TextBox txtNAT;
        private System.Windows.Forms.BindingSource bindingSource4;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog SFD4;
        private System.Windows.Forms.Button btnEE;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnGetImage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}