
namespace Project2_HR
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.hiringBtn = new System.Windows.Forms.Button();
            this.allEmployeesBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(160, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "My Mini HR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(200, 438);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Programmed by group Backbenchers";
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.MediumTurquoise;
            this.addBtn.Location = new System.Drawing.Point(116, 132);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(226, 34);
            this.addBtn.TabIndex = 2;
            this.addBtn.Text = "Add Candidate";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // hiringBtn
            // 
            this.hiringBtn.BackColor = System.Drawing.Color.MediumTurquoise;
            this.hiringBtn.Location = new System.Drawing.Point(116, 188);
            this.hiringBtn.Name = "hiringBtn";
            this.hiringBtn.Size = new System.Drawing.Size(226, 34);
            this.hiringBtn.TabIndex = 3;
            this.hiringBtn.Text = "Hiring Page";
            this.hiringBtn.UseVisualStyleBackColor = false;
            this.hiringBtn.Click += new System.EventHandler(this.hiringBtn_Click);
            // 
            // allEmployeesBtn
            // 
            this.allEmployeesBtn.BackColor = System.Drawing.Color.MediumTurquoise;
            this.allEmployeesBtn.Location = new System.Drawing.Point(116, 242);
            this.allEmployeesBtn.Name = "allEmployeesBtn";
            this.allEmployeesBtn.Size = new System.Drawing.Size(226, 34);
            this.allEmployeesBtn.TabIndex = 4;
            this.allEmployeesBtn.Text = "All Employees";
            this.allEmployeesBtn.UseVisualStyleBackColor = false;
            this.allEmployeesBtn.Click += new System.EventHandler(this.allEmployeesBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.exitBtn.Location = new System.Drawing.Point(116, 337);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(226, 34);
            this.exitBtn.TabIndex = 5;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(467, 466);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.allEmployeesBtn);
            this.Controls.Add(this.hiringBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button hiringBtn;
        private System.Windows.Forms.Button allEmployeesBtn;
        private System.Windows.Forms.Button exitBtn;
    }
}

