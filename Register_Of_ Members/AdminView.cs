using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Register_Of__Members
{
    public partial class AdminView : Form
    {
        private static Collection<Members> allMembers;

        public AdminView(Admin currentAdmin) 
        {
            InitializeComponent();
            Label lblUserFirstNameLastName = new Label
            {
                Width = 200,
                Location = new Point(600, 30),
            };
            this.Controls.Add(lblUserFirstNameLastName);
            lblUserFirstNameLastName.Text = "Pozdrav, " + currentAdmin.FirstName + " " + currentAdmin.LastName;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            if (!Admin.IsAdmin(currentAdmin))
            {
                tsmAdd.Visible = false;
                tsmChange.Visible = false;
                administracijaToolStripMenuItem.Visible = false;
            }

            dgvPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SetTXTFieldToReadOnlyOnTabPage(tabControlMain, true);
            SetDTPFieldToReadOnlyOnTabPage(tabControlMain, true);
            SetCMBFieldToReadOnlyOnTabPage(tabControlMain, true);
            SetButtonToReadOnlyOnTabPage(tabControlMain, true);
            dgvPreview.Tag = "Preview";

            dgvPreview.RowHeadersVisible = false; 
            dgvPreview.AllowUserToAddRows = false; 
            dgvPreview.MultiSelect = false; 
            dgvPreview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            try
            {
                allMembers = Members.GetAllMembers();
                FillDGVWithMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            if (allMembers == null)
            {
                MessageBox.Show("Nema registriranih članova!");
                Application.Exit();

            }
        }

        public void ClearDGV()
        {
            dgvPreview.Columns.Clear();
            dgvPreview.Rows.Clear();
        }

        private void SetTXTFieldToReadOnlyOnTabPage(TabControl tc, bool isReadOnly)
        {
            foreach (TabPage tp in tc.TabPages)
            {
                foreach (Control control in tp.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox a = (TextBox)control;
                        a.ReadOnly = isReadOnly;
                    }
                }
            }
        }
     
        private void SetDTPFieldToReadOnlyOnTabPage(TabControl tc, bool isReadOnly)
        {
            foreach (TabPage tp in tc.TabPages)
            {
                foreach (Control control in tp.Controls)
                {
                    if (control is DateTimePicker)
                    {
                        control.Enabled = !isReadOnly;
                    }
                }
            }
        }

        private void SetCMBFieldToReadOnlyOnTabPage(TabControl tc, bool isReadOnly)
        {
            foreach (TabPage tp in tc.TabPages)
            {
                foreach (Control control in tp.Controls)
                {
                    if (control is ComboBox)
                    {
                        control.Enabled = !isReadOnly;
                    }
                }
            }
        }

        private void SetButtonToReadOnlyOnTabPage(TabControl tc, bool isReadOnly)
        {
            foreach (TabPage tp in tc.TabPages)
            {
                foreach (Control control in tp.Controls)
                {
                    if (control is GroupBox)
                    {
                        control.Enabled = !isReadOnly;
                    }
                }
            }
        }

        public void FillDGVWithMembers()
        {
            dgvPreview.Columns.Add("rbr", "R. br.");
            dgvPreview.Columns.Add("firstName", "Ime");
            dgvPreview.Columns.Add("lastName", "Prezime");

            int counter = 1;

            foreach (Members tmpMembers in Members.GetAllMembers()) 
            {
                DataGridViewRow dgvr = new DataGridViewRow();

                dgvr.Tag = tmpMembers.Id; 

                dgvr.Cells.Add(new DataGridViewTextBoxCell()); 
                dgvr.Cells.Add(new DataGridViewTextBoxCell()); 
                dgvr.Cells.Add(new DataGridViewTextBoxCell());

                dgvr.Cells[0].Value = counter.ToString(); 
                dgvr.Cells[1].Value = tmpMembers.FirstName; 
                dgvr.Cells[2].Value = tmpMembers.LastName; 

                dgvPreview.Rows.Add(dgvr); 

                dgvPreview.Rows[0].Cells[0].Selected = true; 

                counter++;
            }

            Members currentMembers = new Members();
            if (allMembers.Count >= 1)
            {
                currentMembers = allMembers[0];
                fillControlWithMembers(currentMembers);
            }
            else
            {
                MessageBox.Show("Ne postoje podaci o članovima.");
            }

        }

        private void dgvPreview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fillMemberDetails();
        }

        private void fillMemberDetails()
        {
            string id = dgvPreview.CurrentRow.Tag.ToString();

            foreach (Members m in Members.GetAllMembers())
            {
                if (m.Id == id)
                {
                    fillControlWithMembers(m);
                    break;
                }
            }
        }

        private void fillControlWithMembers(Members m)
        {
            picbPicture.ImageLocation = Members.pictureLocation(m);
            picbPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            txtFirstName.Text = m.FirstName;
            txtLastName.Text = m.LastName;
            dtpDateOfBirth.Value = Convert.ToDateTime(m.DateOfBirth);
            txtOib.Text = m.Oib;
            txtAdress.Text = m.Adress;
            txtEmail.Text = m.Email;
            txtNumber.Text = m.Contact;
            if (m.Gender == "Ž")
            {
                rbtnFemale.Checked = true;
            }
            else
            {
                rbtnMale.Checked = true;
            }
            if (m.ActiveCompetitor == true)
            {
                rbtnActiveCompetitor.Checked = true;
            }
            else
            {
                rbtnNotActiveCompetitor.Checked = true;
            }

            if (m.ActiveCompetitor == false)
            {
                cmbLevelOfCompetition.Text = "none";
                cmbAgeCategory.Text = "none";
            }
            else
            {
                cmbLevelOfCompetition.Text = m.LevelOfCompetition;
                cmbAgeCategory.Text = Members.AgeCategoryOfCompetition(m);
            }

            cmbTrainingGroup.Text = m.TrainingGroup;
            dtpDateOfJoining.Value = m.DateOfJoining;
        }

        private void tsmPreview_Click(object sender, EventArgs e)
        {
            fillMemberDetails();
        }

        private void tsmLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Login log = new Login();
            log.Show();
            
        }

        private void tsmAdd_Click(object sender, EventArgs e)
        {
            AddMember am = new AddMember("insert");
            am.ShowDialog();

            if (am.DialogResult == DialogResult.Cancel)
            {
                ClearDGV();
                FillDGVWithMembers();
                fillMemberDetails();
            }
        }

        private void tsmChange_Click(object sender, EventArgs e)
        {
            AddMember am = new AddMember("update/delete");
            am.ShowDialog();

            if (am.DialogResult == DialogResult.Cancel)
            {
                ClearDGV();
                FillDGVWithMembers();
                fillMemberDetails();
            }
        }

        private void dodajNovogAdminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAdmin aa = new AddAdmin("insert");
            aa.ShowDialog();

            if (aa.DialogResult == DialogResult.Cancel)
            {
                ClearDGV();
                FillDGVWithMembers();
                fillMemberDetails();
            }
        }

        private void ažurirajAdminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAdmin aa = new AddAdmin("update/delete");
            aa.ShowDialog();

            if (aa.DialogResult == DialogResult.Cancel)
            {
                ClearDGV();
                FillDGVWithMembers();
                fillMemberDetails();
            }
        }

        private void isprintajPopisČlanovaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Members.PrintAllMembers();
        }

        private void printCurrentMember_Click(object sender, EventArgs e)
        {
            string currentId = dgvPreview.CurrentRow.Tag.ToString();
            Members.PrintCurrentMember(currentId);
        }
    }
}
