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
    public partial class AllEmployees : Form
    {
        public AllEmployees()
        {
            InitializeComponent();
        }

        //                          *    *     *     *     *      *
        //          All Bonuses that Professor Mahdi said are works in the Project
        //                          *    *     *     *     *      *

        private void AllEmployees_Load(object sender, EventArgs e)
        {
            KeepInfoAfterHire candidateInfo = new KeepInfoAfterHire();

            try
            {
                FileStream fs = new FileStream("employees.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var ID = line.Split('>')[0];
                    var name = line.Split('>')[1];
                    var surname = line.Split('>')[2];

                    listBox1.Items.Add(ID + name + " " + surname);
                }

                sr.Close();
                fs.Close();

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Your Employee List is empty!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void listBox1_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream("employees.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                string reader;
                while ((reader = sr.ReadLine()) != null)
                {
                    string[] data = reader.Split('>');
                    foreach (var item in data)
                    {
                        KeepInfoAfterHire.infos.Add(item);
                    }
                }
                sr.Close();
                fs.Close();

                CandidateInfoAfterTxt ct = new CandidateInfoAfterTxt();

                if (listBox1.SelectedItem == null)
                {
                    MessageBox.Show("Select the candidate or your Candidate List is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int found = 0;
                    string[] selected = { listBox1.SelectedItem.ToString() };
                    foreach (string s in selected)
                    {
                        found = s.IndexOf(" ");
                        string surname = s.Substring(found + 1);
                        int IDindex = KeepInfoAfterHire.infos.FindIndex(a => a.Contains(surname));

                        ct.Name = KeepInfoAfterHire.infos[IDindex - 1];
                        ct.Last_Name = KeepInfoAfterHire.infos[IDindex];
                        ct.DateOfBirth = KeepInfoAfterHire.infos[IDindex + 1];
                        ct.Gender = KeepInfoAfterHire.infos[IDindex + 2];
                        ct.Email = KeepInfoAfterHire.infos[IDindex + 3];
                        ct.PhoneNumber = KeepInfoAfterHire.infos[IDindex + 4];
                        ct.Salary = KeepInfoAfterHire.infos[IDindex + 5];
                        ct.Role = KeepInfoAfterHire.infos[IDindex + 6];
                        ct.FullTime = KeepInfoAfterHire.infos[IDindex + 7];
                    }

                    NameLabel.Text = ct.Name;
                    LastNameLabel.Text = ct.Last_Name;
                    DateOfBirthLabel.Text = ct.DateOfBirth;
                    GenderLabel.Text = ct.Gender;
                    emailLabel.Text = ct.Email;
                    phoneLabel.Text = ct.PhoneNumber;
                    salaryLabel.Text = ct.Salary;
                    roleLabel.Text = ct.Role;
                    fullTimeLabel.Text = ct.FullTime;
                }

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Employee List is empty"); ;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please, do not use Space while writing Candidate Information");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Employee List is empty");
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mainMenu = new Form1();
            mainMenu.ShowDialog();
            this.Close();
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
    }
}
