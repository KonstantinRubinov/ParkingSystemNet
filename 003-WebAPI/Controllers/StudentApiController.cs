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
	public class StudentApiController : ApiController
    {
		private IStudentRepository studentRepository;
		public StudentApiController(IStudentRepository _studentRepository)
		{
			studentRepository = _studentRepository;
		}

		[HttpGet]
		[Route("students")]
		public HttpResponseMessage GetAllStudents()
		{
			try
			{
				List<StudentModel> allStudents = studentRepository.GetAllStudents();
				return Request.CreateResponse(HttpStatusCode.OK, allStudents);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("students/{studentId}")]
		public HttpResponseMessage GetOneStudentById(string studentId)
		{
			try
			{
				StudentModel studentModel = studentRepository.GetOneStudentById(studentId);
				return Request.CreateResponse(HttpStatusCode.OK, studentModel);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPost]
		[Route("students")]
		public HttpResponseMessage AddStudent(StudentModel studentModel)
		{
			try
			{
				if (studentModel == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				StudentModel addedStudent = studentRepository.AddStudent(studentModel);
				return Request.CreateResponse(HttpStatusCode.Created, addedStudent);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPut]
		[Route("students/{studentId}")]
		public HttpResponseMessage UpdateStudent(string studentId, StudentModel studentModel)
		{
			try
			{
				if (studentModel == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				studentModel.studentId = studentId;
				StudentModel updatedStudent = studentRepository.UpdateStudent(studentModel);
				return Request.CreateResponse(HttpStatusCode.OK, updatedStudent);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpDelete]
		[Route("students/{studentId}")]
		public HttpResponseMessage DeleteStudent(string studentId)
		{
			try
			{
				int i = studentRepository.DeleteStudent(studentId);
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
