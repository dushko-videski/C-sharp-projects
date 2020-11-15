using DomainLibrary.Entities;
using System.Collections.Generic;

namespace ServicesLibrary.Services
{
    public interface ITrainingService<T> where T : Training
    {
        List<T> GetAllTrainings();
        T GetSingleTraining(int id);
        void AddTraining(T training);
    }
}
