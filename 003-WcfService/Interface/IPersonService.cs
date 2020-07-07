using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ParkingSystem
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPersonService" in both code and config file together.
	[ServiceContract]
	public interface IPersonService
	{
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Persons/all/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetAllPerson();

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Persons/ids/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetAllPersonsId();

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Persons/?getById={getById}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetOnePersonById(string getById);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "Persons/?deleteById={deleteById}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage DeletePerson(string deleteById);
	}
}
