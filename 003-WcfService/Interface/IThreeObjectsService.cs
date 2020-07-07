using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ParkingSystem
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IThreeObjectsService" in both code and config file together.
	[ServiceContract]
	public interface IThreeObjectsService
	{
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "ThreeObjects/all/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetAllThreeObjects();

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "ThreeObjects/?personId={personId}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetAllThreeObjectsByPersonId(string personId);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "ThreeObjects/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage AddThreeObjects(ThreeObjectsModel threeObjectsModel);

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "ThreeObjects/?updateByPersonId={updateByPersonId}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage UpdateThreeObjects(string updateByPersonId, ThreeObjectsModel threeObjectsModel);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "ThreeObjects/?deleteByPersonId={deleteByPersonId}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage DeleteThreeObjects(string deleteByPersonId);
	}
}
