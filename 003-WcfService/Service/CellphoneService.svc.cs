using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace ParkingSystem
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CellphoneService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select CellphoneService.svc or CellphoneService.svc.cs at the Solution Explorer and start debugging.
	public class CellphoneService : ICellphoneService
	{
		private ICellphoneRepository cellphoneRepository;
		public CellphoneService()
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

		public HttpResponseMessage GetAllCellphones()
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(cellphoneRepository.GetAllCellphones()))
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

		public HttpResponseMessage GetOneBeforeCellphone(string beforeCellphone)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(cellphoneRepository.GetOneBeforeCellphone(beforeCellphone)))
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

		public HttpResponseMessage AddCellphone(CellphoneModel cellphoneModel)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.Created)
				{
					Content = new StringContent(JsonConvert.SerializeObject(cellphoneRepository.AddCellphone(cellphoneModel)))
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

		public HttpResponseMessage UpdateCellphone(string beforeCellphone, CellphoneModel cellphoneModel)
		{
			try
			{
				cellphoneModel.beforeCellphone = beforeCellphone;

				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(cellphoneRepository.UpdateCellphone(cellphoneModel)))
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

		public HttpResponseMessage DeleteCellphone(string beforeCellphone)
		{
			try
			{
				int i = cellphoneRepository.DeleteCellphone(beforeCellphone);

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
