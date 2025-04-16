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
            label1 = new Label();
            lblGender = new Label();
            lblFee = new Label();
            lblFullName = new Label();
            lblLastNameError = new Label();
            label2 = new Label();
            lblFirstNameError = new Label();
            label5 = new Label();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // cmbCourse
            // 
            cmbCourse.FormattingEnabled = true;
            cmbCourse.Location = new Point(140, 182);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.Size = new Size(154, 23);
            cmbCourse.TabIndex = 2;
            cmbCourse.SelectedIndexChanged += cmbCourse_SelectedIndexChanged;
            // 
            // rbFemale
            // 
            rbFemale.AutoSize = true;
            rbFemale.Location = new Point(206, 151);
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
            rbMale.Location = new Point(137, 151);
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
            btnSave.Location = new Point(140, 229);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(126, 39);
            btnSave.TabIndex = 1015;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtFee
            // 
            txtFee.Location = new Point(137, 112);
            txtFee.Name = "txtFee";
            txtFee.ReadOnly = true;
            txtFee.Size = new Size(157, 23);
            txtFee.TabIndex = 1019;
            txtFee.TextChanged += txtFee_TextChanged;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(137, 83);
            txtFullName.Name = "txtFullName";
            txtFullName.ReadOnly = true;
            txtFullName.Size = new Size(157, 23);
            txtFullName.TabIndex = 1020;
            txtFullName.TextChanged += txtFullName_TextChanged;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(137, 54);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(157, 23);
            txtLastName.TabIndex = 1014;
            txtLastName.TextChanged += txtLastName_TextChanged;
            // 
            // txtFirstName
            // 
            txtFirstName.AccessibleName = "";
            txtFirstName.Location = new Point(137, 29);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(157, 23);
            txtFirstName.TabIndex = 1012;
            txtFirstName.TextChanged += txtFirstName_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(39, 181);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 1011;
            label1.Text = "Course";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 11F);
            lblGender.Location = new Point(39, 151);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(57, 20);
            lblGender.TabIndex = 1010;
            lblGender.Text = "Gender";
            // 
            // lblFee
            // 
            lblFee.AutoSize = true;
            lblFee.Font = new Font("Segoe UI", 11F);
            lblFee.Location = new Point(39, 119);
            lblFee.Name = "lblFee";
            lblFee.Size = new Size(87, 20);
            lblFee.TabIndex = 1009;
            lblFee.Text = "Student Fee";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 11F);
            lblFullName.Location = new Point(39, 87);
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
            lblLastNameError.Location = new Point(327, 57);
            lblLastNameError.Name = "lblLastNameError";
            lblLastNameError.Size = new Size(153, 20);
            lblLastNameError.TabIndex = 1007;
            lblLastNameError.Text = "Last Name is required";
            lblLastNameError.Visible = false;
            lblLastNameError.Click += lblLastNameError_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(39, 57);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 1006;
            label2.Text = "Last Name";
            // 
            // lblFirstNameError
            // 
            lblFirstNameError.AutoSize = true;
            lblFirstNameError.BackColor = SystemColors.Control;
            lblFirstNameError.Font = new Font("Segoe UI", 11F);
            lblFirstNameError.ForeColor = Color.Red;
            lblFirstNameError.Location = new Point(326, 32);
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
            label5.Location = new Point(39, 28);
            label5.Name = "label5";
            label5.Size = new Size(80, 20);
            label5.TabIndex = 1005;
            label5.Text = "First Name";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(285, 229);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(109, 39);
            btnCancel.TabIndex = 1023;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // StudentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(cmbCourse);
            Controls.Add(rbFemale);
            Controls.Add(rbMale);
            Controls.Add(btnSave);
            Controls.Add(txtFee);
            Controls.Add(txtFullName);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(label1);
            Controls.Add(lblGender);
            Controls.Add(lblFee);
            Controls.Add(lblFullName);
            Controls.Add(lblLastNameError);
            Controls.Add(label2);
            Controls.Add(lblFirstNameError);
            Controls.Add(label5);
            Name = "StudentForm";
            Text = "Student Form";
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
        private Label label1;
        private Label lblGender;
        private Label lblFee;
        private Label lblFullName;
        private Label lblLastNameError;
        private Label label2;
        private Label lblFirstNameError;
        private Label label5;
        private Button btnCancel;
    }
}
