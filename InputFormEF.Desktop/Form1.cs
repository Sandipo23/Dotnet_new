using InputFormEF.BAL;
using InputFormEF.BAL.AppliationConstant;
using InputFormEF.BAL.Interfaces;
using InputFormEF.DAL;

using InputFormEF.DAL.Entities;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading.Tasks;

using InputFormEF.BAL.Dto;
using InputFormEF.BAL.Enums;
using InputFormEF.Desktop.Utilities;

namespace WinFormsApp1
{
    public partial class StudentForm : Form
    {
        //private readonly StudentService _studentService;
        private readonly IStudentReadService _studentReadService;

        private readonly IStudentWriteService _studentWriteService;
        private string _uploadedFile;
        private int _studentId = 0;
        private string _userName;
        private List<StudentReadDto> _students = new List<StudentReadDto>();

        public StudentForm(IStudentReadService studentReadRepository, IStudentWriteService studentWriteRepository)
        {
            _studentReadService = studentReadRepository;
            _studentWriteService = studentWriteRepository;
            InitializeComponent();
            InitializeFormComponent();
        }

        public void SetUserName(string userName)
        {
            _userName = userName;
            lblUserName.Text = $"Welcome, {_userName}";
        }

        private async Task LoadHobbiesAsync()
        {
            var hobbies = await _studentReadService.GetAllHobbiesAsync();
            lbHobbies.DataSource = hobbies;
            lbHobbies.DisplayMember = nameof(Course.Name);
            lbHobbies.ValueMember = nameof(Course.Id);
            //   lbHobbies.Items.AddRange(hobbies);   this is previous code loading from hobbies list
        }

        private async Task LoadStudentsGridAsync()
        {
            dgvStudents.AutoGenerateColumns = false;
            dgvStudents.Columns.Add(new DataGridViewColumn

            // it is for changing the name of the column
            {
                Name = nameof(StudentReadDto.Id),
                HeaderText = "Id",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(StudentReadDto.Id)
            });
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentReadDto.FirstName),
                HeaderText = "First Name",                        // actual showing name in the grid
                CellTemplate = new DataGridViewTextBoxCell(),  //this makes checkboz to string
                DataPropertyName = nameof(StudentReadDto.FirstName)  // used for matching the column name with the data inserted
            });
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentReadDto.LastName),
                HeaderText = "Last Name",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(StudentReadDto.LastName)
            });
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentReadDto.Gender),
                HeaderText = "Gender",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(StudentReadDto.Gender)
            });
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentReadDto.Agree),
                HeaderText = "Agree",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(StudentReadDto.Agree)
            });
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentReadDto.Course),
                HeaderText = "Course",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(StudentReadDto.Course)
            });

            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentReadDto.DOB),
                HeaderText = "DOB",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(StudentReadDto.DOB)
            });
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentReadDto.Profile),
                HeaderText = "Profile",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(StudentReadDto.Profile)
            });
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentReadDto.CreatedDate),
                HeaderText = "Created Date",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(StudentReadDto.CreatedDate)
            });
            await LoadStudentsAsync();
        }

        private async Task LoadStudentsAsync()
        {
            //var students = _studentService.GetAll();
            //if (students.Count > 0)
            //{
            //    dgvStudents.DataSource = students;
            //}
            _students = await _studentReadService.GetAllAsync();
            if (_students.Count > 0)
            {
                dgvStudents.DataSource = _students;
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

        public async Task LoadCoursesAsync()

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
            var courses = await _studentReadService.GetAllCoursesAsync();  // the return in the class StudentServide will return in GetAllCourses and stores the items in courses

            courses.Insert(0, new Course
            {
                Id = 0,
                Name = "Please select a course"
            });
            cmbCourse.DataSource = courses;
            cmbCourse.DisplayMember = nameof(Course.Name);
            cmbCourse.ValueMember = nameof(Course.Id);
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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await SaveUpdateAsync();
            // ResetControls();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        private async Task SaveUpdateAsync()
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            bool gender = rbMale.Checked;

            //string course = cmbCourse.Text;
            int courseId = (int)cmbCourse.SelectedValue;
            bool agree = chkAgree.Checked;
            string dob = dtpDOB.Text.Trim();
            //string[] hobbies = lbHobbies.SelectedItems.Cast<string>().ToArray();  this is for listbox
            //string[] hobbies = lbHobbies.CheckedItems.Cast<string>().ToArray();  // this is for checked list box - gives the data that user clicked

            var hobbyIds = lbHobbies
                         .CheckedItems
                         .Cast<Hobby>()
                          .Select(x => x.Id)
                         .ToList();

            //  string hobbyIds = String.Join(",", hobbies);

            //string imagePath = Path.Combine(_studentService._folderLocation, txtImage.Text);  // to store and retreive the image path
            string imagePath = String.IsNullOrEmpty(txtImage.Text) ? null : Path.Combine(_studentReadService.FilePath, txtImage.Text);

            if (_studentId > 0)
            {
                await UpdateAsync(firstName, lastName, gender, courseId, agree, dob, hobbyIds, imagePath);
            }
            else
            {
                await SaveAsync(firstName, lastName, gender, courseId, agree, dob, hobbyIds, imagePath);
            }
        }

        private async Task SaveAsync(string firstName, string lastName, bool gender, int courseId, bool agree, string dob, List<int> hobbyIds, string imagePath)
        {
            {
                //StudentService studentService = new StudentService();
                var student = new StudentCreateDto     //just property ma save garna lai object banako
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Gender = gender,
                    Agree = agree,
                    CourseId = courseId,
                    DOB = String.IsNullOrEmpty(dob) ? null : dtpDOB.Value,
                    Profile = imagePath,
                    HobbyIds = hobbyIds
                };

                var result = await _studentWriteService.SaveAsync(student);
                await HandleResultAsync(imagePath, result);
            }
        }

        private async Task HandleResultAsync(string imagePath, OutputDto result)
        {
            if (result.Status == Status.Success)
            {
                await OnSuccessAsync(result.Message, imagePath);
            }
            else
            {
                DialogBox.FailureAlert(result);
                txtFirstName.Focus();
            }
        }

        private async Task UpdateAsync(string firstName, string lastName, bool gender, int courseId, bool agree, string dob, List<int> hobbyIds, string imagePath)
        {
            var student = new StudentUpdateDto
            {
                Id = _studentId,
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                Agree = agree,
                CourseId = courseId,
                DOB = String.IsNullOrEmpty(dob) ? null : dtpDOB.Value,
                Profile = imagePath,
                HobbyIds = hobbyIds
            };
            var result = await _studentWriteService.UpdateAsync(student);
            await HandleResultAsync(imagePath, result);
        }

        private async Task OnSuccessAsync(string message, string imagePath)
        {
            var request = new SaveImageRequest
            {
                Source = _uploadedFile,
                Destination = imagePath
            };
            // if (!String.IsNullOrEmpty(_uploadedFile) && !String.IsNullOrEmpty(txtImage.Text))// == this is alredy donr in bal so not necessary
            //   {
            //      _studentWriteService.SaveImageAsync(_uploadedFile, imagePath);
            //  }
            var result = await _studentWriteService.SaveImageAsync(request);

            await LoadStudentsAsync();
            DialogBox.SuccessAlert(message);
            ResetControls();
            if (result.Status == Status.Failed)
            {
                DialogBox.FailureAlert(result);
            }
        }

        private void ResetControls()
        {
            btnSave.Enabled = true;
            txtFirstName.Clear();
            txtLastName.Clear();

            cmbCourse.SelectedIndex = 0;
            chkAgree.Checked = false;
            rbMale.Checked = true;
            RemoveImage();
            _uploadedFile = "";
            dtpDOB.CustomFormat = " ";

            // lbHobbies.SelectedItems.Clear();
            _studentId = 0;
            ResetHobbies();
            txtFirstName.Focus();
        }

        private void ResetHobbies()
        {
            for (int i = 0; i < lbHobbies.Items.Count; i++)
            {
                lbHobbies.SetItemChecked(i, false);
            }
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            if (String.IsNullOrEmpty(search))
            {
                dgvStudents.DataSource = _students;
                return;
            }

            var filtered = _students
                           .Where(x => x.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase))
                           .ToList();
            dgvStudents.DataSource = filtered;
        }

        private async void StudentForm_Load(object sender, EventArgs e)
        {
            await LoadCoursesAsync();    // this is for array of course

            //LoadFormData();  // to show the data thst is saved in json file in our form

            await LoadHobbiesAsync();
            await LoadStudentsGridAsync();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            if (_studentId > 0)
            {
                // Update
                await SaveUpdateAsync();
            }
            else
            {
                MessageBox.Show("Please select a student to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetControls();
            }
        }

        private async void btnDelete_ClickAsync(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            if (_studentId > 0)
            {
                // Delete
                await _studentWriteService.DeleteAsync(_studentId);
                await LoadStudentsAsync();
                MessageBox.Show("Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a student to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ResetControls();
        }

        private async void dgvStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;
            // button1.Enabled = false;
            button2.Enabled = false;
            _studentId = (int)dgvStudents.CurrentRow.Cells[nameof(StudentReadDto.Id)].Value;
            if (_studentId > 0)
            {
                btnSave.Enabled = false;
                //  button1.Enabled = false;
                button2.Enabled = false;
                var student = await _studentReadService.GetByIdAsync(_studentId);
                if (student != null)
                {
                    btnSave.Enabled = false;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    txtFirstName.Text = student.FirstName;
                    txtLastName.Text = student.LastName;
                    if (student.Gender)
                    {
                        rbMale.Checked = true;
                    }
                    else
                    {
                        rbFemale.Checked = true;
                    }

                    cmbCourse.Text = student.Course.Name;
                    dtpDOB.CustomFormat = Constants.Format;
                    dtpDOB.Value = student.DOB;
                    ResetHobbies();
                    for (int i = 0; i < student.StudentHobbies.Count; i++)
                    {
                        int hobbyId = student.StudentHobbies[i].HobbyId;
                        var hobby = lbHobbies
                                   .Items
                                   .Cast<Hobby>()
                                   .FirstOrDefault(x => x.Id == hobbyId);
                        int index = lbHobbies.Items.IndexOf(hobby);
                        lbHobbies.SetItemChecked(index, true);
                    }
                    chkAgree.Checked = student.Agree;
                }
                txtFirstName.Focus();
            }
        }
    }
}