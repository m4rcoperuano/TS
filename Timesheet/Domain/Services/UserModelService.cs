using AutoMapper;
using Domain.Interfaces;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheet.Core.Interfaces;
using Timesheet.Core;

namespace Domain.Services
{
    public class UserModelService : IUserModelService
    {
        private IRepository Repository;
        public UserModelService(IRepository repository)
        {
            this.Repository = repository;
        }

        public UserModel GetUser(int userId)
        {
            UserProfile user = this.Repository.Single<UserProfile>(x=>x.UserId == userId);
            UserModel userModel = this.BuildUserModel(user);

            return userModel;
        }

        private UserModel BuildUserModel(UserProfile userProfile)
        {
            Mapper.CreateMap<UserProfile, UserModel>();
            UserModel userModel = Mapper.Map<UserModel>(userProfile);
            userModel.CompanyId = userProfile.CompanyLocation.fk_company;
            userModel.CompanyLocationId = userProfile.fk_company_location;
            userModel.CreatedOn = userProfile.created_on;
            userModel.Deleted = userProfile.deleted_on != null;
            userModel.DeletedOn = userProfile.deleted_on;
            userModel.UpdatedOn = userProfile.updated_on;            

            return userModel;
        }
    }
}
