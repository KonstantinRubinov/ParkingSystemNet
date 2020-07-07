using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ParkingSystem
{
	[EnableCors("*", "*", "*")]
	[RoutePrefix("api")]
	public class CourseApiController : ApiController
    {
		private ICourseRepository courseRepository;
		public CourseApiController()
		{
			if (GlobalVariable.logicType == 0)
				courseRepository = new EntityCourseManager();
			else if (GlobalVariable.logicType == 1)
				courseRepository = new SqlCourseManager();
			else if (GlobalVariable.logicType == 2)
				courseRepository = new MySqlCourseManager();
			else if (GlobalVariable.logicType == 3)
				courseRepository = new InnerCourseManager();
			else
				courseRepository = new MongoCourseManager();
		}

		[HttpGet]
		[Route("courses")]
		public HttpResponseMessage GetAllCourses()
		{
			try
			{
				List<CourseModel> allCourses = courseRepository.GetAllCourses();
				return Request.CreateResponse(HttpStatusCode.OK, allCourses);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("courses/{courseCode}")]
		public HttpResponseMessage GetOneCourseByCode(string courseCode)
		{
			try
			{
				CourseModel courseModel = courseRepository.GetOneCourseByCode(courseCode);
				return Request.CreateResponse(HttpStatusCode.OK, courseModel);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}


		[HttpPost]
		[Route("courses")]
		public HttpResponseMessage AddCourse(CourseModel courseModel)
		{
			try
			{
				if (courseModel == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				CourseModel addedCourse = courseRepository.AddCourse(courseModel);
				return Request.CreateResponse(HttpStatusCode.Created, addedCourse);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}


		[HttpPut]
		[Route("courses/{courseCode}")]
		public HttpResponseMessage UpdateCourse(string courseCode, CourseModel courseModel)
		{
			try
			{
				if (courseModel == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				courseModel.courseCode = courseCode;
				CourseModel updatedCourse = courseRepository.UpdateCourse(courseModel);
				return Request.CreateResponse(HttpStatusCode.OK, updatedCourse);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpDelete]
		[Route("courses/{courseCode}")]
		public HttpResponseMessage DeleteCourse(string courseCode)
		{
			try
			{
				int i = courseRepository.DeleteCourse(courseCode);
				if (i > 0)
				{
					return Request.CreateResponse(HttpStatusCode.NoContent);
				}
				return Request.CreateResponse(HttpStatusCode.InternalServerError);

			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

	}
}
