namespace EzBuy
{
    partial class PurchaseManager
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
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).BeginInit();
            this.topmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg1
            // 
            this.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg1.Location = new System.Drawing.Point(0, 42);
            this.dg1.Name = "dg1";
            this.dg1.RowTemplate.Height = 24;
            this.dg1.Size = new System.Drawing.Size(1060, 380);
            this.dg1.TabIndex = 1;
            this.dg1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg1_CellClick);
            this.dg1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dg1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            this.dg1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // topmenu
            // 
            this.topmenu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.topmenu.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.topmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.search_B,
            this.refresh});
            this.topmenu.Location = new System.Drawing.Point(0, 0);
            this.topmenu.Name = "topmenu";
            this.topmenu.Size = new System.Drawing.Size(1072, 39);
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
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // PurchaseManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 423);
            this.Controls.Add(this.dg1);
            this.Controls.Add(this.topmenu);
            this.MainMenuStrip = this.topmenu;
            this.Name = "PurchaseManager";
            this.Text = "採購管理";
            this.Load += new System.EventHandler(this.PurchaseManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).EndInit();
            this.topmenu.ResumeLayout(false);
            this.topmenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg1;
        private System.Windows.Forms.MenuStrip topmenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox search_B;
        private System.Windows.Forms.ToolStripMenuItem refresh;
    }
}