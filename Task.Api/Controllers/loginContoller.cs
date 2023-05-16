using HDdelivery.Web.Models.APIs.VMs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Task.Api.Resopnse;
using Task.Service.DTO.User;
using Task.Service.Enums;
using Task.Service.IService;

namespace Task.Api.Controllers
{
   

    [ApiController]
    [Route("api/people/")]
    public class LoginController : ControllerBase
    {

        private readonly IUserService _userService;
        // private readonly MessageHubService _messageHubService;
        private readonly IConfiguration _configration;

        public LoginController(IUserService userService, IConfiguration configration)
        {
            // _messageService = messageService;
            _userService = userService;
            //  _messageHubService = messageHubService;
            _configration = configration;
        }


        [HttpPost("login")]

        //[Consumes("application/x-www-form-urlencoded")]
        public IActionResult LoginBody(LoginVM loginVM)
        {

            try
            {

                StringValues lang = string.Empty;
                HttpContext.Request.Headers.TryGetValue("lang", out lang);
                string language = lang.ToString();
                if (loginVM != null || loginVM.Phone != null || loginVM.Password != null)
                {
                    var user = _userService.LoginMobile(loginVM.Phone, loginVM.Password, loginVM.DeviceToken);
                    if (user != null && (user.Type == UserTypesEnum.User))
                    {
                        var claims = new[]
                        {
                        new Claim (JwtRegisteredClaimNames.Sub,_configration["Jwt:Subject"]),
                        new Claim (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim (JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                        new Claim ("Id",user.Id.ToString()),
                        new Claim ("UserName",user.Name),
                        new Claim ("Phone",user.Mobile),
                    };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(_configration["Jwt:Issuer"], _configration["Jwt:Audience"],
                                                        claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
                        user.Token = new JwtSecurityTokenHandler().WriteToken(token);
                        UserInfoResponse userInfoResponse = new UserInfoResponse()
                        {
                            User = user,
                            Status = StatusCodes.Status200OK,
                            Message = language == "en" ? "you're ready logged in" : "تم تسجيل الدخول بنجاح"
                        };
                        return Ok(userInfoResponse);
                    }
                    else
                    {
                        UserInfoResponse userInfoResponse = new UserInfoResponse()
                        {
                            User = { },
                            Status = StatusCodes.Status500InternalServerError,
                            Message = language == "en" ? "Invalid Email and Password" : "البريد الالكتروني أو كلمة المرور غير صحيحة"
                        };
                        return Ok(userInfoResponse);
                    }
                }
                else
                {
                    UserInfoResponse userInfoResponse = new UserInfoResponse()
                    {
                        User = { },
                        Status = StatusCodes.Status500InternalServerError,
                        Message = language == "en" ? "Invalid Email and Password" : "حدث خطأ في الدخول"
                    };
                    return Ok(userInfoResponse);
                }
            }
            catch (Exception ex)
            {
                UserInfoResponse userInfoResponse = new UserInfoResponse()
                {
                    User = { },
                    Status = StatusCodes.Status500InternalServerError,
                    Message = ex.Message
                };
                return Ok(userInfoResponse);
            }
        }




        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromForm] CreatingUserDto creatingUserDto)
        {
            try
            {


                StringValues lang = string.Empty;
                HttpContext.Request.Headers.TryGetValue("lang", out lang);
                string language = lang.ToString();
                string filePath = string.Empty;
               


                if (creatingUserDto.Type != (int)UserTypesEnum.User || creatingUserDto.Type != (int)UserTypesEnum.Driver)
                {
                    creatingUserDto.Type = (int)UserTypesEnum.User;
                }



                var user = _userService.Create(creatingUserDto);
                var claims = new[]
                    {
                        new Claim (JwtRegisteredClaimNames.Sub,_configration["Jwt:Subject"]),
                        new Claim (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim (JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                        new Claim ("Id",user.Id.ToString()),
                        new Claim ("UserName",user.Name),
                        new Claim ("Phone",user.Mobile),
                    };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(_configration["Jwt:Issuer"], _configration["Jwt:Audience"],
                                                claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
                user.Token = new JwtSecurityTokenHandler().WriteToken(token);
                UserInfoResponse userInfoResponse = new UserInfoResponse()
                {
                    User = user,
                    Status = StatusCodes.Status200OK,
                    Message = language == "en" ? "User Registeration Completed Successfually" : "تم التسجيل بنجاح"
                };
                return Ok(userInfoResponse);
            }
            catch (Exception ex)
            {
                UserInfoResponse userInfoResponse = new UserInfoResponse()
                {
                    User = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = ex.Message
                };
                return Ok(userInfoResponse);
            }
        }

        [HttpPost("forgot")]
        public IActionResult Forgot(ForgotPasswordVM forgotPasswordVM)
        {
            try
            {
                StringValues lang = string.Empty;
                HttpContext.Request.Headers.TryGetValue("lang", out lang);
                string language = lang.ToString();

                if (forgotPasswordVM.Phone == null)
                {
                    UserInfoResponse userInfoResponse = new UserInfoResponse()
                    {
                        User = forgotPasswordVM,
                        Status = StatusCodes.Status500InternalServerError,
                        Message = language == "en" ? "please enter email" : "برجاء ادخال البريد الالكتروني "
                    };
                    return Ok(userInfoResponse);
                }
                var isSend = _userService.ForgotPasswordMobileAsync(forgotPasswordVM.Phone);
                if (isSend)
                {
                    UserInfoResponse userInfoResponse = new UserInfoResponse()
                    {
                        User = { },
                        Status = StatusCodes.Status200OK,
                        Message = language == "en" ? "Verfication Code is send Sucessfullay to your Email" : "تم ارسال الرمز التأكيدي الي البريد الالكتروني بنجاح"
                    };
                    return Ok(userInfoResponse);
                }
                else
                {
                    UserInfoResponse userInfoResponse = new UserInfoResponse()
                    {
                        User = forgotPasswordVM,
                        Status = StatusCodes.Status500InternalServerError,
                        Message = language == "en" ? "there is a problem we can't send reset password to your Email" : "توجد مشكلة في ارسال الرمز التأكيدي الي البريد الالكتروني الخاص بك"
                    };
                    return Ok(userInfoResponse);
                }
            }
            catch (Exception ex)
            {
                UserInfoResponse userInfoResponse = new UserInfoResponse()
                {
                    User = forgotPasswordVM,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = ex.Message
                };
                return Ok(userInfoResponse);
            }
        }

        [HttpPost("confirm-verification-code")]
        public IActionResult ConfirmForgot(ConfirmForgotPasswordVM confirmForgotPasswordVM)
        {
            try
            {
                StringValues lang = string.Empty;
                HttpContext.Request.Headers.TryGetValue("lang", out lang);
                string language = lang.ToString();

                if (confirmForgotPasswordVM.Phone == null || confirmForgotPasswordVM.Code == null)
                {
                    UserInfoResponse userInfoResponse = new UserInfoResponse()
                    {
                        User = confirmForgotPasswordVM,
                        Status = StatusCodes.Status500InternalServerError,
                        Message = language == "en" ? "please enter Verification Code with Correct way" : " برجاء ادخال الرمز التأكيدي بطريقة صحيحة"
                    };
                    return Ok(userInfoResponse);
                }
                var isValid = _userService.ConfirmForgotMobile(confirmForgotPasswordVM.Phone, confirmForgotPasswordVM.Code);
                if (isValid)
                {
                    UserInfoResponse userInfoResponse = new UserInfoResponse()
                    {
                        User = { },
                        Status = StatusCodes.Status200OK,
                        Message = language == "en" ? "verification Code is Correct" : "الرمز التأكيدي صحيح"
                    };
                    return Ok(userInfoResponse);
                }
                else
                {
                    UserInfoResponse userInfoResponse = new UserInfoResponse()
                    {
                        User = confirmForgotPasswordVM,
                        Status = StatusCodes.Status500InternalServerError,
                        Message = language == "en" ? "Verification Code is Not Correct please try again" : "الرمز التأكيدي غير صحيح برجاء اعادة ادخال الرمز التأكيدي بطريقة صحيحة"
                    };
                    return Ok(userInfoResponse);
                }
            }
            catch (Exception ex)
            {
                UserInfoResponse userInfoResponse = new UserInfoResponse()
                {
                    User = confirmForgotPasswordVM,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = ex.Message
                };
                return Ok(userInfoResponse);
            }
        }

        [HttpPost("reset")]
        public IActionResult ResetPassword(ChangePasswordVM changePasswordVM)
        {
            try
            {
                StringValues lang = string.Empty;
                HttpContext.Request.Headers.TryGetValue("lang", out lang);
                string language = lang.ToString();

                if (changePasswordVM.newPassword == null || changePasswordVM.confirmPassword == null || changePasswordVM.Phone == null)
                {
                    UserInfoResponse userInfoResponse = new UserInfoResponse()
                    {
                        User = changePasswordVM,
                        Status = StatusCodes.Status500InternalServerError,
                        Message = language == "en" ? "Please Enter Password and Confirm Password Correct" : "برجاء إدخال كلمة المرور "
                    };
                    return Ok(userInfoResponse);
                }
                else if (changePasswordVM.newPassword != changePasswordVM.confirmPassword)
                {
                    UserInfoResponse userInfoResponse = new UserInfoResponse()
                    {
                        User = changePasswordVM,
                        Status = StatusCodes.Status500InternalServerError,
                        Message = language == "en" ? "Password and Confirm Password are not Identical" : "  كلمة المرور غير متطابقة"
                    };
                    return Ok(userInfoResponse);
                }
                else
                {
                    changePasswordVM.newPassword = BCrypt.Net.BCrypt.HashPassword(changePasswordVM.newPassword);
                    var user = _userService.Get(changePasswordVM.Phone);
                    var updatingUserDto = new UpdatingUserDto
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Mobile = user.Mobile,
                      
                        Type = user.Type,
                       
                        CreatedAt = user.CreatedAt,
                        LastModified = user.LastModified,
                        IsBlocked = user.IsBlocked,
                        IsDeleted = user.IsDeleted,
                        IsHasTempPassword = false,
                        TempPassword = user.TempPassword,
                        Password = changePasswordVM.newPassword
                    };
                    var updatedUserDto = _userService.Update(updatingUserDto);
                    UserInfoResponse userInfoResponse = new UserInfoResponse()
                    {
                        User = updatedUserDto,
                        Status = StatusCodes.Status200OK,
                        Message = language == "en" ? "Reset password completed Sucessfullay" : "تم تغيير كلمة المرور بنجاح"
                    };
                    return Ok(userInfoResponse);

                }

            }
            catch (Exception ex)
            {
                UserInfoResponse userInfoResponse = new UserInfoResponse()
                {
                    User = changePasswordVM,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = ex.Message
                };
                return Ok(userInfoResponse);
            }
        }

        //[HttpPost("send-message")]
        //public ActionResult Post(CreatingMessageDto creatingMessageDto)
        //{
        //    try
        //    {
        //        var messageCreated = _messageService.CreateApi(creatingMessageDto);
        //        int counter = _messageService.GetAllUnSeen().ToList().Count;
        //        _messageHubService.PublishNewMessage(messageCreated, counter);
        //        return Ok(messageCreated);

        //    }
        //    catch (Exception ex)
        //    {
        //        UserInfoResponse userInfoResponse = new UserInfoResponse()
        //        {
        //            User = { },
        //            Status = StatusCodes.Status500InternalServerError,
        //            Message = ex.Message
        //        };
        //        return Ok(userInfoResponse);
        //    }
        //}
    }
}
