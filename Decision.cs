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
    public partial class Decision : Form
    {
        public Decision()
        {
            InitializeComponent();
        }

        private void Decision_Load(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream("candidates.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var name = line.Split('>')[0];
                    var surname = line.Split('>')[1];

                    listBox1.Items.Add(name + " " + surname);
                }

                sr.Close();
                fs.Close();
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("IndexError");
            }

            catch (FileNotFoundException)
            {
                MessageBox.Show("Your Candidate List is empty!"); ;
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mainMenu = new Form1();
            mainMenu.ShowDialog();
            this.Close();
        }

        private List<CandidateInfoAfterTxt> infoKeeper = new List<CandidateInfoAfterTxt>();

        private void listBox1_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream("candidates.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                string reader;
                while ((reader = sr.ReadLine()) != null)
                {
                    string[] data = reader.Split('>');
                    foreach (var item in data)
                    {
                        KeepDataAfterTxt.lines.Add(item);
                    }
                }
                sr.Close();
                fs.Close();

                int found = 0;
                if (listBox1.SelectedItem == null)
                {
                    MessageBox.Show("Select the candidate or your Candidate List is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string[] selected = { listBox1.SelectedItem.ToString() };
                    foreach (string s in selected)
                    {
                        found = s.IndexOf(" ");
                        string surname = s.Substring(found + 1);
                        int IDindex = KeepDataAfterTxt.lines.FindIndex(a => a.Contains(surname));
                        NameLabel.Text = KeepDataAfterTxt.lines[IDindex - 1];
                        LastNameLabel.Text = KeepDataAfterTxt.lines[IDindex];
                        DateofBirthLabel.Text = KeepDataAfterTxt.lines[IDindex + 1];
                        GenderLabel.Text = KeepDataAfterTxt.lines[IDindex + 2];
                        EmailLabel.Text = KeepDataAfterTxt.lines[IDindex + 3];
                        PhoneLabel.Text = KeepDataAfterTxt.lines[IDindex + 4];
                        ExpectedSalaryLabel.Text = KeepDataAfterTxt.lines[IDindex + 5];
                        RoleLabel.Text = KeepDataAfterTxt.lines[IDindex + 6];
                        CVfield.Text = KeepDataAfterTxt.lines[IDindex + 7];

                        SalaryTxtBox.Text = KeepDataAfterTxt.lines[IDindex + 5];
                    }
                }

            }

            catch (FileNotFoundException)
            {
                MessageBox.Show("Candidate List is empty"); ;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("The List is empty");
            }
        }
        private List<int> randomList = new List<int>();

        private void HireBtn_Click(object sender, EventArgs e)
        {
            List<string> lst = File.ReadAllLines("candidates.txt").Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();
            lst.RemoveAll(x => x.Split('>')[0].Equals(NameLabel.Text));
            File.WriteAllLines("candidates.txt", lst);

            try
            {
                FileStream fs = new FileStream("employees.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);


                if (listBox1.SelectedItem == null)
                {
                    MessageBox.Show("Please, first select the Candidate!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int found = 0;
                    string[] selected = { listBox1.SelectedItem.ToString() };
                    foreach (string s in selected)
                    {
                        found = s.IndexOf(" ");
                        string surname = s.Substring(found + 1);
                        int IDindex = KeepInfoAfterHire.lines.FindIndex(a => a.Contains(surname));
                        NameLabel.Text = KeepInfoAfterHire.lines[IDindex - 1];
                        LastNameLabel.Text = KeepInfoAfterHire.lines[IDindex];
                        DateofBirthLabel.Text = KeepInfoAfterHire.lines[IDindex + 1];
                        GenderLabel.Text = KeepInfoAfterHire.lines[IDindex + 2];
                        EmailLabel.Text = KeepInfoAfterHire.lines[IDindex + 3];
                        PhoneLabel.Text = KeepInfoAfterHire.lines[IDindex + 4];
                        KeepInfoAfterHire.lines[IDindex + 5] = SalaryTxtBox.Text;
                        RoleLabel.Text = KeepInfoAfterHire.lines[IDindex + 6];
                        CVfield.Text = KeepInfoAfterHire.lines[IDindex + 7];

                    }

                    KeepInfoAfterHire candidateID = new KeepInfoAfterHire();

                    if (!randomList.Contains(candidateID.Random_ID()))
                    {
                        randomList.Add(candidateID.Random_ID());
                    }

                    if (FullTimeCheckBox.Checked)
                    {

                        sw.WriteLine(candidateID.Random_ID() + "-" + ">" + NameLabel.Text + ">" + LastNameLabel.Text + ">" + DateofBirthLabel.Text + ">"
                                    + GenderLabel.Text + ">" + EmailLabel.Text + ">" + PhoneLabel.Text + ">"
                                    + SalaryTxtBox.Text + ">" + RoleLabel.Text + ">" + "Available");
                        KeepInfoAfterHire.lines[8] = "Available";
                    }
                    else
                    {
                        sw.WriteLine(candidateID.Random_ID() + "-" + ">" + NameLabel.Text + ">" + LastNameLabel.Text + ">" + DateofBirthLabel.Text + ">"
                                       + GenderLabel.Text + ">" + EmailLabel.Text + ">" + PhoneLabel.Text + ">"
                                       + SalaryTxtBox.Text + ">" + RoleLabel.Text + ">" + "Not Available");
                        KeepInfoAfterHire.lines[8] = "Not Available";
                    }

                    sw.Close();
                    fs.Close();
                    MessageBox.Show("Candidate Hired!");

                    while (listBox1.SelectedItems.Count > 0)
                    {
                        listBox1.Items.Remove(listBox1.SelectedItems[0]);
                    }

                    KeepInfoAfterHire dict = new KeepInfoAfterHire();
                    dict.employeeSalary.Add(SalaryTxtBox.Text, candidateID.Random_ID() + "-" + NameLabel.Text + " " + LastNameLabel.Text);
                }
            }


            catch (FileNotFoundException)
            {
                MessageBox.Show("Candidate List is empty");
            }



        }

        private void RejectBtn_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please, first select the Candidate!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                List<string> lst = File.ReadAllLines("candidates.txt").Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();
                lst.RemoveAll(x => x.Split('>')[0].Equals(NameLabel.Text));
                File.WriteAllLines("candidates.txt", lst);

                while (listBox1.SelectedItems.Count > 0)
                {
                    listBox1.Items.Remove(listBox1.SelectedItems[0]);
                }
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
    }
}







