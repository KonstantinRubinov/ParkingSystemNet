using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ParkingSystem
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IApprovalService" in both code and config file together.
	[ServiceContract]
	public interface IApprovalService
	{
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Approvals/all/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetAllApprovals();

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Approvals/?approvalCode={approvalCode}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetOneApprovalByCode(string approvalCode);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "Approvals/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage AddApproval(ApprovalModel approvalModel);

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "Approvals/?updateByCode={updateByCode}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage UpdateApproval(string updateByCode, ApprovalModel approvalModel);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "Approvals/?deleteByCode={deleteByCode}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage DeleteApproval(int approvalNumber);
	}
}
