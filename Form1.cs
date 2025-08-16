using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class StudentForm : Form
    {
        private readonly StudentService _studentService;
        private string _uploadedFile;

        public StudentForm()
        {
            _studentService = new StudentService();
            InitializeComponent();
            InitializeFormComponent();

            LoadCourses();    // this is for array of course

            //LoadFormData();  // to show the data thst is saved in json file in our form
            LoadStudentsGrid();
            LoadHobbies();
        }

        private void LoadHobbies()
        {
            string[] hobbies = _studentService.GetAllHobbies();
            lbHobbies.Items.AddRange(hobbies);
        }

        private void LoadStudentsGrid()
        {
            dgvStudents.AutoGenerateColumns = false;
            dgvStudents.Columns.Add(new DataGridViewColumn   // it is for changing the name of the column
            {
                Name = nameof(StudentRead.FirstName),
                HeaderText = "First Name",                        // actual showing name in the grid
                CellTemplate = new DataGridViewTextBoxCell(),  //this makes checkboz to string
                DataPropertyName = nameof(StudentRead.FirstName)  // used for matching the column name with the data inserted
            });
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentRead.LastName),
                HeaderText = "Last Name",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(StudentRead.LastName)
            });
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentRead.Gender),
                HeaderText = "Gender",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(StudentRead.Gender)
            });
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentRead.Agree),
                HeaderText = "Agree",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(StudentRead.Agree)
            });
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentRead.Course),
                HeaderText = "Course",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(StudentRead.Course)
            });

            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentRead.DOB),
                HeaderText = "DOB",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(StudentRead.DOB)
            });
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentRead.Profile),
                HeaderText = "Profile",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(StudentRead.Profile)
            });
            LoadStudents();
        }

        private void LoadStudents()
        {
            var students = _studentService.GetAll();
            if (students.Count > 0)
            {
                dgvStudents.DataSource = students;
            }
        }

        //private void LoadFormData()
        //{
        //    var student = _studentService.Get();  // alredy save vayeko data student ko data variable student ma ayo
        //    if (student != null)
        //    {
        //        txtFirstName.Text = student.FirstName;
        //        txtLastName.Text = student.LastName;
        //        if (student.Gender)
        //        {
        //            rbMale.Checked = true;
        //        }
        //        else
        //        {
        //            rbFemale.Checked = true;
        //        }
        //        cmbCourse.Text = student.Course;
        //        chkAgree.Checked = student.Agree;
        //        if (!String.IsNullOrEmpty(student.Profile) && File.Exists(student.Profile))  //if file xa vane matra loade garne image
        //        {
        //            txtImage.Text = Path.GetFileName(student.Profile);
        //            pbStudent.Load(Path.Combine(_studentService._folderLocation, student.Profile));
        //        }
        //    }
        //}

        private void InitializeFormComponent()
        {
            txtFee.ReadOnly = true;
            txtFee.Text = Constants.Fee;
            txtFee.Enabled = false;
            rbMale.Checked = true;
            pbStudent.BorderStyle = BorderStyle.Fixed3D;
            pbStudent.SizeMode = PictureBoxSizeMode.StretchImage;  // adjust the size of the
                                                                   // pbStudent.Load(@"D:\Project_Dotnet\pic1.jpg");
            txtImage.Enabled = false; // not be able to copy the text in the image box i.e read only
            dtpDOB.Format = DateTimePickerFormat.Custom;
            dtpDOB.CustomFormat = " ";  // suru ma empty date dekhauxa
            //lbHobbies.SelectionMode = SelectionMode.MultiSimple;  // thic code is for listbox not checked listbox
            lbHobbies.CheckOnClick = true;
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

            // var studentService = new StudentService();   // object of class StudentService is made
            string[] courses = _studentService.GetAllCourses();  // the return in the class SrudentServide will return in GetAllCourses and stores the items in courses

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
            string dob = dtpDOB.Text.Trim();
            //string[] hobbies = lbHobbies.SelectedItems.Cast<string>().ToArray();  this is for listbox
            string[] hobbies = lbHobbies.CheckedItems.Cast<string>().ToArray();  // this is for checked list box - gives the data that user clicked

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

            if (String.IsNullOrEmpty(dob))
            {
                lblDOBError.Visible = true;
            }
            else
            {
                lblDOBError.Visible = false;
            }

            if (hobbies.Length <= 0)
            {
                lblHobbiesError.Visible = true;
            }
            else
            {
                lblHobbiesError.Visible = false;
            }
            //string imagePath = Path.Combine(_studentService._folderLocation, txtImage.Text);  // to store and retreive the image path
            string imagePath = String.IsNullOrEmpty(txtImage.Text) ? null : Path.Combine(_studentService._folderLocation, txtImage.Text);
            if (!String.IsNullOrEmpty(firstName) && !String.IsNullOrEmpty(lastName) && cmbCourse.SelectedIndex > 0 && agree && !String.IsNullOrEmpty(dob) && hobbies.Length > 0)
            {
                //StudentService studentService = new StudentService();
                Student student = new Student     //just property ma save garna lai object banako
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Gender = gender,
                    Agree = agree,
                    Course = course,
                    DOB = dtpDOB.Value,
                    Profile = imagePath,
                    Hobbies = hobbies
                };
                _studentService.Save(student);  // student ko info save gareko so that json ma save garauma
                if (!String.IsNullOrEmpty(_uploadedFile) && !String.IsNullOrEmpty(txtImage.Text))
                {
                    _studentService.SaveImage(_uploadedFile, imagePath);
                }
                LoadStudents();
                MessageBox.Show("Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetControls();
            }
        }

        private void ResetControls()
        {
            txtFirstName.Clear();
            txtLastName.Clear();

            cmbCourse.SelectedIndex = 0;
            chkAgree.Checked = false;
            rbMale.Checked = true;
            RemoveImage();
            _uploadedFile = "";
            dtpDOB.CustomFormat = " ";
            // lbHobbies.SelectedItems.Clear();
            for (int i = 0; i < lbHobbies.Items.Count; i++)
            {
                lbHobbies.SetItemChecked(i, false);
            }
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
                // pbStudent.Load(openFileDialog1.FileName);
                _uploadedFile = openFileDialog1.FileName;
                pbStudent.Load(_uploadedFile);
                txtImage.Text = openFileDialog1.SafeFileName;// shows the image name in the txtImage box which is selected by the user
            }                                           // SafeFileName only gives the name of the selected image by the user
        }

        private void btnRemove_Click_1(object sender, EventArgs e)
        {
            RemoveImage();
        }

        private void RemoveImage()
        {
            pbStudent.Image = null;
            txtImage.Clear();
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            dtpDOB.CustomFormat = Constants.Format;
            lblDOBError.Visible = false;
        }

        private void lbHobbies_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void lbHobbies_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            lbHobbies.ClearSelected();
            if (lbHobbies.CheckedItems.Count > 0)
            {
                lblHobbiesError.Visible = false;
            }
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}