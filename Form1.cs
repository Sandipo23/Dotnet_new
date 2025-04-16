namespace WinFormsApp1
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
            InitializeFormComponent();

            LoadCourses();    // this is for array og course
        }

        private void InitializeFormComponent()
        {
            txtFee.ReadOnly = true;
            txtFee.Text = "35000";
            txtFee.Enabled = false;
            rbMale.Checked = true;
        }

        public void LoadCourses()

        {
            //1st syntax
            // Load from form properties

            // 2nd syntax
            //cmbCourse.Items.Add("Please select a course");
            //cmbCourse.Items.Add("BCA");
            //cmbCourse.Items.Add("BIT");
            //cmbCourse.Items.Add("BIM");
            //cmbCourse.Items.Add("BBS");
            //cmbCourse.Items.Add("BBA");

            var studentService = new StudentService();   // object of class StudentService is made
            string[] courses = studentService.GetAllCourses();  // the return in the class SrudentServide will return in GetAllCourses and stores the items in courses

            // 3rd syntax
            //for (int i = 0; i < courses.Length; i++)
            //{
            //    cmbCourse.Items.Add(courses[i]);
            //}

            // 4th syntax
            cmbCourse.Items.AddRange(courses);    // Addrange can take object of array

            cmbCourse.SelectedIndex = 0;  // selecting the index 0 i.e please select the course
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFirstName.Text.Trim()))   // this is for removing error message when user enters the box
            {
                lblFirstNameError.Visible = false;
            }
            SetFullName();
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtLastName.Text.Trim()))   // this is for removing error message when user enters the box
            {
                lblLastNameError.Visible = false;
            }

            SetFullName();
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
        }

        private void SetFullName()
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string fullName = firstName + " " + lastName;
            txtFullName.Text = fullName;
        }

        private void txtFee_TextChanged(object sender, EventArgs e)
        {
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (cmbCourse.SelectedIndex > 0)
            {
                lblCourseError.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            // ResetControls();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        private void Save()
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            bool gender = rbMale.Checked;
            string course = cmbCourse.Text;
            bool agree = chkAgree.Checked;

            if (String.IsNullOrEmpty(firstName))
            {
                lblFirstNameError.Visible = true;
            }
            else
            {
                lblFirstNameError.Visible = false;
            }

            if (String.IsNullOrEmpty(lastName))
            {
                lblLastNameError.Visible = true;
            }
            else
            {
                lblLastNameError.Visible = false;
            }

            if (cmbCourse.SelectedIndex == 0)
            {
                lblCourseError.Visible = true;
            }
            else
            {
                lblCourseError.Visible = false;
            }
            if (!agree)
            {
                lblAgreeError.Visible = true;
            }
            else
            {
                lblAgreeError.Visible = false;
            }

            if (!String.IsNullOrEmpty(firstName) && !String.IsNullOrEmpty(lastName) && cmbCourse.SelectedIndex > 0 && agree)
            {
                MessageBox.Show("Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetControls();
            }
        }

        private void ResetControls()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtFirstName.Focus();
        }

        //private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbCourse.SelectedIndex > 0)
        //    {
        //        lblCourseError.Visible = false;
        //    }
        //}

        private void lblFirstNameError_Click(object sender, EventArgs e)
        {
        }

        private void lblLastNameError_Click(object sender, EventArgs e)
        {
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
        }

        private void chkAgree_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAgree.Checked)   // this is for immediate click and error message hide
            {
                lblAgreeError.Visible = false;
            }
        }
    }
}