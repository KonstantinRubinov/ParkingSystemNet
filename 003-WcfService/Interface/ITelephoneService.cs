using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ParkingSystem
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITelephoneService" in both code and config file together.
	[ServiceContract]
	public interface ITelephoneService
	{
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Telephones/all/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetAllTelephones();

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Telephones/?beforeTelephone={beforeTelephone}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetOneBeforeTelephone(string beforeTelephone);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "Telephones/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage AddTelephone(TelephoneModel telephoneModel);

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "Telephones/?updateByBeforeTelephone={updateByBeforeTelephone}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage UpdateCellphone(string beforeTelephone, TelephoneModel telephoneModel);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "Telephones/?deleteByBeforeTelephone={deleteByBeforeTelephone}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage DeleteTelephone(string beforeTelephone);
	}
}
