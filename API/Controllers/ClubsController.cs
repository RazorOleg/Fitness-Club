using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL;

namespace API
{
    public class ClubsController : IController<ClubModel>
    {
        private readonly IService<Club> _service;
        private readonly IMapper _mapper;

        public ClubsController(IService<Club> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public void Add(ClubModel club)
        {
            _service.Add(_mapper.Map<Club>(club));
        }

        public void Update(ClubModel club)
        {
            _service.Update(_mapper.Map<Club>(club));
        }

        public void Remove(int id)
        {
            _service.Remove(id);
        }

        public ClubModel GetById(int id)
        {
            return _mapper.Map<ClubModel>(_service.GetById(id));
        }

        public List<ClubModel> GetAll()
        {
            return _mapper.Map<List<ClubModel>>(_service.GetAll());
        }

        public bool Save()
        {
            _service.Save();
            return true;
        }
    }
}
