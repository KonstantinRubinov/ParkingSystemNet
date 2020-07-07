using ParkingSystem.EntityDataBase;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
	public class EntityVehicleManager : EntityBaseManager, IVehicleRepository
	{
		public List<string> GetAllVehicleNumbers()
		{
			var resultQuary = DB.VEHICLES.Select(v => new VehicleModel
			{
				vehicleNumber = v.vehicleNumber
			});

			var resultSP = DB.GetAllVehicleNumbers().Select(vehicleNumber1 => new VehicleModel
			{
				vehicleNumber = vehicleNumber1
			});


			if (GlobalVariable.queryType == 0)
			{
				List<string> vehicleNumbers = new List<string>();

				foreach (var vehicle in resultQuary)
				{
					vehicleNumbers.Add(vehicle.vehicleNumber);
				}

				return vehicleNumbers;
			}
			else
			{
				List<string> vehicleNumbers = new List<string>();

				foreach (var vehicle in resultSP)
				{
					vehicleNumbers.Add(vehicle.vehicleNumber);
				}

				return vehicleNumbers;
			}
		}


		public List<VehicleModel> GetAllVehicles()
		{
			var resultQuary = DB.VEHICLES.Select(v => new VehicleModel
			{
				vehicleNumber = v.vehicleNumber,
				vehicleManufacturer = v.vehicleManufacturer,
				vehicleColor = v.vehicleColor,
				vehicleOwnerId = v.vehicleOwnerId,
				vehicleOwnerName = v.PERSON.personFirstName + " " + v.PERSON.personLastName
			});

			var resultSP = DB.GetAllVehicles().Select(v => new VehicleModel
			{
				vehicleNumber = v.vehicleNumber,
				vehicleManufacturer = v.vehicleManufacturer,
				vehicleColor = v.vehicleColor,
				vehicleOwnerId = v.vehicleOwnerId,
				vehicleOwnerName = v.personFirstName + " " + v.personLastName
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.ToList();
			else
				return resultSP.ToList();
		}


		public VehicleModel GetOneVehicleByNumber(string vehicleNumber)
		{
			var resultQuary = DB.VEHICLES.Where(v => v.vehicleNumber.Equals(vehicleNumber)).Select(v => new VehicleModel
			{
				vehicleNumber = v.vehicleNumber,
				vehicleManufacturer = v.vehicleManufacturer,
				vehicleColor = v.vehicleColor,
				vehicleOwnerId = v.vehicleOwnerId,
				vehicleOwnerName = v.PERSON.personFirstName + " " + v.PERSON.personLastName
			});

			var resultSP = DB.GetOneVehicleByNumber(vehicleNumber).Select(v => new VehicleModel
			{
				vehicleNumber = v.vehicleNumber,
				vehicleManufacturer = v.vehicleManufacturer,
				vehicleColor = v.vehicleColor,
				vehicleOwnerId = v.vehicleOwnerId,
				vehicleOwnerName = v.personFirstName + " " + v.personLastName
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.SingleOrDefault();
			else
				return resultSP.SingleOrDefault();
		}


		public VehicleModel GetOneVehicleByOwnerId(string personId)
		{
			var resultQuary = DB.VEHICLES.Where(v => v.vehicleOwnerId.Equals(personId)).Select(v => new VehicleModel
			{
				vehicleNumber = v.vehicleNumber,
				vehicleManufacturer = v.vehicleManufacturer,
				vehicleColor = v.vehicleColor,
				vehicleOwnerId = v.vehicleOwnerId,
				vehicleOwnerName = v.PERSON.personFirstName + " " + v.PERSON.personLastName
			});

			var resultSP = DB.GetOneVehicleByOwnerId(personId).Select(v => new VehicleModel
			{
				vehicleNumber = v.vehicleNumber,
				vehicleManufacturer = v.vehicleManufacturer,
				vehicleColor = v.vehicleColor,
				vehicleOwnerId = v.vehicleOwnerId,
				vehicleOwnerName = v.personFirstName + " " + v.personLastName
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.SingleOrDefault();
			else
				return resultSP.SingleOrDefault();
		}


		public VehicleModel AddVehicle(VehicleModel vehicleModel)
		{
			var resultSP = DB.AddVehicle(vehicleModel.vehicleNumber, vehicleModel.vehicleManufacturer, vehicleModel.vehicleColor, vehicleModel.vehicleOwnerId).Select(v => new VehicleModel
			{
				vehicleNumber = v.vehicleNumber,
				vehicleManufacturer = v.vehicleManufacturer,
				vehicleColor = v.vehicleColor,
				vehicleOwnerId = v.vehicleOwnerId,
				vehicleOwnerName = v.personFirstName + " " + v.personLastName
			});

			if (GlobalVariable.queryType == 0)
			{
				VEHICLE vehicle = new VEHICLE
				{
					vehicleNumber = vehicleModel.vehicleNumber,
					vehicleManufacturer = vehicleModel.vehicleManufacturer,
					vehicleColor = vehicleModel.vehicleColor,
					vehicleOwnerId = vehicleModel.vehicleOwnerId
				};

				DB.VEHICLES.Add(vehicle);
				DB.SaveChanges();
				return GetOneVehicleByNumber(vehicle.vehicleNumber);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public VehicleModel UpdateVehicle(VehicleModel vehicleModel)
		{
			var resultSP = DB.UpdateVehicle(vehicleModel.vehicleNumber, vehicleModel.vehicleManufacturer, vehicleModel.vehicleColor, vehicleModel.vehicleOwnerId).Select(v => new VehicleModel
			{
				vehicleNumber = v.vehicleNumber,
				vehicleManufacturer = v.vehicleManufacturer,
				vehicleColor = v.vehicleColor,
				vehicleOwnerId = v.vehicleOwnerId,
				vehicleOwnerName = v.personFirstName + " " + v.personLastName
			});

			if (GlobalVariable.queryType == 0)
			{
				VEHICLE vehicle = DB.VEHICLES.Where(v => v.vehicleNumber.Equals(vehicleModel.vehicleNumber) || v.vehicleOwnerId.Equals(vehicleModel.vehicleOwnerId)).SingleOrDefault();
				if (vehicle == null)
					return null;
				vehicle.vehicleNumber = vehicleModel.vehicleNumber;
				vehicle.vehicleManufacturer = vehicleModel.vehicleManufacturer;
				vehicle.vehicleColor = vehicleModel.vehicleColor;
				vehicle.vehicleOwnerId = vehicleModel.vehicleOwnerId;
				DB.SaveChanges();
				return GetOneVehicleByNumber(vehicle.vehicleNumber);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public int DeleteVehicleByNumber(string vehicleNumber)
		{
			var resultSP = DB.DeleteVehicleByNumber(vehicleNumber);

			if (GlobalVariable.queryType == 0)
			{
				VEHICLE vehicle = DB.VEHICLES.Where(v => v.vehicleNumber.Equals(vehicleNumber)).SingleOrDefault();
				DB.VEHICLES.Attach(vehicle);
				if (vehicle == null)
					return 0;
				DB.VEHICLES.Remove(vehicle);
				DB.SaveChanges();
				return 1;
			}
			else
				return resultSP;
		}


		public int DeleteVehicleByOwnerId(string ownerId)
		{
			var resultSP = DB.DeleteVehicleByOwnerId(ownerId);

			if (GlobalVariable.queryType == 0)
			{
				VEHICLE vehicle = DB.VEHICLES.Where(v => v.vehicleOwnerId.Equals(ownerId)).SingleOrDefault();
				DB.VEHICLES.Attach(vehicle);
				if (vehicle == null)
					return 0;
				DB.VEHICLES.Remove(vehicle);
				DB.SaveChanges();
				return 1;
			}
			else
				return resultSP;
		}
	}
}