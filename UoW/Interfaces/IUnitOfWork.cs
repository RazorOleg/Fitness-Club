using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using DataBase;

namespace UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<ClubEntity> Clubs { get; }
        IGenericRepository<ClubPassEntity> ClubPass { get; }
        IGenericRepository<UserEntity> Users { get; }
        IGenericRepository<WorkoutEntity> Workouts { get; }
        void Save(); //IDisposable - интерфейс для освобождения неуправляемых ресурсов
    }
}
