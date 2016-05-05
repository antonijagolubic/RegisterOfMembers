using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Register_Of__Members
{
    public partial class AddAdmin : Form
    {
        public AddAdmin(string operation)
        {
            InitializeComponent();
            PopulateForm(operation);
            if (operation == "update/delete")
            {
                FillAdminsInfoByOib(Admin.GetAllUsers()[0].Oib);
            }
        }

        private void FillAdminsInfoByOib(string oib)
        {
            Admin a = Admin.GetAdminsByOib(oib);

            this.Controls.Find("txtUserName", true)[0].Text = a.UserName;
            this.Controls.Find("txtPassword", true)[0].Text = a.Password;
            this.Controls.Find("txtFirstName", true)[0].Text = a.FirstName;
            this.Controls.Find("txtLastName", true)[0].Text = a.LastName;
            this.Controls.Find("txtOib", true)[0].Text = a.Oib;
            
            RadioButton isAdmin = (RadioButton)Controls.Find("rbtnIsAdmin", true)[0];
            RadioButton notAdmin = (RadioButton)Controls.Find("rbtnNotAdmin", true)[0];
            if (a.Clearance == "1111")
            {
                isAdmin.Checked = true;
                notAdmin.Checked = false;
            }

            else if (a.Clearance == "0000")
            {
                isAdmin.Checked = false;
                notAdmin.Checked = true;
            }
            
        }

        private void btnAddAdmin_Click(object sender, System.EventArgs e)
        {
            string action = Controls.Find("btnAddAdmin", true)[0].Tag.ToString();

            string userName = Controls.Find("txtUserName", true)[0].Text;
            string password = Controls.Find("txtPassword", true)[0].Text;
            string password2 = Controls.Find("txtPassword2", true)[0].Text;
            string firstName = Controls.Find("txtFirstName", true)[0].Text;
            string lastName = Controls.Find("txtLastName", true)[0].Text;
            string oib = Controls.Find("txtOib", true)[0].Text;
            string clerance = "";
            RadioButton isAdmin = (RadioButton)Controls.Find("rbtnIsAdmin", true)[0];
            if (isAdmin.Checked)
            {
                clerance = "1111";
            }
            RadioButton notAdmin = (RadioButton)Controls.Find("rbtnNotAdmin", true)[0];
            if (notAdmin.Checked)
            {
                clerance = "0000";
            }

            bool correctPassword = password == password2;

            if (action == "INSERT")
            {
                try
                {
                    Admin.AddAdminToDatabase(correctPassword, userName, password,firstName, lastName, oib, clerance);
                }
                catch (Exception)
                {
                    throw new Exception("Greška kod spremanja podataka!");
                    throw;
                }

                DialogResult drNewAdd = MessageBox.Show("Želite li novi unos?", "Novi unos", MessageBoxButtons.YesNo);
                if (drNewAdd == DialogResult.Yes)
                {
                    AddMember.ClearControls(this);
                }
                else
                {
                    this.Close();
                }

            }
            else if (action == "UPDATE")
            {
                DataGridView dgv = (DataGridView)Controls.Find("dgvAdmin", true)[0];
                string currentOib = dgv.CurrentRow.Tag.ToString();

                try
                {
                    Admin.UpdateAdminInDatabase(correctPassword, userName, password, firstName, lastName, oib, clerance);
                }
                catch (Exception)
                {
                    throw new Exception("Greška kod spremanja podataka o adminu!");
                    throw;
                }
                ClearDGV(this);
                CreateDGVAdmin();
                AddMember.ClearControls(this);
            }
        }

        private void btnDeleteAdmin_Click(object sender, System.EventArgs e)
        {
            DataGridView dgv = (DataGridView)Controls.Find("dgvAdmin", true)[0];
            string currentOib = dgv.CurrentRow.Tag.ToString();

            try
            {
                Admin.DeleteAdminInDatabase(currentOib);
            }
            catch (Exception)
            {
                throw new Exception("Greška kod brisanja podataka!");
                throw;
            }
            ClearDGV(this);
            CreateDGVAdmin();
            AddMember.ClearControls(this);

        }

        private void dgvAdmin_CellClick(object sender, System.EventArgs e)
        {
            DataGridView dgv = (DataGridView)Controls.Find("dgvAdmin", true)[0];
            string currentOib = dgv.CurrentRow.Tag.ToString();
            FillAdminsInfoByOib(currentOib);
        }

        private void btnExitForm_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        public void PopulateForm(string operation)
        {
            this.Width = 600;
            this.Height = 650;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblUserName = new Label
            {
                Text = "Korisničko ime",
                Width = 100,
                Location = new Point(250, 50)
            };
            this.Controls.Add(lblUserName);

            TextBox txtUserName = new TextBox
            {
                Name = "txtUserName",
                Width = 150,
                Location = new Point(350, 50)
            };
            this.Controls.Add(txtUserName);

            Label lblPassword = new Label
            {
                Text = "Lozinka",
                Width = 45,
                Location = new Point(250, 100)
            };
            this.Controls.Add(lblPassword);

            TextBox txtPassword = new TextBox
            {
                Name = "txtPassword",
                Width = 200,
                Location = new Point(300, 100)
            };
            this.Controls.Add(txtPassword);

            Label lblPassword2 = new Label
            {
                Text = "Ponovite lozinku",
                Width = 100,
                Location = new Point(250, 150)
            };
            this.Controls.Add(lblPassword2);

            TextBox txtPassword2 = new TextBox
            {
                Name = "txtPassword2",
                Width = 150,
                Location = new Point(350, 150)
            };
            this.Controls.Add(txtPassword2);

            Label lblFirstName = new Label
            {
                Text = "Ime",
                Width = 45,
                Location = new Point(250, 200)
            };
            this.Controls.Add(lblFirstName);

            TextBox txtFirstName = new TextBox
            {
                Name = "txtFirstName",
                Width = 200,
                Location = new Point(300, 200)
            };
            this.Controls.Add(txtFirstName);

            Label lblLastName = new Label
            {
                Text = "Prezime",
                Width = 45,
                Location = new Point(250, 250)
            };
            this.Controls.Add(lblLastName);

            TextBox txtLastName = new TextBox
            {
                Name = "txtLastName",
                Width = 200,
                Location = new Point(300, 250)
            };
            this.Controls.Add(txtLastName);

            Label lblOib = new Label
            {
                Text = "OIB",
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

            Label lblClerance = new Label
            {
                Text = "Korisnik je administrator",
                Width = 200,
                Location = new Point(250, 350)
            };
            this.Controls.Add(lblClerance);

            GroupBox gb1 = new GroupBox();
            gb1.Width = 150;
            gb1.Height = 50;
            gb1.Location = new Point(270, 380);
            gb1.Visible = true;

            RadioButton rb11 = new RadioButton();
            rb11.Name = "rbtnIsAdmin";
            rb11.Text = "DA";
            rb11.Visible = true;
            rb11.Location = new Point(10, 10);

            RadioButton rb21 = new RadioButton();
            rb21.Name = "rbtnNotAdmin";
            rb21.Text = "NE";
            rb21.Visible = true;
            rb21.Location = rb11.Location;
            rb21.Location = new Point(rb11.Location.X + 50, rb11.Location.Y);

            gb1.Controls.Add(rb21);
            gb1.Controls.Add(rb11);
            this.Controls.Add(gb1);

            Button btnAddAdmin = new Button
            {
                Name = "btnAddAdmin",
                Tag = "INSERT",
                AutoSize = true,
                Text = "Dodaj",
                Location = new Point(400, 500),
                BackColor = Color.Green,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnAddAdmin.Click += new EventHandler(btnAddAdmin_Click);
            btnAddAdmin.FlatAppearance.BorderSize = 0;
            this.Controls.Add(btnAddAdmin);

            Button exitButton = new Button
            {
                Name = "btnExitForm",
                FlatStyle = FlatStyle.Flat,
                Text = "Izađi",
                BackColor = Color.Gray,
                ForeColor = Color.Black,
                Location = new Point(400, 530)
            };
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.Click += new EventHandler(btnExitForm_Click);
            this.Controls.Add(exitButton);

            PictureBox pbPicture = new PictureBox
            {
                Width = 220,
                Height = 500,
                Location = new Point(1, 10),
                ImageLocation = "pictureAddForm/images.jpg",
                SizeMode = PictureBoxSizeMode.Zoom
            };
            this.Controls.Add(pbPicture);

            if (operation == "update/delete")
            {
                this.Controls.Remove(pbPicture);

                CreateDGVAdmin();

                btnAddAdmin.Text = "Ažuriraj";
                btnAddAdmin.Tag = "UPDATE";
                this.Controls.Add(btnAddAdmin);

                exitButton.Location = new Point(490, 530);
                this.Controls.Add(exitButton);

                Button deleteButton = new Button();
                deleteButton.Name = "btnDeleteAdmin";
                deleteButton.Click += new EventHandler(btnDeleteAdmin_Click);
                deleteButton.FlatStyle = FlatStyle.Flat;
                deleteButton.FlatAppearance.BorderSize = 0;
                deleteButton.Text = "Izbriši";
                deleteButton.BackColor = Color.Crimson;
                deleteButton.ForeColor = Color.White;
                deleteButton.Location = new Point(490, 500);
                this.Controls.Add(deleteButton);



            }


        }

        public void CreateDGVAdmin()
        {
            DataGridView dgvAdmin = new DataGridView();
            dgvAdmin.Name = "dgvAdmin";
            dgvAdmin.AllowUserToAddRows = false;
            dgvAdmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAdmin.MultiSelect = false;
            dgvAdmin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdmin.AllowUserToDeleteRows = false;
            dgvAdmin.AllowUserToResizeColumns = false;
            dgvAdmin.AllowUserToResizeRows = false;
            dgvAdmin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAdmin.RowHeadersVisible = false;
            dgvAdmin.Width = 220;
            dgvAdmin.Height = 500;
            dgvAdmin.Location = new Point(1, 10);

            dgvAdmin.Columns.Add("colFirstName", "Ime");
            dgvAdmin.Columns.Add("colLastName", "Prezime");

            foreach (Admin tmpAdmin in Admin.GetAllUsers())
            {
                DataGridViewRow dgvr = new DataGridViewRow();
                dgvr.Tag = tmpAdmin.Oib;
                DataGridViewTextBoxCell c1 = new DataGridViewTextBoxCell();
                c1.Value = tmpAdmin.FirstName;
                DataGridViewTextBoxCell c2 = new DataGridViewTextBoxCell();
                c2.Value = tmpAdmin.LastName;
                dgvr.Cells.Add(c1);
                dgvr.Cells.Add(c2);
                dgvAdmin.Rows.Add(dgvr);
            }

            dgvAdmin.CellClick += new DataGridViewCellEventHandler(dgvAdmin_CellClick);

            this.Controls.Add(dgvAdmin);
            
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
    }
}
