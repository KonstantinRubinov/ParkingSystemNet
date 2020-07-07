using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ParkingSystem
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITeacherService" in both code and config file together.
	[ServiceContract]
	public interface ITeacherService
	{
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Teachers/all/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetAllTeachers();

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Teachers/?teacherId={teacherId}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetOneTeacherById(string teacherId);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "Teachers/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage AddTeacher(TeacherModel teacherModel);

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "Teachers/?updateById={updateById}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage UpdateTeacher(string updateById, TeacherModel teacherModel);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "Teachers/?deleteById={deleteById}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage DeleteTeacher(string deleteById);
	}
}
