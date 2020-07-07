using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace ParkingSystem
{
	public class MongoCourseManager : ICourseRepository
	{
		private readonly IMongoCollection<CourseModel> _course;

		public MongoCourseManager()
		{
			var client = new MongoClient(ConnectionStrings.ConnectionString);
			var database = client.GetDatabase(ConnectionStrings.DatabaseName);

			_course = database.GetCollection<CourseModel>(ConnectionStrings.CourseCollectionName);
		}

		public List<CourseModel> GetAllCourses()
		{
			return _course.Find(course => true).Project(co => new CourseModel
			{
				courseCode = co.courseCode,
				courseName = co.courseName
			}).ToList();
		}


		public CourseModel GetOneCourseByCode(string courseCode)
		{
			if (courseCode.Equals(string.Empty))
				throw new ArgumentOutOfRangeException();

			return _course.Find<CourseModel>(Builders<CourseModel>.Filter.Eq(course => course.courseCode, courseCode)).Project(co => new CourseModel
			{
				courseCode = co.courseCode,
				courseName = co.courseName
			}).FirstOrDefault();
		}

		public CourseModel AddCourse(CourseModel courseModel)
		{
			if (GetOneCourseByCode(courseModel.courseCode) == null)
			{
				_course.InsertOne(courseModel);
			}

			CourseModel tmpCourseModel = GetOneCourseByCode(courseModel.courseCode);
			return tmpCourseModel;
		}


		public CourseModel UpdateCourse(CourseModel courseModel)
		{
			_course.ReplaceOne(course => course.courseCode.Equals(courseModel.courseCode), courseModel);
			CourseModel tmpCourseModel = GetOneCourseByCode(courseModel.courseCode);
			return tmpCourseModel;
		}

		public int DeleteCourse(string courseCode)
		{
			_course.DeleteOne(course => course.courseCode.Equals(courseCode));
			return 1;
		}
	}
}
