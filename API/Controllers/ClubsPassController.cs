using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using AutoMapper;

namespace API
{
    public class ClubsPassController : IController<ClubPassModel>
    {
        private readonly IService<ClubPass> _service;
        private readonly IMapper _mapper;

        public ClubsPassController(IService<ClubPass> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public void Add(ClubPassModel clubPass)
        {
            _service.Add(_mapper.Map<ClubPass>(clubPass));
        }

        public void Update(ClubPassModel clubPass)
        {
            _service.Update(_mapper.Map<ClubPass>(clubPass));
        }

        public void Remove(int id)
        {
            _service.Remove(id);
        }

        public ClubPassModel GetById(int id)
        {
            return _mapper.Map<ClubPassModel>(_service.GetById(id));
        }

        public List<ClubPassModel> GetAll()
        {
            return _mapper.Map<List<ClubPassModel>>(_service.GetAll());
        }

        public bool Save()
        {
            _service.Save();
            return true;
        }
    }
}
