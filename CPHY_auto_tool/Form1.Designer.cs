namespace CPHY_auto_tool
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textbox_hsa = new System.Windows.Forms.TextBox();
            this.textbox_hbp = new System.Windows.Forms.TextBox();
            this.textbox_hact = new System.Windows.Forms.TextBox();
            this.textbox_hfp = new System.Windows.Forms.TextBox();
            this.textbox_vact = new System.Windows.Forms.TextBox();
            this.textbox_vfp = new System.Windows.Forms.TextBox();
            this.textbox_vbp = new System.Windows.Forms.TextBox();
            this.textbox_vsa = new System.Windows.Forms.TextBox();
            this.label_state = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(408, 219);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(420, 282);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textbox_hsa
            // 
            this.textbox_hsa.Location = new System.Drawing.Point(28, 29);
            this.textbox_hsa.Name = "textbox_hsa";
            this.textbox_hsa.Size = new System.Drawing.Size(63, 22);
            this.textbox_hsa.TabIndex = 2;
            // 
            // textbox_hbp
            // 
            this.textbox_hbp.Location = new System.Drawing.Point(112, 29);
            this.textbox_hbp.Name = "textbox_hbp";
            this.textbox_hbp.Size = new System.Drawing.Size(63, 22);
            this.textbox_hbp.TabIndex = 4;
            // 
            // textbox_hact
            // 
            this.textbox_hact.Location = new System.Drawing.Point(280, 29);
            this.textbox_hact.Name = "textbox_hact";
            this.textbox_hact.Size = new System.Drawing.Size(63, 22);
            this.textbox_hact.TabIndex = 8;
            // 
            // textbox_hfp
            // 
            this.textbox_hfp.Location = new System.Drawing.Point(196, 29);
            this.textbox_hfp.Name = "textbox_hfp";
            this.textbox_hfp.Size = new System.Drawing.Size(63, 22);
            this.textbox_hfp.TabIndex = 6;
            // 
            // textbox_vact
            // 
            this.textbox_vact.Location = new System.Drawing.Point(280, 57);
            this.textbox_vact.Name = "textbox_vact";
            this.textbox_vact.Size = new System.Drawing.Size(63, 22);
            this.textbox_vact.TabIndex = 12;
            // 
            // textbox_vfp
            // 
            this.textbox_vfp.Location = new System.Drawing.Point(196, 57);
            this.textbox_vfp.Name = "textbox_vfp";
            this.textbox_vfp.Size = new System.Drawing.Size(63, 22);
            this.textbox_vfp.TabIndex = 11;
            // 
            // textbox_vbp
            // 
            this.textbox_vbp.Location = new System.Drawing.Point(112, 57);
            this.textbox_vbp.Name = "textbox_vbp";
            this.textbox_vbp.Size = new System.Drawing.Size(63, 22);
            this.textbox_vbp.TabIndex = 10;
            // 
            // textbox_vsa
            // 
            this.textbox_vsa.Location = new System.Drawing.Point(28, 57);
            this.textbox_vsa.Name = "textbox_vsa";
            this.textbox_vsa.Size = new System.Drawing.Size(63, 22);
            this.textbox_vsa.TabIndex = 9;
            // 
            // label_state
            // 
            this.label_state.AutoSize = true;
            this.label_state.Location = new System.Drawing.Point(408, 29);
            this.label_state.Name = "label_state";
            this.label_state.Size = new System.Drawing.Size(44, 12);
            this.label_state.TabIndex = 13;
            this.label_state.Text = "PG State";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 659);
            this.Controls.Add(this.label_state);
            this.Controls.Add(this.textbox_vact);
            this.Controls.Add(this.textbox_vfp);
            this.Controls.Add(this.textbox_vbp);
            this.Controls.Add(this.textbox_vsa);
            this.Controls.Add(this.textbox_hact);
            this.Controls.Add(this.textbox_hfp);
            this.Controls.Add(this.textbox_hbp);
            this.Controls.Add(this.textbox_hsa);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textbox_hsa;
        private System.Windows.Forms.TextBox textbox_hbp;
        private System.Windows.Forms.TextBox textbox_hact;
        private System.Windows.Forms.TextBox textbox_hfp;
        private System.Windows.Forms.TextBox textbox_vact;
        private System.Windows.Forms.TextBox textbox_vfp;
        private System.Windows.Forms.TextBox textbox_vbp;
        private System.Windows.Forms.TextBox textbox_vsa;
        private System.Windows.Forms.Label label_state;
    }
}

