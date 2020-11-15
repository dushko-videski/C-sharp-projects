using DomainLibrary.DB;
using DomainLibrary.Entities;
using System.Collections.Generic;

namespace ServicesLibrary.Services
{
    public class TrainingService<T> : ITrainingService<T> where T : Training
    {

        private IDb<T> _db;

        public TrainingService()
        {
            _db = new FileSystemDB<T>();
        }
        // 1)----------GET ALL TRAININGS-------
        public List<T> GetAllTrainings()
        {
            return _db.GetAll();
        }
        // 2)----------GET SINGLE TRAININGS-------
        public T GetSingleTraining(int id)
        {
            return _db.GetById(id);
        }
        // 3)---------ADD TRAINING---------------
        public void AddTraining(T training)
        {
            _db.Insert(training);
        }

    }
}
