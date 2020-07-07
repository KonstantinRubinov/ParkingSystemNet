using ParkingSystem.EntityDataBase;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
	public class EntityApprovalTypeManager : EntityBaseManager, IApprovalTypesRepository
	{
		public List<ApprovalTypeModel> GetAllApprovalTypes()
		{
			var resultQuary = DB.APPROVALTYPES.Select(a => new ApprovalTypeModel
			{
				approvalCode = a.approvalCode,
				approvalName = a.approvalName
			});

			var resultSP = DB.GetAllApprovalTypes().Select(a => new ApprovalTypeModel
			{
				approvalCode = a.approvalCode,
				approvalName = a.approvalName
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.ToList();
			else
				return resultSP.ToList();
		}


		public ApprovalTypeModel GetOneApprovalTypeByCode(string approvalCode)
		{
			var resultQuary = DB.APPROVALTYPES.Where(a => a.approvalCode.Equals(approvalCode)).Select(a => new ApprovalTypeModel
			{
				approvalCode = a.approvalCode,
				approvalName = a.approvalName
			});

			var resultSP = DB.GetOneApprovalTypeByCode(approvalCode).Select(a => new ApprovalTypeModel
			{
				approvalCode = a.approvalCode,
				approvalName = a.approvalName
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.SingleOrDefault();
			else
				return resultSP.SingleOrDefault();
		}


		public ApprovalTypeModel AddApprovalType(ApprovalTypeModel approvalTypeModel)
		{
			var resultSP = DB.AddApprovalType(approvalTypeModel.approvalCode, approvalTypeModel.approvalName).Select(a => new ApprovalTypeModel
			{
				approvalCode = a.approvalCode,
				approvalName = a.approvalName
			});

			if (GlobalVariable.queryType == 0)
			{
				APPROVALTYPE approvalType = new APPROVALTYPE
				{
					approvalCode = approvalTypeModel.approvalCode,
					approvalName = approvalTypeModel.approvalName
				};
				DB.APPROVALTYPES.Add(approvalType);
				DB.SaveChanges();
				return GetOneApprovalTypeByCode(approvalType.approvalCode);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public ApprovalTypeModel UpdateApprovalType(ApprovalTypeModel approvalTypeModel)
		{
			var resultSP = DB.UpdateApprovalType(approvalTypeModel.approvalCode, approvalTypeModel.approvalName).Select(a => new ApprovalTypeModel
			{
				approvalCode = a.approvalCode,
				approvalName = a.approvalName
			});

			if (GlobalVariable.queryType == 0)
			{
				APPROVALTYPE approvalType = DB.APPROVALTYPES.Where(a => a.approvalCode.Equals(approvalTypeModel.approvalCode)).SingleOrDefault();
				if (approvalType == null)
					return null;
				approvalType.approvalCode = approvalTypeModel.approvalCode;
				approvalType.approvalName = approvalTypeModel.approvalName;
				DB.SaveChanges();
				return GetOneApprovalTypeByCode(approvalType.approvalCode);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public int DeleteApprovalType(string approvalCode)
		{
			var resultSP = DB.DeleteApprovalType(approvalCode);

			if (GlobalVariable.queryType == 0)
			{
				APPROVALTYPE approvalType = DB.APPROVALTYPES.Where(a => a.approvalCode.Equals(approvalCode)).SingleOrDefault();
				DB.APPROVALTYPES.Attach(approvalType);
				if (approvalType == null)
					return 0;
				DB.APPROVALTYPES.Remove(approvalType);
				DB.SaveChanges();
				return 1;
			}
			else
				return resultSP;
		}
	}
}
