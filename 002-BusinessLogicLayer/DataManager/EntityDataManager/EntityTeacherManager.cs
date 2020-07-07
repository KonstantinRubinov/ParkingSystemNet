using ParkingSystem.EntityDataBase;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
	public class EntityTeacherManager : EntityBaseManager, ITeacherRepository
	{
		public List<TeacherModel> GetAllTeachers()
		{
			var resultQuary = DB.TEACHERS.Select(t => new TeacherModel
			{
				personId = t.PERSON.personId,
				personFirstName = t.PERSON.personFirstName,
				personLastName = t.PERSON.personLastName,
				personBeforeTelephone = t.PERSON.personBeforeTelephone,
				personTelephone = t.PERSON.personTelephone,
				personBeforeCellphone = t.PERSON.personBeforeCellphone,
				personCellphone = t.PERSON.personCellphone,
				personCode = t.PERSON.personCode,
				teacherId = t.teacherId,
				teacherFacultyCode = t.teacherFacultyCode,
				teacherStage = t.teacherStage
			});

			var resultSP = DB.GetAllTeachers().Select(t => new TeacherModel
			{
				personId = t.personId,
				personFirstName = t.personFirstName,
				personLastName = t.personLastName,
				personBeforeTelephone = t.personBeforeTelephone,
				personTelephone = t.personTelephone,
				personBeforeCellphone = t.personBeforeCellphone,
				personCellphone = t.personCellphone,
				personCode = t.personCode,
				teacherId = t.teacherId,
				teacherFacultyCode = t.teacherFacultyCode,
				teacherStage = t.teacherStage
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.ToList();
			else
				return resultSP.ToList();
		}


		public TeacherModel GetOneTeacherById(string teacherId)
		{
			var resultQuary = DB.TEACHERS.Where(t => t.teacherId.Equals(teacherId)).Select(t => new TeacherModel
			{
				personId = t.PERSON.personId,
				personFirstName = t.PERSON.personFirstName,
				personLastName = t.PERSON.personLastName,
				personBeforeTelephone = t.PERSON.personBeforeTelephone,
				personTelephone = t.PERSON.personTelephone,
				personBeforeCellphone = t.PERSON.personBeforeCellphone,
				personCellphone = t.PERSON.personCellphone,
				personCode = t.PERSON.personCode,
				teacherId = t.teacherId,
				teacherFacultyCode = t.teacherFacultyCode,
				teacherStage = t.teacherStage
			});

			var resultSP = DB.GetOneTeacherById(teacherId).Select(t => new TeacherModel
			{
				personId = t.personId,
				personFirstName = t.personFirstName,
				personLastName = t.personLastName,
				personBeforeTelephone = t.personBeforeTelephone,
				personTelephone = t.personTelephone,
				personBeforeCellphone = t.personBeforeCellphone,
				personCellphone = t.personCellphone,
				personCode = t.personCode,
				teacherId = t.teacherId,
				teacherFacultyCode = t.teacherFacultyCode,
				teacherStage = t.teacherStage
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.SingleOrDefault();
			else
				return resultSP.SingleOrDefault();
		}


		public TeacherModel AddTeacher(TeacherModel teacherModel)
		{
			var resultSP = DB.AddTeacher(teacherModel.personId, teacherModel.personFirstName, teacherModel.personLastName, teacherModel.personBeforeTelephone, teacherModel.personTelephone, teacherModel.personBeforeCellphone, teacherModel.personCellphone, teacherModel.personCode, teacherModel.teacherId, teacherModel.teacherFacultyCode, teacherModel.teacherStage).Select(t => new TeacherModel
			{
				personId = t.personId,
				personFirstName = t.personFirstName,
				personLastName = t.personLastName,
				personBeforeTelephone = t.personBeforeTelephone,
				personTelephone = t.personTelephone,
				personBeforeCellphone = t.personBeforeCellphone,
				personCellphone = t.personCellphone,
				personCode = t.personCode,
				teacherId = t.teacherId,
				teacherFacultyCode = t.teacherFacultyCode,
				teacherStage = t.teacherStage
			});

			if (GlobalVariable.queryType == 0)
				return AddTeacherQuery(teacherModel);
			else
				return resultSP.SingleOrDefault();
		}


		public TeacherModel UpdateTeacher(TeacherModel teacherModel)
		{
			var resultSP = DB.UpdateTeacher(teacherModel.personId, teacherModel.personFirstName, teacherModel.personLastName, teacherModel.personBeforeTelephone, teacherModel.personTelephone, teacherModel.personBeforeCellphone, teacherModel.personCellphone, teacherModel.personCode, teacherModel.teacherId, teacherModel.teacherFacultyCode, teacherModel.teacherStage).Select(t => new TeacherModel
			{
				personId = t.personId,
				personFirstName = t.personFirstName,
				personLastName = t.personLastName,
				personBeforeTelephone = t.personBeforeTelephone,
				personTelephone = t.personTelephone,
				personBeforeCellphone = t.personBeforeCellphone,
				personCellphone = t.personCellphone,
				personCode = t.personCode,
				teacherId = t.teacherId,
				teacherFacultyCode = t.teacherFacultyCode,
				teacherStage = t.teacherStage
			});

			if (GlobalVariable.queryType == 0)
				return UpdateTeacherQuery(teacherModel);
			else
				return resultSP.SingleOrDefault();
		}


		public int DeleteTeacher(string teacherId)
		{
			var resultSP = DB.DeleteTeacher(teacherId);

			if (GlobalVariable.queryType == 0)
			{
				PERSON person = DB.PERSONS.Where(p => p.personId.Equals(teacherId)).SingleOrDefault();
				TEACHER teacher = DB.TEACHERS.Where(t => t.teacherId.Equals(teacherId)).SingleOrDefault();
				DB.PERSONS.Attach(person);
				DB.TEACHERS.Attach(teacher);
				if (person == null || teacher == null)
					return 0;
				DB.TEACHERS.Remove(teacher);
				DB.PERSONS.Remove(person);
				DB.SaveChanges();
				return 1;
			}
			else
				return resultSP;
		}




		private TeacherModel AddTeacherQuery(TeacherModel teacherModel)
		{
			PERSON person = new PERSON
			{
				personId = teacherModel.personId,
				personFirstName = teacherModel.personFirstName,
				personLastName = teacherModel.personLastName,
				personBeforeTelephone = teacherModel.personBeforeTelephone,
				personTelephone = teacherModel.personTelephone,
				personBeforeCellphone = teacherModel.personBeforeCellphone,
				personCellphone = teacherModel.personCellphone,
				personCode = teacherModel.personCode
			};

			TEACHER teacher = new TEACHER
			{
				teacherId = teacherModel.teacherId,
				teacherFacultyCode = teacherModel.teacherFacultyCode,
				teacherStage = teacherModel.teacherStage
			};

			DB.PERSONS.Add(person);
			DB.TEACHERS.Add(teacher);
			DB.SaveChanges();
			return GetOneTeacherById(teacher.teacherId);
		}

		private TeacherModel UpdateTeacherQuery(TeacherModel teacherModel)
		{
			PERSON person = DB.PERSONS.Where(p => p.personId.Equals(teacherModel.personId)).SingleOrDefault();
			if (person == null)
				return null;
			person.personId = teacherModel.personId;
			person.personFirstName = teacherModel.personFirstName;
			person.personLastName = teacherModel.personLastName;
			person.personBeforeTelephone = teacherModel.personBeforeTelephone;
			person.personTelephone = teacherModel.personTelephone;
			person.personBeforeCellphone = teacherModel.personBeforeCellphone;
			person.personCellphone = teacherModel.personCellphone;
			person.personCode = teacherModel.personCode;

			TEACHER teacher = DB.TEACHERS.Where(t => t.teacherId.Equals(teacherModel.teacherId)).SingleOrDefault();
			if (teacher == null)
				return null;
			teacher.teacherId = teacherModel.teacherId;
			teacher.teacherFacultyCode = teacherModel.teacherFacultyCode;
			teacher.teacherStage = teacherModel.teacherStage;
			DB.SaveChanges();
			return GetOneTeacherById(teacher.teacherId);
		}
	}
}
