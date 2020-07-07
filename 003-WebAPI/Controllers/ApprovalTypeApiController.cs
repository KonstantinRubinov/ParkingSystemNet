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
	public class ApprovalTypeApiController : ApiController
    {
		private IApprovalTypesRepository approvalTypesRepository;
		public ApprovalTypeApiController()
		{
			if (GlobalVariable.logicType == 0)
				approvalTypesRepository = new EntityApprovalTypeManager();
			else if (GlobalVariable.logicType == 1)
				approvalTypesRepository = new SqlApprovalTypeManager();
			else if (GlobalVariable.logicType == 2)
				approvalTypesRepository = new MySqlApprovalTypeManager();
			else if (GlobalVariable.logicType == 3)
				approvalTypesRepository = new InnerApprovalTypeManager();
			else
				approvalTypesRepository = new MongoApprovalTypeManager();
		}


		[HttpGet]
		[Route("approvalTypes")]
		public HttpResponseMessage GetAllApprovalTypes()
		{
			try
			{
				List<ApprovalTypeModel> allApprovalTypes = approvalTypesRepository.GetAllApprovalTypes();
				return Request.CreateResponse(HttpStatusCode.OK, allApprovalTypes);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("approvalTypes/{approvalCode}")]
		public HttpResponseMessage GetOneApprovalTypeByCode(string approvalCode)
		{
			try
			{
				ApprovalTypeModel approvalTypeModel = approvalTypesRepository.GetOneApprovalTypeByCode(approvalCode);
				return Request.CreateResponse(HttpStatusCode.OK, approvalTypeModel);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPost]
		[Route("approvalTypes")]
		public HttpResponseMessage AddApprovalType(ApprovalTypeModel approvalTypeModel)
		{
			try
			{
				if (approvalTypeModel == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				ApprovalTypeModel addedApprovalType = approvalTypesRepository.AddApprovalType(approvalTypeModel);
				return Request.CreateResponse(HttpStatusCode.Created, addedApprovalType);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPut]
		[Route("approvalTypes/{approvalCode}")]
		public HttpResponseMessage UpdateApprovalType(string approvalCode, ApprovalTypeModel approvalTypeModel)
		{
			try
			{
				if (approvalTypeModel == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				approvalTypeModel.approvalCode = approvalCode;
				ApprovalTypeModel updatedApprovalType = approvalTypesRepository.UpdateApprovalType(approvalTypeModel);
				return Request.CreateResponse(HttpStatusCode.OK, updatedApprovalType);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpDelete]
		[Route("approvalTypes/{approvalCode}")]
		public HttpResponseMessage DeleteApprovalType(string approvalCode)
		{
			try
			{
				int i = approvalTypesRepository.DeleteApprovalType(approvalCode);
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
