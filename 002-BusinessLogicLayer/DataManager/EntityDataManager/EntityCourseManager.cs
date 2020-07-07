using ParkingSystem.EntityDataBase;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
	public class EntityCourseManager : EntityBaseManager, ICourseRepository
	{
		public List<CourseModel> GetAllCourses()
		{
			var resultQuary = DB.COURSES.Select(c => new CourseModel
			{
				courseCode = c.courseCode,
				courseName = c.courseName
			});

			var resultSP = DB.GetAllCourses().Select(c => new CourseModel
			{
				courseCode = c.courseCode,
				courseName = c.courseName
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.ToList();
			else
				return resultSP.ToList();
		}


		public CourseModel GetOneCourseByCode(string courseCode)
		{
			var resultQuary = DB.COURSES.Where(c => c.courseCode.Equals(courseCode)).Select(c => new CourseModel
			{
				courseCode = c.courseCode,
				courseName = c.courseName
			});

			var resultSP = DB.GetOneCourseByCode(courseCode).Select(c => new CourseModel
			{
				courseCode = c.courseCode,
				courseName = c.courseName
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.SingleOrDefault();
			else
				return resultSP.SingleOrDefault();
		}


		public CourseModel AddCourse(CourseModel courseModel)
		{
			var resultSP = DB.AddCourse(courseModel.courseCode, courseModel.courseName).Select(c => new CourseModel
			{
				courseCode = c.courseCode,
				courseName = c.courseName
			});

			if (GlobalVariable.queryType == 0)
			{
				COURS course = new COURS
				{
					courseCode = courseModel.courseCode,
					courseName = courseModel.courseName
				};
				DB.COURSES.Add(course);
				DB.SaveChanges();
				return GetOneCourseByCode(course.courseCode);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public CourseModel UpdateCourse(CourseModel courseModel)
		{
			var resultSP = DB.UpdateCourse(courseModel.courseCode, courseModel.courseName).Select(c => new CourseModel
			{
				courseCode = c.courseCode,
				courseName = c.courseName
			});

			if (GlobalVariable.queryType == 0)
			{
				COURS course = DB.COURSES.Where(c => c.courseCode.Equals(courseModel.courseCode)).SingleOrDefault();
				if (course == null)
					return null;
				course.courseCode = courseModel.courseCode;
				course.courseName = courseModel.courseName;
				DB.SaveChanges();
				return GetOneCourseByCode(course.courseCode);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public int DeleteCourse(string courseCode)
		{
			var resultSP = DB.DeleteCourse(courseCode);

			if (GlobalVariable.queryType == 0)
			{
				COURS course = DB.COURSES.Where(c => c.courseCode.Equals(courseCode)).SingleOrDefault();
				DB.COURSES.Attach(course);
				if (course == null)
					return 0;
				DB.COURSES.Remove(course);
				DB.SaveChanges();
				return 1;
			}
			else
				return resultSP;
		}
	}
}
