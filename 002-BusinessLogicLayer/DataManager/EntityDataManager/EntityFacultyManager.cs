using ParkingSystem.EntityDataBase;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
	public class EntityFacultyManager : EntityBaseManager, IFacultyRepository
	{
		public List<FacultyModel> GetAllFaculties()
		{
			var resultQuary = DB.FACULTYS.Select(f => new FacultyModel
			{
				facultyCode = f.facultyCode,
				facultyHead = f.facultyHead,
				facultyName = f.facultyName
			});

			var resultSP = DB.GetAllFaculties().Select(f => new FacultyModel
			{
				facultyCode = f.facultyCode,
				facultyHead = f.facultyHead,
				facultyName = f.facultyName
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.ToList();
			else
				return resultSP.ToList();
		}


		public FacultyModel GetOneFacultyByCode(string facultyCode)
		{
			var resultQuary = DB.FACULTYS.Where(f => f.facultyCode.Equals(facultyCode)).Select(f => new FacultyModel
			{
				facultyCode = f.facultyCode,
				facultyHead = f.facultyHead,
				facultyName = f.facultyName
			});

			var resultSP = DB.GetOneFacultyByCode(facultyCode).Select(f => new FacultyModel
			{
				facultyCode = f.facultyCode,
				facultyHead = f.facultyHead,
				facultyName = f.facultyName
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.SingleOrDefault();
			else
				return resultSP.SingleOrDefault();
		}


		public FacultyModel AddFaculty(FacultyModel facultyModel)
		{
			var resultSP = DB.AddFaculty(facultyModel.facultyCode, facultyModel.facultyName, facultyModel.facultyHead).Select(f => new FacultyModel
			{
				facultyCode = f.facultyCode,
				facultyHead = f.facultyHead,
				facultyName = f.facultyName
			});

			if (GlobalVariable.queryType == 0)
			{
				FACULTY faculty = new FACULTY
				{
					facultyCode = facultyModel.facultyCode,
					facultyHead = facultyModel.facultyHead,
					facultyName = facultyModel.facultyName
				};

				DB.FACULTYS.Add(faculty);
				DB.SaveChanges();
				return GetOneFacultyByCode(faculty.facultyCode);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public FacultyModel UpdateFaculty(FacultyModel facultyModel)
		{
			var resultSP = DB.UpdateFaculty(facultyModel.facultyCode, facultyModel.facultyName, facultyModel.facultyHead).Select(f => new FacultyModel
			{
				facultyCode = f.facultyCode,
				facultyHead = f.facultyHead,
				facultyName = f.facultyName
			});

			if (GlobalVariable.queryType == 0)
			{
				FACULTY faculty = DB.FACULTYS.Where(f => f.facultyCode.Equals(facultyModel.facultyCode)).SingleOrDefault();
				if (faculty == null)
					return null;
				faculty.facultyCode = facultyModel.facultyCode;
				faculty.facultyHead = facultyModel.facultyHead;
				faculty.facultyName = facultyModel.facultyName;
				DB.SaveChanges();
				return GetOneFacultyByCode(faculty.facultyCode);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public int DeleteFaculty(string facultyCode)
		{
			var resultSP = DB.DeleteFaculty(facultyCode);

			if (GlobalVariable.queryType == 0)
			{
				FACULTY faculty = DB.FACULTYS.Where(f => f.facultyCode.Equals(facultyCode)).SingleOrDefault();
				DB.FACULTYS.Attach(faculty);
				if (faculty == null)
					return 0;
				DB.FACULTYS.Remove(faculty);
				DB.SaveChanges();
				return 1;
			}
			else
				return resultSP;
		}
	}
}
