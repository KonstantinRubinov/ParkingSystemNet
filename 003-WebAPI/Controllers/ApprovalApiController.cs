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
	public class ApprovalApiController : ApiController
    {
		private IApprovalRepository approvalRepository;
		public ApprovalApiController(IApprovalRepository _approvalRepository)
		{
			approvalRepository = _approvalRepository;
		}

		[HttpGet]
		[Route("approvals")]
		public HttpResponseMessage GetAllApprovals()
		{
			try
			{
				List<ApprovalModel> allApprovals = approvalRepository.GetAllApprovals();
				return Request.CreateResponse(HttpStatusCode.OK, allApprovals);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("approvals/{approvalCode}")]
		public HttpResponseMessage GetOneApprovalByCode(string approvalCode)
		{
			try
			{
				ApprovalModel approvalModel = approvalRepository.GetOneApprovalByCode(approvalCode);
				return Request.CreateResponse(HttpStatusCode.OK, approvalModel);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPost]
		[Route("approvals")]
		public HttpResponseMessage AddApproval(ApprovalModel approvalModel)
		{
			try
			{
				if (approvalModel == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				ApprovalModel addedApproval = approvalRepository.AddApproval(approvalModel);
				return Request.CreateResponse(HttpStatusCode.Created, addedApproval);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPut]
		[Route("approvals/{approvalCode}")]
		public HttpResponseMessage UpdateApproval(int approvalNumber, ApprovalModel approvalModel)
		{
			try
			{
				if (approvalModel == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				approvalModel.approvalNumber = approvalNumber;
				ApprovalModel updatedApproval = approvalRepository.UpdateApproval(approvalModel);
				return Request.CreateResponse(HttpStatusCode.OK, updatedApproval);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpDelete]
		[Route("approvals/{approvalNumber}")]
		public HttpResponseMessage DeleteApproval(int approvalNumber)
		{
			try
			{
				int i = approvalRepository.DeleteApproval(approvalNumber);
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
