namespace EzBuy
{
    partial class StockManager
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
            this.value_B = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.byProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.byCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.expectedprofit_B = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.res_L = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg1
            // 
            this.dg1.AllowUserToAddRows = false;
            this.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg1.Location = new System.Drawing.Point(111, 12);
            this.dg1.Name = "dg1";
            this.dg1.RowTemplate.Height = 24;
            this.dg1.Size = new System.Drawing.Size(878, 396);
            this.dg1.TabIndex = 1;
            this.dg1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg1_CellClick);
            this.dg1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // value_B
            // 
            this.value_B.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.value_B.Location = new System.Drawing.Point(111, 452);
            this.value_B.Name = "value_B";
            this.value_B.Size = new System.Drawing.Size(169, 36);
            this.value_B.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(107, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "存貨賣出總值";
            // 
            // menu
            // 
            this.menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu.Font = new System.Drawing.Font("微軟正黑體", 17F);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byProduct,
            this.byCategory,
            this.refresh});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menu.Size = new System.Drawing.Size(100, 500);
            this.menu.TabIndex = 5;
            this.menu.Text = "Main";
            // 
            // byProduct
            // 
            this.byProduct.Name = "byProduct";
            this.byProduct.Size = new System.Drawing.Size(87, 34);
            this.byProduct.Text = "依產品";
            this.byProduct.Click += new System.EventHandler(this.byProduct_Click);
            // 
            // byCategory
            // 
            this.byCategory.Name = "byCategory";
            this.byCategory.Size = new System.Drawing.Size(87, 34);
            this.byCategory.Text = "依種類";
            this.byCategory.Click += new System.EventHandler(this.byCategory_Click);
            // 
            // refresh
            // 
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(87, 34);
            this.refresh.Text = "更新";
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // expectedprofit_B
            // 
            this.expectedprofit_B.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.expectedprofit_B.Location = new System.Drawing.Point(312, 452);
            this.expectedprofit_B.Name = "expectedprofit_B";
            this.expectedprofit_B.Size = new System.Drawing.Size(169, 36);
            this.expectedprofit_B.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(308, 420);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "每月期待利潤";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(286, 456);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 27);
            this.label3.TabIndex = 8;
            this.label3.Text = "-";
            // 
            // res_L
            // 
            this.res_L.AutoSize = true;
            this.res_L.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.res_L.Location = new System.Drawing.Point(487, 456);
            this.res_L.Name = "res_L";
            this.res_L.Size = new System.Drawing.Size(26, 27);
            this.res_L.TabIndex = 9;
            this.res_L.Text = "=";
            // 
            // StockManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 500);
            this.Controls.Add(this.res_L);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.expectedprofit_B);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.value_B);
            this.Controls.Add(this.dg1);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "StockManager";
            this.Text = "貨倉管理";
            this.Load += new System.EventHandler(this.category_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg1;
        private System.Windows.Forms.TextBox value_B;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem byProduct;
        private System.Windows.Forms.ToolStripMenuItem byCategory;
        private System.Windows.Forms.ToolStripMenuItem refresh;
        private System.Windows.Forms.TextBox expectedprofit_B;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label res_L;
    }
}