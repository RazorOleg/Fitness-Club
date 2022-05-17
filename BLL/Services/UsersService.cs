using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataBase;
using UoW;

namespace BLL
{
    public class UsersService : IService<User>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(User user)
        {
            _unitOfWork.Users.Add(_mapper.Map<UserEntity>(user));
        }

        public void Update(User user)
        {
            _unitOfWork.Users.Update(_mapper.Map<UserEntity>(user));
        }

        public void Remove(int id)
        {
            _unitOfWork.Users.Remove(id);
        }

        public User GetById(int id)
        {
            return _mapper.Map<User>(_unitOfWork.Users.GetById(id));
        }

        public List<User> GetAll()
        {
            return _mapper.Map<List<User>>(_unitOfWork.Users.GetAll());
        }
        public bool Save()
        {
            _unitOfWork.Save();
            return true;
        }
    }
}
