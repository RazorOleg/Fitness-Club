using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL;

namespace API
{
    public class WorkoutsController : IController<WorkoutModel>
    {
        private readonly IService<Workout> _service;
        private readonly IMapper _mapper;

        public WorkoutsController(IService<Workout> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public void Add(WorkoutModel workout)
        {
            _service.Add(_mapper.Map<Workout>(workout));
        }

        public void Update(WorkoutModel workout)
        {
            _service.Update(_mapper.Map<Workout>(workout));
        }

        public void Remove(int id)
        {
            _service.Remove(id);
        }

        public WorkoutModel GetById(int id)
        {
            return _mapper.Map<WorkoutModel>(_service.GetById(id));
        }

        public List<WorkoutModel> GetAll()
        {
            return _mapper.Map<List<WorkoutModel>>(_service.GetAll());
        }

        public bool Save()
        {
            _service.Save();
            return true;
        }
    }
}
