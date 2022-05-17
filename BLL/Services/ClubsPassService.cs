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
    public class ClubsPassService : IService<ClubPass>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClubsPassService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(ClubPass clubpass)
        {
            _unitOfWork.ClubPass.Add(_mapper.Map<ClubPassEntity>(clubpass));
        }

        public void Update(ClubPass room)
        {
            _unitOfWork.ClubPass.Update(_mapper.Map<ClubPassEntity>(room));
        }

        public void Remove(int id)
        {
            _unitOfWork.ClubPass.Remove(id);
        }

        public ClubPass GetById(int id)
        {
            return _mapper.Map<ClubPass>(_unitOfWork.ClubPass.GetById(id));
        }

        public List<ClubPass> GetAll()
        {
            return _mapper.Map<List<ClubPass>>(_unitOfWork.ClubPass.GetAll());
        }
        public bool Save()
        {
            _unitOfWork.Save();
            return true;
        }
    }
}
