using ParkingSystem.EntityDataBase;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
	public class EntityTelephoneManager : EntityBaseManager, ITelephoneRepository
	{
		public List<TelephoneModel> GetAllTelephones()
		{
			var resultQuary = DB.BeforeTelephones.Select(t => new TelephoneModel
			{
				beforeTelephone = t.beforeTelephone1
			});

			var resultSP = DB.GetAllTelephones().Select(beforeTelephone1 => new TelephoneModel
			{
				beforeTelephone = beforeTelephone1
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.ToList();
			else
				return resultSP.ToList();
		}


		public TelephoneModel GetOneBeforeTelephone(string beforeTelephone1)
		{
			var resultQuary = DB.BeforeCellphones.Where(c => c.beforeCellphone1.Equals(beforeTelephone1)).Select(c => new TelephoneModel
			{
				beforeTelephone = c.beforeCellphone1
			});

			var resultSP = DB.GetOneBeforeTelephone(beforeTelephone1).Select(beforeTelephone2 => new TelephoneModel
			{
				beforeTelephone = beforeTelephone2
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.SingleOrDefault();
			else
				return resultSP.SingleOrDefault();
		}


		public TelephoneModel AddTelephone(TelephoneModel telephoneModel)
		{
			var resultSP = DB.AddTelephone(telephoneModel.beforeTelephone).Select(beforeTelephone2 => new TelephoneModel
			{
				beforeTelephone = beforeTelephone2
			});

			if (GlobalVariable.queryType == 0)
			{
				BeforeTelephone beforeTelephone = new BeforeTelephone
				{
					beforeTelephone1 = telephoneModel.beforeTelephone
				};

				DB.BeforeTelephones.Add(beforeTelephone);
				DB.SaveChanges();
				return GetOneBeforeTelephone(beforeTelephone.beforeTelephone1);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public TelephoneModel UpdateTelephone(TelephoneModel telephoneModel)
		{
			var resultSP = DB.UpdateTelephone(telephoneModel.beforeTelephone).Select(beforeTelephone2 => new TelephoneModel
			{
				beforeTelephone = beforeTelephone2
			});

			if (GlobalVariable.queryType == 0)
			{
				BeforeTelephone beforeTelephone = DB.BeforeTelephones.Where(t => t.beforeTelephone1.Equals(telephoneModel.beforeTelephone)).SingleOrDefault();
				if (beforeTelephone == null)
					return null;
				beforeTelephone.beforeTelephone1 = telephoneModel.beforeTelephone;
				DB.SaveChanges();
				return GetOneBeforeTelephone(beforeTelephone.beforeTelephone1);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public int DeleteTelephone(string beforeTelephone1)
		{
			var resultSP = DB.DeleteTelephone(beforeTelephone1);

			if (GlobalVariable.queryType == 0)
			{
				BeforeTelephone beforeTelephone = DB.BeforeTelephones.Where(t => t.beforeTelephone1.Equals(beforeTelephone1)).SingleOrDefault();
				DB.BeforeTelephones.Attach(beforeTelephone);
				if (beforeTelephone == null)
					return 0;
				DB.BeforeTelephones.Remove(beforeTelephone);
				DB.SaveChanges();
				return 1;
			}
			else
				return resultSP;
		}
	}
}
