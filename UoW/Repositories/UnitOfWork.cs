using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Repository;

namespace UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FitnessContext context;
        public UnitOfWork()
        {
            context = new FitnessContext();
        }
        private IGenericRepository<ClubEntity> clubRepository;
        private IGenericRepository<ClubPassEntity> clubPassRepository;
        private IGenericRepository<UserEntity> userRepository;
        private IGenericRepository<WorkoutEntity> workoutRepository;

        public IGenericRepository<ClubEntity> Clubs 
        {
            get 
            {
                if (clubRepository == null) 
                    clubRepository = new ContextRepository<ClubEntity>(context);
                return clubRepository;
            }
        }
        public IGenericRepository<ClubPassEntity> ClubPass
        {
            get
            {
                if (clubPassRepository == null)
                    clubPassRepository = new ContextRepository<ClubPassEntity>(context);
                return clubPassRepository;
            }
        }
        public IGenericRepository<UserEntity> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new ContextRepository<UserEntity>(context);
                return userRepository;
            }
        }

        public IGenericRepository<WorkoutEntity> Workouts
        {
            get
            {
                if (workoutRepository == null)
                    workoutRepository = new ContextRepository<WorkoutEntity>(context);
                return workoutRepository;
            }
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
