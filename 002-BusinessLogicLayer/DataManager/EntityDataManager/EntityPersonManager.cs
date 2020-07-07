using ParkingSystem.EntityDataBase;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
	public class EntityPersonManager : EntityBaseManager, IPersonRepository
	{
		public List<PersonModel> GetAllPersons()
		{
			var resultQuary = DB.PERSONS.Select(p => new PersonModel
			{
				personId = p.personId,
				personFirstName = p.personFirstName,
				personLastName = p.personLastName,
				personBeforeTelephone = p.personBeforeTelephone,
				personTelephone = p.personTelephone,
				personBeforeCellphone = p.personBeforeCellphone,
				personCellphone = p.personCellphone,
				personCode = p.personCode
			});

			var resultSP = DB.GetAllPersons().Select(p => new PersonModel
			{
				personId = p.personId,
				personFirstName = p.personFirstName,
				personLastName = p.personLastName,
				personBeforeTelephone = p.personBeforeTelephone,
				personTelephone = p.personTelephone,
				personBeforeCellphone = p.personBeforeCellphone,
				personCellphone = p.personCellphone,
				personCode = p.personCode
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.ToList();
			else
				return resultSP.ToList();
		}


		public List<PersonModel> GetAllPersonsId()
		{
			var resultQuary = DB.PERSONS.Select(pid => new PersonModel
			{
				personId = pid.personId
			});

			var resultSP = DB.GetAllPersonsId().Select(personId => new PersonModel
			{
				personId = personId
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.ToList();
			else
				return resultSP.ToList();
		}


		public PersonModel GetOnePersonById(string personId)
		{
			var resultQuary = DB.PERSONS.Where(p => p.personId.Equals(personId)).Select(p => new PersonModel
			{
				personId = p.personId,
				personFirstName = p.personFirstName,
				personLastName = p.personLastName,
				personBeforeTelephone = p.personBeforeTelephone,
				personTelephone = p.personTelephone,
				personBeforeCellphone = p.personBeforeCellphone,
				personCellphone = p.personCellphone,
				personCode = p.personCode
			});

			var resultSP = DB.GetOnePersonById(personId).Select(p => new PersonModel
			{
				personId = p.personId,
				personFirstName = p.personFirstName,
				personLastName = p.personLastName,
				personBeforeTelephone = p.personBeforeTelephone,
				personTelephone = p.personTelephone,
				personBeforeCellphone = p.personBeforeCellphone,
				personCellphone = p.personCellphone,
				personCode = p.personCode
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.SingleOrDefault();
			else
				return resultSP.SingleOrDefault();
		}


		public int DeletePerson(string personId)
		{
			var resultSP = DB.DeletePerson(personId);

			if (GlobalVariable.queryType == 0)
			{
				PERSON person = DB.PERSONS.Where(p => p.personId.Equals(personId)).SingleOrDefault();
				DB.PERSONS.Attach(person);
				if (person == null)
					return 0;
				DB.PERSONS.Remove(person);
				DB.SaveChanges();
				return 1;
			}
			else
				return resultSP;
		}


		public bool checkIfIdExists(string id)
		{
			if (GlobalVariable.queryType == 0)
				return DB.PERSONS.Any(p => p.personId.Equals(id));
			else
			{
				if (DB.checkIfIdExists(id).Equals(1))
					return true;
				else
					return false;
			}
		}
	}
}