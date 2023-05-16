using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Service.DTO.User;
using Task.Service.Enums;

namespace Task.Service.IService
{
    public interface IUserService
    {
        UserDto Get(Guid id);
        UserDto Login(string email, string password);
        IEnumerable<UserDto> GetAll();
        IEnumerable<UserDto> GetAll(UserTypesEnum userTypesEnum);
        UpdatedUserDto Update(UpdatingUserDto updatingUserDto);
        UpdatedUserDto UpdateMoile(UpdatingUserDto updatingUserDto);
        CreatedUserDto Create(CreatingUserDto creatingUserDto);
        void Delete(Guid id);
        bool ForgotPassword(string email);
        UserDto ConfirmForgotPassword(string email, string tempPassword);
        void BlockUserById(Guid id);
        void ActiveUserById(Guid id);
        UserDto Get(string phone);
        UserDto LoginMobile(string email, string password, string deviceToken);
        bool ConfirmForgotMobile(string phone, string code);
        bool ForgotPasswordMobileAsync(string phone);
        //Task SendSMS(string phoneNo, string msg);
        void UpdateUserBalance(Guid userId, double storecoins);
    }
}
