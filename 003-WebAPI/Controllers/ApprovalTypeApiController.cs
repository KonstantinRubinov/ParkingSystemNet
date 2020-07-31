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
		public ApprovalTypeApiController(IApprovalTypesRepository _approvalTypesRepository)
		{
			approvalTypesRepository = _approvalTypesRepository;
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
				return Request.CreateResponse(HttpStatusCode.NoContent);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}
	}
}
