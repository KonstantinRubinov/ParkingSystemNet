using ParkingSystem.EntityDataBase;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
	public class EntityApprovalManager : EntityBaseManager, IApprovalRepository
	{
		public List<ApprovalModel> GetAllApprovals()
		{
			var resultQuary = DB.APPROVALS.Select(a => new ApprovalModel
			{
				approvalCode = a.approvalCode,
				approvalFrom = a.approvalFrom,
				approvalUntil = a.approvalUntil,
				approvalPersonId = a.approvalPersonId,
				approvalNumber = a.approvalNumber
			});

			var resultSP = DB.GetAllApprovals().Select(a => new ApprovalModel
			{
				approvalCode = a.approvalCode,
				approvalFrom = a.approvalFrom,
				approvalUntil = a.approvalUntil,
				approvalPersonId = a.approvalPersonId,
				approvalNumber = a.approvalNumber
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.ToList();
			else
				return resultSP.ToList();
		}


		public ApprovalModel GetOneApprovalByCode(string approvalCode)
		{
			var resultQuary = DB.APPROVALS.Where(a => a.approvalCode.Equals(approvalCode)).Select(a => new ApprovalModel
			{
				approvalCode = a.approvalCode,
				approvalFrom = a.approvalFrom,
				approvalUntil = a.approvalUntil,
				approvalPersonId = a.approvalPersonId,
				approvalNumber = a.approvalNumber
			});

			var resultSP = DB.GetOneApprovalByCode(approvalCode).Select(a => new ApprovalModel
			{
				approvalCode = a.approvalCode,
				approvalFrom = a.approvalFrom,
				approvalUntil = a.approvalUntil,
				approvalPersonId = a.approvalPersonId,
				approvalNumber = a.approvalNumber
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.SingleOrDefault();
			else
				return resultSP.SingleOrDefault();
		}


		public ApprovalModel GetOneApprovalByPersonId(string personId)
		{
			var resultQuary = DB.APPROVALS.Where(a => a.approvalPersonId.Equals(personId)).Select(a => new ApprovalModel
			{
				approvalCode = a.approvalCode,
				approvalFrom = a.approvalFrom,
				approvalUntil = a.approvalUntil,
				approvalPersonId = a.approvalPersonId,
				approvalNumber = a.approvalNumber
			});

			var resultSP = DB.GetOneApprovalByPersonId(personId).Select(a => new ApprovalModel
			{
				approvalCode = a.approvalCode,
				approvalFrom = a.approvalFrom,
				approvalUntil = a.approvalUntil,
				approvalPersonId = a.approvalPersonId,
				approvalNumber = a.approvalNumber
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.SingleOrDefault();
			else
				return resultSP.SingleOrDefault();
		}


		public ApprovalModel GetOneApprovalByNumber(int approvalNumber)
		{
			var resultQuary = DB.APPROVALS.Where(a => a.approvalNumber== approvalNumber).Select(a => new ApprovalModel
			{
				approvalCode = a.approvalCode,
				approvalFrom = a.approvalFrom,
				approvalUntil = a.approvalUntil,
				approvalPersonId = a.approvalPersonId,
				approvalNumber = a.approvalNumber
			});

			var resultSP = DB.GetOneApprovalByNumber(approvalNumber).Select(a => new ApprovalModel
			{
				approvalCode = a.approvalCode,
				approvalFrom = a.approvalFrom,
				approvalUntil = a.approvalUntil,
				approvalPersonId = a.approvalPersonId,
				approvalNumber = a.approvalNumber
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.SingleOrDefault();
			else
				return resultSP.SingleOrDefault();
		}


		public ApprovalModel AddApproval(ApprovalModel approvalModel)
		{
			var resultSP = DB.AddApproval(approvalModel.approvalCode, approvalModel.approvalFrom, approvalModel.approvalUntil, approvalModel.approvalPersonId).Select(a => new ApprovalModel
			{
				approvalCode = a.approvalCode,
				approvalFrom = a.approvalFrom,
				approvalUntil = a.approvalUntil,
				approvalPersonId = a.approvalPersonId,
				approvalNumber = a.approvalNumber
			});

			if (GlobalVariable.queryType == 0)
			{
				APPROVAL approval = new APPROVAL
				{
					approvalCode = approvalModel.approvalCode,
					approvalFrom = approvalModel.approvalFrom,
					approvalUntil = approvalModel.approvalUntil,
					approvalPersonId = approvalModel.approvalPersonId
				};
				DB.APPROVALS.Add(approval);
				DB.SaveChanges();
				return GetOneApprovalByNumber(approval.approvalNumber);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public ApprovalModel UpdateApproval(ApprovalModel approvalModel)
		{
			var resultSP = DB.UpdateApproval(approvalModel.approvalCode, approvalModel.approvalFrom, approvalModel.approvalUntil, approvalModel.approvalPersonId, approvalModel.approvalNumber).Select(a => new ApprovalModel
			{
				approvalCode = a.approvalCode,
				approvalFrom = a.approvalFrom,
				approvalUntil = a.approvalUntil,
				approvalPersonId = a.approvalPersonId,
				approvalNumber = a.approvalNumber
			});

			if (GlobalVariable.queryType == 0)
			{
				APPROVAL approval = DB.APPROVALS.Where(a => a.approvalPersonId == approvalModel.approvalPersonId).SingleOrDefault();
				if (approval == null)
					return null;
				approval.approvalCode = approvalModel.approvalCode;
				approval.approvalFrom = approvalModel.approvalFrom;
				approval.approvalUntil = approvalModel.approvalUntil;
				approval.approvalPersonId = approvalModel.approvalPersonId;
				approval.approvalNumber = approvalModel.approvalNumber;
				DB.SaveChanges();
				return GetOneApprovalByNumber(approval.approvalNumber);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public int DeleteApproval(int approvalNumber)
		{
			var resultSP = DB.DeleteApprovalByNumber(approvalNumber);

			if (GlobalVariable.queryType == 0)
			{
				APPROVAL approval = DB.APPROVALS.Where(a => a.approvalNumber == approvalNumber).SingleOrDefault();
				DB.APPROVALS.Attach(approval);
				if (approval == null)
					return 0;
				DB.APPROVALS.Remove(approval);
				DB.SaveChanges();
				return 1;
			}
			else
				return resultSP;
		}


		public int DeleteApprovalById(string approvalPersonId)
		{
			var resultSP = DB.DeleteApprovalByPerson(approvalPersonId);

			if (GlobalVariable.queryType == 0)
			{
				APPROVAL approval = DB.APPROVALS.Where(a => a.approvalPersonId.Equals(approvalPersonId)).SingleOrDefault();
				DB.APPROVALS.Attach(approval);
				if (approval == null)
					return 0;
				DB.APPROVALS.Remove(approval);
				DB.SaveChanges();
				return 1;
			}
			else
				return resultSP;
		}
	}
}
