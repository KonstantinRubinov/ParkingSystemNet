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
	public class VehicleApiController : ApiController
    {
		private IVehicleRepository vehicleRepository;
		public VehicleApiController()
		{
			if (GlobalVariable.logicType == 0)
				vehicleRepository = new EntityVehicleManager();
			else if (GlobalVariable.logicType == 1)
				vehicleRepository = new SqlVehicleManager();
			else if (GlobalVariable.logicType == 2)
				vehicleRepository = new MySqlVehicleManager();
			else if (GlobalVariable.logicType == 3)
				vehicleRepository = new InnerVehicleManager();
			else
				vehicleRepository = new MongoVehicleManager();
		}


		[HttpGet]
		[Route("vehicles/number")]
		public HttpResponseMessage GetAllVehicleNumbers()
		{
			try
			{
				List<string> allVehicleNumbers = vehicleRepository.GetAllVehicleNumbers();
				return Request.CreateResponse(HttpStatusCode.OK, allVehicleNumbers);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("vehicles")]
		public HttpResponseMessage GetAllVehicles()
		{
			try
			{
				List<VehicleModel> allVehicles = vehicleRepository.GetAllVehicles();
				return Request.CreateResponse(HttpStatusCode.OK, allVehicles);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("vehicles/{vehicleNumber}")]
		public HttpResponseMessage GetOneVehicleByNumber(string vehicleNumber)
		{
			try
			{
				VehicleModel vehicleModel = vehicleRepository.GetOneVehicleByNumber(vehicleNumber);
				return Request.CreateResponse(HttpStatusCode.OK, vehicleModel);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPost]
		[Route("vehicles")]
		public HttpResponseMessage AddVehicle(VehicleModel vehicleModel)
		{
			try
			{
				if (vehicleModel == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				VehicleModel addedVehicle = vehicleRepository.AddVehicle(vehicleModel);
				return Request.CreateResponse(HttpStatusCode.Created, addedVehicle);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPut]
		[Route("vehicles/{vehicleNumber}")]
		public HttpResponseMessage UpdateVehicle(string vehicleNumber, VehicleModel vehicleModel)
		{
			try
			{
				if (vehicleModel == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				vehicleModel.vehicleNumber = vehicleNumber;
				VehicleModel updatedVehicle = vehicleRepository.UpdateVehicle(vehicleModel);
				return Request.CreateResponse(HttpStatusCode.OK, updatedVehicle);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}


		[HttpDelete]
		[Route("vehicles/{vehicleNumber}")]
		public HttpResponseMessage DeleteVehicle(string vehicleNumber)
		{
			try
			{
				int i = vehicleRepository.DeleteVehicleByNumber(vehicleNumber);
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
