using AutoMapper;
using Domain.Interfaces;
using Domain.IServices;
using Domain.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheet.Core;
using Timesheet.Tests.Services;

namespace Timesheet.Tests
{
    public class TestBootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();            
            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            RegisterMapper();
            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IAccountServices, AccountServices>();
            container.RegisterType<IClientProfileVMServices, ClientProfileVMService>();
            container.RegisterType<IMembership, FakeMembership>();
            container.RegisterType<IUserModelService, UserModelService>();
            container.RegisterType<IProjectService, ProjectVMService>();

            //for DAL
            Timesheet.Core.DataCtx.RegisterDataAccessLayerTypes(container);
        }

        public static void RegisterMapper()
        {
            Mapper.CreateMap<UserProfile, Domain.ViewModels.RegisterModel>();
            Mapper.CreateMap<UserProfile, Domain.ViewModels.UserModel>();
        }
    }
}
