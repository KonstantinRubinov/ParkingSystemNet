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
	public class PersonApiController : ApiController
    {
		private IPersonRepository personRepository;
		private IStudentRepository studentRepository;
		private ITeacherRepository teacherRepository;

		public PersonApiController()
		{
			if (GlobalVariable.logicType == 0)
			{
				personRepository = new EntityPersonManager();
				studentRepository = new EntityStudentManager();
				teacherRepository = new EntityTeacherManager();
			}
			else if (GlobalVariable.logicType == 1)
			{
				personRepository = new SqlPersonManager();
				studentRepository = new SqlStudentManager();
				teacherRepository = new SqlTeacherManager();
			}
			else if (GlobalVariable.logicType == 2)
			{
				personRepository = new MySqlPersonManager();
				studentRepository = new MySqlStudentManager();
				teacherRepository = new MySqlTeacherManager();
			}
			else if (GlobalVariable.logicType == 3)
			{
				personRepository = new InnerPersonManager();
				studentRepository = new InnerStudentManager();
				teacherRepository = new InnerTeacherManager();
			}
			else
			{
				personRepository = new MongoPersonManager();
				studentRepository = new MongoStudentManager();
				teacherRepository = new MongoTeacherManager();
			}
		}


		[HttpGet]
		[Route("persons")]
		public HttpResponseMessage GetAllPerson()
		{
			try
			{
				List<PersonModel> allPersons = personRepository.GetAllPersons();
				return Request.CreateResponse(HttpStatusCode.OK, allPersons);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("persons/id")]
		public HttpResponseMessage GetAllPersonsId()
		{
			try
			{
				List<PersonModel> allPersonsId = personRepository.GetAllPersonsId();
				return Request.CreateResponse(HttpStatusCode.OK, allPersonsId);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpDelete]
		[Route("persons/{personId}")]
		public HttpResponseMessage DeletePerson(string personId)
		{
			try
			{
				int i = personRepository.DeletePerson(personId);
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

		[HttpGet]
		[Route("persons/{personId}")]
		public HttpResponseMessage GetOnePersonById(string personId)
		{
			try
			{
				PersonModel personModel = studentRepository.GetOneStudentById(personId);
				if (personModel == null)
				{
					personModel = teacherRepository.GetOneTeacherById(personId);
				}
				if (personModel == null)
				{
					return Request.CreateResponse(HttpStatusCode.NotFound, "The person record couldn't be found.");
				}
				return Request.CreateResponse(HttpStatusCode.OK, personModel);
			}

			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}
	}
}
