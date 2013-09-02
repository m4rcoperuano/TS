using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using AutoMapper;

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
        container.RegisterType<Domain.IServices.IAccountServices, Timesheet.Services.AccountServices>();
        container.RegisterType<Domain.IServices.IClientServices, Timesheet.Services.ClientService>();
        container.RegisterType<Domain.IServices.IMembership, Timesheet.Services.AccountMembership>();
    }

    public static void RegisterMapper()
    {
        Mapper.CreateMap<Domain.Models.RegisterModel, DataSource.UserProfile>();
    }
  }
}