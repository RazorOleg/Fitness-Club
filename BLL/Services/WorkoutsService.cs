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
    public class WorkoutsService : IService<Workout>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkoutsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(Workout workout)
        {
            _unitOfWork.Workouts.Add(_mapper.Map<WorkoutEntity>(workout));
        }

        public void Update(Workout workout)
        {
            _unitOfWork.Workouts.Update(_mapper.Map<WorkoutEntity>(workout));
        }

        public void Remove(int id)
        {
            _unitOfWork.Workouts.Remove(id);
        }

        public Workout GetById(int id)
        {
            return _mapper.Map<Workout>(_unitOfWork.Workouts.GetById(id));
        }

        public List<Workout> GetAll()
        {
            return _mapper.Map<List<Workout>>(_unitOfWork.Workouts.GetAll());
        }
        public bool Save()
        {
            _unitOfWork.Save();
            return true;
        }
    }
}
