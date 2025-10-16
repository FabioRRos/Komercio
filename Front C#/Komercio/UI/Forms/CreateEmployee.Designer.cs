namespace Komercio.UI.Forms
{
    partial class fmCreateEmployee
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
            this.btnNewEmployee = new System.Windows.Forms.Button();
            this.btnSaveNewEmployee = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbEmployeeName = new System.Windows.Forms.TextBox();
            this.tbEmployeePassword = new System.Windows.Forms.TextBox();
            this.btnSeePassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewEmployee
            // 
            this.btnNewEmployee.Location = new System.Drawing.Point(34, 191);
            this.btnNewEmployee.Name = "btnNewEmployee";
            this.btnNewEmployee.Size = new System.Drawing.Size(75, 23);
            this.btnNewEmployee.TabIndex = 0;
            this.btnNewEmployee.Text = "Novo";
            this.btnNewEmployee.UseVisualStyleBackColor = true;
            this.btnNewEmployee.Click += new System.EventHandler(this.btnNewEmployee_Click);
            // 
            // btnSaveNewEmployee
            // 
            this.btnSaveNewEmployee.Location = new System.Drawing.Point(162, 191);
            this.btnSaveNewEmployee.Name = "btnSaveNewEmployee";
            this.btnSaveNewEmployee.Size = new System.Drawing.Size(75, 23);
            this.btnSaveNewEmployee.TabIndex = 1;
            this.btnSaveNewEmployee.Text = "Salvar";
            this.btnSaveNewEmployee.UseVisualStyleBackColor = true;
            this.btnSaveNewEmployee.Click += new System.EventHandler(this.btnSaveNewEmployee_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nome completo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Senha";
            // 
            // tbEmployeeName
            // 
            this.tbEmployeeName.Location = new System.Drawing.Point(34, 58);
            this.tbEmployeeName.Name = "tbEmployeeName";
            this.tbEmployeeName.Size = new System.Drawing.Size(203, 20);
            this.tbEmployeeName.TabIndex = 4;
            // 
            // tbEmployeePassword
            // 
            this.tbEmployeePassword.Location = new System.Drawing.Point(34, 139);
            this.tbEmployeePassword.Name = "tbEmployeePassword";
            this.tbEmployeePassword.PasswordChar = '*';
            this.tbEmployeePassword.Size = new System.Drawing.Size(100, 20);
            this.tbEmployeePassword.TabIndex = 5;
            // 
            // btnSeePassword
            // 
            this.btnSeePassword.Location = new System.Drawing.Point(162, 136);
            this.btnSeePassword.Name = "btnSeePassword";
            this.btnSeePassword.Size = new System.Drawing.Size(75, 23);
            this.btnSeePassword.TabIndex = 6;
            this.btnSeePassword.Text = "Ver";
            this.btnSeePassword.UseVisualStyleBackColor = true;
            this.btnSeePassword.Click += new System.EventHandler(this.btnSeePassword_Click);
            // 
            // fmCreateEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnSeePassword);
            this.Controls.Add(this.tbEmployeePassword);
            this.Controls.Add(this.tbEmployeeName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveNewEmployee);
            this.Controls.Add(this.btnNewEmployee);
            this.Name = "fmCreateEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novo Funcionário";
            this.Load += new System.EventHandler(this.fmCreateEmployee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewEmployee;
        private System.Windows.Forms.Button btnSaveNewEmployee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbEmployeeName;
        private System.Windows.Forms.TextBox tbEmployeePassword;
        private System.Windows.Forms.Button btnSeePassword;
    }
}