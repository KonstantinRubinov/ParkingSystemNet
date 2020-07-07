using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ParkingSystem
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVehicleService" in both code and config file together.
	[ServiceContract]
	public interface IVehicleService
	{
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Vehicles/numbers/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetAllVehicleNumbers();

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Vehicles/all/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetAllVehicles();

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Vehicles/?vehicleNumber={vehicleNumber}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetOneVehicleByNumber(string vehicleNumber);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "Vehicles/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage AddVehicle(VehicleModel vehicleModel);

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "Vehicles/?updateByNumber={updateByNumber}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage UpdateVehicle(string updateByNumber, VehicleModel vehicleModel);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "Vehicles/?deleteByNumber={deleteByNumber}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage DeleteVehicle(string deleteByNumber);
	}
}
