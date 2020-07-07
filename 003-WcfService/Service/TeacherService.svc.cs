using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace ParkingSystem
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TeacherService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select TeacherService.svc or TeacherService.svc.cs at the Solution Explorer and start debugging.
	public class TeacherService : ITeacherService
	{
		private ITeacherRepository teacherRepository;
		public TeacherService()
		{
			if (GlobalVariable.logicType == 0)
				teacherRepository = new EntityTeacherManager();
			else if (GlobalVariable.logicType == 1)
				teacherRepository = new SqlTeacherManager();
			else if (GlobalVariable.logicType == 2)
				teacherRepository = new MySqlTeacherManager();
			else if (GlobalVariable.logicType == 3)
				teacherRepository = new InnerTeacherManager();
			else
				teacherRepository = new MongoTeacherManager();
		}

		public HttpResponseMessage GetAllTeachers()
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(teacherRepository.GetAllTeachers()))
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

		public HttpResponseMessage GetOneTeacherById(string teacherId)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(teacherRepository.GetOneTeacherById(teacherId)))
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

		public HttpResponseMessage AddTeacher(TeacherModel teacherModel)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.Created)
				{
					Content = new StringContent(JsonConvert.SerializeObject(teacherRepository.AddTeacher(teacherModel)))
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

		public HttpResponseMessage UpdateTeacher(string updateById, TeacherModel teacherModel)
		{
			try
			{
				teacherModel.teacherId = updateById;
				TeacherModel updatedTeacher = teacherRepository.UpdateTeacher(teacherModel);

				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(updatedTeacher))
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

		public HttpResponseMessage DeleteTeacher(string deleteById)
		{
			try
			{
				int i = teacherRepository.DeleteTeacher(deleteById);

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
