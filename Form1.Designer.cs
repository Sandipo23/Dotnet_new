namespace WinFormsApp1
{
    partial class StudentForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbCourse = new ComboBox();
            rbFemale = new RadioButton();
            rbMale = new RadioButton();
            btnSave = new Button();
            txtFee = new TextBox();
            txtFullName = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            txtCourse = new Label();
            lblGender = new Label();
            lblFee = new Label();
            lblFullName = new Label();
            lblLastNameError = new Label();
            lblLastName = new Label();
            lblFirstNameError = new Label();
            label5 = new Label();
            btnCancel = new Button();
            lblCourseError = new Label();
            chkAgree = new CheckBox();
            pbStudent = new PictureBox();
            btnUpload = new Button();
            btnRemove = new Button();
            txtImage = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            dgvStudents = new DataGridView();
            lblDOBError = new Label();
            lblDOB = new Label();
            dtpDOB = new DateTimePicker();
            lblAgreeError = new Label();
            txtHobbies = new Label();
            lblHobbiesError = new Label();
            lbHobbies = new CheckedListBox();
            menuStrip = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            menuLogout = new ToolStripMenuItem();
            lblUserName = new Label();
            txtSearch = new TextBox();
            lblSearch = new Label();
            ((System.ComponentModel.ISupportInitialize)pbStudent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // cmbCourse
            // 
            cmbCourse.FormattingEnabled = true;
            cmbCourse.Location = new Point(140, 246);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.Size = new Size(154, 23);
            cmbCourse.TabIndex = 2;
            cmbCourse.SelectedIndexChanged += cmbCourse_SelectedIndexChanged;
            // 
            // rbFemale
            // 
            rbFemale.AutoSize = true;
            rbFemale.Location = new Point(209, 211);
            rbFemale.Name = "rbFemale";
            rbFemale.Size = new Size(57, 19);
            rbFemale.TabIndex = 1022;
            rbFemale.TabStop = true;
            rbFemale.Text = "Femle";
            rbFemale.UseVisualStyleBackColor = true;
            rbFemale.CheckedChanged += rbFemale_CheckedChanged;
            // 
            // rbMale
            // 
            rbMale.AutoSize = true;
            rbMale.Location = new Point(140, 211);
            rbMale.Name = "rbMale";
            rbMale.Size = new Size(51, 19);
            rbMale.TabIndex = 1021;
            rbMale.TabStop = true;
            rbMale.Text = "Male";
            rbMale.UseVisualStyleBackColor = true;
            rbMale.CheckedChanged += rbMale_CheckedChanged;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(136, 492);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(126, 39);
            btnSave.TabIndex = 1015;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtFee
            // 
            txtFee.Location = new Point(137, 172);
            txtFee.Name = "txtFee";
            txtFee.ReadOnly = true;
            txtFee.Size = new Size(157, 23);
            txtFee.TabIndex = 1019;
            txtFee.TextChanged += txtFee_TextChanged;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(137, 124);
            txtFullName.Name = "txtFullName";
            txtFullName.ReadOnly = true;
            txtFullName.Size = new Size(157, 23);
            txtFullName.TabIndex = 1020;
            txtFullName.TextChanged += txtFullName_TextChanged;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(137, 95);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(157, 23);
            txtLastName.TabIndex = 1014;
            txtLastName.TextChanged += txtLastName_TextChanged;
            // 
            // txtFirstName
            // 
            txtFirstName.AccessibleName = "";
            txtFirstName.Location = new Point(137, 70);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(157, 23);
            txtFirstName.TabIndex = 1012;
            txtFirstName.TextChanged += txtFirstName_TextChanged;
            // 
            // txtCourse
            // 
            txtCourse.AutoSize = true;
            txtCourse.Font = new Font("Segoe UI", 11F);
            txtCourse.Location = new Point(39, 245);
            txtCourse.Name = "txtCourse";
            txtCourse.Size = new Size(54, 20);
            txtCourse.TabIndex = 1011;
            txtCourse.Text = "Course";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 11F);
            lblGender.Location = new Point(42, 211);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(57, 20);
            lblGender.TabIndex = 1010;
            lblGender.Text = "Gender";
            // 
            // lblFee
            // 
            lblFee.AutoSize = true;
            lblFee.Font = new Font("Segoe UI", 11F);
            lblFee.Location = new Point(39, 172);
            lblFee.Name = "lblFee";
            lblFee.Size = new Size(87, 20);
            lblFee.TabIndex = 1009;
            lblFee.Text = "Student Fee";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 11F);
            lblFullName.Location = new Point(39, 128);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(76, 20);
            lblFullName.TabIndex = 1008;
            lblFullName.Text = "Full Name";
            // 
            // lblLastNameError
            // 
            lblLastNameError.AutoSize = true;
            lblLastNameError.Font = new Font("Segoe UI", 11F);
            lblLastNameError.ForeColor = Color.Red;
            lblLastNameError.Location = new Point(327, 98);
            lblLastNameError.Name = "lblLastNameError";
            lblLastNameError.Size = new Size(153, 20);
            lblLastNameError.TabIndex = 1007;
            lblLastNameError.Text = "Last Name is required";
            lblLastNameError.Visible = false;
            lblLastNameError.Click += lblLastNameError_Click;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 11F);
            lblLastName.Location = new Point(39, 98);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(79, 20);
            lblLastName.TabIndex = 1006;
            lblLastName.Text = "Last Name";
            // 
            // lblFirstNameError
            // 
            lblFirstNameError.AutoSize = true;
            lblFirstNameError.BackColor = SystemColors.Control;
            lblFirstNameError.Font = new Font("Segoe UI", 11F);
            lblFirstNameError.ForeColor = Color.Red;
            lblFirstNameError.Location = new Point(326, 73);
            lblFirstNameError.Name = "lblFirstNameError";
            lblFirstNameError.Size = new Size(154, 20);
            lblFirstNameError.TabIndex = 1013;
            lblFirstNameError.Text = "First Name is required";
            lblFirstNameError.Visible = false;
            lblFirstNameError.Click += lblFirstNameError_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F);
            label5.Location = new Point(39, 69);
            label5.Name = "label5";
            label5.Size = new Size(80, 20);
            label5.TabIndex = 1005;
            label5.Text = "First Name";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(281, 492);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(109, 39);
            btnCancel.TabIndex = 1023;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblCourseError
            // 
            lblCourseError.AutoSize = true;
            lblCourseError.Font = new Font("Segoe UI", 11F);
            lblCourseError.ForeColor = Color.Red;
            lblCourseError.Location = new Point(326, 249);
            lblCourseError.Name = "lblCourseError";
            lblCourseError.Size = new Size(170, 20);
            lblCourseError.TabIndex = 1007;
            lblCourseError.Text = "Course must be selected";
            lblCourseError.Visible = false;
            lblCourseError.Click += lblLastNameError_Click;
            // 
            // chkAgree
            // 
            chkAgree.AutoSize = true;
            chkAgree.Location = new Point(136, 443);
            chkAgree.Name = "chkAgree";
            chkAgree.Size = new Size(176, 19);
            chkAgree.TabIndex = 1024;
            chkAgree.Text = "I agree terms and conditions";
            chkAgree.UseVisualStyleBackColor = true;
            chkAgree.CheckedChanged += chkAgree_CheckedChanged;
            // 
            // pbStudent
            // 
            pbStudent.Location = new Point(619, 68);
            pbStudent.Name = "pbStudent";
            pbStudent.Size = new Size(143, 124);
            pbStudent.TabIndex = 1025;
            pbStudent.TabStop = false;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(595, 242);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(88, 27);
            btnUpload.TabIndex = 1026;
            btnUpload.Text = "Upload";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(689, 242);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(82, 27);
            btnRemove.TabIndex = 1027;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click_1;
            // 
            // txtImage
            // 
            txtImage.Location = new Point(604, 207);
            txtImage.Name = "txtImage";
            txtImage.Size = new Size(167, 23);
            txtImage.TabIndex = 1028;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(39, 552);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.Size = new Size(723, 238);
            dgvStudents.TabIndex = 1029;
            // 
            // lblDOBError
            // 
            lblDOBError.AutoSize = true;
            lblDOBError.Font = new Font("Segoe UI", 11F);
            lblDOBError.ForeColor = Color.Red;
            lblDOBError.Location = new Point(363, 293);
            lblDOBError.Name = "lblDOBError";
            lblDOBError.Size = new Size(114, 20);
            lblDOBError.TabIndex = 1007;
            lblDOBError.Text = "DOB is required";
            lblDOBError.Visible = false;
            lblDOBError.Click += lblLastNameError_Click;
            // 
            // lblDOB
            // 
            lblDOB.AutoSize = true;
            lblDOB.Font = new Font("Segoe UI", 11F);
            lblDOB.Location = new Point(39, 288);
            lblDOB.Name = "lblDOB";
            lblDOB.Size = new Size(40, 20);
            lblDOB.TabIndex = 1011;
            lblDOB.Text = "DOB";
            // 
            // dtpDOB
            // 
            dtpDOB.Location = new Point(137, 290);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(200, 23);
            dtpDOB.TabIndex = 1030;
            dtpDOB.ValueChanged += dtpDOB_ValueChanged;
            // 
            // lblAgreeError
            // 
            lblAgreeError.AutoSize = true;
            lblAgreeError.Font = new Font("Segoe UI", 11F);
            lblAgreeError.ForeColor = Color.Red;
            lblAgreeError.Location = new Point(322, 440);
            lblAgreeError.Name = "lblAgreeError";
            lblAgreeError.Size = new Size(251, 20);
            lblAgreeError.TabIndex = 1007;
            lblAgreeError.Text = "must agree the terms and conditions";
            lblAgreeError.Visible = false;
            lblAgreeError.Click += lblLastNameError_Click;
            // 
            // txtHobbies
            // 
            txtHobbies.AutoSize = true;
            txtHobbies.Font = new Font("Segoe UI", 11F);
            txtHobbies.Location = new Point(39, 330);
            txtHobbies.Name = "txtHobbies";
            txtHobbies.Size = new Size(68, 20);
            txtHobbies.TabIndex = 1011;
            txtHobbies.Text = "Hobbies:";
            // 
            // lblHobbiesError
            // 
            lblHobbiesError.AutoSize = true;
            lblHobbiesError.Font = new Font("Segoe UI", 11F);
            lblHobbiesError.ForeColor = Color.Red;
            lblHobbiesError.Location = new Point(363, 370);
            lblHobbiesError.Name = "lblHobbiesError";
            lblHobbiesError.Size = new Size(178, 20);
            lblHobbiesError.TabIndex = 1007;
            lblHobbiesError.Text = "hobbies must be selected";
            lblHobbiesError.Visible = false;
            lblHobbiesError.Click += lblLastNameError_Click;
            // 
            // lbHobbies
            // 
            lbHobbies.FormattingEnabled = true;
            lbHobbies.Location = new Point(137, 330);
            lbHobbies.Name = "lbHobbies";
            lbHobbies.Size = new Size(200, 94);
            lbHobbies.TabIndex = 1031;
            lbHobbies.SelectedIndexChanged += lbHobbies_SelectedIndexChanged_1;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 24);
            menuStrip.TabIndex = 1032;
            menuStrip.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuLogout });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // menuLogout
            // 
            menuLogout.Name = "menuLogout";
            menuLogout.Size = new Size(112, 22);
            menuLogout.Text = "Logout";
            menuLogout.Click += menuLogout_Click;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(652, 37);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(0, 15);
            lblUserName.TabIndex = 1033;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(650, 523);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(112, 23);
            txtSearch.TabIndex = 1034;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(595, 526);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(42, 15);
            lblSearch.TabIndex = 1035;
            lblSearch.Text = "Search";
            // 
            // StudentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 802);
            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblUserName);
            Controls.Add(lbHobbies);
            Controls.Add(dtpDOB);
            Controls.Add(dgvStudents);
            Controls.Add(txtImage);
            Controls.Add(btnRemove);
            Controls.Add(btnUpload);
            Controls.Add(pbStudent);
            Controls.Add(chkAgree);
            Controls.Add(btnCancel);
            Controls.Add(cmbCourse);
            Controls.Add(rbFemale);
            Controls.Add(rbMale);
            Controls.Add(btnSave);
            Controls.Add(txtFee);
            Controls.Add(txtFullName);
            Controls.Add(txtLastName);
            Controls.Add(txtHobbies);
            Controls.Add(lblDOB);
            Controls.Add(txtFirstName);
            Controls.Add(txtCourse);
            Controls.Add(lblGender);
            Controls.Add(lblFee);
            Controls.Add(lblFullName);
            Controls.Add(lblHobbiesError);
            Controls.Add(lblDOBError);
            Controls.Add(lblAgreeError);
            Controls.Add(lblCourseError);
            Controls.Add(lblLastNameError);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstNameError);
            Controls.Add(label5);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "StudentForm";
            Text = "Student Form";
            Load += StudentForm_Load;
            ((System.ComponentModel.ISupportInitialize)pbStudent).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCourse;
        private RadioButton rbFemale;
        private RadioButton rbMale;
       
        private Button btnSave;
        private TextBox txtFee;
        private TextBox txtFullName;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private Label txtCourse;
        private Label lblGender;
        private Label lblFee;
        private Label lblFullName;
        private Label lblLastNameError;
        private Label lblLastName;
        private Label lblFirstNameError;
        private Label label5;
        private Button btnCancel;
        private Label lblCourseError;
        private CheckBox chkAgree;
        private PictureBox pbStudent;
        private Button btnUpload;
        private Button btnRemove;
        private TextBox txtImage;
        private OpenFileDialog openFileDialog1;
        private DataGridView dgvStudents;
        private Label lblDOBError;
        private Label lblDOB;
        private DateTimePicker dtpDOB;
        private Label lblAgreeError;
        private Label txtHobbies;
        private Label lblHobbiesError;
        private CheckedListBox lbHobbies;
        private MenuStrip menuStrip;
        private Label lblUserName;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem menuLogout;
        private TextBox txtSearch;
        private Label lblSearch;
    }
}
