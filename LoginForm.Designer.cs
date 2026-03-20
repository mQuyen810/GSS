namespace GSS
{
    partial class LoginForm
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
            this.lb_Login = new System.Windows.Forms.Label();
            this.tab_Login = new System.Windows.Forms.TableLayoutPanel();
            this.panel_dNhap = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.link_Register = new System.Windows.Forms.LinkLabel();
            this.txt_Password = new System.Windows.Forms.RichTextBox();
            this.txt_Login = new System.Windows.Forms.RichTextBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.tab_Login.SuspendLayout();
            this.panel_dNhap.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_Login
            // 
            this.lb_Login.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Login.AutoEllipsis = true;
            this.lb_Login.AutoSize = true;
            this.lb_Login.Cursor = System.Windows.Forms.Cursors.Default;
            this.lb_Login.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lb_Login.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Login.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb_Login.Location = new System.Drawing.Point(2, 0);
            this.lb_Login.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Login.Name = "lb_Login";
            this.lb_Login.Size = new System.Drawing.Size(593, 104);
            this.lb_Login.TabIndex = 0;
            this.lb_Login.Text = "Đăng nhập";
            this.lb_Login.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_Login.UseMnemonic = false;
            this.lb_Login.Click += new System.EventHandler(this.lb_dNhap_Click);
            // 
            // tab_Login
            // 
            this.tab_Login.ColumnCount = 1;
            this.tab_Login.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tab_Login.Controls.Add(this.panel_dNhap, 0, 1);
            this.tab_Login.Controls.Add(this.lb_Login, 0, 0);
            this.tab_Login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_Login.Location = new System.Drawing.Point(0, 0);
            this.tab_Login.Margin = new System.Windows.Forms.Padding(0);
            this.tab_Login.Name = "tab_Login";
            this.tab_Login.RowCount = 2;
            this.tab_Login.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.42105F));
            this.tab_Login.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.57895F));
            this.tab_Login.Size = new System.Drawing.Size(597, 366);
            this.tab_Login.TabIndex = 1;
            // 
            // panel_dNhap
            // 
            this.panel_dNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_dNhap.Controls.Add(this.label1);
            this.panel_dNhap.Controls.Add(this.label3);
            this.panel_dNhap.Controls.Add(this.link_Register);
            this.panel_dNhap.Controls.Add(this.txt_Password);
            this.panel_dNhap.Controls.Add(this.txt_Login);
            this.panel_dNhap.Controls.Add(this.btn_Login);
            this.panel_dNhap.Location = new System.Drawing.Point(2, 106);
            this.panel_dNhap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel_dNhap.Name = "panel_dNhap";
            this.panel_dNhap.Size = new System.Drawing.Size(593, 258);
            this.panel_dNhap.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(157, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mật khẩu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(157, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tên đăng nhập:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // link_Register
            // 
            this.link_Register.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.link_Register.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_Register.Location = new System.Drawing.Point(175, 199);
            this.link_Register.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.link_Register.Name = "link_Register";
            this.link_Register.Size = new System.Drawing.Size(256, 20);
            this.link_Register.TabIndex = 4;
            this.link_Register.TabStop = true;
            this.link_Register.Text = "Chưa có tài khoản ? Đăng ký ngay";
            this.link_Register.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.link_Register.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_Register_LinkClicked);
            // 
            // txt_Password
            // 
            this.txt_Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Password.Location = new System.Drawing.Point(303, 98);
            this.txt_Password.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(167, 21);
            this.txt_Password.TabIndex = 3;
            this.txt_Password.Text = "";
            // 
            // txt_Login
            // 
            this.txt_Login.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Login.Location = new System.Drawing.Point(303, 53);
            this.txt_Login.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Login.Name = "txt_Login";
            this.txt_Login.Size = new System.Drawing.Size(167, 21);
            this.txt_Login.TabIndex = 2;
            this.txt_Login.Text = "";
            // 
            // btn_Login
            // 
            this.btn_Login.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Login.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Login.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btn_Login.Location = new System.Drawing.Point(206, 146);
            this.btn_Login.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(191, 39);
            this.btn_Login.TabIndex = 2;
            this.btn_Login.Text = "Đăng nhập";
            this.btn_Login.UseVisualStyleBackColor = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(597, 366);
            this.Controls.Add(this.tab_Login);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LoginForm";
            this.Text = "Đăng nhập";
            this.tab_Login.ResumeLayout(false);
            this.tab_Login.PerformLayout();
            this.panel_dNhap.ResumeLayout(false);
            this.panel_dNhap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_Login;
        private System.Windows.Forms.TableLayoutPanel tab_Login;
        private System.Windows.Forms.Panel panel_dNhap;
        private System.Windows.Forms.LinkLabel link_Register;
        private System.Windows.Forms.RichTextBox txt_Password;
        private System.Windows.Forms.RichTextBox txt_Login;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}