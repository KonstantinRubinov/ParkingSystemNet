using ParkingSystem.EntityDataBase;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
	public class EntityStudentManager : EntityBaseManager, IStudentRepository
	{
		public List<StudentModel> GetAllStudents()
		{
			var resultQuary = DB.STUDENTS.Select(s => new StudentModel
			{
				personId = s.PERSON.personId,
				personFirstName = s.PERSON.personFirstName,
				personLastName = s.PERSON.personLastName,
				personBeforeTelephone = s.PERSON.personBeforeTelephone,
				personTelephone = s.PERSON.personTelephone,
				personBeforeCellphone = s.PERSON.personBeforeCellphone,
				personCellphone = s.PERSON.personCellphone,
				personCode = s.PERSON.personCode,
				studentId = s.studentId,
				studentType = s.studentType,
				studentYear = s.studentYear,
				studentFacultyCode = s.studentFacultyCode
			});

			var resultSP = DB.GetAllStudents().Select(s => new StudentModel
			{
				personId = s.personId,
				personFirstName = s.personFirstName,
				personLastName = s.personLastName,
				personBeforeTelephone = s.personBeforeTelephone,
				personTelephone = s.personTelephone,
				personBeforeCellphone = s.personBeforeCellphone,
				personCellphone = s.personCellphone,
				personCode = s.personCode,
				studentId = s.studentId,
				studentType = s.studentType,
				studentYear = s.studentYear,
				studentFacultyCode = s.studentFacultyCode
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.ToList();
			else
				return resultSP.ToList();
		}


		public StudentModel GetOneStudentById(string studentId)
		{
			var resultQuary = DB.STUDENTS.Where(s => s.studentId.Equals(studentId)).Select(s => new StudentModel
			{
				personId = s.PERSON.personId,
				personFirstName = s.PERSON.personFirstName,
				personLastName = s.PERSON.personLastName,
				personBeforeTelephone = s.PERSON.personBeforeTelephone,
				personTelephone = s.PERSON.personTelephone,
				personBeforeCellphone = s.PERSON.personBeforeCellphone,
				personCellphone = s.PERSON.personCellphone,
				personCode = s.PERSON.personCode,
				studentId = s.studentId,
				studentType = s.studentType,
				studentYear = s.studentYear,
				studentFacultyCode = s.studentFacultyCode
			});

			var resultSP = DB.GetOneStudentById(studentId).Select(s => new StudentModel
			{
				personId = s.personId,
				personFirstName = s.personFirstName,
				personLastName = s.personLastName,
				personBeforeTelephone = s.personBeforeTelephone,
				personTelephone = s.personTelephone,
				personBeforeCellphone = s.personBeforeCellphone,
				personCellphone = s.personCellphone,
				personCode = s.personCode,
				studentId = s.studentId,
				studentType = s.studentType,
				studentYear = s.studentYear,
				studentFacultyCode = s.studentFacultyCode
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.SingleOrDefault();
			else
				return resultSP.SingleOrDefault();
		}


		public StudentModel AddStudent(StudentModel studentModel)
		{
			var resultSP = DB.AddStudent(studentModel.personId, studentModel.personFirstName, studentModel.personLastName, studentModel.personBeforeTelephone, studentModel.personTelephone, studentModel.personBeforeCellphone, studentModel.personCellphone, studentModel.personCode, studentModel.studentId, studentModel.studentFacultyCode, studentModel.studentYear, studentModel.studentType).Select(s => new StudentModel
			{
				personId = s.personId,
				personFirstName = s.personFirstName,
				personLastName = s.personLastName,
				personBeforeTelephone = s.personBeforeTelephone,
				personTelephone = s.personTelephone,
				personBeforeCellphone = s.personBeforeCellphone,
				personCellphone = s.personCellphone,
				personCode = s.personCode,
				studentId = s.studentId,
				studentType = s.studentType,
				studentYear = s.studentYear,
				studentFacultyCode = s.studentFacultyCode
			});

			if (GlobalVariable.queryType == 0)
				return AddStudentQuery(studentModel);
			else
				return resultSP.SingleOrDefault();
		}


		public StudentModel UpdateStudent(StudentModel studentModel)
		{
			var resultSP = DB.UpdateStudent(studentModel.personId, studentModel.personFirstName, studentModel.personLastName, studentModel.personBeforeTelephone, studentModel.personTelephone, studentModel.personBeforeCellphone, studentModel.personCellphone, studentModel.personCode, studentModel.studentId, studentModel.studentFacultyCode, studentModel.studentYear, studentModel.studentType).Select(s => new StudentModel
			{
				personId = s.personId,
				personFirstName = s.personFirstName,
				personLastName = s.personLastName,
				personBeforeTelephone = s.personBeforeTelephone,
				personTelephone = s.personTelephone,
				personBeforeCellphone = s.personBeforeCellphone,
				personCellphone = s.personCellphone,
				personCode = s.personCode,
				studentId = s.studentId,
				studentType = s.studentType,
				studentYear = s.studentYear,
				studentFacultyCode = s.studentFacultyCode
			});

			if (GlobalVariable.queryType == 0)
				return UpdateStudentQuery(studentModel);
			else
				return resultSP.SingleOrDefault();
		}


		public int DeleteStudent(string studentId)
		{
			var resultSP = DB.DeleteStudent(studentId);

			if (GlobalVariable.queryType == 0)
			{
				PERSON person = DB.PERSONS.Where(p => p.personId.Equals(studentId)).SingleOrDefault();
				STUDENT student = DB.STUDENTS.Where(s => s.studentId.Equals(studentId)).SingleOrDefault();
				DB.PERSONS.Attach(person);
				DB.STUDENTS.Attach(student);
				if (person == null || student == null)
					return 0;
				DB.STUDENTS.Remove(student);
				DB.PERSONS.Remove(person);
				DB.SaveChanges();
				return 1;
			}
			else
				return resultSP;
		}





		private StudentModel AddStudentQuery(StudentModel studentModel)
		{
			PERSON person = new PERSON
			{
				personId = studentModel.personId,
				personFirstName = studentModel.personFirstName,
				personLastName = studentModel.personLastName,
				personBeforeTelephone = studentModel.personBeforeTelephone,
				personTelephone = studentModel.personTelephone,
				personBeforeCellphone = studentModel.personBeforeCellphone,
				personCellphone = studentModel.personCellphone,
				personCode = studentModel.personCode
			};

			STUDENT student = new STUDENT
			{
				studentId = studentModel.studentId,
				studentType = studentModel.studentType,
				studentYear = studentModel.studentYear,
				studentFacultyCode = studentModel.studentFacultyCode
			};

			DB.PERSONS.Add(person);
			DB.STUDENTS.Add(student);
			DB.SaveChanges();
			return GetOneStudentById(student.studentId);
		}

		private StudentModel UpdateStudentQuery(StudentModel studentModel)
		{
			PERSON person = DB.PERSONS.Where(p => p.personId.Equals(studentModel.personId)).SingleOrDefault();
			if (person == null)
				return null;
			person.personId = studentModel.personId;
			person.personFirstName = studentModel.personFirstName;
			person.personLastName = studentModel.personLastName;
			person.personBeforeTelephone = studentModel.personBeforeTelephone;
			person.personTelephone = studentModel.personTelephone;
			person.personBeforeCellphone = studentModel.personBeforeCellphone;
			person.personCellphone = studentModel.personCellphone;
			person.personCode = studentModel.personCode;

			STUDENT student = DB.STUDENTS.Where(s => s.studentId.Equals(studentModel.studentId)).SingleOrDefault();
			if (person == null)
				return null;
			student.studentId = studentModel.studentId;
			student.studentType = studentModel.studentType;
			student.studentYear = studentModel.studentYear;
			student.studentFacultyCode = studentModel.studentFacultyCode;
			DB.SaveChanges();
			return GetOneStudentById(student.studentId);
		}
	}
}
