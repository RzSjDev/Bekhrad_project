using Bekhrad_project.Controllers;
using Bekhrad_project.Repository;
using Bekhrad_project.Repository.Group;
using Bekhrad_project.Repository.User;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace Bekhrad_project
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IGroupUserRepository, GroupUserRepository>();

            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
           
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}