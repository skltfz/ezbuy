namespace EzBuy
{
    partial class ProfitManager
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
            this.dg1 = new System.Windows.Forms.DataGridView();
            this.topmenu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.search_B = new System.Windows.Forms.ToolStripTextBox();
            this.refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.dgType = new System.Windows.Forms.ToolStripComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dg2 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.purchase_B = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sold_B = new System.Windows.Forms.TextBox();
            this.profit_B = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).BeginInit();
            this.topmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg1
            // 
            this.dg1.AllowUserToAddRows = false;
            this.dg1.AllowUserToDeleteRows = false;
            this.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg1.Location = new System.Drawing.Point(218, 42);
            this.dg1.Name = "dg1";
            this.dg1.RowTemplate.Height = 24;
            this.dg1.Size = new System.Drawing.Size(954, 380);
            // 
            // topmenu
            // 
            this.topmenu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.topmenu.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.topmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.search_B,
            this.refresh,
            this.dgType});
            this.topmenu.Location = new System.Drawing.Point(0, 0);
            this.topmenu.Name = "topmenu";
            this.topmenu.Size = new System.Drawing.Size(1184, 39);
            this.topmenu.TabIndex = 5;
            this.topmenu.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(103, 35);
            this.toolStripMenuItem1.Text = "Search";
            // 
            // search_B
            // 
            this.search_B.Name = "search_B";
            this.search_B.Size = new System.Drawing.Size(200, 35);
            this.search_B.TextChanged += new System.EventHandler(this.orderid_B_TextChanged);
            // 
            // refresh
            // 
            this.refresh.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.refresh.ForeColor = System.Drawing.Color.Lime;
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(74, 35);
            this.refresh.Text = "更新";
            this.refresh.Click += new System.EventHandler(this.refresh_btn_Click);
            // 
            // dgType
            // 
            this.dgType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dgType.Items.AddRange(new object[] {
            "DAILY",
            "MONTHLY",
            "YEARLY",
            "EVER"});
            this.dgType.Name = "dgType";
            this.dgType.Size = new System.Drawing.Size(121, 35);
            this.dgType.SelectedIndexChanged += new System.EventHandler(this.dgType_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dateTimePicker1.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 42);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 36);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dg2
            // 
            this.dg2.AllowUserToAddRows = false;
            this.dg2.AllowUserToDeleteRows = false;
            this.dg2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg2.Location = new System.Drawing.Point(218, 428);
            this.dg2.Name = "dg2";
            this.dg2.RowTemplate.Height = 24;
            this.dg2.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dg2.Size = new System.Drawing.Size(954, 380);
            this.dg2.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.profit_B);
            this.groupBox1.Controls.Add(this.sold_B);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.purchase_B);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 338);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Summary";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(70, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "買入";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(70, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "賣出";
            // 
            // purchase_B
            // 
            this.purchase_B.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.purchase_B.Location = new System.Drawing.Point(10, 45);
            this.purchase_B.Name = "purchase_B";
            this.purchase_B.Size = new System.Drawing.Size(184, 36);
            this.purchase_B.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(70, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "盈利";
            // 
            // sold_B
            // 
            this.sold_B.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.sold_B.Location = new System.Drawing.Point(6, 133);
            this.sold_B.Name = "sold_B";
            this.sold_B.Size = new System.Drawing.Size(184, 36);
            this.sold_B.TabIndex = 6;
            // 
            // profit_B
            // 
            this.profit_B.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.profit_B.Location = new System.Drawing.Point(6, 241);
            this.profit_B.Name = "profit_B";
            this.profit_B.Size = new System.Drawing.Size(184, 36);
            this.profit_B.TabIndex = 7;
            // 
            // ProfitManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 842);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dg2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dg1);
            this.Controls.Add(this.topmenu);
            this.MainMenuStrip = this.topmenu;
            this.Name = "ProfitManager";
            this.Text = "盈利管理";
            this.Load += new System.EventHandler(this.PurchaseManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).EndInit();
            this.topmenu.ResumeLayout(false);
            this.topmenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg1;
        private System.Windows.Forms.MenuStrip topmenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox search_B;
        private System.Windows.Forms.ToolStripMenuItem refresh;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ToolStripComboBox dgType;
        private System.Windows.Forms.DataGridView dg2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox profit_B;
        private System.Windows.Forms.TextBox sold_B;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox purchase_B;
    }
}