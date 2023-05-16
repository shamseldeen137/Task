using AutoMapper;

using System;
using Task.Data.Models;
using Task.Service.DTO.User;

namespace Task.Service.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {



            #region User
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreatingUserDto>().ReverseMap();
            CreateMap<User, CreatedUserDto>().ReverseMap();
            CreateMap<User, UpdatingUserDto>().ReverseMap();
            CreateMap<User, UpdatedUserDto>().ReverseMap();

            #endregion

            #region Transaction
            CreateMap<Transaction, TransactionDTO>().ReverseMap();
          

            #endregion

        }
    }
}
