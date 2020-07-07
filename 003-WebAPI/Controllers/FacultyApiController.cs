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
	public class FacultyApiController : ApiController
    {
		private IFacultyRepository facultyRepository;
		public FacultyApiController()
		{
			if (GlobalVariable.logicType == 0)
				facultyRepository = new EntityFacultyManager();
			else if (GlobalVariable.logicType == 1)
				facultyRepository = new SqlFacultyManager();
			else if (GlobalVariable.logicType == 2)
				facultyRepository = new MySqlFacultyManager();
			else if (GlobalVariable.logicType == 3)
				facultyRepository = new InnerFacultyManager();
			else
				facultyRepository = new MongoFacultyManager();
		}


		[HttpGet]
		[Route("faculties")]
		public HttpResponseMessage GetAllFaculties()
		{
			try
			{
				List<FacultyModel> allFaculties = facultyRepository.GetAllFaculties();
				return Request.CreateResponse(HttpStatusCode.OK, allFaculties);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("faculties/{facultyCode}")]
		public HttpResponseMessage GetOneFacultyByCode(string facultyCode)
		{
			try
			{
				FacultyModel facultyModel = facultyRepository.GetOneFacultyByCode(facultyCode);
				return Request.CreateResponse(HttpStatusCode.OK, facultyModel);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPost]
		[Route("faculties")]
		public HttpResponseMessage AddFaculty(FacultyModel facultyModel)
		{
			try
			{
				if (facultyModel == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				FacultyModel addedFaculty = facultyRepository.AddFaculty(facultyModel);
				return Request.CreateResponse(HttpStatusCode.Created, addedFaculty);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPut]
		[Route("faculties/{facultyCode}")]
		public HttpResponseMessage UpdateFaculty(string facultyCode, FacultyModel facultyModel)
		{
			try
			{
				if (facultyModel == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				facultyModel.facultyCode = facultyCode;
				FacultyModel updatedFaculty = facultyRepository.UpdateFaculty(facultyModel);
				return Request.CreateResponse(HttpStatusCode.OK, updatedFaculty);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}



		[HttpDelete]
		[Route("faculties/{facultyCode}")]
		public HttpResponseMessage DeleteFaculty(string facultyCode)
		{
			try
			{
				int i = facultyRepository.DeleteFaculty(facultyCode);
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
