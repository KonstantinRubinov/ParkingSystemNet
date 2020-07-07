using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace ParkingSystem
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TelephoneService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select TelephoneService.svc or TelephoneService.svc.cs at the Solution Explorer and start debugging.
	public class TelephoneService : ITelephoneService
	{
		private ITelephoneRepository telephoneRepository;
		public TelephoneService()
		{
			if (GlobalVariable.logicType == 0)
				telephoneRepository = new EntityTelephoneManager();
			else if (GlobalVariable.logicType == 1)
				telephoneRepository = new SqlTelephoneManager();
			else if (GlobalVariable.logicType == 2)
				telephoneRepository = new MySqlTelephoneManager();
			else if (GlobalVariable.logicType == 3)
				telephoneRepository = new InnerTelephoneManager();
			else
				telephoneRepository = new MongoTelephoneManager();
		}

		public HttpResponseMessage GetAllTelephones()
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(telephoneRepository.GetAllTelephones()))
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

		public HttpResponseMessage GetOneBeforeTelephone(string beforeTelephone)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(telephoneRepository.GetOneBeforeTelephone(beforeTelephone)))
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

		public HttpResponseMessage AddTelephone(TelephoneModel telephoneModel)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.Created)
				{
					Content = new StringContent(JsonConvert.SerializeObject(telephoneRepository.AddTelephone(telephoneModel)))
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

		public HttpResponseMessage UpdateCellphone(string beforeTelephone, TelephoneModel telephoneModel)
		{
			try
			{
				telephoneModel.beforeTelephone = beforeTelephone;

				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(telephoneRepository.UpdateTelephone(telephoneModel)))
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

		public HttpResponseMessage DeleteTelephone(string beforeTelephone)
		{
			try
			{
				int i = telephoneRepository.DeleteTelephone(beforeTelephone);

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
