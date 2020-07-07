using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace ParkingSystem
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PersonService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select PersonService.svc or PersonService.svc.cs at the Solution Explorer and start debugging.
	public class PersonService : IPersonService
	{
		private IPersonRepository personRepository;
		private IStudentRepository studentRepository;
		private ITeacherRepository teacherRepository;

		public PersonService()
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


		public HttpResponseMessage GetAllPerson()
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(personRepository.GetAllPersons()))
				};
				return hrm;
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				HttpResponseMessage hr = new HttpResponseMessage(HttpStatusCode.InternalServerError)
				{
					Content = new StringContent(errors.ToString())
				};
				return hr;
			}
		}

		public HttpResponseMessage GetAllPersonsId()
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(personRepository.GetAllPersonsId()))
				};
				return hrm;
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				HttpResponseMessage hr = new HttpResponseMessage(HttpStatusCode.InternalServerError)
				{
					Content = new StringContent(errors.ToString())
				};
				return hr;
			}
		}

		public HttpResponseMessage GetOnePersonById(string getById)
		{
			try
			{
				PersonModel personModel = studentRepository.GetOneStudentById(getById);
				if (personModel == null)
				{
					personModel = teacherRepository.GetOneTeacherById(getById);
				}
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(personModel))
				};
				return hrm;
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				HttpResponseMessage hr = new HttpResponseMessage(HttpStatusCode.InternalServerError)
				{
					Content = new StringContent(errors.ToString())
				};
				return hr;
			}
		}

		public HttpResponseMessage DeletePerson(string deleteById)
		{
			try
			{
				int i = personRepository.DeletePerson(deleteById);

				if (i > 0)
				{
					HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.NoContent)
					{
					};
					return hrm;
				}
				HttpResponseMessage hr = new HttpResponseMessage(HttpStatusCode.InternalServerError)
				{
				};
				return hr;
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				HttpResponseMessage hr = new HttpResponseMessage(HttpStatusCode.InternalServerError)
				{
					Content = new StringContent(errors.ToString())
				};
				return hr;
			}
		}
	}
}
