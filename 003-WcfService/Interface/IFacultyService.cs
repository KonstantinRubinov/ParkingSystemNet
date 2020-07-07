using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ParkingSystem
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFacultyService" in both code and config file together.
	[ServiceContract]
	public interface IFacultyService
	{
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Faculties/all/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetAllFaculties();

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Faculties/?facultyByCode={facultyByCode}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetOneFacultyByCode(string facultyByCode);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "Faculties/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage AddFaculty(FacultyModel facultyModel);

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "Faculties/?updateByCode={updateByCode}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage UpdateFaculty(string updateByCode, FacultyModel facultyModel);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "Faculties/?deleteByCode={deleteByCode}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage DeleteFaculty(string deleteByCode);
	}
}
