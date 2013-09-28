using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using AutoMapper;
using Timesheet.Core;

namespace Timesheet
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<Domain.IServices.IAccountServices, Domain.Services.AccountServices>();
            container.RegisterType<Domain.IServices.IClientProfileVMServices, Domain.Services.ClientProfileVMService>();
            container.RegisterType<Domain.IServices.IMembership, Timesheet.Services.Membership>();
            container.RegisterType<Domain.Interfaces.IUserModelService, Domain.Services.UserModelService>();
            container.RegisterType<Domain.Interfaces.IProjectService, Domain.Services.ProjectVMService>();

            //for DAL
            Timesheet.Core.DataCtx.RegisterDataAccessLayerTypes(container);
        }
    }
}