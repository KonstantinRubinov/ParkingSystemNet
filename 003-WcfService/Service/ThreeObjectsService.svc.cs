using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace ParkingSystem
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ThreeObjectsService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select ThreeObjectsService.svc or ThreeObjectsService.svc.cs at the Solution Explorer and start debugging.
	public class ThreeObjectsService : IThreeObjectsService
	{
		private IThreeObjectsRepository threeObjectsRepository;
		public ThreeObjectsService()
		{
			if (GlobalVariable.logicType == 0)
				threeObjectsRepository = new EntityThreeObjectsManager();
			else if (GlobalVariable.logicType == 1)
				threeObjectsRepository = new SqlThreeObjectsManager();
			else if (GlobalVariable.logicType == 2)
				threeObjectsRepository = new MySqlThreeObjectsManager();
			else if (GlobalVariable.logicType == 3)
				threeObjectsRepository = new InnerThreeObjectsManager();
			else
				threeObjectsRepository = new MongoThreeObjectsManager();
		}

		public HttpResponseMessage GetAllThreeObjects()
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(threeObjectsRepository.GetAllThreeObjects()))
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

		public HttpResponseMessage GetAllThreeObjectsByPersonId(string personId)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(threeObjectsRepository.GetAllThreeObjectsByPersonId(personId)))
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

		public HttpResponseMessage AddThreeObjects(ThreeObjectsModel threeObjectsModel)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.Created)
				{
					Content = new StringContent(JsonConvert.SerializeObject(threeObjectsRepository.AddThreeObjects(threeObjectsModel)))
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

		public HttpResponseMessage UpdateThreeObjects(string updateByPersonId, ThreeObjectsModel threeObjectsModel)
		{
			try
			{
				threeObjectsModel.personModel.personId = updateByPersonId;
				threeObjectsModel.approvalModel.approvalPersonId = updateByPersonId;
				threeObjectsModel.vehicleModel.vehicleOwnerId = updateByPersonId;

				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(threeObjectsRepository.UpdateThreeObjects(threeObjectsModel)))
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

		public HttpResponseMessage DeleteThreeObjects(string deleteByPersonId)
		{
			try
			{
				int i = threeObjectsRepository.DeleteThreeObjects(deleteByPersonId);

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
