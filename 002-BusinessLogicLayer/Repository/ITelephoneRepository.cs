using System.Collections.Generic;

namespace ParkingSystem
{
	public interface ITelephoneRepository
	{
		List<TelephoneModel> GetAllTelephones();
		TelephoneModel GetOneBeforeTelephone(string beforeTelephone1);
		TelephoneModel AddTelephone(TelephoneModel telephoneModel);
		TelephoneModel UpdateTelephone(TelephoneModel telephoneModel);
		int DeleteTelephone(string beforeTelephone1);
	}
}
