using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ParkingSystem
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICellphoneService" in both code and config file together.
	[ServiceContract]
	public interface ICellphoneService
	{
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Cellphones/all/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetAllCellphones();

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Cellphones/?beforeCellphone={beforeCellphone}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetOneBeforeCellphone(string beforeCellphone);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "Cellphones/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage AddCellphone(CellphoneModel cellphoneModel);

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "Cellphones/?updateByBeforeCellphone={updateByBeforeCellphone}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage UpdateCellphone(string beforeCellphone, CellphoneModel cellphoneModel);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "Cellphones/?deleteByBeforeCellphone={deleteByBeforeCellphone}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage DeleteCellphone(string beforeCellphone);
	}
}
