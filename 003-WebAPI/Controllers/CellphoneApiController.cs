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
	public class CellphoneApiController : ApiController
    {
		private ICellphoneRepository cellphoneRepository;
		public CellphoneApiController()
		{
			if (GlobalVariable.logicType == 0)
				cellphoneRepository = new EntityCellphoneManager();
			else if (GlobalVariable.logicType == 1)
				cellphoneRepository = new SqlCellphoneManager();
			else if (GlobalVariable.logicType == 2)
				cellphoneRepository = new MySqlCellphoneManager();
			else if (GlobalVariable.logicType == 3)
				cellphoneRepository = new InnerCellphoneManager();
			else
				cellphoneRepository = new MongoCellphoneManager();
		}

		[HttpGet]
		[Route("cellphones")]
		public HttpResponseMessage GetAllCellphones()
		{
			try
			{
				List<CellphoneModel> allCellphones = cellphoneRepository.GetAllCellphones();
				return Request.CreateResponse(HttpStatusCode.OK, allCellphones);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("cellphones/{beforeCellphone}")]
		public HttpResponseMessage GetOneBeforeCellphone(string beforeCellphone)
		{
			try
			{
				CellphoneModel cellphoneModel = cellphoneRepository.GetOneBeforeCellphone(beforeCellphone);
				return Request.CreateResponse(HttpStatusCode.OK, cellphoneModel);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPost]
		[Route("cellphones")]
		public HttpResponseMessage AddCellphone(CellphoneModel cellphoneModel)
		{
			try
			{
				if (cellphoneModel == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				CellphoneModel addedCellphone = cellphoneRepository.AddCellphone(cellphoneModel);
				return Request.CreateResponse(HttpStatusCode.Created, addedCellphone);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}


		[HttpPut]
		[Route("cellphones/{beforeCellphone}")]
		public HttpResponseMessage UpdateCellphone(string beforeCellphone, CellphoneModel cellphoneModel)
		{
			try
			{
				if (cellphoneModel == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				cellphoneModel.beforeCellphone = beforeCellphone;
				CellphoneModel updatedCellphone = cellphoneRepository.UpdateCellphone(cellphoneModel);
				return Request.CreateResponse(HttpStatusCode.OK, updatedCellphone);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpDelete]
		[Route("cellphones/{beforeCellphone}")]
		public HttpResponseMessage DeleteCellphone(string beforeCellphone)
		{
			try
			{
				int i = cellphoneRepository.DeleteCellphone(beforeCellphone);
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
