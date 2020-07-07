using ParkingSystem.EntityDataBase;
using System;

namespace ParkingSystem
{
	public class EntityBaseManager : IDisposable
	{
		protected ParkingEntities DB = new ParkingEntities();

		public void Dispose()
		{
			DB.Dispose();
		}
	}
}
