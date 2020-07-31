using SimpleInjector;
using System.Web.Http;
using System.Web.Mvc;

namespace ParkingSystem
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		private void ConfigureApi()
		{
			var container = new Container();
			container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

			if (GlobalVariable.logicType == 0)
			{
				container.Register<IApprovalRepository, EntityApprovalManager>();
				container.Register<IApprovalTypesRepository, EntityApprovalTypeManager>();
				container.Register<ICellphoneRepository, EntityCellphoneManager>();
				container.Register<ICourseRepository, EntityCourseManager>();
				container.Register<IFacultyRepository, EntityFacultyManager>();
				container.Register<IPersonRepository, EntityPersonManager>();
				container.Register<IStudentRepository, EntityStudentManager>();
				container.Register<ITeacherRepository, EntityTeacherManager>();
				container.Register<ITelephoneRepository, EntityTelephoneManager>();
				container.Register<IThreeObjectsRepository, EntityThreeObjectsManager>();
				container.Register<IVehicleRepository, EntityVehicleManager>();
			}
			else if (GlobalVariable.logicType == 1)
			{
				container.Register<IApprovalRepository, SqlApprovalManager>();
				container.Register<IApprovalTypesRepository, SqlApprovalTypeManager>();
				container.Register<ICellphoneRepository, SqlCellphoneManager>();
				container.Register<ICourseRepository, SqlCourseManager>();
				container.Register<IFacultyRepository, SqlFacultyManager>();
				container.Register<IPersonRepository, SqlPersonManager>();
				container.Register<IStudentRepository, SqlStudentManager>();
				container.Register<ITeacherRepository, SqlTeacherManager>();
				container.Register<ITelephoneRepository, SqlTelephoneManager>();
				container.Register<IThreeObjectsRepository, SqlThreeObjectsManager>();
				container.Register<IVehicleRepository, SqlVehicleManager>();
			}
			else if (GlobalVariable.logicType == 2)
			{
				container.Register<IApprovalRepository, MySqlApprovalManager>();
				container.Register<IApprovalTypesRepository, MySqlApprovalTypeManager>();
				container.Register<ICellphoneRepository, MySqlCellphoneManager>();
				container.Register<ICourseRepository, MySqlCourseManager>();
				container.Register<IFacultyRepository, MySqlFacultyManager>();
				container.Register<IPersonRepository, MySqlPersonManager>();
				container.Register<IStudentRepository, MySqlStudentManager>();
				container.Register<ITeacherRepository, MySqlTeacherManager>();
				container.Register<ITelephoneRepository, MySqlTelephoneManager>();
				container.Register<IThreeObjectsRepository, MySqlThreeObjectsManager>();
				container.Register<IVehicleRepository, MySqlVehicleManager>();
			}
			else if (GlobalVariable.logicType == 3)
			{
				container.Register<IApprovalRepository, InnerApprovalManager>();
				container.Register<IApprovalTypesRepository, InnerApprovalTypeManager>();
				container.Register<ICellphoneRepository, InnerCellphoneManager>();
				container.Register<ICourseRepository, InnerCourseManager>();
				container.Register<IFacultyRepository, InnerFacultyManager>();
				container.Register<IPersonRepository, InnerPersonManager>();
				container.Register<IStudentRepository, InnerStudentManager>();
				container.Register<ITeacherRepository, InnerTeacherManager>();
				container.Register<ITelephoneRepository, InnerTelephoneManager>();
				container.Register<IThreeObjectsRepository, InnerThreeObjectsManager>();
				container.Register<IVehicleRepository, InnerVehicleManager>();
			}
			else
			{
				container.Register<IApprovalRepository, MongoApprovalManager>();
				container.Register<IApprovalTypesRepository, MongoApprovalTypeManager>();
				container.Register<ICellphoneRepository, MongoCellphoneManager>();
				container.Register<ICourseRepository, MongoCourseManager>();
				container.Register<IFacultyRepository, MongoFacultyManager>();
				container.Register<IPersonRepository, MongoPersonManager>();
				container.Register<IStudentRepository, MongoStudentManager>();
				container.Register<ITeacherRepository, MongoTeacherManager>();
				container.Register<ITelephoneRepository, MongoTelephoneManager>();
				container.Register<IThreeObjectsRepository, MongoThreeObjectsManager>();
				container.Register<IVehicleRepository, MongoVehicleManager>();
			}
			container.Verify();
			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
			GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorDependencyResolver(container);
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			ConfigureApi();

			GlobalConfiguration.Configure(WebApiConfig.Register);
		}
	}
}
