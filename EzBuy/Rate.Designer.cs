namespace EzBuy
{
    partial class Rate
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
            this.cny_B = new System.Windows.Forms.TextBox();
            this.hkd_B = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.kg_B = new System.Windows.Forms.TextBox();
            this.kgcost_B = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cny_B
            // 
            this.cny_B.Location = new System.Drawing.Point(192, 12);
            this.cny_B.Name = "cny_B";
            this.cny_B.Size = new System.Drawing.Size(100, 22);
            this.cny_B.TabIndex = 0;
            this.cny_B.TextChanged += new System.EventHandler(this.cny_B_TextChanged);
            // 
            // hkd_B
            // 
            this.hkd_B.Location = new System.Drawing.Point(86, 12);
            this.hkd_B.Name = "hkd_B";
            this.hkd_B.Size = new System.Drawing.Size(100, 22);
            this.hkd_B.TabIndex = 1;
            this.hkd_B.TextChanged += new System.EventHandler(this.hkd_B_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // kg_B
            // 
            this.kg_B.Location = new System.Drawing.Point(86, 53);
            this.kg_B.Name = "kg_B";
            this.kg_B.Size = new System.Drawing.Size(100, 22);
            this.kg_B.TabIndex = 3;
            this.kg_B.TextChanged += new System.EventHandler(this.kg_B_TextChanged);
            // 
            // kgcost_B
            // 
            this.kgcost_B.Location = new System.Drawing.Point(192, 53);
            this.kgcost_B.Name = "kgcost_B";
            this.kgcost_B.Size = new System.Drawing.Size(100, 22);
            this.kgcost_B.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "KG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "HKD<>CNY";
            // 
            // Rate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 161);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kgcost_B);
            this.Controls.Add(this.kg_B);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.hkd_B);
            this.Controls.Add(this.cny_B);
            this.Name = "Rate";
            this.Text = "Rate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cny_B;
        private System.Windows.Forms.TextBox hkd_B;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox kg_B;
        private System.Windows.Forms.TextBox kgcost_B;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}