using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ParkingSystem
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IApprovalTypeService" in both code and config file together.
	[ServiceContract]
	public interface IApprovalTypeService
	{
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "ApprovalTypes/all/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetAllApprovalTypes();

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "ApprovalTypes/?approvalCode={approvalCode}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetOneApprovalTypeByCode(string approvalCode);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "ApprovalTypes/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage AddApprovalType(ApprovalTypeModel approvalTypeModel);

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "ApprovalTypes/?updateByCode={updateByCode}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage UpdateApprovalType(string updateByCode, ApprovalTypeModel approvalTypeModel);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "ApprovalTypes/?deleteByCode={deleteByCode}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage DeleteApprovalType(string deleteByCode);
	}
}
