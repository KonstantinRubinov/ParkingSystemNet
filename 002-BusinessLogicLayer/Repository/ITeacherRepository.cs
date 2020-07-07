using System.Collections.Generic;

namespace ParkingSystem
{
	public interface ITeacherRepository
	{
		List<TeacherModel> GetAllTeachers();
		TeacherModel GetOneTeacherById(string teacherId);
		TeacherModel AddTeacher(TeacherModel teacherModel);
		TeacherModel UpdateTeacher(TeacherModel teacherModel);
		int DeleteTeacher(string teacherId);
	}
}
