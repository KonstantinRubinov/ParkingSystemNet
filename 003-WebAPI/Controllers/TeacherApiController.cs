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
	public class TeacherApiController : ApiController
    {
		private ITeacherRepository teacherRepository;
		public TeacherApiController(ITeacherRepository _teacherRepository)
		{
			teacherRepository = _teacherRepository;
		}

		[HttpGet]
		[Route("teachers")]
		public HttpResponseMessage GetAllTeachers()
		{
			try
			{
				List<TeacherModel> allTeachers = teacherRepository.GetAllTeachers();
				return Request.CreateResponse(HttpStatusCode.OK, allTeachers);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("teachers/{teacherId}")]
		public HttpResponseMessage GetOneTeacherById(string teacherId)
		{
			try
			{
				TeacherModel teacherModel = teacherRepository.GetOneTeacherById(teacherId);
				return Request.CreateResponse(HttpStatusCode.OK, teacherModel);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPost]
		[Route("teachers")]
		public HttpResponseMessage AddTeacher(TeacherModel teacherModel)
		{
			try
			{
				if (teacherModel == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				TeacherModel addedTeacher = teacherRepository.AddTeacher(teacherModel);
				return Request.CreateResponse(HttpStatusCode.Created, addedTeacher);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPut]
		[Route("teachers/{teacherId}")]
		public HttpResponseMessage UpdateTeacher(string teacherId, TeacherModel teacherModel)
		{
			try
			{
				if (teacherModel == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				teacherModel.teacherId = teacherId;
				TeacherModel updatedTeacher = teacherRepository.UpdateTeacher(teacherModel);
				return Request.CreateResponse(HttpStatusCode.OK, updatedTeacher);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpDelete]
		[Route("teachers/{teacherId}")]
		public HttpResponseMessage DeleteTeacher(string teacherId)
		{
			try
			{
				int i = teacherRepository.DeleteTeacher(teacherId);
				return Request.CreateResponse(HttpStatusCode.NoContent);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}
	}
}
