using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Data.Models;
using Task.Repo.Base;
using Task.Repo.IRepo;
using Task.Service.DTO.User;
using Task.Service.IService;

namespace Task.Service.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionrRepository;
        private readonly IUserRepository _userRepository;



        public IUnitOfWork _unitOfWork { get; }
        private readonly IMapper _mapper;

        public TransactionService(IMapper mapper, IUserRepository userRepository, ITransactionRepository transactionRepository,

                           IUnitOfWork unitOfWork)
        {
            _transactionrRepository = transactionRepository;
            _userRepository = userRepository;

            _unitOfWork = unitOfWork; _mapper = mapper;
        }





     

        public TransactionDTO Get(Guid id)
        {
            var transaction = _transactionrRepository.GetRange(x => x.Id == id).FirstOrDefault();
            return _mapper.Map<Transaction, TransactionDTO>(transaction);
        }

        public IEnumerable<TransactionDTO> GetAll()
        {
            var transaction = _transactionrRepository.GetRange().OrderByDescending(x => x.CreatedAt);
            return _mapper.Map<IEnumerable<Transaction>, IEnumerable<TransactionDTO>>(transaction);
        }

        public UpdatedUserDto Update(TransactionDTO updatingUserDto)
        {
            throw new NotImplementedException();
        }

        public TransactionDTO Create(TransactionDTO transactionDTO)
        {
            try
            {
                //var transaction = _mapper.Map<TransactionDTO, Transaction>(transactionDTO);

                if (transactionDTO.RecieverId == transactionDTO.SendrId)
                {
                    throw new Exception("can't send to yourself Not Found");
                }

                var sender=  _userRepository.Get(u => u.Mobile == transactionDTO.SendrId);
            var reciever =  _userRepository.Get(u => u.Mobile == transactionDTO.RecieverId);
            if (sender== null|| reciever== null)
            {
                throw new Exception("User Not Found");
            }
            if (transactionDTO.Value<=0)
            {
                throw new Exception("Can't send 0 value");
            }
            if (sender.Balance< transactionDTO.Value) {
                throw new Exception("Unsufficent balance");

            }

                var createdtransaction = _transactionrRepository.Create(new Transaction() { 
                SendrId=sender.Id,
                RecieverId= reciever.Id,
                Value=transactionDTO.Value
                });
            _userRepository.UpdateUserBalance(sender.Id, sender.Balance.GetValueOrDefault() - transactionDTO.Value);
            _userRepository.UpdateUserBalance(reciever.Id, reciever.Balance.GetValueOrDefault() + transactionDTO.Value);
            _unitOfWork.Commit();
               


                return _mapper.Map<Transaction, TransactionDTO>(createdtransaction);
            }
            catch (Exception e)
            {

                throw ;
            }
        }

        public void Delete(Guid id)
        {
            _userRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public void UpdateUserCoins(Guid userId, double storecoins)
        {
            _userRepository.UpdateUserBalance(userId, storecoins);
            _unitOfWork.Commit();
        }
    }
}
