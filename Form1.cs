namespace WinFormsApp1
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
            InitializeFormComponent();

            LoadCourses();
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

            cmbCourse.SelectedIndex = 0;
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            SetFullName();
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            ResetControls();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        private void Save()
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();

            if (String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("First name and last name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // call database()
                MessageBox.Show("Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ResetControls()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtFirstName.Focus();
        }

        private void lblFirstNameError_Click(object sender, EventArgs e)
        {
        }

        private void lblLastNameError_Click(object sender, EventArgs e)
        {
        }
    }
}