using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL;

namespace API
{
    public class UsersController : IController<UserModel>
    {
        private readonly IService<User> _service;
        private readonly IMapper _mapper;

        public UsersController(IService<User> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public void Add(UserModel user)
        {
            _service.Add(_mapper.Map<User>(user));
        }

        public void Update(UserModel user)
        {
            _service.Update(_mapper.Map<User>(user));
        }

        public void Remove(int id)
        {
            _service.Remove(id);
        }

        public UserModel GetById(int id)
        {
            return _mapper.Map<UserModel>(_service.GetById(id));
        }

        public List<UserModel> GetAll()
        {
            return _mapper.Map<List<UserModel>>(_service.GetAll());
        }

        public bool Save()
        {
            _service.Save();
            return true;
        }
    }
}
