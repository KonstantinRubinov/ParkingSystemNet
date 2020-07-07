using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ParkingSystem
{
	public partial class FrmParkingProject : Form
    {
		private static string mainUrl= "http://localhost:53114/api/";
		private static string searchUrl = mainUrl + "personsByString/";

		bool test = false;



		static string strExe = Application.StartupPath;

		IStudentRepository studentRepository;
		ITeacherRepository teacherRepository;
		IPersonRepository personRepository;
		IFacultyRepository facultyRepository;
		IVehicleRepository vehicleRepository;
		IApprovalTypesRepository approvalTypeRepository;
		IApprovalRepository approvalRepository;
		ICourseRepository courseRepository;
		IThreeObjectsRepository threeObjectsRepository;

		

		private void InitilizeLogicsInner()
		{
			studentRepository = new InnerStudentManager(strExe);
			teacherRepository = new InnerTeacherManager(strExe);
			personRepository = new InnerPersonManager(strExe);
			facultyRepository = new InnerFacultyManager(strExe);
			vehicleRepository = new InnerVehicleManager(strExe);
			approvalTypeRepository = new InnerApprovalTypeManager(strExe);
			approvalRepository = new InnerApprovalManager(strExe);
			courseRepository = new InnerCourseManager(strExe);
			threeObjectsRepository = new InnerThreeObjectsManager(strExe);
		}

		private void InitilizeLogicsEntity()
		{
			studentRepository = new EntityStudentManager();
			teacherRepository = new EntityTeacherManager();
			personRepository = new EntityPersonManager();
			facultyRepository = new EntityFacultyManager();
			vehicleRepository = new EntityVehicleManager();
			approvalTypeRepository = new EntityApprovalTypeManager();
			approvalRepository = new EntityApprovalManager();
			courseRepository = new EntityCourseManager();
			threeObjectsRepository = new EntityThreeObjectsManager();
		}

		private void InitilizeLogicsSql()
		{
			studentRepository = new SqlStudentManager();
			teacherRepository = new SqlTeacherManager();
			personRepository = new SqlPersonManager();
			facultyRepository = new SqlFacultyManager();
			vehicleRepository = new SqlVehicleManager();
			approvalTypeRepository = new SqlApprovalTypeManager();
			approvalRepository = new SqlApprovalManager();
			courseRepository = new SqlCourseManager();
			threeObjectsRepository = new SqlThreeObjectsManager();
		}

		private void InitilizeLogicsMySql()
		{
			studentRepository = new MySqlStudentManager();
			teacherRepository = new MySqlTeacherManager();
			personRepository = new MySqlPersonManager();
			facultyRepository = new MySqlFacultyManager();
			vehicleRepository = new MySqlVehicleManager();
			approvalTypeRepository = new MySqlApprovalTypeManager();
			approvalRepository = new MySqlApprovalManager();
			courseRepository = new MySqlCourseManager();
			threeObjectsRepository = new MySqlThreeObjectsManager();
		}

        private void InitilizeLogicsMongo()
        {
            studentRepository = new MongoStudentManager();
            teacherRepository = new MongoTeacherManager();
            personRepository = new MongoPersonManager();
            facultyRepository = new MongoFacultyManager();
            vehicleRepository = new MongoVehicleManager();
            approvalTypeRepository = new MongoApprovalTypeManager();
            approvalRepository = new MongoApprovalManager();
            courseRepository = new MongoCourseManager();
            threeObjectsRepository = new MongoThreeObjectsManager();
        }



        int rdoYear = 0; // variable year type
        int StudyType = 0; // variable "type of studies" type
        int dataInsertError = 0; // flag to check if all data inserted
        //int choiseIndex=-1;

        List<PersonModel> idPerson; // person id array
		//List<PersonModel> dataPerson; // all person array
		List<TeacherModel> dataTeacher; // all teacher data array
		List<StudentModel> dataStudent; // all student data array

		List<VehicleModel> allVehicle; // vehicle data array

		List<FacultyModel> allFaculties; // faculties data array
		List<CourseModel> allCourses; // courses data array

		List<ApprovalModel> allApproval; // all approval data array
		List<ApprovalTypeModel> allApprovalTypes; // all approval data array

		List<ThreeObjectsModel> allThreeObjects; // all approval data array

		public FrmParkingProject()
        {
            InitializeComponent();
            this.Width = grStudent.Width + btnAddDetails.Width+50; //save form width
            this.Height = grStudent.Height+60; // save form height

			if (GlobalVariable.logicType == 0)
				InitilizeLogicsEntity();
			else if (GlobalVariable.logicType == 1)
				InitilizeLogicsSql();
			else if (GlobalVariable.logicType == 2)
				InitilizeLogicsMySql();
			else if (GlobalVariable.logicType == 3)
                InitilizeLogicsInner();
            else
                InitilizeLogicsMongo();



            if (test == true)
			{
				//dataPersonId = "311078026";
				dataPersonFamily = "Rubinov";
				dataPersonName = "Konstantin";
				dataPersonBeforeTelephone = "08";
				dataPersonTelephone = "6570903";
				dataPersonBeforeCellphone = "0544";
				dataPersonCellphone = "538421";
				dataPersonCode = 1;
				dataStudentYear = 1;
				dataStudentType = 1;
			}
		}

		

		private void FrmParkingProject_Resize(object sender, EventArgs e)
        {
            this.Width = grStudent.Width + btnAddDetails.Width + 50; //save form width
            this.Height = grStudent.Height + 60; // save form height
        }

		//---------------------------------DataProperties-----------------------------
		public string dataPersonId
		{
			get { return this.cmbIdNumber.Text; }
			set { this.cmbIdNumber.Text = value; }
		}

		public string dataPersonFamily
		{
			get { return this.txtFamilyName.Text; }
			set { this.txtFamilyName.Text = value; }
		}

		public string dataPersonName
		{
			get { return this.txtFirstName.Text; }
			set { this.txtFirstName.Text = value; }
		}

		public string dataPersonBeforeTelephone
		{
			get { return this.CmbTelephone.Text; }
			set { this.CmbTelephone.Text = value; }
		}

		public string dataPersonTelephone
		{
			get { return this.TxtTelephone.Text; }
			set { this.TxtTelephone.Text = value; }
		}


		public string dataPersonBeforeCellphone
		{
			get { return this.CmbTelephone2.Text; }
			set { this.CmbTelephone2.Text = value; }
		}

		public string dataPersonCellphone
		{
			get { return this.TxtTelephone2.Text; }
			set { this.TxtTelephone2.Text = value; }
		}

		public int dataPersonCode
		{
			get
			{
				if (this.rdoStudent.Checked)
				{
					dataIsStudent = true;
					dataIsTeacher = false;
					return 1;
				}

				else if (this.rdoTeacher.Checked)
				{
					dataIsTeacher = true;
					dataIsStudent = false;
					return 2;
				}

				else
				{
					dataIsStudent = false;
					dataIsTeacher = false;
					return 0;
				}

			}
			set
			{
				if (value == 1)
				{
					this.rdoStudent.Checked = true;
					this.rdoTeacher.Checked = false;
					dataIsStudent = true;
					dataIsTeacher = false;
				}
					
				else if (value == 2)
				{
					this.rdoStudent.Checked = false;
					this.rdoTeacher.Checked = true;
					dataIsStudent = false;
					dataIsTeacher = true;
				}
					
				else
				{
					this.rdoStudent.Checked = false;
					this.rdoTeacher.Checked = false;
					dataIsStudent = false;
					dataIsTeacher = false;
				}
			}
		}


		public int dataStudentYear
		{
			get
			{
				if (this.rdoYear1.Checked)
					return 1;
				else if (this.rdoYear2.Checked)
					return 2;
				else if (this.rdoYear3.Checked)
					return 3;
				else return 0;
			}
			set
			{
				if (value == 1)
					this.rdoYear1.Checked = true;
				else if (value == 2)
					this.rdoYear2.Checked = true;
				else if (value == 3)
					this.rdoYear3.Checked = true;
				else
				{
					this.rdoYear1.Checked = false;
					this.rdoYear2.Checked = false;
					this.rdoYear3.Checked = false;
				}
			}
		}


		public int dataStudentType
		{
			get
			{
				if (this.rdoStudyType1.Checked)
				{
					CmbFaculty.Enabled = true;
					CmbHeadOfFaculty.Enabled = true;
					cmbCourse.Enabled = false;
					return 1;
				}

				else if (this.rdoStudyType2.Checked)
				{
					CmbFaculty.Enabled = true;
					CmbHeadOfFaculty.Enabled = true;
					cmbCourse.Enabled = false;
					return 2;
				}

				else if (this.rdoStudyType3.Checked)
				{
					CmbFaculty.Enabled = false;
					CmbHeadOfFaculty.Enabled = false;
					cmbCourse.Enabled = true;
					return 3;
				}

				else return 0;
			}
			set
			{
				if (value == 1)
				{
					this.rdoStudyType1.Checked = true;
					CmbFaculty.Enabled = true;
					CmbHeadOfFaculty.Enabled = true;
					cmbCourse.Enabled = false;
				}
				else if (value == 2)
				{
					this.rdoStudyType2.Checked = true;
					CmbFaculty.Enabled = true;
					CmbHeadOfFaculty.Enabled = true;
					cmbCourse.Enabled = false;
				}
					
				else if (value == 3)
				{
					this.rdoStudyType3.Checked = true;
					CmbFaculty.Enabled = false;
					CmbHeadOfFaculty.Enabled = false;
					cmbCourse.Enabled = true;
				}
					
				else
				{
					this.rdoStudyType1.Checked = false;
					this.rdoStudyType2.Checked = false;
					this.rdoStudyType3.Checked = false;
					CmbFaculty.Enabled = false;
					CmbHeadOfFaculty.Enabled = false;
					cmbCourse.Enabled = false;
				}
			}
		}

		public string dataStudentFaculty
		{
			get { return this.CmbFaculty.Text; }
			set { this.CmbFaculty.Text = value; }
		}

		public string dataStudentHeadOfFaculty
		{
			get { return this.CmbHeadOfFaculty.Text; }
			set { this.CmbHeadOfFaculty.Text = value; }
		}

		public string dataTeacherCodeOfFaculty
		{
			get { return this.CmbCodeOfFaculty.Text; }
			set { this.CmbCodeOfFaculty.Text = value; }
		}

		public bool dataIsStudent
		{
			get { return this.grStudentPersonal.Enabled; }
			set { this.grStudentPersonal.Enabled = value; }
		}

		public bool dataIsTeacher
		{
			get { return this.grTeacherPersonal.Enabled; }
			set { this.grTeacherPersonal.Enabled = value; }
		}

		public string dataVehicleNumber
		{
			get { return this.txtLessenNumber.Text; }
			set { this.txtLessenNumber.Text = value; }
		}

		public string dataVehicleManufacturer
		{
			get { return this.txtCarCreator.Text; }
			set { this.txtCarCreator.Text = value; }
		}

		public string dataVehicleColor
		{
			get { return this.txtCarColor.Text; }
			set { this.txtCarColor.Text = value; }
		}

		public string dataVehicleOwnerId
		{
			get { return this.cmbIdNumber.Text; }
			set { this.cmbIdNumber.Text = value; }
		}

		public string dataVehicleOwnerName
		{
			get { return this.txtCarOwner.Text; }
			set { this.txtCarOwner.Text = value; }
		}

		public string dataApprovalCode
		{
			get { return this.cmbCodeOfApproval.Text; }
			set { this.cmbCodeOfApproval.Text = value; }
		}

		public string dataApprovalType
		{
			get { return this.cmbTypeOfApproval.Text; }
			set { this.cmbTypeOfApproval.Text = value; }
		}
		public DateTime dataApprovalFrom
		{
			get { return this.dateFrom.Value; }
			set { this.dateFrom.Value = value; }
		}
		public DateTime dataApprovalUntil
		{
			get { return this.dateUntil.Value; }
			set { this.dateUntil.Value = value; }
		}
		public string dataApprovalPersonId
		{
			get { return this.txtCarOwner.Text; }
			set { this.txtCarOwner.Text = value; }
		}
		public int dataApprovalNumber { get; set; }


		private void openDataWindow()
		{
			btnAddDetails.Enabled = false; // disable this button
			btnManageFacult.Enabled = true; // enable this button
			btnManageParkLabel.Enabled = true; // enable this button
			btnDetails.Enabled = true; // enable this button
			btnReport.Enabled = true; // enable this button
			btnManageCourse.Enabled = true; // enable this button

			this.Controls.Remove(this.grFacultManage); // do not show this group
			this.Controls.Add(this.grStudent); // show this group
			this.Controls.Remove(this.grLabelTypes); // do not show this group
			this.Controls.Remove(this.grCourses); // do not show this group
			this.Controls.Remove(this.grSearch); // do not show this group
			this.Controls.Remove(this.grPdf); // do not show this group
		}

		//---------------------------------LoadDataBase----------------------------------------
		//public void LoadDataBase()
		//{
		//	idPerson = personLogic.GetAllPersonsId(); // get person ids
		//	dataPerson = personLogic.GetAllPersons(); // get Person data
		//	dataStudent = studentLogic.GetAllStudents(); // get student data
		//	dataTeacher = teacherLogic.GetAllTeachers(); // get teacher data
		//	allFaculties = facultyLogic.GetAllFaculties(); // get faculty data
		//	allVehicle = vehicleLogic.GetAllVehicles(); // get vehicle data
		//	allApprovalTypes = approvalTypeLogic.GetAllApprovalTypes(); // all approvalTypes data array
		//	allApproval = approvalLogic.GetAllApprovals(); // all approval data array
		//	allCourses = courseLogic.GetAllCourses(); // get course data
		//	allThreeObjects = threeObjectsLogic.GetAllThreeObjects(); // get ThreeObjects data
		//}

		public void LoadAllIdFacultyCourseVehicleApprovalThree()
		{
			idPerson = personRepository.GetAllPersonsId();
			allFaculties = facultyRepository.GetAllFaculties();
			allCourses = courseRepository.GetAllCourses();
			allVehicle = vehicleRepository.GetAllVehicles();
			allApprovalTypes = approvalTypeRepository.GetAllApprovalTypes();
			allThreeObjects = threeObjectsRepository.GetAllThreeObjects();
		}

		public void LoadAllApprovalStudentCourseFaculty()
		{
			allApprovalTypes = approvalTypeRepository.GetAllApprovalTypes(); // all approvalTypes data array
			allApproval = approvalRepository.GetAllApprovals(); // all approval data array
			dataStudent = studentRepository.GetAllStudents(); // get student data
			allFaculties = facultyRepository.GetAllFaculties(); // get faculty data
			allCourses = courseRepository.GetAllCourses(); // get course data
		}

		public void LoadAllFacultyStudentTeacherVehicle()
		{
			dataStudent = studentRepository.GetAllStudents(); // get student data
			dataTeacher = teacherRepository.GetAllTeachers(); // get teacher data
			allFaculties = facultyRepository.GetAllFaculties(); // get faculty data
			allVehicle = vehicleRepository.GetAllVehicles(); // get vehicle data
		}


		public void LoadAllPersonCourseVehicleApproval()
		{
			dataStudent = studentRepository.GetAllStudents();
			dataTeacher = teacherRepository.GetAllTeachers();
			allVehicle = vehicleRepository.GetAllVehicles();
			allCourses = courseRepository.GetAllCourses();
			allApproval = approvalRepository.GetAllApprovals();
		}

		//---------------------------------clearForm-----------------------------
		public void clearForm()
        {
			dataPersonId = "";
			dataPersonFamily = "";
			dataPersonName = "";
			dataPersonBeforeTelephone = "";
			dataPersonTelephone = "";
			dataPersonBeforeCellphone = "";
			dataPersonCellphone = "";

			dataPersonCode = 0;

			dataStudentYear = 0;
			dataStudentType = 0;

			dataStudentFaculty = "";
			dataStudentHeadOfFaculty = "";

			dataTeacherCodeOfFaculty = "";

			dataVehicleNumber = "";
			dataVehicleManufacturer = "";
			dataVehicleColor = "";
			dataVehicleOwnerName = "";

			DateTime thisDate1 = new DateTime(2000, 1, 1);

			dataApprovalFrom = thisDate1;
			dataApprovalUntil = thisDate1;
			dataApprovalType = "";
			dataApprovalCode = "";
		}

        

        //----------------------------------Parking Project Load-------------------------------------
        private void FrmParkingProject_Load(object sender, EventArgs e)
        {
            addMainDetails();
        }

        //----------------------------------If - Add Details---------------------------------------
        private void btnAddDetails_Click(object sender, EventArgs e)
        {
            addMainDetails();
        }

        //----------------------------------Add Details to "add person" form---------------------------------------
        void addMainDetails()
        {
			cmbIdNumber.Items.Clear();
			CmbFaculty.Items.Clear();
			CmbHeadOfFaculty.Items.Clear();
			CmbCodeOfFaculty.Items.Clear();
			cmbCourse.Items.Clear();
			cmbTypeOfApproval.Items.Clear();
			cmbCodeOfApproval.Items.Clear();

			dataIsStudent = false;
			dataIsTeacher = false;

			openDataWindow();

			LoadAllIdFacultyCourseVehicleApprovalThree();

			for (int i = 0; i < idPerson.Count; i++) // show the id numbers starts with entered digits
            {
                if (idPerson[i].personId.StartsWith(dataPersonId))
                    cmbIdNumber.Items.Add(idPerson[i].personId);
            }

			//-----------------------------------------insert all faculty data into combobox--------------------------
			for (int i = 0; i < allFaculties.Count; i++)
            {
                CmbFaculty.Items.Add(allFaculties[i].facultyName);
                CmbHeadOfFaculty.Items.Add(allFaculties[i].facultyHead);
                CmbCodeOfFaculty.Items.Add(allFaculties[i].facultyCode);
            }

			//-----------------------------------------insert all course data into combobox--------------------------
			for (int i = 0; i < allCourses.Count; i++)
            {
                cmbCourse.Items.Add(allCourses[i].courseName);
            }

			//-----------------------------------------insert all vehicle data into combobox--------------------------
			for (int i = 0; i < allVehicle.Count; i++)
            {
                cmbLessence.Items.Add(allVehicle[i].vehicleNumber);
            }

			//-----------------------------------------insert all approval data into combobox--------------------------
			for (int i = 0; i < allApprovalTypes.Count; i++)
            {
                cmbLabel.Items.Add(allApprovalTypes[i].approvalName);
				cmbTypeOfApproval.Items.Add(allApprovalTypes[i].approvalName);
				cmbCodeOfApproval.Items.Add(allApprovalTypes[i].approvalCode);
				cmbLabelType.Items.Add(allApprovalTypes[i].approvalName);
				cmbLabelCode.Items.Add(allApprovalTypes[i].approvalCode);
			}
        }

        //-----------------------------------------if the person is student--------------------------
        private void rdoStudent_CheckedChanged(object sender, EventArgs e)
        {
			if (rdoStudent.Checked == true)
				dataPersonCode =1;
        }

        //-----------------------------------------if the person is teacher--------------------------
        private void rdoTeacher_CheckedChanged(object sender, EventArgs e)
        {
			if (rdoTeacher.Checked == true)
				dataPersonCode = 2;
		}

        //-----------------------------------------if the student year is 1--------------------------
        private void rdoYear1_CheckedChanged(object sender, EventArgs e)
        {
			rdoYear = dataStudentYear; // if year radio is 1, the same variable is 1
        }

        //-----------------------------------------if the student year is 2--------------------------
        private void rdoYear2_CheckedChanged(object sender, EventArgs e)
        {
			rdoYear = dataStudentYear; // if year radio is 2, the same variable is 2
		}

        //-----------------------------------------if the student year is 3--------------------------
        private void rdoYear3_CheckedChanged(object sender, EventArgs e)
        {
			rdoYear = dataStudentYear; // if year radio is 3, the same variable is 3
		}

        //-----------------------------------------if the student type is morning--------------------------
        private void rdoStudyType1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoStudyType1.Checked == true)
            {
				dataStudentType = 1;
				StudyType = 1;
            }
        }

        //-----------------------------------------if the student type is evening--------------------------
        private void rdoStudyType2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoStudyType2.Checked == true)
            {
				dataStudentType = 2;
				StudyType = 2;
            }
        }

        //-----------------------------------------if the student type is course--------------------------
        private void rdoStudyType3_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoStudyType3.Checked == true)
            {
				dataStudentType = 3;
				StudyType = 3;
            }
        }

        //----------------------------------Add Details to "Faculty" form---------------------------------------
        private void btnManageFacult_Click(object sender, EventArgs e)
        {
            while (cmbFaclName.Items.Count > 0) // clear items in cmbIdNumber
            {
                cmbFaclName.Items.RemoveAt(0);
            }

            while (cmbFaclCode.Items.Count > 0) // clear items in cmbIdNumber
            {
                cmbFaclCode.Items.RemoveAt(0);
            }

            while (cmbFaclHead.Items.Count > 0) // clear items in cmbIdNumber
            {
                cmbFaclHead.Items.RemoveAt(0);
            }

            btnAddDetails.Enabled = true; // enable this button
            btnManageFacult.Enabled = false; // disable this button
            btnManageParkLabel.Enabled = true; // enable this button
            btnDetails.Enabled = true; // enable this button
            btnReport.Enabled = true; // enable this button
            btnManageCourse.Enabled = true; // enable this button

            this.Controls.Remove(this.grStudent); // do not show this group
            this.Controls.Add(this.grFacultManage); // show this group
            this.Controls.Remove(this.grLabelTypes); // do not show this group
            this.Controls.Remove(this.grCourses); // do not show this group
            this.Controls.Remove(this.grSearch); // do not show this group
            this.Controls.Remove(this.grPdf); // do not show this group

            for (int i = 0; i < allFaculties.Count; i++) // add faculty data into comboboxes
            {
                cmbFaclName.Items.Add(allFaculties[i].facultyName);
                cmbFaclCode.Items.Add(allFaculties[i].facultyCode);
                cmbFaclHead.Items.Add(allFaculties[i].facultyHead);
            }
        }

        //----------------------------------Add Details to "approval" form---------------------------------------
        private void btnManageParkLabel_Click(object sender, EventArgs e)
        {
            while (cmbLabelType.Items.Count > 0) // clear items in cmbIdNumber
            {
                cmbLabelType.Items.RemoveAt(0);
            }

            while (cmbLabelCode.Items.Count > 0) // clear items in cmbIdNumber
            {
                cmbLabelCode.Items.RemoveAt(0);
            }

            btnAddDetails.Enabled = true; // enable this button
            btnManageFacult.Enabled = true; // enable this button
            btnManageParkLabel.Enabled = false; // disable this button
            btnDetails.Enabled = true; // enable this button
            btnReport.Enabled = true; // enable this button
            btnManageCourse.Enabled = true; // enable this button

            this.Controls.Remove(this.grStudent); // do not show this group
            this.Controls.Remove(this.grFacultManage); // do not show this group
            this.Controls.Add(this.grLabelTypes); // show this group
            this.Controls.Remove(this.grCourses); // do not show this group
            this.Controls.Remove(this.grSearch); // do not show this group
            this.Controls.Remove(this.grPdf); // do not show this group

            for (int i = 0; i < allApprovalTypes.Count; i++) // add label data into comboboxes
            {
                cmbLabelType.Items.Add(allApprovalTypes[i].approvalName);
                cmbLabelCode.Items.Add(allApprovalTypes[i].approvalCode);
            }
        }

        //----------------------------------Add Details to "search" form---------------------------------------
        private void btnDetails_Click(object sender, EventArgs e)
        {
			allVehicle = vehicleRepository.GetAllVehicles();
			idPerson = personRepository.GetAllPersonsId();

			if (allVehicle != null && allVehicle.Count>0)
            {
                btnAddDetails.Enabled = true; // enable this button
                btnManageFacult.Enabled = true; // enable this button
                btnManageParkLabel.Enabled = true; // disable this button
                btnDetails.Enabled = false; // disable this button
                btnReport.Enabled = true; // enable this button
                btnManageCourse.Enabled = true; // enable this button

                this.Controls.Remove(this.grStudent); // do not show this group
                this.Controls.Remove(this.grFacultManage); // do not show this group
                this.Controls.Remove(this.grLabelTypes); // do not show this group
                this.Controls.Remove(this.grCourses); // do not show this group
                this.Controls.Add(this.grSearch); // show this group
                this.Controls.Remove(this.grPdf); // do not show this group

                while (cmbSearch.Items.Count > 0) // clear items in cmbSearch
                {
                    cmbSearch.Items.RemoveAt(0);
                }

                for (int i = 0; i < allVehicle.Count; i++)
                {
                    cmbSearch.Items.Add(allVehicle[i].vehicleNumber);
                }
            }
            else MessageBox.Show("אין נתונים");
        }

        //-------------------------------------check if all data entered------------------------------------
        private void CheckData()
        {
            string str = "";

            if (dataPersonId.Length != 9)
            {
                dataInsertError = 1;
                str = str + "חסר מספר זהות" + "\n";
            }

            if (dataPersonFamily.Length == 0)
            {
                dataInsertError = 1;
                str = str + "חסר שם משפחה" + "\n";
            }

            if (dataPersonName.Length == 0)
            {
                dataInsertError = 1;
                str = str + "חסר שם פרטי" + "\n";
            }
            if (dataPersonBeforeTelephone.Length == 0)
            {
                dataInsertError = 1;
                str = str + "חסר קידמת סלולרית" + "\n";
            }
            if (dataPersonTelephone.Length == 0)
            {
                dataInsertError = 1;
                str = str + "חסר מספר סלולרי" + "\n";
            }

            if (dataPersonCode==0)
            {
                dataInsertError = 1;
                str = str + "חסרה בחירה - סטודנט/מרצה" + "\n";
            }

            if (dataPersonCode==1)
            {
                if (dataStudentFaculty.Length == 0)
                {
                    dataInsertError = 1;
                    str = str + "חסר שם שם מגמה" + "\n";
                }

                if (dataStudentHeadOfFaculty.Length == 0)
                {
                    dataInsertError = 1;
                    str = str + "חסר שם ראש המגמה" + "\n";
                }

                if (rdoYear == 0)
                {
                    dataInsertError = 1;
                    str = str + "חסר שנת הלימודים" + "\n";
                }

                if (StudyType == 0)
                {
                    dataInsertError = 1;
                    str = str + "חסר סוג הלימודים" + "\n";
                }
            }

            if (rdoTeacher.Checked == true)
            {
                if (dataTeacherCodeOfFaculty.Length == 0)
                {
                    dataInsertError = 1;
                    str = str + "חסר קוד המגמה" + "\n";
                }
            }


            if (dataVehicleNumber.Length == 0)
            {
                dataInsertError = 1;
                str = str + "חסר מספר רישוי" + "\n";
            }

            if (dataVehicleManufacturer.Length == 0)
            {
                dataInsertError = 1;
                str = str + "חסר שם יצרן הרכב" + "\n";
            }

            if (dataVehicleColor.Length == 0)
            {
                dataInsertError = 1;
                str = str + "חסר צבע הרכב" + "\n";
            }

            if (dataVehicleOwnerName.Length == 0)
            {
                dataInsertError = 1;
                str = str + "חסר שם בעל הרכב";
                
            }
            if (dataInsertError==1) MessageBox.Show(str);
        }

        //---------------------------------------------insert data to student class----------------------------
        private StudentModel MakeStudent()
        {
			StudentModel std;

            if (dataPersonBeforeCellphone.Length == 0 || dataPersonCellphone.Length == 0)
                std = new StudentModel(dataPersonName, dataPersonFamily, dataPersonBeforeTelephone, dataPersonTelephone, 1, dataPersonId, rdoYear, StudyType);
            else
                std = new StudentModel(dataPersonName, dataPersonFamily, dataPersonBeforeTelephone, dataPersonTelephone, dataPersonBeforeCellphone, dataPersonCellphone, 1, dataPersonId, rdoYear, StudyType);


            if (dataStudentType == 1 || dataStudentType == 2)
            {
				FacultyModel facultyModel = allFaculties.Where(af => af.facultyName.Equals(dataStudentFaculty)).Select(f => new FacultyModel
				{
					facultyCode = f.facultyCode,
					facultyHead = f.facultyHead,
					facultyName = f.facultyName
				}).SingleOrDefault();
				std.studentFacultyCode = facultyModel.facultyCode;
            }
            else if (dataStudentType == 3)
            {
				CourseModel courseModel = allCourses.Where(ac => ac.courseName.Equals(cmbCourse.Text)).Select(c => new CourseModel
				{
					courseCode = c.courseCode,
					courseName = c.courseName
				}).SingleOrDefault();
				std.studentFacultyCode = courseModel.courseCode;
            }
            return std;
        }

        //-----------------------------------------------insert data to teacher class--------------------------
        private TeacherModel MakeTeacher()
        {
			TeacherModel tcr;

            if (dataPersonBeforeCellphone.Length == 0 || dataPersonCellphone.Length == 0)
                tcr = new TeacherModel(dataPersonName, dataPersonFamily, dataPersonBeforeTelephone, dataPersonTelephone, 2, dataPersonId, dataTeacherCodeOfFaculty);
            else
                tcr = new TeacherModel(dataPersonName, dataPersonFamily, dataPersonBeforeTelephone, dataPersonTelephone, dataPersonBeforeCellphone, dataPersonCellphone, 2, dataPersonId, dataTeacherCodeOfFaculty);
            return tcr;
        }

        //--------------------------------------------------insert data to vehicle class-----------------------
        private VehicleModel MakeVehicle()
        {
			VehicleModel vcl = new VehicleModel(dataVehicleNumber, dataVehicleManufacturer, dataVehicleColor, dataVehicleOwnerName, dataPersonId);
            return vcl;
        }

        //---------------------------------------------------insert data to approval class----------------------
        private ApprovalModel MakeApproval()
        {
			allApproval = approvalRepository.GetAllApprovals(); // all approval data array
			ApprovalModel apv = new ApprovalModel(Convert.ToDateTime(dateFrom.Text.ToString()), Convert.ToDateTime(dateUntil.Text.ToString()), dataApprovalCode, dataPersonId);
            
            for (int i = 0; i<allApproval.Count; i++)
            {
                apv.approvalNumber = 0;
                if (apv.approvalNumber < allApproval[i].approvalNumber)
						apv.approvalNumber = allApproval[i].approvalNumber;
            }
            apv.approvalNumber++;

            return apv;
        }

        //---------------------------------------------------create person---------------------------------------
        private void btnCreatePerson_Click(object sender, EventArgs e)
        {
			CheckData();


			


			bool exists = idPerson.Any(p => p.personId.Equals(dataPersonId));

			if (dataInsertError == 0) // if everything ok
            {
                if (exists == true)
				{
					MessageBox.Show("המספר זהות כבר קיים");
				}
				else if (exists == false)
                {
					ThreeObjectsModel threeObjectsModel = new ThreeObjectsModel();
					if (dataPersonCode==1) threeObjectsModel.personModel = MakeStudent();
					else if (dataPersonCode==2) threeObjectsModel.personModel = MakeTeacher();
					threeObjectsModel.vehicleModel = MakeVehicle();
					threeObjectsModel.approvalModel = MakeApproval();
					threeObjectsRepository.AddThreeObjects(threeObjectsModel);
					MessageBox.Show("הוספת נתונים");
                    clearForm(); // clear form from data
                }
            }
        }

        //--------------------------------------------------update person------------------------------------------
        private void btnEditPerson_Click(object sender, EventArgs e)
        {
            CheckData();
			bool exists = idPerson.Any(p => p.personId.Equals(dataPersonId));
			if (exists == false)
			{
				MessageBox.Show("המספר זהות אינו קיים");
			} else
			{
				if (dataInsertError == 0) // if everything ok
				{
					ThreeObjectsModel threeObjectsModel = new ThreeObjectsModel();
					if (dataPersonCode == 1)
					{
						threeObjectsModel.personModel = MakeStudent();
					}
					else if (dataPersonCode == 2)
					{
						threeObjectsModel.personModel = MakeTeacher();
					}
					threeObjectsModel.vehicleModel = MakeVehicle();
					threeObjectsModel.approvalModel = MakeApproval();

					threeObjectsRepository.UpdateThreeObjects(threeObjectsModel);
					MessageBox.Show("עדכנת נתונים");
					clearForm(); // clear form from data
				}
			}
			
		}

		//-----------------------------------------------------remove person-----------------------------------
		private void btnRemovePerson_Click(object sender, EventArgs e)
        {
            CheckData();
			bool exists = idPerson.Any(p => p.personId.Equals(dataPersonId));
			if (exists == false)
			{
				MessageBox.Show("המספר זהות אינו קיים");
			} else {
				if (dataInsertError == 0)
				{
					int num = threeObjectsRepository.DeleteThreeObjects(dataPersonId);
					if (num > 0)
					{
						MessageBox.Show("מחקת נתונים");
						clearForm();
					}
				}
			}
		}

		//------------------------------------------------------create approvals------------------------------------
		private void btnLabelAdd_Click(object sender, EventArgs e)
        {
            ApprovalTypeModel apv = new ApprovalTypeModel(cmbLabelType.Text, cmbLabelCode.Text);
            approvalTypeRepository.AddApprovalType(apv);
			MessageBox.Show("הוספת נתונים");
        }

        //------------------------------------------------------remove approvals------------------------------------
        private void btnLabelRemove_Click(object sender, EventArgs e)
        {
			approvalTypeRepository.DeleteApprovalType(cmbLabelCode.Text);
            cmbLabelType.Text = "";
            cmbLabelCode.Text = "";
			MessageBox.Show("מחקת נתונים");
        }

        //------------------------------------------------------update approvals------------------------------------
        private void btnLabelEdit_Click(object sender, EventArgs e)
        {
			ApprovalTypeModel apv = new ApprovalTypeModel(cmbLabelType.Text, cmbLabelCode.Text);
            approvalTypeRepository.UpdateApprovalType(apv);
			MessageBox.Show("עדכנת נתונים");
        }

        //------------------------------------------------------create faculities--------------------------------
        private void btnApproveFaci_Click(object sender, EventArgs e)
        {
            FacultyModel fcl = new FacultyModel(cmbFaclName.Text, cmbFaclCode.Text, cmbFaclHead.Text);
            facultyRepository.AddFaculty(fcl);
			MessageBox.Show("הוספת נתונים");
        }

        //---------------------------------------------------update faculty---------------------------------------
        private void btnEditFaci_Click(object sender, EventArgs e)
        {
			FacultyModel Fcl = new FacultyModel(cmbFaclName.Text, cmbFaclCode.Text, cmbFaclHead.Text);
			facultyRepository.UpdateFaculty(Fcl);
			MessageBox.Show("עדכנת נתונים");
        }

        //---------------------------------------------------remove faculty---------------------------------------
        private void btnRemoveFaci_Click(object sender, EventArgs e)
        {
			facultyRepository.DeleteFaculty(cmbFaclCode.Text);
            cmbFaclName.Text = "";
            cmbFaclCode.Text = "";
            cmbFaclHead.Text = "";
			MessageBox.Show("מחקת נתונים");
        }

        //------------------------------------------------------create course------------------------------------
        private void btnAddCourse_Click(object sender, EventArgs e)
        {
			CourseModel cou = new CourseModel(cmbCourseCode.Text, cmbCourseName.Text);
            courseRepository.AddCourse(cou);

			MessageBox.Show("הוספת נתונים");
        }

        //------------------------------------------------------remove course------------------------------------
        private void btnDeleteCourse_Click(object sender, EventArgs e)
        {
			courseRepository.DeleteCourse(cmbCourseCode.Text);
            cmbCourseCode.Text = "";
            cmbCourseName.Text = "";
			MessageBox.Show("מחקת נתונים");
        }

        //------------------------------------------------------update course------------------------------------
        private void btnUpdateCourse_Click(object sender, EventArgs e)
        {
			CourseModel cou = new CourseModel(cmbCourseCode.Text, cmbCourseName.Text);
			courseRepository.UpdateCourse(cou);
			MessageBox.Show("עדכנת נתונים");
        }

        //--------------------------------------------------------exit---------------------------------------
        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        //-------------------------------------------------------entering id number--------------------------
        private void cmbIdNumber_TextChanged(object sender, EventArgs e)
        {
            string tmpStr;

            if (System.Text.RegularExpressions.Regex.IsMatch(dataPersonId, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
				dataPersonId = "";
            }

            tmpStr = dataPersonId;
            cmbIdNumber.Items.Clear();
			dataPersonId = tmpStr;
            cmbIdNumber.SelectionStart = dataPersonId.Length + 1;
            
            for (int i = 0; i < idPerson.Count; i++)
            {
                if (dataPersonId != "" && idPerson[i].personId.StartsWith(dataPersonId))
                    cmbIdNumber.Items.Add(idPerson[i].personId);
            }
            cmbIdNumber.DroppedDown = true;
        }

        //-------------------------------------------------------entering vehicle number to search--------------------------
        private void cmbSearch_TextChanged(object sender, EventArgs e)
        {
            string tmpStr;
            tmpStr = cmbSearch.Text;
            cmbSearch.Items.Clear();
            cmbSearch.Text = tmpStr;
            cmbSearch.SelectionStart = cmbSearch.Text.Length + 1;
            
            for (int i = 0; i < allVehicle.Count; i++) // show the vehicle numbers starts with entered digits
            {
                if (allVehicle[i].vehicleNumber.StartsWith(cmbSearch.Text))
                    cmbSearch.Items.Add(allVehicle[i].vehicleNumber);
            }
            cmbSearch.DroppedDown = true;
        }

        //-------------------------------------------------------start search--------------------------
        private void btnStartSearch_Click(object sender, EventArgs e)
        {
			allThreeObjects = threeObjectsRepository.GetAllThreeObjects();
			for (int i = 0; i < allThreeObjects.Count; i++)
            {
                if (allThreeObjects[i].vehicleModel.vehicleNumber == cmbSearch.Text.ToString())
                {
					dataVehicleNumber = allThreeObjects[i].vehicleModel.vehicleNumber;
					dataVehicleManufacturer = allThreeObjects[i].vehicleModel.vehicleManufacturer;
					dataVehicleColor = allThreeObjects[i].vehicleModel.vehicleColor;
					dataVehicleOwnerName = allThreeObjects[i].vehicleModel.vehicleOwnerName;

					dataPersonCode = 0;

					dataIsTeacher = false;

					dataPersonId = allThreeObjects[i].vehicleModel.vehicleOwnerId;

					dataPersonFamily = allThreeObjects[i].personModel.personLastName;
					dataPersonName = allThreeObjects[i].personModel.personFirstName;

					dataPersonBeforeTelephone = allThreeObjects[i].personModel.personBeforeTelephone;
					dataPersonTelephone = allThreeObjects[i].personModel.personTelephone;

					if (allThreeObjects[i].personModel.personBeforeTelephone.ToString() != null)
					{
						dataPersonBeforeCellphone = allThreeObjects[i].personModel.personBeforeCellphone;
						dataPersonCellphone = allThreeObjects[i].personModel.personCellphone;
					}

					if (allThreeObjects[i].personModel is StudentModel)
					{
						dataPersonCode = 1;

						dataIsStudent = true;
						dataIsTeacher = false;

						if ((allThreeObjects[i].personModel as StudentModel).studentYear == 1) dataStudentYear = 1;
						else if ((allThreeObjects[i].personModel as StudentModel).studentYear == 2) dataStudentYear = 2;
						else if ((allThreeObjects[i].personModel as StudentModel).studentYear == 3) dataStudentYear = 3;

						if ((allThreeObjects[i].personModel as StudentModel).studentType == 1) dataStudentType = 1;
						else if ((allThreeObjects[i].personModel as StudentModel).studentType == 2) dataStudentType = 2;
						else if ((allThreeObjects[i].personModel as StudentModel).studentType == 3) dataStudentType = 3;

						if (dataStudentType == 1 || dataStudentType == 2)
						{
							FacultyModel facultyModel = allFaculties.Where(af => af.facultyCode.Equals((allThreeObjects[i].personModel as StudentModel).studentFacultyCode)).Select(f => new FacultyModel
							{
								facultyCode = f.facultyCode,
								facultyHead = f.facultyHead,
								facultyName = f.facultyName
							}).SingleOrDefault();
							dataStudentFaculty = facultyModel.facultyName;
							dataStudentHeadOfFaculty = facultyModel.facultyHead;
						}

						else if (dataStudentType == 3)
						{
							CourseModel courseModel = allCourses.Where(ac => ac.courseCode.Equals((allThreeObjects[i].personModel as StudentModel).studentFacultyCode)).Select(c => new CourseModel
							{
								courseCode = c.courseCode,
								courseName = c.courseName
							}).SingleOrDefault();
							cmbCourse.Text = courseModel.courseName;
						}
					}

					if (allThreeObjects[i].personModel is TeacherModel)
					{
						dataPersonCode = 2;
						dataIsStudent = false;
						dataIsTeacher = true;
						dataTeacherCodeOfFaculty = (allThreeObjects[i].personModel as TeacherModel).teacherFacultyCode;
					}

					
				}


				dateFrom.Text = allThreeObjects[i].approvalModel.approvalFrom.ToShortDateString();
				dateUntil.Text = allThreeObjects[i].approvalModel.approvalUntil.ToShortDateString();

				for (int j = 0; j < allApprovalTypes.Count; j++)
				{
					if (allApprovalTypes[j].approvalCode == dataApprovalCode)
						dataApprovalType = allApprovalTypes[j].approvalName.ToString();
				}
				dataApprovalCode = allThreeObjects[i].approvalModel.approvalCode.ToString();
			}


            

            btnAddDetails.Enabled = false; // disable this button
            btnManageFacult.Enabled = true; // enable this button
            btnManageParkLabel.Enabled = true; // enable this button
            btnDetails.Enabled = true; // enable this button

            this.Controls.Remove(this.grFacultManage); // do not show this group
            this.Controls.Add(this.grStudent); // show this group
            this.Controls.Remove(this.grLabelTypes); // do not show this group
            this.Controls.Remove(this.grSearch); // do not show this group

            if (dataApprovalFrom > DateTime.Now)
            {
                MessageBox.Show("תקופת האישור עוד לא התחילה");
            }

            if (dataApprovalUntil < DateTime.Now)
            {
                if (MessageBox.Show("תקופת האישור נגמרה, למחוק מהמערכת?", "Important Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CheckData();
                    if (dataInsertError == 0)
                    {
						personRepository.DeletePerson(dataPersonId);
                        if (dataPersonCode==1) studentRepository.DeleteStudent(dataPersonId);
                        else if (dataPersonCode==2) teacherRepository.DeleteTeacher(dataPersonId);

						vehicleRepository.DeleteVehicleByNumber(dataPersonId);
                        approvalRepository.DeleteApprovalById(dataPersonId);
                        MessageBox.Show("מחקת נתונים");
                        clearForm();
                    }
                }
            }
            cmbSearch.Text = "";
        }


        private void CmbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i  = CmbFaculty.SelectedIndex;
            CmbHeadOfFaculty.SelectedIndex = i;
        }

        private void CmbHeadOfFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = CmbHeadOfFaculty.SelectedIndex;
            CmbFaculty.SelectedIndex = i;
        }

        private void cmbTypeOfApproval_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbTypeOfApproval.SelectedIndex;
            cmbCodeOfApproval.SelectedIndex = i;
        }

        private void cmbCodeOfApproval_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbCodeOfApproval.SelectedIndex;
            cmbTypeOfApproval.SelectedIndex = i;
        }


        

        private void cmbLabelCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbLabelCode.SelectedIndex;
            cmbLabelType.SelectedIndex = i;
        }

        private void cmbLabelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbLabelType.SelectedIndex;
            cmbLabelCode.SelectedIndex = i;
        }

        private void cmbFaclName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbFaclName.SelectedIndex;
            cmbFaclCode.SelectedIndex = i;
            cmbFaclHead.SelectedIndex = i;

        }

        private void cmbFaclCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbFaclCode.SelectedIndex;
            cmbFaclName.SelectedIndex = i;
            cmbFaclHead.SelectedIndex = i;
        }

        private void cmbFaclHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbFaclHead.SelectedIndex;
            cmbFaclName.SelectedIndex = i;
            cmbFaclCode.SelectedIndex = i;
        }

        //-------------------------------------------------------goto pdf creating------------------------------------
        private void btnReport_Click(object sender, EventArgs e)
        {
            btnAddDetails.Enabled = true; // enable this button
            btnManageFacult.Enabled = true; // enable this button
            btnManageParkLabel.Enabled = true; // enable this button
            btnDetails.Enabled = true; // enable this button
            btnReport.Enabled = false; // disable this button
            btnManageCourse.Enabled = true; // enable this button

            this.Controls.Remove(this.grStudent); // do not show this group
            this.Controls.Remove(this.grFacultManage); // do not show this group
            this.Controls.Remove(this.grLabelTypes); // show this group
            this.Controls.Remove(this.grCourses); // do not show this group
            this.Controls.Remove(this.grSearch); // do not show this group
            this.Controls.Add(this.grPdf); // do not show this group

            cmbChooseBy.Visible = true;
            cmbLessence.Visible = false;
            cmbChooseFaculty.Visible = false;
            cmbLabel.Visible = false;

            while (cmbChooseFaculty.Items.Count > 0) // clear items in cmbChooseFaculty
            {
                cmbChooseFaculty.Items.RemoveAt(0);
            }

            while (cmbLessence.Items.Count > 0) // clear items in cmbLessence
            {
                cmbLessence.Items.RemoveAt(0);
            }

            while (cmbLabel.Items.Count > 0) // clear items in cmbLabel
            {
                cmbLabel.Items.RemoveAt(0);
            }

            if (allFaculties.Count <= 0)
            {
                MessageBox.Show("אין מגמות");
                return;
            }

            for (int i = 0; i < allFaculties.Count; i++) // add items to cmbChooseFaculty
            {
                cmbChooseFaculty.Items.Add(allFaculties[i].facultyName);
            }
            
            if (allVehicle.Count <= 0)
            {
                MessageBox.Show("אין מכוניות");
                return;
            }
            for (int i = 0; i < allVehicle.Count; i++) // add items to cmbLessence
            {
                cmbLessence.Items.Add(allVehicle[i].vehicleNumber);
            }

            if (allApprovalTypes.Count <= 0)
            {
                MessageBox.Show("אין תווים");
                return;
            }
            for (int i = 0; i < allApprovalTypes.Count; i++) // add items to cmbLabel
            {
                cmbLabel.Items.Add(allApprovalTypes[i].approvalName);
            }
        }

        //-------------------------------------------------------make PDF------------------------------------

        private void btnSaveToPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog(); // open file dialog
            sfd.Filter = "PDF|";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK) // if file dialog works
            {
                CreatePDF myPdf = new CreatePDF(sfd.FileName);

                myPdf.DataForPDF(rtbToPdf);
                myPdf.CloseReport();
            }
        }

        //-------------------------------------------------------choise of pdf type------------------------------------
        private void cmbChooseBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChooseBy.SelectedIndex == 0)
            {
                cmbLessence.Visible = true;
                cmbChooseFaculty.Visible = false;
                cmbLabel.Visible = false;
                //this.choiseIndex = 0;
            }
            else if (cmbChooseBy.SelectedIndex == 1)
            {
                cmbLessence.Visible = false;
                cmbChooseFaculty.Visible = true;
                cmbLabel.Visible = false;
				//this.choiseIndex = 1;
            }
            else if (cmbChooseBy.SelectedIndex == 2)
            {
                cmbLessence.Visible = false;
                cmbChooseFaculty.Visible = false;
                cmbLabel.Visible = true;
				//this.choiseIndex = 2;
            }
        }


        //---------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------choises to pdf------------------------------------
        //---------------------------------------------------------------------------------------------------------
        private void ChoiseOne()
        {
            string str="";
            if (allVehicle.Count > 0)
            {
                MyTable.ColumnCount = 17;
                MyTable.RowCount = allVehicle.Count;

                MyTable.Columns[0].HeaderText = "Status";
                MyTable.Columns[1].HeaderText = "ID";
                MyTable.Columns[2].HeaderText = "First Name";
                MyTable.Columns[3].HeaderText = "Family Name";
                MyTable.Columns[4].HeaderText = "Telephone Number";
                MyTable.Columns[5].HeaderText = "Telephone Number 2";
                MyTable.Columns[6].HeaderText = "Year of Study";
                MyTable.Columns[7].HeaderText = "Type of Study";
                MyTable.Columns[8].HeaderText = "Faculty Name";
                MyTable.Columns[9].HeaderText = "Faculty Head";
                MyTable.Columns[10].HeaderText = "Course Name";
                MyTable.Columns[11].HeaderText = "Vehicle Number";
                MyTable.Columns[12].HeaderText = "Vehicle Creator";
                MyTable.Columns[13].HeaderText = "Vehicle Color";
                MyTable.Columns[14].HeaderText = "Vehicle Owner";
                MyTable.Columns[15].HeaderText = "Approval From";
                MyTable.Columns[16].HeaderText = "Approval Until";

				LoadAllPersonCourseVehicleApproval();





				for (int i = 0; i < allVehicle.Count; i++)
                {
                    if (cmbLessence.Text == allVehicle[i].vehicleNumber)
                    {
                        for (int a = 0; a < dataStudent.Count; a++)
                        {
                            if (allVehicle[i].vehicleOwnerId==dataStudent[a].studentId)
                            {
                                str = str + "Status: Student \n";
                                str = str + "ID: " + dataStudent[a].studentId + "\n";
                                str = str + "First Name: " + dataStudent[a].personFirstName + "\n";
                                str = str + "Family Name: " + dataStudent[a].personLastName + "\n";
                                str = str + "Telephone Number: " + dataStudent[a].personBeforeTelephone + dataStudent[a].personTelephone + "\n";

                                MyTable[0, i].Value = "Student";
                                MyTable[1, i].Value = dataStudent[a].studentId;
                                MyTable[2, i].Value = dataStudent[a].personFirstName;
                                MyTable[3, i].Value = dataStudent[a].personLastName;
                                MyTable[4, i].Value = dataStudent[a].personBeforeTelephone + dataStudent[i].personTelephone;

                                if (dataStudent[a].personBeforeCellphone.ToString() != "")
                                {
                                    str = str + "Telephone Number: " + dataStudent[a].personBeforeCellphone + dataStudent[a].personCellphone + "\n";
                                    MyTable[5, i].Value = dataStudent[a].personBeforeCellphone + dataStudent[i].personCellphone;
                                }

                                str = str + "Year of Study: " + dataStudent[a].studentYear + "\n";
                                MyTable[6, i].Value = dataStudent[a].studentYear;

                                if (dataStudent[a].studentType==1) str = str + "Type of Study: Morning \n";
                                else if (dataStudent[a].studentType == 2) str = str + "Type of Study: Evening \n";
                                else if (dataStudent[a].studentType == 3) str = str + "Type of Study: Course \n";
                                MyTable[7, i].Value = dataStudent[a].studentType;



                                if (dataStudent[a].studentType == 1 || dataStudent[a].studentType == 2)
                                    for (int b = 0; b < allFaculties.Count; b++)
                                    {
                                        if (dataStudent[a].studentFacultyCode == allFaculties[b].facultyCode)
                                        {
                                            str = str + "Faculty Name: " + allFaculties[b].facultyName + "\n";
                                            str = str + "Faculty Head: " + allFaculties[b].facultyHead + "\n";

                                            MyTable[8, i].Value = allFaculties[b].facultyName;
                                            MyTable[9, i].Value = allFaculties[b].facultyHead;
                                        }
                                    }
                                else if (dataStudent[a].studentType == 3)
                                    for (int b = 0; b < allCourses.Count; b++)
                                    {
                                        if (dataStudent[a].studentFacultyCode == allCourses[b].courseCode)
                                        {
                                            MyTable[10, i].Value = allCourses[b].courseName;
                                            str = str + "Course Name: " + allCourses[b].courseName + "\n";
                                        }
                                            
                                    }
                            }
                        }

                        for (int a = 0; a < dataTeacher.Count; a++)
                        {
                            if (allVehicle[i].vehicleOwnerId == dataTeacher[a].teacherId)
                            {
                                str = str + "Status: Teacher \n";
                                str = str + "ID: " + dataTeacher[a].teacherId + "\n";
                                str = str + "First Name: " + dataTeacher[a].personFirstName + "\n";
                                str = str + "Family Name: " + dataTeacher[a].personLastName + "\n";
                                str = str + "Telephone Number: " + dataTeacher[a].personBeforeTelephone + dataStudent[a].personTelephone + "\n";

                                MyTable[0, i].Value = "Teacher";
                                MyTable[1, i].Value = dataTeacher[a].teacherId;
                                MyTable[2, i].Value = dataTeacher[a].personFirstName;
                                MyTable[3, i].Value = dataTeacher[a].personLastName;
                                MyTable[4, i].Value = dataTeacher[a].personBeforeTelephone + dataStudent[i].personBeforeTelephone;

                                if (dataTeacher[a].personBeforeCellphone.ToString() != "")
                                {
                                    MyTable[5, i].Value = dataTeacher[a].personBeforeCellphone + dataStudent[i].personCellphone;
                                    str = str + "Telephone Number: " + dataStudent[a].personBeforeCellphone + dataStudent[a].personCellphone + "\n";
                                }
                                
                                for (int b = 0; b < allFaculties.Count; b++)
                                {
                                    if (dataTeacher[a].teacherFacultyCode == allFaculties[b].facultyCode)
                                    {
                                        str = str + "Faculty Name: " + allFaculties[b].facultyName + "\n";
                                        str = str + "Faculty Head: " + allFaculties[b].facultyHead + "\n";

                                        MyTable[8, i].Value = allFaculties[b].facultyName;
                                        MyTable[9, i].Value = allFaculties[b].facultyHead;
                                    }
                                }   
                            }
                        }

                        MyTable[11, i].Value = allVehicle[i].vehicleNumber;
                        MyTable[12, i].Value = allVehicle[i].vehicleManufacturer;
                        MyTable[13, i].Value = allVehicle[i].vehicleColor;
                        MyTable[14, i].Value = allVehicle[i].vehicleOwnerName;

                        str = str + "Vehicle Number: " + allVehicle[i].vehicleNumber + "\n";
                        str = str + "Vehicle Creator: " + allVehicle[i].vehicleManufacturer + "\n";
                        str = str + "Vehicle Color: " + allVehicle[i].vehicleColor + "\n";
                        str = str + "Vehicle Owner Name: " + allVehicle[i].vehicleOwnerName + "\n";

                        for (int c = 0; c < allApproval.Count; c++)
                        {
                            if (allVehicle[i].vehicleOwnerId == allApproval[c].approvalPersonId)
                            {
                                MyTable[15, i].Value = allApproval[c].approvalFrom.ToString();
                                MyTable[16, i].Value = allApproval[c].approvalUntil.ToString();

                                str = str + "Approval From: " + allApproval[c].approvalFrom.ToString() + "\n";
                                str = str + "Approval Until: " + allApproval[c].approvalUntil.ToString() + "\n";
                            }
                        }
                    }
                }
                rtbToPdf.Text = str;
            }
            else MessageBox.Show("אין מספרי רישיון");
        }















        private void ChoiseTwo()
        {
            int esists=0;
            string str="";

			LoadAllFacultyStudentTeacherVehicle();

			if (allFaculties.Count>0)
            {
                for (int i = 0; i < allFaculties.Count; i++)
                {
                    if (cmbChooseFaculty.Text == allFaculties[i].facultyName)
                    {
                        for (int a = 0; a < dataStudent.Count; a++)
                        {
                            if (dataStudent[a].studentFacultyCode == allFaculties[i].facultyCode)
                            {
                                esists = 1;
                                str = str + "Status: Student \n";
                                str = str + "ID: " + dataStudent[a].studentId + "\n";
                                str = str + "First Name: " + dataStudent[a].personFirstName + "\n";
                                str = str + "Family Name: " + dataStudent[a].personLastName + "\n";
                                str = str + "Telephone Number: " + dataStudent[a].personBeforeTelephone + dataStudent[a].personTelephone + "\n";
                                if (dataStudent[a].personBeforeCellphone.ToString()!="") str = str + "Telephone Number: " + dataStudent[a].personBeforeCellphone + dataStudent[a].personCellphone + "\n";
                                str = str + "Year of Study: " + dataStudent[a].studentYear + "\n";

                                if (dataStudent[a].studentType == 1) str = str + "Type of Study: Morning \n";
                                else if (dataStudent[a].studentType == 2) str = str + "Type of Study: Evening \n";
                                else if (dataStudent[a].studentType == 3) str = str + "Type of Study: Course \n";

                                if (dataStudent[a].studentType == 1 || dataStudent[a].studentType==2)
                                {
                                    str = str + "Faculty Name: " + allFaculties[i].facultyName + "\n";
                                    str = str + "Faculty Head: " + allFaculties[i].facultyHead + "\n";
                                }
                                else if (dataStudent[a].studentType == 3)
                                    for (int b = 0; b < allCourses.Count; b++)
                                    {
                                        if (dataStudent[a].studentFacultyCode == allCourses[b].courseCode)
                                            str = str + "Course Name: " + allCourses[b].courseName + "\n";
                                    }


                                for (int d = 0; d < allVehicle.Count; d++)
                                {
                                    if (dataStudent[a].studentId == allVehicle[d].vehicleOwnerId)
                                    {
                                        str = str + "Vehicle Number: " + allVehicle[d].vehicleNumber + "\n";
                                        str = str + "Vehicle Creator: " + allVehicle[d].vehicleManufacturer + "\n";
                                        str = str + "Vehicle Color: " + allVehicle[d].vehicleColor + "\n";
                                        str = str + "Vehicle Owner Name: " + allVehicle[d].vehicleOwnerName + "\n";
                                    }
                                }

                                for (int c = 0; c < allApproval.Count; c++)
                                {
                                    if (dataStudent[a].studentId == allApproval[c].approvalPersonId)
                                    {
                                        str = str + "Approval From: " + allApproval[c].approvalFrom.ToString() + "\n";
                                        str = str + "Approval Until: " + allApproval[c].approvalUntil.ToString() + "\n";
                                    }
                                }
                            }
                            str = str + "\n";
                        }

                        for (int a = 0; a < dataTeacher.Count; a++)
                        {
                            if (dataTeacher[a].teacherFacultyCode == allFaculties[i].facultyCode)
                            {
                                esists = 1;
                                str = str + "Status: Teacher \n";
                                str = str + "ID: " + dataTeacher[a].teacherId + "\n";
                                str = str + "First Name: " + dataTeacher[a].personFirstName + "\n";
                                str = str + "Family Name: " + dataTeacher[a].personLastName + "\n";
                                str = str + "Telephone Number: " + dataTeacher[a].personBeforeTelephone + dataStudent[a].personTelephone + "\n";
                                if (dataTeacher[a].personBeforeCellphone.ToString() != "") str = str + "Telephone Number: " + dataStudent[a].personBeforeCellphone + dataStudent[a].personCellphone + "\n";
                                str = str + "Faculty Name: " + allFaculties[i].facultyName + "\n";
                                str = str + "Faculty Head: " + allFaculties[i].facultyHead + "\n";


                                for (int d=0; d<allVehicle.Count; d++)
                                {
                                    if (dataTeacher[a].teacherId==allVehicle[d].vehicleOwnerId)
                                    {
                                        str = str + "Vehicle Number: " + allVehicle[d].vehicleNumber + "\n";
                                        str = str + "Vehicle Creator: " + allVehicle[d].vehicleManufacturer + "\n";
                                        str = str + "Vehicle Color: " + allVehicle[d].vehicleColor + "\n";
                                        str = str + "Vehicle Owner Name: " + allVehicle[d].vehicleOwnerName + "\n";
                                    }
                                }

                                for (int c = 0; c < allApproval.Count; c++)
                                {
                                    if (dataTeacher[a].teacherId == allApproval[c].approvalPersonId)
                                    {
                                        str = str + "Approval From: " + allApproval[c].approvalFrom.ToString() + "\n";
                                        str = str + "Approval Until: " + allApproval[c].approvalUntil.ToString() + "\n";
                                    }
                                }
                            }
                            str = str + "\n";
                        }



                        rtbToPdf.Text = str;
                    }
                }
                if (esists==0) MessageBox.Show("אין אנשים במגמה");
            }
            else MessageBox.Show("אין מגמות");
        }
























        private void ChoiseThree()
        {
            int exists=0;
            string str = "";

			LoadAllApprovalStudentCourseFaculty();




			for (int a = 0; a < allApprovalTypes.Count; a++)
            {
                if (cmbLabel.Text == allApprovalTypes[a].approvalName)
                {
                    for (int b = 0; b < allApproval.Count; b++)
                    {
                        if (allApprovalTypes[a].approvalCode == allApproval[b].approvalCode)
                        {
                            exists=1;
                            for (int c = 0; c < dataStudent.Count; c++)
                            {
                                if (dataStudent[c].studentId == allApproval[b].approvalPersonId)
                                {
                                    str = str + "Status: Student \n";
                                    str = str + "ID: " + dataStudent[c].studentId + "\n";
                                    str = str + "First Name: " + dataStudent[c].personFirstName + "\n";
                                    str = str + "Family Name: " + dataStudent[c].personLastName + "\n";
                                    str = str + "Telephone Number: " + dataStudent[c].personBeforeTelephone + dataStudent[c].personTelephone + "\n";
                                    if (dataStudent[c].personBeforeCellphone.ToString() != "") str = str + "Telephone Number: " + dataStudent[c].personBeforeCellphone + dataStudent[c].personCellphone + "\n";
                                    str = str + "Year of Study: " + dataStudent[c].studentYear + "\n";

                                    if (dataStudent[c].studentType == 1) str = str + "Type of Study: Morning \n";
                                    else if (dataStudent[c].studentType == 2) str = str + "Type of Study: Evening \n";
                                    else if (dataStudent[c].studentType == 3) str = str + "Type of Study: Course \n";

                                    for (int d = 0; d < allFaculties.Count; d++)
                                    {
                                        if (allFaculties[d].facultyCode == dataStudent[c].studentFacultyCode)
                                        {
                                            if (dataStudent[c].studentType == 1 || dataStudent[c].studentType == 2)
                                            {
                                                str = str + "Faculty Name: " + allFaculties[d].facultyName + "\n";
                                                str = str + "Faculty Head: " + allFaculties[d].facultyHead + "\n";
                                            }
                                            else if (dataStudent[c].studentType == 3)
                                                for (int e = 0; e < allCourses.Count; d++)
                                                {
                                                    if (dataStudent[c].studentFacultyCode == allCourses[e].courseCode)
                                                        str = str + "Course Name: " + allCourses[e].courseName + "\n";
                                                }
                                        }
                                    }
                                }
                            }

                            for (int d = 0; d < allVehicle.Count; d++)
                            {
                                if (allApproval[b].approvalPersonId == allVehicle[d].vehicleOwnerId)
                                {
                                    str = str + "Vehicle Number: " + allVehicle[d].vehicleNumber + "\n";
                                    str = str + "Vehicle Creator: " + allVehicle[d].vehicleManufacturer + "\n";
                                    str = str + "Vehicle Color: " + allVehicle[d].vehicleColor + "\n";
                                    str = str + "Vehicle Owner Name: " + allVehicle[d].vehicleOwnerName + "\n";
                                }
                            }

                            str = str + "Approval From: " + allApproval[b].approvalFrom.ToString() + "\n";
                            str = str + "Approval Until: " + allApproval[b].approvalUntil.ToString() + "\n";
                            str = str + "\n";
                        }
                    }
                    rtbToPdf.Text = rtbToPdf.Text + str;
                }
            }
            if (exists == 0) MessageBox.Show("אין אנשים עם התווית");
        }


















































        private void cmbLessence_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChoiseOne();
        }

        private void cmbChooseFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChoiseTwo();
        }

        private void cmbLabel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChoiseThree();
        }

        private void btnManageCourse_Click(object sender, EventArgs e)
        {

            while (cmbCourseName.Items.Count > 0) // clear items in cmbIdNumber
            {
                cmbCourseName.Items.RemoveAt(0);
            }

            while (cmbCourseCode.Items.Count > 0) // clear items in cmbIdNumber
            {
                cmbCourseCode.Items.RemoveAt(0);
            }

            btnAddDetails.Enabled = true; // enable this button
            btnManageFacult.Enabled = true; // enable this button
            btnManageParkLabel.Enabled = true; // enable this button
            btnDetails.Enabled = true; // enable this button
            btnReport.Enabled = true; // disable this button
            btnManageCourse.Enabled = false; // enable this button

            this.Controls.Remove(this.grStudent); // do not show this group
            this.Controls.Remove(this.grFacultManage); // do not show this group
            this.Controls.Remove(this.grLabelTypes); // show this group
            this.Controls.Add(this.grCourses); // do not show this group
            this.Controls.Remove(this.grSearch); // do not show this group
            this.Controls.Remove(this.grPdf); // do not show this group

            for (int i = 0; i < allCourses.Count; i++)
            {
                cmbCourseCode.Items.Add(allCourses[i].courseCode);
                cmbCourseName.Items.Add(allCourses[i].courseName);
            }
        }

        private void cmbCourseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbCourseName.SelectedIndex;
            cmbCourseCode.SelectedIndex = i;
        }


        private void cmbCourseCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbCourseCode.SelectedIndex;
            cmbCourseName.SelectedIndex = i;
        }

        private void cmbPdfFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPdfFormat.SelectedIndex==0)
            {
                rtbToPdf.Visible = true;
                MyTable.Visible = false;
            }
            else if (cmbPdfFormat.SelectedIndex == 1)
            {
                rtbToPdf.Visible = false;
                MyTable.Visible = true;
            }
            
        }
     }
}