using HDdelivery.Web.Models.APIs.VMs;
using Microsoft.AspNetCore.Authorization;
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
    [Route("api/transaction/")]
    public class TransactionContoller : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly ITransactionService _transactionService;
        // private readonly MessageHubService _messageHubService;
        private readonly IConfiguration _configration;

        public TransactionContoller(IUserService userService, ITransactionService transaction, IConfiguration configration)
        {
            _userService = userService;
           _transactionService=transaction;
            _configration = configration;
        }


      
        [HttpPost("send-money")]
        public async Task<IActionResult> SendMoney([FromForm] TransactionVM transactionDTO)
        {
            try
            {


                StringValues lang = string.Empty;
                HttpContext.Request.Headers.TryGetValue("lang", out lang);
                string language = lang.ToString();
               
   

                //string senderid=   GetUserId();

                var user = _transactionService.Create(new TransactionDTO { 
                    RecieverId = transactionDTO.phoneNumber,
                    SendrId = transactionDTO.SenderphoneNumber,
                    Value=transactionDTO.value

                });
              
                UserInfoResponse userInfoResponse = new UserInfoResponse()
                {
                    User = user,
                    Status = StatusCodes.Status200OK,
                    Message = language == "en" ? "sent successfully" : "تم التسجيل بنجاح"
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

        [HttpGet("all-transactions")]
        public async Task<IActionResult> GetAllTransactions()
        {
            try
            {


                StringValues lang = string.Empty;
                HttpContext.Request.Headers.TryGetValue("lang", out lang);
                string language = lang.ToString();
                string filePath = string.Empty;

                var transactions = _transactionService.GetAll();



                TransactionResponse userInfoResponse = new TransactionResponse()
                {
                    data = transactions.ToList(),
                    Status = StatusCodes.Status200OK,
                    Message = language == "en" ? "all transactions" : ""
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
        protected string GetUserId()
        {
            return this.User.Claims.First(i => i.Type == "id").Value;
        }

    }
}
