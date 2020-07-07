using System.Collections.Generic;

namespace ParkingSystem
{
	public interface IPersonRepository
	{
		List<PersonModel> GetAllPersons();
		List<PersonModel> GetAllPersonsId();
		PersonModel GetOnePersonById(string personId);
		int DeletePerson(string personId);
		bool checkIfIdExists(string id);
	}
}
