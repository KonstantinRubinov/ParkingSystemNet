using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace ParkingSystem
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ApprovalService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select ApprovalService.svc or ApprovalService.svc.cs at the Solution Explorer and start debugging.
	public class ApprovalService : IApprovalService
	{
		private IApprovalRepository approvalRepository;
		public ApprovalService()
		{
			if (GlobalVariable.logicType == 0)
				approvalRepository = new EntityApprovalManager();
			else if (GlobalVariable.logicType == 1)
				approvalRepository = new SqlApprovalManager();
			else if (GlobalVariable.logicType == 2)
				approvalRepository = new MySqlApprovalManager();
			else if (GlobalVariable.logicType == 3)
				approvalRepository = new InnerApprovalManager();
			else
				approvalRepository = new MongoApprovalManager();
		}

		public HttpResponseMessage GetAllApprovals()
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(approvalRepository.GetAllApprovals()))
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

		public HttpResponseMessage GetOneApprovalByCode(string approvalCode)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(approvalRepository.GetOneApprovalByCode(approvalCode)))
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

		public HttpResponseMessage AddApproval(ApprovalModel approvalModel)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.Created)
				{
					Content = new StringContent(JsonConvert.SerializeObject(approvalRepository.AddApproval(approvalModel)))
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

		public HttpResponseMessage UpdateApproval(string updateByCode, ApprovalModel approvalModel)
		{
			try
			{
				approvalModel.approvalCode = updateByCode;
				ApprovalModel updatedApproval = approvalRepository.UpdateApproval(approvalModel);

				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(updatedApproval))
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

		public HttpResponseMessage DeleteApproval(int approvalNumber)
		{
			try
			{
				int i = approvalRepository.DeleteApproval(approvalNumber);

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
