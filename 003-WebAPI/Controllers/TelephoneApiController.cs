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
	public class TelephoneApiController : ApiController
    {
		private ITelephoneRepository telephoneRepository;
		public TelephoneApiController(ITelephoneRepository _telephoneRepository)
		{
			telephoneRepository = _telephoneRepository;
		}

		[HttpGet]
		[Route("telephones")]
		public HttpResponseMessage GetAllTelephones()
		{
			try
			{
				List<TelephoneModel> allTelephones = telephoneRepository.GetAllTelephones();
				return Request.CreateResponse(HttpStatusCode.OK, allTelephones);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("telephones/{beforeTelephone}")]
		public HttpResponseMessage GetOneBeforeTelephone(string beforeTelephone)
		{
			try
			{
				TelephoneModel telephoneModel = telephoneRepository.GetOneBeforeTelephone(beforeTelephone);
				return Request.CreateResponse(HttpStatusCode.OK, telephoneModel);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPost]
		[Route("telephones")]
		public HttpResponseMessage AddTelephone(TelephoneModel telephoneModel)
		{
			try
			{
				if (telephoneModel == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				TelephoneModel addedTelephone = telephoneRepository.AddTelephone(telephoneModel);
				return Request.CreateResponse(HttpStatusCode.Created, addedTelephone);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPut]
		[Route("telephones/{beforeTelephone}")]
		public HttpResponseMessage UpdateTelephone(string beforeTelephone, TelephoneModel telephoneModel)
		{
			try
			{
				if (telephoneModel == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				telephoneModel.beforeTelephone = beforeTelephone;
				TelephoneModel updatedTelephone = telephoneRepository.UpdateTelephone(telephoneModel);
				return Request.CreateResponse(HttpStatusCode.OK, updatedTelephone);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpDelete]
		[Route("telephones/{beforeTelephone}")]
		public HttpResponseMessage DeleteTelephone(string beforeTelephone)
		{
			try
			{
				int i = telephoneRepository.DeleteTelephone(beforeTelephone);
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
