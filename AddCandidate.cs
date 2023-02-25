using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project2_HR
{
    public partial class AddCandidate : Form
    {
        public AddCandidate()
        {
            InitializeComponent();
        }

        private void AddCandidate_Load(object sender, EventArgs e)
        {

        }

        private void NameTxt_TextChanged(object sender, EventArgs e)
        {
            CandidateInfo candidate = new CandidateInfo();
            candidate.name = NameTxt.Text;

            KeepInfo.name = candidate.name;
        }

        private void LastNameTxt_TextChanged(object sender, EventArgs e)
        {
            CandidateInfo candidate = new CandidateInfo();
            candidate.last_name = LastNameTxt.Text;

            KeepInfo.last_name = candidate.last_name;
        }

        private void BirthTxt_TextChanged(object sender, EventArgs e)
        {
            CandidateInfo candidate = new CandidateInfo();
            candidate.dateOfBirth = BirthTxt.Text;

            KeepInfo.dateOfBirth = candidate.dateOfBirth;
        }

        private void GenderCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CandidateInfo candidate = new CandidateInfo();
            candidate.gender = GenderCombo.GetItemText(GenderCombo.SelectedItem);

            KeepInfo.gender = candidate.gender;
        }

        private void EmailTxt_TextChanged(object sender, EventArgs e)
        {
            CandidateInfo candidate = new CandidateInfo();
            candidate.email = EmailTxt.Text;

            KeepInfo.email = candidate.email;
        }

        private void PhoneTxt_TextChanged(object sender, EventArgs e)
        {
            CandidateInfo candidate = new CandidateInfo();
            candidate.phone_number = PhoneTxt.Text;

            KeepInfo.phone_number = candidate.phone_number;
        }

        private void SalaryTxt_TextChanged(object sender, EventArgs e)
        {
            CandidateInfo candidate = new CandidateInfo();
            candidate.salary = SalaryTxt.Text;

            KeepInfo.salary = candidate.salary;
        }

        private void RoleCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CandidateInfo candidate = new CandidateInfo();
            candidate.role = RoleCombo.GetItemText(RoleCombo.SelectedItem);

            KeepInfo.role = candidate.role;
        }

        private void CVlaodBtn_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CVfieldBox.Text = "";

                FileStream fs = new FileStream(openFileDialog1.FileName,FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                while (!sr.EndOfStream)
                {
                    CVfieldBox.Text = sr.ReadLine();
                }
                sr.Close();
                fs.Close();
            }
        }

        private void CVfieldBox_TextChanged(object sender, EventArgs e)
        {
            CandidateInfo candidate = new CandidateInfo();
            candidate.CV = CVfieldBox.Text;

            KeepInfo.CV = candidate.CV;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (NameTxt.Text == string.Empty)
            {
                MessageBox.Show("Please, Enter the Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (LastNameTxt.Text == string.Empty)
            {
                MessageBox.Show("Please, Enter the Last Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (BirthTxt.Text == string.Empty)
            {
                MessageBox.Show("Please, Enter the Date of Birth", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (GenderCombo.GetItemText(GenderCombo.SelectedItem) == "")
            {
                MessageBox.Show("Please, Select the Gender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (EmailTxt.Text == string.Empty)
            {
                MessageBox.Show("Please, Enter the Email Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (PhoneTxt.Text == string.Empty)
            {
                MessageBox.Show("Please, Enter the Phone Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (SalaryTxt.Text == string.Empty)
            {
                MessageBox.Show("Please, Enter the Expected Salary", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (RoleCombo.GetItemText(RoleCombo.SelectedItem) == "")
            {
                MessageBox.Show("Please, Select the Role", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (CVfieldBox.Text == string.Empty)
            {
                MessageBox.Show("Please, write down your CV or Load the CV", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FileStream fs = new FileStream("candidates.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(KeepInfo.name + ">" + KeepInfo.last_name+ ">" + KeepInfo.dateOfBirth
                            + ">" + KeepInfo.gender + ">" + KeepInfo.email + ">" + KeepInfo.phone_number + ">" 
                            + KeepInfo.salary + ">" + KeepInfo.role + ">" + KeepInfo.CV);
                sw.Close();
                fs.Close();


                MessageBox.Show("Candidate Added!");

                NameTxt.Text = "";
                LastNameTxt.Text = "";
                PhoneTxt.Text = "";
                EmailTxt.Text = "";
                BirthTxt.Text = "";
                SalaryTxt.Text = "";
                CVfieldBox.Text = "";
                GenderCombo.Text = "";
                RoleCombo.Text = "";
            }
        }
        private void ExitBtn_Click(object sender, EventArgs e)
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

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mainMenu = new Form1();
            mainMenu.ShowDialog();
            this.Close();
        }
    }
}
