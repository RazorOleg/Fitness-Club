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
    public class ClubsService : IService<Club>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ClubsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(Club club)
        {
            _unitOfWork.Clubs.Add(_mapper.Map<ClubEntity>(club));
        }

        public void Update(Club club)
        {
            _unitOfWork.Clubs.Update(_mapper.Map<ClubEntity>(club));
        }

        public void Remove(int id)
        {
            _unitOfWork.Clubs.Remove(id);
        }

        public Club GetById(int id)
        {
            return _mapper.Map<Club>(_unitOfWork.Clubs.GetById(id));
        }

        public List<Club> GetAll()
        {
            return _mapper.Map<List<Club>>(_unitOfWork.Clubs.GetAll());
        }
        public bool Save()
        {
            _unitOfWork.Save();
            return true;
        }
    }
}
