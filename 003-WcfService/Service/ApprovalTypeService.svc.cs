using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace ParkingSystem
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ApprovalTypeService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select ApprovalTypeService.svc or ApprovalTypeService.svc.cs at the Solution Explorer and start debugging.
	public class ApprovalTypeService : IApprovalTypeService
	{
		private IApprovalTypesRepository approvalTypesRepository;
		public ApprovalTypeService()
		{
			if (GlobalVariable.logicType == 0)
				approvalTypesRepository = new EntityApprovalTypeManager();
			else if (GlobalVariable.logicType == 1)
				approvalTypesRepository = new SqlApprovalTypeManager();
			else if(GlobalVariable.logicType == 2)
				approvalTypesRepository = new MySqlApprovalTypeManager();
			else if (GlobalVariable.logicType == 3)
				approvalTypesRepository = new InnerApprovalTypeManager();
			else
				approvalTypesRepository = new MongoApprovalTypeManager();
		}

		public HttpResponseMessage GetAllApprovalTypes()
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(approvalTypesRepository.GetAllApprovalTypes()))
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

		public HttpResponseMessage GetOneApprovalTypeByCode(string approvalCode)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(approvalTypesRepository.GetOneApprovalTypeByCode(approvalCode)))
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

		public HttpResponseMessage AddApprovalType(ApprovalTypeModel approvalTypeModel)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.Created)
				{
					Content = new StringContent(JsonConvert.SerializeObject(approvalTypesRepository.AddApprovalType(approvalTypeModel)))
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

		public HttpResponseMessage UpdateApprovalType(string updateByCode, ApprovalTypeModel approvalTypeModel)
		{
			try
			{
				approvalTypeModel.approvalCode = updateByCode;
				ApprovalTypeModel updatedApprovalType = approvalTypesRepository.UpdateApprovalType(approvalTypeModel);

				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(updatedApprovalType))
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

		public HttpResponseMessage DeleteApprovalType(string deleteByCode)
		{
			try
			{
				int i = approvalTypesRepository.DeleteApprovalType(deleteByCode);

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
