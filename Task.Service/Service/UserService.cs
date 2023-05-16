using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Task.Data.Models;
using Task.Repo.Base;
using Task.Repo.IRepo;
using Task.Service.DTO.User;
using Task.Service.Enums;
using Task.Service.IService;
using BC = BCrypt.Net.BCrypt;
namespace Task.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

     

        public IUnitOfWork _unitOfWork { get; }
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUserRepository userRepository,
                          
                           IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
          
            _unitOfWork = unitOfWork; _mapper = mapper;
        }

        public CreatedUserDto Create(CreatingUserDto creatingUserDto)
        {
            var user = _mapper.Map<CreatingUserDto, User>(creatingUserDto);
            if (user.Password == null)
            {
                user.Password = Generate(new RandomPasswordOptions());
                user.IsHasTempPassword = true;
                var createdUserDto = _userRepository.Create(user);
                _unitOfWork.Commit();
                var url = "http://localhost:4254/Account";

          
                return _mapper.Map<User, CreatedUserDto>(createdUserDto);
            }
            else
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                user.Balance = 1000;
                var createdUserDto = _userRepository.Create(user);
                _unitOfWork.Commit();
                return _mapper.Map<User, CreatedUserDto>(createdUserDto);
            }
        }

        public void Delete(Guid id)
        {
            _userRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public UserDto Get(Guid id)
        {
            var user = _userRepository.Get(id);
            return _mapper.Map<User, UserDto>(user);
        }

        public IEnumerable<UserDto> GetAll()
        {
            var users = _userRepository.GetRange();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public IEnumerable<UserDto> GetAll(UserTypesEnum userTypesEnum)
        {
            var users = _userRepository.GetRange(x => x.Type == (int)userTypesEnum).OrderByDescending(x => x.CreatedAt);
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }
        public UpdatedUserDto Update(UpdatingUserDto updatingUserDto)
        {

            var user = _mapper.Map<UpdatingUserDto, User>(updatingUserDto);
            var updatedUser = _userRepository.Update(user);
            _unitOfWork.Commit();
            return _mapper.Map<User, UpdatedUserDto>(updatedUser);
        }

        public UserDto Login(string mobile, string password)
        {
            var user = _userRepository.Get(x => x.Mobile.ToLower() == mobile.ToLower());
            if (user == null)
                throw new Exception("Either your Credential Is not Correct");
            if (user.IsHasTempPassword)
            {
                var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
                if (!BC.Verify(password, user.TempPassword))
                    throw new Exception("Either your E-mail address or password Is not Correct");
                return _mapper.Map<User, UserDto>(user);
            }
            if (!BC.Verify(password, user.Password))
                throw new Exception("Either your E-mail address or password Is not Correct");
            if (user.IsBlocked.Value)
                throw new Exception("this user is blocked by admin please check with administrator");
            if (user.IsDeleted)
                throw new Exception("Not Authenticated User");
            return _mapper.Map<User, UserDto>(user);
        }

        public bool ForgotPassword(string email)
        {
            if (email == null)
            {
                throw new Exception("Invalid Email");
            }
            User user = _userRepository.Get(item => item.Mobile.ToLower() == email.ToLower());
            if (user == null)
                throw new Exception("your e-mail address is not Correct");

            var randomPassword = Generate(new RandomPasswordOptions());
            user.IsHasTempPassword = true;
            user.TempPassword = BCrypt.Net.BCrypt.HashPassword(randomPassword);
            user = _userRepository.Update(user);
            _unitOfWork.Commit();

            var url = "http://localhost:4254/Account/";

            var isSend = true;
            if (isSend)
                return true;
            else
                throw new Exception("there is a problem we can't send reset password to your Email");
        }

        public string Generate(RandomPasswordOptions options)
        {
            string[] randomChars = new[] {
                "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
                "abcdefghijkmnopqrstuvwxyz",    // lowercase
                "0123456789",                   // digits
                "!@#$%&?"                        // non-alphanumeric
            };
            Random rand = new Random();
            List<char> chars = new List<char>();

            if (options.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count), randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (options.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (options.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (options.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < options.RequiredLength
                || chars.Distinct().Count() < options.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }

        public UserDto ConfirmForgotPassword(string mobile, string tempPassword)
        {
            User user = _userRepository.Get(u => u.Mobile == mobile);
            if (user == null)
                throw new Exception("Either your E-mail address is not Correct");
            if (!user.IsHasTempPassword)
                throw new Exception("you need to forget password first");
            if (!BC.Verify(tempPassword, user.TempPassword))
                throw new Exception("Either password is not Correct");

            user.Password = user.TempPassword;
            user.TempPassword = null;
            user.IsHasTempPassword = false;
            user = _userRepository.Update(user);
            _unitOfWork.Commit();
            return _mapper.Map<User, UserDto>(user);
        }

        public UserDto Get(string phone)
        {
            var user = _userRepository.GetRange(x => x.Mobile == phone).FirstOrDefault();
            return _mapper.Map<User, UserDto>(user);
        }

        public void BlockUserById(Guid id)
        {
            var user = _userRepository.Get(id);
            if (user.IsBlocked.Value)
                throw new Exception("User Blocked Already");
            else
                user.IsBlocked = true;
            _unitOfWork.Commit();
        }

        public void ActiveUserById(Guid id)
        {
            var user = _userRepository.Get(id);
            if (!user.IsBlocked.Value)
                throw new Exception("User not Blocked Already");
            else
                user.IsBlocked = false;
            _unitOfWork.Commit();




        }

        #region APIs
        public bool ForgotPasswordMobileAsync(string phone)
        {
            if (phone == null)
            {
                throw new Exception("Invalid Email");
            }
            User user = _userRepository.Get(item => item.Mobile == phone);
            if (user == null)
                throw new Exception("your Phone is not Correct");

            var verificationCode = Generate();
            user.IsHasTempPassword = true;
            user.TempPassword = verificationCode;
            user = _userRepository.Update(user);
            _unitOfWork.Commit();
            //SendSMS(user.Phone, verificationCode);
            //var creatingUserEmailDto = new CreatingUserEmailDto
            //{
            //    Body = @$"Dear {user.Name},<br />
            //              This email was generated as a request form the Forgot login retrieval based on the search criteria provided.<br />
            //              You'll find below a erification Code you can use it for now, this verification Code will not be sent for any other email addresses.<br />
            //              Verification Code: <b>{verificationCode}</b>",
            //    ReceiverEmail = email,
            //    Subject = "Forgot Password"
            //};
            //var isSend = _mailConfigrationService.Send(creatingUserEmailDto);
            if (true)
                return true;
            else
                throw new Exception("there is a problem we can't send reset password to your Email");
        }

        public string Generate()
        {
            //Random generator = new Random();
            //String r = generator.Next(0, 1000000).ToString("D6");
            //return r;
            return "1234";
        }

        public bool ConfirmForgotMobile(string phone, string code)
        {
            var isValid = _userRepository.GetRange().Any(x => x.Mobile == phone && x.TempPassword == code);
            return isValid;
        }

        public UserDto LoginMobile(string phone, string password, string deviceToken)
        {
            var user = _userRepository.Get(x => x.Mobile == phone);
            if (user == null)
                throw new Exception("Either your Phone address or password Is not Correct");
            if (!BC.Verify(password, user.Password))
                throw new Exception("Either your Phone address or password Is not Correct");
            if (user.IsBlocked.Value)
                throw new Exception("this user is blocked by admin please check with administrator");
            if (user.IsDeleted)
                throw new Exception("Not Authenticated User");
            user.DeviceToken = deviceToken;
            _unitOfWork.Commit();
            return _mapper.Map<User, UserDto>(user);
        }

        public UpdatedUserDto UpdateMoile(UpdatingUserDto updatingUserDto)
        {
            var user = _mapper.Map<UpdatingUserDto, User>(updatingUserDto);
            var updatedUser = _userRepository.Update(user);
            _unitOfWork.Commit();
            return _mapper.Map<User, UpdatedUserDto>(updatedUser);
        }

     
        public void UpdateUserBalance(Guid userId, double Value)
        {
            _userRepository.UpdateUserBalance(userId, Value);
            _unitOfWork.Commit();
        }


        #endregion

    }
}
