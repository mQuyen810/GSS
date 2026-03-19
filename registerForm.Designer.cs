namespace GSS
{
    partial class registerForm
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
            this.lb_Register = new System.Windows.Forms.Label();
            this.tab_Login = new System.Windows.Forms.TableLayoutPanel();
            this.panel_dNhap = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_resetPassword = new System.Windows.Forms.RichTextBox();
            this.btn_Back = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Password = new System.Windows.Forms.RichTextBox();
            this.txt_Register = new System.Windows.Forms.RichTextBox();
            this.btn_Register = new System.Windows.Forms.Button();
            this.tab_Login.SuspendLayout();
            this.panel_dNhap.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_Register
            // 
            this.lb_Register.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Register.AutoEllipsis = true;
            this.lb_Register.AutoSize = true;
            this.lb_Register.Cursor = System.Windows.Forms.Cursors.Default;
            this.lb_Register.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lb_Register.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Register.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb_Register.Location = new System.Drawing.Point(3, 0);
            this.lb_Register.Name = "lb_Register";
            this.lb_Register.Size = new System.Drawing.Size(794, 37);
            this.lb_Register.TabIndex = 0;
            this.lb_Register.Text = "Đăng ký";
            this.lb_Register.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_Register.UseMnemonic = false;
            // 
            // tab_Login
            // 
            this.tab_Login.ColumnCount = 1;
            this.tab_Login.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tab_Login.Controls.Add(this.panel_dNhap, 0, 1);
            this.tab_Login.Controls.Add(this.lb_Register, 0, 0);
            this.tab_Login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_Login.Location = new System.Drawing.Point(0, 0);
            this.tab_Login.Margin = new System.Windows.Forms.Padding(0);
            this.tab_Login.Name = "tab_Login";
            this.tab_Login.RowCount = 2;
            this.tab_Login.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.42105F));
            this.tab_Login.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.57895F));
            this.tab_Login.Size = new System.Drawing.Size(800, 450);
            this.tab_Login.TabIndex = 2;
            // 
            // panel_dNhap
            // 
            this.panel_dNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_dNhap.Controls.Add(this.label2);
            this.panel_dNhap.Controls.Add(this.txt_resetPassword);
            this.panel_dNhap.Controls.Add(this.btn_Back);
            this.panel_dNhap.Controls.Add(this.label1);
            this.panel_dNhap.Controls.Add(this.label3);
            this.panel_dNhap.Controls.Add(this.txt_Password);
            this.panel_dNhap.Controls.Add(this.txt_Register);
            this.panel_dNhap.Controls.Add(this.btn_Register);
            this.panel_dNhap.Location = new System.Drawing.Point(3, 130);
            this.panel_dNhap.Name = "panel_dNhap";
            this.panel_dNhap.Size = new System.Drawing.Size(794, 317);
            this.panel_dNhap.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(176, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nhập lại mật khẩu:";
            // 
            // txt_resetPassword
            // 
            this.txt_resetPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_resetPassword.Location = new System.Drawing.Point(404, 119);
            this.txt_resetPassword.Name = "txt_resetPassword";
            this.txt_resetPassword.Size = new System.Drawing.Size(224, 25);
            this.txt_resetPassword.TabIndex = 8;
            this.txt_resetPassword.Text = "";
            // 
            // btn_Back
            // 
            this.btn_Back.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Back.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Back.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btn_Back.Location = new System.Drawing.Point(274, 246);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(257, 48);
            this.btn_Back.TabIndex = 7;
            this.btn_Back.Text = "Quay lại";
            this.btn_Back.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(176, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mật khẩu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(176, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tên đăng nhập:";
            // 
            // txt_Password
            // 
            this.txt_Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Password.Location = new System.Drawing.Point(404, 71);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(224, 25);
            this.txt_Password.TabIndex = 3;
            this.txt_Password.Text = "";
            // 
            // txt_Register
            // 
            this.txt_Register.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Register.Location = new System.Drawing.Point(404, 24);
            this.txt_Register.Name = "txt_Register";
            this.txt_Register.Size = new System.Drawing.Size(224, 25);
            this.txt_Register.TabIndex = 2;
            this.txt_Register.Text = "";
            // 
            // btn_Register
            // 
            this.btn_Register.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Register.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_Register.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Register.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btn_Register.Location = new System.Drawing.Point(274, 180);
            this.btn_Register.Name = "btn_Register";
            this.btn_Register.Size = new System.Drawing.Size(257, 48);
            this.btn_Register.TabIndex = 2;
            this.btn_Register.Text = "Đăng ký";
            this.btn_Register.UseVisualStyleBackColor = false;
            // 
            // registerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tab_Login);
            this.Name = "registerForm";
            this.Text = "resgisterForm";
            this.tab_Login.ResumeLayout(false);
            this.tab_Login.PerformLayout();
            this.panel_dNhap.ResumeLayout(false);
            this.panel_dNhap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_Register;
        private System.Windows.Forms.TableLayoutPanel tab_Login;
        private System.Windows.Forms.Panel panel_dNhap;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txt_Password;
        private System.Windows.Forms.RichTextBox txt_Register;
        private System.Windows.Forms.Button btn_Register;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txt_resetPassword;
    }
}