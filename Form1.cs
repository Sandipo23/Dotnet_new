using System.Windows.Forms;

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
            txtFee.Text = StudentService._fee;
            txtFee.Enabled = false;
            rbMale.Checked = true;
            pbStudent.BorderStyle = BorderStyle.Fixed3D;
            pbStudent.SizeMode = PictureBoxSizeMode.StretchImage;  // adjust the size of the
            pbStudent.Load(@"D:\Project_Dotnet\pic1.jpg");
            txtImage.Enabled = false; // not be able to copy the text in the image box i.e read only
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
                StudentService studentService = new StudentService();
                Student student = new Student     //just property ma save garna lai object banako
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Gender = gender,
                    Agree = agree,
                    Course = course,
                    Profile = ""
                };
                studentService.Save(student);  // student ko info save gareko so that json ma save garauma
                MessageBox.Show("Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetControls();
            }
        }

        private void ResetControls()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            pbStudent.Image = null;
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

        private void btnUpload_Click(object sender, EventArgs e)    //this is the open dialog box created by drag and drop in the form
        {
            openFileDialog1.Filter = "Images |*.jpg;*.jpeg;*.png;"; // shows only jpg;*.jpeg;*.png files when uploading the image
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbStudent.Load(openFileDialog1.FileName);
                txtImage.Text = openFileDialog1.SafeFileName;// shows the image name in the txtImage box which is selected by the user
            }                                           // SafeFileName only gives the name of the selected image by the user
        }

        private void btnRemove_Click_1(object sender, EventArgs e)
        {
            pbStudent.Image = null;
            txtImage.Clear();
        }
    }
}