using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ParkingSystem
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICourseService" in both code and config file together.
	[ServiceContract]
	public interface ICourseService
	{
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Courses/all/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetAllCourses();

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Courses/?courseCode={courseCode}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetOneCourseByCode(string courseCode);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "Courses/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage AddCourse(CourseModel courseModel);

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "Courses/?updateByCourseCode={updateByCourseCode}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage UpdateCourse(string updateByCourseCode, CourseModel courseModel);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "Courses/?deleteByCourseCode={deleteByCourseCode}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage DeleteCourse(string deleteByCourseCode);
	}
}
