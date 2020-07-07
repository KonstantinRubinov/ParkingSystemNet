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
	public class ThreeObjectsApiController : ApiController
    {
		private IThreeObjectsRepository threeObjectsRepository;
		public ThreeObjectsApiController()
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


		[HttpGet]
		[Route("threeObjects")]
		public HttpResponseMessage GetAllThreeObjects()
		{
			try
			{
				List<ThreeObjectsModel> allThreeObjects = threeObjectsRepository.GetAllThreeObjects();
				return Request.CreateResponse(HttpStatusCode.OK, allThreeObjects);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("threeObjects/{personId}")]
		public HttpResponseMessage GetAllThreeObjectsByPersonId(string personId)
		{
			try
			{
				ThreeObjectsModel threeObjectsModel = threeObjectsRepository.GetAllThreeObjectsByPersonId(personId);
				return Request.CreateResponse(HttpStatusCode.OK, threeObjectsModel);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPost]
		[Route("threeObjects")]
		public HttpResponseMessage AddThreeObjects(ThreeObjectsModel threeObjectsModel)
		{
			try
			{
				if (threeObjectsModel == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				ThreeObjectsModel addedThreeObjects = threeObjectsRepository.AddThreeObjects(threeObjectsModel);
				return Request.CreateResponse(HttpStatusCode.Created, addedThreeObjects);
			}
			catch (Exception ex)
			{
				threeObjectsRepository.DeleteThreeObjects(threeObjectsModel.personModel.personId);
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPut]
		[Route("threeObjects/{personId}")]
		public HttpResponseMessage UpdateThreeObjects(string personId, ThreeObjectsModel threeObjectsModel)
		{
			try
			{
				if (threeObjectsModel == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}
				threeObjectsModel.personModel.personId = personId;
				threeObjectsModel.approvalModel.approvalPersonId = personId;
				threeObjectsModel.vehicleModel.vehicleOwnerId = personId;
				ThreeObjectsModel updatedThreeObjects = threeObjectsRepository.UpdateThreeObjects(threeObjectsModel);
				return Request.CreateResponse(HttpStatusCode.OK, updatedThreeObjects);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpDelete]
		[Route("threeObjects/{personId}")]
		public HttpResponseMessage DeleteThreeObjects(string personId)
		{
			try
			{
				int i = threeObjectsRepository.DeleteThreeObjects(personId);
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
