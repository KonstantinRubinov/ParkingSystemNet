using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace ParkingSystem
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FacultyService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select FacultyService.svc or FacultyService.svc.cs at the Solution Explorer and start debugging.
	public class FacultyService : IFacultyService
	{
		private IFacultyRepository facultyRepository;
		public FacultyService()
		{
			if (GlobalVariable.logicType == 0)
				facultyRepository = new EntityFacultyManager();
			else if (GlobalVariable.logicType == 1)
				facultyRepository = new SqlFacultyManager();
			else if(GlobalVariable.logicType == 2)
				facultyRepository = new MySqlFacultyManager();
			else if (GlobalVariable.logicType == 3)
				facultyRepository = new InnerFacultyManager();
			else
				facultyRepository = new MongoFacultyManager();
		}

		public HttpResponseMessage GetAllFaculties()
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(facultyRepository.GetAllFaculties()))
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

		public HttpResponseMessage GetOneFacultyByCode(string facultyByCode)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(facultyRepository.GetOneFacultyByCode(facultyByCode)))
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

		public HttpResponseMessage AddFaculty(FacultyModel facultyModel)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.Created)
				{
					Content = new StringContent(JsonConvert.SerializeObject(facultyRepository.AddFaculty(facultyModel)))
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

		public HttpResponseMessage UpdateFaculty(string updateByCode, FacultyModel facultyModel)
		{
			try
			{
				facultyModel.facultyCode = updateByCode;
				FacultyModel updatedFaculty = facultyRepository.UpdateFaculty(facultyModel);

				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(updatedFaculty))
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

		public HttpResponseMessage DeleteFaculty(string deleteByCode)
		{
			try
			{
				int i = facultyRepository.DeleteFaculty(deleteByCode);

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
