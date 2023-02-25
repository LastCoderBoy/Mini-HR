using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2_HR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddCandidate AddCandidate = new AddCandidate();
            AddCandidate.ShowDialog();
            this.Close();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you Sure?!", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void hiringBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Decision HiringPage = new Decision();
            HiringPage.ShowDialog();
            this.Close();
        }

        private void allEmployeesBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AllEmployees Employees = new AllEmployees();
            Employees.ShowDialog();
            this.Close();
        }
    }
}
