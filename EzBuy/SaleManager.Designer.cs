namespace EzBuy
{
    partial class SaleManager
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
            this.function = new System.Windows.Forms.MenuStrip();
            this.stock = new System.Windows.Forms.ToolStripMenuItem();
            this.purchase = new System.Windows.Forms.ToolStripMenuItem();
            this.dginput = new System.Windows.Forms.DataGridView();
            this.check_btn = new System.Windows.Forms.Button();
            this.clear_btn = new System.Windows.Forms.Button();
            this.refresh_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.total_B = new System.Windows.Forms.TextBox();
            this.topmenu = new System.Windows.Forms.MenuStrip();
            this.search = new System.Windows.Forms.ToolStripMenuItem();
            this.search_B = new System.Windows.Forms.ToolStripTextBox();
            this.topfunction = new System.Windows.Forms.MenuStrip();
            this.profit = new System.Windows.Forms.ToolStripMenuItem();
            this.topmenu2 = new System.Windows.Forms.MenuStrip();
            this.category_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.product_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.rateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).BeginInit();
            this.function.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dginput)).BeginInit();
            this.topmenu.SuspendLayout();
            this.topfunction.SuspendLayout();
            this.topmenu2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg1
            // 
            this.dg1.AllowUserToAddRows = false;
            this.dg1.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg1.Location = new System.Drawing.Point(87, 45);
            this.dg1.Name = "dg1";
            this.dg1.RowTemplate.Height = 24;
            this.dg1.Size = new System.Drawing.Size(978, 332);
            this.dg1.TabIndex = 0;
            this.dg1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg1_CellClick);
            this.dg1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg1_CellEndEdit);
            this.dg1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg1_RowHeaderMouseClick);
            this.dg1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dg1_UserDeletingRow);
            this.dg1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dg1_KeyDown);
            // 
            // function
            // 
            this.function.BackColor = System.Drawing.Color.LightYellow;
            this.function.Dock = System.Windows.Forms.DockStyle.Left;
            this.function.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.function.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stock,
            this.purchase,
            this.rateToolStripMenuItem});
            this.function.Location = new System.Drawing.Point(0, 0);
            this.function.Name = "function";
            this.function.Size = new System.Drawing.Size(98, 660);
            this.function.TabIndex = 1;
            this.function.Text = "功能";
            // 
            // stock
            // 
            this.stock.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.stock.Name = "stock";
            this.stock.Size = new System.Drawing.Size(85, 35);
            this.stock.Text = "存貨";
            this.stock.Click += new System.EventHandler(this.stock_Click);
            // 
            // purchase
            // 
            this.purchase.Name = "purchase";
            this.purchase.Size = new System.Drawing.Size(85, 35);
            this.purchase.Text = "採購";
            this.purchase.Click += new System.EventHandler(this.purchase_Click);
            // 
            // dginput
            // 
            this.dginput.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dginput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dginput.Location = new System.Drawing.Point(87, 383);
            this.dginput.Name = "dginput";
            this.dginput.RowTemplate.Height = 24;
            this.dginput.Size = new System.Drawing.Size(801, 265);
            this.dginput.TabIndex = 2;
            this.dginput.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dginput_CellClick);
            this.dginput.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dginput_CellEndEdit);
            this.dginput.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dginput_RowHeaderMouseClick);
            this.dginput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dginput_KeyDown);
            // 
            // check_btn
            // 
            this.check_btn.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.check_btn.Location = new System.Drawing.Point(894, 511);
            this.check_btn.Name = "check_btn";
            this.check_btn.Size = new System.Drawing.Size(167, 65);
            this.check_btn.TabIndex = 3;
            this.check_btn.Text = "CHECK";
            this.check_btn.UseVisualStyleBackColor = true;
            this.check_btn.Click += new System.EventHandler(this.check_btn_Click);
            // 
            // clear_btn
            // 
            this.clear_btn.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.clear_btn.Location = new System.Drawing.Point(895, 582);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(166, 66);
            this.clear_btn.TabIndex = 4;
            this.clear_btn.Text = "CLEAR";
            this.clear_btn.UseVisualStyleBackColor = true;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // refresh_btn
            // 
            this.refresh_btn.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.refresh_btn.Location = new System.Drawing.Point(895, 383);
            this.refresh_btn.Name = "refresh_btn";
            this.refresh_btn.Size = new System.Drawing.Size(147, 43);
            this.refresh_btn.TabIndex = 6;
            this.refresh_btn.Text = "REFRESH";
            this.refresh_btn.UseVisualStyleBackColor = true;
            this.refresh_btn.Click += new System.EventHandler(this.refresh_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(894, 442);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "總數";
            // 
            // total_B
            // 
            this.total_B.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.total_B.Location = new System.Drawing.Point(893, 469);
            this.total_B.Name = "total_B";
            this.total_B.Size = new System.Drawing.Size(168, 36);
            this.total_B.TabIndex = 8;
            // 
            // topmenu
            // 
            this.topmenu.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.topmenu.Dock = System.Windows.Forms.DockStyle.None;
            this.topmenu.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.topmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.search,
            this.search_B});
            this.topmenu.Location = new System.Drawing.Point(750, 3);
            this.topmenu.Name = "topmenu";
            this.topmenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.topmenu.Size = new System.Drawing.Size(313, 39);
            this.topmenu.TabIndex = 11;
            this.topmenu.Text = "menuStrip1";
            // 
            // search
            // 
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(103, 35);
            this.search.Text = "Search";
            // 
            // search_B
            // 
            this.search_B.Name = "search_B";
            this.search_B.Size = new System.Drawing.Size(200, 35);
            this.search_B.TextChanged += new System.EventHandler(this.search_B_TextChanged);
            // 
            // topfunction
            // 
            this.topfunction.Dock = System.Windows.Forms.DockStyle.None;
            this.topfunction.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.topfunction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profit});
            this.topfunction.Location = new System.Drawing.Point(83, 3);
            this.topfunction.Name = "topfunction";
            this.topfunction.Size = new System.Drawing.Size(82, 39);
            this.topfunction.TabIndex = 12;
            this.topfunction.Text = "menuStrip1";
            // 
            // profit
            // 
            this.profit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.profit.ForeColor = System.Drawing.Color.Yellow;
            this.profit.Name = "profit";
            this.profit.Size = new System.Drawing.Size(74, 35);
            this.profit.Text = "盈利";
            this.profit.Click += new System.EventHandler(this.profit_Click);
            // 
            // topmenu2
            // 
            this.topmenu2.BackColor = System.Drawing.Color.Orchid;
            this.topmenu2.Dock = System.Windows.Forms.DockStyle.None;
            this.topmenu2.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.topmenu2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.category_menu,
            this.product_menu});
            this.topmenu2.Location = new System.Drawing.Point(368, 3);
            this.topmenu2.Name = "topmenu2";
            this.topmenu2.Size = new System.Drawing.Size(156, 39);
            this.topmenu2.TabIndex = 13;
            this.topmenu2.Text = "menuStrip1";
            // 
            // category_menu
            // 
            this.category_menu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.category_menu.Name = "category_menu";
            this.category_menu.Size = new System.Drawing.Size(74, 35);
            this.category_menu.Text = "種類";
            this.category_menu.Click += new System.EventHandler(this.category_menu_Click);
            // 
            // product_menu
            // 
            this.product_menu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.product_menu.Name = "product_menu";
            this.product_menu.Size = new System.Drawing.Size(74, 35);
            this.product_menu.Text = "產品";
            this.product_menu.Click += new System.EventHandler(this.product_menu_Click);
            // 
            // rateToolStripMenuItem
            // 
            this.rateToolStripMenuItem.Name = "rateToolStripMenuItem";
            this.rateToolStripMenuItem.Size = new System.Drawing.Size(85, 35);
            this.rateToolStripMenuItem.Text = "Rate";
            this.rateToolStripMenuItem.Click += new System.EventHandler(this.rateToolStripMenuItem_Click);
            // 
            // SaleManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 660);
            this.Controls.Add(this.topmenu);
            this.Controls.Add(this.total_B);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refresh_btn);
            this.Controls.Add(this.clear_btn);
            this.Controls.Add(this.check_btn);
            this.Controls.Add(this.dginput);
            this.Controls.Add(this.dg1);
            this.Controls.Add(this.function);
            this.Controls.Add(this.topfunction);
            this.Controls.Add(this.topmenu2);
            this.MainMenuStrip = this.function;
            this.Name = "SaleManager";
            this.Text = "出售管理";
            this.Load += new System.EventHandler(this.main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).EndInit();
            this.function.ResumeLayout(false);
            this.function.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dginput)).EndInit();
            this.topmenu.ResumeLayout(false);
            this.topmenu.PerformLayout();
            this.topfunction.ResumeLayout(false);
            this.topfunction.PerformLayout();
            this.topmenu2.ResumeLayout(false);
            this.topmenu2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg1;
        private System.Windows.Forms.MenuStrip function;
        private System.Windows.Forms.ToolStripMenuItem purchase;
        private System.Windows.Forms.ToolStripMenuItem stock;
        private System.Windows.Forms.DataGridView dginput;
        private System.Windows.Forms.Button check_btn;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.Button refresh_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox total_B;
        private System.Windows.Forms.MenuStrip topmenu;
        private System.Windows.Forms.ToolStripMenuItem search;
        private System.Windows.Forms.ToolStripTextBox search_B;
        private System.Windows.Forms.MenuStrip topfunction;
        private System.Windows.Forms.ToolStripMenuItem profit;
        private System.Windows.Forms.MenuStrip topmenu2;
        private System.Windows.Forms.ToolStripMenuItem category_menu;
        private System.Windows.Forms.ToolStripMenuItem product_menu;
        private System.Windows.Forms.ToolStripMenuItem rateToolStripMenuItem;
    }
}

