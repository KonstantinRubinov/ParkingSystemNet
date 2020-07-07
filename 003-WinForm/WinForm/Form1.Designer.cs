namespace ParkingSystem
{
    partial class FrmParkingProject
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
			this.btnAddDetails = new System.Windows.Forms.Button();
			this.btnManageFacult = new System.Windows.Forms.Button();
			this.btnManageParkLabel = new System.Windows.Forms.Button();
			this.btnDetails = new System.Windows.Forms.Button();
			this.btnReport = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.grStudent = new System.Windows.Forms.GroupBox();
			this.grTeacherPersonal = new System.Windows.Forms.GroupBox();
			this.CmbCodeOfFaculty = new System.Windows.Forms.ComboBox();
			this.lblCodeOfFacility = new System.Windows.Forms.Label();
			this.btnEditPerson = new System.Windows.Forms.Button();
			this.btnRemovePerson = new System.Windows.Forms.Button();
			this.btnCreatePerson = new System.Windows.Forms.Button();
			this.grInfo = new System.Windows.Forms.GroupBox();
			this.cmbCodeOfApproval = new System.Windows.Forms.ComboBox();
			this.dateUntil = new System.Windows.Forms.DateTimePicker();
			this.dateFrom = new System.Windows.Forms.DateTimePicker();
			this.lblFrom = new System.Windows.Forms.Label();
			this.lblUntil = new System.Windows.Forms.Label();
			this.lblTypeOfApproval = new System.Windows.Forms.Label();
			this.lblCodeOfApproval = new System.Windows.Forms.Label();
			this.cmbTypeOfApproval = new System.Windows.Forms.ComboBox();
			this.grCar = new System.Windows.Forms.GroupBox();
			this.txtLessenNumber = new System.Windows.Forms.TextBox();
			this.txtCarCreator = new System.Windows.Forms.TextBox();
			this.txtCarColor = new System.Windows.Forms.TextBox();
			this.txtCarOwner = new System.Windows.Forms.TextBox();
			this.lblLessenNumber = new System.Windows.Forms.Label();
			this.lblCarCreator = new System.Windows.Forms.Label();
			this.lblCarColor = new System.Windows.Forms.Label();
			this.lblCarOwner = new System.Windows.Forms.Label();
			this.grPersonal = new System.Windows.Forms.GroupBox();
			this.cmbIdNumber = new System.Windows.Forms.ComboBox();
			this.CmbTelephone = new System.Windows.Forms.ComboBox();
			this.rdoTeacher = new System.Windows.Forms.RadioButton();
			this.rdoStudent = new System.Windows.Forms.RadioButton();
			this.grStudentPersonal = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbCourse = new System.Windows.Forms.ComboBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lblStudyType = new System.Windows.Forms.Label();
			this.rdoStudyType1 = new System.Windows.Forms.RadioButton();
			this.rdoStudyType2 = new System.Windows.Forms.RadioButton();
			this.rdoStudyType3 = new System.Windows.Forms.RadioButton();
			this.CmbHeadOfFaculty = new System.Windows.Forms.ComboBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblYear = new System.Windows.Forms.Label();
			this.rdoYear1 = new System.Windows.Forms.RadioButton();
			this.rdoYear3 = new System.Windows.Forms.RadioButton();
			this.rdoYear2 = new System.Windows.Forms.RadioButton();
			this.CmbFaculty = new System.Windows.Forms.ComboBox();
			this.lblFacility = new System.Windows.Forms.Label();
			this.lblHeadOfFacility = new System.Windows.Forms.Label();
			this.txtFamilyName = new System.Windows.Forms.TextBox();
			this.lblFamilyName = new System.Windows.Forms.Label();
			this.lblFirstName = new System.Windows.Forms.Label();
			this.lblIdNumber = new System.Windows.Forms.Label();
			this.LblTelephone = new System.Windows.Forms.Label();
			this.lblTelephone2 = new System.Windows.Forms.Label();
			this.CmbTelephone2 = new System.Windows.Forms.ComboBox();
			this.TxtTelephone2 = new System.Windows.Forms.TextBox();
			this.txtFirstName = new System.Windows.Forms.TextBox();
			this.TxtTelephone = new System.Windows.Forms.TextBox();
			this.grLabelTypes = new System.Windows.Forms.GroupBox();
			this.cmbLabelCode = new System.Windows.Forms.ComboBox();
			this.cmbLabelType = new System.Windows.Forms.ComboBox();
			this.btnLabelEdit = new System.Windows.Forms.Button();
			this.btnLabelRemove = new System.Windows.Forms.Button();
			this.btnLabelAdd = new System.Windows.Forms.Button();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.grFacultManage = new System.Windows.Forms.GroupBox();
			this.cmbFaclHead = new System.Windows.Forms.ComboBox();
			this.cmbFaclCode = new System.Windows.Forms.ComboBox();
			this.cmbFaclName = new System.Windows.Forms.ComboBox();
			this.btnEditFaci = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnRemoveFaci = new System.Windows.Forms.Button();
			this.btnApproveFaci = new System.Windows.Forms.Button();
			this.label21 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.grSearch = new System.Windows.Forms.GroupBox();
			this.cmbSearch = new System.Windows.Forms.ComboBox();
			this.btnStartSearch = new System.Windows.Forms.Button();
			this.lblSearch = new System.Windows.Forms.Label();
			this.grPdf = new System.Windows.Forms.GroupBox();
			this.cmbPdfFormat = new System.Windows.Forms.ComboBox();
			this.btnSaveToPDF = new System.Windows.Forms.Button();
			this.cmbChooseBy = new System.Windows.Forms.ComboBox();
			this.cmbLabel = new System.Windows.Forms.ComboBox();
			this.cmbChooseFaculty = new System.Windows.Forms.ComboBox();
			this.cmbLessence = new System.Windows.Forms.ComboBox();
			this.MyTable = new System.Windows.Forms.DataGridView();
			this.rtbToPdf = new System.Windows.Forms.RichTextBox();
			this.btnManageCourse = new System.Windows.Forms.Button();
			this.grCourses = new System.Windows.Forms.GroupBox();
			this.cmbCourseCode = new System.Windows.Forms.ComboBox();
			this.cmbCourseName = new System.Windows.Forms.ComboBox();
			this.btnUpdateCourse = new System.Windows.Forms.Button();
			this.btnDeleteCourse = new System.Windows.Forms.Button();
			this.btnAddCourse = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.grStudent.SuspendLayout();
			this.grTeacherPersonal.SuspendLayout();
			this.grInfo.SuspendLayout();
			this.grCar.SuspendLayout();
			this.grPersonal.SuspendLayout();
			this.grStudentPersonal.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.grLabelTypes.SuspendLayout();
			this.grFacultManage.SuspendLayout();
			this.grSearch.SuspendLayout();
			this.grPdf.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MyTable)).BeginInit();
			this.grCourses.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnAddDetails
			// 
			this.btnAddDetails.Location = new System.Drawing.Point(703, 13);
			this.btnAddDetails.Name = "btnAddDetails";
			this.btnAddDetails.Size = new System.Drawing.Size(75, 50);
			this.btnAddDetails.TabIndex = 0;
			this.btnAddDetails.Text = "הוספה עדכון פרטים";
			this.btnAddDetails.UseVisualStyleBackColor = true;
			this.btnAddDetails.Click += new System.EventHandler(this.btnAddDetails_Click);
			// 
			// btnManageFacult
			// 
			this.btnManageFacult.Location = new System.Drawing.Point(703, 67);
			this.btnManageFacult.Name = "btnManageFacult";
			this.btnManageFacult.Size = new System.Drawing.Size(75, 50);
			this.btnManageFacult.TabIndex = 2;
			this.btnManageFacult.Text = "הוספה עדכון מגמות";
			this.btnManageFacult.UseVisualStyleBackColor = true;
			this.btnManageFacult.Click += new System.EventHandler(this.btnManageFacult_Click);
			// 
			// btnManageParkLabel
			// 
			this.btnManageParkLabel.Location = new System.Drawing.Point(703, 179);
			this.btnManageParkLabel.Name = "btnManageParkLabel";
			this.btnManageParkLabel.Size = new System.Drawing.Size(75, 50);
			this.btnManageParkLabel.TabIndex = 3;
			this.btnManageParkLabel.Text = "הוספה עדכון סוג תווית";
			this.btnManageParkLabel.UseVisualStyleBackColor = true;
			this.btnManageParkLabel.Click += new System.EventHandler(this.btnManageParkLabel_Click);
			// 
			// btnDetails
			// 
			this.btnDetails.Location = new System.Drawing.Point(703, 235);
			this.btnDetails.Name = "btnDetails";
			this.btnDetails.Size = new System.Drawing.Size(75, 50);
			this.btnDetails.TabIndex = 4;
			this.btnDetails.Text = "חיפוש פרטים";
			this.btnDetails.UseVisualStyleBackColor = true;
			this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
			// 
			// btnReport
			// 
			this.btnReport.Location = new System.Drawing.Point(703, 291);
			this.btnReport.Name = "btnReport";
			this.btnReport.Size = new System.Drawing.Size(75, 50);
			this.btnReport.TabIndex = 6;
			this.btnReport.Text = "יצירת דוח";
			this.btnReport.UseVisualStyleBackColor = true;
			this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(703, 385);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(75, 50);
			this.btnExit.TabIndex = 7;
			this.btnExit.Text = "סגור";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// grStudent
			// 
			this.grStudent.Controls.Add(this.grTeacherPersonal);
			this.grStudent.Controls.Add(this.btnEditPerson);
			this.grStudent.Controls.Add(this.btnRemovePerson);
			this.grStudent.Controls.Add(this.btnCreatePerson);
			this.grStudent.Controls.Add(this.grInfo);
			this.grStudent.Controls.Add(this.grCar);
			this.grStudent.Controls.Add(this.grPersonal);
			this.grStudent.Location = new System.Drawing.Point(10, 13);
			this.grStudent.Name = "grStudent";
			this.grStudent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.grStudent.Size = new System.Drawing.Size(681, 428);
			this.grStudent.TabIndex = 10;
			this.grStudent.TabStop = false;
			this.grStudent.Text = "פרטים";
			// 
			// grTeacherPersonal
			// 
			this.grTeacherPersonal.Controls.Add(this.CmbCodeOfFaculty);
			this.grTeacherPersonal.Controls.Add(this.lblCodeOfFacility);
			this.grTeacherPersonal.Location = new System.Drawing.Point(78, 26);
			this.grTeacherPersonal.Name = "grTeacherPersonal";
			this.grTeacherPersonal.Size = new System.Drawing.Size(287, 52);
			this.grTeacherPersonal.TabIndex = 32;
			this.grTeacherPersonal.TabStop = false;
			this.grTeacherPersonal.Text = "פרטי מרצה";
			// 
			// CmbCodeOfFaculty
			// 
			this.CmbCodeOfFaculty.Cursor = System.Windows.Forms.Cursors.Hand;
			this.CmbCodeOfFaculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CmbCodeOfFaculty.FormattingEnabled = true;
			this.CmbCodeOfFaculty.Location = new System.Drawing.Point(14, 19);
			this.CmbCodeOfFaculty.Name = "CmbCodeOfFaculty";
			this.CmbCodeOfFaculty.Size = new System.Drawing.Size(160, 21);
			this.CmbCodeOfFaculty.TabIndex = 36;
			// 
			// lblCodeOfFacility
			// 
			this.lblCodeOfFacility.AutoSize = true;
			this.lblCodeOfFacility.Location = new System.Drawing.Point(205, 22);
			this.lblCodeOfFacility.Name = "lblCodeOfFacility";
			this.lblCodeOfFacility.Size = new System.Drawing.Size(56, 13);
			this.lblCodeOfFacility.TabIndex = 28;
			this.lblCodeOfFacility.Text = "קוד מגמה";
			// 
			// btnEditPerson
			// 
			this.btnEditPerson.Location = new System.Drawing.Point(485, 399);
			this.btnEditPerson.Name = "btnEditPerson";
			this.btnEditPerson.Size = new System.Drawing.Size(79, 23);
			this.btnEditPerson.TabIndex = 29;
			this.btnEditPerson.Text = "עדכן";
			this.btnEditPerson.UseVisualStyleBackColor = true;
			this.btnEditPerson.Click += new System.EventHandler(this.btnEditPerson_Click);
			// 
			// btnRemovePerson
			// 
			this.btnRemovePerson.Location = new System.Drawing.Point(384, 399);
			this.btnRemovePerson.Name = "btnRemovePerson";
			this.btnRemovePerson.Size = new System.Drawing.Size(79, 23);
			this.btnRemovePerson.TabIndex = 28;
			this.btnRemovePerson.Text = "מחיקה";
			this.btnRemovePerson.UseVisualStyleBackColor = true;
			this.btnRemovePerson.Click += new System.EventHandler(this.btnRemovePerson_Click);
			// 
			// btnCreatePerson
			// 
			this.btnCreatePerson.Location = new System.Drawing.Point(584, 399);
			this.btnCreatePerson.Name = "btnCreatePerson";
			this.btnCreatePerson.Size = new System.Drawing.Size(79, 23);
			this.btnCreatePerson.TabIndex = 27;
			this.btnCreatePerson.Text = "הוסף";
			this.btnCreatePerson.UseVisualStyleBackColor = true;
			this.btnCreatePerson.Click += new System.EventHandler(this.btnCreatePerson_Click);
			// 
			// grInfo
			// 
			this.grInfo.Controls.Add(this.cmbCodeOfApproval);
			this.grInfo.Controls.Add(this.dateUntil);
			this.grInfo.Controls.Add(this.dateFrom);
			this.grInfo.Controls.Add(this.lblFrom);
			this.grInfo.Controls.Add(this.lblUntil);
			this.grInfo.Controls.Add(this.lblTypeOfApproval);
			this.grInfo.Controls.Add(this.lblCodeOfApproval);
			this.grInfo.Controls.Add(this.cmbTypeOfApproval);
			this.grInfo.Location = new System.Drawing.Point(17, 231);
			this.grInfo.Name = "grInfo";
			this.grInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.grInfo.Size = new System.Drawing.Size(348, 164);
			this.grInfo.TabIndex = 26;
			this.grInfo.TabStop = false;
			this.grInfo.Text = "פרטי האישור";
			// 
			// cmbCodeOfApproval
			// 
			this.cmbCodeOfApproval.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cmbCodeOfApproval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCodeOfApproval.FormattingEnabled = true;
			this.cmbCodeOfApproval.Location = new System.Drawing.Point(30, 123);
			this.cmbCodeOfApproval.Margin = new System.Windows.Forms.Padding(2);
			this.cmbCodeOfApproval.Name = "cmbCodeOfApproval";
			this.cmbCodeOfApproval.Size = new System.Drawing.Size(199, 21);
			this.cmbCodeOfApproval.TabIndex = 22;
			this.cmbCodeOfApproval.SelectedIndexChanged += new System.EventHandler(this.cmbCodeOfApproval_SelectedIndexChanged);
			// 
			// dateUntil
			// 
			this.dateUntil.Location = new System.Drawing.Point(29, 57);
			this.dateUntil.Name = "dateUntil";
			this.dateUntil.Size = new System.Drawing.Size(200, 20);
			this.dateUntil.TabIndex = 14;
			this.dateUntil.Value = new System.DateTime(2019, 7, 31, 0, 0, 0, 0);
			// 
			// dateFrom
			// 
			this.dateFrom.Location = new System.Drawing.Point(29, 27);
			this.dateFrom.Name = "dateFrom";
			this.dateFrom.Size = new System.Drawing.Size(200, 20);
			this.dateFrom.TabIndex = 13;
			this.dateFrom.Value = new System.DateTime(2019, 7, 20, 0, 0, 0, 0);
			// 
			// lblFrom
			// 
			this.lblFrom.AutoSize = true;
			this.lblFrom.Location = new System.Drawing.Point(262, 33);
			this.lblFrom.Name = "lblFrom";
			this.lblFrom.Size = new System.Drawing.Size(76, 13);
			this.lblFrom.TabIndex = 9;
			this.lblFrom.Text = "תאריך הנפקה";
			// 
			// lblUntil
			// 
			this.lblUntil.AutoSize = true;
			this.lblUntil.Location = new System.Drawing.Point(257, 63);
			this.lblUntil.Name = "lblUntil";
			this.lblUntil.Size = new System.Drawing.Size(81, 13);
			this.lblUntil.TabIndex = 10;
			this.lblUntil.Text = "תקף עד תאריך";
			// 
			// lblTypeOfApproval
			// 
			this.lblTypeOfApproval.AutoSize = true;
			this.lblTypeOfApproval.Location = new System.Drawing.Point(270, 92);
			this.lblTypeOfApproval.Name = "lblTypeOfApproval";
			this.lblTypeOfApproval.Size = new System.Drawing.Size(68, 13);
			this.lblTypeOfApproval.TabIndex = 11;
			this.lblTypeOfApproval.Text = "סוג האישור";
			// 
			// lblCodeOfApproval
			// 
			this.lblCodeOfApproval.AutoSize = true;
			this.lblCodeOfApproval.Location = new System.Drawing.Point(261, 125);
			this.lblCodeOfApproval.Name = "lblCodeOfApproval";
			this.lblCodeOfApproval.Size = new System.Drawing.Size(77, 13);
			this.lblCodeOfApproval.TabIndex = 12;
			this.lblCodeOfApproval.Text = "מספר האישור";
			// 
			// cmbTypeOfApproval
			// 
			this.cmbTypeOfApproval.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cmbTypeOfApproval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTypeOfApproval.FormattingEnabled = true;
			this.cmbTypeOfApproval.Location = new System.Drawing.Point(30, 89);
			this.cmbTypeOfApproval.Name = "cmbTypeOfApproval";
			this.cmbTypeOfApproval.Size = new System.Drawing.Size(199, 21);
			this.cmbTypeOfApproval.TabIndex = 13;
			this.cmbTypeOfApproval.SelectedIndexChanged += new System.EventHandler(this.cmbTypeOfApproval_SelectedIndexChanged);
			// 
			// grCar
			// 
			this.grCar.Controls.Add(this.txtLessenNumber);
			this.grCar.Controls.Add(this.txtCarCreator);
			this.grCar.Controls.Add(this.txtCarColor);
			this.grCar.Controls.Add(this.txtCarOwner);
			this.grCar.Controls.Add(this.lblLessenNumber);
			this.grCar.Controls.Add(this.lblCarCreator);
			this.grCar.Controls.Add(this.lblCarColor);
			this.grCar.Controls.Add(this.lblCarOwner);
			this.grCar.Location = new System.Drawing.Point(78, 79);
			this.grCar.Name = "grCar";
			this.grCar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.grCar.Size = new System.Drawing.Size(287, 134);
			this.grCar.TabIndex = 25;
			this.grCar.TabStop = false;
			this.grCar.Text = "פרטי הרכב";
			// 
			// txtLessenNumber
			// 
			this.txtLessenNumber.Location = new System.Drawing.Point(6, 25);
			this.txtLessenNumber.Name = "txtLessenNumber";
			this.txtLessenNumber.Size = new System.Drawing.Size(160, 20);
			this.txtLessenNumber.TabIndex = 15;
			// 
			// txtCarCreator
			// 
			this.txtCarCreator.Location = new System.Drawing.Point(6, 52);
			this.txtCarCreator.Name = "txtCarCreator";
			this.txtCarCreator.Size = new System.Drawing.Size(160, 20);
			this.txtCarCreator.TabIndex = 16;
			// 
			// txtCarColor
			// 
			this.txtCarColor.Location = new System.Drawing.Point(6, 79);
			this.txtCarColor.Name = "txtCarColor";
			this.txtCarColor.Size = new System.Drawing.Size(160, 20);
			this.txtCarColor.TabIndex = 17;
			// 
			// txtCarOwner
			// 
			this.txtCarOwner.Location = new System.Drawing.Point(6, 106);
			this.txtCarOwner.Name = "txtCarOwner";
			this.txtCarOwner.Size = new System.Drawing.Size(160, 20);
			this.txtCarOwner.TabIndex = 18;
			// 
			// lblLessenNumber
			// 
			this.lblLessenNumber.AutoSize = true;
			this.lblLessenNumber.Location = new System.Drawing.Point(214, 28);
			this.lblLessenNumber.Name = "lblLessenNumber";
			this.lblLessenNumber.Size = new System.Drawing.Size(67, 13);
			this.lblLessenNumber.TabIndex = 5;
			this.lblLessenNumber.Text = "מספר רישוי";
			// 
			// lblCarCreator
			// 
			this.lblCarCreator.AutoSize = true;
			this.lblCarCreator.Location = new System.Drawing.Point(221, 55);
			this.lblCarCreator.Name = "lblCarCreator";
			this.lblCarCreator.Size = new System.Drawing.Size(60, 13);
			this.lblCarCreator.TabIndex = 6;
			this.lblCarCreator.Text = "יצרן הרכב";
			// 
			// lblCarColor
			// 
			this.lblCarColor.AutoSize = true;
			this.lblCarColor.Location = new System.Drawing.Point(253, 82);
			this.lblCarColor.Name = "lblCarColor";
			this.lblCarColor.Size = new System.Drawing.Size(28, 13);
			this.lblCarColor.TabIndex = 7;
			this.lblCarColor.Text = "צבע";
			// 
			// lblCarOwner
			// 
			this.lblCarOwner.AutoSize = true;
			this.lblCarOwner.Location = new System.Drawing.Point(204, 109);
			this.lblCarOwner.Name = "lblCarOwner";
			this.lblCarOwner.Size = new System.Drawing.Size(77, 13);
			this.lblCarOwner.TabIndex = 8;
			this.lblCarOwner.Text = "שם בעל הרכב";
			// 
			// grPersonal
			// 
			this.grPersonal.Controls.Add(this.cmbIdNumber);
			this.grPersonal.Controls.Add(this.CmbTelephone);
			this.grPersonal.Controls.Add(this.rdoTeacher);
			this.grPersonal.Controls.Add(this.rdoStudent);
			this.grPersonal.Controls.Add(this.grStudentPersonal);
			this.grPersonal.Controls.Add(this.txtFamilyName);
			this.grPersonal.Controls.Add(this.lblFamilyName);
			this.grPersonal.Controls.Add(this.lblFirstName);
			this.grPersonal.Controls.Add(this.lblIdNumber);
			this.grPersonal.Controls.Add(this.LblTelephone);
			this.grPersonal.Controls.Add(this.lblTelephone2);
			this.grPersonal.Controls.Add(this.CmbTelephone2);
			this.grPersonal.Controls.Add(this.TxtTelephone2);
			this.grPersonal.Controls.Add(this.txtFirstName);
			this.grPersonal.Controls.Add(this.TxtTelephone);
			this.grPersonal.Location = new System.Drawing.Point(384, 26);
			this.grPersonal.Name = "grPersonal";
			this.grPersonal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.grPersonal.Size = new System.Drawing.Size(281, 367);
			this.grPersonal.TabIndex = 24;
			this.grPersonal.TabStop = false;
			this.grPersonal.Text = "פרטים אישיים";
			// 
			// cmbIdNumber
			// 
			this.cmbIdNumber.FormattingEnabled = true;
			this.cmbIdNumber.Location = new System.Drawing.Point(20, 20);
			this.cmbIdNumber.Name = "cmbIdNumber";
			this.cmbIdNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbIdNumber.Size = new System.Drawing.Size(160, 21);
			this.cmbIdNumber.TabIndex = 32;
			this.cmbIdNumber.TextChanged += new System.EventHandler(this.cmbIdNumber_TextChanged);
			// 
			// CmbTelephone
			// 
			this.CmbTelephone.FormattingEnabled = true;
			this.CmbTelephone.Items.AddRange(new object[] {
            "02",
            "03",
            "04",
            "07",
            "08",
            "09"});
			this.CmbTelephone.Location = new System.Drawing.Point(20, 109);
			this.CmbTelephone.Name = "CmbTelephone";
			this.CmbTelephone.Size = new System.Drawing.Size(54, 21);
			this.CmbTelephone.TabIndex = 31;
			// 
			// rdoTeacher
			// 
			this.rdoTeacher.AutoSize = true;
			this.rdoTeacher.Location = new System.Drawing.Point(22, 163);
			this.rdoTeacher.Name = "rdoTeacher";
			this.rdoTeacher.Size = new System.Drawing.Size(52, 17);
			this.rdoTeacher.TabIndex = 30;
			this.rdoTeacher.TabStop = true;
			this.rdoTeacher.Text = "מרצה";
			this.rdoTeacher.UseVisualStyleBackColor = true;
			this.rdoTeacher.CheckedChanged += new System.EventHandler(this.rdoTeacher_CheckedChanged);
			// 
			// rdoStudent
			// 
			this.rdoStudent.AutoSize = true;
			this.rdoStudent.Location = new System.Drawing.Point(117, 163);
			this.rdoStudent.Name = "rdoStudent";
			this.rdoStudent.Size = new System.Drawing.Size(63, 17);
			this.rdoStudent.TabIndex = 29;
			this.rdoStudent.TabStop = true;
			this.rdoStudent.Text = "סטודנט";
			this.rdoStudent.UseVisualStyleBackColor = true;
			this.rdoStudent.CheckedChanged += new System.EventHandler(this.rdoStudent_CheckedChanged);
			// 
			// grStudentPersonal
			// 
			this.grStudentPersonal.Controls.Add(this.label4);
			this.grStudentPersonal.Controls.Add(this.cmbCourse);
			this.grStudentPersonal.Controls.Add(this.panel2);
			this.grStudentPersonal.Controls.Add(this.CmbHeadOfFaculty);
			this.grStudentPersonal.Controls.Add(this.panel1);
			this.grStudentPersonal.Controls.Add(this.CmbFaculty);
			this.grStudentPersonal.Controls.Add(this.lblFacility);
			this.grStudentPersonal.Controls.Add(this.lblHeadOfFacility);
			this.grStudentPersonal.Location = new System.Drawing.Point(6, 187);
			this.grStudentPersonal.Name = "grStudentPersonal";
			this.grStudentPersonal.Size = new System.Drawing.Size(272, 174);
			this.grStudentPersonal.TabIndex = 16;
			this.grStudentPersonal.TabStop = false;
			this.grStudentPersonal.Text = "פרטי סטודנט";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(203, 129);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 13);
			this.label4.TabIndex = 41;
			this.label4.Text = "שם הקורס";
			// 
			// cmbCourse
			// 
			this.cmbCourse.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCourse.Enabled = false;
			this.cmbCourse.FormattingEnabled = true;
			this.cmbCourse.Location = new System.Drawing.Point(14, 124);
			this.cmbCourse.Name = "cmbCourse";
			this.cmbCourse.Size = new System.Drawing.Size(160, 21);
			this.cmbCourse.TabIndex = 40;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lblStudyType);
			this.panel2.Controls.Add(this.rdoStudyType1);
			this.panel2.Controls.Add(this.rdoStudyType2);
			this.panel2.Controls.Add(this.rdoStudyType3);
			this.panel2.Location = new System.Drawing.Point(5, 44);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(261, 21);
			this.panel2.TabIndex = 39;
			// 
			// lblStudyType
			// 
			this.lblStudyType.AutoSize = true;
			this.lblStudyType.Location = new System.Drawing.Point(184, 4);
			this.lblStudyType.Name = "lblStudyType";
			this.lblStudyType.Size = new System.Drawing.Size(74, 13);
			this.lblStudyType.TabIndex = 25;
			this.lblStudyType.Text = "מסלול לימוד";
			// 
			// rdoStudyType1
			// 
			this.rdoStudyType1.AutoSize = true;
			this.rdoStudyType1.Location = new System.Drawing.Point(118, 2);
			this.rdoStudyType1.Name = "rdoStudyType1";
			this.rdoStudyType1.Size = new System.Drawing.Size(50, 17);
			this.rdoStudyType1.TabIndex = 31;
			this.rdoStudyType1.TabStop = true;
			this.rdoStudyType1.Text = "בוקר";
			this.rdoStudyType1.UseVisualStyleBackColor = true;
			this.rdoStudyType1.CheckedChanged += new System.EventHandler(this.rdoStudyType1_CheckedChanged);
			// 
			// rdoStudyType2
			// 
			this.rdoStudyType2.AutoSize = true;
			this.rdoStudyType2.Location = new System.Drawing.Point(72, 2);
			this.rdoStudyType2.Name = "rdoStudyType2";
			this.rdoStudyType2.Size = new System.Drawing.Size(45, 17);
			this.rdoStudyType2.TabIndex = 32;
			this.rdoStudyType2.TabStop = true;
			this.rdoStudyType2.Text = "ערב";
			this.rdoStudyType2.UseVisualStyleBackColor = true;
			this.rdoStudyType2.CheckedChanged += new System.EventHandler(this.rdoStudyType2_CheckedChanged);
			// 
			// rdoStudyType3
			// 
			this.rdoStudyType3.AutoSize = true;
			this.rdoStudyType3.Location = new System.Drawing.Point(12, 2);
			this.rdoStudyType3.Name = "rdoStudyType3";
			this.rdoStudyType3.Size = new System.Drawing.Size(50, 17);
			this.rdoStudyType3.TabIndex = 33;
			this.rdoStudyType3.TabStop = true;
			this.rdoStudyType3.Text = "קורס";
			this.rdoStudyType3.UseVisualStyleBackColor = true;
			this.rdoStudyType3.CheckedChanged += new System.EventHandler(this.rdoStudyType3_CheckedChanged);
			// 
			// CmbHeadOfFaculty
			// 
			this.CmbHeadOfFaculty.Cursor = System.Windows.Forms.Cursors.Hand;
			this.CmbHeadOfFaculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CmbHeadOfFaculty.Enabled = false;
			this.CmbHeadOfFaculty.FormattingEnabled = true;
			this.CmbHeadOfFaculty.Location = new System.Drawing.Point(14, 97);
			this.CmbHeadOfFaculty.Name = "CmbHeadOfFaculty";
			this.CmbHeadOfFaculty.Size = new System.Drawing.Size(160, 21);
			this.CmbHeadOfFaculty.TabIndex = 35;
			this.CmbHeadOfFaculty.SelectedIndexChanged += new System.EventHandler(this.CmbHeadOfFaculty_SelectedIndexChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblYear);
			this.panel1.Controls.Add(this.rdoYear1);
			this.panel1.Controls.Add(this.rdoYear3);
			this.panel1.Controls.Add(this.rdoYear2);
			this.panel1.Location = new System.Drawing.Point(5, 18);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(261, 24);
			this.panel1.TabIndex = 38;
			// 
			// lblYear
			// 
			this.lblYear.AutoSize = true;
			this.lblYear.Location = new System.Drawing.Point(196, 6);
			this.lblYear.Name = "lblYear";
			this.lblYear.Size = new System.Drawing.Size(62, 13);
			this.lblYear.TabIndex = 24;
			this.lblYear.Text = "שנת לימוד";
			// 
			// rdoYear1
			// 
			this.rdoYear1.AutoSize = true;
			this.rdoYear1.Location = new System.Drawing.Point(134, 4);
			this.rdoYear1.Name = "rdoYear1";
			this.rdoYear1.Size = new System.Drawing.Size(33, 17);
			this.rdoYear1.TabIndex = 28;
			this.rdoYear1.TabStop = true;
			this.rdoYear1.Text = "א";
			this.rdoYear1.UseVisualStyleBackColor = true;
			this.rdoYear1.CheckedChanged += new System.EventHandler(this.rdoYear1_CheckedChanged);
			// 
			// rdoYear3
			// 
			this.rdoYear3.AutoSize = true;
			this.rdoYear3.Location = new System.Drawing.Point(30, 3);
			this.rdoYear3.Name = "rdoYear3";
			this.rdoYear3.Size = new System.Drawing.Size(31, 17);
			this.rdoYear3.TabIndex = 30;
			this.rdoYear3.TabStop = true;
			this.rdoYear3.Text = "ג";
			this.rdoYear3.UseVisualStyleBackColor = true;
			this.rdoYear3.CheckedChanged += new System.EventHandler(this.rdoYear3_CheckedChanged);
			// 
			// rdoYear2
			// 
			this.rdoYear2.AutoSize = true;
			this.rdoYear2.Location = new System.Drawing.Point(84, 4);
			this.rdoYear2.Name = "rdoYear2";
			this.rdoYear2.Size = new System.Drawing.Size(32, 17);
			this.rdoYear2.TabIndex = 29;
			this.rdoYear2.TabStop = true;
			this.rdoYear2.Text = "ב";
			this.rdoYear2.UseVisualStyleBackColor = true;
			this.rdoYear2.CheckedChanged += new System.EventHandler(this.rdoYear2_CheckedChanged);
			// 
			// CmbFaculty
			// 
			this.CmbFaculty.BackColor = System.Drawing.Color.White;
			this.CmbFaculty.Cursor = System.Windows.Forms.Cursors.Hand;
			this.CmbFaculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CmbFaculty.Enabled = false;
			this.CmbFaculty.FormattingEnabled = true;
			this.CmbFaculty.Location = new System.Drawing.Point(14, 69);
			this.CmbFaculty.Name = "CmbFaculty";
			this.CmbFaculty.Size = new System.Drawing.Size(160, 21);
			this.CmbFaculty.TabIndex = 34;
			this.CmbFaculty.SelectedIndexChanged += new System.EventHandler(this.CmbFaculty_SelectedIndexChanged);
			// 
			// lblFacility
			// 
			this.lblFacility.AutoSize = true;
			this.lblFacility.Location = new System.Drawing.Point(185, 72);
			this.lblFacility.Name = "lblFacility";
			this.lblFacility.Size = new System.Drawing.Size(80, 13);
			this.lblFacility.TabIndex = 26;
			this.lblFacility.Text = "מגמת לימודים";
			// 
			// lblHeadOfFacility
			// 
			this.lblHeadOfFacility.AutoSize = true;
			this.lblHeadOfFacility.Location = new System.Drawing.Point(184, 100);
			this.lblHeadOfFacility.Name = "lblHeadOfFacility";
			this.lblHeadOfFacility.Size = new System.Drawing.Size(81, 13);
			this.lblHeadOfFacility.TabIndex = 27;
			this.lblHeadOfFacility.Text = "שם מרכז מגמה";
			// 
			// txtFamilyName
			// 
			this.txtFamilyName.Location = new System.Drawing.Point(20, 50);
			this.txtFamilyName.Name = "txtFamilyName";
			this.txtFamilyName.Size = new System.Drawing.Size(160, 20);
			this.txtFamilyName.TabIndex = 9;
			// 
			// lblFamilyName
			// 
			this.lblFamilyName.AutoSize = true;
			this.lblFamilyName.Location = new System.Drawing.Point(211, 54);
			this.lblFamilyName.Name = "lblFamilyName";
			this.lblFamilyName.Size = new System.Drawing.Size(63, 13);
			this.lblFamilyName.TabIndex = 0;
			this.lblFamilyName.Text = "שם משפחה";
			// 
			// lblFirstName
			// 
			this.lblFirstName.AutoSize = true;
			this.lblFirstName.Location = new System.Drawing.Point(223, 81);
			this.lblFirstName.Name = "lblFirstName";
			this.lblFirstName.Size = new System.Drawing.Size(51, 13);
			this.lblFirstName.TabIndex = 1;
			this.lblFirstName.Text = "שם פרטי";
			// 
			// lblIdNumber
			// 
			this.lblIdNumber.AutoSize = true;
			this.lblIdNumber.Location = new System.Drawing.Point(223, 25);
			this.lblIdNumber.Name = "lblIdNumber";
			this.lblIdNumber.Size = new System.Drawing.Size(52, 13);
			this.lblIdNumber.TabIndex = 2;
			this.lblIdNumber.Text = "מספר ת.ז";
			// 
			// LblTelephone
			// 
			this.LblTelephone.AutoSize = true;
			this.LblTelephone.Location = new System.Drawing.Point(206, 112);
			this.LblTelephone.Name = "LblTelephone";
			this.LblTelephone.Size = new System.Drawing.Size(68, 13);
			this.LblTelephone.TabIndex = 3;
			this.LblTelephone.Text = "מספר טלפון";
			// 
			// lblTelephone2
			// 
			this.lblTelephone2.AutoSize = true;
			this.lblTelephone2.Location = new System.Drawing.Point(205, 140);
			this.lblTelephone2.Name = "lblTelephone2";
			this.lblTelephone2.Size = new System.Drawing.Size(74, 13);
			this.lblTelephone2.TabIndex = 4;
			this.lblTelephone2.Text = "מספר סלולרי";
			// 
			// CmbTelephone2
			// 
			this.CmbTelephone2.FormattingEnabled = true;
			this.CmbTelephone2.Items.AddRange(new object[] {
            "0505",
            "0506",
            "0507",
            "0508",
            "0522",
            "0523",
            "0524",
            "0528",
            "0542",
            "0544",
            "0545",
            "0546",
            "0547",
            "0577"});
			this.CmbTelephone2.Location = new System.Drawing.Point(20, 136);
			this.CmbTelephone2.Name = "CmbTelephone2";
			this.CmbTelephone2.Size = new System.Drawing.Size(54, 21);
			this.CmbTelephone2.TabIndex = 15;
			// 
			// TxtTelephone2
			// 
			this.TxtTelephone2.Location = new System.Drawing.Point(80, 136);
			this.TxtTelephone2.Name = "TxtTelephone2";
			this.TxtTelephone2.Size = new System.Drawing.Size(100, 20);
			this.TxtTelephone2.TabIndex = 14;
			// 
			// txtFirstName
			// 
			this.txtFirstName.Location = new System.Drawing.Point(20, 77);
			this.txtFirstName.Name = "txtFirstName";
			this.txtFirstName.Size = new System.Drawing.Size(160, 20);
			this.txtFirstName.TabIndex = 10;
			// 
			// TxtTelephone
			// 
			this.TxtTelephone.Location = new System.Drawing.Point(80, 109);
			this.TxtTelephone.Name = "TxtTelephone";
			this.TxtTelephone.Size = new System.Drawing.Size(100, 20);
			this.TxtTelephone.TabIndex = 12;
			// 
			// grLabelTypes
			// 
			this.grLabelTypes.Controls.Add(this.cmbLabelCode);
			this.grLabelTypes.Controls.Add(this.cmbLabelType);
			this.grLabelTypes.Controls.Add(this.btnLabelEdit);
			this.grLabelTypes.Controls.Add(this.btnLabelRemove);
			this.grLabelTypes.Controls.Add(this.btnLabelAdd);
			this.grLabelTypes.Controls.Add(this.label22);
			this.grLabelTypes.Controls.Add(this.label23);
			this.grLabelTypes.Location = new System.Drawing.Point(10, 13);
			this.grLabelTypes.Name = "grLabelTypes";
			this.grLabelTypes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.grLabelTypes.Size = new System.Drawing.Size(681, 428);
			this.grLabelTypes.TabIndex = 29;
			this.grLabelTypes.TabStop = false;
			this.grLabelTypes.Text = "עדכון סוג תווית";
			// 
			// cmbLabelCode
			// 
			this.cmbLabelCode.FormattingEnabled = true;
			this.cmbLabelCode.Location = new System.Drawing.Point(242, 189);
			this.cmbLabelCode.Margin = new System.Windows.Forms.Padding(2);
			this.cmbLabelCode.Name = "cmbLabelCode";
			this.cmbLabelCode.Size = new System.Drawing.Size(169, 21);
			this.cmbLabelCode.TabIndex = 8;
			this.cmbLabelCode.SelectedIndexChanged += new System.EventHandler(this.cmbLabelCode_SelectedIndexChanged);
			// 
			// cmbLabelType
			// 
			this.cmbLabelType.FormattingEnabled = true;
			this.cmbLabelType.Location = new System.Drawing.Point(242, 161);
			this.cmbLabelType.Margin = new System.Windows.Forms.Padding(2);
			this.cmbLabelType.Name = "cmbLabelType";
			this.cmbLabelType.Size = new System.Drawing.Size(169, 21);
			this.cmbLabelType.TabIndex = 7;
			this.cmbLabelType.SelectedIndexChanged += new System.EventHandler(this.cmbLabelType_SelectedIndexChanged);
			// 
			// btnLabelEdit
			// 
			this.btnLabelEdit.Location = new System.Drawing.Point(242, 214);
			this.btnLabelEdit.Name = "btnLabelEdit";
			this.btnLabelEdit.Size = new System.Drawing.Size(57, 23);
			this.btnLabelEdit.TabIndex = 6;
			this.btnLabelEdit.Text = "עדכון";
			this.btnLabelEdit.UseVisualStyleBackColor = true;
			this.btnLabelEdit.Click += new System.EventHandler(this.btnLabelEdit_Click);
			// 
			// btnLabelRemove
			// 
			this.btnLabelRemove.Location = new System.Drawing.Point(305, 214);
			this.btnLabelRemove.Name = "btnLabelRemove";
			this.btnLabelRemove.Size = new System.Drawing.Size(50, 23);
			this.btnLabelRemove.TabIndex = 5;
			this.btnLabelRemove.Text = "הורדה";
			this.btnLabelRemove.UseVisualStyleBackColor = true;
			this.btnLabelRemove.Click += new System.EventHandler(this.btnLabelRemove_Click);
			// 
			// btnLabelAdd
			// 
			this.btnLabelAdd.Location = new System.Drawing.Point(361, 214);
			this.btnLabelAdd.Name = "btnLabelAdd";
			this.btnLabelAdd.Size = new System.Drawing.Size(50, 23);
			this.btnLabelAdd.TabIndex = 4;
			this.btnLabelAdd.Text = "הוספה";
			this.btnLabelAdd.UseVisualStyleBackColor = true;
			this.btnLabelAdd.Click += new System.EventHandler(this.btnLabelAdd_Click);
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(416, 192);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(58, 13);
			this.label22.TabIndex = 3;
			this.label22.Text = "קוד תווית";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(416, 165);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(57, 13);
			this.label23.TabIndex = 2;
			this.label23.Text = "סוג תווית";
			// 
			// grFacultManage
			// 
			this.grFacultManage.Controls.Add(this.cmbFaclHead);
			this.grFacultManage.Controls.Add(this.cmbFaclCode);
			this.grFacultManage.Controls.Add(this.cmbFaclName);
			this.grFacultManage.Controls.Add(this.btnEditFaci);
			this.grFacultManage.Controls.Add(this.label1);
			this.grFacultManage.Controls.Add(this.btnRemoveFaci);
			this.grFacultManage.Controls.Add(this.btnApproveFaci);
			this.grFacultManage.Controls.Add(this.label21);
			this.grFacultManage.Controls.Add(this.label20);
			this.grFacultManage.Location = new System.Drawing.Point(10, 13);
			this.grFacultManage.Name = "grFacultManage";
			this.grFacultManage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.grFacultManage.Size = new System.Drawing.Size(681, 428);
			this.grFacultManage.TabIndex = 28;
			this.grFacultManage.TabStop = false;
			this.grFacultManage.Text = "הוספה ועדכון מגמות";
			// 
			// cmbFaclHead
			// 
			this.cmbFaclHead.FormattingEnabled = true;
			this.cmbFaclHead.Location = new System.Drawing.Point(255, 213);
			this.cmbFaclHead.Margin = new System.Windows.Forms.Padding(2);
			this.cmbFaclHead.Name = "cmbFaclHead";
			this.cmbFaclHead.Size = new System.Drawing.Size(171, 21);
			this.cmbFaclHead.TabIndex = 11;
			this.cmbFaclHead.SelectedIndexChanged += new System.EventHandler(this.cmbFaclHead_SelectedIndexChanged);
			// 
			// cmbFaclCode
			// 
			this.cmbFaclCode.FormattingEnabled = true;
			this.cmbFaclCode.Location = new System.Drawing.Point(255, 185);
			this.cmbFaclCode.Margin = new System.Windows.Forms.Padding(2);
			this.cmbFaclCode.Name = "cmbFaclCode";
			this.cmbFaclCode.Size = new System.Drawing.Size(171, 21);
			this.cmbFaclCode.TabIndex = 10;
			this.cmbFaclCode.SelectedIndexChanged += new System.EventHandler(this.cmbFaclCode_SelectedIndexChanged);
			// 
			// cmbFaclName
			// 
			this.cmbFaclName.FormattingEnabled = true;
			this.cmbFaclName.Location = new System.Drawing.Point(255, 162);
			this.cmbFaclName.Margin = new System.Windows.Forms.Padding(2);
			this.cmbFaclName.Name = "cmbFaclName";
			this.cmbFaclName.Size = new System.Drawing.Size(171, 21);
			this.cmbFaclName.TabIndex = 9;
			this.cmbFaclName.SelectedIndexChanged += new System.EventHandler(this.cmbFaclName_SelectedIndexChanged);
			// 
			// btnEditFaci
			// 
			this.btnEditFaci.Location = new System.Drawing.Point(313, 241);
			this.btnEditFaci.Name = "btnEditFaci";
			this.btnEditFaci.Size = new System.Drawing.Size(54, 23);
			this.btnEditFaci.TabIndex = 8;
			this.btnEditFaci.Text = "עדכון";
			this.btnEditFaci.UseVisualStyleBackColor = true;
			this.btnEditFaci.Click += new System.EventHandler(this.btnEditFaci_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(435, 216);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "ראש מגמה";
			// 
			// btnRemoveFaci
			// 
			this.btnRemoveFaci.Location = new System.Drawing.Point(255, 241);
			this.btnRemoveFaci.Name = "btnRemoveFaci";
			this.btnRemoveFaci.Size = new System.Drawing.Size(54, 23);
			this.btnRemoveFaci.TabIndex = 5;
			this.btnRemoveFaci.Text = "הורדה";
			this.btnRemoveFaci.UseVisualStyleBackColor = true;
			this.btnRemoveFaci.Click += new System.EventHandler(this.btnRemoveFaci_Click);
			// 
			// btnApproveFaci
			// 
			this.btnApproveFaci.Location = new System.Drawing.Point(371, 241);
			this.btnApproveFaci.Name = "btnApproveFaci";
			this.btnApproveFaci.Size = new System.Drawing.Size(55, 23);
			this.btnApproveFaci.TabIndex = 4;
			this.btnApproveFaci.Text = "הוספה";
			this.btnApproveFaci.UseVisualStyleBackColor = true;
			this.btnApproveFaci.Click += new System.EventHandler(this.btnApproveFaci_Click);
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(434, 191);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(56, 13);
			this.label21.TabIndex = 3;
			this.label21.Text = "קוד מגמה";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(437, 164);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(53, 13);
			this.label20.TabIndex = 2;
			this.label20.Text = "שם מגמה";
			// 
			// grSearch
			// 
			this.grSearch.Controls.Add(this.cmbSearch);
			this.grSearch.Controls.Add(this.btnStartSearch);
			this.grSearch.Controls.Add(this.lblSearch);
			this.grSearch.Location = new System.Drawing.Point(10, 13);
			this.grSearch.Name = "grSearch";
			this.grSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.grSearch.Size = new System.Drawing.Size(681, 428);
			this.grSearch.TabIndex = 30;
			this.grSearch.TabStop = false;
			this.grSearch.Text = "חפש נתונים לפי מספר רישוי";
			// 
			// cmbSearch
			// 
			this.cmbSearch.FormattingEnabled = true;
			this.cmbSearch.Location = new System.Drawing.Point(261, 159);
			this.cmbSearch.Margin = new System.Windows.Forms.Padding(2);
			this.cmbSearch.Name = "cmbSearch";
			this.cmbSearch.Size = new System.Drawing.Size(165, 21);
			this.cmbSearch.TabIndex = 5;
			this.cmbSearch.TextChanged += new System.EventHandler(this.cmbSearch_TextChanged);
			// 
			// btnStartSearch
			// 
			this.btnStartSearch.Location = new System.Drawing.Point(261, 187);
			this.btnStartSearch.Name = "btnStartSearch";
			this.btnStartSearch.Size = new System.Drawing.Size(165, 23);
			this.btnStartSearch.TabIndex = 4;
			this.btnStartSearch.Text = "התחל חיפוש";
			this.btnStartSearch.UseVisualStyleBackColor = true;
			this.btnStartSearch.Click += new System.EventHandler(this.btnStartSearch_Click);
			// 
			// lblSearch
			// 
			this.lblSearch.AutoSize = true;
			this.lblSearch.Location = new System.Drawing.Point(437, 164);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(67, 13);
			this.lblSearch.TabIndex = 2;
			this.lblSearch.Text = "מספר רישוי";
			// 
			// grPdf
			// 
			this.grPdf.Controls.Add(this.cmbPdfFormat);
			this.grPdf.Controls.Add(this.btnSaveToPDF);
			this.grPdf.Controls.Add(this.cmbChooseBy);
			this.grPdf.Controls.Add(this.cmbLabel);
			this.grPdf.Controls.Add(this.cmbChooseFaculty);
			this.grPdf.Controls.Add(this.cmbLessence);
			this.grPdf.Controls.Add(this.MyTable);
			this.grPdf.Controls.Add(this.rtbToPdf);
			this.grPdf.Location = new System.Drawing.Point(10, 10);
			this.grPdf.Name = "grPdf";
			this.grPdf.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.grPdf.Size = new System.Drawing.Size(681, 429);
			this.grPdf.TabIndex = 33;
			this.grPdf.TabStop = false;
			this.grPdf.Text = "יצירת דוחות";
			// 
			// cmbPdfFormat
			// 
			this.cmbPdfFormat.FormattingEnabled = true;
			this.cmbPdfFormat.Items.AddRange(new object[] {
            "List",
            "Table"});
			this.cmbPdfFormat.Location = new System.Drawing.Point(579, 21);
			this.cmbPdfFormat.Margin = new System.Windows.Forms.Padding(2);
			this.cmbPdfFormat.Name = "cmbPdfFormat";
			this.cmbPdfFormat.Size = new System.Drawing.Size(92, 21);
			this.cmbPdfFormat.TabIndex = 16;
			this.cmbPdfFormat.SelectedIndexChanged += new System.EventHandler(this.cmbPdfFormat_SelectedIndexChanged);
			// 
			// btnSaveToPDF
			// 
			this.btnSaveToPDF.Location = new System.Drawing.Point(295, 23);
			this.btnSaveToPDF.Margin = new System.Windows.Forms.Padding(2);
			this.btnSaveToPDF.Name = "btnSaveToPDF";
			this.btnSaveToPDF.Size = new System.Drawing.Size(56, 19);
			this.btnSaveToPDF.TabIndex = 13;
			this.btnSaveToPDF.Text = "לשמור דוח";
			this.btnSaveToPDF.UseVisualStyleBackColor = true;
			this.btnSaveToPDF.Click += new System.EventHandler(this.btnSaveToPDF_Click);
			// 
			// cmbChooseBy
			// 
			this.cmbChooseBy.FormattingEnabled = true;
			this.cmbChooseBy.Items.AddRange(new object[] {
            "Lessence Number",
            "Faculty",
            "Label Type"});
			this.cmbChooseBy.Location = new System.Drawing.Point(476, 21);
			this.cmbChooseBy.Margin = new System.Windows.Forms.Padding(2);
			this.cmbChooseBy.Name = "cmbChooseBy";
			this.cmbChooseBy.Size = new System.Drawing.Size(92, 21);
			this.cmbChooseBy.TabIndex = 9;
			this.cmbChooseBy.SelectedIndexChanged += new System.EventHandler(this.cmbChooseBy_SelectedIndexChanged);
			// 
			// cmbLabel
			// 
			this.cmbLabel.FormattingEnabled = true;
			this.cmbLabel.Location = new System.Drawing.Point(365, 21);
			this.cmbLabel.Margin = new System.Windows.Forms.Padding(2);
			this.cmbLabel.Name = "cmbLabel";
			this.cmbLabel.Size = new System.Drawing.Size(92, 21);
			this.cmbLabel.TabIndex = 12;
			this.cmbLabel.SelectedIndexChanged += new System.EventHandler(this.cmbLabel_SelectedIndexChanged);
			// 
			// cmbChooseFaculty
			// 
			this.cmbChooseFaculty.FormattingEnabled = true;
			this.cmbChooseFaculty.Location = new System.Drawing.Point(365, 21);
			this.cmbChooseFaculty.Margin = new System.Windows.Forms.Padding(2);
			this.cmbChooseFaculty.Name = "cmbChooseFaculty";
			this.cmbChooseFaculty.Size = new System.Drawing.Size(92, 21);
			this.cmbChooseFaculty.TabIndex = 11;
			this.cmbChooseFaculty.SelectedIndexChanged += new System.EventHandler(this.cmbChooseFaculty_SelectedIndexChanged);
			// 
			// cmbLessence
			// 
			this.cmbLessence.FormattingEnabled = true;
			this.cmbLessence.Location = new System.Drawing.Point(365, 21);
			this.cmbLessence.Margin = new System.Windows.Forms.Padding(2);
			this.cmbLessence.Name = "cmbLessence";
			this.cmbLessence.Size = new System.Drawing.Size(92, 21);
			this.cmbLessence.TabIndex = 10;
			this.cmbLessence.SelectedIndexChanged += new System.EventHandler(this.cmbLessence_SelectedIndexChanged);
			// 
			// MyTable
			// 
			this.MyTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.MyTable.Location = new System.Drawing.Point(6, 48);
			this.MyTable.Margin = new System.Windows.Forms.Padding(2);
			this.MyTable.Name = "MyTable";
			this.MyTable.RowTemplate.Height = 24;
			this.MyTable.Size = new System.Drawing.Size(669, 375);
			this.MyTable.TabIndex = 15;
			// 
			// rtbToPdf
			// 
			this.rtbToPdf.Location = new System.Drawing.Point(6, 47);
			this.rtbToPdf.Name = "rtbToPdf";
			this.rtbToPdf.Size = new System.Drawing.Size(670, 376);
			this.rtbToPdf.TabIndex = 14;
			this.rtbToPdf.Text = "";
			// 
			// btnManageCourse
			// 
			this.btnManageCourse.Location = new System.Drawing.Point(703, 123);
			this.btnManageCourse.Name = "btnManageCourse";
			this.btnManageCourse.Size = new System.Drawing.Size(75, 50);
			this.btnManageCourse.TabIndex = 34;
			this.btnManageCourse.Text = "הוספה עדכון קורסים";
			this.btnManageCourse.UseVisualStyleBackColor = true;
			this.btnManageCourse.Click += new System.EventHandler(this.btnManageCourse_Click);
			// 
			// grCourses
			// 
			this.grCourses.Controls.Add(this.cmbCourseCode);
			this.grCourses.Controls.Add(this.cmbCourseName);
			this.grCourses.Controls.Add(this.btnUpdateCourse);
			this.grCourses.Controls.Add(this.btnDeleteCourse);
			this.grCourses.Controls.Add(this.btnAddCourse);
			this.grCourses.Controls.Add(this.label2);
			this.grCourses.Controls.Add(this.label3);
			this.grCourses.Location = new System.Drawing.Point(5, 12);
			this.grCourses.Name = "grCourses";
			this.grCourses.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.grCourses.Size = new System.Drawing.Size(681, 428);
			this.grCourses.TabIndex = 35;
			this.grCourses.TabStop = false;
			this.grCourses.Text = "עדכון סוג קורס";
			// 
			// cmbCourseCode
			// 
			this.cmbCourseCode.FormattingEnabled = true;
			this.cmbCourseCode.Location = new System.Drawing.Point(242, 189);
			this.cmbCourseCode.Margin = new System.Windows.Forms.Padding(2);
			this.cmbCourseCode.Name = "cmbCourseCode";
			this.cmbCourseCode.Size = new System.Drawing.Size(169, 21);
			this.cmbCourseCode.TabIndex = 8;
			this.cmbCourseCode.SelectedIndexChanged += new System.EventHandler(this.cmbCourseCode_SelectedIndexChanged);
			// 
			// cmbCourseName
			// 
			this.cmbCourseName.FormattingEnabled = true;
			this.cmbCourseName.Location = new System.Drawing.Point(242, 161);
			this.cmbCourseName.Margin = new System.Windows.Forms.Padding(2);
			this.cmbCourseName.Name = "cmbCourseName";
			this.cmbCourseName.Size = new System.Drawing.Size(169, 21);
			this.cmbCourseName.TabIndex = 7;
			this.cmbCourseName.SelectedIndexChanged += new System.EventHandler(this.cmbCourseName_SelectedIndexChanged);
			// 
			// btnUpdateCourse
			// 
			this.btnUpdateCourse.Location = new System.Drawing.Point(242, 214);
			this.btnUpdateCourse.Name = "btnUpdateCourse";
			this.btnUpdateCourse.Size = new System.Drawing.Size(57, 23);
			this.btnUpdateCourse.TabIndex = 6;
			this.btnUpdateCourse.Text = "עדכון";
			this.btnUpdateCourse.UseVisualStyleBackColor = true;
			this.btnUpdateCourse.Click += new System.EventHandler(this.btnUpdateCourse_Click);
			// 
			// btnDeleteCourse
			// 
			this.btnDeleteCourse.Location = new System.Drawing.Point(305, 214);
			this.btnDeleteCourse.Name = "btnDeleteCourse";
			this.btnDeleteCourse.Size = new System.Drawing.Size(50, 23);
			this.btnDeleteCourse.TabIndex = 5;
			this.btnDeleteCourse.Text = "הורדה";
			this.btnDeleteCourse.UseVisualStyleBackColor = true;
			this.btnDeleteCourse.Click += new System.EventHandler(this.btnDeleteCourse_Click);
			// 
			// btnAddCourse
			// 
			this.btnAddCourse.Location = new System.Drawing.Point(361, 214);
			this.btnAddCourse.Name = "btnAddCourse";
			this.btnAddCourse.Size = new System.Drawing.Size(50, 23);
			this.btnAddCourse.TabIndex = 4;
			this.btnAddCourse.Text = "הוספה";
			this.btnAddCourse.UseVisualStyleBackColor = true;
			this.btnAddCourse.Click += new System.EventHandler(this.btnAddCourse_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(416, 192);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "קוד קורס";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(416, 165);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(51, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "שם קורס";
			// 
			// FrmParkingProject
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(787, 446);
			this.Controls.Add(this.btnManageCourse);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnReport);
			this.Controls.Add(this.btnManageFacult);
			this.Controls.Add(this.btnDetails);
			this.Controls.Add(this.btnManageParkLabel);
			this.Controls.Add(this.btnAddDetails);
			this.Controls.Add(this.grStudent);
			this.Controls.Add(this.grLabelTypes);
			this.Controls.Add(this.grSearch);
			this.Controls.Add(this.grFacultManage);
			this.Controls.Add(this.grCourses);
			this.Controls.Add(this.grPdf);
			this.Name = "FrmParkingProject";
			this.Text = "Parking Project";
			this.Load += new System.EventHandler(this.FrmParkingProject_Load);
			this.Resize += new System.EventHandler(this.FrmParkingProject_Resize);
			this.grStudent.ResumeLayout(false);
			this.grTeacherPersonal.ResumeLayout(false);
			this.grTeacherPersonal.PerformLayout();
			this.grInfo.ResumeLayout(false);
			this.grInfo.PerformLayout();
			this.grCar.ResumeLayout(false);
			this.grCar.PerformLayout();
			this.grPersonal.ResumeLayout(false);
			this.grPersonal.PerformLayout();
			this.grStudentPersonal.ResumeLayout(false);
			this.grStudentPersonal.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.grLabelTypes.ResumeLayout(false);
			this.grLabelTypes.PerformLayout();
			this.grFacultManage.ResumeLayout(false);
			this.grFacultManage.PerformLayout();
			this.grSearch.ResumeLayout(false);
			this.grSearch.PerformLayout();
			this.grPdf.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MyTable)).EndInit();
			this.grCourses.ResumeLayout(false);
			this.grCourses.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddDetails;
        private System.Windows.Forms.Button btnManageFacult;
        private System.Windows.Forms.Button btnManageParkLabel;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox grStudent;
        private System.Windows.Forms.Button btnCreatePerson;
        private System.Windows.Forms.GroupBox grInfo;
        private System.Windows.Forms.DateTimePicker dateUntil;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblUntil;
        private System.Windows.Forms.Label lblTypeOfApproval;
        private System.Windows.Forms.Label lblCodeOfApproval;
        private System.Windows.Forms.GroupBox grCar;
        private System.Windows.Forms.TextBox txtLessenNumber;
        private System.Windows.Forms.TextBox txtCarCreator;
        private System.Windows.Forms.TextBox txtCarColor;
        private System.Windows.Forms.TextBox txtCarOwner;
        private System.Windows.Forms.Label lblLessenNumber;
        private System.Windows.Forms.Label lblCarCreator;
        private System.Windows.Forms.Label lblCarColor;
        private System.Windows.Forms.Label lblCarOwner;
        private System.Windows.Forms.GroupBox grPersonal;
        private System.Windows.Forms.RadioButton rdoTeacher;
        private System.Windows.Forms.RadioButton rdoStudent;
        private System.Windows.Forms.GroupBox grStudentPersonal;
        private System.Windows.Forms.ComboBox CmbHeadOfFaculty;
        private System.Windows.Forms.ComboBox CmbFaculty;
        private System.Windows.Forms.RadioButton rdoYear3;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.RadioButton rdoYear2;
        private System.Windows.Forms.RadioButton rdoYear1;
        private System.Windows.Forms.Label lblFacility;
        private System.Windows.Forms.Label lblHeadOfFacility;
        private System.Windows.Forms.TextBox txtFamilyName;
        private System.Windows.Forms.Label lblFamilyName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblIdNumber;
        private System.Windows.Forms.Label LblTelephone;
        private System.Windows.Forms.Label lblTelephone2;
        private System.Windows.Forms.ComboBox CmbTelephone2;
        private System.Windows.Forms.TextBox TxtTelephone2;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.ComboBox cmbTypeOfApproval;
        private System.Windows.Forms.TextBox TxtTelephone;
        private System.Windows.Forms.GroupBox grFacultManage;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnApproveFaci;
        private System.Windows.Forms.GroupBox grLabelTypes;
        private System.Windows.Forms.Button btnLabelRemove;
        private System.Windows.Forms.Button btnLabelAdd;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox CmbTelephone;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblStudyType;
        private System.Windows.Forms.RadioButton rdoStudyType1;
        private System.Windows.Forms.RadioButton rdoStudyType2;
        private System.Windows.Forms.RadioButton rdoStudyType3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRemovePerson;
        private System.Windows.Forms.Button btnRemoveFaci;
        private System.Windows.Forms.Button btnEditPerson;
        private System.Windows.Forms.GroupBox grSearch;
        private System.Windows.Forms.Button btnStartSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ComboBox cmbIdNumber;
        private System.Windows.Forms.ComboBox cmbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCodeOfApproval;
        private System.Windows.Forms.Button btnLabelEdit;
        private System.Windows.Forms.ComboBox cmbLabelCode;
        private System.Windows.Forms.ComboBox cmbLabelType;
        private System.Windows.Forms.Button btnEditFaci;
        private System.Windows.Forms.ComboBox cmbFaclHead;
        private System.Windows.Forms.ComboBox cmbFaclCode;
        private System.Windows.Forms.ComboBox cmbFaclName;
        private System.Windows.Forms.GroupBox grPdf;
        private System.Windows.Forms.Button btnSaveToPDF;
        private System.Windows.Forms.ComboBox cmbChooseBy;
        private System.Windows.Forms.ComboBox cmbLabel;
        private System.Windows.Forms.ComboBox cmbChooseFaculty;
        private System.Windows.Forms.ComboBox cmbLessence;
        private System.Windows.Forms.Button btnManageCourse;
        private System.Windows.Forms.GroupBox grCourses;
        private System.Windows.Forms.ComboBox cmbCourseCode;
        private System.Windows.Forms.ComboBox cmbCourseName;
        private System.Windows.Forms.Button btnUpdateCourse;
        private System.Windows.Forms.Button btnDeleteCourse;
        private System.Windows.Forms.Button btnAddCourse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grTeacherPersonal;
        private System.Windows.Forms.ComboBox CmbCodeOfFaculty;
        private System.Windows.Forms.Label lblCodeOfFacility;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.RichTextBox rtbToPdf;
        private System.Windows.Forms.ComboBox cmbPdfFormat;
        private System.Windows.Forms.DataGridView MyTable;
    }
}

