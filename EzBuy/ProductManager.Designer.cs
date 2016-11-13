namespace EzBuy
{
    partial class ProductManager
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
            this.dg_type = new System.Windows.Forms.DataGridView();
            this.search = new System.Windows.Forms.MenuStrip();
            this.search_L = new System.Windows.Forms.ToolStripMenuItem();
            this.query_B = new System.Windows.Forms.ToolStripTextBox();
            this.refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.readonly_B = new System.Windows.Forms.ToolStripTextBox();
            this.dg_count = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_type)).BeginInit();
            this.search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_count)).BeginInit();
            this.SuspendLayout();
            // 
            // dg1
            // 
            this.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg1.Location = new System.Drawing.Point(12, 42);
            this.dg1.Name = "dg1";
            this.dg1.RowTemplate.Height = 24;
            this.dg1.Size = new System.Drawing.Size(600, 409);
            this.dg1.TabIndex = 1;
            this.dg1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg1_CellClick);
            this.dg1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg1_CellEndEdit);
            this.dg1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg1_RowHeaderMouseClick);
            this.dg1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dg1_KeyDown);
            // 
            // dg_type
            // 
            this.dg_type.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_type.Location = new System.Drawing.Point(618, 42);
            this.dg_type.Name = "dg_type";
            this.dg_type.RowTemplate.Height = 24;
            this.dg_type.Size = new System.Drawing.Size(386, 409);
            this.dg_type.TabIndex = 7;
            this.dg_type.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_type_CellEndEdit);
            this.dg_type.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_type_RowHeaderMouseClick);
            this.dg_type.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dg_type_KeyDown);
            // 
            // search
            // 
            this.search.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.search.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.search_L,
            this.query_B,
            this.refresh,
            this.readonly_B});
            this.search.Location = new System.Drawing.Point(0, 0);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(1278, 39);
            this.search.TabIndex = 8;
            this.search.Text = "menuStrip1";
            // 
            // search_L
            // 
            this.search_L.Name = "search_L";
            this.search_L.Size = new System.Drawing.Size(103, 35);
            this.search_L.Text = "Search";
            // 
            // query_B
            // 
            this.query_B.Name = "query_B";
            this.query_B.Size = new System.Drawing.Size(200, 35);
            this.query_B.TextChanged += new System.EventHandler(this.query_B_TextChanged);
            // 
            // refresh
            // 
            this.refresh.ForeColor = System.Drawing.Color.DarkGreen;
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(127, 35);
            this.refresh.Text = "REFRESH";
            this.refresh.Click += new System.EventHandler(this.refresh_btn_Click);
            // 
            // readonly_B
            // 
            this.readonly_B.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.readonly_B.Name = "readonly_B";
            this.readonly_B.ReadOnly = true;
            this.readonly_B.Size = new System.Drawing.Size(250, 35);
            // 
            // dg_count
            // 
            this.dg_count.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_count.Location = new System.Drawing.Point(1010, 42);
            this.dg_count.Name = "dg_count";
            this.dg_count.RowTemplate.Height = 24;
            this.dg_count.Size = new System.Drawing.Size(255, 409);
            this.dg_count.TabIndex = 9;
            // 
            // ProductManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 463);
            this.Controls.Add(this.dg_count);
            this.Controls.Add(this.dg_type);
            this.Controls.Add(this.dg1);
            this.Controls.Add(this.search);
            this.MainMenuStrip = this.search;
            this.Name = "ProductManager";
            this.Text = "Product Manager";
            this.Load += new System.EventHandler(this.category_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_type)).EndInit();
            this.search.ResumeLayout(false);
            this.search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_count)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg1;
        private System.Windows.Forms.DataGridView dg_type;
        private System.Windows.Forms.MenuStrip search;
        private System.Windows.Forms.ToolStripMenuItem search_L;
        private System.Windows.Forms.ToolStripTextBox query_B;
        private System.Windows.Forms.ToolStripMenuItem refresh;
        private System.Windows.Forms.ToolStripTextBox readonly_B;
        private System.Windows.Forms.DataGridView dg_count;
    }
}