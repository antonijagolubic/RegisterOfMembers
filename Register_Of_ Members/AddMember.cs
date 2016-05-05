using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Register_Of__Members
{
    public partial class AddMember : Form
    {
        private static Collection<Members> allMembers;

        public AddMember(string operation)
        {
            InitializeComponent();
            PopulateForm(operation);
            if (operation == "update/delete")
            {
                FillMembersInfoById(Members.GetAllMembers()[0].Id);
            }
            
        }

        private void btnAddMember_Click(object sender, System.EventArgs e)
        {
            string action = Controls.Find("btnAddMember", true)[0].Tag.ToString();

            string firstName = Controls.Find("txtFirstName", true)[0].Text;
            string lastName = Controls.Find("txtLastName", true)[0].Text;

            string gender = "";

            RadioButton genderF = (RadioButton)Controls.Find("rbtnFemale", true)[0];
            if (genderF.Checked)
                gender = "Ž";
            RadioButton genderM = (RadioButton)Controls.Find("rbtnMale", true)[0];
            if (genderM.Checked)
                gender = "M";

            DateTime dateOfBirth = Convert.ToDateTime(Controls.Find("dtpDateOfBirth", true)[0].Text);
            string oib = Controls.Find("txtOib", true)[0].Text;
            string adress = Controls.Find("txtAdress", true)[0].Text;
            string email = Controls.Find("txtEmail", true)[0].Text;
            string contact = Controls.Find("txtContact", true)[0].Text;

            string levelOfCompetition = "";
            bool activeC = false;
            RadioButton activeCompetitor = (RadioButton)Controls.Find("rbtnActiveCompetitor", true)[0];
            if (activeCompetitor.Checked)
            {
                activeC = true;
                levelOfCompetition = Controls.Find("cmbLevelOfCompetition", true)[0].Text;
            }
            RadioButton activeCompetitor1 = (RadioButton)Controls.Find("rbtnNotActiveCompetitor", true)[0];
            if (activeCompetitor1.Checked)
            {
                activeC = false;
                levelOfCompetition = Controls.Find("cmbLevelOfCompetition", true)[0].Text = "NEMA";
            }

            string trainingGroup = Controls.Find("cmbTrainingGroup", true)[0].Text;
            DateTime dateOfJoining = Convert.ToDateTime(Controls.Find("dtpDateOfJoining", true)[0].Text);
            string picture = Controls.Find("txtPicture", true)[0].Text;

            if (action == "INSERT")
            {
                try
                {
                    Members.AddMembersToDatabase(firstName, lastName, gender, dateOfBirth, oib, adress, email, contact,
                        activeC, levelOfCompetition, trainingGroup, dateOfJoining, picture);
                }
                catch (Exception)
                {
                    throw new Exception("Greška kod spremanja podataka o članu!");
                    throw;
                }

                DialogResult drNewAdd = MessageBox.Show("Želite li novi unos?", "Novi unos", MessageBoxButtons.YesNo);
                if (drNewAdd == DialogResult.Yes)
                {
                    ClearControls(this);
                }
                else
                {
                    this.Close();
                }
                   
            }
            else if (action == "UPDATE")
            {
                DataGridView dgv = (DataGridView)Controls.Find("dgvMembers", true)[0];
                string currentId = dgv.CurrentRow.Tag.ToString();

                try
                {
                    Members.UpdateMembersInDatabase(currentId, firstName, lastName, gender, dateOfBirth, oib, adress, email, contact,
                        activeC, levelOfCompetition, trainingGroup, dateOfJoining, picture);
                }
                catch (Exception)
                {
                    throw new Exception("Greška kod spremanja podataka o članu!");
                    throw;
                }

                ClearDGV(this);
                CreateDGVMembers();
                ClearControls(this);
            }
        }

        public static void ClearControls (Form f)
        {
            foreach (Control control in f.Controls)
            {
                if (control is TextBox)
                {
                    TextBox a = (TextBox) control;
                    a.Text = null;
                }
                if (control is GroupBox)
                {
                    GroupBox gb = (GroupBox) control;
                    foreach (Control c in gb.Controls)
                    {
                        RadioButton rb = (RadioButton) c;
                        rb.Checked = false;
                    }
                }
                if (control is DateTimePicker)
                {
                    DateTimePicker p = (DateTimePicker) control;
                    p.Text = null;
                }
                if (control is ComboBox)
                {
                    ComboBox c = (ComboBox)control;
                    c.SelectedIndex = -1;
                }
            }
        }

        public void ClearDGV(Form f)
        {
            foreach (Control control in f.Controls)
            {
                if (control is DataGridView)
                {
                    DataGridView dgv = (DataGridView)control;
                    Controls.Remove(dgv);
                }
                
            }
            
        }

        private void btnDeleteMember_Click(object sender, System.EventArgs e)
        {
            DataGridView dgv = (DataGridView)Controls.Find("dgvMembers", true)[0];
            string currentid = dgv.CurrentRow.Tag.ToString();
            
            try
            {
                Members.DeleteMembersInDatabase(currentid);
            }
            catch (Exception)
            {
                throw new Exception("Greška kod brisanja podataka o članu!");
                throw;
            }
            ClearDGV(this);
            CreateDGVMembers();
            ClearControls(this);

        }

        private void dgvMembers_CellClick(object sender, System.EventArgs e)
        {
            DataGridView dgv = (DataGridView)Controls.Find("dgvMembers", true)[0];
            string currentId = dgv.CurrentRow.Tag.ToString();
            FillMembersInfoById(currentId);
        }

        private void btnExitForm_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void FillMembersInfoById(string id)
        {
            Members m = Members.GetMemberById(id);
            this.Controls.Find("txtFirstName", true)[0].Text = m.FirstName;
            this.Controls.Find("txtLastName", true)[0].Text = m.LastName;

            RadioButton genderF = (RadioButton)Controls.Find("rbtnFemale", true)[0];
            RadioButton genderM = (RadioButton)Controls.Find("rbtnMale", true)[0];
            if (m.Gender == "Ž")
            {
                genderF.Checked = true;
                genderM.Checked = false;
            }
            
            else if (m.Gender == "M")
            {
                genderM.Checked = true;
                genderF.Checked = false;
            }

            this.Controls.Find("dtpDateOfBirth", true)[0].Text = m.DateOfBirth.ToString();
            this.Controls.Find("txtOib", true)[0].Text = m.Oib;
            this.Controls.Find("txtAdress", true)[0].Text = m.Adress;
            this.Controls.Find("txtEmail", true)[0].Text = m.Email;
            this.Controls.Find("txtContact", true)[0].Text = m.Contact;
            this.Controls.Find("cmbLevelOfCompetition", true)[0].Text = m.LevelOfCompetition;

            RadioButton activeCompetitor = (RadioButton)Controls.Find("rbtnActiveCompetitor", true)[0];
            RadioButton activeCompetitor1 = (RadioButton)Controls.Find("rbtnNotActiveCompetitor", true)[0];
            if (m.ActiveCompetitor == true)
            {
                activeCompetitor.Checked = true;
                activeCompetitor1.Checked = false;
            }
            
            else if (m.ActiveCompetitor == false)
            {
                activeCompetitor.Checked = false;
                activeCompetitor1.Checked = true;
            }

            this.Controls.Find("cmbTrainingGroup", true)[0].Text = m.TrainingGroup;
            this.Controls.Find("dtpDateOfJoining", true)[0].Text = m.DateOfJoining.ToString();
            this.Controls.Find("txtPicture", true)[0].Text = m.Picture;
        }
        
        public void PopulateForm(string operation)
        { 
            
            this.Width = 1000;
            this.Height = 600;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblFirstName = new Label
            {
               Text = "Ime",
               Width = 45,
               Location = new Point(250, 50)
            };
            this.Controls.Add(lblFirstName);

            TextBox txtFirstName = new TextBox
            {
              Name = "txtFirstName",
              Width = 200,
              Location = new Point(300, 50)
                };
                this.Controls.Add(txtFirstName);

                Label lblLastName = new Label
                {
                    Text = "Prezime",
                    Width = 45,
                    Location = new Point(250, 100)
                };
                this.Controls.Add(lblLastName);

                TextBox txtLastName = new TextBox
                {
                    Name = "txtLastName",
                    Width = 200,
                    Location = new Point(300, 100)
                };
                this.Controls.Add(txtLastName);

                Label lblGender = new Label
                {
                    Text = "Spol",
                    Width = 45,
                    Location = new Point(250, 170)
                };
                this.Controls.Add(lblGender);

                GroupBox gb = new GroupBox();
                gb.Width = 150;
                gb.Height = 50;
                gb.Location = new Point(300, 150);
                gb.Visible = true;
               
                RadioButton rb1 = new RadioButton();
                rb1.Name = "rbtnFemale";
                rb1.Text = "Ž";
                rb1.Visible = true;
                rb1.Location = new Point(10, 10);
                rb1.CheckedChanged += new EventHandler(rb1_CheckedChanged);

                RadioButton rb2 = new RadioButton();
                rb2.Name = "rbtnMale";
                rb2.Text = "M";
                rb2.Visible = true;
                rb2.Location = rb1.Location;
                rb2.Location = new Point(rb1.Location.X + 50, rb1.Location.Y);
                rb2.CheckedChanged += new EventHandler(rb2_CheckedChanged);

                gb.Controls.Add(rb2);
                gb.Controls.Add(rb1);
                this.Controls.Add(gb);

                Label lblDateOfBirth = new Label
                {
                    Text = "Datum rođenja",
                    Width = 100,
                    Location = new Point(250, 250)
                };
                this.Controls.Add(lblDateOfBirth);

                DateTimePicker dtpDateOfBirth = new DateTimePicker
                {
                    Name = "dtpDateOfBirth",
                    Width = 150,
                    Location = new Point(350, 250)
                };
                this.Controls.Add(dtpDateOfBirth);

                Label lblOib = new Label
                {
                    Text = "Oib",
                    Width = 45,
                    Location = new Point(250, 300)
                };
                this.Controls.Add(lblOib);

                TextBox txtOib = new TextBox
                {
                    Name = "txtOib",
                    Width = 200,
                    Location = new Point(300, 300)
                };
                this.Controls.Add(txtOib);

                Label lblAdress = new Label
                {
                    Text = "Adresa",
                    Width = 45,
                    Location = new Point(250, 350)
                };
                this.Controls.Add(lblAdress);

                TextBox txtAdress = new TextBox
                {
                    Name = "txtAdress",
                    Width = 200,
                    Location = new Point(300, 350)
                };
                this.Controls.Add(txtAdress);

                Label lblEmail = new Label
                {
                    Text = "E-mail",
                    Width = 45,
                    Location = new Point(250, 400)
                };
                this.Controls.Add(lblEmail);

                TextBox txtEmail = new TextBox
                {
                    Name = "txtEmail",
                    Width = 200,
                    Location = new Point(300, 400)
                };
                this.Controls.Add(txtEmail);

                Label lblContact = new Label
                {
                    Text = "Kontakt",
                    Width = 45,
                    Location = new Point(250, 450)
                };
                this.Controls.Add(lblContact);

                TextBox txtContact = new TextBox
                {
                    Name = "txtContact",
                    Width = 200,
                    Location = new Point(300, 450)
                };
                this.Controls.Add(txtContact);

                Label lblActiveCompetitor = new Label
                {
                    Text = "Aktivi natjecatelj",
                    Width = 100,
                    Location = new Point(600, 55)
                };
                this.Controls.Add(lblActiveCompetitor);

                GroupBox gb1 = new GroupBox();
                gb1.Width = 150;
                gb1.Height = 50;
                gb1.Location = new Point(700, 40);
                gb1.Visible = true;

                RadioButton rb11 = new RadioButton();
                rb11.Name = "rbtnActiveCompetitor";
                rb11.Text = "DA";
                rb11.Visible = true;
                rb11.Location = new Point(10, 10);
                rb11.CheckedChanged += new EventHandler(rb11_CheckedChanged);

                RadioButton rb21 = new RadioButton();
                rb21.Name = "rbtnNotActiveCompetitor";
                rb21.Text = "NE";
                rb21.Visible = true;
                rb21.Location = rb1.Location;
                rb21.Location = new Point(rb11.Location.X + 50, rb11.Location.Y);
                rb21.CheckedChanged += new EventHandler(rb21_CheckedChanged);

                gb1.Controls.Add(rb21);
                gb1.Controls.Add(rb11);
                this.Controls.Add(gb1);

                Label lblLevelOfCompetition = new Label
                {
                    Text = "Program natjecanja",
                    Width = 100,
                    Location = new Point(600, 150)
                };
                this.Controls.Add(lblLevelOfCompetition);

                ComboBox cmbLevelOfCompetition = new ComboBox
                {
                    Name = "cmbLevelOfCompetition",
                    Width = 150,
                    Location = new Point(700, 150),
                    DropDownStyle = ComboBoxStyle.DropDownList,
                };
                this.Controls.Add(cmbLevelOfCompetition);

                Label lblTrainingGroup = new Label
                {
                    Text = "Trenira u grupi",
                    Width = 100,
                    Location = new Point(600, 200)
                };
                this.Controls.Add(lblTrainingGroup);
            
                ComboBox cmbTrainingGroup = new ComboBox
                {
                    Name = "cmbTrainingGroup",
                    Width = 150,
                    Location = new Point(700, 200),
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    DataSource = Enum.GetValues(typeof(Members.trainingGroupSelect))
                };
       
                this.Controls.Add(cmbTrainingGroup);

                Label lblDateOfJoining = new Label
                {
                    Text = "Datum upisa",
                    Width = 100,
                    Location = new Point(600, 250)
                };
                this.Controls.Add(lblDateOfJoining);

                DateTimePicker dtpDateOFJoining = new DateTimePicker
                {
                    Name = "dtpDateOfJoining",
                    Width = 150,
                    Location = new Point(700, 250)
                };
                this.Controls.Add(dtpDateOFJoining);

                Label lblPicture = new Label
                {
                    Text = "Naziv (šifra) slike",
                    Width = 100,
                    Location = new Point(600, 300)
                };
                this.Controls.Add(lblPicture);

                TextBox txtPicture = new TextBox
                {
                    Name = "txtPicture",
                    Width = 150,
                    Location = new Point(700, 300)
                };
                this.Controls.Add(txtPicture);

                Button btnAddMember = new Button
                {
                    Name = "btnAddMember",
                    Tag = "INSERT",
                    AutoSize = true,
                    Text = "Dodaj člana",
                    Location = new Point(750, 450),
                    BackColor = Color.Green,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                btnAddMember.Click += new EventHandler(btnAddMember_Click);
                btnAddMember.FlatAppearance.BorderSize = 0;
                this.Controls.Add(btnAddMember);

            Button exitButton = new Button
            {
                Name = "btnExitForm",
                FlatStyle = FlatStyle.Flat,
                Text = "Izađi",
                BackColor = Color.Gray,
                ForeColor = Color.Black,
                Location = new Point(750, 480)
            };
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.Click += new EventHandler(btnExitForm_Click);
            this.Controls.Add(exitButton);

            PictureBox pbPicture = new PictureBox
            {
                Width = 220,
                Height = 500,
                Location = new Point(1, 5),
                ImageLocation = "pictureAddForm/images.jpg",
                SizeMode = PictureBoxSizeMode.Zoom
            };
            this.Controls.Add(pbPicture);

            if (operation == "update/delete")
            {
                this.Controls.Remove(pbPicture);

                CreateDGVMembers();

                btnAddMember.Text = "Ažuriraj člana";
                btnAddMember.Tag = "UPDATE";
                btnAddMember.Location = new Point(710, 450);
                this.Controls.Add(btnAddMember);

                Button deleteButton = new Button();
                deleteButton.Name = "btnDeleteMember";
                deleteButton.Click += new EventHandler(btnDeleteMember_Click);
                deleteButton.FlatStyle = FlatStyle.Flat;
                deleteButton.FlatAppearance.BorderSize = 0;
                deleteButton.Text = "Izbriši člana";
                deleteButton.BackColor = Color.Crimson;
                deleteButton.ForeColor = Color.White;
                deleteButton.Location = new Point(800, 450);
                this.Controls.Add(deleteButton);

                exitButton.Location = new Point(800, 480);
            }
        }

        public void CreateDGVMembers()
        {
            DataGridView dgvMembers = new DataGridView();
            dgvMembers.Name = "dgvMembers";
            dgvMembers.AllowUserToAddRows = false;
            dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMembers.MultiSelect = false;
            dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMembers.AllowUserToDeleteRows = false;
            dgvMembers.AllowUserToResizeColumns = false;
            dgvMembers.AllowUserToResizeRows = false;
            dgvMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMembers.RowHeadersVisible = false;
            dgvMembers.Width = 220;
            dgvMembers.Height = 500;
            dgvMembers.Location = new Point(1, 5);

            dgvMembers.Columns.Add("colFirstName", "Ime");
            dgvMembers.Columns.Add("colLastName", "Prezime");

            foreach (Members tmpMembers in Members.GetAllMembers())
            {
                DataGridViewRow dgvr = new DataGridViewRow();
                dgvr.Tag = tmpMembers.Id;
                DataGridViewTextBoxCell c1 = new DataGridViewTextBoxCell();
                c1.Value = tmpMembers.FirstName;
                DataGridViewTextBoxCell c2 = new DataGridViewTextBoxCell();
                c2.Value = tmpMembers.LastName;
                dgvr.Cells.Add(c1);
                dgvr.Cells.Add(c2);
                dgvMembers.Rows.Add(dgvr);
            }

            dgvMembers.CellClick += new DataGridViewCellEventHandler(dgvMembers_CellClick);

            this.Controls.Add(dgvMembers);

           
        }

        private void rb21_CheckedChanged(object sender, EventArgs e)
        {
            bool cmb = Controls.Find("cmbLevelOfCompetition", true)[0].Enabled = false;
        }

        private void rb11_CheckedChanged(object sender, EventArgs e)
        {
            bool cmb = Controls.Find("cmbLevelOfCompetition", true)[0].Enabled = true;
        }

        private void rb1_CheckedChanged(object sender, EventArgs e)
        {
            ComboBox cbx = (ComboBox)Controls.Find("cmbLevelOfCompetition", true)[0];
            cbx.DataSource = Enum.GetValues(typeof(Members.levelOfCompetitionSelectF));
        }

        private void rb2_CheckedChanged(object sender, EventArgs e)
        {
            ComboBox cbx = (ComboBox)Controls.Find("cmbLevelOfCompetition", true)[0];
            cbx.DataSource = Enum.GetValues(typeof(Members.levelOfCompetitionSelectM));
        }
        
    }
}
