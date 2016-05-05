namespace Register_Of__Members
{
    partial class AdminView
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
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmChange = new System.Windows.Forms.ToolStripMenuItem();
            this.isprintajPopisČlanovaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administracijaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajNovogAdminaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ažurirajAdminaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtAdress = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtOib = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbtnMale = new System.Windows.Forms.RadioButton();
            this.rbtnFemale = new System.Windows.Forms.RadioButton();
            this.label23 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.picbPicture = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtpDateOfJoining = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbLevelOfCompetition = new System.Windows.Forms.ComboBox();
            this.cmbAgeCategory = new System.Windows.Forms.ComboBox();
            this.cmbTrainingGroup = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnNotActiveCompetitor = new System.Windows.Forms.RadioButton();
            this.rbtnActiveCompetitor = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.printCurrentMember = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbPicture)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPreview
            // 
            this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreview.Location = new System.Drawing.Point(12, 50);
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.Size = new System.Drawing.Size(240, 478);
            this.dgvPreview.TabIndex = 1;
            this.dgvPreview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPreview_CellClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPreview,
            this.tsmAdd,
            this.tsmChange,
            this.isprintajPopisČlanovaToolStripMenuItem,
            this.administracijaToolStripMenuItem,
            this.tsmLogout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(806, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmPreview
            // 
            this.tsmPreview.Name = "tsmPreview";
            this.tsmPreview.Size = new System.Drawing.Size(59, 20);
            this.tsmPreview.Text = "Pregled";
            this.tsmPreview.Click += new System.EventHandler(this.tsmPreview_Click);
            // 
            // tsmAdd
            // 
            this.tsmAdd.Name = "tsmAdd";
            this.tsmAdd.Size = new System.Drawing.Size(75, 20);
            this.tsmAdd.Text = "Dodavanje";
            this.tsmAdd.Click += new System.EventHandler(this.tsmAdd_Click);
            // 
            // tsmChange
            // 
            this.tsmChange.Name = "tsmChange";
            this.tsmChange.Size = new System.Drawing.Size(75, 20);
            this.tsmChange.Text = "Uređivanje";
            this.tsmChange.Click += new System.EventHandler(this.tsmChange_Click);
            // 
            // isprintajPopisČlanovaToolStripMenuItem
            // 
            this.isprintajPopisČlanovaToolStripMenuItem.Name = "isprintajPopisČlanovaToolStripMenuItem";
            this.isprintajPopisČlanovaToolStripMenuItem.Size = new System.Drawing.Size(137, 20);
            this.isprintajPopisČlanovaToolStripMenuItem.Text = "Isprintaj popis članova";
            this.isprintajPopisČlanovaToolStripMenuItem.Click += new System.EventHandler(this.isprintajPopisČlanovaToolStripMenuItem_Click);
            // 
            // administracijaToolStripMenuItem
            // 
            this.administracijaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajNovogAdminaToolStripMenuItem,
            this.ažurirajAdminaToolStripMenuItem});
            this.administracijaToolStripMenuItem.Name = "administracijaToolStripMenuItem";
            this.administracijaToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.administracijaToolStripMenuItem.Text = "Administracija";
            // 
            // dodajNovogAdminaToolStripMenuItem
            // 
            this.dodajNovogAdminaToolStripMenuItem.Name = "dodajNovogAdminaToolStripMenuItem";
            this.dodajNovogAdminaToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.dodajNovogAdminaToolStripMenuItem.Text = "Dodaj novog admina";
            this.dodajNovogAdminaToolStripMenuItem.Click += new System.EventHandler(this.dodajNovogAdminaToolStripMenuItem_Click);
            // 
            // ažurirajAdminaToolStripMenuItem
            // 
            this.ažurirajAdminaToolStripMenuItem.Name = "ažurirajAdminaToolStripMenuItem";
            this.ažurirajAdminaToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.ažurirajAdminaToolStripMenuItem.Text = "Ažuriraj admina";
            this.ažurirajAdminaToolStripMenuItem.Click += new System.EventHandler(this.ažurirajAdminaToolStripMenuItem_Click);
            // 
            // tsmLogout
            // 
            this.tsmLogout.Name = "tsmLogout";
            this.tsmLogout.Size = new System.Drawing.Size(56, 20);
            this.tsmLogout.Text = "Odjava";
            this.tsmLogout.Click += new System.EventHandler(this.tsmLogout_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPage1);
            this.tabControlMain.Controls.Add(this.tabPage2);
            this.tabControlMain.Location = new System.Drawing.Point(291, 50);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(458, 478);
            this.tabControlMain.TabIndex = 23;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtNumber);
            this.tabPage1.Controls.Add(this.txtEmail);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.txtAdress);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.txtOib);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.dtpDateOfBirth);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.txtLastName);
            this.tabPage1.Controls.Add(this.txtFirstName);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.label27);
            this.tabPage1.Controls.Add(this.picbPicture);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(450, 452);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Opći podaci";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(150, 406);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(198, 20);
            this.txtNumber.TabIndex = 53;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(150, 370);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(198, 20);
            this.txtEmail.TabIndex = 52;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(47, 370);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(34, 13);
            this.label20.TabIndex = 43;
            this.label20.Text = "e-mail";
            // 
            // txtAdress
            // 
            this.txtAdress.Location = new System.Drawing.Point(150, 335);
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.Size = new System.Drawing.Size(198, 20);
            this.txtAdress.TabIndex = 51;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(46, 335);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 13);
            this.label21.TabIndex = 41;
            this.label21.Text = "Adresa";
            // 
            // txtOib
            // 
            this.txtOib.Location = new System.Drawing.Point(150, 301);
            this.txtOib.Name = "txtOib";
            this.txtOib.Size = new System.Drawing.Size(198, 20);
            this.txtOib.TabIndex = 50;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(47, 406);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(44, 13);
            this.label22.TabIndex = 42;
            this.label22.Text = "Kontakt";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Location = new System.Drawing.Point(150, 266);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(121, 20);
            this.dtpDateOfBirth.TabIndex = 49;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbtnMale);
            this.groupBox4.Controls.Add(this.rbtnFemale);
            this.groupBox4.Location = new System.Drawing.Point(154, 211);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(100, 42);
            this.groupBox4.TabIndex = 48;
            this.groupBox4.TabStop = false;
            // 
            // rbtnMale
            // 
            this.rbtnMale.AutoSize = true;
            this.rbtnMale.Location = new System.Drawing.Point(60, 17);
            this.rbtnMale.Name = "rbtnMale";
            this.rbtnMale.Size = new System.Drawing.Size(34, 17);
            this.rbtnMale.TabIndex = 1;
            this.rbtnMale.TabStop = true;
            this.rbtnMale.Text = "M";
            this.rbtnMale.UseVisualStyleBackColor = true;
            // 
            // rbtnFemale
            // 
            this.rbtnFemale.AutoSize = true;
            this.rbtnFemale.Location = new System.Drawing.Point(6, 17);
            this.rbtnFemale.Name = "rbtnFemale";
            this.rbtnFemale.Size = new System.Drawing.Size(32, 17);
            this.rbtnFemale.TabIndex = 0;
            this.rbtnFemale.TabStop = true;
            this.rbtnFemale.Text = "Ž";
            this.rbtnFemale.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rbtnFemale.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(46, 228);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(28, 13);
            this.label23.TabIndex = 47;
            this.label23.Text = "Spol";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(150, 182);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(198, 20);
            this.txtLastName.TabIndex = 46;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(150, 149);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(198, 20);
            this.txtFirstName.TabIndex = 45;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(47, 303);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(25, 13);
            this.label24.TabIndex = 40;
            this.label24.Text = "OIB";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(46, 266);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(77, 13);
            this.label25.TabIndex = 39;
            this.label25.Text = "Datum rođenja";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(46, 182);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(44, 13);
            this.label26.TabIndex = 38;
            this.label26.Text = "Prezime";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(46, 149);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(24, 13);
            this.label27.TabIndex = 37;
            this.label27.Text = "Ime";
            // 
            // picbPicture
            // 
            this.picbPicture.Location = new System.Drawing.Point(49, 24);
            this.picbPicture.Name = "picbPicture";
            this.picbPicture.Size = new System.Drawing.Size(105, 105);
            this.picbPicture.TabIndex = 44;
            this.picbPicture.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtpDateOfJoining);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.cmbLevelOfCompetition);
            this.tabPage2.Controls.Add(this.cmbAgeCategory);
            this.tabPage2.Controls.Add(this.cmbTrainingGroup);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(450, 452);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Aktivnost u klubu";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtpDateOfJoining
            // 
            this.dtpDateOfJoining.Location = new System.Drawing.Point(146, 202);
            this.dtpDateOfJoining.Name = "dtpDateOfJoining";
            this.dtpDateOfJoining.Size = new System.Drawing.Size(121, 20);
            this.dtpDateOfJoining.TabIndex = 51;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "Datum učlanjenja";
            // 
            // cmbLevelOfCompetition
            // 
            this.cmbLevelOfCompetition.FormattingEnabled = true;
            this.cmbLevelOfCompetition.Location = new System.Drawing.Point(146, 100);
            this.cmbLevelOfCompetition.Name = "cmbLevelOfCompetition";
            this.cmbLevelOfCompetition.Size = new System.Drawing.Size(121, 21);
            this.cmbLevelOfCompetition.TabIndex = 39;
            // 
            // cmbAgeCategory
            // 
            this.cmbAgeCategory.FormattingEnabled = true;
            this.cmbAgeCategory.Location = new System.Drawing.Point(146, 133);
            this.cmbAgeCategory.Name = "cmbAgeCategory";
            this.cmbAgeCategory.Size = new System.Drawing.Size(121, 21);
            this.cmbAgeCategory.TabIndex = 38;
            // 
            // cmbTrainingGroup
            // 
            this.cmbTrainingGroup.FormattingEnabled = true;
            this.cmbTrainingGroup.Location = new System.Drawing.Point(146, 167);
            this.cmbTrainingGroup.Name = "cmbTrainingGroup";
            this.cmbTrainingGroup.Size = new System.Drawing.Size(121, 21);
            this.cmbTrainingGroup.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Trenira u grupi";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnNotActiveCompetitor);
            this.groupBox1.Controls.Add(this.rbtnActiveCompetitor);
            this.groupBox1.Location = new System.Drawing.Point(150, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(100, 42);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            // 
            // rbtnNotActiveCompetitor
            // 
            this.rbtnNotActiveCompetitor.AutoSize = true;
            this.rbtnNotActiveCompetitor.Location = new System.Drawing.Point(60, 17);
            this.rbtnNotActiveCompetitor.Name = "rbtnNotActiveCompetitor";
            this.rbtnNotActiveCompetitor.Size = new System.Drawing.Size(40, 17);
            this.rbtnNotActiveCompetitor.TabIndex = 1;
            this.rbtnNotActiveCompetitor.TabStop = true;
            this.rbtnNotActiveCompetitor.Text = "NE";
            this.rbtnNotActiveCompetitor.UseVisualStyleBackColor = true;
            // 
            // rbtnActiveCompetitor
            // 
            this.rbtnActiveCompetitor.AutoSize = true;
            this.rbtnActiveCompetitor.Location = new System.Drawing.Point(6, 17);
            this.rbtnActiveCompetitor.Name = "rbtnActiveCompetitor";
            this.rbtnActiveCompetitor.Size = new System.Drawing.Size(40, 17);
            this.rbtnActiveCompetitor.TabIndex = 0;
            this.rbtnActiveCompetitor.TabStop = true;
            this.rbtnActiveCompetitor.Text = "DA";
            this.rbtnActiveCompetitor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rbtnActiveCompetitor.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Aktivni natjecatelj";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Starosna kategorija";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Program natjecanja";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(42, 119);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(0, 13);
            this.label19.TabIndex = 20;
            // 
            // printCurrentMember
            // 
            this.printCurrentMember.Location = new System.Drawing.Point(674, 530);
            this.printCurrentMember.Name = "printCurrentMember";
            this.printCurrentMember.Size = new System.Drawing.Size(75, 23);
            this.printCurrentMember.TabIndex = 24;
            this.printCurrentMember.Text = "Isprintaj";
            this.printCurrentMember.UseVisualStyleBackColor = true;
            this.printCurrentMember.Click += new System.EventHandler(this.printCurrentMember_Click);
            // 
            // AdminView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 592);
            this.Controls.Add(this.printCurrentMember);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.dgvPreview);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminView";
            this.Text = "AdminView";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbPicture)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPreview;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmPreview;
        private System.Windows.Forms.ToolStripMenuItem tsmAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmChange;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtAdress;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtOib;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbtnMale;
        private System.Windows.Forms.RadioButton rbtnFemale;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.PictureBox picbPicture;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DateTimePicker dtpDateOfJoining;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbLevelOfCompetition;
        private System.Windows.Forms.ComboBox cmbAgeCategory;
        private System.Windows.Forms.ComboBox cmbTrainingGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnNotActiveCompetitor;
        private System.Windows.Forms.RadioButton rbtnActiveCompetitor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ToolStripMenuItem tsmLogout;
        private System.Windows.Forms.ToolStripMenuItem administracijaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajNovogAdminaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ažurirajAdminaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem isprintajPopisČlanovaToolStripMenuItem;
        private System.Windows.Forms.Button printCurrentMember;
    }
}