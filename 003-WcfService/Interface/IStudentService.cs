using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ParkingSystem
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStudentService" in both code and config file together.
	[ServiceContract]
	public interface IStudentService
	{
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Students/all/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetAllStudents();

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Students/?studentId={studentId}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetOneStudentById(string studentId);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "Students/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage AddStudent(StudentModel studentModel);

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "Students/?updateById={updateById}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage UpdateStudent(string updateById, StudentModel studentModel);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "Students/?deleteById={deleteById}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage DeleteStudent(string deleteById);
	}
}
