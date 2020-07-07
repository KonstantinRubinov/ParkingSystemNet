using ParkingSystem.EntityDataBase;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
	public class EntityCellphoneManager : EntityBaseManager, ICellphoneRepository
	{
		public List<CellphoneModel> GetAllCellphones()
		{
			var resultQuary = DB.BeforeCellphones.Select(c => new CellphoneModel
			{
				beforeCellphone = c.beforeCellphone1
			});

			var resultSP = DB.GetAllCellphones().Select(beforeCellphone1 => new CellphoneModel
			{
				beforeCellphone = beforeCellphone1
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.ToList();
			else
				return resultSP.ToList();
		}


		public CellphoneModel GetOneBeforeCellphone(string beforeCellphone1)
		{
			var resultQuary = DB.BeforeCellphones.Where(c => c.beforeCellphone1.Equals(beforeCellphone1)).Select(c => new CellphoneModel
			{
				beforeCellphone = c.beforeCellphone1
			});

			var resultSP = DB.GetOneBeforeCellphone(beforeCellphone1).Select(beforeCellphone2 => new CellphoneModel
			{
				beforeCellphone = beforeCellphone2
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.SingleOrDefault();
			else
				return resultSP.SingleOrDefault();
		}


		public CellphoneModel AddCellphone(CellphoneModel cellphoneModel)
		{
			var resultSP = DB.AddCellphone(cellphoneModel.beforeCellphone).Select(beforeCellphone2 => new CellphoneModel
			{
				beforeCellphone = beforeCellphone2
			});

			if (GlobalVariable.queryType == 0)
			{
				BeforeCellphone beforeCellphone = new BeforeCellphone
				{
					beforeCellphone1 = cellphoneModel.beforeCellphone
				};

				DB.BeforeCellphones.Add(beforeCellphone);
				DB.SaveChanges();
				return GetOneBeforeCellphone(beforeCellphone.beforeCellphone1);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public CellphoneModel UpdateCellphone(CellphoneModel cellphoneModel)
		{
			var resultSP = DB.UpdateCellphone(cellphoneModel.beforeCellphone).Select(beforeCellphone2 => new CellphoneModel
			{
				beforeCellphone = beforeCellphone2
			});

			if (GlobalVariable.queryType == 0)
			{
				BeforeCellphone beforeCellphone = DB.BeforeCellphones.Where(c => c.beforeCellphone1.Equals(cellphoneModel.beforeCellphone)).SingleOrDefault();
				if (beforeCellphone == null)
					return null;
				beforeCellphone.beforeCellphone1 = cellphoneModel.beforeCellphone;
				DB.SaveChanges();
				return GetOneBeforeCellphone(beforeCellphone.beforeCellphone1);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public int DeleteCellphone(string beforeCellphone1)
		{
			var resultSP = DB.DeleteCellphone(beforeCellphone1);

			if (GlobalVariable.queryType == 0)
			{
				BeforeCellphone beforeCellphone = DB.BeforeCellphones.Where(c => c.beforeCellphone1.Equals(beforeCellphone1)).SingleOrDefault();
				DB.BeforeCellphones.Attach(beforeCellphone);
				if (beforeCellphone == null)
					return 0;
				DB.BeforeCellphones.Remove(beforeCellphone);
				DB.SaveChanges();
				return 1;
			}
			else
				return resultSP;
		}
	}
}
